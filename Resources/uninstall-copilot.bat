@echo off

:: Uninstall Copilot packages for all users
powershell -Command "Get-AppxPackage -AllUsers | Where-Object { $_.Name -like '*Copilot*' } | ForEach-Object { Remove-AppxPackage -Package $_.PackageFullName -AllUsers -ErrorAction SilentlyContinue }"
powershell -Command "Get-AppxProvisionedPackage -Online | Where-Object { $_.DisplayName -eq 'Microsoft.Copilot' } | ForEach-Object { Remove-AppxProvisionedPackage -Online -PackageName $_.PackageName -ErrorAction SilentlyContinue }"

:: Disable Windows Copilot and related features
reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsCopilot" /v TurnOffWindowsCopilot /t REG_DWORD /d 1 /f
reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\CloudContent" /v DisableWindowsSpotlightFeatures /t REG_DWORD /d 1 /f
reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Search" /v BingSearchEnabled /t REG_DWORD /d 0 /f
reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Search" /v CortanaConsent /t REG_DWORD /d 0 /f
reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer" /v HideSCAMeetNow /t REG_DWORD /d 1 /f

:: Remove Copilot taskbar shortcut
reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\Explorer" /v HideTaskbarCopilot /t REG_DWORD /d 1 /f

exit
