/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Reflection;

namespace Microsoft.VsSDK.UnitTestLibrary
{
	public sealed class FileGenerator
	{
		private string path;

		public FileGenerator(string relativePath)
		{
			// Generate temp directory name
			path = Path.Combine(Path.GetTempPath(), relativePath);

			// Delete it if it already exist to prevent being affected by previous runs
			try
			{
				if (Directory.Exists(path))
					Directory.Delete(path, true);
			}
			catch (IOException)
			{ }

			// Create the directory
			Directory.CreateDirectory(path);
		}

		/// <summary>
		/// Create the specified path under a temp directory
		/// The file will have some content
		/// </summary>
		/// <param name="fileName">FileName, can include relative path</param>
		public string CreateFile(string fileName)
		{
			return CreateFileWithSpecificContent(fileName, fileName);
		}

		public string CreateFileFromEmbeddedContent(string fileName, string content)
		{
			return CreateFileWithSpecificContent(fileName, content);
		}

		public string CreateXmlFileFromEmbeddedContent(string fileName, string content)
		{
			// Create an XML document with the specific content
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(content);

			string outputPath = this.GetFullPath(fileName);
			doc.Save(outputPath);

			return outputPath;
		}

		/// <summary>
		/// Create the specified path under a temp directory
		/// Add the specified content to the file
		/// </summary>
		/// <param name="fileName">FileName, can include relative path</param>
		/// <param name="content">Content to add to the file</param>
		public string CreateFileWithSpecificContent(string fileName, string content)
		{
			string filePath = this.GetFullPath(fileName);
			string directory = Path.GetDirectoryName(filePath);
			if (!Directory.Exists(directory))
				Directory.CreateDirectory(directory);
			using (StreamWriter file = File.CreateText(filePath))
			{
				file.WriteLine(content);
			}

			return filePath;
		}

		/// <summary>
		/// Verify that the files have the same content
		/// </summary>
		/// <param name="path1">Full path of one of the file</param>
		/// <param name="path2">Full path of the other file</param>
		/// <param name="comparaisonType">What kind of comparaison to use</param>
		/// <returns></returns>
		public static bool FilesContentIsSame(string path1, string path2, StringComparison comparisonType)
		{
			string content1;
			string content2;
			using (StreamReader contentReader = File.OpenText(path1))
			{
				content1 = contentReader.ReadToEnd();
			}
			using (StreamReader contentReader = File.OpenText(path2))
			{
				content2 = contentReader.ReadToEnd();
			}

			return String.Equals(content1, content2, comparisonType);
		}

		private string GetFullPath(string fileName)
		{
			string filePath = Path.Combine(path, fileName);

			return filePath;
		}
	}
}
