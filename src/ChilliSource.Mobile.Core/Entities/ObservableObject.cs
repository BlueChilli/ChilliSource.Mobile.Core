#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

/*
Source: 	MvvmHelpers (https://github.com/jamesmontemagno/mvvm-helpers/blob/master/MvvmHelpers)
Author:  	James Montemagno (https://github.com/jamesmontemagno)
License: 	Apache v2.0 (https://github.com/jamesmontemagno/mvvm-helpers/blob/master/LICENSE.md)
*/

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace ChilliSource.Mobile.Core
{
	/// <summary>
	/// Observable object with INotifyPropertyChanged implemented
	/// </summary>
	public class ObservableObject : INotifyPropertyChanged
	{
		/// <summary>
		/// Sets the property.
		/// </summary>
		/// <returns><c>true</c>, if property was set, <c>false</c> otherwise.</returns>
		/// <param name="backingStore">Backing store.</param>
		/// <param name="value">Value.</param>
		/// <param name="propertyName">Property name.</param>
		/// <param name="onChanged">On changed.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		protected bool SetProperty<T>(
			ref T backingStore, T value,
			[CallerMemberName]string propertyName = "",
			Action onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
			{
				return false;
			}

			backingStore = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}

		/// <summary>
		/// Occurs when property changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raises the property changed event.
		/// </summary>
		/// <param name="propertyName">Property name.</param>
		protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


	}
}
