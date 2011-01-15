require  "albacore"
require 'fileutils'
load 'varConfig.rb'

task :default => [:publish]

msbuild :publish do |msb|
  msb.solution = WEBSITE_PROJ
  msb.targets :publish
  msb.parameters  [ "/T:Package",
					"/P:Configuration=" + COMILE_MODE]
end
