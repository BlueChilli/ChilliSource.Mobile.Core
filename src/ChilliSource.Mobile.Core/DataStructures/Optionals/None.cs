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
	public struct None : IOptional
	{
		public bool IsNone => true;
		public bool IsSome => false;
		public Type GetUnderlyingType() => null;
		public static None Default => new None();
	}
}
