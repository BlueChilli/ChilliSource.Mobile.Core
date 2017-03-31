#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

using System;
using System.Collections.Generic;

namespace ChilliSource.Mobile.Core
{
	/// <summary>
	/// Contract for <see cref="T:ChilliSource.Mobile.Core.OperationResult"/>
	/// </summary>
	public interface IOperationResult
	{
		bool IsHandled { get; }
		Exception Exception { get; }
		bool IsSuccessful { get; set; }
		bool IsCancelled { get; set; }
		bool IsFailure { get; }
		string Message { get; set; }
		List<string> Warnings { get; set; }
	}

}
