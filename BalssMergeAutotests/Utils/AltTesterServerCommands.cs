using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BalssMergeAutotests.Utils
{
    public class AltTesterServerCommands
    {
        private const string AltTesterServerProcessName = "AltTesterDesktop";

        public void StartAltTesterServer()
        {
            if (IsAppRunning(AltTesterServerProcessName))
            {
                return;
            }
            string altTesterAppPath = Environment.GetEnvironmentVariable("altTesterAppPath")
                          ?? @"C:\Program Files\AltTesterDesktop\AltTesterDesktop.exe";
            try
            {
                Process.Start(altTesterAppPath);
                Console.WriteLine("Alt Tester server started");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while trying to start Alt Tester server: {ex.Message}");
            }
        }

        public void ShutDownAltTesterServer()
        {
            try
            {
                foreach (var process in Process.GetProcessesByName(AltTesterServerProcessName))
                {
                    process.Kill();
                    process.WaitForExit();
                    Console.WriteLine($"{AltTesterServerProcessName} was shuted down.");
                }
            }
            catch(Exception ex )
            {
                Console.WriteLine($"Error whyle trying to shut dowm AltTester server: {ex.Message}");
            }
        }

        private bool IsAppRunning(string appName)
        {
            try
            {
                var processes = Process.GetProcessesByName(appName);
                return processes.Any();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when checking application operation {appName}: {ex.Message}");
                return false;
            }
        }
    }
}
