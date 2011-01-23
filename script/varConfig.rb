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
PUBLISH_DIR = File.join(OUTPUT_DIRECTORY, "Publish")
WEB_DEV_NAME = "WebDev.WebServer40.EXE"
WEB_DEV_FULL_NAME = "C:/Program Files/Common Files/Microsoft Shared/DevServer/10.0/" + WEB_DEV_NAME

DEPLOY_SOURCE = File.join(PUBLISH_DIR, COMILE_MODE)
AT_CONFIG_NAME = "AgileWizard.AcceptanceTests.dll.config"
AT_CONFIG_PATH = File.join(OUTPUT_DLL_DIR, AT_CONFIG_NAME)
AT_CONFIG_SITE = "http://localhost/"