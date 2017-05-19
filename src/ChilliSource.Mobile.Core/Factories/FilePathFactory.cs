#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

#if !__NETSTANDARD__

using System;
using System.IO;

namespace ChilliSource.Mobile.Core
{

    /// <summary>
    /// Provides file path builder methods
    /// </summary>
    public static class FilePathFactory
	{

        /// <summary>
        /// Constructs a file path for the specified <paramref name="fileName"/> to the platform's documents folder
        /// and optionally creates a <paramref name="subfolder"/>
        /// </summary>
        /// <returns>The document path</returns>
        /// <param name="fileName">File name</param>
        /// <param name="subfolder">Optional subfolder name</param>
        /// <param name="createSubfolder">Determines if a subfolder named <paramref name="subfolder"/>should be created</param>
        public static string BuildDocumentPath(string fileName, string subfolder, bool createSubfolder = false)
		{
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			if (createSubfolder && !string.IsNullOrEmpty(subfolder))
			{
				FileSystemManager.CreateDocumentsSubfolder(Path.Combine(documents, subfolder));
			}

			return Path.Combine(documents, subfolder, fileName);
		}

		/// <summary>
		/// Constructs a file path for the specified <paramref name="fileName"/> relative to the platform's documents folder
		/// </summary>
		/// <returns>The document path.</returns>
		/// <param name="fileName">File name.</param>
		public static string BuildDocumentPath(string fileName)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			return Path.Combine(documentsPath, fileName);
		}

		/// <summary>
		/// Constructs a file path for the specified <paramref name="fileName"/> relative to the platform's temporary folder
		/// </summary>
		/// <returns>The temp path.</returns>
		/// <param name="fileName">File name.</param>
		public static string BuildTempPath(string fileName)
		{
			var tempDir = Path.GetTempPath();
			return Path.Combine(tempDir, fileName);
		}

	}
}
#endif
