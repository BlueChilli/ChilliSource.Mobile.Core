#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

using System;
using System.Text;
using System.Threading.Tasks;

namespace ChilliSource.Core
{

	/// <summary>
	/// Represents all the different possible outcomes and any relevant error descriptors
	/// of a web service operation. Use this class as the return type of methods that perform
	/// web API calls.
	/// Based on <see cref="T:ChilliSource.Mobile.Core.OperationResult"/> 
	/// </summary>
	public class ServiceResult : OperationResult, IServiceResult
	{
		public int StatusCode { get; set; }

		public static ServiceResult AsSuccess(string message = "")
		{
			return new ServiceResult()
			{
				IsSuccessful = true,
				Exception = null,
				Message = message,
				IsCancelled = false,
				StatusCode = 200
			};
		}

		public static new ServiceResult AsCancel()
		{
			return new ServiceResult()
			{
				IsSuccessful = false,
				Exception = null,
				IsCancelled = true
			};
		}

		public static ServiceResult AsFailure(Exception ex, int statusCode = 500)
		{
			return new ServiceResult()
			{
				IsSuccessful = false,
				Exception = ex,
				Message = ex.Message,
				IsCancelled = false,
				StatusCode = statusCode
			};
		}

		public static ServiceResult AsFailure(string errorMessage, int statusCode = 500)
		{
			return new ServiceResult()
			{
				IsSuccessful = false,
				Exception = new Exception(errorMessage),
				Message = errorMessage,
				IsCancelled = false,
				StatusCode = statusCode
			};
		}

		public static ServiceResult Combine(params IServiceResult[] results)
		{
			if (!Array.TrueForAll(results, (obj) => obj.IsSuccessful))
			{
				var failed = Array.FindAll(results, (obj) => obj.IsFailure);
				var builder = new StringBuilder();
				foreach (var failedR in failed)
				{
					if (failedR.Exception != null)
					{
						builder.AppendLine(failedR.Exception.ToString());
					}
					else
					{
						builder.AppendLine(failedR.Message);
					}
				}
				return AsFailure(builder.ToString());
			}

			return AsSuccess();
		}
	}

	/// <summary>
	/// Generic version of <see cref="T:ChilliSource.Mobile.Core.ServiceResult"/> that also acts
	/// as a wrapper for a method's return type
	/// </summary>
	public class ServiceResult<T> : ServiceResult
	{
		public T Result { get; set; }

		public static ServiceResult<T> AsSuccess(T result)
		{
			return new ServiceResult<T>()
			{
				Result = result,
				IsSuccessful = true,
				Exception = null,
				IsCancelled = false,
				StatusCode = 200
			};
		}

		public new static ServiceResult<T> AsCancel()
		{
			return new ServiceResult<T>()
			{
				IsSuccessful = false,
				Exception = null,
				IsCancelled = true
			};
		}

		public static ServiceResult<T> AsFailure(Exception ex, T result = default(T), int statusCode = 500)
		{
			return new ServiceResult<T>()
			{
				IsSuccessful = false,
				Exception = ex,
				Message = ex.Message,
				IsCancelled = false,
				Result = result,
				StatusCode = statusCode
			};
		}

		public static ServiceResult<T> AsFailure(string errorMessage, T result = default(T), int statusCode = 500)
		{
			return new ServiceResult<T>()
			{
				IsSuccessful = false,
				Exception = new Exception(errorMessage),
				Message = errorMessage,
				IsCancelled = false,
				Result = result,
				StatusCode = statusCode
			};
		}
	}
}

