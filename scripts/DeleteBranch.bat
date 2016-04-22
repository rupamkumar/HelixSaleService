call Common.bat

rem ECHO 1. Local Branch
rem ECHO 2. Remote Branch
rem ECHO 3. Local and Remote
rem ECHO C. -- CANCEL --

rem CHOICE /C:123C /m:"Please choose Local or Remote or Both "

rem IF "%ERRORLEVEL%" == "1" (
rem	%GPATH%git.exe branch -D %TOBRANCH%
rem )

rem IF "%ERRORLEVEL%" == "2" (
rem	%GPATH%git.exe push origin --delete %TOBRANCH%
rem )

rem IF "%ERRORLEVEL%" == "3" (
	%GPATH%git.exe branch -D %TOBRANCH%
	%GPATH%git.exe push origin --delete %TOBRANCH%
rem )
 

 IF NOT %ERRORLEVEL%== 0 GOTO :ERROREXIT

 echo Branch %TOBRANCH% has been deleted.
 
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