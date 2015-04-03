using System.Diagnostics;

namespace Epam.NetMentoring.CommandPattern
{
    class ProcessManager
    {
        public string GetListOfProcesses()
        {
            string result = "";
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                result = result + theprocess + "\r\n";
            }
            return result;
        }

    }
}
