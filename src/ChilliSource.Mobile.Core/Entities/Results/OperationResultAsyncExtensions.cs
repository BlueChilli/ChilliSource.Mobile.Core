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
    /// states of <see cref="T:ChilliSource.Mobile.Core.OperationResult"/>
    /// </summary>
    public static class OperationResultAsyncExtensions
	{
        /// <summary>
        /// Provides a mechanism to respond asynchronously to the successful completion of an operation
        /// </summary>
        /// <param name="operationTask">The task representing the async execution of the operation</param>
        /// <param name="action">The action to perform if the operation is successful</param>
        /// <returns></returns>
		public static async Task<OperationResult> OnSuccessAsync(this Task<OperationResult> operationTask, Func<Task<OperationResult>> action)
		{
			var result = await operationTask;

			return result.IsSuccessful ? await action() : result;
		}

        /// <summary>
        /// Provides a mechanism to respond asynchronously to the failed execution of an operation
        /// </summary>
        /// <param name="operationTask">The task representing the async execution of the operation</param>
        /// <param name="action">The action to perform if the operation has failed</param>
        /// <returns></returns>
        public static async Task<OperationResult> OnFailureAsync(this Task<OperationResult> operationTask, Func<Task> action)
		{
			var result = await operationTask;

			if (result.IsFailure)
			{
				await action();
			}

			return result;
		}

        /// <summary>
        /// Provides a mechanism to respond asynchronously to the cancellation of an operation
        /// </summary>
        /// <param name="operationTask">The task representing the async execution of the operation</param>
        /// <param name="action">The action to perform if the operation is cancelled</param>
        /// <returns></returns>
		public static async Task<OperationResult> OnCancelledAsync(this Task<OperationResult> operationTask, Func<Task> action)
		{
			var result = await operationTask;

			if (result.IsCancelled)
			{
				await action();
			}

			return result;
		}

        /// <summary>
        /// Provides a mechanism to respond asynchronously to the completion of an operation, regardless what the outcome of the operation is
        /// </summary>
        /// <param name="operationTask">The task representing the async execution of the operation</param>
        /// <param name="action">The action to perform on completion</param>
        /// <returns></returns>
		public static async Task<OperationResult> AlwaysAsync(this Task<OperationResult> operationTask, Func<Task> action)
		{
			var result = await operationTask;
			await action();
			return result;
		}

        /// <summary>
        ///  Provides a mechanism to respond asynchronously to the successful completion of an operation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operationTask">The task representing the async execution of the operation</param>
        /// <param name="action">The action to perform if the operation is successful</param>
        /// <returns></returns>
        public static async Task<OperationResult<T>> OnSuccessAsync<T>(this Task<OperationResult<T>> operationTask, Func<OperationResult<T>, Task<OperationResult<T>>> action)
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
		public static async Task<OperationResult<T>> OnFailureAsync<T>(this Task<OperationResult<T>> operationTask, Func<Task> action)
		{
			var result = await operationTask;
			if (result.IsFailure)
			{
				await action();
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
        public static async Task<OperationResult<T>> OnCancelledAsync<T>(this Task<OperationResult<T>> operationTask, Func<Task> action)
		{
			var result = await operationTask;
			if (result.IsCancelled)
			{
				await action();
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
		public static async Task<OperationResult<T>> AlwaysAsync<T>(this Task<OperationResult<T>> operationTask, Func<Task> action)
		{
			var result = await operationTask;
			await action();
			return result;
		}

        /// <summary>
        /// Returns a <see cref="OperationResult"/> instance representing the 
        /// execution state of the provided <paramref name="task"/>
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static async Task<OperationResult> WaitForResult(this Task task)
        {
            try
            {
                await task;
                return OperationResult.AsSuccess();
            }
            catch (Exception ex)
            {
                return OperationResult.AsFailure(ex);
            }
        }

        /// <summary>
        /// Returns a <see cref="OperationResult"/> instance representing the 
        /// execution state of the provided <paramref name="task"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="task"></param>
        /// <returns></returns>
		public static async Task<OperationResult<T>> WaitForResult<T>(this Task<T> task)
        {
            try
            {
                var result = await task;
                return OperationResult<T>.AsSuccess(result);
            }
            catch (Exception ex)
            {
                return OperationResult<T>.AsFailure(ex);
            }
        }
    }
}
