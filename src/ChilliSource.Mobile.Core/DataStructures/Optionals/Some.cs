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
	/// Represents a concrete value in a given <see cref="T:ChilliSource.Mobile.Core.Optional"/>
	/// </summary>
	public struct Some<T> : IOptional, IEquatable<T>
	{
        /// <summary>
        /// Returns true
        /// </summary>
		public bool IsSome => true;

        /// <summary>
        /// Returns false
        /// </summary>
        public bool IsNone => !IsSome;

        /// <summary>
        /// The generic value
        /// </summary>
        public T Value { get; }

		internal Some(T value)
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			Value = value;
		}

        /// <summary>
        /// Compares <paramref name="other"/> with <see cref="Value"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
		public bool Equals(T other)
		{
			return Value.Equals(other);
		}

        /// <summary>
        /// Implicit operator to assign T to Some&lt;T&gt;
        /// </summary>
        /// <param name="value"></param>
		[Pure]
		public static implicit operator Some<T>(T value) => new Some<T>(value);

        /// <summary>
        /// Implicit operator to assign Some&lt;T&gt; to T
        /// </summary>
        /// <param name="value"></param>
		[Pure]
		public static implicit operator T(Some<T> value) => value.Value;

        /// <summary>
        /// Returns string representation of <see cref="Value"/>
        /// </summary>
        /// <returns></returns>
		[Pure]
		public override string ToString() => Value.ToString();

        /// <summary>
        /// Returns Hashcode of <see cref="Value"/>
        /// </summary>
        /// <returns></returns>
		[Pure]
		public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Compares <paramref name="other"/> with <see cref="Value"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
		[Pure]
		public override bool Equals(object other) => Value.Equals(other);

        /// <summary>
        /// Returns the type info of the instance's generic type 
        /// </summary>
        /// <returns></returns>
		[Pure]
		public Type GetUnderlyingType() => typeof(T);

	}

}
