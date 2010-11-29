require  "albacore"
require 'fileutils'

task :default => [:test,:clean]

@root=File.expand_path(File.join(File.dirname(__FILE__), ".."))
if @root=="C:/" then
  puts "change root from c drive"
  # only for teamcity.rb debugging
  @root="C:/Projects/AgileWizard/"
end
puts "Project root directory is " + @root

@sln=File.join(@root,"src/AgileWizard.sln")
@xunitExe = "xunit.console.clr4.exe"
@ncoverConsole="C:/Program Files/NCover/NCover.Console.exe"
@xunitPath = @root + "lib/xunitnet/" + @xunitExe
@ncoverReporting="C:/Program Files/NCover/NCover.Reporting.exe"
@projName="AgileWizard"
@outputDir = @root + "bin"
@outputDllDir = File.join(@outputDir, "Release")
@webDevExeName = "WebDev.WebServer40.EXE"
@webDevExe = "C:/Program Files/Common Files/Microsoft Shared/DevServer/10.0/" + @webDevExeName

# webdevexe does not accept "/" as a directory path, use "\\" instead
@webSiteLocation = File.expand_path(File.join(@root, "src/AgileWizard.Website")).gsub(/\//, "\\")
@webDevPort = "1984"

desc "delete the bin directory before building"
task :deletebin do
	if FileTest::directory?(@outputDir) then
		FileUtils.rm_rf @outputDir
	end
end

desc "initialize the server environment"
task :init =>:deletebin do
  puts "close all IE"
  system("call taskkill /F /IM iexplore*")

  puts "start one IE for forbidding the COM error when WatiN running"
  system("start iexplore.exe")
end


desc "Build the agile wizard teamcity file"
msbuild :compile => :init do |msb|
  msb.solution = @sln
  msb.version = "v4.0.30319"
  msb.targets :clean, :build
  msb.properties :configuration => :release
end

task :startWebServer => :compile do
  @cmdText= "\"" + @webDevExe +"\"" + " /port:"  + @webDevPort + " /path:\"" + @webSiteLocation+"\""
  
  puts @cmdText
  system("call taskkill /F /IM " + @webDevExeName)

  Thread.new{system(@cmdText)}
  sleep(2)
end

task :test=>[:compile,
            :xunit_acceptance,
            :xunit_domain,
            :xunit_mvc,
            :xunit_website] do
    
end

xunit :xunit_acceptance=>:startWebServer do |xunit|
    xunit.path_to_command = @xunitPath
    xunit.assembly = File.join(@outputDllDir, "AgileWizard.AcceptanceTests.dll")
end

xunit :xunit_domain do |xunit|
    xunit.path_to_command = @xunitPath
    xunit.assembly = File.join(@outputDllDir, "AgileWizard.Domain.Tests.dll")
end

xunit :xunit_mvc do |xunit|
    xunit.path_to_command = @xunitPath
    xunit.assembly = File.join(@outputDllDir, "AgileWizard.MVC.Tests.dll")
end

xunit :xunit_website do |xunit|
    xunit.path_to_command = @xunitPath
    xunit.assembly = File.join(@outputDllDir, "AgileWizard.Website.Tests.dll")
end

desc "Run NCover Console code coverage"
  ncoverconsole :ncoverconsole=>[:test] do |ncc|
    @xml_coverage = @outputDir+"/CodeCoverage/coverage.xml"

    #create xUnit directory
    unless FileTest::directory?(@outputDir + "/xUnit") then
      Dir::mkdir(@outputDir+"/xUnit")
    end

    File.delete(@xml_coverage) if File.exist?(@xml_coverage)

    ncc.log_level = :verbose
    ncc.path_to_command = @ncoverConsole
    ncc.output :xml => @xml_coverage
    ncc.working_directory = "."

    xunit = XUnitTestRunner.new(@root + "lib/xunitnet/" + @xunitExe)
    xunit.log_level = :verbose

    xunit.options = [
      @outputDir+"/Release/AgileWizard.Domain.Tests.dll",
#      @outputDir+"/Release/AgileWizard.AcceptanceTests.dll",
      "/xml "+ @outputDir + "/xUnit/XUnit-Result.xml"
    ]
    ncc.testrunner = xunit
  end

  desc "Run NCover Report to check code coverage"
  ncoverreport :coverageSummary => :ncoverconsole do |ncr|
    @xml_coverage = @outputDir + "/CodeCoverage/coverage.xml"
    ncr.parameters = [ "//p "+ @projName ]

    ncr.path_to_command = @ncoverReporting
    ncr.coverage_files @xml_coverage

    summaryreport = NCover::SummaryReport.new
    summaryreport.output_path = @outputDir + "/CodeCoverage/summary/CoverageSummary.html"
    ncr.reports summaryreport

    ncr.required_coverage(
    	NCover::BranchCoverage.new(:minimum => 10)
    	# NCover::CyclomaticComplexity.new(:maximum => 1)
    )
  end

desc "Run NCover Report to check code coverage"
  ncoverreport :codeCoverage => :coverageSummary do |ncr|
    @xml_coverage = @outputDir + "/CodeCoverage/coverage.xml"
    ncr.parameters = [ "//p "+ @projName ]

    ncr.path_to_command = @ncoverReporting
    ncr.coverage_files @xml_coverage

    fullcoveragereport = NCover::FullCoverageReport.new
    fullcoveragereport.output_path = @outputDir+"/CodeCoverage/output"
    ncr.reports fullcoveragereport

    ncr.required_coverage(
    	NCover::BranchCoverage.new(:minimum => 10)
    	# NCover::CyclomaticComplexity.new(:maximum => 1)
    )
  end

desc "finialize the who step"
task :clean do
 
end