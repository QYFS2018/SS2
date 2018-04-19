using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WComm;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using System.Web;
using System.Text.RegularExpressions;
using System.Xml;
using SS2.Model;

     
namespace SS2
{
    public class Common
    {
        public static string ProcessType;
       

        public static void Log(string message)
        {

            string path = Application.StartupPath + "/Log/" + ProcessType + "_" + System.DateTime.Now.ToString("yyyyMMdd") + ".log";

            string _message = "";

            if (message.ToUpper() == "FINISH")
            {
                _message = System.DateTime.Now.ToString() + "     Finish\r\n\r\n\r\n\r\n";
            }
            else
            {
                _message = System.DateTime.Now.ToString() + "     " + message + "\r\n";
            }

            #region Save File

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(_message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    if ((File.GetAttributes(path) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        File.SetAttributes(path, FileAttributes.Normal);
                    sw.WriteLine(_message);
                }
            }
            #endregion
        }

        public static void ProcessError(ReturnValue result)
        {
            Common.ProcessError(result, true);
        }
        public static void ProcessError(ReturnValue result, bool terminate)
        {
            if (ConInfo.Transcation != null)
            {
                ConInfo.Transcation.RollbackTransaction();
            }


            TApp_Log_SQL _tApp_Log_SQL = new TApp_Log_SQL();


            if (string.IsNullOrEmpty(result.ErrMessage) == true)
            {
                _tApp_Log_SQL.Notes = result.Code.ToString();
            }
            else
            {
                _tApp_Log_SQL.Notes = result.ErrMessage;
            }
            _tApp_Log_SQL.Success = false;
            _tApp_Log_SQL.SQLText = result.SQLText;
           
            _tApp_Log_SQL.SQLType = "Code";
            _tApp_Log_SQL.Save();

            SentAlterEmail(0, result.ErrMessage);

            if (terminate == true)
            {
                Common.Log("Finish");
                System.Environment.Exit(-1);
            }


            return;
        }
        public static void ProcessError(string message, bool terminate)
        {
            ReturnValue _result = new ReturnValue();
            _result.Success = false;
            _result.ErrMessage = message;

            Common.ProcessError(_result, terminate);
        }
        public static void SentAlterEmail(int failedRecordCount, string errorNotes)
        {
            if (failedRecordCount == 0)
            {
                return;
            }

            WComm.MyEmail _mail = new MyEmail();

            if (string.IsNullOrEmpty(ConfigurationSettings.AppSettings["SMTPServer"]) == true)
            {
                _mail.SMTPServer = "localhost";
            }
            else
            {
                _mail.SMTPServer = ConfigurationSettings.AppSettings["SMTPServer"].ToString();
            }
            if (string.IsNullOrEmpty(ConfigurationSettings.AppSettings["LogErrorEmailFrom"]) == true)
            {
                _mail.Address_From = "ludan176127@163.com";
            }
            else
            {
                _mail.Address_From = ConfigurationSettings.AppSettings["LogErrorEmailFrom"].ToString();
            }


            _mail.Address_To = ConfigurationSettings.AppSettings["MailTo"].ToString();

            _mail.CC = ConfigurationSettings.AppSettings["MailBCC"].ToString();



            // _mail.Subject = "Failure : [" + _Owner.Name + "] -- " + Common.ProcessType + " -- " + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm CST");

            _mail.Subject = "Failure : [" + ProcessType + "]";


            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsTestMode"].ToString()) == true)
            {
                _mail.Subject = "[Test][Job] " + _mail.Subject;
            }
            else
            {
                _mail.Subject = "[Prod][Job] " + _mail.Subject;

            }

            string _notes = "";




            //_notes = _notes + "Server : " + System.Environment.MachineName + "\r\n";

            _notes = _notes + "DATE : " + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm CST") + "\r\n";
            _notes = _notes + "Record(s) : " + failedRecordCount.ToString() + "\r\n" + "\r\n";
            _notes = _notes += "DETAILS : " + "\r\n";
            _notes = _notes + errorNotes + "\r\n\r\n";
            _notes = _notes += "This is a  CONFIDENTIAL email. Do not reply to this email.";


            _mail.BodyText = _notes;


            string _mailresult = "";
            try
            {
                _mailresult = _mail.Send();
            }
            catch (Exception ex)
            {
                Common.Log("SentAlterEmail---ER \r\n" + ex.ToString());
            }
            if (string.IsNullOrEmpty(_mailresult) == true)
            {
                Common.Log("SentAlterEmail---OK  Failed Record(s): " + failedRecordCount.ToString());
            }
            else
            {
                Common.Log("SentAlterEmail---ER \r\n" + _mailresult);
            }

            string path = Application.StartupPath + "//App_Log.log";
            string _message = "Date:" + System.DateTime.Now.ToString() + "\r\n" +
                             "Address From:" + _mail.Address_From + "\r\n" +
                             "Address To:" + _mail.Address_To + "\r\n" +
                             "Address Bcc:" + _mail.Bcc + "\r\n" +
                             "Subject:" + _mail.Subject + "\r\n" +
                             _mail.BodyText + "\r\n" +
                             "SMTP Server:" + _mail.SMTPServer + "\r\n\r\n";

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(_message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    if ((File.GetAttributes(path) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        File.SetAttributes(path, FileAttributes.Normal);
                    sw.WriteLine(_message);
                }
            }




        }

        public static bool AutoCreateProduct
        {
            get
            {
                return bool.Parse(System.Configuration.ConfigurationSettings.AppSettings["AutoCreateProduct"]);
            }
        }
    }
}
