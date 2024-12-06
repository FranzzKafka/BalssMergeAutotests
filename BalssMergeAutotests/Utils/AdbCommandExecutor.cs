using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalssMergeAutotests.Utils
{
    public static class AdbCommandExecutor
    {
        public static string ExecuteAdbCommand(string command)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "adb",
                Arguments = command,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    Console.WriteLine($"Output: {output}");
                    Console.WriteLine($"Error: {error}");
                    throw new Exception($"ADB command failed with exit code: {process.ExitCode}. Error: {error}");
                }

                return output;
            }
        }
    }
}
