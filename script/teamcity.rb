require  "albacore"

task :default => [:ncoverreport]

desc "Build the agile wizard teamcity file"
msbuild :build do |msb|
  msb.solution = "src\\AgileWizard.sln"
  msb.targets :clean, :build
  msb.properties :configuration => :release
end

desc "Run NCover Console code coverage"
  ncoverconsole :ncoverconsole=>:build do |ncc|
    @xml_coverage = "bin\\CodeCoverage\\test-coverage.xml"
    
    #create xUnit directory
    unless FileTest::directory?("bin/xUnit") then
	Dir::mkdir("bin/xUnit")
    end

    File.delete(@xml_coverage) if File.exist?(@xml_coverage)

    ncc.log_level = :verbose
    ncc.path_to_command = "C:\\Program Files\\NCover\\NCover.Console.exe"
    ncc.output :xml => @xml_coverage
    ncc.working_directory = "lib\\xunitnet"

    xunit = XUnitTestRunner.new("lib\\xunitnet\\xunit.console.clr4.exe")
    xunit.log_level = :verbose
    # xunit.assembly = "bin\\Release\\AgileWizard.Domain.Tests.dll"
    xunit.options = [
      "bin\\Release\\AgileWizard.Domain.Tests.dll",
      "/xml bin\\xUnit\\XUnit-Result.xml"
    ]
    ncc.testrunner = xunit
  end

  desc "Run NCover Report to check code coverage"
  ncoverreport :ncoverreport => :ncoverconsole do |ncr|
    @xml_coverage = "bin\\CodeCoverage\\test-coverage.xml"

    ncr.path_to_command = "C:\\Program Files\\NCover\\NCover.Reporting.exe"
    ncr.coverage_files @xml_coverage

    fullcoveragereport = NCover::FullCoverageReport.new
    fullcoveragereport.output_path = "bin\\CodeCoverage\\output"
    ncr.reports fullcoveragereport

    ncr.required_coverage(
    	NCover::BranchCoverage.new(:minimum => 10)
    	# NCover::CyclomaticComplexity.new(:maximum => 1)
    )
  end