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
		public bool IsSome => true;
		public bool IsNone => !IsSome;
		public T Value { get; }

		internal Some(T value)
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			Value = value;
		}

		public bool Equals(T other)
		{
			return Value.Equals(other);
		}

		[Pure]
		public static implicit operator Some<T>(T value) => new Some<T>(value);

		[Pure]
		public static implicit operator T(Some<T> value) => value.Value;

		[Pure]
		public override string ToString() => Value.ToString();

		[Pure]
		public override int GetHashCode() => Value.GetHashCode();

		[Pure]
		public override bool Equals(object obj) => Value.Equals(obj);

		[Pure]
		public Type GetUnderlyingType() => typeof(T);

	}

}
