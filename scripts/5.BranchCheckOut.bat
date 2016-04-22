@Echo off


call Common.bat

rem %GPATH%git.exe tag -a  -m "Test Message"
 %GPATH%git.exe checkout  %TOBRANCH%

rem %GPATH%git.exe merge  ProjectA 

 IF NOT %ERRORLEVEL%== 0 GOTO :ERROREXIT

 GOTO EXIT 
 
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