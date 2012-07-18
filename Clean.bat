@echo off
echo Clean: Cleaning up...

call :KillAccessors

for /D %%i in (*) do (
  if not exist "%%i\DoNotClean.txt" (
    pushd "%%i"
    for /R /D %%i in (ProxyAssemblyCache.*) do rmdir /S /Q "%%i"
    for /R /D %%i in (bin.*) do rmdir /S /Q "%%i"
    for /R /D %%i in (obj.*) do rmdir /S /Q "%%i"
    del /Q "%%i\TestResult.xml" >nul 2>nul
    if exist "Bin" (
      pushd "Bin"
      for /D %%j in (*) do rmdir /S /Q "%%j"
      popd
    )
    if exist "Lib" (
      pushd "Lib"
      del /Q *.* >nul 2>nul
      popd
    )
    if exist "Logs" (
      pushd "Logs"
      del /Q *.log >nul 2>nul
      del /Q *.xml >nul 2>nul
      popd
    )
    if exist ".sass-cache" (
      rmdir /S /Q ".sass-cache" >nul 2>nul
    )
    popd
  )
)
if exist ".sass-cache" (
  rmdir /S /Q ".sass-cache" >nul 2>nul
)

echo Clean:   Done.
goto :End

:KillAccessors
rem taskkill /IM devenv.exe /T /F >nul 2>nul
taskkill /IM MSBuild.exe /T /F >nul 2>nul
taskkill /IM PostSharp.exe /T /F >nul 2>nul
taskkill /IM postsharp.srv.* /T /F >nul 2>nul
taskkill /IM Xtensive.Licensing.Manager.exe /T /F >nul 2>nul
goto :End

:End
