@ECHO OFF

SET BUILD=Dev
SET GIT_TAG=DailyFigures
SET VER_FILE=Sapphire.DailyFigures\Client\exe\Sapphire.DailyFigures.Client.exe

REM Get Solution Folders
	SET BASEFOLDER=%~dp0..
	SET SOLFOLDER=%BASEFOLDER%\..\..\..\
	PUSHD .
	CD %SOLFOLDER%
	SET SOLFOLDER=%CD%\
	POPD
	SET DEPFOLDER=%SOLFOLDER%\Deployment\%BUILD%

CALL %SOLFOLDER%\Build\Checkin.bat