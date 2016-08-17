:: CANStream release script for open source version
::
:: Version 4
::
:: Date: July 3rd 2016

echo off

echo Path setting
set PATH=%PATH%;C:\Program Files (x86)\Inno Setup 5;C:\Program Files\7-Zip;C:\Windows\Microsoft.NET\Framework64\v4.0.30319

:: dir ...\CANStream
cd..

:: Code building
echo Release_OpenSource configuration code building
Msbuild.exe CANStream.sln /p:Configuration=Release /p:Platform="Any CPU"

echo Setup building
:: Compile inno setup scripts

:: dir ...\CANStream\Installer
cd Installer

RMDIR bin\Release /S /Q

iscc "CANStream_OpenSource_Setup.iss"
iscc /dWIN32 "CANStream_OpenSource_Setup.iss"

echo Master creation
:: dir ...\CANStream\Release
cd ..\Release

:: Create Master folder
IF EXIST Output\MasterOpenSouce RMDIR Output\MasterOpenSouce /S /Q
MKDIR Output\MasterOpenSouce

:: Create Bin folder
MKDIR Output\MasterOpenSouce\Bin

:: Copy all installers
copy ..\Installer\Bin\Release\CANStream_Setup_Win32.exe Output\MasterOpenSouce\Bin
copy ..\Installer\Bin\Release\CANStream_Setup_x64.exe Output\MasterOpenSouce\Bin


:: Create source folder
MKDIR Output\MasterOpenSouce\Sources
:: dir ...\CANStream\Release\Output\MasterOpenSouce\Sources
cd Output\MasterOpenSouce\Sources

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

MKDIR Ctrl_GraphWindow
cd Ctrl_GraphWindow
xcopy ..\..\..\..\..\..\Ctrl_GraphWindow\Ctrl_GraphWindow /E/F


::Create a 7-zip archive of the source directory and delete the source directory
cd ..\..
7z a Sources.zip Sources\
rmdir Sources /S /Q 

::Copy the release note into the Master folder
cd..
copy "..\..\CANStream\bin\Release\CANStream Release notes.txt" MasterOpenSouce

::Copy the user documentation into the MasterOpenSouce folder
copy "..\..\Documentation\Build\CANStream User Guide.pdf" MasterOpenSouce

pause
