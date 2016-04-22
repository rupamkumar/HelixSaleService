@Echo off


SET /p FROMBRANCH="Please Enter branch Name where you want to merge from: "
call Common.bat

 
 %GPATH%git.exe checkout  %TOBRANCH% 
 
 %GPATH%git.exe merge  %FROMBRANCH% 

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