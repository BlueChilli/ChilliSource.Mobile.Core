#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

using System;
namespace ChilliSource.Core
{
	/// <summary>
	/// Contract for <see cref="T:ChilliSource.Mobile.Core.ServiceResult"/>
	/// </summary>
	public interface IServiceResult : IOperationResult
	{
		int StatusCode { get; }
	}
}