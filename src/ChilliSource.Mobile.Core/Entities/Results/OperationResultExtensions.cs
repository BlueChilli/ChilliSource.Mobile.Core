#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

using System;
namespace ChilliSource.Mobile.Core
{
	/// <summary>
	/// Functional extensions for handling the various outcome 
	/// states of <see cref="T:ChilliSource.Mobile.Core.OperationResult"/>
	/// </summary>
	public static class OperationResultExtensions
	{
		public static OperationResult OnSuccess(this OperationResult result, Func<OperationResult> action)
		{
			return result.IsSuccessful ? action() : result;
		}

		public static OperationResult OnFailure(this OperationResult result, Action action)
		{
			if (result.IsFailure)
			{
				action();
			}

			return result;
		}

		public static OperationResult OnCancelled(this OperationResult result, Action action)
		{
			if (result.IsCancelled)
			{
				action();
			}

			return result;
		}


		public static OperationResult Always(this OperationResult result, Action action)
		{
			action();
			return result;
		}

		public static OperationResult<T> OnSuccess<T>(this OperationResult<T> result, Func<OperationResult<T>, OperationResult<T>> action)
		{
			return result.IsSuccessful ? action(result) : result;
		}

		public static OperationResult<T> OnFailure<T>(this OperationResult<T> result, Action action)
		{
			if (result.IsFailure)
			{
				action();
			}

			return result;
		}

		public static OperationResult<T> OnCancelled<T>(this OperationResult<T> result, Action action)
		{
			if (result.IsCancelled)
			{
				action();
			}

			return result;
		}

		public static OperationResult<T> Always<T>(this OperationResult<T> result, Action action)
		{
			action();
			return result;
		}
	}

}
