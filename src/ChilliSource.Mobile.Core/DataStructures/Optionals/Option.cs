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
    /// Helper class to simplify syntax through automatic casting from Option to Option{T}
    /// via Option{T}'s implicit conversion operators
    /// e.g. Option.None is automatically converted to Option{T}.None
    /// </summary>
    public static class Option
	{
        /// <summary>
        /// The empty state representation
        /// </summary>
		public static None None => None.Default;

        /// <summary>
        /// Container for the value of the optional
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Some<T> Some<T>(T value) => new Some<T>(value);
	}

	/// <summary>
	/// Functional programming inspired implementation of optionals 
    /// to explicity represent a variable's state of having and not having a value and prevent null reference exceptions
	public struct Option<T> : IOptional, IComparable<Option<T>>, IComparable<T>, IEquatable<Option<T>>, IEquatable<T>
	{
		private Option(T value)
		{
			this.IsSome = true;
			_value = value;
		}

        /// <summary>
        /// Wraps <paramref name="value"/> into an <see cref="Option"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
		[Pure]
		public static Option<T> Some(T value) => new Option<T>(value);

		/// <summary>
		/// Option None of T
		/// </summary>
		public static readonly Option<T> None = new Option<T>();

        /// <summary>
        /// True is option has a value
        /// </summary>
		public bool IsSome { get; }

		/// <summary>
		/// True if the Option has the empty state
		/// </summary>
		public bool IsNone => !IsSome;

        /// <summary>
        /// Allows assigning T to Option&lt;T&gt;
        /// </summary>
        /// <param name="value"></param>
		[Pure]
		public static implicit operator Option<T>(T value) =>
			value == null ? None : Some(value);

        /// <summary>
        /// Allows assigning a <see cref="None"/> instance to an <see cref="Option"/>
        /// </summary>
        /// <param name="_"></param>
		[Pure]
		public static implicit operator Option<T>(None _) => None;

        /// <summary>
        /// Allows assigning a <see cref="Some"/> instance to an <see cref="Option"/>
        /// </summary>
        /// <param name="_"></param>
		[Pure]
		public static implicit operator Option<T>(Some<T> _) => new Option<T>(_.Value);


		private readonly T _value;

        /// <summary>
        /// The generic value of the optional
        /// </summary>
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

        /// <summary>
        /// True if instance has some value
        /// </summary>
		public bool HasValue => IsSome;

        /// <summary>
        /// True if instance is in empty state
        /// </summary>
        public bool HasNoValue => IsNone;

        /// <summary>
        /// Determines equality between <paramref name="option"/>'s Value and <paramref name="value"/>
        /// </summary>
        /// <param name="option"></param>
        /// <param name="value"></param>
        /// <returns></returns>
		public static bool operator ==(Option<T> option, T @value)
		{
			if (option.HasNoValue)
			{
				return false;
			}

			return option.Value.Equals(@value);
		}

        /// <summary>
        /// Determines inequality between <paramref name="option"/>'s Value and <paramref name="value"/>
        /// </summary>
        /// <param name="option"></param>
        /// <param name="value"></param>
        /// <returns></returns>
		public static bool operator !=(Option<T> option, T @value)
		{
			return !(option == value);
		}

        /// <summary>
        /// Determines equality between two optionals
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
		public static bool operator ==(Option<T> first, Option<T> second)
		{
			return first.Equals(second);
		}

        /// <summary>
        /// Determines inequality between two optionals
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
		public static bool operator !=(Option<T> first, Option<T> second)
		{
			return !(first == second);
		}

        /// <summary>
        /// Determines equality to <paramref name="other"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
		public override bool Equals(object other)
		{
            if (!(other is Option<T>))
            {
                return false;
            }

			var otherOptional = (Option<T>)other;

			return this.Equals(otherOptional);
		}

        /// <summary>
        /// Determines equality to <paramref name="other"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
		public bool Equals(Option<T> other)
		{
            if (HasNoValue && other.HasNoValue)
            {
                return true;
            }

            if (HasNoValue || other.HasNoValue)
            {
                return false;
            }

			return _value.Equals(other._value);
		}

        /// <summary>
        /// Returns the hash code for <see cref="Value"/>
        /// </summary>
        /// <returns></returns>
		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}

        /// <summary>
        /// Returns the string representation of <see cref="Value"/>
        /// </summary>
        /// <returns></returns>
		public override string ToString()
		{
			return _value.ToString();
		}

        /// <summary>
        /// Returns <see cref="Value"/> if value is set, otherwise <paramref name="defaultValue"/>
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
		public T Unwrap(T defaultValue = default(T))
		{
			return HasValue ? _value : defaultValue;
		}

        /// <summary>
        /// Performs comparison to <paramref name="other"/> based on the value of the objects
        /// and whether the value is set for each of the objects
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
		public int CompareTo(Option<T> other)
		{
            if (HasNoValue && other.HasNoValue)
            {
                return 0;
            }

            if (HasValue && other.HasNoValue)
            {
                return 1;
            }

            if (HasNoValue && other.HasValue)
            {
                return -1;
            }

			return Comparer<T>.Default.Compare(_value, other.Value);
		}

        /// <summary>
        /// Performs comparison to <paramref name="other"/> based on the value of the objects
        /// and whether the objects are not null
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(T other)
		{
            if (_value == null && other == null)
            {
                return 0;
            }

            if (_value != null && other == null)
            {
                return 1;
            }

            if (_value == null && other != null)
            {
                return -1;
            }

			return Comparer<T>.Default.Compare(_value, other);
		}

        /// <summary>
        /// Determines quality to <paramref name="other"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
		public bool Equals(T other)
		{
            if (HasNoValue && other == null)
            {
                return true;
            }

            if (HasNoValue || other == null)
            {
                return false;
            }

			return _value.Equals(other);
		}

        /// <summary>
        /// Returns type information for the generic type of this instance
        /// </summary>
        /// <returns></returns>
		public Type GetUnderlyingType()
		{
			return typeof(T);
		}

        /// <summary>
        /// Invokes either <paramref name= "Some" /> or <paramref name= "None" /> depending on the state of the optional
        /// </summary>
        /// <param name="Some"></param>
        /// <param name="None"></param>
        /// <returns></returns>
        public Unit Match(Action<T> Some, Action None)
        {
           return Match(Some.ToFunc(), None.ToFunc());
        }

        /// <summary>
        /// Invokes either <paramref name="Some"/> or <paramref name="None"/> depending on the state of the optional
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="Some"></param>
        /// <param name="None"></param>
        /// <returns></returns>
        public R Match<R>(Func<T, R> Some, Func<R> None)
        {
            return IsSome? Some(Value) : None();
        }

		/// <summary>
		/// Invokes <paramref name="someHandler"/> if Option is in the Some state, otherwise nothing
		/// happens.
		/// </summary>
		public Unit IfSome(Action<T> someHandler) => IfSome(someHandler.ToFunc());

		/// <summary>
		/// Invokes <paramref name="someHandler"/> if Option is in the Some state, otherwise nothing
		/// happens.
		/// </summary>
		public Unit IfSome(Func<T, Unit> someHandler) => IfSome<Unit>(someHandler);

		/// <summary>
		/// Invokes <paramref name="someHandler"/> if Option is in the Some state, otherwise nothing
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

        /// <summary>
        /// Invokes <paramref name="noneHandler"/> if Option is in empty state
        /// </summary>
        /// <param name="noneHandler"></param>
        /// <returns></returns>
        public Unit IfNone(Action noneHandler)
        {
            return IfNone(noneHandler.ToFunc());
        }

        /// <summary>
        /// Invokes <paramref name="noneHandler"/> 
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="noneHandler"></param>
        /// <returns></returns>
        public R IfNone<R>(Func<R> noneHandler)
        {
            return Match((arg) => { return default(R); }, noneHandler);
        }

        /// <summary>
        /// Converts <see cref="Value"/> to an <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <returns></returns>
		public IEnumerable<T> AsEnumerable()
		{
			if (IsSome)
			{
				yield return Value;
			}
		}

        /// <summary>
        /// Invokes <paramref name="selector"/> on each element in the <see cref="IEnumerable{T}"/> version of <see cref="Value"/>
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public IEnumerable<R> SelectMany<R>(Func<T, IEnumerable<R>> selector)
        {
            return this.AsEnumerable().SelectMany(m => selector(m));
        }
	}
}
