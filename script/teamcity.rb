require  "albacore"
require 'fileutils'

task :default => [:compile,:test,:clean]

ROOT = File.expand_path(File.join(File.dirname(__FILE__), ".."))
puts "Project root directory is " + ROOT

SOLUTION = File.join(ROOT,"src/AgileWizard.sln")
XUNIT_PATH = File.join(ROOT, "lib/xunitnet/xunit.console.clr4.exe")
PROJECT_NAME = "AgileWizard"
OUTPUT_DIRECTORY = File.join(ROOT, "bin")
COMILE_MODE = "Release"
OUTPUT_DLL_DIR = File.join(OUTPUT_DIRECTORY, COMILE_MODE)
WEB_DEV_NAME = "WebDev.WebServer40.EXE"
WEB_DEV_FULL_NAME = "C:/Program Files/Common Files/Microsoft Shared/DevServer/10.0/" + WEB_DEV_NAME

# Webdevexe does not accept "/" as a directory path, use "\\" instead
WEBSITE_LOCATION = File.expand_path(File.join(ROOT, "src/AgileWizard.Website")).gsub(/\//, "\\")
WEB_PORT = "1984"

desc "initialize the server environment"
task :init do
  puts "delete the bin directory before building"
  if FileTest::directory?(OUTPUT_DLL_DIR) then
		FileUtils.rm_rf OUTPUT_DLL_DIR
	end
end

desc "Build the agile wizard teamcity file"
msbuild :compile => :init do |msb|
  msb.solution = SOLUTION
  msb.verbosity = "minimal"
  msb.targets :clean, :build
  msb.properties :configuration => :release,:platform => 'Any CPU'
end

task :test=>[:startWebServer,
			:openIE,
            :xunit
			] do    
end

task :startWebServer do
  START_COMMAND= "\"" + WEB_DEV_FULL_NAME + "\"" + " /port:"  + WEB_PORT + " /path:\"" + WEBSITE_LOCATION+"\""
  
  puts START_COMMAND
  system("call taskkill /F /IM " + WEB_DEV_NAME)

  Thread.new{system(START_COMMAND)}
  sleep(1)
end

xunit :xunit =>[:startWebServer,:openIE] do |xunit|
    xunit.command = XUNIT_PATH
	xunit.assemblies = [
		File.join(OUTPUT_DLL_DIR, "AgileWizard.Domain.Tests.dll"),
		File.join(OUTPUT_DLL_DIR, "AgileWizard.Website.Tests.dll"),
		File.join(OUTPUT_DLL_DIR, "AgileWizard.AcceptanceTests.dll"),
		File.join(OUTPUT_DLL_DIR, "AgileWizard.IntegrationTests.dll"),
		File.join(OUTPUT_DLL_DIR, "AgileWizard.Locale.Tests.dll")
		]
end

task :openIE do
	puts "close all IE first"
	system("call taskkill /F /IM iexplore*")

	puts "start one IE for forbidding the COM error when WatiN running"
	system("start iexplore.exe about:blank")
end

desc "finialize the whole step"
task :clean do
 
end