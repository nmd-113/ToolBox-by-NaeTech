@echo off
cls

setlocal

set x86="%SYSTEMROOT%\System32\OneDriveSetup.exe"
set x64="%SYSTEMROOT%\SysWOW64\OneDriveSetup.exe"

echo [INFO] Closing OneDrive process...
taskkill /f /im OneDrive.exe > NUL 2>&1
timeout /t 5 /nobreak > NUL

echo [INFO] Uninstalling OneDrive...
if exist %x64% (
    %x64% /uninstall
) else (
    %x86% /uninstall
)
timeout /t 5 /nobreak > NUL

echo [INFO] Removing OneDrive leftovers...
rd "%USERPROFILE%\OneDrive" /Q /S > NUL 2>&1
rd "C:\OneDriveTemp" /Q /S > NUL 2>&1
rd "%LOCALAPPDATA%\Microsoft\OneDrive" /Q /S > NUL 2>&1
rd "%LOCALAPPDATA%\OneDrive" /Q /S > NUL 2>&1
rd "%PROGRAMDATA%\Microsoft OneDrive" /Q /S > NUL 2>&1

echo [INFO] Removing OneDrive from the Explorer Side Panel...
reg delete "HKEY_CLASSES_ROOT\CLSID\{018D5C66-4533-4307-9B53-224DE2ED1FE6}" /f > NUL 2>&1
reg delete "HKEY_CLASSES_ROOT\Wow6432Node\CLSID\{018D5C66-4533-4307-9B53-224DE2ED1FE6}" /f > NUL 2>&1

echo [INFO] OneDrive has been completely uninstalled and cleaned up.
endlocal