@echo off
setlocal enabledelayedexpansion

echo ========================================
echo Admin.Api IIS Removal Script
echo ========================================

:: Check if running as Administrator
net session >nul 2>&1
if %errorLevel% neq 0 (
    echo ERROR: This script must be run as Administrator
    echo Please right-click and select "Run as Administrator"
    pause
    exit /b 1
)

:: Set variables
set APP_POOL_NAME=AdminApiPool
set SITE_NAME=AdminApiSite
set PORT=80

echo.
echo ========================================
echo Step 1: Stopping IIS Site
echo ========================================
echo Stopping site: %SITE_NAME%
appcmd stop site /site.name:"%SITE_NAME%" >nul 2>&1
if %errorLevel% equ 0 (
    echo Site stopped successfully
) else (
    echo Site was not running or does not exist
)

echo.
echo ========================================
echo Step 2: Removing IIS Site
echo ========================================
echo Removing site: %SITE_NAME%
appcmd delete site /site.name:"%SITE_NAME%" >nul 2>&1
if %errorLevel% equ 0 (
    echo Site removed successfully
) else (
    echo Site does not exist
)

echo.
echo ========================================
echo Step 3: Removing Application Pool
echo ========================================
echo Removing application pool: %APP_POOL_NAME%
appcmd delete apppool /apppool.name:"%APP_POOL_NAME%" >nul 2>&1
if %errorLevel% equ 0 (
    echo Application pool removed successfully
) else (
    echo Application pool does not exist
)

echo.
echo ========================================
echo Step 4: Removing Firewall Rules
echo ========================================
echo Removing firewall rule for port %PORT%...
netsh advfirewall firewall delete rule name="AdminApi HTTP" >nul 2>&1

echo Removing firewall rule for gRPC port 82...
netsh advfirewall firewall delete rule name="AdminApi gRPC" >nul 2>&1

echo.
echo ========================================
echo Step 5: Cleaning Publish Folder
echo ========================================
set PUBLISH_PATH=%~dp0publish
if exist "%PUBLISH_PATH%" (
    echo Removing publish folder...
    rmdir /s /q "%PUBLISH_PATH%"
    echo Publish folder removed
) else (
    echo Publish folder does not exist
)

echo.
echo ========================================
echo Removal Complete!
echo ========================================
echo.
echo All AdminApi components have been removed from IIS
echo.

pause 