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
    /// Represents the empty state of a  given <see cref="T:ChilliSource.Mobile.Core.Optional"/>
    /// </summary>
    public struct None : IOptional
	{
        /// <summary>
        /// Returns true
        /// </summary>
		public bool IsNone => true;

        /// <summary>
        /// Returns false
        /// </summary>
        public bool IsSome => false;

        /// <summary>
        /// Returns null
        /// </summary>
        /// <returns></returns>
        public Type GetUnderlyingType() => null;

        /// <summary>
        /// Returns a new <see cref="None"/> instance with default values set
        /// </summary>
        public static None Default => new None();
	}
}
