using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ToolBOX_Remastered
{
    public partial class toolbox : Form
    {

        public toolbox()
        {
            InitializeComponent();
            FontManager.LoadCustomFonts();
            FontManager.ApplyCustomFonts(this);
            SetAppVersion();

            // DRAGGING
            top_bar.MouseDown += new MouseEventHandler(top_bar_MouseDown);
            top_bar.MouseMove += new MouseEventHandler(top_bar_MouseMove);
            top_bar.MouseUp += new MouseEventHandler(top_bar_MouseUp);

            // TOOLTIPS
            toolTip1.SetToolTip(this.tip1, "Includes all Microsoft Visual C++ Redistributables (2005-2022).");
            toolTip1.SetToolTip(this.tip2, "Includes all Microsoft .NET Runtime versions (v3.0.3-v8.0.4).");
            toolTip1.SetToolTip(this.tip3, "A slimmed-down version of Office, including only Word, Excell and Powerpoint.");
        }

        private Size originalSizeInstallerIcon;
        private Point originalLocationInstallerIcon;
        private Size originalSizeTweakerIcon;
        private Point originalLocationTweakerIcon;

        private void Form1_Load(object sender, EventArgs e)
        {
            originalSizeInstallerIcon = installer_icon.Size;
            originalLocationInstallerIcon = installer_icon.Location;
            originalSizeTweakerIcon = tweaker_icon.Size;
            originalLocationTweakerIcon = tweaker_icon.Location;
        }

        #region TOP BAR WINDOW DRAGGING ////////////////////////////////////////////////////////////////////////////////

        /// TOP BAR WINDOW DRAGGING
        ///

        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private string tempPath = Path.Combine(Path.GetTempPath(), "AppInstallerTemp");

        private void top_bar_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void top_bar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calculate the new position of the form
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void top_bar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        ///
        /// TOP BAR WINDOW DRAGGING

        #endregion TOP BAR WINDOW DRAGGING ////////////////////////////////////////////////////////////////////////////////

        #region EXIT & MINIMIZE BUTTONS ////////////////////////////////////////////////////////////////////////////////

        /// EXIT AND MINIMIZE BUTTONS
        ///

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        ///
        /// EXIT AND MINIMIZE BUTTONS

        #endregion EXIT & MINIMIZE BUTTONS ////////////////////////////////////////////////////////////////////////////////

        #region SIDE MENU & Donate ////////////////////////////////////////////////////////////////////////////////

        /// SIDE MENU & Donate
        ///

        private void installer_icon_Click(object sender, EventArgs e)
        {
            tweaker_back.Visible = false;
            tweaker_icon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            installer_back.Visible = true;
            installer_icon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            quick_installer.Visible = true;
        }

        private void tweaker_icon_Click(object sender, EventArgs e)
        {
            installer_back.Visible = false;
            installer_icon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            tweaker_back.Visible = true;
            tweaker_icon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            quick_installer.Visible = false;
        }

        private void naetech_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.naetech.ro");
        }

        private void donate_icon_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.revolut.me/nmd113");
        }

        private void SetAppVersion()
        {
            // Get the version of the current application
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            // Set the label text to show the version in the desired format
            app_version.Text = $"v{version}";
        }

        /// MENU MOUSE HOVER EFFECT

        private void installer_icon_MouseEnter(object sender, EventArgs e)
        {
            StartScaling(installer_icon, originalSizeInstallerIcon, originalLocationInstallerIcon, 1.05);
        }

        private void installer_icon_MouseLeave(object sender, EventArgs e)
        {
            StartScaling(installer_icon, originalSizeInstallerIcon, originalLocationInstallerIcon, 1.0);
        }

        private void tweaker_icon_MouseEnter(object sender, EventArgs e)
        {
            StartScaling(tweaker_icon, originalSizeTweakerIcon, originalLocationTweakerIcon, 1.05);
        }

        private void tweaker_icon_MouseLeave(object sender, EventArgs e)
        {
            StartScaling(tweaker_icon, originalSizeTweakerIcon, originalLocationTweakerIcon, 1.0);
        }

        private void StartScaling(PictureBox pictureBox, Size originalSize, Point originalLocation, double targetScale)
        {
            int originalWidth = originalSize.Width;
            int originalHeight = originalSize.Height;
            int targetWidth = (int)(originalWidth * targetScale);
            int targetHeight = (int)(originalHeight * targetScale);
            int stepCount = 5;  // Number of steps for smooth transition
            int delay = 5;  // Delay in milliseconds between steps

            Timer timer = new Timer();
            timer.Interval = delay;
            int currentStep = 0;

            timer.Tick += (s, e) =>
            {
                currentStep++;
                double scale = 1.0 + (targetScale - 1.0) * currentStep / stepCount;
                int newWidth = (int)(originalWidth * scale);
                int newHeight = (int)(originalHeight * scale);

                pictureBox.Size = new Size(newWidth, newHeight);
                pictureBox.Left = originalLocation.X - (newWidth - originalWidth) / 2;
                pictureBox.Top = originalLocation.Y - (newHeight - originalHeight) / 2;

                if (currentStep >= stepCount)
                {
                    timer.Stop();
                    timer.Dispose();
                }
            };

            timer.Start();
        }

        /// MENU MOUSE HOVER EFFECT


        ///
        /// SIDE MENU & Donate

        #endregion SIDE MENU & Donate ////////////////////////////////////////////////////////////////////////////////

        #region Quick Installer ////////////////////////////////////////////////////////////////////////////////

        /// QUICK INSTALLER
        ///

        private async void installbtn_Click(object sender, EventArgs e)
        {
            ToggleControls(false);

            try
            {

                Directory.CreateDirectory(tempPath);

                int totalTasks = quick_installer.Controls
                    .OfType<System.Windows.Forms.CheckBox>()
                    .Count(cb => cb.Checked);


                if (totalTasks == 0)
                {
                    MessageBox.Show("No applications selected for installation.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Directory.Delete(tempPath, true);
                    return;
                }

                var confirmationResult = MessageBox.Show($"You have selected {totalTasks} application(s) for installation. Do you want to proceed?","Confirm Installation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (confirmationResult == DialogResult.No)
                {
                    Directory.Delete(tempPath, true);
                    return;
                }

                var results = new StringBuilder("Setup results:\n\n");
                var tasks = new List<Func<Task>>();
                
                loadinglabel.Visible = true;
                progressbar.Visible = true;
                Cursor = Cursors.AppStarting;
                progressbar.Value = 0;

                if (cb_7zip.Checked) tasks.Add(() => DownloadAndInstallAsync("7-Zip", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/7zip-x64.exe", "/S", results));
                if (cb_qbit.Checked) tasks.Add(() => DownloadAndInstallAsync("qBittorrent", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/qbittorrent_x64_setup.exe", "/S", results));

                if (cb_vlc.Checked) tasks.Add(() => DownloadAndInstallAsync("VLC Media Player", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/vlc-win64.exe", "/L=1033 /S", results));
                if (cb_klite.Checked) tasks.Add(() => DownloadAndInstallAsync("K-Lite Codec Pack Standard", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/K-Lite_Codec_Pack_Standard.exe", "/verysilent", results));

                if (cb_steam.Checked) tasks.Add(() => DownloadAndInstallAsync("Steam", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/SteamSetup.exe", "/S", results));
                if (cb_epic.Checked) tasks.Add(() => DownloadAndInstallAsync("Epic Games", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/EpicInstaller.msi", "/passive", results));
                if (cb_ea.Checked) tasks.Add(() => DownloadAndInstallAsync("EA App", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/EAappInstaller.exe", "/S", results));
                if (cb_gog.Checked) tasks.Add(() => DownloadAndInstallAsync("GOG Galaxy", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/setup_galaxy.exe", "/verysilent", results));
                if (cb_ubi.Checked) tasks.Add(() => DownloadAndInstallAsync("Ubisoft Connect", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/UbisoftConnectInstaller.exe", "/S", results));
                if (cb_gfn.Checked) tasks.Add(() => DownloadAndInstallAsync("Geforce Now", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/GeForceNOW-release.exe", "/S", results));

                if (cb_chrome.Checked) tasks.Add(() => DownloadAndInstallAsync("Chrome Browser", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/ChromeSetup.exe", "/silent /install", results));
                if (cb_opera.Checked) tasks.Add(() => DownloadAndInstallAsync("Opera Browser", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/Opera_Setup_x64.exe", "/silent /allusers=1 /launchopera=0 /setdefaultbrowser=0", results));
                if (cb_brave.Checked) tasks.Add(() => DownloadAndInstallAsync("Brave Browser", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/BraveBrowserStandaloneSilentSetup.exe", "", results));
                if (cb_firefox.Checked) tasks.Add(() => DownloadAndInstallAsync("Firefox Browser", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/Firefox_Setup.exe", "/S /PreventRebootRequired=true", results));

                if (cb_libre.Checked) tasks.Add(() => DownloadAndInstallAsync("Libre Office", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/LibreOffice_Win_x86-64.msi", "/quiet /norestart", results));
                if (cb_gear.Checked) tasks.Add(() => DownloadAndInstallAsync("PDF Gear", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/pdfgear_setup.exe", "/VERYSILENT /NORESTART", results));
                if (cb_office.Checked) tasks.Add(() => DownloadAndInstallAsync("MS Office 2021 Lite", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/office2021.zip", "", results, true));
                if (cb_acrobat.Checked) tasks.Add(() => DownloadAndInstallAsync("Adobe Acrobat Reader", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/AcroRdrDC_en_US.exe", "/sAll /rs /msi EULA_ACCEPT=YES", results));

                if (cb_dx.Checked) tasks.Add(() => DownloadAndInstallAsync("DirectX", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/directx_Jun2010_redist.zip", "", results, true));
                if (cb_netrun.Checked) tasks.Add(() => DownloadAndInstallAsync(".Net Runtime All", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/NET-Runtimes-AIO.zip", "", results, true));
                if (cb_vcplus.Checked) tasks.Add(() => DownloadAndInstallAsync("Visual C++ All", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/Visual-C-Runtimes-All-in-One.zip", "", results, true));

                foreach (var task in tasks)
                {
                    progressbar.Value = 0;
                    await task();
                }

                loadinglabel.Visible = false;
                progressbar.Visible = false;
                Cursor = Cursors.Default;

                MessageBox.Show(results.ToString(), "Installation finished");
                Directory.Delete(tempPath, true);

                foreach (System.Windows.Forms.CheckBox checkbox in quick_installer.Controls.OfType<System.Windows.Forms.CheckBox>())
                {
                    checkbox.Checked = false;
                }
            }
            finally
            {
                ToggleControls(true);
            }
        }

        private async Task DownloadAndInstallAsync(string appName, string url, string arguments, StringBuilder results, bool isZip = false)
        {
            string fileName = Path.Combine(tempPath, Path.GetFileName(url));

            try
            {
                loadinglabel.Invoke((Action)(() =>
                {
                    loadinglabel.Text = $"Downloading: {appName}";
                }));

                using (WebClient client = new WebClient())
                {
                    client.DownloadProgressChanged += (s, e) =>
                    {
                        progressbar.Invoke((Action)(() =>
                        {
                            progressbar.Value = e.ProgressPercentage / 2;
                        }));
                    };

                    await client.DownloadFileTaskAsync(new Uri(url), fileName);
                }

                if (isZip)
                {
                    string extractedPath = Path.Combine(tempPath, appName);
                    System.IO.Compression.ZipFile.ExtractToDirectory(fileName, extractedPath);

                    if (appName == "Visual C++ All")
                    {
                        fileName = Path.Combine(extractedPath, "install_all.bat");
                    }
                    if (appName == ".Net Runtime All")
                    {
                        fileName = Path.Combine(extractedPath, "NETRuntime\\SilentSetup.bat");
                    }
                    else if (appName == "DirectX")
                    {
                        fileName = Path.Combine(extractedPath, "DXSETUP.exe");
                        arguments = "/silent";
                    }
                    else if (appName == "MS Office 2021 Lite")
                    {
                        fileName = Path.Combine(extractedPath, "install.bat");
                    }
                }

                loadinglabel.Invoke((Action)(() =>
                {
                    loadinglabel.Text = $"Installing: {appName}";
                }));

                Process process;
                if (fileName.EndsWith(".msi", StringComparison.OrdinalIgnoreCase))
                {
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
                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    });
                }

                int installationProgress = 50;
                while (!process.HasExited)
                {
                    await Task.Delay(500);
                    progressbar.Invoke((Action)(() =>
                    {
                        progressbar.Value = Math.Min(installationProgress + 1, 100);
                        installationProgress++;
                    }));
                }

                results.AppendLine($"{appName}: {(process.ExitCode == 0 ? "Success" : "Failed or incomplete")}");
            }
            catch (Exception ex)
            {
                results.AppendLine($"{appName}: Failed - {ex.Message}");
            }
        }

        private void ToggleControls(bool enable)
        {
            installbtn.Enabled = enable;
            exitbtn.Enabled = enable;
            tweaker_icon.Enabled = enable;
            installer_icon.Enabled = enable;

            foreach (Control control in quick_installer.Controls)
            {
                if (control is System.Windows.Forms.CheckBox checkbox)
                {
                    checkbox.Enabled = enable;

                    if (enable)
                    {
                        checkbox.ForeColor = Color.White;
                    }
                    else
                    {
                        checkbox.ForeColor = Color.Gray;
                        checkbox.BackColor = Color.Transparent;
                    }
                }
            }
        }

        ///
        /// QUICK INSTALLER

        #endregion  Quick Installer ////////////////////////////////////////////////////////////////////////////////

        #region Windows Tweaker ////////////////////////////////////////////////////////////////////////////////

        /// WINDOWS TWEAKER
        ///

        private async void button1_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX_Remastered.Resources.old_context_menu.reg",
                "Old context menu enabled! Restarting Explorer to apply changes...",
                "Failed to enable old context menu.",
                requiresRestart: true);

        }

        private async void button2_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX_Remastered.Resources.disable_ads.reg",
                "Windows Ads were disabled successfully! A windows restart may be required.",
                "Failed to disable Windows Ads.");

        }

        private async void button3_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX_Remastered.Resources.disable_web_search.reg",
                "Start Menu web search disabled successfully! A windows restart may be required.",
                "Failed to disable Start Menu web search.");

        }

        private async void button4_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX_Remastered.Resources.disable_auto_updates.reg",
                "Automatic Windows Updates disabled successfully! A restart may be required.",
                "Failed to disable Automatic Windows Updates.");

        }

        private async void button5_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX_Remastered.Resources.optimized_visual_effects.reg",
                "Optimized visual effects applied successfully! Logging out to apply changes...",
                "Failed to apply optimized visual effects.",
                requiresLogout: true);

        }

        private async void button6_Click(object sender, EventArgs e)
        {

            await PerformCommandAsync("powercfg", "-h off", "Hibernation has been disabled successfully.", "Failed to disable Hibernation.");

        }

        private async void button7_Click(object sender, EventArgs e)
        {

            await PerformCommandAsync("powercfg", "-duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61",
                "Ultimate Performance Plan added successfully. Enable it in Power settings.",
                "Failed to add Ultimate Performance Plan.");

        }

        private async void button8_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX_Remastered.Resources.legacy_photo_viewer.reg",
                "Legacy Photo Viewer enabled successfully.",
                "Failed to enable Legacy Photo Viewer.");

        }

        private async void button9_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX_Remastered.Resources.disable_gamebar.reg",
                "Game Bar and GameDVR disabled successfully! A Windows restart may be required.",
                "Failed to disable Game Bar and GameDVR.");

        }


        private async void button10_Click(object sender, EventArgs e)
        {

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = "-Command \"Start-Process fondue -ArgumentList '/Enable-feature:DirectPlay' -NoNewWindow -Wait\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true
                }
            };

            process.Start();
            string error = await process.StandardError.ReadToEndAsync();
            await Task.Run(() => process.WaitForExit());

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Failed to enable DirectPlay feature.\n" + error);
            }

        }


        private async void button11_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX_Remastered.Resources.run_with_priority.reg",
                "Run with priority context menu added successfully.",
                "Failed to add Run with priority context menu.");

        }

        private async void button12_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX_Remastered.Resources.disable-drivers-auto-update.reg",
                "Automatic updates for Windows drivers has been disabled successfully.",
                "Failed to disable Automatic updates for Windows drivers.");

        }


        private async void button13_Click(object sender, EventArgs e)
        {

            await ExecuteBatchFile("ToolBOX_Remastered.Resources.uninstall-onedrive.bat",
                "OneDrive uninstalled successfully. A windows restart may be required.",
                "Failed to uninstall OneDrive.");

        }

        private async void button14_Click(object sender, EventArgs e)
        {
            await ExecuteBatchFile("ToolBOX_Remastered.Resources.uninstall-copilot.bat",
                "Copilot uninstalled successfully. Restarting Explorer to apply changes...",
                "Failed to uninstall Copilot.",
                requiresRestart: true);
        }

        private async void button15_Click(object sender, EventArgs e)
        {
            await ExecuteBatchFile("ToolBOX_Remastered.Resources.disable-weather.bat",
                "Weather Widget disabled successfully. Restarting Explorer to apply changes...",
                "Failed to disable Weather Widget.",
                requiresRestart: true);
        }

        private void SetButtonState(Control control, bool isEnabled)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl is Button button)
                {
                    button.Enabled = isEnabled;
                }
                else
                {
                    SetButtonState(childControl, isEnabled);
                }
            }
        }

        private void SetWaitCursor(bool isWaiting)
        {
            this.UseWaitCursor = isWaiting;
            Application.DoEvents();
        }

        private async Task ExecuteBatchFile(string resourceName, string successMessage, string failureMessage, bool requiresRestart = false, bool requiresLogout = false)
        {
            try
            {
                SetButtonState(this, false);
                SetWaitCursor(true);

                string batFilePath = ExtractEmbeddedResource(resourceName);
                string result = await Task.Run(() => RunCommand("cmd.exe", $"/c \"{batFilePath}\""));

                if (string.IsNullOrWhiteSpace(result) || !result.Contains("error"))
                {
                    MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (requiresRestart) RestartExplorer();
                    if (requiresLogout) LogoutUser();
                }
                else
                {
                    MessageBox.Show($"{failureMessage}\nOutput:\n{result}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                File.Delete(batFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetButtonState(this, true);
                SetWaitCursor(false);
            }
        }

        private async Task PerformRegistryImport(string resourceName, string successMessage, string failureMessage, bool requiresRestart = false, bool requiresLogout = false)
        {
            try
            {
                SetButtonState(this, false);
                SetWaitCursor(true);

                string regFilePath = ExtractEmbeddedResource(resourceName);
                string result = await Task.Run(() => RunCommand("reg.exe", $"import \"{regFilePath}\""));

                if (string.IsNullOrWhiteSpace(result) || result.Contains("The operation completed successfully"))
                {
                    MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (requiresRestart) RestartExplorer();
                    if (requiresLogout) LogoutUser();
                }
                else
                {
                    MessageBox.Show($"{failureMessage}\nOutput:\n{result}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                File.Delete(regFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetButtonState(this, true);
                SetWaitCursor(false);
            }
        }

        private async Task PerformCommandAsync(string command, string arguments, string successMessage, string failureMessage)
        {
            try
            {
                SetButtonState(this, false);
                SetWaitCursor(true);

                string result = await Task.Run(() => RunCommand(command, arguments));

                if (string.IsNullOrWhiteSpace(result))
                {
                    MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"{failureMessage}\nOutput:\n{result}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetButtonState(this, true);
                SetWaitCursor(false);
            }
        }

        private string ExtractEmbeddedResource(string resourceName)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), resourceName);

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException("Resource not found", resourceName);
                }

                using (FileStream fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }
            }

            return tempPath;
        }

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
                    return process.ExitCode == 0 ? string.Empty : output;
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private void RestartExplorer()
        {
            var confirmResult = MessageBox.Show("Are you sure you want to restart Windows Explorer?", "Confirm Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    string killResult = RunCommand("taskkill", "/f /im explorer.exe");
                    if (!string.IsNullOrEmpty(killResult))
                    {
                        MessageBox.Show("Failed to stop Explorer: " + killResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    System.Threading.Thread.Sleep(1000);

                    string startResult = RunCommand("cmd", "/c start \"\" explorer.exe");
                    if (!string.IsNullOrEmpty(startResult))
                    {
                        MessageBox.Show("Failed to restart Explorer: " + startResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LogoutUser()
        {
            try
            {
                var confirmResult = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    string result = RunCommand("shutdown.exe", "/l /f");
                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show("Failed to log out: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///
        /// WINDOWS TWEAKER

        #endregion Windows Tweaker ////////////////////////////////////////////////////////////////////////////////
    }
}
