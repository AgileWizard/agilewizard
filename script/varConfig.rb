# the variable used in the ruby files
ROOT = File.expand_path(File.join(File.dirname(__FILE__), ".."))
puts "Project root directory is " + ROOT

# Webdevexe does not accept "/" as a directory path, use "\\" instead
WEBSITE_LOCATION = File.expand_path(File.join(ROOT, "src/AgileWizard.Website")).gsub(/\//, "\\")
WEBSITE_PROJ = File.join(WEBSITE_LOCATION,"AgileWizard.Website.csproj")
WEB_PORT = "1984"

SOLUTION = File.join(ROOT,"src/AgileWizard.sln")
XUNIT_PATH = File.join(ROOT, "lib/xunitnet/xunit.console.clr4.exe")
PROJECT_NAME = "AgileWizard"
OUTPUT_DIRECTORY = File.join(ROOT, "bin")
COMILE_MODE = "Release"
OUTPUT_DLL_DIR = File.join(OUTPUT_DIRECTORY, COMILE_MODE)
WEB_DEV_NAME = "WebDev.WebServer40.EXE"
WEB_DEV_FULL_NAME = "C:/Program Files/Common Files/Microsoft Shared/DevServer/10.0/" + WEB_DEV_NAME
