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

namespace ChilliSource.Mobile.Core
{
	/// <summary>
	/// A unit type is a type that allows only one value (and thus can hold no information)
	/// </summary>
	public struct Unit : IEquatable<Unit>
	{
        /// <summary>
        /// Instance with default values
        /// </summary>
		public static readonly Unit Default = new Unit();

        /// <summary>
        /// Returns 0
        /// </summary>
        /// <returns></returns>
		[Pure]        
		public override int GetHashCode() => 0;

        /// <summary>
        /// Equality override
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
		[Pure]
		public override bool Equals(object obj) => obj is Unit;

        /// <summary>
        /// Returns "()"
        /// </summary>
        /// <returns></returns>
		[Pure]
		public override string ToString() => "()";

        /// <summary>
        /// Returns true
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
		[Pure]
		public bool Equals(Unit other) => true;

        /// <summary>
        /// Returns true
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
		[Pure]
		public static bool operator ==(Unit lhs, Unit rhs) => true;

        /// <summary>
        /// Returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
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
