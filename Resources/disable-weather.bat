@echo off

echo Disabling Weather Widget...

:: Disable Widgets via Registry
reg add "HKLM\SOFTWARE\Policies\Microsoft\Dsh" /v AllowNewsAndInterests /t REG_DWORD /d 0 /f
reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\Explorer" /v HideWidgets /t REG_DWORD /d 1 /f

:: Stop and disable Widgets-related services
sc stop "WebExperienceHost" >nul 2>&1
sc config "WebExperienceHost" start= disabled >nul 2>&1

echo Weather Widget has been successfully disabled.
exit
