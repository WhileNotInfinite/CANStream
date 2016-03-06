:: CANStream release script
::
:: Version 3
::
:: Date: 12 06 2015

echo off

echo Path setting
set PATH=%PATH%;C:\Program Files (x86)\Inno Setup 5;C:\Program Files\7-Zip;C:\Users\Marti\Documents\Vincent\Dev\Tools\ConfuserEx_bin;C:\Windows\Microsoft.NET\Framework64\v4.0.30319

:: dir ...\CANStream
cd..

:: Code building
echo Release configuration code building
Msbuild.exe CANStream.sln /p:Configuration=Release /p:Platform="Any CPU"

echo Demo configuration code building
Msbuild.exe CANStream.sln /p:Configuration=Demo /p:Platform="Any CPU"

:: Code confusing
:: dir ...\CANStream\Release\Confuser\Outputs
echo Confuser outputs directory cleaning

cd Release\Confuser\Outputs

RMDIR Release /S /Q
RMDIR Demo /S /Q

:: dir ...\CANStream\Release\Confuser\Projects
cd ..\Projects

echo Release build consfusing
Confuser.CLI CANStream_Release_Confusing.crproj

echo Demo build consfusing
Confuser.CLI CANStream_Demo_Confusing.crproj

echo Setup building
:: Compile inno setup scripts

:: dir ...\CANStream\Installer
cd ..\..\..\Installer

RMDIR bin\Release /S /Q
RMDIR bin\Demo /S /Q

iscc "CANStream_Setup.iss"
iscc /dWIN32 "CANStream_Setup.iss"
iscc /dDEMO "CANStream_Setup.iss"
iscc /dWIN32 /dDEMO "CANStream_Setup.iss"

echo Master creation
:: dir ...\CANStream\Release
cd ..\Release

:: Create Master folder
IF EXIST Output\Master RMDIR Output\Master /S /Q
MKDIR Output\Master

:: Create Bin folder
MKDIR Output\Master\Bin
MKDIR Output\Master\Bin\Release
MKDIR Output\Master\Bin\Demo

:: Copy all installers
copy ..\Installer\Bin\Release\CANStream_Setup_Win32.exe Output\Master\Bin\Release
copy ..\Installer\Bin\Release\CANStream_Setup_x64.exe Output\Master\Bin\Release
copy ..\Installer\Bin\Demo\CANStream_DEMO_Setup_Win32.exe Output\Master\Bin\Demo
copy ..\Installer\Bin\Demo\CANStream_DEMO_Setup_x64.exe Output\Master\Bin\Demo

:: Create source folder
MKDIR Output\Master\Sources
cd Output\Master\Sources

:: Copy all projects sources
copy ..\..\..\..\..\CANStream\CANStream.sln

MKDIR CANStream
cd CANStream
xcopy ..\..\..\..\..\CANStream /E /F

cd..
MKDIR Flee_Lib
cd Flee_Lib
xcopy ..\..\..\..\..\Flee_Lib /E /F

cd..
MKDIR Ressources
cd Ressources
xcopy ..\..\..\..\..\Ressources /E /F

cd..
MKDIR Documentation
cd Documentation
xcopy ..\..\..\..\..\Documentation /E /F

cd..
MKDIR Installer
cd Installer
xcopy ..\..\..\..\..\Installer /E /F
rmdir Bin

cd..
MKDIR "PCAN-Basic API"
cd PCAN-Basic API
xcopy ..\..\..\..\..\"PCAN-Basic API" /E /F

cd..
MKDIR Release
copy ..\..\..\..\Release\MakeRelease.bat Release

MKDIR Release\Confuser
xcopy ..\..\..\Confuser Release\Confuser /E /F

MKDIR Ctrl_GraphWindow
cd Ctrl_GraphWindow
xcopy ..\..\..\..\..\..\SD_Ctrl_GraphWindow\Ctrl_GraphWindow /E /F

::Create a 7-zip archive of the source directory and delete the source directory
cd ..\..
7z a Sources.zip Sources\
rmdir Sources /S /Q 

::Copy the release note into the Master folder
cd..
copy "..\..\CANStream\bin\Release\CANStream Release notes.txt" Master

echo Client creation

::Create the client folder
IF EXIST Output\Client RMDIR Output\Client /S /Q
MKDIR Client

:: Copy all installers
copy ..\..\Installer\Bin\Release\CANStream_Setup_Win32.exe Client
copy ..\..\Installer\Bin\Release\CANStream_Setup_x64.exe Client

::Copy the release note into the client folder
copy "..\..\CANStream\bin\Release\CANStream Release notes.txt" Client

::Copy the user documentation into the client folder
copy "..\..\Documentation\Build\CANStream User Guide.pdf" Client

echo Demo creation

::Create the demo folder
IF EXIST Output\Demo RMDIR Output\Demo /S /Q
MKDIR Demo

:: Copy all installers
copy ..\..\Installer\Bin\Demo\CANStream_DEMO_Setup_Win32.exe Demo
copy ..\..\Installer\Bin\Demo\CANStream_DEMO_Setup_x64.exe Demo

::Copy the release note into the client folder
copy "..\..\CANStream\bin\Release\CANStream Release notes.txt" Demo

::Copy the user documentation into the client folder
copy "..\..\Documentation\Build\CANStream User Guide.pdf" Demo

pause
