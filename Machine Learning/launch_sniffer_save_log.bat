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

echo.
echo Notice: Log files ARE NOT put in github.
echo Please upload logfiles to ftp
echo Exit program using CTRL + C
echo.
echo Executing Python Script!
python sniffer2.py > logfile_%name%_%date%_%random%
echo Python script terminated!

echo.
echo Press any key to exit terminal
pause >nul