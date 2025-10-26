using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolBOX_by_Naetech
{
    public partial class Toolbox : Form
    {
        private Size originalSizeInstallerIcon;
        private Size originalSizeTweakerIcon;

        private Point originalLocationTweakerIcon;
        private Point originalLocationInstallerIcon;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private bool isDragging = false;

        private readonly string tempPath = Path.Combine(Path.GetTempPath(), "AppInstallerTemp");

        public Toolbox()
        {
            InitializeComponent();
            FontManager.LoadCustomFonts();
            FontManager.ApplyCustomFonts(this);
            SetAppVersion();

            // DRAGGING
            top_bar.MouseDown += new MouseEventHandler(Top_bar_MouseDown);
            top_bar.MouseMove += new MouseEventHandler(Top_bar_MouseMove);
            top_bar.MouseUp += new MouseEventHandler(Top_bar_MouseUp);

            // TOOLTIPS
            toolTip1.SetToolTip(this.tip1, "Includes all Microsoft Visual C++ Redistributables (2005-2022).");
            toolTip1.SetToolTip(this.tip2, "Includes all Microsoft .NET Runtime versions (v3.0.3-v8.0.4).");
            toolTip1.SetToolTip(this.tip3, "A slimmed-down version of Office, including only Word, Excell and Powerpoint.");
            toolTip1.SetToolTip(this.tip4, "Prioritize Winget for app installation. Ensures cleaner setup and up-to-date versions.");
            toolTip1.SetToolTip(this.tip5, "Requires user's interaction.");
            toolTip1.SetToolTip(this.tip6, "VMWare Workstation Pro Full.");
            toolTip1.SetToolTip(this.tip7, "Requires user's interaction.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            originalSizeInstallerIcon = installer_icon.Size;
            originalLocationInstallerIcon = installer_icon.Location;
            originalSizeTweakerIcon = tweaker_icon.Size;
            originalLocationTweakerIcon = tweaker_icon.Location;
        }

        #region TOP BAR WINDOW DRAGGING ////////////////////////////////////////////////////////////////////////////////

        private void Top_bar_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Top_bar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void Top_bar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        #endregion TOP BAR WINDOW DRAGGING ////////////////////////////////////////////////////////////////////////////////

        #region EXIT & MINIMIZE BUTTONS ////////////////////////////////////////////////////////////////////////////////


        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Minimizebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion EXIT & MINIMIZE BUTTONS ////////////////////////////////////////////////////////////////////////////////

        #region SIDE MENU & Donate ////////////////////////////////////////////////////////////////////////////////

        private void Installer_icon_Click(object sender, EventArgs e)
        {
            tweaker_back.Visible = false;
            tweaker_icon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            installer_back.Visible = true;
            installer_icon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            quick_installer.Visible = true;
        }

        private void Tweaker_icon_Click(object sender, EventArgs e)
        {
            installer_back.Visible = false;
            installer_icon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            tweaker_back.Visible = true;
            tweaker_icon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            quick_installer.Visible = false;
        }

        private void Naetech_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.naetech.ro");
        }

        private void Donate_icon_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.revolut.me/nmd113");
        }

        private void SetAppVersion()
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            app_version.Text = $"v{version}";
        }

        private void Installer_icon_MouseEnter(object sender, EventArgs e)
        {
            StartScaling(installer_icon, originalSizeInstallerIcon, originalLocationInstallerIcon, 1.05);
        }

        private void Installer_icon_MouseLeave(object sender, EventArgs e)
        {
            StartScaling(installer_icon, originalSizeInstallerIcon, originalLocationInstallerIcon, 1.0);
        }

        private void Tweaker_icon_MouseEnter(object sender, EventArgs e)
        {
            StartScaling(tweaker_icon, originalSizeTweakerIcon, originalLocationTweakerIcon, 1.05);
        }

        private void Tweaker_icon_MouseLeave(object sender, EventArgs e)
        {
            StartScaling(tweaker_icon, originalSizeTweakerIcon, originalLocationTweakerIcon, 1.0);
        }

        private void StartScaling(PictureBox pictureBox, Size originalSize, Point originalLocation, double targetScale)
        {
            int originalWidth = originalSize.Width;
            int originalHeight = originalSize.Height;
            int targetWidth = (int)(originalWidth * targetScale);
            int targetHeight = (int)(originalHeight * targetScale);
            int stepCount = 5;
            int delay = 5;

            Timer timer = new Timer
            {
                Interval = delay
            };
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

        #endregion SIDE MENU & Donate ////////////////////////////////////////////////////////////////////////////////

        #region Quick Installer ////////////////////////////////////////////////////////////////////////////////

        private async void Installbtn_Click(object sender, EventArgs e)
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

                if (winGetCbx.Checked)
                {
                    await EnsureWingetInstalledAsync();
                }

                if (cb_7zip.Checked) tasks.Add(() => InstallAppSmart("7zip.7zip", "7-Zip", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/7zip-x64.exe", "/S", results));
                if (cb_qbit.Checked) tasks.Add(() => InstallAppSmart("qBittorrent.qBittorrent", "qBittorrent", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/qbittorrent_x64_setup.exe", "/S", results));
                if (cb_bcuninstaller.Checked) tasks.Add(() => InstallAppSmart("Klocman.BulkCrapUninstaller", "Bulk Crap Uninstaller", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/BCUninstaller-setup.exe", "/VERYSILENT /NORESTART", results));
                if (cb_anydesk.Checked) tasks.Add(() => InstallAppSmart("AnyDesk.AnyDesk", "AnyDesk", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/AnyDesk.exe", "--install \"C:\\Program Files (x86)\\AnyDesk\" --start-with-win --create-shortcuts --create-desktop-icon --silent", results));
                if (cb_wincdemu.Checked) tasks.Add(() => DownloadAndInstallAsync("WinCDEmu", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/WinCDEmu.exe", "/UNATTENDED", results));
                if (cb_notepadpp.Checked) tasks.Add(() => InstallAppSmart("Notepad++.Notepad++", "Notepad++", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/npp.exe", "/S", results));
                if (cb_vlc.Checked) tasks.Add(() => InstallAppSmart("VideoLAN.VLC", "VLC Media Player", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/vlc-win64.exe", "/L=1033 /S", results));
                if (cb_klite.Checked) tasks.Add(() => InstallAppSmart("CodecGuide.K-LiteCodecPack.Standard", "K-Lite Codec Pack Standard", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/K-Lite_Codec_Pack_Standard.exe", "/verysilent", results));
                if (cb_handbrake.Checked) tasks.Add(() => InstallAppSmart("HandBrake.HandBrake", "HandBrake", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/HandBrake.exe", "/S", results));
                if (cb_stremio.Checked) tasks.Add(() => InstallAppSmart("Stremio.Stremio", "Stremio", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/Stremio-setup.exe", "", results));
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
                if (cb_vmware.Checked) tasks.Add(() => DownloadAndInstallAsync("VMware Workstation Pro", "https://www.naetech.ro/wp-content/uploads/2024/toolbox/vmware-workstation-full.exe", "/s /v/qn EULAS_AGREED=1 AUTOSOFTWAREUPDATE=0 DATACOLLECTION=0 ADDLOCAL=ALL REBOOT=ReallySuppress", results));

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
                string wingetPath = "winget";
                string temp = Path.Combine(Path.GetTempPath(), "winget_fix");
                string scriptPath = Path.Combine(temp, "repair_winget.ps1");

                void UpdateLabel(string text)
                {
                    if (loadinglabel.InvokeRequired)
                        loadinglabel.Invoke(new Action(() => loadinglabel.Text = text));
                    else
                        loadinglabel.Text = text;
                }

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
                    if (MessageBox.Show("Winget is not installed on this system. Do you want to install it now?", "Winget Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        winGetCbx.Invoke(new Action(() => winGetCbx.Checked = false));
                        UpdateLabel("Winget installation skipped.");
                        return;
                    }
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

                    UpdateLabel("Verifying Winget installation...");

                    System.Threading.Thread.Sleep(2000);

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
                    UpdateLabel("PowerShell repair or final verification failed.");
                }
                finally
                {
                    try
                    {
                        if (Directory.Exists(temp))
                            Directory.Delete(temp, true);
                    }
                    catch { /*ignore*/ }
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

        #endregion  Quick Installer ////////////////////////////////////////////////////////////////////////////////

        #region Windows Tweaker ////////////////////////////////////////////////////////////////////////////////

        private async void Button1_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX.Resources.old_context_menu.reg",
                "Old context menu enabled! Restarting Explorer to apply changes...",
                "Failed to enable old context menu.",
                requiresRestart: true);

        }

        private async void Button2_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX.Resources.disable_ads.reg",
                "Windows Ads were disabled successfully! A windows restart may be required.",
                "Failed to disable Windows Ads.");

        }

        private async void Button3_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX.Resources.disable_web_search.reg",
                "Start Menu web search disabled successfully! A windows restart may be required.",
                "Failed to disable Start Menu web search.");

        }

        private async void Button4_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX.Resources.disable_auto_updates.reg",
                "Automatic Windows Updates disabled successfully! A restart may be required.",
                "Failed to disable Automatic Windows Updates.");

        }

        private async void Button5_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX.Resources.optimized_visual_effects.reg",
                "Optimized visual effects applied successfully! Logging out to apply changes...",
                "Failed to apply optimized visual effects.",
                requiresLogout: true);

        }

        private async void Button6_Click(object sender, EventArgs e)
        {

            await PerformCommandAsync("powercfg", "-h off", "Hibernation has been disabled successfully.", "Failed to disable Hibernation.");

        }

        private async void Button7_Click(object sender, EventArgs e)
        {

            await PerformCommandAsync("powercfg", "-duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61",
                "Ultimate Performance Plan added successfully. Enable it in Power settings.",
                "Failed to add Ultimate Performance Plan.");

        }

        private async void Button8_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX.Resources.legacy_photo_viewer.reg",
                "Legacy Photo Viewer enabled successfully.",
                "Failed to enable Legacy Photo Viewer.");

        }

        private async void Button9_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX.Resources.disable_gamebar.reg",
                "Game Bar and GameDVR disabled successfully! A Windows restart may be required.",
                "Failed to disable Game Bar and GameDVR.");

        }


        private async void Button10_Click(object sender, EventArgs e)
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


        private async void Button11_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX.Resources.run_with_priority.reg",
                "Run with priority context menu added successfully.",
                "Failed to add Run with priority context menu.");

        }

        private async void Button12_Click(object sender, EventArgs e)
        {

            await PerformRegistryImport("ToolBOX.Resources.disable-drivers-auto-update.reg",
                "Automatic updates for Windows drivers has been disabled successfully.",
                "Failed to disable Automatic updates for Windows drivers.");

        }


        private async void Button13_Click(object sender, EventArgs e)
        {

            await ExecuteBatchFile("ToolBOX.Resources.uninstall-onedrive.bat",
                "OneDrive uninstalled successfully. A windows restart may be required.",
                "Failed to uninstall OneDrive.");

        }

        private async void Button14_Click(object sender, EventArgs e)
        {
            await ExecuteBatchFile("ToolBOX.Resources.uninstall-copilot.bat",
                "Copilot uninstalled successfully. Restarting Explorer to apply changes...",
                "Failed to uninstall Copilot.",
                requiresRestart: true);
        }

        private async void Button15_Click(object sender, EventArgs e)
        {
            await ExecuteBatchFile("ToolBOX.Resources.disable-weather.bat",
                "Weather Widget disabled successfully. Restarting Explorer to apply changes...",
                "Failed to disable Weather Widget.",
                requiresRestart: true);
        }

        private async void Button16_Click(object sender, EventArgs e)
        {
            ServiceConfig serviceConfig = new ServiceConfig();

            try
            {
                SetButtonState(this, false);
                SetWaitCursor(true);

                await serviceConfig.ApplyServiceOptimizationsAsync();
                MessageBox.Show("Service optimizations applied. Please reboot for full effect.", "Optimization Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during service optimization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetButtonState(this, true);
                SetWaitCursor(false);
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

        #endregion Windows Tweaker ////////////////////////////////////////////////////////////////////////////////
    }
}
