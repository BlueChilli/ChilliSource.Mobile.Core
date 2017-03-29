#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

/* 
Source: 	Serilog (https://github.com/serilog/serilog)
Author: 	Serilog (https://github.com/serilog)
License:	Apache License Version 2.0 (https://github.com/serilog/serilog/blob/dev/LICENSE)
*/

using System;
using System.Collections.Generic;

namespace ChilliSource.Core
{
	/// <summary>
	/// Contract for implementation independant logging of information, errors, warnings
	/// </summary>
	public interface ILogger
	{
		void Information(string message);
		void Information(Exception exception, string message);
		void Debug(string message);
		void Debug(Exception exception, string message);
		void Warning(string message);
		void Warning(Exception exception, string message);
		void Error(Exception exception);
		void Error(Exception exception, string message);
	}
}
