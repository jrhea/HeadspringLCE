REM
REM This script must be run from Visual Studio Cmd Prompt
REM
msbuild EmployeeDirectory.sln
cd EmployeeDirectory.Tests/bin/Debug
VSTest.Console.exe EmployeeDirectory.Tests.dll
ECHO Press any key to exit...
PAUSE