#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion


//------------------------------------------------------------------------------
// <copyright file="DescriptionAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

using System;
namespace ChilliSource.Mobile.Core
{
	/// <summary>
	/// Specifies a description for a property or event
	/// </summary>
	[AttributeUsage(AttributeTargets.All)]
	public class DescriptionAttribute : Attribute
	{
		/// <summary>
		/// Specifies the default value for the <see cref='DescriptionAttribute'/> , which is an
		/// empty string (""). This <see langword='static'/> field is read-only.
		/// </summary>
		public static readonly DescriptionAttribute Default = new DescriptionAttribute();

	    /// <summary>
		/// [To be supplied.]
		/// </summary>
		public DescriptionAttribute() : this(string.Empty)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref='DescriptionAttribute'/> class.
		/// </summary>
		public DescriptionAttribute(string description)
		{
			this.DescriptionValue = description;
		}

		/// <summary>
		/// Gets the description stored in this attribute.
		/// </summary>
		public virtual string Description => DescriptionValue;

	    /// <summary>
		/// Read/Write property that directly modifies the string stored
		/// in the description attribute. The default implementation
		/// of the Description property simply returns this value.
		/// </summary>
		protected string DescriptionValue { get; set; }

	    /// <summary>
        /// Equality override
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
		public override bool Equals(object obj)
		{
			if (obj == this)
			{
				return true;
			}

			var other = obj as DescriptionAttribute;

			return (other != null) && other.Description == Description;
		}

        /// <summary>
        /// Hashcode override
        /// </summary>
        /// <returns></returns>
		public override int GetHashCode()
		{
			return Description.GetHashCode();
		}

	}
}
