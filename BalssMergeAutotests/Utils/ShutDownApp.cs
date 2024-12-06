using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalssMergeAutotests.Utils
{
    public class ShutDownApp
    {
        public void ShutDownApplication()
        {
            try
            {
                string packageName = "com.right.hand.balls.merge";
                string command = $"shell am force-stop {packageName}";

                var output = AdbCommandExecutor.ExecuteAdbCommand(command);
                if (output.Contains("Success"))
                {
                    Console.WriteLine("Application data has been successfully shuted down.");
                }
                else
                {
                    Console.WriteLine("Failed to shut down application");
                    Console.WriteLine($"{output}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error when trying to shut down application: {ex.Message}");
            }
        }
    }
}
