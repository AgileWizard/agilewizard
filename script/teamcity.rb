require  "albacore"

task :default => [:codeCoverage]

@root="C:\\Projects\\AgileWizard\\"
@ncoverConsole="C:\\Program Files\\NCover\\NCover.Console.exe"
@ncoverReporting="C:\\Program Files\\NCover\\NCover.Reporting.exe"
@projName="AgileWizard"
@outputDir=@root + "bin"
@webDevExeName = "WebDev.WebServer40.EXE"
@webDevExe = "C:\\Program Files\\Common Files\\Microsoft Shared\\DevServer\\10.0\\" + @webDevExeName
@webSiteLocation = @root + "src\\AgileWizard.Website"
@webDevPort = "1984"


desc "delete the bin directory before building"
task :deletebin do
	if FileTest::directory?(@outputDir) then
		require 'fileutils'
		FileUtils.rm_rf @outputDir
	end
end 

desc "Build the agile wizard teamcity file"
msbuild :build => :deletebin do |msb|
  msb.solution = @root+"src\\AgileWizard.sln"
  msb.targets :clean, :build
  msb.properties :configuration => :release
end

task :startWebServer => :build do
  @cmdText= "\"" + @webDevExe +"\"" + " /port:"  + @webDevPort + " /path:\"" + @webSiteLocation+"\""

  system("echo "+@cmdText)
  system("call taskkill /F /IM " + @webDevExeName)
  
  Thread.new{system(@cmdText)}
  sleep(2)
end

desc "Run NCover Console code coverage"
  ncoverconsole :ncoverconsole=>:startWebServer do |ncc|
    @xml_coverage = @outputDir+"\\CodeCoverage\\coverage.xml"

    #create xUnit directory
    unless FileTest::directory?(@outputDir + "/xUnit") then
      Dir::mkdir(@outputDir+"/xUnit")
    end

    File.delete(@xml_coverage) if File.exist?(@xml_coverage)

    ncc.log_level = :verbose
    ncc.path_to_command = @ncoverConsole
    ncc.output :xml => @xml_coverage
    ncc.working_directory = @root + "lib\\xunitnet"

    xunit = XUnitTestRunner.new(@root + "lib\\xunitnet" + "\\xunit.console.clr4.exe")
    xunit.log_level = :verbose

    #xunit.assembly= @outputDir + "\\Release\\AgileWizard.AcceptanceTests.dll"
    #xunit.assemblies @outputDir + "\\Release\\AgileWizard.AcceptanceTests.dll"
    #, @outputDir+"\\Release\\AgileWizard.Domain.Tests.dll"

    xunit.options = [
#      @outputDir+"\\Release\\AgileWizard.Domain.Tests.dll",
      @outputDir+"\\Release\\AgileWizard.AcceptanceTests.dll",
      "/xml "+ @outputDir + "\\xUnit\\XUnit-Result.xml"
    ]
    ncc.testrunner = xunit
  end

  desc "Run NCover Report to check code coverage"
  ncoverreport :coverageSummary => :ncoverconsole do |ncr|
    @xml_coverage = @outputDir + "\\CodeCoverage\\coverage.xml"
    ncr.parameters = [ "//p "+ @projName ]

    ncr.path_to_command = @ncoverReporting
    ncr.coverage_files @xml_coverage

    summaryreport = NCover::SummaryReport.new
    summaryreport.output_path = @outputDir + "\\CodeCoverage\\summary\\CoverageSummary.html"
    ncr.reports summaryreport

    ncr.required_coverage(
    	NCover::BranchCoverage.new(:minimum => 10)
    	# NCover::CyclomaticComplexity.new(:maximum => 1)
    )
  end

desc "Run NCover Report to check code coverage"
  ncoverreport :codeCoverage => :coverageSummary do |ncr|
    @xml_coverage = @outputDir + "\\CodeCoverage\\coverage.xml"
    ncr.parameters = [ "//p "+ @projName ]

    ncr.path_to_command = @ncoverReporting
    ncr.coverage_files @xml_coverage

    fullcoveragereport = NCover::FullCoverageReport.new
    fullcoveragereport.output_path = @outputDir+"\\CodeCoverage\\output"
    ncr.reports fullcoveragereport

    ncr.required_coverage(
    	NCover::BranchCoverage.new(:minimum => 10)
    	# NCover::CyclomaticComplexity.new(:maximum => 1)
    )
  end