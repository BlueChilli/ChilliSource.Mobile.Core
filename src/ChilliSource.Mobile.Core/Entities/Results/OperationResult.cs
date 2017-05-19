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
	/// of a conceptual operation which is typically implemented as a method.
	/// Use this class as the return type of methods that can have multiple outcomes, 
	/// e.g. failed, successful etc.
	/// </summary>
	public class OperationResult : IOperationResult
	{
        /// <summary>
        /// Specifies whether the operation has executed successfully
        /// </summary>
		public bool IsSuccessful { get; set; }


        /// <summary>
        /// Specifies whether the <see cref="Exception"/> has been handled
        /// </summary>
        public bool IsHandled { get; set; }

        /// <summary>
        /// Specifies whether the operation was cancelled, usually as a result of a user action
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// A list of warning message strinfs that may have occured during the execution of the operation, 
        /// but that did not result in a failure of the operation
        /// </summary>
        public List<string> Warnings { get; set; }

        /// <summary>
        /// Specifies whether the operation failed, providing a <see cref="Message"/> and/or an <see cref="Exception"/>
        /// </summary>
        public bool IsFailure
		{
			get
			{
				return !IsSuccessful && !IsCancelled;
			}
		}

        /// <summary>
        /// Exception that may have been raised and captured during the execution of the Operation
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// The message holding additional information about the exeuction of the operation, 
        /// or explaining the reason for the failure if <see cref="IsFailure"/> is set to true
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Creates a new <see cref="OperationResult"/> instance with its state representing the successful execution of an operation
        /// </summary>
        /// <param name="message">optional message</param>
        /// <param name="warnings">optional list of warnings</param>
        /// <returns></returns>
		public static OperationResult AsSuccess(string message = "", List<string> warnings = null)
		{
			return new OperationResult()
			{
				IsSuccessful = true,
				Exception = null,
				Message = message,
				IsCancelled = false,
				Warnings = warnings
			};
		}

        /// <summary>
        /// Creates a new <see cref="OperationResult"/> instance with its state representing the fact that an operation was cancelled
        /// </summary>
        /// <returns></returns>
		public static OperationResult AsCancel()
		{
			return new OperationResult()
			{
				IsSuccessful = false,
				Exception = null,
				Message = null,
				IsCancelled = true
			};
		}

        /// <summary>
        /// Creates a new <see cref="OperationResult"/> instance with its state representing the the failure of an operation and the corresponding <paramref name="exception"/> 
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
		public static OperationResult AsFailure(Exception exception)
		{
			return new OperationResult()
			{
				IsSuccessful = false,
				Exception = exception,
				Message = exception.Message,
				IsCancelled = false,
			};
		}

        /// <summary>
        /// Creates a new <see cref="OperationResult"/> instance with its state representing the the failure of an operation and the corresponding <paramref name="errorMessage"/>
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
		public static OperationResult AsFailure(string errorMessage)
		{
			return new OperationResult()
			{
				IsSuccessful = false,
				Message = errorMessage,
				Exception = new Exception(errorMessage),
				IsCancelled = false
			};
		}

        /// <summary>
        /// Combines the specified <paramref name="operationResults"/> array by returning a single <see cref="OperationResult"/> according to the following these rules:
        /// 1. If all operations are successful, the result operation will represent the success state
        /// 2. If at least one operation has failed the result operation will represent the failed state and hold the concatenated error messages
        /// 3. Otherwise the result operation will represent the cancelled state
        /// </summary>
        /// <param name="operationResults"></param>
        /// <returns></returns>
		public static OperationResult Combine(params IOperationResult[] operationResults)
		{
			if (!Array.TrueForAll(operationResults, (obj) => obj.IsSuccessful))
			{                
				var failedOperations = Array.FindAll(operationResults, (obj) => obj.IsFailure);                
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
	/// Generic version of <see cref="T:ChilliSource.Mobile.Core.OperationResult"/> that also acts
	/// as a wrapper for a method's return type
	/// </summary>
	public class OperationResult<T> : OperationResult
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
        public static OperationResult<T> AsSuccess(T result, List<string> warnings = null)
		{
			return new OperationResult<T>()
			{
				Result = result,
				IsSuccessful = true,
				Message = null,
				Exception = null,
				IsCancelled = false,
				Warnings = warnings
			};
		}

        /// <summary>
        /// Creates a new <see cref="OperationResult"/> instance with its state representing the fact that an operation was cancelled
        /// </summary>
        /// <returns></returns>
        public new static OperationResult<T> AsCancel()
		{
			return new OperationResult<T>()
			{
				IsSuccessful = false,
				Message = null,
				Exception = null,
				IsCancelled = true
			};
		}

        /// <summary>
        /// Creates a new <see cref="OperationResult"/> instance with its state representing the the failure of an operation and the corresponding <paramref name="exception"/> 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="result"></param>
        /// <returns></returns>
		public static OperationResult<T> AsFailure(Exception exception, T result = default(T))
		{
			return new OperationResult<T>()
			{
				IsSuccessful = false,
				Exception = exception,
				Message = exception.Message,
				IsCancelled = false,
				Result = result,
			};
		}

        /// <summary>
        ///  Creates a new <see cref="OperationResult"/> instance with its state representing the the failure of an operation and the corresponding <paramref name="errorMessage"/>
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="result"></param>
        /// <returns></returns>
		public static OperationResult<T> AsFailure(string errorMessage, T result = default(T))
		{
			return new OperationResult<T>()
			{
				IsSuccessful = false,
				Message = errorMessage,
				Exception = new Exception(errorMessage),
				IsCancelled = false,
				Result = result,
			};
		}
	}

}
