#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChilliSource.Mobile.Core
{

	/// <summary>
	/// Represents all the different possible outcomes and any relevant error descriptors
	/// of a web service operation. Use this class as the return type of methods that perform
	/// web API calls.
	/// Based on <see cref="T:ChilliSource.Mobile.Core.OperationResult"/> 
	/// </summary>
	public class ServiceResult : OperationResult, IServiceResult
	{
        /// <summary>
        /// Represents the HTTP status code returned once the operation has completed
        /// </summary>
		public int StatusCode { get; set; }

        /// <summary>
        /// Creates a new <see cref="OperationResult"/> instance with its state representing the successful execution of an operation
        /// </summary>
        /// <param name="message">optional message</param>
        /// <param name="warnings">optional list of warnings</param>
        /// <returns></returns>
		public static new ServiceResult AsSuccess(string message = "", List<string> warnings = null)
		{
			return new ServiceResult()
			{
				IsSuccessful = true,
				Exception = null,
				Message = message,
				IsCancelled = false,
				StatusCode = 200,
                Warnings = warnings
            };
		}

        /// <summary>
        /// Creates a new <see cref="OperationResult"/> instance with its state representing the fact that an operation was cancelled
        /// </summary>
        /// <returns></returns>
        public static new ServiceResult AsCancel()
		{
			return new ServiceResult()
			{
				IsSuccessful = false,
				Exception = null,
				IsCancelled = true
			};
		}

        /// <summary>
        /// Creates a new <see cref="OperationResult"/> instance with its state representing the the failure of an operation and the corresponding <paramref name="exception"/> 
        /// </summary>
        /// <param name="exception">The exception</param>
        /// <param name="statusCode">The Http status code. Default is 500</param>
        /// <returns></returns>
        public static ServiceResult AsFailure(Exception exception, int statusCode = 500)
		{
			return new ServiceResult()
			{
				IsSuccessful = false,
				Exception = exception,
				Message = exception.Message,
				IsCancelled = false,
				StatusCode = statusCode
			};
		}

        /// <summary>
        /// Creates a new <see cref="OperationResult"/> instance with its state representing the the failure of an operation and the corresponding <paramref name="errorMessage"/>
        /// </summary>
        /// <param name="errorMessage">The error message</param>
        /// <param name="statusCode">The Http status code. Default is 500</param>
        /// <returns></returns>
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

        /// <summary>
        /// Combines the specified <paramref name="serviceResults"/> array by returning a single <see cref="OperationResult"/> according to the following these rules:
        /// 1. If all operations are successful, the result operation will represent the success state
        /// 2. If at least one operation has failed the result operation will represent the failed state and hold the concatenated error messages
        /// 3. Otherwise the result operation will represent the cancelled state
        /// </summary>
        /// <param name="serviceResults"></param>
        /// <returns></returns>
        public static ServiceResult Combine(params IServiceResult[] serviceResults)
		{
			if (!Array.TrueForAll(serviceResults, (obj) => obj.IsSuccessful))
			{
                var failedOperations = Array.FindAll(serviceResults, (obj) => obj.IsFailure);
                var builder = new StringBuilder();

                if (failedOperations.Length > 0)
                {

                    foreach (var failedOperation in failedOperations)
                    {
                        if (failedOperation.Exception != null)
                        {
                            builder.AppendLine(failedOperation.Exception.ToString());
                        }
                        else
                        {
                            builder.AppendLine(failedOperation.Message);
                        }
                    }
                    return AsFailure(builder.ToString());
                }
                else
                {
                    return AsCancel();
                }
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
        /// <summary>
        /// A generic object that can be set to any value to hold the result of an operation
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// Creates a new <see cref="OperationResult"/> instance with its state representing the successful execution of an operation
        /// </summary>
        /// <param name="result"></param>
        /// <param name="warnings"></param>
        /// <returns></returns>
        public static ServiceResult<T> AsSuccess(T result, List<string> warnings = null)
		{
			return new ServiceResult<T>()
			{
				Result = result,
				IsSuccessful = true,
				Exception = null,
				IsCancelled = false,
				StatusCode = 200,
                Warnings = warnings
            };
		}

        /// <summary>
        /// Creates a new <see cref="OperationResult"/> instance with its state representing the fact that an operation was cancelled
        /// </summary>
        /// <returns></returns>
        public new static ServiceResult<T> AsCancel()
		{
			return new ServiceResult<T>()
			{
				IsSuccessful = false,
				Exception = null,
				IsCancelled = true
			};
		}

        /// <summary>
        /// Creates a new <see cref="OperationResult"/> instance with its state representing the the failure of an operation and the corresponding <paramref name="exception"/> 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="result"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>    
        public static ServiceResult<T> AsFailure(Exception exception, T result = default(T), int statusCode = 500)
		{
			return new ServiceResult<T>()
			{
				IsSuccessful = false,
				Exception = exception,
				Message = exception.Message,
				IsCancelled = false,
				Result = result,
				StatusCode = statusCode
			};
		}

        /// <summary>
        ///  Creates a new <see cref="OperationResult"/> instance with its state representing the the failure of an operation and the corresponding <paramref name="errorMessage"/>
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="result"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
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


