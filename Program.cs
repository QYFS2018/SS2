using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Security.Permissions;
using WComm;


namespace SS2
{
    static class Program
    {

        [STAThread]
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            ReturnValue _result = new ReturnValue();

            string _action = "MarkOrderShip";
            

            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

                return;
            }
            else
            {
                _action = args[0].ToString().Trim();
                

                if (System.Configuration.ConfigurationSettings.AppSettings["Hold"].ToString() == "Y")
                {
                    FileInfo fi = new FileInfo("SS2.exe.config");

                    Common.Log(_action + "--Hold");

                    int holdMinutes = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["HoldMinutes"].ToString());

                    //Common.Log(_action+"---"+fi.LastWriteTime.ToString());

                    if (fi.LastWriteTime.AddMinutes(holdMinutes) > System.DateTime.Now)
                    {
                        Common.Log(_action + "--Hold--" + fi.LastWriteTime.AddMinutes(holdMinutes).ToString());

                        return;
                    }
                }



            }

         

            Process Process = new Process();
            _result = Process.Run(_action);


        }


        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception _ex = e.ExceptionObject as Exception;

            ReturnValue _result = new ReturnValue();
            _result.Success = false;
            _result.ErrMessage = _ex.ToString();
            //_result.EffectRows = 1;

            Common.ProcessError(_result.ErrMessage, false);

        }
    }
}
