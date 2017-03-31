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
		string ExecutionEnvironment { get; }
		string AppId { get; }
		string AppVersion { get; }
		string Timezone { get; }
		string Platform { get; }
		string ApplicationName { get; }
		string DeviceName { get; }
	}
}
