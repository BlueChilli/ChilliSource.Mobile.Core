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
    /// A contract for optional types to explicity represent a variable's state of having and not having a value and prevent null reference exceptions
    /// </summary>
	public interface IOptional
	{
        /// <summary>
        /// Determines if the instance is set to the empty value
        /// </summary>
		bool IsNone { get; }

        /// <summary>
        /// Determines if the instance has a non-empty value
        /// </summary>
		bool IsSome { get; }

        /// <summary>
        /// Returns the generic type of the instance implementing this contract
        /// </summary>
        /// <returns></returns>
		Type GetUnderlyingType();
	}
}
