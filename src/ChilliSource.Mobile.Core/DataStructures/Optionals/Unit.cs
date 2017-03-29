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
using System.Threading.Tasks;

namespace ChilliSource.Core
{
	/// <summary>
	/// A unit type is a type that allows only one value (and thus can hold no information)
	/// </summary>
	public struct Unit : IEquatable<Unit>
	{
		public static readonly Unit Default = new Unit();

		[Pure]
		public override int GetHashCode() => 0;

		[Pure]
		public override bool Equals(object obj) => obj is Unit;

		[Pure]
		public override string ToString() => "()";

		[Pure]
		public bool Equals(Unit other) => true;

		[Pure]
		public static bool operator ==(Unit lhs, Unit rhs) => true;

		[Pure]
		public static bool operator !=(Unit lhs, Unit rhs) => false;

		/// <summary>
		/// Provide an alternative value to unit
		/// </summary>
		/// <typeparam name="T">Alternative value type</typeparam>
		/// <param name="anything">Alternative value</param>
		/// <returns>Alternative value</returns>
		[Pure]
		public T Return<T>(T anything) => anything;

		/// <summary>
		/// Provide an alternative value to unit
		/// </summary>
		/// <typeparam name="T">Alternative value type</typeparam>
		/// <param name="anything">Alternative value</param>
		/// <returns>Alternative value</returns>
		[Pure]
		public T Return<T>(Func<T> anything) => anything();
	}


}
