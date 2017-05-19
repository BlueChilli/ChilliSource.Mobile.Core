#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

namespace ChilliSource.Mobile.Core
{
	/// <summary>
	/// Stores app and platform info for logging and API communication
	/// </summary>
	public class EnvironmentInformation : IEnvironmentInformation
	{
        /// <summary>
        /// Default constructor
        /// </summary>
		public EnvironmentInformation() { }

        /// <summary>
        /// Initializes object and sets properties to the specified parameters
        /// </summary>
        /// <param name="executionEnvironment">Determines whether the app is executing in a development, staging, or production environment</param>
        /// <param name="appId">The unique id of the currently executing app</param>
        /// <param name="appVersion">The version of the currently executing app</param>
        /// <param name="timezone">The user's timezone</param>
        /// <param name="platform">The OS on which the currently executing app is running</param>
        /// <param name="applicationName">The currently executing application name</param>
        /// <param name="deviceName">The name that the user has given the device, e.g. "John's iPhone 7"</param>
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

        /// <summary>
        /// Determines whether the app is executing in a development, staging, or production environment
        /// </summary>
        public string ExecutionEnvironment { get; set; }

        /// <summary>
        /// The unique id of the currently executing app
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// The version of the currently executing app
        /// </summary>
		public string AppVersion { get; set; }

        /// <summary>
        /// The user's timezone
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// The OS on which the currently executing app is running
        /// </summary>
		public string Platform { get; set; }

        /// <summary>
        /// The currently executing application name
        /// </summary>
		public string ApplicationName { get; set; }

        /// <summary>
        /// The name that the user has given the device, e.g. "John's iPhone 7"
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// A blank instance of the current class
        /// </summary>
		public static EnvironmentInformation Empty => new EnvironmentInformation();

	}
}
