using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ToolBox_by_NaeTech
{
    public partial class toolbox : Form
    {
        //
        //  Declare the variables at the class level
        //
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        //
        //  Define path for temporary files
        //
        private string tempPath = Path.Combine(Path.GetTempPath(), "AppInstallerTemp");

        //
        //  Loading app...
        //
        public toolbox()
        {
            InitializeComponent();

            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
        }


        ///////////////////////
        /// QUICK INSTALLER ///
        ///////////////////////

        //
        //  Main function for Install button click
        //

        private async void installbtn_ClickAsync(object sender, EventArgs e)
        {
            Directory.CreateDirectory(tempPath); // Create temporary folder

            // Show loading message
            loadingLabel.Visible = true;

            var results = new StringBuilder("Installation Summary:\n\n");

            if (check1.Checked) await DownloadAndInstallAsync("K-Lite Mega Codec Pack", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/K-Lite_Codec_Pack_1865_Standard.exe", "/verysilent", results);
            if (check2.Checked) await DownloadAndInstallAsync("VLC Media Player", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/vlc-3.0.21-win64.exe", "/L=1033 /S", results);
            if (check3.Checked) await DownloadAndInstallAsync("7-Zip", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/7z2408-x64.exe", "/S", results);
            if (check4.Checked) await DownloadAndInstallAsync("qBittorrent", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/qbittorrent_5.0.1_x64_setup.exe", "/S", results);
            if (check5.Checked) await DownloadAndInstallAsync("Steam", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/SteamSetup.exe", "/S", results);
            if (check6.Checked) await DownloadAndInstallAsync("Epic Games", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/EpicInstaller-15.17.1.msi", "/passive", results);
            if (check7.Checked) await DownloadAndInstallAsync("Ubisoft Connect", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/UbisoftConnectInstaller.exe", "/S", results);
            if (check8.Checked) await DownloadAndInstallAsync("EA App", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/EAappInstaller.exe", "/S", results);
            if (check9.Checked) await DownloadAndInstallAsync("GOG Galaxy", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/setup_galaxy_2.0.77.22.exe", "/verysilent", results);
            if (check10.Checked) await DownloadAndInstallAsync("Geforce Now", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/GeForceNOW-release.exe", "/S", results);
            if (check15.Checked) await DownloadAndInstallAsync("Chrome Browser", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/ChromeSetup.exe", "/silent /install", results);
            if (check16.Checked) await DownloadAndInstallAsync("Firefox Browser", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/Firefox_Setup_132.0b9.exe", "/S /PreventRebootRequired=true", results);
            if (check17.Checked) await DownloadAndInstallAsync("Opera Browser", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/Opera_114.0.5282.94_Setup_x64.exe", "/silent /allusers=1 /launchopera=0 /setdefaultbrowser=0", results);
            if (check18.Checked) await DownloadAndInstallAsync("Brave Browser", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/BraveBrowserStandaloneSilentSetup.exe", "", results);
            if (check11.Checked) await DownloadAndInstallAsync("DirectX", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/directx_Jun2010_redist.zip", "", results, true);
            if (check12.Checked) await DownloadAndInstallAsync(".Net Runtime 8.0.10", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/windowsdesktop-runtime-8.0.10-win-x64.exe", "/install /quiet /norestart", results);
            if (check13.Checked) await DownloadAndInstallAsync("Visual C++ (All-In-One)", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/Visual-C-Runtimes-All-in-One-Oct-2024.zip", "", results, true);
            if (check14.Checked) await DownloadAndInstallAsync(".Net Framework 4.8.1", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/NDP481-x86-x64-AllOS-ENU.exe", "/quiet /AcceptEULA /norestart", results);

            // Hide the loading message
            loadingLabel.Visible = false;

            // Show the summary and clean up
            MessageBox.Show(results.ToString(), "Installation Summary");
            Directory.Delete(tempPath, true); // Clean up temp folder

            // Uncheck all checkboxes after installation
            foreach (var control in this.Controls)
            {
                if (control is CheckBox checkbox)
                {
                    checkbox.Checked = false;
                }
            }
        }

        private async Task DownloadAndInstallAsync(string appName, string url, string arguments, StringBuilder results, bool isZip = false)
        {
            string fileName = Path.Combine(tempPath, Path.GetFileName(url));

            try
            {
                using (WebClient client = new WebClient())
                {
                    await client.DownloadFileTaskAsync(new Uri(url), fileName); // Download installer
                }

                if (isZip)
                {
                    string extractedPath = Path.Combine(tempPath, appName);
                    System.IO.Compression.ZipFile.ExtractToDirectory(fileName, extractedPath); // Unzip if needed

                    // Check if the app is Visual C++ and set the fileName accordingly
                    if (appName == "Visual C++ (All-In-One)")
                    {
                        fileName = Path.Combine(extractedPath, "install_all.bat");
                    }
                    // Set fileName to DXSETUP.exe path
                    else if (appName == "DirectX")
                    {
                        fileName = Path.Combine(extractedPath, "DXSETUP.exe");
                        arguments = "/silent"; // Add the silent argument for DXSETUP.exe
                    }
                }

                // Determine if the file is an MSI or EXE
                Process process;
                if (fileName.EndsWith(".msi", StringComparison.OrdinalIgnoreCase))
                {
                    // Use MsiExec for MSI files
                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "MsiExec.exe",
                        Arguments = $"/i \"{fileName}\" {arguments}",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    });
                }
                else
                {
                    // Use direct execution for EXE files
                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    });
                }

                process.WaitForExit(); // Wait for process completion

                // Log result based on process exit code
                results.AppendLine($"{appName}: {(process.ExitCode == 0 ? "Success" : "Failed")}");
            }
            catch (Exception ex)
            {
                results.AppendLine($"{appName}: Failed - {ex.Message}");
            }
        }

        ///////////////////////
        /// WINDOWS TWEAKER ///
        ///////////////////////

        private void button1_Click(object sender, EventArgs e)
        {
            var exePath = ExtractEmbeddedResource("ToolBox_by_NaeTech.RegistryHelper.exe");
            var result = ExecuteHelper(exePath, "\"reg.exe add HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32 /f /ve\"");

            if (result)
            {
                MessageBox.Show("Old context menu enabled! Restarting explorer.exe to apply.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RestartExplorer();
            }
            else
            {
                MessageBox.Show("Failed to enable context menu.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Extract the .reg file from embedded resources
                var regFilePath = ExtractEmbeddedResource("ToolBox_by_NaeTech.Resources.disable_ads.reg");

                // Import the .reg file using the RunCommand method directly
                var result = RunCommand("reg.exe", $"import \"{regFilePath}\"");

                // Check the result of the command
                if (result.Contains("The operation completed successfully") || result.Trim() == "")
                {
                    MessageBox.Show("Windows Ads was disabled successfully! Restart may be required.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to disable Windows Ads.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Clean up the .reg file
                if (File.Exists(regFilePath))
                {
                    File.Delete(regFilePath);  // Clean up the .reg file
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Extract the .reg file from embedded resources
                var regFilePath = ExtractEmbeddedResource("ToolBox_by_NaeTech.Resources.disable_web_search.reg");

                // Import the .reg file using the RunCommand method directly
                var result = RunCommand("reg.exe", $"import \"{regFilePath}\"");

                // Check the result of the command
                if (result.Contains("The operation completed successfully") || result.Trim() == "")
                {
                    MessageBox.Show("Web search in Start Menu was disabled successfully! Restart may be required.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Failed to disable Start Menu web search. Output:\n{result}", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Clean up the .reg file
                if (File.Exists(regFilePath))
                {
                    File.Delete(regFilePath);  // Clean up the .reg file
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var exePath = ExtractEmbeddedResource("ToolBox_by_NaeTech.RegistryHelper.exe");

            // Registry commands for Windows Update settings
            var result1 = ExecuteHelper(exePath, "\"reg.exe add HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU /v AUOptions /t REG_DWORD /d 2 /f\"");
            var result2 = ExecuteHelper(exePath, "\"reg.exe add HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU /v NoAutoUpdate /t REG_DWORD /d 1 /f\"");

            // Check results of all commands
            if (result1 && result2)
            {
                MessageBox.Show("Automatic Windows Updates disabled successfully! Restart may be required.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to disable Automatic Windows Updates.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Extract the .reg file from embedded resources
                var regFilePath = ExtractEmbeddedResource("ToolBox_by_NaeTech.Resources.optimized_visual_effects.reg");

                // Import the .reg file using the RunCommand method directly
                var result = RunCommand("reg.exe", $"import \"{regFilePath}\"");

                // Check the result of the command
                if (result.Contains("The operation completed successfully") || result.Trim() == "")
                {
                    MessageBox.Show("Optimized visual effects applied successfully! Logging out to apply.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogoutUser();
                }
                else
                {
                    MessageBox.Show($"Failed to apply optimized visual effects. Output:\n{result}", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Clean up the .reg file
                if (File.Exists(regFilePath))
                {
                    File.Delete(regFilePath);  // Clean up the .reg file
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string command = "powercfg";
            string arguments = "-h off";
            string output = RunCommand(command, arguments);
            if (string.IsNullOrEmpty(output))
            {
                MessageBox.Show("Hibernation has been disabled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to disable Hibernation: " + output, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string command = "powercfg";
            string arguments = "-duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61";
            string output = RunCommand(command, arguments);
            MessageBox.Show("Ultimate Performance Plan has been added. Enable it in Power settings.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                // Extract the .reg file from embedded resources
                var regFilePath = ExtractEmbeddedResource("ToolBox_by_NaeTech.Resources.legacy_photo_viewer.reg");

                // Import the .reg file using the RunCommand method directly
                var result = RunCommand("reg.exe", $"import \"{regFilePath}\"");

                // Check the result of the command
                if (result.Contains("The operation completed successfully") || result.Trim() == "")
                {
                    MessageBox.Show("Legacy Photo Viewer enabled successfully!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Failed to enable Legacy Photo Viewer. Output:\n{result}", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Clean up the .reg file
                if (File.Exists(regFilePath))
                {
                    File.Delete(regFilePath);  // Clean up the .reg file
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            var exePath = ExtractEmbeddedResource("ToolBox_by_NaeTech.RegistryHelper.exe");

            // Disable Full-Screen Optimizations
            var result1 = ExecuteHelper(exePath, "\"reg.exe add HKCU\\System\\GameConfigStore /v GameDVR_FSEBehaviorMode /t REG_DWORD /d 2 /f\"");
            var result2 = ExecuteHelper(exePath, "\"reg.exe add HKCU\\System\\GameConfigStore /v GameDVR_HonorUserFSEBehaviorMode /t REG_DWORD /d 1 /f\"");

            // Disable Game Bar
            var result3 = ExecuteHelper(exePath, "\"reg.exe add HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\GameDVR /v AppCaptureEnabled /t REG_DWORD /d 0 /f\"");
            var result4 = ExecuteHelper(exePath, "\"reg.exe add HKCU\\Software\\Microsoft\\GameBar /v AllowAutoGameMode /t REG_DWORD /d 0 /f\"");
            var result5 = ExecuteHelper(exePath, "\"reg.exe add HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\GameDVR /v GameDVR_Enabled /t REG_DWORD /d 0 /f\"");

            // Check results of all commands
            if (result1 && result2 && result3 && result4 && result5)
            {
                MessageBox.Show("Full-Screen Optimizations and Game Bar disabled successfully! Restart may be required.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to disable Full-Screen Optimizations and Game Bar.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            // Enable DirectPlay (Legacy) feature using PowerShell
            var result = await Task.Run(() => RunCommand("powershell.exe", "-Command \"Start-Process fondue -ArgumentList '/Enable-feature:DirectPlay' -NoNewWindow -Wait\""));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                // Extract the .reg file from embedded resources
                var regFilePath = ExtractEmbeddedResource("ToolBox_by_NaeTech.Resources.run_with_priority.reg");

                // Import the .reg file using the RunCommand method directly
                var result = RunCommand("reg.exe", $"import \"{regFilePath}\"");

                // Check the result of the command
                if (result.Contains("The operation completed successfully") || result.Trim() == "")
                {
                    MessageBox.Show("Run with priority context menu added successfully!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Failed to add Run with priority context menu. Output:\n{result}", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Clean up the .reg file
                if (File.Exists(regFilePath))
                {
                    File.Delete(regFilePath);  // Clean up the .reg file
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //
        //  EXIT AND MINIMIZE BUTTONS
        //

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //
        //  WINDOW DRAGGING
        //

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Start dragging
            isDragging = true;
            // Record the cursor's location and the form's location
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calculate the new position of the form
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // Stop dragging
            isDragging = false;
        }

        //
        //  OTHER METHODS
        //

        private string RunCommand(string command, string arguments)
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(processInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ex.Message;
            }
        }

        private string ExtractEmbeddedResource(string resourceName)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                var tempFile = Path.Combine(Path.GetTempPath(), resourceName);
                using (var fileStream = new FileStream(tempFile, FileMode.Create))
                {
                    stream.CopyTo(fileStream);
                }
                return tempFile;
            }
        }

        private bool ExecuteHelper(string fileName, string arguments)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    Verb = "runas",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = new Process { StartInfo = processInfo })
                {
                    process.Start();
                    process.WaitForExit();
                    return process.ExitCode == 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void RestartExplorer()
        {
            // Close all explorer windows but keep the taskbar and desktop visible
            foreach (Process process in Process.GetProcessesByName("explorer"))
            {
                if (process.MainWindowHandle != IntPtr.Zero)
                {
                    process.Kill();
                }
            }

            System.Threading.Thread.Sleep(1000); // Wait a bit to ensure it closes completely

            // Relaunch explorer.exe
            var processInfo = new ProcessStartInfo("explorer.exe")
            {
                RedirectStandardOutput = false,
                UseShellExecute = true,
                CreateNoWindow = false
            };
            using (var process = new Process { StartInfo = processInfo })
            {
                process.Start();
            }
        }

        private void LogoutUser()
        {
            try
            {
                Process.Start("shutdown.exe", "/l /f");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to log out: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
