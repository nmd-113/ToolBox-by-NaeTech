@echo off
REM Disable News and Interests on the taskbar
reg add "HKLM\SOFTWARE\Policies\Microsoft\Dsh" /v AllowNewsAndInterests /t REG_DWORD /d 0 /f

REM Hide Widgets from the taskbar
reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\Explorer" /v HideWidgets /t REG_DWORD /d 1 /f

REM Stop and reconfigure Web Experience Host service
sc stop "WebExperienceHost" >nul 2>&1
sc config "WebExperienceHost" start= manual >nul 2>&1

REM Exit the script
exit