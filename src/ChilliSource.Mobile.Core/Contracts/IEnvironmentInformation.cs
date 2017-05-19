#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChilliSource.Mobile.Core
{
	/// <summary>
	/// Contract for providing app and platform info for logging and API communication
	/// </summary>
	public interface IEnvironmentInformation
	{
        /// <summary>
        /// Determines whether the app is executing in a development, staging, or production environment
        /// </summary>
		string ExecutionEnvironment { get; }

        /// <summary>
        /// The unique id of the currently executing app
        /// </summary>
        string AppId { get; }

        /// <summary>
        /// The version of the currently executing app
        /// </summary>
        string AppVersion { get; }

        /// <summary>
        /// The user's timezone
        /// </summary>
		string Timezone { get; }

        /// <summary>
        /// The OS on which the currently executing app is running
        /// </summary>
		string Platform { get; }

        /// <summary>
        /// The currently executing application name
        /// </summary>
		string ApplicationName { get; }

        /// <summary>
        /// The name that the user has given the device, e.g. "John's iPhone 7"
        /// </summary>
		string DeviceName { get; }
	}
}
