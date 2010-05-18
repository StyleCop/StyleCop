//////////////////////////////////////////////////////////////////////////////
// ProvideLanguageServiceAttribute
//
// This attribute class will ease the pain of registering a language service
// written in managed code.
//
// To add editor Tool Options Pages, use ProvideLanguageEditorOptionPageAttribute.
// To add code expansion support, use ProvideLanguageCodeExpansionAttribute.
//
// Usage:
// [ProvideLanguageServiceAttribute(<type>,<language name>,<language name id>,
//    DebuggerLanguageExpressionEvaluator = "{guid}"
//    ShowCompetion = true | false
//    ShowSmartIndent = true | false
//    RequestStockColors = true | false
//    ShowHotURLs = true | false
//    DefaultToNonHotURLs = true | false
//    DefaultToInsertSpaces = true | false
//    ShowDropDownOptions = true | false
//    SingleCodeWindowOnly = true | false
//    EnableAdvancedMembersOption = true | false
//    SupportCopyPasteOfHTML = true | false
//    EnableLineNumbers = true | false
//    HideAdvancedMembersByDefault = true | false
//    CodeSense = true | false
//    MatchBraces = true | false
//    QuickInfo = true | false
//    ShowMatchingBrace = true | false
//    MatchBracesAtCaret = true | false
//    MaxErrorMessages = <number>
//    CodeSenseDelay = <number>
//    EnableAsyncCompletion = true | false
//    EnableCommenting = true | false
//    EnableFormatSelection = true | false
//    AutoOutlining = true | false
// )]
//
// Notes:
// * All named options are optional.
// 
//
// <type>             is the type of the class implementing the language
//                    service.  The language GUID is obtained from this.
// <language name>    Name of the language to be used as a registry key name.
// <language name id> resource id of localized language name which Visual
//                    Studio will show to the user.
//
// LocalizedName      literal text or #ddd (resource id of localized name)
//                    This name is used for the string put into the tree list
//                    of options in Visual Studio's Tools Options dialog.
//                    This value appears as the default value for the
//                    GroupName and ItemName registry keys.  If not specified,
//                    the GroupName or ItemName is substituted.
// GroupName          Registry key name.  This acts as a node in the tree list
//                    of options.
// ItemName           Registry key name which has a registry entry that
//                    specifies the guid of an option page to show.
//
// Note: All GroupName and ItemName keys contain an additional registry entry
//       for the package guid (which is derived internally and does not have
//       to be specified in the attribute).
//////////////////////////////////////////////////////////////////////////////

#region Using directives

using System;
using System.Diagnostics;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;

#endregion

