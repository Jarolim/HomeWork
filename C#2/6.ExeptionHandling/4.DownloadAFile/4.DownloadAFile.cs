﻿using System;
using System.Net;

namespace _04.DownloadAFile
{
	class DownloadAFile
	{
		static void Main()
		{
			string address = "http://www.devbg.org/img/Logo-BASD.jpg";
			string file = "logo.jpg";

			using (WebClient myClient = new WebClient())
			{
				try
				{
					myClient.DownloadFile(address, file);
					Console.WriteLine("The file was downloaded in the project directory!");
				}
				catch (ArgumentNullException)
				{
					Console.WriteLine("No-value provided for the web-address (or null value). Please specify a valid address.");
				}
				catch (ArgumentException)
				{
					Console.WriteLine("The web-address name is empty. Please specify a valid address.");
				}
				catch (WebException)
				{
					Console.WriteLine("The URL was not found! Please make sure the address is correct.");
				}
				catch (NotSupportedException)
				{
					Console.WriteLine("This operation is already performed by another method.");
				}

			}

		}
	}
}
