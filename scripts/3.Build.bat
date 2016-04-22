@ECHO OFF
SET BUILD=Dev
SET APP_LOG=DailyFigures
SET PROJECTPREFIXVALUE=Sapphire.DailyFigures

SET BASEFOLDER=%~dp0..
SET SOLFOLDER=%BASEFOLDER%\..\..\..\
PUSHD .
CD %SOLFOLDER%
SET SOLFOLDER=%CD%\
POPD
SET LOGFILE=%SOLFOLDER%\Deployment\%BUILD%\%APP_LOG%.log
SET REFFOLDER=%SOLFOLDER%\References\%BUILD%\
SET OUTFOLDER=%SOLFOLDER%\BuildTemp\%BUILD%\
SET DEPFOLDER=%SOLFOLDER%\Deployment\%BUILD%\

SET /P ANSWER=Do you want to Build Base (Y/N)?
echo You chose: %ANSWER%
if /i {%ANSWER%}=={y} (goto :BuildBase)
if /i {%ANSWER%}=={yes} (goto :BuildBase)
goto :BuildBaseNo
:BuildBase
CALL %SOLFOLDER%\Base\BaseSolution\Build\%BUILD%\%BUILD%.Build.bat
IF NOT %ERRORLEVEL% == 0 GOTO ERROREXIT

:BuildBaseNo
mkdir %SOLFOLDER%Deployment\%BUILD%
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\msBuild %BASEFOLDER%\MSBuild.xml /p:RefPath=%REFFOLDER% /p:BaseFolder=%BASEFOLDER% /p:SolutionFolder=%SOLFOLDER% /p:ProjectPrefix=%PROJECTPREFIXVALUE% /p:OutputFolder=%OUTFOLDER%\ /p:DeploymentFolder=%DEPFOLDER%\ /p:Configuration=%BUILD% /l:FileLogger,Microsoft.Build.Engine;LogFile=%LOGFILE%
:ERROREXIT
Pause
