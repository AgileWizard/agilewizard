require  "albacore"
require 'fileutils'
if not((defined? ROOT)) then
	load 'varConfig.rb'
end
#load 'publish.rb'

# Configuration
APPLICATION_DIR = "C:/inetpub/wwwroot/Agile wizard"
APPLICATION_BACKUP_DIR = 'C:/backups'
RAVENDB_DATA_BACKUP_DIR = 'C:/backups'

time = Time.new

# Current date and time string format
CURRENT_DATE_TIME = time.strftime("%Y%m%d_%H%M%S")

task :default => [:backupApp, :backupData, :deploy]

desc 'backup the old website applications'
task :backupApp do |zip|
	# zip.output_path APPLICATION_BACKUP_DIR
	# zip.directories_to_zip APPLICATION_DIR
	# zip.additional_files =""
	# zip.output_file CURRENT_DATE_TIME + '.zip'
end

desc 'backup the raven db data'
task :backupData do
end

desc ''
task :deploy do

end
