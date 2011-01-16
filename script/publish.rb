require  "albacore"
require 'fileutils'
if not((defined? ROOT)) then
	load File.join(File.dirname(__FILE__), 'varConfig.rb')
end

task :default => [:publish]

desc 'starting to publish the website project'
msbuild :publish do |msb|
  msb.solution = WEBSITE_PROJ
  msb.verbosity = "minimal"
  msb.targets :publish
  msb.parameters  [ "/T:Package",
					"/P:Configuration=" + COMILE_MODE]
end
