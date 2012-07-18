@echo off
call :run 20 "20 items"
call :run 100 "100 items"
call :run 10000 "10K items"
call :run 1000000 "1M items"
call :run 50000000 "50M items (200+ MB RAM, so working set doesn't fit into L2)"
goto :eof

:run
echo Output for %~2:
echo ^<pre^>
call Run.bat %1
echo ^</pre^>
echo.
goto :eof
