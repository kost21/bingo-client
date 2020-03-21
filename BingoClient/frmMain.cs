using DevExpress.XtraEditors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Linq;
using ToastNotifications;

namespace BingoClient
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        private string errorLogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Trace.log");
        private string config = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Config.xml");
        private string extensionsFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Extensions.txt");

        private void WriteLog(LogLevel logLevel, string logMessage)
        {
            string strLevel = string.Empty;

            switch (logLevel)
            {
                case LogLevel.Debug:
                    strLevel = "[DEBUG]:";
                    break;
                case LogLevel.Error:
                    strLevel = "[ERROR]:";
                    break;
                case LogLevel.Fatal:
                    strLevel = "[FATAL]:";
                    break;
                case LogLevel.Info:
                    strLevel = "[INFO]:";
                    break;
                case LogLevel.Warn:
                    strLevel = "[WARNING]:";
                    break;
                default:
                    break;
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(this.errorLogFilePath, true, Encoding.Default))
                {
                    string message = string.Format("{0} {1} {2}", DateTime.Now.ToString(), strLevel, logMessage);

                    sw.WriteLine(message);
                    this.meLog.Text += message + Environment.NewLine;
                }
            }
            catch
            {

            }
        }

        private void WaitForMe(int ms)
        {
            new System.Threading.ManualResetEvent(false).WaitOne(ms);
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2007 Green");

            this.LoadUserSettings();

            this.teShareDirectory.Enabled = false;
            this.sbtnSelectShareDirectory.Enabled = false;
            this.teUrl.Enabled = false;

            this.ActiveControl = this.meLog;
        }

        private void sbtnRun_Click(object sender, EventArgs e)
        {
            if (!this.bwCommon.IsBusy)
            {
                this.sbtnRun.Enabled = false;
                this.sbtnRun.Text = "ОБРАБОТКА...";

                this.bwCommon.RunWorkerAsync();
            }
            else
            {
                this.WriteLog(LogLevel.Info, "I am busy!");
            }
        }

        private void SetSelection()
        {
            this.meLog.SelectionStart = this.meLog.Text.Length;
            this.meLog.ScrollToCaret();
            this.meLog.Refresh();
        }

        private void ShowAlert(string message)
        {
            try
            {
                var toastNotification = new Notification
                (
                    "2pdf Bingo Client",
                    message,
                    60,
                    FormAnimator.AnimationMethod.Slide,
                    FormAnimator.AnimationDirection.Up
                );

                PlayNotificationSound("normal");
                toastNotification.Show();
            }
            catch (Exception ex)
            {
                this.WriteLog(LogLevel.Error, "Ошибка при отправке всплывающего сообщения: " + ex.Message);
            }
        }

        private void PlayNotificationSound(string sound)
        {
            var soundsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");
            var soundFile = Path.Combine(soundsFolder, sound + ".wav");

            using (var player = new System.Media.SoundPlayer(soundFile))
            {
                player.Play();
            }
        }

        private void bwCommon_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            File.Delete(this.errorLogFilePath);

            this.WriteLog(LogLevel.Info, "Начало работы программы");

            try
            {
                string share = this.teShareDirectory.Text.Trim();
                string user = this.teUserDirectory.Text.Trim();
                string url = this.teUrl.Text.Trim();

                if (string.IsNullOrWhiteSpace(share) || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(url))
                {
                    this.WriteLog(LogLevel.Error, "Не заполнены некоторые поля!");
                    return;
                }

                if (!Directory.Exists(share))
                {
                    this.WriteLog(LogLevel.Error, "Не найдена глобальная общая директория на сервере!");
                    return;
                }

                if (!Directory.Exists(user))
                {
                    this.WriteLog(LogLevel.Error, "Не найдена директория с пользовательскими файлами для обработки!");
                    return;
                }

                if (Directory.GetFiles(user).Count() < 1)
                {
                    this.WriteLog(LogLevel.Error, "Директория с пользовательскими файлами для обработки пуста!");
                    return;
                }

                this.WriteLog(LogLevel.Info, "Генерация нового GUID...");

                Guid id = Guid.NewGuid();

                this.WriteLog(LogLevel.Info, "Сгенерирован новый GUID: " + id);

                this.WriteLog(LogLevel.Info, "Создание уникальной директории на сервере...");

                string inDirectory = Path.Combine(share, id.ToString(), "In");
                if (!Directory.Exists(inDirectory))
                {
                    Directory.CreateDirectory(inDirectory);
                }

                this.WriteLog(LogLevel.Info, "Уникальная директория на сервере с входящими файлами: " + inDirectory);

                this.WriteLog(LogLevel.Info, "Копирование файлов на сервер...");

                List<string> extensions = new List<string>();
                try
                {
                    extensions = File.ReadAllLines(this.extensionsFilePath).ToList();
                    extensions.ForEach(x => x.ToLower());
                }
                catch
                {

                }

                if (extensions.Count == 0 || (extensions.Count == 1 && extensions[0] == "*"))
                {
                    foreach (var file in Directory.GetFiles(user))
                    {
                        File.Copy(file, Path.Combine(inDirectory, Path.GetFileName(file)));
                        this.WaitForMe(1000);
                    }
                }
                else
                {
                    foreach (var file in Directory.GetFiles(user))
                    {
                        string ext = Path.GetExtension(file);
                        if (extensions.Contains(ext.ToLower()))
                        {
                            File.Copy(file, Path.Combine(inDirectory, Path.GetFileName(file)));
                            this.WaitForMe(1000);
                        }
                    }
                }

                this.WriteLog(LogLevel.Info, "Ожидание загрузки файлов...");

                this.WaitForMe(10000);

                this.WriteLog(LogLevel.Info, "Формирование запроса на обработку загруженных файлов...");

                var client = new RestClient(url + "/" + "api/Bingo/CreatePdf");

                var request = new RestRequest(Method.POST);

                request.AddHeader("Content-Type", "application/json");

                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(new { Id = id });

                var response = client.Execute(request);

                this.WriteLog(LogLevel.Info, "Выполняется обработка...");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var obj = JObject.Parse(response.Content);

                    try
                    {
                        string status = obj["Status"].ToString();
                        string message = obj["Message"].ToString();
                        if (status == "Good")
                        {
                            this.WriteLog(LogLevel.Info, "Обработка закончена успешно!");

                            string outDirectory = Path.Combine(share, id.ToString(), "Out");

                            string outFilePathServer = Path.Combine(outDirectory, message.Split(':')[1].Trim());
                            string outFilePathClient = Path.Combine(user, Path.GetFileName(outFilePathServer));

                            this.WriteLog(LogLevel.Info, "Путь к сформированному файлу PDF на сервере: " + outFilePathServer);

                            File.Copy(outFilePathServer, outFilePathClient);

                            this.WaitForMe(1000);

                            this.WriteLog(LogLevel.Info, "Путь к сформированному файлу PDF на клиенте: " + outFilePathClient);

                            this.WriteLog(LogLevel.Info, "Удаление директории сессии на сервере...");

                            if (File.Exists(outFilePathClient))
                            {
                                Directory.Delete(Path.Combine(share, id.ToString()), true);
                            }
                            else
                            {
                                this.WriteLog(LogLevel.Info, "Локальный PDF файл не существует! Директория сессии не удаляется!");
                            }

                            BeginInvoke(new MethodInvoker(delegate
                            {
                                using (var frmYesNo = new frmYesNo())
                                {
                                    var result = frmYesNo.ShowDialog();
                                    if (result == DialogResult.OK)
                                    {
                                        System.Diagnostics.Process.Start(outFilePathClient);
                                    }
                                }
                            }));
                        }
                        else
                        {
                            this.WriteLog(LogLevel.Error, "Возникли ошибки при обработке: " + message);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.WriteLog(LogLevel.Error, "Ошибка при работе программы: " + ex.Message);
                    }
                }
                else
                {
                    this.WriteLog(LogLevel.Error, "Неверный ответ от сервера: " + response.Content);
                }


            }
            catch (Exception ex)
            {
                this.WriteLog(LogLevel.Error, "Ошибка при работе программы: " + ex.Message);
            }
        }

        private void bwCommon_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void bwCommon_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.sbtnRun.Enabled = true;
            this.sbtnRun.Text = "СТАРТ";

            this.sbtnClose.Enabled = true;
            this.sbtnClose.Text = "ЗАКРЫТЬ";

            if (e.Error != null)
            {
                this.WriteLog(LogLevel.Info, "Программа завершена с ошибками!");
            }
            else
            {
                this.WriteLog(LogLevel.Info, "Программа завершена!");
            }
        }

        private void CancelWorker()
        {
            if (this.bwCommon.IsBusy)
            {
                this.WriteLog(LogLevel.Info, "Остановка...");
                this.bwCommon.CancelAsync();
            }
        }

        private void sbtnStop_Click(object sender, EventArgs e)
        {
            if (!this.bwCommon.IsBusy)
            {
                this.WriteLog(LogLevel.Info, "I am not busy now!");
                return;
            }

            this.WriteLog(LogLevel.Info, "Запрос на остановку программы...");

            this.sbtnRun.Enabled = false;
            this.sbtnClose.Enabled = false;

            this.sbtnRun.Text = "ОСТАНОВКА...";

            this.CancelWorker();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveUserSettings();
        }

        private void sbtnClose_Click(object sender, EventArgs e)
        {
            this.WriteLog(LogLevel.Info, "Нажатие кнопки ЗАКРЫТЬ...");
            Application.Exit();
        }

        private void SaveUserSettings()
        {
            XElement rootItem = new XElement("settings");

            XElement shareItem = new XElement("param", new XAttribute("name", "share"), new XAttribute("value", this.teShareDirectory.Text));
            rootItem.Add(shareItem);

            XElement userItem = new XElement("param", new XAttribute("name", "user"), new XAttribute("value", this.teUserDirectory.Text));
            rootItem.Add(userItem);

            XElement urlItem = new XElement("param", new XAttribute("name", "url"), new XAttribute("value", this.teUrl.Text));
            rootItem.Add(urlItem);

            try
            {
                rootItem.Save(this.config);
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить XML файл с настройками элементов на форме.", this.Text);
            }
        }

        private void LoadUserSettings()
        {
            if (!File.Exists(this.config))
            {
                return;
            }

            try
            {
                XDocument doc = XDocument.Load(this.config);
                foreach (XElement el in doc.Descendants("param"))
                {
                    if (el.Attribute("name").Value == "share")
                    {
                        this.teShareDirectory.Text = el.Attribute("value").Value;
                    }

                    if (el.Attribute("name").Value == "user")
                    {
                        this.teUserDirectory.Text = el.Attribute("value").Value;
                    }

                    if (el.Attribute("name").Value == "url")
                    {
                        this.teUrl.Text = el.Attribute("value").Value;
                    }
                }

                doc = null;
            }
            catch
            {
                return;
            }

            return;
        }

        private void sbtnSelectTemplateCallbackFile_Click(object sender, EventArgs e)
        {
            if (this.fbdCommon.ShowDialog() == DialogResult.OK)
            {
                this.teShareDirectory.Text = this.fbdCommon.SelectedPath;
            }
        }

        private void sbtnSelectTemplateOrderFile_Click(object sender, EventArgs e)
        {
            if (this.fbdCommon.ShowDialog() == DialogResult.OK)
            {
                this.teUserDirectory.Text = this.fbdCommon.SelectedPath;
            }
        }

        private void meLog_EditValueChanged(object sender, EventArgs e)
        {
            this.SetSelection();
        }
    }

    public enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }
}
