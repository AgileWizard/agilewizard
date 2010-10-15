require  "albacore"

task :default => [:build]

msbuild :build do |msb|
  msb.solution = "src\AgileWizard.sln"
  msb.targets :clean, :build
  msb.properties :configuration => :release
end