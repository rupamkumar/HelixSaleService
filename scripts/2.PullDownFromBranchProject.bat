@Echo off


call Common.bat

%GPATH%git.exe checkout %TOBRANCH%
%GPATH%git.exe pull origin : %TOBRANCH%

 IF NOT %ERRORLEVEL%== 0 GOTO :ERROREXIT

 GOTO EXIT 
 
:ERROREXIT
ECHO.
ECHO.
	ECHO --------------------------------------------------------------
	ECHO -------THERE WAS AN ISSUE, FETCH IS NOT COMPLETE------------
	ECHO --------------------------------------------------------------
ECHO.
ECHO.	

:EXIT
pause