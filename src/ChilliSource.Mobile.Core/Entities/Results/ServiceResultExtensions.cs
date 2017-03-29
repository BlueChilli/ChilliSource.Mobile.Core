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
	/// <summary>
	/// Functional extensions for handling the various outcome 
	/// states of <see cref="T:ChilliSource.Mobile.Core.ServiceResult"/>
	/// </summary>
	public static class ServiceResultExtensions
	{
		public static ServiceResult OnSuccess(this ServiceResult result, Func<ServiceResult, ServiceResult> action)
		{
			return result.IsSuccessful ? action(result) : result;
		}

		public static ServiceResult OnFailure(this ServiceResult result, Action<ServiceResult> action)
		{
			if (result.IsFailure)
			{
				action(result);
			}

			return result;
		}

		public static ServiceResult OnCancelled(this ServiceResult result, Action<ServiceResult> action)
		{
			if (result.IsCancelled)
			{
				action(result);
			}

			return result;
		}

		public static ServiceResult Always(this ServiceResult result, Action<ServiceResult> action)
		{
			action(result);
			return result;
		}

		public static ServiceResult<T> OnSuccess<T>(this ServiceResult<T> result, Func<ServiceResult<T>, ServiceResult<T>> action)
		{
			return result.IsSuccessful ? action(result) : result;
		}

		public static ServiceResult<T> OnFailure<T>(this ServiceResult<T> result, Action<ServiceResult<T>> action)
		{
			if (result.IsFailure)
			{
				action(result);
			}

			return result;
		}

		public static ServiceResult<T> OnCancelled<T>(this ServiceResult<T> result, Action<ServiceResult<T>> action)
		{
			if (result.IsCancelled)
			{
				action(result);
			}

			return result;
		}

		public static ServiceResult<T> Always<T>(this ServiceResult<T> result, Action<ServiceResult<T>> action)
		{
			action(result);
			return result;
		}
	}
}
