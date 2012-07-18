@echo off
pushd "%~dp0"
  call Build\Environment.bat
  call :start %*
popd
goto :end

:start
echo Building...
"%MSBuildPath%\MSBuild.exe" /nologo /v:m /p:Configuration=Release %* LinqVSRawCode.sln
echo.
echo Done.
goto :end

:end