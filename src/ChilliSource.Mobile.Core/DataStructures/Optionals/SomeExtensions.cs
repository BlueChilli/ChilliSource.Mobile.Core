#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

/* based on
Source: 	language-ext (https://github.com/louthy/language-ext)
Author: 	Paul Louth (https://github.com/louthy)
License:	MIT https://github.com/louthy/language-ext/blob/master/LICENSE)
*/

using System;
namespace ChilliSource.Mobile.Core
{
	/// <summary>
	/// Functional query extensions for <see cref="T:ChilliSource.Mobile.Core.Some"/>
	/// </summary>
	public static class SomeExtensions
	{
		/// <summary>
		/// Convert value to Some T.  Helps with the lack of covariance of generic
		/// parameters in structs (and therefore Some T)
		/// </summary>
		/// <typeparam name="T">Value type</typeparam>
		/// <param name="value">Value</param>
		/// <returns>Value wrapped in a Some T</returns>
		public static Some<T> ToSome<T>(this T value)
		{
			return new Some<T>(value);
		}
	}

}
