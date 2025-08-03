@echo off
REM Set environment variables
set BUILD_CONFIGURATION=Release
set OUTPUT_DIR=build-output

REM Path to the main project file (Startup Project)
set PROJECT_PATH=Services\BaseInfo\Dkd.App.BaseInfo.Api\Dkd.App.BaseInfo.Api.csproj

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

echo Build and publish succeeded. Output is saved in the %OUTPUT_DIR% folder.
pause
