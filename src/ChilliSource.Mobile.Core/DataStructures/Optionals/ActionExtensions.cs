#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

using System;
namespace ChilliSource.Core
{
	public static class ActionExtensions
	{
		public static Func<Unit> ToFunc(this Action action)
		{
			return () =>
			{
				action();
				return Unit.Default;
			};
		}

		public static Func<T, Unit> ToFunc<T>(this Action<T> action)
		{
			return t =>
			{
				action(t);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, Unit> ToFunc<T1, T2>(this Action<T1, T2> action)
		{
			return (arg1, arg2) =>
			{
				action(arg1, arg2);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, T3, Unit> ToFunc<T1, T2, T3>(this Action<T1, T2, T3> action)
		{
			return (arg1, arg2, arg3) =>
			{
				action(arg1, arg2, arg3);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, T3, T4, Unit> ToFunc<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
		{
			return (arg1, arg2, arg3, arg4) =>
			{
				action(arg1, arg2, arg3, arg4);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, T3, T4, T5, Unit> ToFunc<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action)
		{
			return (arg1, arg2, arg3, arg4, arg5) =>
			{
				action(arg1, arg2, arg3, arg4, arg5);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, T3, T4, T5, T6, Unit> ToFunc<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action)
		{
			return (arg1, arg2, arg3, arg4, arg5, arg6) =>
			{
				action(arg1, arg2, arg3, arg4, arg5, arg6);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action)
		{
			return (arg1, arg2, arg3, arg4, arg5, arg6, arg7) =>
			{
				action(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
		{
			return (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) =>
			{
				action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
			this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
		{
			return (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9) =>
			{
				action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
			this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
		{
			return (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) =>
			{
				action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
			this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
		{
			return (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) =>
			{
				action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
			this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
		{
			return (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12) =>
			{
				action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
			this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
		{
			return (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13) =>
			{
				action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
			this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
		{
			return (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14) =>
			{
				action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
			this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
		{
			return (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) =>
			{
				action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
				return Unit.Default;
			};
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
			this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
		{
			return (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16) =>
			{
				action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
				return Unit.Default;
			};
		}

	}
}
