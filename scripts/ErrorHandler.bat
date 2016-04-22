@Echo off
SET ProjectFolder=HelixSaleService
SET /p TOBRANCH="Please Enter branch Name: "
SET BASEFOLDER=%~dp0
set PATH=%PATH%;C:\Program Files\Git\bin\
set GPATH = C:\Program Files\Git\bin\


rem echo %BASEFOLDER%
rem SET SOLFOLDER=%BASEFOLDER%\..\..\..\

SET SOLFOLDER=%BASEFOLDER%
rem echo %SOLFOLDER%
PUSHD .
cd %SOLFOLDER%

SET SOLFOLDER=%CD%\%ProjectFolder%\
	POPD
rem  echo %SOLFOLDER%
cd %SOLFOLDER%
