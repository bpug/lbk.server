@echo off

REM Delete all temp build directories for a clean client checkin
set SRC1=%~dp0\build
set SRC2=%~dp0\bin
REM del /s /q %SRC%\*.*
REM rd /s /q %SRC%

for /d %%i in (%SRC1%) do @if exist %%i rd /s /q %%i
for /d %%i in (%SRC2%) do @if exist %%i rd /s /q %%i

rd /s /q %~dp0\obj