@echo OFF
msiexec  /qb-! /x {3175553C-88D5-453B-93CB-4012A827533A} /quiet /l*v %~dp0Log.Uninstall.txt NOVSSHUTDOWNCHECK=1
echo Logged uninstall result to %~dp0Log.Uninstall.txt 