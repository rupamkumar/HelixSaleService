@Echo off



SET BASEFOLDER=%~dp0..
set PATH=%PATH%;C:\Program Files\Git\bin\
set GPATH = C:\Program Files\Git\bin\




rem echo %BASEFOLDER%
rem SET SOLFOLDER=%BASEFOLDER%\..\..\..\

SET SOLFOLDER=%BASEFOLDER%
echo %SOLFOLDER%
PUSHD .
cd %SOLFOLDER%

SET SOLFOLDER=%CD%\
	POPD
rem echo %SOLFOLDER%
rem pull does not work of version 1.8.1.0
rem %SOLFOLDER%\Utilities\git\git.exe fetch 
rem echo %GPATH%

rem %GPATH%git.exe tag -a  -m "Test Message"
 %GPATH%git.exe checkout  ProjectB

rem %GPATH%git.exe merge  ProjectA 

 IF NOT %ERRORLEVEL%== 0 GOTO :ERROREXIT

 GOTO EXIT 
rem cd C://Projects/Sapphire/
rem git pull
:ERROREXIT
ECHO.
ECHO.
	ECHO --------------------------------------------------------------
	ECHO -------THERE WAS AN ISSUE, Reset merge------------
	ECHO --------------------------------------------------------------
ECHO.
ECHO.


:EXIT
pause