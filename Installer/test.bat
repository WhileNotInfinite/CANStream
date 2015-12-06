echo off

echo Path setting
set PATH=%PATH%;C:\Program Files (x86)\Inno Setup 5;

iscc "CANStream_Setup.iss"
iscc /dWIN32 "CANStream_Setup.iss"
iscc /dDEMO "CANStream_Setup.iss"
iscc /dWIN32 /dDEMO "CANStream_Setup.iss"