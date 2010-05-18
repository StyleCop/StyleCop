//--------------------------------------------------------------------------
//  <copyright file="utilities.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
//  </copyright>
//  <summary>
//  </summary>
//--------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Collections;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Designer.Interfaces;
using Microsoft.VisualStudio.Shell;
using Microsoft.Win32;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using IServiceProvider = System.IServiceProvider;
using ShellConstants = Microsoft.VisualStudio.Shell.Interop.Constants;
using OleConstants = Microsoft.VisualStudio.OLE.Interop.Constants;

namespace Microsoft.VisualStudio.Shell
{


    /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities"]' />
    public static class PackageUtilities
	{

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.GetSystemAssemblyPath"]' />
        public static string GetSystemAssemblyPath()
		{
			return Path.GetDirectoryName(typeof(object).Assembly.Location);
#if SYSTEM_COMPILER 
      // To support true cross-platform compilation we really need to use
      // the System.Compiler.dll SystemTypes class which statically loads
      // mscorlib type information from "TargetPlatform" location.
      return Path.GetDirectoryName(SystemTypes.SystemAssembly.Location);
#endif

		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.EnsureOutputPath"]' />
        public static void EnsureOutputPath(string path)
		{
			if (!String.IsNullOrEmpty(path) && !Directory.Exists(path))
			{
				try
				{
					Directory.CreateDirectory(path);
				}
				catch (IOException e)
				{
					Trace.WriteLine("Exception : " + e.Message);
				}
				catch (UnauthorizedAccessException e)
				{
					Trace.WriteLine("Exception : " + e.Message);
				}
				catch (ArgumentException e)
				{
					Trace.WriteLine("Exception : " + e.Message);
				}
				catch (NotSupportedException e)
				{
					Trace.WriteLine("Exception : " + e.Message);
				}

			}
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.ContainsInvalidFileNameChars"]' />
        /// <devdoc>
		/// Returns true if thename that can represent a path, absolut or relative, or a file name contains invalid filename characters.
		/// </devdoc>
		/// <param name="name">File name</param>
		/// <returns>true if file name is invalid</returns>
		public static bool ContainsInvalidFileNameChars(string name)
		{
			if (String.IsNullOrEmpty(name))
			{
				return true;
			}

			if (Path.IsPathRooted(name))
			{
				string root = Path.GetPathRoot(name);
				name = name.Substring(root.Length);
			}

			Url uri = new Url(name);

			string[] segments = uri.Segments;
			if (segments != null)
			{
				foreach (string segment in segments)
				{
					if (IsFilePartInValid(segment))
					{
						return true;
					}
				}
			}
			else
			{
				return IsFilePartInValid(name);
			}

			return false;
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.IsFileNameInvalid"]' />
        /// <devdoc>
		/// Cehcks if a file name is valid.
		/// </devdoc>
		/// <param name="fileName">The name of the file</param>
		/// <returns>True if the file is valid.</returns>
		public static bool IsFileNameInvalid(string fileName)
		{
			if (String.IsNullOrEmpty(fileName))
			{
				return true;
			}

			if (IsFileNameAllGivenCharacter('.', fileName) || IsFileNameAllGivenCharacter(' ', fileName))
			{
				return true;
			}


			return IsFilePartInValid(fileName);

		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.CopyUrlToLocal"]' />
        ///<devdoc>
        /// Copy the specified file to the local project directory.  Also supports downloading
		/// of HTTP resources (so be prepared for a delay in that case!).
		/// </devdoc>
		public static  void CopyUrlToLocal(Uri uri, string local)
		{
			if (uri.IsFile)
			{
				// now copy file
				FileInfo fiOrg = new FileInfo(uri.LocalPath);
				FileInfo fiNew = fiOrg.CopyTo(local, true);
			}
			else
			{
				FileStream localFile = new FileStream(local, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
				try
				{
					WebRequest wr = WebRequest.Create(uri);
					wr.Timeout = 10000;
					wr.Credentials = CredentialCache.DefaultCredentials;
					WebResponse resp = wr.GetResponse();
					Stream s = resp.GetResponseStream();
					byte[] buffer = new byte[10 * 1024];
					int len;
					while ((len = s.Read(buffer, 0, buffer.Length)) != 0)
					{
						localFile.Write(buffer, 0, len);
					}
				}
				finally
				{
					localFile.Close();
				}
			}
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.MakeRelativeIfRooted"]' />
        /// <devdoc>
		/// If this file is in the same folder the Url or below make it relative to the current Url
		/// </devdoc>
        /// <param name="fileName">filename (is rooted) to be transformed</param>
		/// <param name="url">the location to make the filename relative to</param>
		/// <returns>the relative path to the url or returns filename if not rooted</returns>
		public static string MakeRelativeIfRooted(string fileName, Url url)
		{
			string relativePath = fileName;
			if (Path.IsPathRooted(relativePath))
			{
				string path = new Url(relativePath).AbsoluteUrl;
				string basePath = url.AbsoluteUrl;
				if (path.StartsWith(basePath, StringComparison.OrdinalIgnoreCase))
				{
					relativePath = path.Substring(basePath.Length);
				}
			}
			return relativePath;
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.GetPathDistance"]' />
        /// <devdoc>
		/// Given two uris calculates the distance from the second path top the first one.
		/// </devdoc>
		/// <returns>The distance in path, if it can make it or the fullpath of the second uri if there if relative path does not make sense.</returns>
		public static string GetPathDistance(Uri uriBase, Uri uriRelativeTo)
		{
			string diff = String.Empty;

			if (uriRelativeTo != null && uriBase != null)
			{
				// MakeRelative only really works if on the same drive.
				if (uriRelativeTo.Segments.Length > 0 && uriBase.Segments.Length > 0 && String.Compare(uriRelativeTo.Segments[1], uriBase.Segments[1], StringComparison.OrdinalIgnoreCase) == 0)
				{
					Uri uriRelative = uriBase.MakeRelativeUri(uriRelativeTo);
					if (uriRelative != null)
					{
						diff = Url.Unescape(uriRelative.ToString(), true);
					}
				}
				else
				{
					diff = uriRelativeTo.LocalPath;
				}
			}

			return diff;
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.MakeRelative"]' />
        public static string MakeRelative(string filename, string filename2)
		{
			string[] parts = filename.Split(Path.DirectorySeparatorChar);
			string[] parts2 = filename2.Split(Path.DirectorySeparatorChar);

			if (parts.Length == 0 || parts2.Length == 0 || parts[0] != parts2[0])
			{
				return filename2; // completely different paths.
			}

			int i;

			for (i = 1; i < parts.Length && i < parts2.Length; i++)
			{
				if (parts[i] != parts2[i]) break;
			}

			StringBuilder sb = new StringBuilder();

			for (int j = i; j < parts.Length - 1; j++)
			{
				sb.Append("..");
				sb.Append(Path.DirectorySeparatorChar);
			}

			for (int j = i; j < parts2.Length; j++)
			{
				sb.Append(parts2[j]);
				if (j < parts2.Length - 1)
					sb.Append(Path.DirectorySeparatorChar);
			}

			return sb.ToString();
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.CreateCAUUIDFromGuidArray"]' />
        /// <devdoc>
		/// Creates a CAUUID from a guid array. Memory is allocated for the elems. 
		/// It is the responsability of the caller to release this memory.
		/// </devdoc>
		/// <param name="guids"></param>
		/// <returns></returns>
		[CLSCompliant(false)]
		public static CAUUID CreateCAUUIDFromGuidArray(Guid[] guids)
		{
			CAUUID cauuid = new CAUUID();

			if (guids != null)
			{
				cauuid.cElems = (uint)guids.Length;

				int size = Marshal.SizeOf(typeof(Guid));

				cauuid.pElems = Marshal.AllocCoTaskMem(guids.Length * size);

				IntPtr ptr = cauuid.pElems;

				for (int i = 0; i < guids.Length; i++)
				{
					Marshal.StructureToPtr(guids[i], ptr, false);
					ptr = new IntPtr(ptr.ToInt64() + size);
				}
			}

			return cauuid;
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.GetIntPointerFromImage"]' />
        public static int GetIntPointerFromImage(Image image)
		{
			Debug.Assert(image is Bitmap);
			Bitmap bitmap = image as Bitmap;
			if (bitmap != null)
			{
				IntPtr ptr = bitmap.GetHicon();
				// todo: this is not 64bit safe, but is a work around until whidbey bug 172595 is fixed.
				return ptr.ToInt32();
			}
			return 0;
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.GetImageList"]' />
        /// <devdoc>
		/// Creates an imagelist from resourcenames that are assumed to be icons.
		/// </devdoc>
		/// <param name="assembly"></param>
		/// <param name="resourceNames"></param>
		/// <returns></returns>
		public static ImageList GetImageList(Assembly assembly, string[] resourceNames)
		{
			if (resourceNames == null || resourceNames.Length == 0 || assembly == null)
			{
				return null;
			}

			ImageList ilist = new ImageList();
			ilist.ImageSize = new Size(16, 16);

			foreach (string imageName in resourceNames)
			{
				Stream stream = assembly.GetManifestResourceStream(imageName);
				if (stream != null)
				{
					Icon icon = new Icon(stream);
					ilist.Images.Add(icon.ToBitmap());
				}
			}

			return ilist;
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.GetImageList"]' />
        public static ImageList GetImageList(Stream imageStream)
		{
			ImageList ilist = new ImageList();

			if (imageStream == null)
			{
				return ilist;
			}
			ilist.ImageSize = new Size(16, 16);
			Bitmap bitmap = new Bitmap(imageStream);
			ilist.Images.AddStrip(bitmap);
			ilist.TransparentColor = Color.Magenta;
			return ilist;
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.GetImageList"]' />
        public static ImageList GetImageList(object imageListAsPointer)
		{
			ImageList images = null;

			IntPtr intPtr = new IntPtr((int)imageListAsPointer);
			HandleRef hImageList = new HandleRef(null, intPtr);
			int count = UnsafeNativeMethods.ImageList_GetImageCount(hImageList);

			if (count > 0)
			{
				// Create a bitmap big enough to hold all the images
				Bitmap b = new Bitmap(16 * count, 16);
				Graphics g = Graphics.FromImage(b);

				// Loop through and extract each image from the imagelist into our own bitmap
				IntPtr hDC = IntPtr.Zero;
				try
				{
					hDC = g.GetHdc();
					HandleRef handleRefDC = new HandleRef(null, hDC);
					for (int i = 0; i < count; i++)
					{
						UnsafeNativeMethods.ImageList_Draw(hImageList, i, handleRefDC, i * 16, 0, NativeMethods.ILD_NORMAL);
					}
				}
				finally
				{
					if (g != null && hDC != IntPtr.Zero)
					{
						g.ReleaseHdc(hDC);
					}
				}

				// Create a new imagelist based on our stolen images
				images = new ImageList();
				images.ImageSize = new Size(16, 16);
				images.Images.AddStrip(b);
			}
			return images;
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.ConvertToType"]' />
        /// <devdoc>
		/// Helper method to call a converter explicitely to convert to an enum type
		/// </devdoc>
		/// <typeparam name="T">The enum to convert to</typeparam>
		/// <param name="value">The enum value to be converted to</param>
		/// <param name="typeToConvert">The type to convert</param>
		/// <param name="culture">The culture to use to read the localized strings</param>
		/// <returns></returns>
		[CLSCompliant(false)]
		public static object ConvertToType<T>(T value, Type typeToConvert, CultureInfo culture)
			where T : struct
		{
			EnumConverter converter = GetEnumConverter<T>();
			if (converter == null)
			{
				return null;
			}
			if (converter.CanConvertTo(typeToConvert))
			{
				return converter.ConvertTo(null, culture, value, typeToConvert);
			}
			
			return null;
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.ConvertFromType"]' />
        /// <devdoc>
		/// Helper method for converting from a string to an enum using a converter.
		/// </devdoc>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <param name="culture">The culture to use to read the localized strings</param>
		/// <returns></returns>
		[CLSCompliant(false)]
		public static Nullable<T> ConvertFromType<T>(string value, CultureInfo culture)
			where T : struct
		{
			Nullable<T> returnValue = new Nullable<T>();

			returnValue = returnValue.GetValueOrDefault();

			if (value == null)
			{
				return returnValue;
			}

			EnumConverter converter = GetEnumConverter<T>();
			if (converter == null)
			{
				return returnValue;
			}
			
			if (converter.CanConvertFrom(value.GetType()))
			{
				object converted = converter.ConvertFrom(null, culture, value);

				if (converted != null && (converted is T))
				{
					returnValue = (T)converted;
				}
			}

			return returnValue;
		}


        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.SetStringValueFromConvertedEnum"]' />
        /// <devdoc>
		/// Sets a string value from an enum
		/// </devdoc>
		/// <typeparam name="T">The enum type</typeparam>
		/// <param name="enumValue">The value of the enum.</param>
        /// <param name="culture"></param>
        /// <returns></returns>
		[CLSCompliant(false)]
		public static string SetStringValueFromConvertedEnum<T>(T enumValue, CultureInfo culture)
			where T : struct
		{
			object convertToType = PackageUtilities.ConvertToType<T>(enumValue, typeof(string), culture);
			if (convertToType == null || !(convertToType is string))
			{
				return String.Empty;
			}
			
			return (string)convertToType;
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.GetEnumConverter"]' />
        /// <devdoc>
		/// Gets an instance 
		/// </devdoc>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		private static EnumConverter GetEnumConverter<T>()
			where T : struct
		{
			object[] attributes = typeof(T).GetCustomAttributes(typeof(PropertyPageTypeConverterAttribute), true);

			// There should be only one PropertyPageTypeConverterAttribute defined on T
			if (attributes != null && attributes.Length == 1)
			{
				
				Debug.Assert(attributes[0] is PropertyPageTypeConverterAttribute, "The returned attribute must be an attribute is PropertyPageTypeConverterAttribute");
				PropertyPageTypeConverterAttribute converterAttribute = (PropertyPageTypeConverterAttribute)attributes[0];

				if (converterAttribute.ConverterType.IsSubclassOf(typeof(EnumConverter)))
				{
					return Activator.CreateInstance(converterAttribute.ConverterType) as EnumConverter;
				}
			}

			return null;
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.IsFilePartInValid"]' />
        /// <devdoc>
		/// Checks whether a file part contains valid characters. The file part can be any part of a non rooted path.
		/// </devdoc>
		/// <param name="filePart"></param>
		/// <returns></returns>
		private static bool IsFilePartInValid(string filePart)
		{
			if (String.IsNullOrEmpty(filePart))
			{
				return true;
			}

			// Define a regular expression that covers all characters that are not in the safe character sets.
			// It is compiled for performance.
			Regex unsafeCharactersRegex = new Regex(@"[/?:&\\*<>|#%" + '\"' + "]", RegexOptions.Compiled);
			return unsafeCharactersRegex.IsMatch(filePart);
		}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="PackageUtilities.IsFileNameAllGivenCharacter"]' />
        /// <devdoc>
		/// Checks if the file name is all the given character.
		/// </devdoc>
		private static bool IsFileNameAllGivenCharacter(char c, string fileName)
		{
			// A valid file name cannot be all "c" .
			int charFound = 0;
			for (charFound = 0; charFound < fileName.Length && fileName[charFound] == c; ++charFound) ;
			if (charFound >= fileName.Length)
			{
				return true;
			}

			return false;
		}
	}
}