namespace Microsoft.VisualStudio.Shell
{
    /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute"]' />
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class ProvideLanguageServiceAttribute : RegistrationAttribute
    {
        // ProvideLanguageServiceAttribute Private fields.
        //
        private Guid                languageServiceGuid;
        private string              strLanguageName;
        private int                 languageResourceID;
        private Hashtable           optionsTable;
        private DebuggerLanguages   debuggerLanguages;


        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.ProvideLanguageServiceAttribute"]' />
        /// <devdoc>
        /// Registers a language service.
        /// </devdoc>
        /// <param name="languageService"></param>
        /// <param name="strLanguageName"></param>
        /// <param name="languageResourceID"></param>
        public ProvideLanguageServiceAttribute(
            object languageService,
            string strLanguageName,
            int languageResourceID)
        {
            if (languageService is Type)
                this.languageServiceGuid = ((Type)languageService).GUID;
            else if (languageService is string)
                this.languageServiceGuid = new Guid((string)languageService);
            else
                throw new ArgumentException();
            this.strLanguageName     = strLanguageName;
            this.languageResourceID  = languageResourceID;

            debuggerLanguages   = new DebuggerLanguages(strLanguageName);
            optionsTable = new Hashtable();
        }

        // ProvideLanguageServiceAttribute Properties.

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.LanguageServiceSid"]' />
        public Guid LanguageServiceSid
        {
            get { return languageServiceGuid; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.LanguageName"]' />
        public string LanguageName
        {
            get { return strLanguageName; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.LanguageResourceID"]' />
        public int LanguageResourceID
        {
            get { return languageResourceID; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.DebuggerLanguageExpressionEvaluator"]' />
        /// <devdoc>
        /// Establish an expression evaluator for debugging languages.
        /// </devdoc>
        public string DebuggerLanguageExpressionEvaluator
        {
            get { return debuggerLanguages.ExpressionEvaluator.ToString("B"); }
            set { debuggerLanguages.ExpressionEvaluator = new Guid(value); }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.ShowCompletion"]' />
        public bool ShowCompletion
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.showCompletion];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.showCompletion] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.ShowSmartIndent"]' />
        public bool ShowSmartIndent
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.showIndentOptions];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.showIndentOptions] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.RequestStockColors"]' />
        public bool RequestStockColors
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.useStockColors];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.useStockColors] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.ShowHotURLs"]' />
        public bool ShowHotURLs
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.showHotURLs];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.showHotURLs] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.DefaultToNonHotURLs"]' />
        public bool DefaultToNonHotURLs
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.nonHotURLs];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.nonHotURLs] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.DefaultToInsertSpaces"]' />
        public bool DefaultToInsertSpaces
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.insertSpaces];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.insertSpaces] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.ShowDropDownOptions"]' />
        public bool ShowDropDownOptions
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.showDropDownBar];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.showDropDownBar] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.SingleCodeWindowOnly"]' />
        public bool SingleCodeWindowOnly
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.disableWindowNewWindow];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.disableWindowNewWindow] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.EnableAdvancedMembersOption"]' />
        public bool EnableAdvancedMembersOption
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.enableAdvMembersOption];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.enableAdvMembersOption] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.SupportCopyPasteOfHTML"]' />
        public bool SupportCopyPasteOfHTML
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.supportCF_HTML];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.supportCF_HTML] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.EnableLineNumbers"]' />
        public bool EnableLineNumbers
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.enableLineNumbersOption];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.enableLineNumbersOption] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.HideAdvancedMembersByDefault"]' />
        public bool HideAdvancedMembersByDefault
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.hideAdvancedMembersByDefault];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.hideAdvancedMembersByDefault] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.CodeSense"]' />
        public bool CodeSense
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.codeSense];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.codeSense] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.MatchBraces"]' />
        public bool MatchBraces
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.matchBraces];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.matchBraces] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.QuickInfo"]' />
        public bool QuickInfo
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.quickInfo];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.quickInfo] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.ShowMatchingBrace"]' />
        public bool ShowMatchingBrace
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.showMatchingBrace];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.showMatchingBrace] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.MatchBracesAtCaret"]' />
        public bool MatchBracesAtCaret
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.matchBracesAtCaret];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.matchBracesAtCaret] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.MaxErrorMessages"]' />
        public int MaxErrorMessages
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.maxErrorMessages];
                return (null == val) ? 0 : (int)val;
            }
            set { optionsTable[LanguageOptionKeys.maxErrorMessages] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.CodeSenseDelay"]' />
        public int CodeSenseDelay
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.codeSenseDelay];
                return (null == val) ? 0 : (int)val;
            }
            set { optionsTable[LanguageOptionKeys.codeSenseDelay] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.EnableAsyncCompletion"]' />
        public bool EnableAsyncCompletion
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.enableAsyncCompletion];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.enableAsyncCompletion] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.EnableCommenting"]' />
        public bool EnableCommenting
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.enableCommenting];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.enableCommenting] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.EnableFormatSelection"]' />
        public bool EnableFormatSelection
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.enableFormatSelection];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.enableFormatSelection] = value; }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.AutoOutlining"]' />
        public bool AutoOutlining
        {
            get { 
                object val = optionsTable[LanguageOptionKeys.autoOutlining];
                return (null == val) ? false : (bool)val;
            }
            set { optionsTable[LanguageOptionKeys.autoOutlining] = value; }
        }


        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.LanguageServicesKeyName"]' />
        private string LanguageServicesKeyName
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture,
                                     "{0}\\{1}",
                                     RegistryPaths.languageServices,
                                     LanguageName);
            }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.Register"]' />
        public override void Register(RegistrationAttribute.RegistrationContext context)
        {
            context.Log.WriteLine(string.Format(Resources.Culture, Resources.Reg_NotifyLanguageService, LanguageName, LanguageServiceSid.ToString("B")));

            // Create our top-most language key
            using (Key serviceKey = context.CreateKey(LanguageServicesKeyName))
            {
                // Add specific entries corresponding to arguments to
                // ProvideLanguageServiceAttribute constructor.
                serviceKey.SetValue(string.Empty, LanguageServiceSid.ToString("B"));
                serviceKey.SetValue(RegistryPaths.package, context.ComponentType.GUID.ToString("B"));
                serviceKey.SetValue(RegistryPaths.languageResourceId, languageResourceID);

                // Now add any explicitly specified options.
                string name;
                string value;
                foreach(object item in optionsTable.Keys)
                {
                    name = item.ToString();
                    if (optionsTable[item] is bool)
                    {
                        // Bool values are special-cased as they need to
                        // be written as 0 or 1 instead of false or true.
                        int nValue = 0;
                        if ((bool)optionsTable[item])
                        {
                            nValue = 1;
                        }
                        serviceKey.SetValue(name, nValue);
                    }
                    else if (optionsTable[item] is int)
                    {
                        serviceKey.SetValue(name, (int)optionsTable[item]);
                    }
                    else
                    {
                        // If not bool type, always write the value as a
                        // string.
                        value = optionsTable[item].ToString();
                        serviceKey.SetValue(name, value);
                    }
                }
                if (debuggerLanguages.IsValid())
                {
                    // If any debugger language options have been specified then...
                    // Note: we are assuming there can be only one of these entries
                    // for each language service.
                    string eeRegName = string.Format(CultureInfo.InvariantCulture, 
                                                     "{0}\\{1}", 
                                                     RegistryPaths.debuggerLanguages, 
                                                     debuggerLanguages.ExpressionEvaluator.ToString("B"));
                    using (Key dbgLangKey = serviceKey.CreateSubkey(eeRegName))
                    {
                        dbgLangKey.SetValue(null, debuggerLanguages.LanguageName);
                    }
                }
            }
        }

        /// <include file='doc\ProvideLanguageServiceAttribute.uex' path='docs/doc[@for="ProvideLanguageServiceAttribute.Unregister"]' />
        public override void Unregister(RegistrationAttribute.RegistrationContext context)
        {
            context.RemoveKey(LanguageServicesKeyName);
        }

        // Local classes.

        // DebuggerLanguages encapsulates all elements under the
        // "Debugger Languages" registry key.  There are only two entries
        // ever under this key and that's a language name and a guid of an
        // expression evaluator.
        private class DebuggerLanguages
        {
            //////////////////////////////////////////////////////////////////
            // DebuggerLanguages Private fields.
            private Guid   guidEE;    // Expression Evaluator Guid
            private string languageName;

            //////////////////////////////////////////////////////////////////
            // DebuggerLanguages Public methods.
            public DebuggerLanguages(string languageName)
            {
                this.languageName = languageName;
                guidEE = Guid.Empty;
            }
            /// <summary>
            /// Guid of the expression evaluator.
            /// </summary>
            /// <value>Guid</value>
            public Guid ExpressionEvaluator
            {
                get { return guidEE; }
                set { guidEE = value; }
            }

            public string LanguageName
            {
                get { return languageName; }
            }

            /// <summary>
            /// Determine whether the debugger language options have been set.
            /// </summary>
            /// <returns>bool</returns>
            public bool IsValid()
            {
                return guidEE != Guid.Empty;
            }
        }
    }
}
