import sys

from utils import prGreen,prRed,prYellow

prYellow("ℹ️  This script will check if all imports are installed.")

def checkPython():
    try:
        if(sys.version):
            prGreen("✅ Python is succesfully installed!")
        else:
            prRed("❌ Python is not installed please install Python first: https://www.python.org/downloads/")
    except Exception as e:
        prRed(e)
def checkPip():
    try:
        import pip
        prGreen("✅ Pip is succesfully installed!")
    except ImportError:
        prRed("❌ Pip not present. Install pip: https://pip.pypa.io/en/stable/installation/")
def checkSelenium():
    try:
        import selenium
        prGreen("✅ Selenium is succesfully installed!")
    except ImportError:
        prRed("❌ Selenium not present. Install Selenium: https://pypi.org/project/selenium/")
def checkDotenv():
    try:
        import dotenv
        prGreen("✅ Dotenv is succesfully installed!")
    except ImportError:
        prRed("❌ Dotenv not present. Install Dotenv: https://pypi.org/project/python-dotenv/")

checkPython()
checkPip()
checkSelenium()
checkDotenv()



prGreen("Test Execution Successfully Completed!")