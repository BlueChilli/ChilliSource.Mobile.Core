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

namespace ChilliSource.Core
{

	/// <summary>
	/// Represents all the different possible outcomes and any relevant error descriptors
	/// of a conceptual operation which is typically implemented as a method.
	/// Use this class as the return type of methods that can have multiple outcomes, 
	/// e.g. failed, successful etc.
	/// </summary>
	public class OperationResult : IOperationResult
	{
		public bool IsSuccessful { get; set; }
		public bool IsHandled { get; set; }
		public bool IsCancelled { get; set; }
		public List<string> Warnings { get; set; }

		public bool IsFailure
		{
			get
			{
				return !IsSuccessful && !IsCancelled;
			}
		}

		public Exception Exception { get; set; }
		public string Message { get; set; }


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

		public static OperationResult AsFailure(Exception ex)
		{
			return new OperationResult()
			{
				IsSuccessful = false,
				Exception = ex,
				Message = ex.Message,
				IsCancelled = false,
			};
		}

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

		public static OperationResult Combine(params IOperationResult[] operationResults)
		{
			if (!Array.TrueForAll(operationResults, (obj) => obj.IsSuccessful))
			{
				var failed = Array.FindAll(operationResults, (obj) => obj.IsFailure);
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
	/// Generic version of <see cref="T:ChilliSource.Mobile.Core.OperationResult"/> that also acts
	/// as a wrapper for a method's return type
	/// </summary>
	public class OperationResult<T> : OperationResult
	{
		public T Result { get; set; }

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

		public static OperationResult<T> AsFailure(Exception ex, T result = default(T))
		{
			return new OperationResult<T>()
			{
				IsSuccessful = false,
				Exception = ex,
				Message = ex.Message,
				IsCancelled = false,
				Result = result,
			};
		}

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
