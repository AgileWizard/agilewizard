require  "albacore"
require 'fileutils'

if not((defined? ROOT)) then
	load File.join(File.dirname(__FILE__), 'varConfig.rb')
end

load File.join(File.dirname(__FILE__), 'Rakefile')

task :default => [:deleteBin, :compile,:test,:clean]
