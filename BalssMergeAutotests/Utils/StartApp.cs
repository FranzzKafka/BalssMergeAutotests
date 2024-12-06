using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalssMergeAutotests.Utils
{
    public class StartApp
    {
        public void StartApplication()
        {
            try
            {
                string packageName = "com.right.hand.balls.merge";
                string activityName = "com.unity3d.player.UnityPlayerActivity";
                string startAppCommand = $"shell am start -n {packageName}/{activityName}";

                var output = AdbCommandExecutor.ExecuteAdbCommand(startAppCommand);
                if (output.Contains("Success"))
                {
                    Console.WriteLine("Application data has been successfully started.");
                }
                else
                {
                    Console.WriteLine("Failed to start application");
                    Console.WriteLine($"{output}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error when trying to start application: {ex.Message}");
            }
        }
    }
}
