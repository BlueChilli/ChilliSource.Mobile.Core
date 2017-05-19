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
	/// Provides a functional approach for handling the various outcome 
	/// states of <see cref="T:ChilliSource.Mobile.Core.OperationResult"/>
	/// </summary>
	public static class OperationResultExtensions
	{
        /// <summary>
        /// Executes <paramref name="action"/> if the <paramref name="result"/> is successful
        /// </summary>
        /// <param name="result"></param>
        /// <param name="action"></param>
        /// <returns>The <paramref name="result"/></returns>
		public static OperationResult OnSuccess(this OperationResult result, Func<OperationResult> action)
		{
			return result.IsSuccessful ? action() : result;
		}

        /// <summary>
        /// Executes <paramref name="action"/> if the <paramref name="result"/> has failed
        /// </summary>
        /// <param name="result"></param>
        /// <param name="action"></param>
        /// <returns>The <paramref name="result"/></returns>
		public static OperationResult OnFailure(this OperationResult result, Action action)
		{
			if (result.IsFailure)
			{
				action();
			}

			return result;
		}

        /// <summary>
        /// Executes <paramref name="action"/> if the <paramref name="result"/> was cancelled
        /// </summary>
        /// <param name="result"></param>
        /// <param name="action"></param>
        /// <returns>The <paramref name="result"/></returns>
		public static OperationResult OnCancelled(this OperationResult result, Action action)
		{
			if (result.IsCancelled)
			{
				action();
			}

			return result;
		}

        /// <summary>
        /// Executes <paramref name="action"/> once the result has completed, regardless of its outcome
        /// </summary>
        /// <param name="result"></param>
        /// <param name="action"></param>
        /// <returns>The <paramref name="result"/></returns>
		public static OperationResult Always(this OperationResult result, Action action)
		{
			action();
			return result;
		}

        /// <summary>
        /// Executes <paramref name="action"/> if the <paramref name="result"/> is successful
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="action"></param>
        /// <returns>The <paramref name="result"/></returns>
        public static OperationResult<T> OnSuccess<T>(this OperationResult<T> result, Func<OperationResult<T>, OperationResult<T>> action)
		{
			return result.IsSuccessful ? action(result) : result;
		}

        /// <summary>
        /// Executes <paramref name="action"/> if the <paramref name="result"/> has failed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="action"></param>
        /// <returns>The <paramref name="result"/></returns>
		public static OperationResult<T> OnFailure<T>(this OperationResult<T> result, Action action)
		{
			if (result.IsFailure)
			{
				action();
			}

			return result;
		}

        /// <summary>
        /// Executes <paramref name="action"/> if the <paramref name="result"/> was cancelled
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="action"></param>
        /// <returns>The <paramref name="result"/></returns>
        public static OperationResult<T> OnCancelled<T>(this OperationResult<T> result, Action action)
		{
			if (result.IsCancelled)
			{
				action();
			}

			return result;
		}

        /// <summary>
        /// Executes <paramref name="action"/> once the result has completed, regardless of its outcome
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="action"></param>
        /// <returns>The <paramref name="result"/></returns>
        public static OperationResult<T> Always<T>(this OperationResult<T> result, Action action)
		{
			action();
			return result;
		}
	}

}
