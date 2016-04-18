@ECHO OFF
IF %BUILD% == "" GOTO :ERROREXIT	
IF %GIT_TAG% == "" GOTO :ERROREXIT	
IF %VER_FILE% == "" GOTO :ERROREXIT	

SET HOME=%USERPROFILE%

REM Set Temp Files
	SET TMP_LOG=%TEMP%.\%GIT_TAG%.%BUILD%.Version.txt

REM Get Version 
	IF NOT EXIST %DEPFOLDER%\%VER_FILE% (
		ECHO Version File not found [ %DEPFOLDER%\%VER_FILE%]
		GOTO ERROREXIT
	)

	%SOLFOLDER%\Utilities\sigcheck.exe -n -q %DEPFOLDER%\%VER_FILE% > %TMP_LOG%
	SET /p VER= < %TMP_LOG%
	ECHO %VER%
	for /f "tokens=1,2,3,4 delims=." %%a in ("%VER%") do set va=%%a&set vb=%%b&set vc=%%c&set vd=%%d
	SET vap=000%va%
	SET vbp=000%vb%
	SET vcp=000%vc%
	SET vdp=000%vd%
	SET PadBuild=%vap:~-3%.%vbp:~-3%.%vcp:~-3%.%vdp:~-3%
	ECHO %PadBuild%
	ECHO V%vc%.%vd% (%BUILD%)
	
REM Add SVN Tag
	
	FOR /F "usebackq tokens=1,2,3,4 delims=/ " %%i IN (`date /t`) DO (
	set yyyymmdd=%%l-%%j-%%k
	)
	%SOLFOLDER%\Utilities\git\git.exe tag -a %GIT_TAG%/%BUILD%/%PadBuild% -m "%GIT_TAG%.%BUILD% %VER% - %yyyymmdd%"
	IF NOT %ERRORLEVEL%== 0 GOTO :ERROREXIT	
	%SOLFOLDER%\Utilities\git\git.exe push origin %GIT_TAG%/%BUILD%/%PadBuild%
	IF NOT %ERRORLEVEL%== 0 GOTO :ERROREXIT	
	GOTO EXIT
:ERROREXIT
ECHO.
ECHO.
	ECHO --------------------------------------------------------------
	ECHO -------THERE WAS AN ISSUE, CHECKIN IS NOT COMPLETE------------
	ECHO --------------------------------------------------------------
ECHO.
ECHO.	

:EXIT	
PAUSE