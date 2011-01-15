@echo off

pushd %~dp0

call rake -f "publish.rb"

REM echo %~dp0..\bin\publish\release
popd

cd ..\bin\publish\release

echo Please run "AgileWizard.Website.deploy.cmd /Y"


