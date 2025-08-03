@echo off
setlocal enabledelayedexpansion

echo ========================================
echo Admin.Api IIS Deployment Script
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
set PROJECT_PATH=%~dp0
set PUBLISH_PATH=%PROJECT_PATH%publish
set APP_NAME=AdminApi
set APP_POOL_NAME=AdminApiPool
set SITE_NAME=AdminApiSite
set PORT=80

echo.
echo Project Path: %PROJECT_PATH%
echo Publish Path: %PUBLISH_PATH%
echo Application Name: %APP_NAME%
echo Port: %PORT%

echo.
echo ========================================
echo Step 1: Cleaning previous publish
echo ========================================
if exist "%PUBLISH_PATH%" (
    echo Removing previous publish folder...
    rmdir /s /q "%PUBLISH_PATH%"
)

echo.
echo ========================================
echo Step 2: Publishing project
echo ========================================
echo Running: dotnet publish -c Release -o ./publish
cd /d "%PROJECT_PATH%"
dotnet publish -c Release -o ./publish

if %errorLevel% neq 0 (
    echo ERROR: dotnet publish failed
    pause
    exit /b 1
)

echo.
echo ========================================
echo Step 3: Creating appsettings.Production.json for port 80
echo ========================================
echo Creating production settings for port 80...

(
echo {
echo   "ConfigurationType": "Consul",
echo   "Consul": {
echo     "ConsulUrl": "http://10.2.8.5:8500",
echo     "ConsulKeyPath": "adnc/production/shared/appsettings,adnc/production/$SHORTNAME/appsettings"
echo   },
echo   "Kestrel": {
echo     "Endpoints": {
echo       "Default": {
echo         "Url": "http://0.0.0.0:%PORT%"
echo       },
echo       "Grpc": {
echo         "Url": "http://0.0.0.0:82",
echo         "Protocols": "Http2"
echo       }
echo     }
echo   }
echo }
) > "%PUBLISH_PATH%\appsettings.Production.json"

echo.
echo ========================================
echo Step 4: Creating web.config for IIS
echo ========================================
echo Creating web.config file...

(
echo ^<?xml version="1.0" encoding="utf-8"?^>
echo ^<configuration^>
echo   ^<location path="." inheritInChildApplications="false"^>
echo     ^<system.webServer^>
echo       ^<handlers^>
echo         ^<add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" /^>
echo       ^</handlers^>
echo       ^<aspNetCore processPath="dotnet" arguments=".\Dkd.App.Admin.Api.dll" stdoutLogEnabled="true" stdoutLogFile=".\logs\stdout" hostingModel="inprocess"^>
echo         ^<environmentVariables^>
echo           ^<environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Production" /^>
echo           ^<environmentVariable name="ASPNETCORE_URLS" value="http://0.0.0.0:%PORT%" /^>
echo         ^</environmentVariables^>
echo       ^</aspNetCore^>
echo     ^</system.webServer^>
echo   ^</location^>
echo ^</configuration^>
) > "%PUBLISH_PATH%\web.config"

echo.
echo ========================================
echo Step 5: Creating logs directory
echo ========================================
if not exist "%PUBLISH_PATH%\logs" (
    mkdir "%PUBLISH_PATH%\logs"
    echo Created logs directory
)

echo.
echo ========================================
echo Step 6: IIS Configuration
echo ========================================

:: Check if Application Pool exists, if not create it
echo Checking Application Pool: %APP_POOL_NAME%
appcmd list apppool /name:"%APP_POOL_NAME%" >nul 2>&1
if %errorLevel% neq 0 (
    echo Creating Application Pool: %APP_POOL_NAME%
    appcmd add apppool /name:"%APP_POOL_NAME%" /managedRuntimeVersion:"" /managedPipelineMode:Integrated
    appcmd set apppool /apppool.name:"%APP_POOL_NAME%" /processModel.identityType:ApplicationPoolIdentity
    echo Application Pool created successfully
) else (
    echo Application Pool already exists
)

:: Check if Site exists, if not create it
echo Checking Site: %SITE_NAME%
appcmd list site /name:"%SITE_NAME%" >nul 2>&1
if %errorLevel% neq 0 (
    echo Creating Site: %SITE_NAME%
    appcmd add site /name:"%SITE_NAME%" /physicalPath:"%PUBLISH_PATH%" /bindings:http://*:%PORT%
    appcmd set site /site.name:"%SITE_NAME%" /applicationDefaults.applicationPool:"%APP_POOL_NAME%"
    echo Site created successfully
) else (
    echo Site already exists, updating bindings...
    appcmd set site /site.name:"%SITE_NAME%" /bindings:http://*:%PORT%
    appcmd set site /site.name:"%SITE_NAME%" /applicationDefaults.applicationPool:"%APP_POOL_NAME%"
)

:: Start the site
echo Starting site...
appcmd start site /site.name:"%SITE_NAME%"

echo.
echo ========================================
echo Step 7: Firewall Configuration
echo ========================================
echo Adding firewall rule for port %PORT%...
netsh advfirewall firewall add rule name="AdminApi HTTP" dir=in action=allow protocol=TCP localport=%PORT%

echo Adding firewall rule for gRPC port 82...
netsh advfirewall firewall add rule name="AdminApi gRPC" dir=in action=allow protocol=TCP localport=82

echo.
echo ========================================
echo Step 8: Testing Configuration
echo ========================================
echo Waiting 5 seconds for application to start...
timeout /t 5 /nobreak >nul

echo Testing HTTP endpoint...
curl -s -o nul -w "HTTP Status: %%{http_code}\n" http://localhost:%PORT%/health

echo.
echo ========================================
echo Deployment Complete!
echo ========================================
echo.
echo Summary:
echo - Project published to: %PUBLISH_PATH%
echo - IIS Site: %SITE_NAME%
echo - Application Pool: %APP_POOL_NAME%
echo - HTTP Port: %PORT%
echo - gRPC Port: 82
echo - Health Check: http://localhost:%PORT%/health
echo.
echo To access the application:
echo - HTTP API: http://localhost:%PORT%
echo - gRPC: http://localhost:82
echo.
echo To stop the application:
echo - appcmd stop site /site.name:"%SITE_NAME%"
echo.
echo To remove the application:
echo - appcmd delete site /site.name:"%SITE_NAME%"
echo - appcmd delete apppool /apppool.name:"%APP_POOL_NAME%"
echo.

pause 