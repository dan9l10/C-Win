using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public class service
    {
        ServiceController[] sc = ServiceController.GetServices();
        List<string> SerName = new List<string>();
        List<string> DispName = new List<string>();
        List<System.ServiceProcess.ServiceControllerStatus> Status = new List<ServiceControllerStatus>();
        List<string> CanStop = new List<string>();
        public int retNumber()
        {
            return sc.Length;
        }
        public void added()
        {
            for (int i = 0; i < sc.Length; i++)
            {
                SerName.Add(sc[i].ServiceName);
                DispName.Add(sc[i].DisplayName);
                Status.Add(sc[i].Status);
                CanStop.Add(sc[i].CanStop.ToString());
            }
        }
        public string retCanStop(int index)
        {
            return CanStop[index];
        }
        public string retStatus(int index)
        {
            return Status[index].ToString();
        }
        public string retDisp(int index)
        {
            return DispName[index];
        }
        public string retName(int index)
        {
            return SerName[index];
        }
        public void startService(int index)
        {
            sc[index].Start();
            Status.RemoveAt(index);
            CanStop.RemoveAt(index);
            Thread.Sleep(1000);
            ServiceController[] sc1 = ServiceController.GetServices();
            Status.Insert(index, sc1[index].Status);
            CanStop.Insert(index, sc1[index].CanStop.ToString());

        }
        public void stopService(int index)
        {
            sc[index].Stop();
            Status.RemoveAt(index);
            CanStop.RemoveAt(index);
            Thread.Sleep(1000);
            ServiceController[] sc1 = ServiceController.GetServices();
            Status.Insert(index, sc1[index].Status);
            CanStop.Insert(index, sc1[index].CanStop.ToString());
        }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
