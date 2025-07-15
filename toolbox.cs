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
using System.ServiceProcess;
using System.Management;

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
            toolTip1.SetToolTip(this.tip4, "Enable this to use Winget for app installation. Ensures cleaner setup and up-to-date versions.");
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
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
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
                    .Count(cb => cb.Checked && cb != winGetCbx);

                if (totalTasks == 0)
                {
                    MessageBox.Show("No applications selected for installation.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Directory.Delete(tempPath, true);
                    return;
                }

                var confirmationResult = MessageBox.Show($"You have selected {totalTasks} application(s) for installation. Do you want to proceed?", "Confirm Installation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                await EnsureWingetInstalledAsync();

                if (cb_7zip.Checked) tasks.Add(() => InstallAppSmart("7zip.7zip", "7-Zip", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/7zip-x64.exe", "/S", results));
                if (cb_qbit.Checked) tasks.Add(() => InstallAppSmart("qBittorrent.qBittorrent", "qBittorrent", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/qbittorrent_x64_setup.exe", "/S", results));
                if (cb_vlc.Checked) tasks.Add(() => InstallAppSmart("VideoLAN.VLC", "VLC Media Player", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/vlc-win64.exe", "/L=1033 /S", results));
                if (cb_klite.Checked) tasks.Add(() => InstallAppSmart("CodecGuide.K-LiteCodecPack.Standard", "K-Lite Codec Pack Standard", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/K-Lite_Codec_Pack_Standard.exe", "/verysilent", results));
                if (cb_steam.Checked) tasks.Add(() => InstallAppSmart("Valve.Steam", "Steam", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/SteamSetup.exe", "/S", results));
                if (cb_epic.Checked) tasks.Add(() => InstallAppSmart("EpicGames.EpicGamesLauncher", "Epic Games", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/EpicInstaller.msi", "/passive", results));
                if (cb_ea.Checked) tasks.Add(() => InstallAppSmart("ElectronicArts.EADesktop", "EA App", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/EAappInstaller.exe", "/S", results));
                if (cb_gog.Checked) tasks.Add(() => InstallAppSmart("GOG.Galaxy", "GOG Galaxy", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/setup_galaxy.exe", "/verysilent", results));
                if (cb_ubi.Checked) tasks.Add(() => InstallAppSmart("Ubisoft.Connect", "Ubisoft Connect", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/UbisoftConnectInstaller.exe", "/S", results));
                if (cb_gfn.Checked) tasks.Add(() => InstallAppSmart("Nvidia.GeForceNow", "Geforce Now", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/GeForceNOW-release.exe", "/S", results));
                if (cb_chrome.Checked) tasks.Add(() => InstallAppSmart("Google.Chrome", "Chrome Browser", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/ChromeSetup.exe", "/silent /install", results));
                if (cb_opera.Checked) tasks.Add(() => InstallAppSmart("Opera.Opera", "Opera Browser", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/Opera_Setup_x64.exe", "/silent /allusers=1 /launchopera=0 /setdefaultbrowser=0", results));
                if (cb_brave.Checked) tasks.Add(() => InstallAppSmart("Brave.Brave", "Brave Browser", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/BraveBrowserStandaloneSilentSetup.exe", "", results));
                if (cb_firefox.Checked) tasks.Add(() => InstallAppSmart("Mozilla.Firefox", "Firefox Browser", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/Firefox_Setup.exe", "/S", results));
                if (cb_libre.Checked) tasks.Add(() => InstallAppSmart("TheDocumentFoundation.LibreOffice", "Libre Office", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/LibreOffice_Win_x86-64.msi", "/quiet /norestart", results));
                if (cb_gear.Checked) tasks.Add(() => InstallAppSmart("PDFgear.PDFgear", "PDF Gear", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/pdfgear_setup.exe", "/VERYSILENT /NORESTART", results));
                if (cb_office.Checked) tasks.Add(() => DownloadAndInstallAsync("MS Office 2021 Lite", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/office2021.zip", "", results, true));
                if (cb_acrobat.Checked) tasks.Add(() => InstallAppSmart("Adobe.Acrobat.Reader.64-bit", "Adobe Acrobat Reader", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/AcroRdrDC_en_US.exe", "/sAll /rs /msi EULA_ACCEPT=YES", results));
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
                    if (checkbox != winGetCbx)
                        checkbox.Checked = false;
                }
            }
            finally
            {
                ToggleControls(true);
            }
        }

        private Task EnsureWingetInstalledAsync()
        {
            return Task.Run(() =>
            {
                void UpdateLabel(string text)
                {
                    if (loadinglabel.InvokeRequired)
                        loadinglabel.Invoke(new Action(() => loadinglabel.Text = text));
                    else
                        loadinglabel.Text = text;
                }

                string wingetPath = "winget";
                string temp = Path.Combine(Path.GetTempPath(), "winget_fix");
                string scriptPath = Path.Combine(temp, "repair_winget.ps1");

                Directory.CreateDirectory(temp);

                UpdateLabel("Checking Winget...");

                try
                {
                    var check = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = wingetPath,
                            Arguments = "--version",
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        }
                    };
                    check.Start();
                    check.WaitForExit();

                    if (check.ExitCode == 0)
                    {
                        UpdateLabel("Winget already installed.");
                        return;
                    }
                }
                catch
                {
                    // Winget not found
                }

                UpdateLabel("Winget not found. Installing...");

                string psScript = "$ProgressPreference = 'SilentlyContinue'\r\n" +
                                  "Install-PackageProvider -Name NuGet -Force | Out-Null\r\n" +
                                  "Install-Module -Name Microsoft.WinGet.Client -Force -Repository PSGallery -AllowClobber | Out-Null\r\n" +
                                  "Repair-WinGetPackageManager -AllUsers\r\n";

                try
                {
                    File.WriteAllText(scriptPath, psScript);
                }
                catch
                {
                    UpdateLabel("Failed to write install script.");
                    return;
                }

                try
                {
                    var repair = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "powershell",
                            Arguments = "-ExecutionPolicy Bypass -File \"" + scriptPath + "\"",
                            UseShellExecute = false,
                            CreateNoWindow = true,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true
                        }
                    };
                    repair.Start();
                    repair.WaitForExit();
                }
                catch
                {
                    UpdateLabel("PowerShell repair failed.");
                    return;
                }

                UpdateLabel("Verifying Winget installation...");

                try
                {
                    var finalCheck = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = wingetPath,
                            Arguments = "--version",
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        }
                    };
                    finalCheck.Start();
                    finalCheck.WaitForExit();

                    if (finalCheck.ExitCode == 0)
                    {
                        UpdateLabel("Winget installed successfully.");
                    }
                    else
                    {
                        UpdateLabel("Winget install failed.");
                    }
                }
                catch
                {
                    UpdateLabel("Winget install verification failed.");
                }
            });
        }


        private async Task InstallAppSmart(string wingetId, string appName, string fallbackUrl, string fallbackArgs, StringBuilder results)
        {
            if (winGetCbx.Checked)
            {
                bool success = await InstallWithWingetAsync(wingetId, appName, results);
                if (!success)
                {
                    await DownloadAndInstallAsync(appName, fallbackUrl, fallbackArgs, results);
                }
            }
            else
            {
                await DownloadAndInstallAsync(appName, fallbackUrl, fallbackArgs, results);
            }
        }

        private async Task<bool> InstallWithWingetAsync(string packageId, string appName, StringBuilder results)
        {
            try
            {
                loadinglabel.Invoke(new Action(() =>
                {
                    loadinglabel.Text = $"Installing with winget: {appName}";
                }));

                var process = Process.Start(new ProcessStartInfo
                {
                    FileName = "winget",
                    Arguments = $"install --id \"{packageId}\" -e --silent --accept-package-agreements --accept-source-agreements",
                    UseShellExecute = false,
                    CreateNoWindow = true
                });

                int progress = 50;
                while (!process.HasExited)
                {
                    await Task.Delay(500);
                    progressbar.Invoke(new Action(() =>
                    {
                        progressbar.Value = Math.Min(progress + 1, 100);
                        progress++;
                    }));
                }

                if (process.ExitCode == 0)
                {
                    results.AppendLine($"{appName}: Installed with winget");
                    return true;
                }
            }
            catch { }

            return false;
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

        private async void button16_Click(object sender, EventArgs e)
        {
            toolbox tweaker = new toolbox();
            button16.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                await tweaker.ApplyServiceOptimizationsAsync();
                MessageBox.Show("Service optimizations applied. Please reboot for full effect.", "Optimization Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during service optimization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button16.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        public enum ServiceStartupType
        {
            Automatic,
            AutomaticDelayedStart,
            Manual,
            Disabled
        }

        public class ServiceConfig
        {
            public string Name { get; set; }
            public ServiceStartupType DesiredStartupType { get; set; }
        }

        public async Task ApplyServiceOptimizationsAsync()
        {
            List<ServiceConfig> configs = new List<ServiceConfig>
        {
            new ServiceConfig { Name = "AJRouter", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "ALG", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "AppIDSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "AppMgmt", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "AppReadiness", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "AppVClient", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "AppXSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Appinfo", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "AssignedAccessManagerSvc", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "AudioEndpointBuilder", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "AudioSrv", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "Audiosrv", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "AxInstSV", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "BDESVC", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "BFE", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "BITS", DesiredStartupType = ServiceStartupType.AutomaticDelayedStart },
            new ServiceConfig { Name = "BTAGService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "BcastDVRUserService_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "BluetoothUserService_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "BrokerInfrastructure", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "Browser", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "BthAvctpSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "BthHFSrv", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "CDPSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "CDPUserSvc_*", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "COMSysApp", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "CaptureService_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "CertPropSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "ClipSVC", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "ConsentUxUserSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "CoreMessagingRegistrar", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "CredentialEnrollmentManagerUserSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "CryptSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "CscService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DPS", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "DcomLaunch", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "DcpSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DevQueryBroker", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DeviceAssociationBrokerSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DeviceAssociationService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DeviceInstall", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DevicePickerUserSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DevicesFlowUserSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Dhcp", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "DiagTrack", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "DialogBlockingService", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "DispBrokerDesktopSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "DisplayEnhancementService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DmEnrollmentSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Dnscache", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "DoSvc", DesiredStartupType = ServiceStartupType.AutomaticDelayedStart },
            new ServiceConfig { Name = "DsSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DsmSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DusmSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "EFS", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "EapHost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "EntAppSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "EventLog", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "EventSystem", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "FDResPub", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Fax", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "FontCache", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "FrameServer", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "FrameServerMonitor", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "GraphicsPerfSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "HomeGroupListener", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "HomeGroupProvider", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "HvHost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "IEEtwCollectorService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "IKEEXT", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "InstallService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "InventorySvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "IpxlatCfgSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "KeyIso", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "KtmRm", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "LSM", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "LanmanServer", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "LanmanWorkstation", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "LicenseManager", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "LxpSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "MSDTC", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "MSiSCSI", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "MapsBroker", DesiredStartupType = ServiceStartupType.AutomaticDelayedStart },
            new ServiceConfig { Name = "McpManagementService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "MessagingService_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "MicrosoftEdgeElevationService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "MixedRealityOpenXRSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "MpsSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "MsKeyboardFilter", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "NPSMSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NaturalAuthentication", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NcaSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NcbService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NcdAutoSetup", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NetSetupSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NetTcpPortSharing", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "Netlogon", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "Netman", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NgcCtnrSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NgcSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NlaSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "OneSyncSvc_*", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "P9RdrService_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PNRPAutoReg", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PNRPsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PcaSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PeerDistSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PenService_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PerfHost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PhoneSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PimIndexMaintenanceSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PlugPlay", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PolicyAgent", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Power", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "PrintNotify", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PrintWorkflowUserSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "ProfSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "PushToInstall", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "QWAVE", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "RasAuto", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "RasMan", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "RemoteAccess", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "RemoteRegistry", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "RetailDemo", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "RmSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "RpcEptMapper", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "RpcLocator", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "RpcSs", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "SCPolicySvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SCardSvr", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SDRSVC", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SEMgrSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SENS", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "SNMPTRAP", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SNMPTrap", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SSDPSRV", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SamSs", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "ScDeviceEnum", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Schedule", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "SecurityHealthService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Sense", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SensorDataService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SensorService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SensrSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SessionEnv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SgrmBroker", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "SharedAccess", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SharedRealitySvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "ShellHWDetection", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "SmsRouter", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Spooler", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "SstpSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "StateRepository", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "StiSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "StorSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SysMain", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "SystemEventsBroker", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "TabletInputService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "TapiSrv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "TermService", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "TextInputManagementService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Themes", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "TieringEngineService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "TimeBroker", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "TimeBrokerSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "TokenBroker", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "TrkWks", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "TroubleshootingSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "TrustedInstaller", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "UI0Detect", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "UdkUserSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "UevAgentService", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "UmRdpService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "UnistoreSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "UserDataSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "UserManager", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "UsoSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "VGAuthService", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "VMTools", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "VSS", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "VacSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "VaultSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "W32Time", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WEPHOSTSVC", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WFDSConMgrSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WMPNetworkSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WManSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WPDBusEnum", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WSService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WSearch", DesiredStartupType = ServiceStartupType.AutomaticDelayedStart },
            new ServiceConfig { Name = "WaaSMedicSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WalletService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WarpJITSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WbioSrvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Wcmsvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "WcsPlugInService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WdNisSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WdiServiceHost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WdiSystemHost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WebClient", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Wecsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WerSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WiaRpc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WinDefend", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "WinHttpAutoProxySvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WinRM", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Winmgmt", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "WlanSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "WpcMonSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WpnService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WpnUserService_*", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "XblAuthManager", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "XblGameSave", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "XboxGipSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "XboxNetApiSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "autotimesvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "bthserv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "camsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "cbdhsvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "cloudidsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "dcsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "defragsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "diagnosticshub.standardcollector.service", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "diagsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "dmwappushservice", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "dot3svc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "edgeupdate", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "edgeupdatem", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "embeddedmode", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "fdPHost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "fhsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "gpsvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "hidserv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "icssvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "iphlpsvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "lfsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "lltdsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "lmhosts", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "mpssvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "msiserver", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "netprofm", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "nsi", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "p2pimsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "p2psvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "perceptionsimulation", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "pla", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "seclogon", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "shpamsvc", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "smphost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "spectrum", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "sppsvc", DesiredStartupType = ServiceStartupType.AutomaticDelayedStart },
            new ServiceConfig { Name = "ssh-agent", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "svsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "swprv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "tiledatamodelsvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "tzautoupdate", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "uhssvc", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "upnphost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vds", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vm3dservice", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "vmicguestinterface", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmicheartbeat", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmickvpexchange", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmicrdv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmicshutdown", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmictimesync", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmicvmsession", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmicvss", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmvss", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wbengine", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wcncsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "webthreatdefsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "webthreatdefusersvc_*", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "wercplsupport", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wisvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wlidsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wlpasvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wmiApSrv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "workfolderssvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wscsvc", DesiredStartupType = ServiceStartupType.AutomaticDelayedStart },
            new ServiceConfig { Name = "wuauserv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wudfsvc", DesiredStartupType = ServiceStartupType.Manual }
        };

            foreach (var config in configs)
            {
                try
                {
                    await Task.Run(() =>
                    {
                        SetServiceStartupType(config.Name, config.DesiredStartupType);

                        using (ServiceController service = new ServiceController(config.Name))
                        {
                            if ((config.DesiredStartupType == ServiceStartupType.Disabled || config.DesiredStartupType == ServiceStartupType.Manual) &&
                                (service.Status == ServiceControllerStatus.Running || service.Status == ServiceControllerStatus.StartPending))
                            {
                                service.Stop();
                                // WaitForStatus is also a blocking call, so it's good it's in Task.Run
                                service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                            }
                            else if (config.DesiredStartupType == ServiceStartupType.Automatic && service.Status != ServiceControllerStatus.Running)
                            {
                                service.Start();
                                service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                            }
                        }
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing service '{config.Name}': {ex.Message}");
                }
            }
        }

        private void SetServiceStartupType(string serviceName, ServiceStartupType startupType)
        {
            string wmiStartupType;
            switch (startupType)
            {
                case ServiceStartupType.Automatic:
                    wmiStartupType = "Automatic";
                    break;
                case ServiceStartupType.AutomaticDelayedStart:
                    wmiStartupType = "Automatic";
                    break;
                case ServiceStartupType.Manual:
                    wmiStartupType = "Manual";
                    break;
                case ServiceStartupType.Disabled:
                    wmiStartupType = "Disabled";
                    break;
                default:
                    throw new ArgumentException("Invalid ServiceStartupType.");
            }

            using (ManagementObject service = new ManagementObject($"Win32_Service.Name='{serviceName}'"))
            {
                ManagementBaseObject inParams = service.GetMethodParameters("ChangeStartMode");
                inParams["StartMode"] = wmiStartupType;
                service.InvokeMethod("ChangeStartMode", inParams, null);
            }
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
