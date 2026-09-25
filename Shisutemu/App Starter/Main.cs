using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Utilities.Extensions;

namespace AppStarter
{
    public partial class Main : ServiceBase
    {
        #region Constants

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Enums

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        private List<Process> _ProcessList = new List<Process>();

        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor

        public Main()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        private List<StartInfo> ReadConfig()
        {
            List<StartInfo> ConfigList = new List<StartInfo>();
            string ApplicationFolder = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string Filename = "AppStartInfo.xml";
            string FullPath = System.IO.Path.Combine(ApplicationFolder, Filename);

            ConfigList = ConfigList.LoadFromFile(FullPath);

            return ConfigList;
        }

        private void StartProcesses(List<StartInfo> ConfigurationList)
        {
            foreach (StartInfo StartInfo in ConfigurationList)
            {
                Process p = new Process();

                ProcessStartInfo Info = new ProcessStartInfo(StartInfo.Filename, StartInfo.Arguments);
                Info.CreateNoWindow = StartInfo.CreateNoWindow;
                Info.UseShellExecute = StartInfo.UseShellExecute;
                Info.WindowStyle = StartInfo.WindowStyle;

                p.StartInfo = Info;

                Task t = new Task(() =>
                {
                    p.Start();
                    _ProcessList.Add(p);
                });

                t.Start();
            }
        }

        private void StopProcesses()
        {
            int ProcessCounter = 0;

            try
            {
                while (_ProcessList.Count > 0)
                {
                    Process p = _ProcessList[ProcessCounter];

                    try
                    {
                        // Check to see if the process is running, if so, close it
                        if (!p.HasExited)
                        {
                            p.Kill();
                        }
                    }
                    catch
                    {
                        // The nice way didn't work, so just close it
                        try
                        {
                            p.Kill();
                        }
                        catch
                        {
                        }
                    }
                    finally
                    {
                        _ProcessList.Remove(p);
                    }

                    Thread.Sleep(50);
                }


            }
            catch
            {
            }
        }

        #endregion

        #region Public and Protected Methods

        protected internal void RunAsConsole(string[] args)
        {
            // Read config file
            List<StartInfo> StartInfoList = ReadConfig();

            StartProcesses(StartInfoList);

            Console.WriteLine("Press the enter key to exit");
            Console.ReadLine();
            OnStop();
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            List<StartInfo> StartInfoList = ReadConfig();

            StartProcesses(StartInfoList);
        }

        protected override void OnStop()
        {
            StopProcesses();

            base.OnStop();
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion
    }
}

