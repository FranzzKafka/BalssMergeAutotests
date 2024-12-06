using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalssMergeAutotests.Utils
{
    public class BackSystemCommand
    {
        public void PressBackButtonSystemCommand()
        {
            try
            {
                string output = AdbCommandExecutor.ExecuteAdbCommand($"shell input keyevent KEYCODE_BACK");
                if (string.IsNullOrEmpty(output))
                {
                    Console.WriteLine("Failed to apply back system command");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when executing the command: {ex.Message}");
            }
        }
    }
}
