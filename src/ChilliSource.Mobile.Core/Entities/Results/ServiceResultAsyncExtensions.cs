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
	/// states of <see cref="T:ChilliSource.Mobile.Core.ServiceResult"/>
	/// </summary>
	public static class ServiceResultAsyncExtensions
	{
		public static async Task<ServiceResult> OnSuccessAsync(this Task<ServiceResult> resultTask, Func<ServiceResult, Task<ServiceResult>> action)
		{
			var result = await resultTask;
			return result.IsSuccessful ? await action(result) : result;
		}

		public static async Task<ServiceResult> OnFailureAsync(this Task<ServiceResult> resultTask, Func<ServiceResult, Task> action)
		{
			var result = await resultTask;
			if (result.IsFailure)
			{
				await action(result);
			}

			return result;
		}

		public static async Task<ServiceResult> OnCancelledAsync(this Task<ServiceResult> resultTask, Func<ServiceResult, Task> action)
		{
			var result = await resultTask;
			if (result.IsCancelled)
			{
				await action(result);
			}

			return result;
		}


		public static async Task<ServiceResult> AlwaysAsync(this Task<ServiceResult> resultTask, Func<ServiceResult, Task> action)
		{
			var result = await resultTask;
			await action(result);
			return result;
		}


		public static async Task<ServiceResult<T>> OnSuccessAsync<T>(this Task<ServiceResult<T>> resultTask, Func<ServiceResult<T>, Task<ServiceResult<T>>> action)
		{
			var result = await resultTask;
			return result.IsSuccessful ? await action(result) : result;
		}

		public static async Task<ServiceResult<T>> OnFailureAsync<T>(this Task<ServiceResult<T>> resultTask, Func<ServiceResult<T>, Task> action)
		{
			var result = await resultTask;

			if (result.IsFailure)
			{
				await action(result);
			}

			return result;
		}

		public static async Task<ServiceResult<T>> OnCancelledAsync<T>(this Task<ServiceResult<T>> resultTask, Func<ServiceResult<T>, Task> action)
		{
			var result = await resultTask;

			if (result.IsCancelled)
			{
				await action(result);
			}

			return result;
		}

		public static async Task<ServiceResult<T>> AlwaysAsync<T>(this Task<ServiceResult<T>> resultTask, Func<ServiceResult<T>, Task> action)
		{
			var result = await resultTask;
			await action(result);
			return result;
		}

		public static async Task<ServiceResult> WaitForResult(this Task task)
		{
			try
			{
				await task;
				return ServiceResult.AsSuccess();
			}
			catch (Exception ex)
			{
				return ServiceResult.AsFailure(ex);
			}
		}

		public static async Task<ServiceResult<T>> WaitForResult<T>(this Task<T> task)
		{
			try
			{
				var r = await task;
				return ServiceResult<T>.AsSuccess(r);
			}
			catch (Exception ex)
			{
				return ServiceResult<T>.AsFailure(ex);
			}
		}
	}
}
