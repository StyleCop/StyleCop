// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopOptions.cs" company="http://stylecop.codeplex.com">
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
//   Class to hold all of the Configurable options for this addin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

extern alias JB;

namespace StyleCop.ReSharper.Options
{
    #region Using Directives

    using System.Windows.Forms;
    using System.Xml;

    using JetBrains.Application;
    using JetBrains.ComponentModel;

    using Microsoft.Win32;

    using StyleCop.ReSharper.Core;

    #endregion

    /// <summary>
    /// Class to hold all of the Configurable options for this addin.
    /// </summary>
    [ShellComponentInterface(ProgramConfigurations.VS_ADDIN)]
    [ShellComponentImplementation]
    public class StyleCopOptions : IXmlExternalizableShellComponent
    {
        #region Constants and Fields

        private bool alwaysCheckForUpdatesWhenVisualStudioStarts;

        /// <summary>
        /// Set to true when we've attempted to get the StyleCop path.
        /// </summary>
        private bool attemptedToGetStyleCopPath;

        /// <summary>
        /// Tracks whether we should check for updates.
        /// </summary>
        private bool automaticallyCheckForUpdates;

        /// <summary>
        /// The number of days between update checks.
        /// </summary>
        private int daysBetweenUpdateChecks;

        /// <summary>
        /// The value of the detected path for StyleCop.
        /// </summary>
        private string styleCopDetectedPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopOptions"/> class. 
        /// Set to max performance by default.
        /// </summary>
        public StyleCopOptions()
        {
            this.ParsingPerformance = 9;
            this.SpecifiedAssemblyPath = string.Empty;
            this.InsertTextIntoDocumentation = true;
            this.AutomaticallyCheckForUpdates = true;
            this.AlwaysCheckForUpdatesWhenVisualStudioStarts = true;
            this.DaysBetweenUpdateChecks = 2;
            this.LastUpdateCheckDate = "1900-01-01";
            this.DashesCountInFileHeader = 116;
            this.UseExcludeFromStyleCopSetting = true;
            this.SuppressStyleCopAttributeJustificationText = "Reviewed. Suppression is OK here.";
            this.UseSingleLineDeclarationComments = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static StyleCopOptions Instance
        {
            get
            {
                return Shell.Instance.GetComponent<StyleCopOptions>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether AlwaysCheckForUpdatesWhenVisualStudioStarts.
        /// </summary>
        [JB::JetBrains.Util.XmlExternalizableAttribute(true)]
        public bool AlwaysCheckForUpdatesWhenVisualStudioStarts
        {
            get
            {
                return this.alwaysCheckForUpdatesWhenVisualStudioStarts;
            }

            set
            {
                this.alwaysCheckForUpdatesWhenVisualStudioStarts = value;

                SetRegistry("AlwaysCheckForUpdatesWhenVisualStudioStarts", value, RegistryValueKind.DWord);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether we check for updates when plugin starts.
        /// </summary>
        [JB::JetBrains.Util.XmlExternalizableAttribute(true)]
        public bool AutomaticallyCheckForUpdates
        {
            get
            {
                return this.automaticallyCheckForUpdates;
            }

            set
            {
                this.automaticallyCheckForUpdates = value;
                SetRegistry("AutomaticallyCheckForUpdates", value, RegistryValueKind.DWord);
            }
        }

        /// <summary>
        /// Gets or sets DashesCountInFileHeader.
        /// </summary>
        [JB::JetBrains.Util.XmlExternalizableAttribute(116)]
        public int DashesCountInFileHeader { get; set; }

        /// <summary>
        /// Gets or sets DaysBetweenUpdateChecks.
        /// </summary>
        [JB::JetBrains.Util.XmlExternalizableAttribute(2)]
        public int DaysBetweenUpdateChecks
        {
            get
            {
                return this.daysBetweenUpdateChecks;
            }

            set
            {
                this.daysBetweenUpdateChecks = value;
                SetRegistry("DaysBetweenUpdateChecks", value, RegistryValueKind.DWord);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether descriptive text should be inserted into missing documentation headers.
        /// </summary>
        [JB::JetBrains.Util.XmlExternalizableAttribute(true)]
        public bool InsertTextIntoDocumentation { get; set; }

        /// <summary>
        /// Gets or sets the last update check date.
        /// </summary>
        [JB::JetBrains.Util.XmlExternalizableAttribute("1900-01-01")]
        public string LastUpdateCheckDate { get; set; }

        /// <summary>
        /// Gets or sets the ParsingPerformance value.
        /// </summary>
        /// <value>
        /// The performance value.
        /// </value>
        [JB::JetBrains.Util.XmlExternalizableAttribute(9)]
        public int ParsingPerformance { get; set; }

        /// <summary>
        /// Gets the Scope that defines which store the data goes into.
        /// Must not be
        /// <c>0.</c>.
        /// </summary>
        /// <value>
        /// The Scope.
        /// </value>
        public XmlExternalizationScope Scope
        {
            get
            {
                return XmlExternalizationScope.UserSettings;
            }
        }

        /// <summary>
        /// Gets or sets the Specified Assembly Path.
        /// </summary>
        /// <value>
        /// The allow null attribute.
        /// </value>
        [JB::JetBrains.Util.XmlExternalizableAttribute("")]
        public string SpecifiedAssemblyPath { get; set; }

        /// <summary>
        /// Gets or sets the text for inserting suppressmessageattributes.
        /// </summary>
        [JB::JetBrains.Util.XmlExternalizableAttribute("Reviewed. Suppression is OK here.")]
        public string SuppressStyleCopAttributeJustificationText { get; set; }

        /// <summary>
        /// Gets the name of the tag.
        /// </summary>
        /// <value>
        /// The name of the tag.
        /// </value>
        public string TagName
        {
            get
            {
                return "StyleCopForReSharper";
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use exclude from style cop setting.
        /// </summary>
        [JB::JetBrains.Util.XmlExternalizableAttribute(true)]
        public bool UseExcludeFromStyleCopSetting { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether declaration comments should be multi line or single line.
        /// </summary>
        [JB::JetBrains.Util.XmlExternalizableAttribute(false)]
        public bool UseSingleLineDeclarationComments { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Detects the style cop path.
        /// </summary>
        /// <returns>
        /// The path to the detected StyleCop assembly.
        /// </returns>
        public string DetectStyleCopPath()
        {
            var assemblyPath = StyleCopLocator.GetStyleCopPath();
            return StyleCopReferenceHelper.LocationValid(assemblyPath) ? assemblyPath : null;
        }

        /// <summary>
        /// Gets the assembly location.
        /// </summary>
        /// <returns>
        /// The path to the StyleCop assembly.
        /// </returns>
        public string GetAssemblyPath()
        {
            if (!this.attemptedToGetStyleCopPath)
            {
                this.attemptedToGetStyleCopPath = true;

                if (!string.IsNullOrEmpty(this.SpecifiedAssemblyPath))
                {
                    if (StyleCopReferenceHelper.LocationValid(this.SpecifiedAssemblyPath))
                    {
                        this.styleCopDetectedPath = this.SpecifiedAssemblyPath;
                        return this.styleCopDetectedPath;
                    }

                    // Location not valid. Blank it and automatically get location
                    this.SpecifiedAssemblyPath = null;
                }

                this.styleCopDetectedPath = this.DetectStyleCopPath();

                if (string.IsNullOrEmpty(this.styleCopDetectedPath))
                {
                    MessageBox.Show(
                        string.Format("Failed to find the StyleCop Assembly. Please check your StyleCop installation."), "Error Finding StyleCop Assembly", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return this.styleCopDetectedPath;
        }

        #endregion

        #region Implemented Interfaces

        #region IComponent

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init()
        {
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion

        #region IXmlExternalizable

        /// <summary>
        /// Reads the settings from the XML.
        /// </summary>
        /// <param name="element">
        /// The XmlElement to read from.
        /// </param>
        public void ReadFromXml(XmlElement element)
        {
            if (element == null)
            {
                return;
            }

            JB::JetBrains.Util.XmlExternalizationUtil.ReadFromXml(element, this);
        }

        /// <summary>
        /// Writes the settings to XML.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        public void WriteToXml(XmlElement element)
        {
            JB::JetBrains.Util.XmlExternalizationUtil.WriteToXml(element, this);
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Sets a regkey value in the registry.
        /// </summary>
        /// <param name="key">
        /// The subkey to create.
        /// </param>
        /// <param name="value">
        /// The value to use.
        /// </param>
        /// <param name="valueKind">
        /// The type of regkey value to set.
        /// </param>
        private static void SetRegistry(string key, object value, RegistryValueKind valueKind)
        {
            const string SubKey = @"SOFTWARE\CodePlex\StyleCop";

            var registryKey = Registry.CurrentUser.CreateSubKey(SubKey);
            if (registryKey != null)
            {
                registryKey.SetValue(key, value, valueKind);
            }
        }

        #endregion
    }
}