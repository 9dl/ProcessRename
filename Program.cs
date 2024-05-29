using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Leaf.xNet;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace ProcessRename
{
    internal class Program
    {
        private static string RenameFile = "Sys64.exe";

        [STAThread]
        public static void Main()
        {
            try
            {
                Console.Clear();
                Console.Title = "ProcessRename | Made By 9dl";

                Console.Write("Input Process Name: ");
                string ProcessName = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Searching Processes!");

                foreach (var process in Process.GetProcessesByName(ProcessName))
                {
                    Console.WriteLine(" | Found Process!");
                    process.Kill();

                    // Get Process Path
                    string ProcessPath = process.MainModule.FileName;
                    Console.WriteLine(" | Path: " + ProcessPath);

                    // Rename Process
                    Console.WriteLine(" | Renaming Task.");

                    if (File.Exists(Path.GetDirectoryName(ProcessPath) + "//" + RenameFile))
                        File.Delete(Path.GetDirectoryName(ProcessPath) + "//" + RenameFile);

                    File.Copy(ProcessPath, Path.GetDirectoryName(ProcessPath) + "//" + RenameFile, true);

                    // Print Done
                    Console.WriteLine(" | Started Session! (Don't close Program)");

                    // Start Process
                    File.SetAttributes(Path.GetDirectoryName(ProcessPath) + "//" + RenameFile, FileAttributes.Hidden);
                    var RenameProc = Process.Start(Path.GetDirectoryName(ProcessPath) + "//" + RenameFile);
                    RenameProc.WaitForExit();

                    if (File.Exists(Path.GetDirectoryName(ProcessPath) + "//" + RenameFile))
                        File.Delete(Path.GetDirectoryName(ProcessPath) + "//" + RenameFile);
                }
                Console.WriteLine("Session Ended! You can close Program now.");

                Console.ReadKey();
                Main();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                Console.Clear();
                //Console.WriteLine("You can't use \"ProcessRename x64\" for 32x Programs");
                Console.WriteLine("You can't use \"ProcessRename x32\" for 64x Programs");
                Console.ReadKey();
                Environment.Exit(-1);
            }
        }
    }
}