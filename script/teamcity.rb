require  "albacore"
require 'fileutils'

if not((defined? ROOT)) then
	load File.join(File.dirname(__FILE__), 'varConfig.rb')
end

load File.join(File.dirname(__FILE__), 'tasks.rb')

task :default => [:init, :compile,:test,:clean]

desc "initialize the server environment"
task :init do
  puts "delete the bin directory before building"
  if FileTest::directory?(OUTPUT_DLL_DIR) then
		FileUtils.rm_rf OUTPUT_DLL_DIR
	end
end
