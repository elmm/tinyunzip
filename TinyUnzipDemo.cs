using System;
using System.IO;
using System.Linq;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
        	if(args.Length < 3)
        	{
        		Console.WriteLine("Usage: zip_file_name file_to_extract output_file");
        		return;
        	}

        	using(FileStream zipFileStream = new FileStream(args[0], FileMode.Open))
			{
				using(TinyUnzip tinyUnzip = new TinyUnzip(zipFileStream))
				{
					var zipEntry = tinyUnzip.Entries.Where(e => e.FullName == args[1]).First();
					var uncompressStream = tinyUnzip.GetStream(zipEntry.FullName);
					using(FileStream outStream = new FileStream(args[2], FileMode.Create))
					{
						byte[] buffer = new byte[1024 * 1024];
						Console.WriteLine(String.Format("Extracting {0} to {1}", args[1], args[2]));

						int read;
						while((read = uncompressStream.Read(buffer, 0, buffer.Length)) > 0)
						{
							outStream.Write(buffer, 0, read);
						}
					}
				}	
			}

			Console.WriteLine("Finished.");
        }
    }
}
