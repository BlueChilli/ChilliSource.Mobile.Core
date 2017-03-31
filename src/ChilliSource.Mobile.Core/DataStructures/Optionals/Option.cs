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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilliSource.Mobile.Core
{
	/// <summary>
	/// Helper class to simplify syntax through automatic casting from Option to Option<T>
	/// via Option<T>'s implicit conversion operators
	/// e.g. Option.None is automatically converted to Option<T>.None
	/// </summary>
	public static class Option
	{
		public static None None => None.Default;
		public static Some<T> Some<T>(T value) => new Some<T>(value);
	}

	/// <summary>
	/// Functional programming inspired implementation of optionals, allowing the distinction 
	/// betweeb 3 states of a variable: no value, value, empty value
	/// </summary>
	public struct Option<T> : IOptional, IComparable<Option<T>>, IComparable<T>, IEquatable<Option<T>>, IEquatable<T>
	{
		private Option(T value)
		{
			this.IsSome = true;
			_value = value;
		}

		[Pure]
		public static Option<T> Some(T value) => new Option<T>(value);

		/// <summary>
		/// Option None of T
		/// </summary>
		public static readonly Option<T> None = new Option<T>();

		public bool IsSome { get; }

		/// <summary>
		/// true if the Option is in a None state
		/// </summary>
		public bool IsNone => !IsSome;

		[Pure]
		public static implicit operator Option<T>(T value) =>
			value == null ? None : Some(value);

		[Pure]
		public static implicit operator Option<T>(None _) => None;

		[Pure]
		public static implicit operator Option<T>(Some<T> _) => new Option<T>(_.Value);


		private readonly T _value;
		public T Value
		{
			get
			{
				if (HasNoValue)
				{
					throw new InvalidOperationException();
				}

				return _value;
			}
		}

		public bool HasValue => IsSome;
		public bool HasNoValue => IsNone;

		public static bool operator ==(Option<T> option, T @value)
		{
			if (option.HasNoValue)
			{
				return false;
			}

			return option.Value.Equals(@value);
		}

		public static bool operator !=(Option<T> option, T @value)
		{
			return !(option == value);
		}

		public static bool operator ==(Option<T> first, Option<T> second)
		{
			return first.Equals(second);
		}

		public static bool operator !=(Option<T> first, Option<T> second)
		{
			return !(first == second);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Option<T>))
				return false;

			var other = (Option<T>)obj;

			return this.Equals(other);
		}

		public bool Equals(Option<T> other)
		{
			if (HasNoValue && other.HasNoValue)
				return true;

			if (HasNoValue || other.HasNoValue)
				return false;

			return _value.Equals(other._value);
		}

		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}

		public override string ToString()
		{
			return _value.ToString();
		}

		public T Unwrap(T defaultValue = default(T))
		{
			return HasValue ? _value : defaultValue;
		}

		public int CompareTo(Option<T> other)
		{
			if (HasNoValue && other.HasNoValue)
				return 0;

			if (HasValue && other.HasNoValue)
				return 1;

			if (HasNoValue && other.HasValue)
				return -1;

			return Comparer<T>.Default.Compare(_value, other.Value);
		}

		public int CompareTo(T other)
		{
			if (_value == null && other == null)
				return 0;

			if (_value != null && other == null)
				return 1;

			if (_value == null && other != null)
				return -1;

			return Comparer<T>.Default.Compare(_value, other);
		}

		public bool Equals(T other)
		{
			if (HasNoValue && other == null)
				return true;

			if (HasNoValue || other == null)
				return false;

			return _value.Equals(other);
		}

		public Type GetUnderlyingType()
		{
			return typeof(T);
		}

		public Unit Match(Action<T> Some, Action None) => Match(Some.ToFunc(), None.ToFunc());

		public R Match<R>(Func<T, R> Some, Func<R> None) => IsSome ? Some(Value) : None();

		/// <summary>
		/// Invokes the someHandler if Option is in the Some state, otherwise nothing
		/// happens.
		/// </summary>
		public Unit IfSome(Action<T> someHandler) => IfSome(someHandler.ToFunc());

		/// <summary>
		/// Invokes the someHandler if Option is in the Some state, otherwise nothing
		/// happens.
		/// </summary>
		public Unit IfSome(Func<T, Unit> someHandler) => IfSome<Unit>(someHandler);

		/// <summary>
		/// Invokes the someHandler if Option is in the Some state, otherwise nothing
		/// happens.
		/// </summary>
		public R IfSome<R>(Func<T, R> someHandler)
		{
			if (IsSome)
			{
				return someHandler(Value);
			}

			return default(R);
		}

		public Unit IfNone(Action noneHandler) => IfNone(noneHandler.ToFunc());
		public R IfNone<R>(Func<R> noneHandler) => Match((arg) => { return default(R); }, noneHandler);

		public IEnumerable<T> AsEnumerable()
		{
			if (IsSome)
			{
				yield return Value;
			}
		}

		public IEnumerable<R> SelectMany<R>(Func<T, IEnumerable<R>> selector) =>
		this.AsEnumerable().SelectMany(m => selector(m));
	}
}
