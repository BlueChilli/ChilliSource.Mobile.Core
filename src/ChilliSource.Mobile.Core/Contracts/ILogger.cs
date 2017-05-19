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

namespace ChilliSource.Mobile.Core
{
	/// <summary>
	/// Contract for implementation independent logging of information, errors, warnings
	/// </summary>
	public interface ILogger
	{
        /// <summary>
        /// Logs the <paramref name="message"/> as an information entry
        /// </summary>
        /// <param name="message"></param>
		void Information(string message);

        /// <summary>
        /// Logs the <paramref name="exception"/> and <paramref name="message"/> as an information entry
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        void Information(Exception exception, string message);

        /// <summary>
        /// Logs the <paramref name="message"/> as a debug entry
        /// </summary>
        /// <param name="message"></param>
        void Debug(string message);

        /// <summary>
        /// Logs the <paramref name="exception"/> and <paramref name="message"/> as a debug entry
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        void Debug(Exception exception, string message);

        /// <summary>
        /// Logs the <paramref name="message"/> as a debug entry
        /// </summary>
        /// <param name="message"></param>
        void Warning(string message);

        /// <summary>
        /// Logs the <paramref name="exception"/> and <paramref name="message"/> as a warning entry
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        void Warning(Exception exception, string message);

        /// <summary>
        /// Logs the <paramref name="exception"/> as an error entry
        /// </summary>
        /// <param name="exception"></param>
        void Error(Exception exception);

        /// <summary>
        /// Logs the <paramref name="exception"/> and <paramref name="message"/> as an error entry
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        void Error(Exception exception, string message);
	}
}
