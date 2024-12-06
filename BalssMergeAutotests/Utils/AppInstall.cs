using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace BalssMergeAutotests.Utils
{
    public class AppInstall
    {
        private const string PackageName = "com.right.hand.balls.merge";
        private readonly string ApkPath = Environment.GetEnvironmentVariable("apkPath")
                               ?? "C:\\apkBallsMerge\\Cat Balls_ Fun Merge.apk";

        public void CheckAndInstallApp()
        {
            if (!IsAppInstalled(PackageName))
            {
                Console.WriteLine("The application is not installed. Installing...");
                InstallApk(ApkPath);
            }
            else
            {
                Console.WriteLine("The application is already installed.");
            }
        }

        private bool IsAppInstalled(string packageName)
        {
            try
            {
                string output = AdbCommandExecutor.ExecuteAdbCommand($"shell pm list packages {packageName}");
                if (string.IsNullOrEmpty(output))
                {
                    Console.WriteLine("Failed to get package list");
                    return false;
                }
                return output.Contains(packageName);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error when executing the command: {ex.Message}");
                return false;
            }
        }

        private void InstallApk(string apkPath)
        {
            try
            {
                string output = AdbCommandExecutor.ExecuteAdbCommand($"install \"{apkPath}\"");
                Console.WriteLine(output);
                if (output.Contains("Success"))
                {
                    Console.WriteLine("Application is successfully installed.");
                }
                else
                {
                    Console.WriteLine("Failed to install the application..");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when installing the application: {ex.Message}");
            }
        }
    }
}
