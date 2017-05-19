#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

using System;
using System.Collections.Generic;

namespace ChilliSource.Mobile.Core
{
	/// <summary>
	/// Contract for <see cref="T:ChilliSource.Mobile.Core.OperationResult"/>
	/// </summary>
	public interface IOperationResult
	{
       

        /// <summary>
        /// Specifies whether the operation has executed successfully
        /// </summary>
        bool IsSuccessful { get; set; }

        /// <summary>
        /// Specifies whether the operation was cancelled, usually as a result of a user action
        /// </summary>
        bool IsCancelled { get; set; }

        /// <summary>
        /// Specifies whether the operation failed, providing a <see cref="Message"/> and/or an <see cref="Exception"/>
        /// </summary>
        bool IsFailure { get; }

        /// <summary>
        /// The message holding additional information about the exeuction of the operation, 
        /// or explaining the reason for the failure if <see cref="IsFailure"/> is set to true
        /// </summary>
        string Message { get; set; }
        
        /// <summary>
        /// Specifies whether the <see cref="Exception"/> has been handled
        /// </summary>
        bool IsHandled { get; }

        /// <summary>
        /// Exception that may have been raised and captured during the execution of the Operation
        /// </summary>
		Exception Exception { get; }

        /// <summary>
        /// A list of warning message strinfs that may have occured during the execution of the operation, 
        /// but that did not result in a failure of the operation
        /// </summary>
        List<string> Warnings { get; set; }
	}

}
