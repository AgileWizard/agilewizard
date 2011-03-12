require 'rubygems'

gem 'rubyzip'

require 'zip/zip'

class BackupRaven
  
  attr_accessor:output_folder
  
  def compress(zip_file_name, raw_file_name)
    Zip::ZipFile.open(zip_file_name, Zip::ZipFile::CREATE) do |zip|
      base_name = File.basename raw_file_name
      zip.add(base_name, raw_file_name)
    end
  end
  
  def zip(raw_file_name)
    zip_file_name = output_folder + Time.new.strftime('%Y%m%d') + '.zip'
    
    if File.exists?(zip_file_name)
      puts "deleting old #{zip_file_name} ..."
      puts
      File.delete zip_file_name
    end
    
    puts "adding #{raw_file_name} into #{zip_file_name} ..."
    puts
    compress(zip_file_name, raw_file_name)
  end
  
  def export_raven(dump_file)
    system "RavenSmuggler out http://localhost:8080 #{dump_file}"
  end
  
  def backup
    puts

    dump_file = output_folder + "dump.raven"

    export_raven dump_file
    zip dump_file
    
    if File.exists?(dump_file)
      File.delete dump_file
    end
    
    puts "Done!"
    puts
  end
end

if ARGV.length > 0
  dump_file_folder = ARGV[0]
else
  dump_file_folder = ''
end

obj = BackupRaven.new
obj.output_folder = dump_file_folder
obj.backup




