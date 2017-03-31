#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

using System;
using System.Reflection;

namespace ChilliSource.Mobile.Core
{
	public abstract class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
	{
		protected abstract bool EqualsCore(T other);
		protected abstract int GetHashCodeCore();

		public override int GetHashCode()
		{
			return this.GetHashCodeCore();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			var other = obj as T;
			return this.Equals(other);
		}

		public bool Equals(T other)
		{
			return EqualsCore(other);
		}

		public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
		{
			if (ReferenceEquals(x, null) && ReferenceEquals(y, null)) return true;
			if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;

			return x.Equals(y);
		}

		public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
		{
			return !(x == y);
		}
	}
}
