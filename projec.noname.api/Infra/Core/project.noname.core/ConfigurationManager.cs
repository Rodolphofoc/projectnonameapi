using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace project.noname.core
{
    public class ConfigurationManager
    {
		private static KeyApp appSettings;
		public KeyApp AppSettings
		{
			get
			{
				if (appSettings == null)
					appSettings = new KeyApp();

				return appSettings;
			}
		}

		public class KeyApp
		{
			private IConfigurationRoot _configuration;
			public IConfigurationRoot Configuration
			{
				get
				{
					if (_configuration == null)
					{
						var builder = new ConfigurationBuilder()
							.SetBasePath(Directory.GetCurrentDirectory())
							.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
							.AddJsonFile("appsettings.json", optional: true);
							
						_configuration = builder.Build();
					}

					return _configuration;
				}
			}

			public string this[string key]
			{
				get
				{
					try
					{
						return Configuration[key];
					}
					catch { }
					return string.Empty;
				}
			}



			//public void AddRange(IDictionary<string, string> items)
			//{
			//	var builder = new ConfigurationBuilder()
			//		.SetBasePath(Directory.GetCurrentDirectory())
			//		.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
			//		.AddJsonFile("appsettings.json", optional: true)
			//		.AddEnvironmentVariables()
			//		.AddInMemoryCollection(items);
			//	_configuration = builder.Build();
			//}
		}

		public static string GetEnvironment
		{
			get
			{
				try
				{
					var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
					if (!string.IsNullOrWhiteSpace(env))
						return env;
				}
				catch { }
				return string.Empty;
			}
		}
	}

}



