#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

namespace ChilliSource.Core
{
	/// <summary>
	/// Stores app and platform info for logging and API communication
	/// </summary>
	public class EnvironmentInformation : IEnvironmentInformation
	{
		public EnvironmentInformation() { }
		public EnvironmentInformation(string executionEnvironment, string appId,
									  string appVersion, string timezone,
									  string platform, string applicationName, string deviceName)
		{
			this.ExecutionEnvironment = executionEnvironment;
			this.AppId = appId;
			this.AppVersion = appVersion;
			this.Timezone = timezone;
			this.Platform = platform;
			this.ApplicationName = applicationName;
			this.DeviceName = deviceName;
		}

		public string ExecutionEnvironment { get; set; }
		public string AppId { get; set; }
		public string AppVersion { get; set; }
		public string Timezone { get; set; }
		public string Platform { get; set; }
		public string ApplicationName { get; set; }
		public string DeviceName { get; set; }

		public static EnvironmentInformation Empty => new EnvironmentInformation();

	}
}
