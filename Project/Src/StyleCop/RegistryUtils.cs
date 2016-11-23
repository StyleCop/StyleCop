// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistryUtils.cs" company="https://github.com/StyleCop">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
// <summary>
//   Performs operations in the registry.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;
    using System.Security;
    using System.Windows.Forms;

    using Microsoft.Win32;

    /// <summary>
    /// Performs operations in the registry.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Utils", 
        Justification = "API has already been published and should not be changed.")]
    public partial class RegistryUtils
    {
        #region Constants

        /// <summary>
        /// The StyleCop sub key.
        /// </summary>
        private const string StyleCopSubKey = @"Software\CodePlex\StyleCop";

        #endregion

        #region Fields

        /// <summary>
        /// The current user registry key for StyleCop.
        /// </summary>
        private RegistryKey currentUserRoot;

        /// <summary>
        /// The local machine registry key for StyleCop.
        /// </summary>
        private RegistryKey localMachineRoot;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Finalizes an instance of the RegistryUtils class.
        /// </summary>
        ~RegistryUtils()
        {
            if (this.currentUserRoot != null)
            {
                this.currentUserRoot.Close();
            }

            if (this.localMachineRoot != null)
            {
                this.localMachineRoot.Close();
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the HKCU root key for the StyleCop key as read/write. It will be created if it doesn't exist.
        /// </summary>
        public RegistryKey CurrentUserRoot
        {
            get
            {
                if (this.currentUserRoot == null)
                {
                    Permissions.DemandCurrentUserAccess(StyleCopSubKey);
                    this.currentUserRoot = Registry.CurrentUser.OpenSubKey(StyleCopSubKey, true)
                        ?? Registry.CurrentUser.CreateSubKey(StyleCopSubKey);
                }

                return this.currentUserRoot;
            }
        }

        /// <summary>
        /// Gets the HKLM root key for the StyleCop key as read only.
        /// </summary>
        public RegistryKey LocalMachineRoot
        {
            get
            {
                if (this.localMachineRoot == null)
                {
                    // Don't open local machine key on non-windows as it fails.
                    if (StyleCopCore.PlatformID == PlatformID.Win32NT)
                    {
                        Permissions.DemandLocalMachineAccess(StyleCopSubKey);
                        this.localMachineRoot = Registry.LocalMachine.OpenSubKey(StyleCopSubKey, false);
                    }
                }

                return this.localMachineRoot;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets a RegistryKey value for the specified <paramref name="keyName"/> and <paramref name="valueName"/> from the local machine hive.
        /// </summary>
        /// <param name="keyName">
        /// The key to retrieve from the registry.
        /// </param>
        /// <param name="valueName">
        /// The value to retrieve from the key provided.
        /// </param>
        /// <returns>
        /// Returns the RegistryKey value or null if not found.
        /// </returns>
        public static string LocalMachineGetValue(string keyName, string valueName)
        {
            return Registry.GetValue(@"HKEY_LOCAL_MACHINE\" + keyName, valueName, null) as string;
        }

        /// <summary>
        /// Gets a value under the StyleCop HKCU key.
        /// </summary>
        /// <param name="name">
        /// The path to the value.
        /// </param>
        /// <returns>
        /// Returns the object retrieved.
        /// </returns>
        public object CUGetValue(string name)
        {
            Param.RequireValidString(name, "name");
            return GetValue(this.CurrentUserRoot, name);
        }

        /// <summary>
        /// Adds or overwrites a value under the StyleCop HKCU key.
        /// </summary>
        /// <param name="name">
        /// The path to the value.
        /// </param>
        /// <param name="value">
        /// The object to write.
        /// </param>
        /// <returns>
        /// Returns true if the value was written, false if not.
        /// </returns>
        public bool CUSetValue(string name, object value)
        {
            Param.RequireValidString(name, "name");
            Param.RequireNotNull(value, "value");

            return SetValue(this.CurrentUserRoot, name, value);
        }

        /// <summary>
        /// Gets a value under the StyleCop HKLM key.
        /// </summary>
        /// <param name="name">
        /// The path to the value.
        /// </param>
        /// <returns>
        /// Returns the object retrieved.
        /// </returns>
        public object LMGetValue(string name)
        {
            Param.RequireValidString(name, "name");
            return this.LocalMachineRoot == null ? null : GetValue(this.LocalMachineRoot, name);
        }

        /// <summary>
        /// Restores the position of a form.
        /// </summary>
        /// <param name="name">
        /// The unique name of the form.
        /// </param>
        /// <param name="form">
        /// The form to restore.
        /// </param>
        /// <param name="location">
        /// Form's default location (optional).
        /// </param>
        /// <param name="size">
        /// Form's default size (optional).
        /// </param>
        /// <returns>
        /// Returns false if there is no registry information for this form, or if 
        /// the position of the form could not be restored.
        /// </returns>
        public bool RestoreWindowPosition(string name, Form form, object location, object size)
        {
            Param.RequireValidString(name, "name");
            Param.RequireNotNull(form, "form");
            Param.Ignore(location);
            Param.Ignore(size);

            bool ret = false;

            object loc = this.CUGetValue("WindowLocation\\" + name);
            if (loc == null)
            {
                // Apply passed defaults.
                if (location != null)
                {
                    form.Location = (Point)location;
                }

                if (size != null)
                {
                    form.Size = (Size)size;
                }
            }
            else
            {
                WindowLocation winLoc = new WindowLocation((string)loc);
                form.Location = winLoc.Location;
                form.Size = winLoc.Size;
                form.WindowState = winLoc.State;
                form.StartPosition = FormStartPosition.Manual;

                ret = true;
            }

            // Determine if the Location and Size is within the Screen's boundaries.
            if (form.WindowState == FormWindowState.Normal)
            {
                Rectangle workArea = Screen.PrimaryScreen.WorkingArea;

                if (form.Width > workArea.Width)
                {
                    form.Width = workArea.Width;
                }

                if (form.Height > workArea.Height)
                {
                    form.Height = workArea.Height;
                }

                int posX = form.Location.X;
                if (posX < 0)
                {
                    posX = 0;
                }

                if (posX + form.Width > workArea.Right)
                {
                    posX = workArea.Right - form.Width;
                }

                int posY = form.Location.Y;
                if (posY < 0)
                {
                    posY = 0;
                }

                if (posY + form.Height > workArea.Bottom)
                {
                    posY = workArea.Bottom - form.Height;
                }

                form.Location = new Point(posX, posY);
            }

            return ret;
        }

        /// <summary>
        /// Saves the current position of a form in the registry, given the position values.
        /// </summary>
        /// <param name="name">
        /// A unique name for the form.
        /// </param>
        /// <param name="location">
        /// The location of the form.
        /// </param>
        /// <param name="size">
        /// The size of the form.
        /// </param>
        /// <param name="state">
        /// The window state of the form.
        /// </param>
        /// <returns>
        /// Return false if the position could not be saved.
        /// </returns>
        public bool SaveWindowPosition(string name, Point location, Size size, FormWindowState state)
        {
            Param.RequireValidString(name, "name");
            Param.Ignore(location);
            Param.Ignore(size);
            Param.Ignore(state);

            WindowLocation windowLocation = new WindowLocation();
            windowLocation.Location = location;
            windowLocation.Size = size;
            windowLocation.State = state;

            return this.CUSetValue("WindowLocation\\" + name, windowLocation);
        }

        /// <summary>
        /// Saves the current position of the given form in the registry.
        /// </summary>
        /// <param name="name">
        /// A unique name for this form.
        /// </param>
        /// <param name="form">
        /// The form to save.
        /// </param>
        /// <returns>
        /// Returns false if the position could not be saved.
        /// </returns>
        public bool SaveWindowPositionByForm(string name, Form form)
        {
            Param.RequireValidString(name, "name");
            Param.RequireNotNull(form, "form");

            if (form.WindowState == FormWindowState.Normal)
            {
                return this.SaveWindowPosition(name, form.Location, form.Size, form.WindowState);
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Creates a path of keys in the registry.
        /// </summary>
        /// <param name="root">
        /// The root node to create the keys under.
        /// </param>
        /// <param name="name">
        /// The path the create under the root node.
        /// </param>
        /// <returns>
        /// Returns the key to the lowest branch created, or null if the path could not be created.
        /// </returns>
        private static PathInfo CreatePath(RegistryKey root, string name)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertValidString(name, "name");

            PathInfo pathinfo = new PathInfo();

            try
            {
                pathinfo.Key = root;
                string path = name;
                string nameTemp = null;
                while (true)
                {
                    int index = path.IndexOf("\\", StringComparison.Ordinal);
                    if (-1 == index)
                    {
                        pathinfo.Stub = path;
                        break;
                    }
                    else
                    {
                        nameTemp = path.Substring(0, index);
                        path = path.Substring(index + 1, path.Length - index - 1);
                        pathinfo.Key = pathinfo.Key.CreateSubKey(nameTemp);
                    }
                }

                return pathinfo;
            }
            catch (ArgumentException)
            {
            }
            catch (SecurityException)
            {
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }

            pathinfo.Key = null;
            return pathinfo;
        }

        /// <summary>
        /// Traverses a path in the registry and returns the lowest key.
        /// </summary>
        /// <param name="root">
        /// The root that the path is under.
        /// </param>
        /// <param name="name">
        /// The path to traverse.
        /// </param>
        /// <returns>
        /// Returns the key if it was found and loaded, or null otherwise.
        /// </returns>
        private static PathInfo GetPath(RegistryKey root, string name)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertValidString(name, "name");

            PathInfo pathinfo = new PathInfo();

            try
            {
                pathinfo.Key = root;
                string path = name;
                string nameTemp = null;
                while (true)
                {
                    int index = path.IndexOf("\\", StringComparison.Ordinal);
                    if (-1 == index)
                    {
                        pathinfo.Stub = path;
                        break;
                    }
                    else
                    {
                        nameTemp = path.Substring(0, index);
                        path = path.Substring(index + 1, path.Length - index - 1);
                        pathinfo.Key = pathinfo.Key.OpenSubKey(nameTemp, true);
                    }
                }

                return pathinfo;
            }
            catch (ArgumentException)
            {
            }
            catch (IOException)
            {
            }
            catch (SecurityException)
            {
            }

            pathinfo.Key = null;
            return pathinfo;
        }

        /// <summary>
        /// Gets one value from the registry.
        /// </summary>
        /// <param name="root">
        /// The root key to get the value under.
        /// </param>
        /// <param name="name">
        /// The path to the value under the root key.
        /// </param>
        /// <returns>
        /// Return the object or null if it could not be found or retrieved.
        /// </returns>
        private static object GetValue(RegistryKey root, string name)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertValidString(name, "name");

            try
            {
                PathInfo pathinfo = GetPath(root, name);
                if (pathinfo.Key == null)
                {
                    return null;
                }
                else
                {
                    return pathinfo.Key.GetValue(pathinfo.Stub);
                }
            }
            catch (SecurityException)
            {
            }
            catch (IOException)
            {
            }
            catch (ArgumentException)
            {
            }

            return null;
        }

        /// <summary>
        /// Sets one value in the registry.
        /// </summary>
        /// <param name="root">
        /// The root key to set the value under.
        /// </param>
        /// <param name="name">
        /// The path to the value to set.
        /// </param>
        /// <param name="value">
        /// The value to set.
        /// </param>
        /// <returns>
        /// Returns true if the value is set, false otherwise.
        /// </returns>
        private static bool SetValue(RegistryKey root, string name, object value)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertValidString(name, "name");
            Param.AssertNotNull(value, "value");

            try
            {
                PathInfo pathinfo = CreatePath(root, name);
                if (pathinfo.Key == null)
                {
                    return false;
                }
                else
                {
                    pathinfo.Key.SetValue(pathinfo.Stub, value);
                }

                return true;
            }
            catch (ArgumentException)
            {
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (SecurityException)
            {
            }

            return false;
        }

        #endregion

        /// <summary>
        /// Used by the GetPath and CreatePath functions.
        /// </summary>
        private struct PathInfo
        {
            #region Fields

            /// <summary>
            /// The path key.
            /// </summary>
            public RegistryKey Key;

            /// <summary>
            /// The path stub.
            /// </summary>
            public string Stub;

            #endregion
        }
    }
}