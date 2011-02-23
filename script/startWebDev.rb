require  "albacore"
require 'fileutils'
if not((defined? ROOT)) then
	load File.join(File.dirname(__FILE__), 'varConfig.rb')
end

load 'tasks.rb'

task :default => [:compile, :startWebServer, :openUrl]

task :openUrl do
	LAUNCH_URL = "http://localhost:"+WEB_PORT
	system("start iexplore.exe " + LAUNCH_URL)
end