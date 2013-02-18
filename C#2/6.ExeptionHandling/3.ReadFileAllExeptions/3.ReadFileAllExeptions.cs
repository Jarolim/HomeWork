using System;
using System.IO;//
using System.Security;//

namespace _3.ReadFileAllExeptions
{
	
	class ReadFileAllExeptions
	{
		/*Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini),
		  reads its contents and prints it on the console.
		  Find in MSDN how to use System.IO.File.ReadAllText(…).
		  Be sure to catch all possible exceptions and print user-friendly error messages.*/
		static void ReadFilesContent(string path)
		{
			Console.WriteLine(path);
		}
		static void Main()
		{
			try
			{
				string path = File.ReadAllText(@"C:\WINDOWS\win.ini");
				ReadFilesContent(path);
			}
			catch (ArgumentNullException)
			{
				Console.WriteLine("Path is null.");
			}
			catch (PathTooLongException)
			{
				Console.WriteLine("The specified path, file name, or both exceed the system-defined maximum length");
			}
			catch (DirectoryNotFoundException)
			{
				Console.WriteLine("The specified path is invalid. ");
			}
			catch (IOException)
			{
				Console.WriteLine("An I/O error occurred while opening the file.");
			}
			catch (UnauthorizedAccessException)
			{
				Console.WriteLine("path specified a file that is read-only. \n -or- This operation is not supported on the current platform.\n -or- path specified a directory.\n -or- The caller does not have the required permission. ");
			}
			catch (NotSupportedException)
			{
				Console.WriteLine("An I/O error occurred while opening the file.");
			}
			catch (SecurityException)
			{
				Console.WriteLine("The caller does not have the required permission. ");
			}
		}
	}
}
