using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalssMergeAutotests.Utils
{
    public class CleanAppData
    {
        public void ClearAppData()
        {
            try
            {
                string packageName = "com.right.hand.balls.merge";
                string command = $"shell pm clear {packageName}";

                var output = AdbCommandExecutor.ExecuteAdbCommand(command);
                if (output.Contains("Success"))
                {
                    Console.WriteLine("Application data has been successfully cleared.");
                }
                else
                {
                    Console.WriteLine("Failed to clear application data");
                    Console.WriteLine($"{output}");
                }
            }
            catch(Exception ex )
            {
                Console.WriteLine($"Error when trying to clear application data: {ex.Message}");

            }
        }
    }
}
