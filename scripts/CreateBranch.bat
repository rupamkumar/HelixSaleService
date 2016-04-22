call Common.bat

 %GPATH%git.exe branch %TOBRANCH%


 IF NOT %ERRORLEVEL%== 0 GOTO :ERROREXIT

 echo Branch %TOBRANCH% has been created Locally.
 
 SET /P ANSWER=Do you want to Push this branch to the Server (Y/N)?
rem echo You chose: %ANSWER%
if /i {%ANSWER%}=={y} (goto :PushBranch)
if /i {%ANSWER%}=={yes} (goto :PushBranch)
goto :EXIT

:PushBranch
%GPATH%git.exe push origin : %TOBRANCH% --tags
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