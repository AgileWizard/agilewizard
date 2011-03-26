@echo off

pushd %~dp0

call rake publish

popd

cd ..\bin\publish\release

echo Please run "AgileWizard.Website.deploy.cmd /Y"


