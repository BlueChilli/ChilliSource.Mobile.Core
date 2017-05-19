#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

using System.Collections.Generic;
using System.Linq;
using Foundation;

namespace ChilliSource.Mobile.Core
{
    /// <summary>
    /// NSDictionary conversion helpers
    /// </summary>
	public static class NSDictionaryExtensions
	{
		/// <summary>
		/// Convert to .NET dictionary
		/// </summary>
		/// <returns>iOS dictionary.</returns>
		/// <param name="data">.NET dictionary.</param>
		public static Dictionary<string, object> ToDictionary(this NSDictionary data)
		{
			if (data == null)
			{
				return null;
			}
			var output = new Dictionary<string, object>();
			GetDictionary(data, output);

			return output;
		}

		static void GetDictionary(NSDictionary dictionary, Dictionary<string, object> result)
		{
			foreach (var key in dictionary.Keys)
			{
				if (!result.ContainsKey(key.ToString()))
				{
					var dictionaryValue = dictionary.ObjectForKey(key);

					if (dictionaryValue is NSDictionary)
					{
						var newDictionary = new Dictionary<string, object>();
						result.Add(key.ToString(), newDictionary);
						GetDictionary(dictionaryValue as NSDictionary, newDictionary);
					}
					else if (dictionaryValue is NSString)
					{
						var dictionaryObject = dictionary.ObjectForKey(key) as NSString;

						if (dictionaryObject != null)
						{
							result.Add(key.ToString(), dictionaryObject.ToString());
						}
					}
				}
			}
		}
	}
}
