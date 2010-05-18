
namespace Microsoft.VisualStudio.Shell
{
    // These string names and definitions are from vscommon\inc\vsregkeynames.h
    internal class RegistryPaths
    {
        private RegistryPaths() { }

        internal static string package            = "Package";
        internal static string displayName        = "DisplayName";
        internal static string languageStringId   = "LangStringID";
        internal static string languageResourceId = "LangResID";
        internal static string showRoots          = "ShowRoots";
        internal static string indexPath          = "IndexPath";
        internal static string paths              = "Paths";
        internal static string languages          = "Languages";
        internal static string languageServices   = languages + "\\Language Services";
        internal static string codeExpansion      = languages + "\\CodeExpansions";
        internal static string forceCreateDirs    = "ForceCreateDirs";
        internal static string debuggerLanguages  = "Debugger Languages";
        internal static string editorToolsOptions = "EditorToolsOptions";
        internal static string page               = "Page";
    }

    internal class LanguageOptionKeys
    {
        private LanguageOptionKeys() { }

        internal static string showCompletion               = "ShowCompletion";
        internal static string showIndentOptions            = "ShowSmartIndent";
        internal static string useStockColors               = "RequestStockColors";
        internal static string showHotURLs                  = "ShowHotURLs";
        internal static string nonHotURLs                   = "Default to Non Hot URLs";
        internal static string insertSpaces                 = "DefaultToInsertSpaces";
        internal static string showDropDownBar              = "ShowDropdownBarOption";
        internal static string disableWindowNewWindow       = "Single Code Window Only";
        internal static string enableAdvMembersOption       = "EnableAdvancedMembersOption";
        internal static string supportCF_HTML               = "Support CF_HTML";
        internal static string enableLineNumbersOption      = "EnableLineNumbersOption";
        internal static string hideAdvancedMembersByDefault = "HideAdvancedMembersByDefault";
        internal static string codeSense                    = "CodeSense";
        internal static string matchBraces                  = "MatchBraces";
        internal static string quickInfo                    = "QuickInfo";
        internal static string showMatchingBrace            = "ShowMatchingBrace";
        internal static string matchBracesAtCaret           = "MatchBracesAtCaret";
        internal static string maxErrorMessages             = "MaxErrorMessages";
        internal static string codeSenseDelay               = "CodeSenseDelay";
        internal static string enableAsyncCompletion        = "EnableAsyncCompletion";
        internal static string enableCommenting             = "EnableCommenting";
        internal static string enableFormatSelection        = "EnableFormatSelection";
        internal static string autoOutlining                = "AutoOutlining";
    }
}
