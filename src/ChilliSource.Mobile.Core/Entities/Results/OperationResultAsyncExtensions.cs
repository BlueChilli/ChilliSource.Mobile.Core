#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

using System;
using System.Threading.Tasks;

namespace ChilliSource.Mobile.Core
{
	/// <summary>
	/// Functional async extensions for handling the various outcome 
	/// states of <see cref="T:ChilliSource.Mobile.Core.OperationResult"/>
	/// </summary>
	public static class OperationResultAsyncExtensions
	{
		public static async Task<OperationResult> OnSuccessAsync(this Task<OperationResult> resultTask, Func<Task<OperationResult>> action)
		{
			var result = await resultTask;

			return result.IsSuccessful ? await action() : result;
		}

		public static async Task<OperationResult> OnFailureAsync(this Task<OperationResult> resultTask, Func<Task> action)
		{
			var result = await resultTask;

			if (result.IsFailure)
			{
				await action();
			}

			return result;
		}

		public static async Task<OperationResult> OnCancelledAsync(this Task<OperationResult> resultTask, Func<Task> action)
		{
			var result = await resultTask;

			if (result.IsCancelled)
			{
				await action();
			}

			return result;
		}


		public static async Task<OperationResult> AlwaysAsync(this Task<OperationResult> resultTask, Func<Task> action)
		{
			var result = await resultTask;
			await action();
			return result;
		}

		public static async Task<OperationResult<T>> OnSuccessAsync<T>(this Task<OperationResult<T>> resultTask, Func<OperationResult<T>, Task<OperationResult<T>>> action)
		{
			var result = await resultTask;
			return result.IsSuccessful ? await action(result) : result;
		}

		public static async Task<OperationResult<T>> OnFailureAsync<T>(this Task<OperationResult<T>> resultTask, Func<Task> action)
		{
			var result = await resultTask;
			if (result.IsFailure)
			{
				await action();
			}

			return result;
		}

		public static async Task<OperationResult<T>> OnCancelledAsync<T>(this Task<OperationResult<T>> resultTask, Func<Task> action)
		{
			var result = await resultTask;
			if (result.IsCancelled)
			{
				await action();
			}

			return result;
		}

		public static async Task<OperationResult<T>> AlwaysAsync<T>(this Task<OperationResult<T>> resultTask, Func<Task> action)
		{
			var result = await resultTask;
			await action();
			return result;
		}


	}
}
