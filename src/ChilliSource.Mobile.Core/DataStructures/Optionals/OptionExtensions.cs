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
	/// Functional query extensions for <see cref="T:ChilliSource.Mobile.Core.Optional"/>
	/// </summary>
	public static class OptionExtenssions
	{
		public static Option<T> Where<T>(this Option<T> optT, Func<T, bool> predicate)
		{
			return optT.Match(
			   (t) => predicate(t) ? optT : Option<T>.None,
			   () => Option<T>.None);
		}

		public static Option<R> SelectMany<T, R>(this Option<T> optT, Func<T, Option<R>> f)
		{
			return optT.Match((t) => f(t), () => Option<R>.None);
		}

		public static Option<R> Select<T, R>(this Option<T> optT, Func<T, R> f)
		{
			return optT.Match((t) => Option<R>.Some(f(t)), () => Option<R>.None);
		}

		public static Option<Unit> ForEach<T>(this Option<T> @this, Action<T> action)
		{
			return @this.Select(action.ToFunc());
		}

		public static async Task<Option<R>> SelectAsync<T, R>(this Option<T> self, Func<T, Task<R>> map)
		{
			return self.IsSome
				? Option<R>.Some(await map(self.Value))
				: Option<R>.None;
		}

		public static async Task<Option<R>> SelectAsync<T, R>(this Task<Option<T>> self, Func<T, Task<R>> map)
		{
			var val = await self;
			return val.IsSome
				? Option<R>.Some(await map(val.Value))
				: Option<R>.None;
		}

		public static async Task<Option<R>> SelectAsync<T, R>(this Task<Option<T>> self, Func<T, R> map)
		{
			var val = await self;
			return val.IsSome
				? Option<R>.Some(map(val.Value))
				: Option<R>.None;
		}

		public static async Task<Option<R>> SelectAsync<T, R>(this Option<Task<T>> self, Func<T, R> map)
		{
			return self.IsSome
				? Option<R>.Some(map(await self.Value))
				: Option<R>.None;
		}

		public static async Task<Option<R>> MapAsync<T, R>(this Option<Task<T>> self, Func<T, Task<R>> map)
		{
			return self.IsSome
				? Option<R>.Some(await map(await self.Value))
				: Option<R>.None;
		}

		public static async Task<Option<R>> SelectManyAsync<T, R>(this Option<T> self, Func<T, Task<Option<R>>> bind)
		{
			return self.IsSome
				? await bind(self.Value)
				: Option<R>.None;
		}

		public static async Task<Option<R>> SelectManyAsync<T, R>(this Task<Option<T>> self, Func<T, Task<Option<R>>> bind)
		{
			var val = await self;
			return val.IsSome
				? await bind(val.Value)
				: Option<R>.None;
		}

		public static async Task<Option<R>> SelectManyAsync<T, R>(this Task<Option<T>> self, Func<T, Option<R>> bind)
		{
			var val = await self;
			return val.IsSome
				? bind(val.Value)
				: Option<R>.None;
		}

		public static async Task<Option<R>> SelectManyAsync<T, R>(this Option<Task<T>> self, Func<T, Option<R>> bind)
		{
			return self.IsSome
				? bind(await self.Value)
				: Option<R>.None;
		}

		public static async Task<Option<R>> SelectManyAsync<T, R>(this Option<Task<T>> self, Func<T, Task<Option<R>>> bind)
		{
			return self.IsSome
				? await bind(await self.Value)
				: Option<R>.None;
		}

		public static async Task<Unit> ForEachAsync<T>(this Task<Option<T>> self, Action<T> action)
		{
			var val = await self;
			if (val.IsSome)
			{
				action(val.Value);
			}
			return Unit.Default;
		}

		public static async Task<Unit> ForEachAsync<T>(this Option<Task<T>> self, Action<T> action)
		{
			if (self.IsSome)
			{
				action(await self.Value);
			}
			return Unit.Default;
		}

	}
}
