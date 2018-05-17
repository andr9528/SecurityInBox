@echo off
cd /d "%~dp0"

    echo Administrative permissions required. Detecting permissions...

    net session >nul 2>&1
    if %errorLevel% == 0 (
        echo Success: Administrative permissions confirmed.
		goto process
    ) else (
        echo Failure: Current permissions inadequate.
		pause
		exit
    )

    pause >nul 
	
:process
set /p name=Name to save log as (e.g. your own name):
python sniffer2.py > logfile_%name%_%date%_%random%

pause >nul