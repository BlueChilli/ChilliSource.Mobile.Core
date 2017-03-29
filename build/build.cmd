@echo off

sh -c "../build/license-header-cmd.sh %1"
del ..\build\artifacts\*.* /S /Q
del ..\src\*.tmp.* /S /Q
mkdir tools
mkdir tools\nuget
powershell -Command "wget https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile ./tools/nuget/nuget.exe"
tools\nuget\nuget.exe update -self
tools\nuget\nuget.exe install Cake -OutputDirectory tools -ExcludeVersion
tools\Cake\Cake.exe ..\build\build.cake
exit /b %errorlevel%