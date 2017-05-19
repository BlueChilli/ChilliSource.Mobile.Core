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
    /// Provides an async functional programming approach for handling the various outcome 
    /// states of <see cref="T:ChilliSource.Mobile.Core.ServiceResult"/>
    /// </summary>
    public static class ServiceResultAsyncExtensions
	{

        /// <summary>
        /// Provides a mechanism to respond asynchronously to the successful completion of an operation
        /// </summary>
        /// <param name="operationTask">The task representing the async execution of the operation</param>
        /// <param name="action">The action to perform if the operation is successful</param>
        /// <returns></returns>
        public static async Task<ServiceResult> OnSuccessAsync(this Task<ServiceResult> operationTask, Func<ServiceResult, Task<ServiceResult>> action)
		{
			var result = await operationTask;
			return result.IsSuccessful ? await action(result) : result;
		}

        /// <summary>
        /// Provides a mechanism to respond asynchronously to the failed execution of an operation
        /// </summary>
        /// <param name="operationTask">The task representing the async execution of the operation</param>
        /// <param name="action">The action to perform if the operation has failed</param>
        /// <returns></returns>
        public static async Task<ServiceResult> OnFailureAsync(this Task<ServiceResult> operationTask, Func<ServiceResult, Task> action)
		{
			var result = await operationTask;
			if (result.IsFailure)
			{
				await action(result);
			}

			return result;
		}

        /// <summary>
        /// Provides a mechanism to respond asynchronously to the cancellation of an operation
        /// </summary>
        /// <param name="operationTask">The task representing the async execution of the operation</param>
        /// <param name="action">The action to perform if the operation is cancelled</param>
        /// <returns></returns>
		public static async Task<ServiceResult> OnCancelledAsync(this Task<ServiceResult> operationTask, Func<ServiceResult, Task> action)
		{
			var result = await operationTask;
			if (result.IsCancelled)
			{
				await action(result);
			}

			return result;
		}

        /// <summary>
        /// Provides a mechanism to respond asynchronously to the completion of an operation, regardless what the outcome of the operation is
        /// </summary>
        /// <param name="operationTask">The task representing the async execution of the operation</param>
        /// <param name="action">The action to perform on completion</param>
        /// <returns></returns>
        public static async Task<ServiceResult> AlwaysAsync(this Task<ServiceResult> operationTask, Func<ServiceResult, Task> action)
		{
			var result = await operationTask;
			await action(result);
			return result;
		}

        /// <summary>
        ///  Provides a mechanism to respond asynchronously to the successful completion of an operation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operationTask">The task representing the async execution of the operation</param>
        /// <param name="action">The action to perform if the operation is successful</param>
        /// <returns></returns>
        public static async Task<ServiceResult<T>> OnSuccessAsync<T>(this Task<ServiceResult<T>> operationTask, Func<ServiceResult<T>, Task<ServiceResult<T>>> action)
		{
			var result = await operationTask;
			return result.IsSuccessful ? await action(result) : result;
		}

        /// <summary>
        /// Provides a mechanism to respond asynchronously to the failed execution of an operation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operationTask">The task representing the async execution of the operation</param>
        /// <param name="action">The action to perform if the operation has failed</param>
        /// <returns></returns>
		public static async Task<ServiceResult<T>> OnFailureAsync<T>(this Task<ServiceResult<T>> operationTask, Func<ServiceResult<T>, Task> action)
		{
			var result = await operationTask;

			if (result.IsFailure)
			{
				await action(result);
			}

			return result;
		}

        /// <summary>
        ///  Provides a mechanism to respond asynchronously to the cancellation of an operation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operationTask">The task representing the async execution of the operation</param>
        /// <param name="action">The action to perform if the operation is cancelled</param>
        /// <returns></returns>
        public static async Task<ServiceResult<T>> OnCancelledAsync<T>(this Task<ServiceResult<T>> operationTask, Func<ServiceResult<T>, Task> action)
		{
			var result = await operationTask;

			if (result.IsCancelled)
			{
				await action(result);
			}

			return result;
		}

        /// <summary>
        /// Provides a mechanism to respond asynchronously to the completion of an operation, regardless what the outcome of the operation is
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operationTask">The task representing the async execution of the operation</param>
        /// <param name="action">The action to perform on completion</param>
        /// <returns></returns>
        public static async Task<ServiceResult<T>> AlwaysAsync<T>(this Task<ServiceResult<T>> operationTask, Func<ServiceResult<T>, Task> action)
		{
			var result = await operationTask;
			await action(result);
			return result;
		}

  //      /// <summary>
  //      /// Returns a <see cref="ServiceResult"/> instance representing the 
  //      /// execution state of the provided <paramref name="task"/>
  //      /// </summary>
  //      /// <param name="task"></param>
  //      /// <returns></returns>
		//public static async Task<ServiceResult> WaitForResult(this Task task)
		//{
		//	try
		//	{
		//		await task;
		//		return ServiceResult.AsSuccess();
		//	}
		//	catch (Exception ex)
		//	{
		//		return ServiceResult.AsFailure(ex);
		//	}
		//}

  //      /// <summary>
  //      /// Returns a <see cref="ServiceResult"/> instance representing the 
  //      /// execution state of the provided <paramref name="task"/>
  //      /// </summary>
  //      /// <typeparam name="T"></typeparam>
  //      /// <param name="task"></param>
  //      /// <returns></returns>
		//public static async Task<ServiceResult<T>> WaitForResult<T>(this Task<T> task)
		//{
		//	try
		//	{
		//		var result = await task;
		//		return ServiceResult<T>.AsSuccess(result);
		//	}
		//	catch (Exception ex)
		//	{
		//		return ServiceResult<T>.AsFailure(ex);
		//	}
		//}
	}
}
