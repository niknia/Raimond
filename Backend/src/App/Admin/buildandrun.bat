@echo off
REM Set environment variables for ASP.NET Core
set ASPNETCORE_ENVIRONMENT=Development
set DOTNET_RUNNING_IN_CONTAINER=false
set DOTNET_USE_POLLING_FILE_WATCHER=true
set ASPNETCORE_URLS=http://localhost:50010;https://localhost:50011

REM Set build configuration and output directory
set BUILD_CONFIGURATION=Release
set OUTPUT_DIR=build-output

REM Path to the main project file (Startup Project)
set PROJECT_PATH=Admin.Api\Adnc.Demo.Admin.Api.csproj

REM Check if .NET CLI is installed
dotnet --version >nul 2>&1
IF %ERRORLEVEL% NEQ 0 (
    echo .NET CLI is not installed. Please install .NET SDK.
    exit /b 1
)

REM Clean up previous output
IF EXIST %OUTPUT_DIR% (
    echo Cleaning up previous output directory...
    rmdir /s /q %OUTPUT_DIR%
)

REM Restore NuGet dependencies
echo Restoring NuGet dependencies...
dotnet restore %PROJECT_PATH%
IF %ERRORLEVEL% NEQ 0 (
    echo Failed to restore dependencies.
    exit /b 1
)

REM Build the project
echo Building the project...
dotnet build %PROJECT_PATH% -c %BUILD_CONFIGURATION% -o %OUTPUT_DIR%
IF %ERRORLEVEL% NEQ 0 (
    echo Build failed.
    exit /b 1
)

REM Publish the project
echo Publishing the project...
dotnet publish %PROJECT_PATH% -c %BUILD_CONFIGURATION% -o %OUTPUT_DIR%
IF %ERRORLEVEL% NEQ 0 (
    echo Publish failed.
    exit /b 1
)

REM Navigate to the publish directory
cd %OUTPUT_DIR%

REM Search and modify Kestrel settings in any 'setting.*.json' files
echo Searching for 'appsettings.*.json' files and updating Kestrel port...

REM Loop through all appsettings.*.json files
for /r %%F in (appsettings.*.json) do (
    echo Checking file %%F
    REM Update Kestrel settings if found
    powershell -Command "(Get-Content '%%F' -Raw) -replace '\"Url\": \"http://0.0.0.0:80\"', '\"Url\": \"http://0.0.0.0:50060\"' | Set-Content '%%F'"
    REM Check if Http2 exists and replace port
    powershell -Command "(Get-Content '%%F' -Raw) -replace '\"Url\": \"http://0.0.0.0:81\"', '\"Url\": \"http://0.0.0.0:50062\"' | Set-Content '%%F'"
)

REM Run the application with the updated settings
echo Running the application...
dotnet Adnc.Demo.Admin.Api.dll
IF %ERRORLEVEL% NEQ 0 (
    echo Failed to run the application.
    exit /b 1
)

pause