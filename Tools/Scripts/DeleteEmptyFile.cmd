@echo off
if exist %1 for %%i in (%1) do if %%~zi==0 del "%%i"
