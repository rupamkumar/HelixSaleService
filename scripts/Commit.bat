@Echo off


rem SET ProjectFolder=HelixSaleService

call Common.bat

 rem pull does not work of version 1.8.1.0
rem %SOLFOLDER%\Utilities\git\git.exe fetch 
rem echo %GPATH%

rem %GPATH%git.exe tag -a  -m "Test Message"
 %GPATH%git.exe checkout  %TOBRANCH% 

 %GPATH%git.exe add .
 
 %GPATH%git.exe commit  -a -m "this is test"

 IF NOT %ERRORLEVEL%== 0 GOTO :ERROREXIT

 GOTO EXIT 
rem cd C://Projects/Sapphire/
rem git pull
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