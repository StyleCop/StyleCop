
namespace StyleCop.Spelling
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading;

    internal sealed class SpellChecker : IDisposable
    {
        private sealed class Speller : IDisposable
        {
            [SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
            private IntPtr m_libraryHandle;

            private IntPtr m_id;

            private IntPtr[] m_lexicons;

            private PROOFTERMINATE m_terminate;

            private PROOFOPENLEX m_openLex;

            private PROOFCLOSELEX m_closeLex;

            private SPELLERCHECK m_check;

            private SPELLERADDUDR m_addUdr;

            private SPELLERDELUDR m_deleteUdr;

            private SPELLERCLEARUDR m_clearUdr;

            private IntPtr m_ignoredDictionary;

            internal Speller(string path)
            {
                this.m_libraryHandle = NativeMethods.LoadLibrary(path);
                if (this.m_libraryHandle == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }
                PROOFINIT proc = GetProc<PROOFINIT>(this.m_libraryHandle, "SpellerInit");
                PROOFSETOPTIONS proc2 = GetProc<PROOFSETOPTIONS>(this.m_libraryHandle, "SpellerSetOptions");
                this.m_terminate = GetProc<PROOFTERMINATE>(this.m_libraryHandle, "SpellerTerminate");
                this.m_openLex = GetProc<PROOFOPENLEX>(this.m_libraryHandle, "SpellerOpenLex");
                this.m_closeLex = GetProc<PROOFCLOSELEX>(this.m_libraryHandle, "SpellerCloseLex");
                this.m_check = GetProc<SPELLERCHECK>(this.m_libraryHandle, "SpellerCheck");
                this.m_addUdr = GetProc<SPELLERADDUDR>(this.m_libraryHandle, "SpellerAddUdr");
                this.m_deleteUdr = GetProc<SPELLERDELUDR>(this.m_libraryHandle, "SpellerDelUdr");
                this.m_clearUdr = GetProc<SPELLERCLEARUDR>(this.m_libraryHandle, "SpellerClearUdr");
                PROOFPARAMS pROOFPARAMS = default(PROOFPARAMS);
                pROOFPARAMS.VersionApi = 50331648u;
                IntPtr id;
                PTEC error = proc(out id, ref pROOFPARAMS);
                CheckErrorCode(error);
                this.m_id = id;
                error = proc2(id, 0u, 131078u);
                CheckErrorCode(error);
                this.InitIgnoreDictionary();
            }

            internal unsafe SpellerStatus Check(string word)
            {
                char* pwsz = stackalloc char[65];
                SPELLERSUGGESTION* prgsugg = stackalloc SPELLERSUGGESTION[checked(1 * sizeof(SPELLERSUGGESTION) / sizeof(SPELLERSUGGESTION))];

                fixed (IntPtr* lexicons = this.m_lexicons)
                {
                    WSIB wSIB = default(WSIB);
                    wSIB.pwsz = word;
                    wSIB.ichStart = 0u;
                    wSIB.cch = (UIntPtr)((ulong)(word.Length));
                    wSIB.cchUse = wSIB.cch;
                    wSIB.prglex = lexicons;
                    wSIB.clex = (UIntPtr)((ulong)((long)this.m_lexicons.Length));
                    wSIB.sstate = SpellerState.StartsSentence;
                    WSRB wSRB = default(WSRB);
                    wSRB.pwsz = pwsz;
                    wSRB.cchAlloc = 65u;
                    wSRB.cszAlloc = 1u;
                    wSRB.prgsugg = prgsugg;

                    PTEC error;
                    try
                    {
                        Monitor.Enter(this);
                        error = this.m_check(this.m_id, SPELLERCOMMAND.VerifyBuffer, ref wSIB, ref wSRB);
                    }
                    finally
                    {

                        Monitor.Exit(this);
                    }

                    CheckErrorCode(error);
                    return wSRB.sstat;
                }
            }

            internal void AddLexicon(ushort lcid, string path)
            {
                PROOFLEXIN pROOFLEXIN = default(PROOFLEXIN);
                pROOFLEXIN.pwszLex = path;
                pROOFLEXIN.lxt = PROOFLEXTYPE.Main;
                pROOFLEXIN.lidExpected = lcid;
                PROOFLEXOUT pROOFLEXOUT = default(PROOFLEXOUT);
                pROOFLEXOUT.cchCopyright = 0u;
                pROOFLEXOUT.fReadOnly = true;
                PTEC error = this.m_openLex(this.m_id, ref pROOFLEXIN, ref pROOFLEXOUT);
                CheckErrorCode(error);
                this.AddLexicon(pROOFLEXOUT.lex);
            }

            internal void AddIgnoredWord(string word)
            {
                PTEC error = this.m_addUdr(this.m_id, this.m_ignoredDictionary, word);
                CheckErrorCode(error);
            }

            internal void RemoveIgnoredWord(string word)
            {
                PTEC error = this.m_deleteUdr(this.m_id, this.m_ignoredDictionary, word);
                CheckErrorCode(error);
            }

            internal void ClearIgnoredWords()
            {
                PTEC error = this.m_clearUdr(this.m_id, this.m_ignoredDictionary);
                CheckErrorCode(error);
            }

            private void AddLexicon(IntPtr lex)
            {
                IntPtr[] array;
                int num;
                if (this.m_lexicons == null)
                {
                    array = new IntPtr[1];
                    num = 0;
                }
                else
                {
                    array = new IntPtr[this.m_lexicons.Length + 1];
                    this.m_lexicons.CopyTo(array, 0);
                    num = this.m_lexicons.Length;
                }
                array[num] = lex;
                this.m_lexicons = array;
            }

            ~Speller()
            {
                this.Dispose(false);
            }

            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }

            [SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
            private void Dispose(bool disposing)
            {
                try
                {
                    if (this.m_lexicons != null)
                    {
                        IntPtr[] lexicons = this.m_lexicons;
                        for (int i = 0; i < lexicons.Length; i++)
                        {
                            IntPtr lex = lexicons[i];
                            PTEC error = this.m_closeLex(this.m_id, lex, true);
                            CheckErrorCode(error);
                        }
                        this.m_lexicons = null;
                    }
                    if (this.m_id != IntPtr.Zero)
                    {
                        PTEC error2 = this.m_terminate(this.m_id, true);
                        CheckErrorCode(error2);
                        this.m_id = IntPtr.Zero;
                    }
                    if (this.m_libraryHandle != IntPtr.Zero)
                    {
                        if (!NativeMethods.FreeLibrary(this.m_libraryHandle))
                        {
                            throw new Win32Exception();
                        }
                        this.m_libraryHandle = IntPtr.Zero;
                    }
                }
                finally
                {
                    if (disposing)
                    {
                        this.m_terminate = null;
                        this.m_closeLex = null;
                        this.m_openLex = null;
                        this.m_check = null;
                        this.m_addUdr = null;
                        this.m_clearUdr = null;
                        this.m_deleteUdr = null;
                    }
                }
            }

            private void InitIgnoreDictionary()
            {
                SPELLERBUILTINUDR proc = GetProc<SpellChecker.SPELLERBUILTINUDR>(this.m_libraryHandle, "SpellerBuiltinUdr");
                this.m_ignoredDictionary = proc(this.m_id, PROOFLEXTYPE.User);
                if (this.m_ignoredDictionary == IntPtr.Zero)
                {
                    throw new InvalidOperationException("Failed to get the ignored dictionary handle.");
                }
            }

            private static T GetProc<T>(IntPtr library, string procName) where T : class
            {
                IntPtr procAddress = NativeMethods.GetProcAddress(library, procName);
                if (procAddress == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }
                return (T)((object)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(T)));
            }

            private static void CheckErrorCode(PTEC error)
            {
                if (!error.Succeeded)
                {
                    string format = "Unexpected proofing tool error code: {0}.";
                    string message = string.Format(CultureInfo.CurrentCulture, format, new object[] { error });
                    throw new InvalidOperationException(message);
                }
            }
        }

        private class Language
        {
            internal readonly string Name;

            internal readonly ushort LCID;

            internal readonly bool IsAvailable;

            internal readonly string LibraryFullPath;

            internal readonly string LexiconFullPath;

            internal Language(string name, string library, string lexicon, ushort lcid)
            {
                this.Name = name;
                this.LCID = lcid;
                this.LibraryFullPath = Probe(library);
                this.LexiconFullPath = Probe(lexicon);
                this.IsAvailable = (this.LibraryFullPath != null && this.LexiconFullPath != null);
            }

            private static string Probe(string library)
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string libraryPath = Path.Combine(baseDirectory, library);
                if (File.Exists(libraryPath))
                {
                    return libraryPath;
                }

                baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                libraryPath = Path.Combine(baseDirectory, library);
                if (File.Exists(libraryPath))
                {
                    return libraryPath;
                }

                return null;
            }
        }

        private static class NativeMethods
        {
            [DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Auto, SetLastError = true, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr LoadLibrary(string lpFileName);

            [DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool FreeLibrary(IntPtr hModule);
        }

        private struct PTEC
        {
            internal uint Code;

            public PTEC(uint code)
                : this()
            {
                Code = code;
            }

            internal PTEC_MAJOR Major
            {
                get
                {
                    return (PTEC_MAJOR)(this.Code & 255u);
                }
            }

            internal PTEC_MINOR Minor
            {
                get
                {
                    return (PTEC_MINOR)(this.Code >> 16);
                }
            }

            internal bool Succeeded
            {
                get
                {
                    return this.Code == 0u;
                }
            }

            public override string ToString()
            {
                string text = "0x" + this.Code.ToString("X", CultureInfo.InvariantCulture);
                text = text + " -- " + this.Major.ToString();
                if (this.Minor != (PTEC_MINOR)0u)
                {
                    text = text + ":" + this.Minor.ToString();
                }
                return text;
            }
        }

        private enum SpellerStatus
        {
            NoErrors,

            UnknownInputWord,

            ReturningChangeAlways,

            ReturningChangeOnce,

            InvalidHyphenation,

            ErrorCapitalization,

            WordConsideredAbbreviation,

            HyphenChangesSpelling,

            NoMoreSuggestions,

            MoreInfoThanBufferCouldHold,

            NoSentenceStartCap,

            RepeatWord,

            ExtraSpaces,

            MissingSpace,

            InitialNumeral,

            NoErrorsUDHit,

            ReturningAutoReplace,

            ErrorAccent
        }

        private enum PTEC_MAJOR : uint
        {
            NoErrors,

            OOM,

            ModuleError,

            IOErrorMainLex,

            IOErrorUserLex,

            NotSupported,

            BufferTooSmall,

            NotFound,

            ModuleNotLoaded
        }

        private enum PTEC_MINOR : uint
        {
            ModuleAlreadyBusy = 128u,

            InvalidID,

            InvalidWsc,

            InvalidMainLex,

            InvalidUserLex,

            InvalidCmd,

            InvalidFormat,

            OperNotMatchedUserLex,

            FileRead,

            FileWrite,

            FileCreate,

            FileShare,

            ModuleNotTerminated,

            UserLexFull,

            InvalidEntry,

            EntryTooLong,

            MainLexCountExceeded,

            UserLexCountExceeded,

            FileOpenError,

            FileTooLargeError,

            UserLexReadOnly,

            ProtectModeOnly,

            InvalidLanguage
        }

        private enum PROOFLEXTYPE : uint
        {
            ChangeOnce,

            ChangeAlways,

            User,

            Exclude,

            Main,

            SysUdr,

            Max,

            IgnoreAlways = 2u
        }

        private enum SPELLERCOMMAND : uint
        {
            VerifyBuffer = 2u,

            Suggest,

            SuggestMore,

            Wildcard = 6u,

            Anagram,

            VerifyBufferAutoReplace = 10u
        }

        [Flags]
        private enum SpellerState : uint
        {
            IsContinued = 1u,

            StartsSentence = 2u,

            IsEditedChange = 4u,

            NoStateInfo = 0u
        }

        private enum SPELLEROPTIONSELECT : uint
        {
            Bits,

            PossibleBits,

            AutoReplace
        }

        [Flags]
        private enum SpellingOptions : uint
        {
            SuggestFromUserLex = 1u,

            IgnoreAllCaps = 2u,

            IgnoreMixedDigits = 4u,

            IgnoreRomanNumerals = 8u,

            FindRepeatWord = 64u,

            RateSuggestions = 1024u,

            FindInitialNumerals = 2048u,

            SglStepSugg = 65536u,

            IgnoreSingleLetter = 131072u,

            IgnoreInitialCap = 262144u,

            LangMode = 4026531840u,

            HebrewFullScript = 0u,

            HebrewPartialScript = 268435456u,

            HebrewMixedScript = 536870912u,

            HebrewMixedAuthorizedScript = 805306368u,

            FrenchDialectDefault = 0u,

            FrenchUnaccentedUppercase = 268435456u,

            FrenchAccentedUppercase = 536870912u,

            RussianDialectDefault = 0u,

            RussianIE = 268435456u,

            RussianIO = 536870912u,

            KoreanNoAuxCombine = 268435456u,

            KoreanNoMissSpellDictSearch = 536870912u,

            KoreanNoCompoundNounProc = 1073741824u,

            KoreanDefault = 0u,

            GermanUsePrereform = 268435456u,

            ArabicNone = 0u,

            ArabicStrictAlefHamza = 268435456u,

            ArabicStrictFinalYaa = 536870912u,

            ArabicBothStrict = 805306368u
        }

        private struct PROOFPARAMS
        {
            internal uint VersionApi;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct PROOFLEXIN
        {
            internal string pwszLex;

            internal bool fCreate;

            internal PROOFLEXTYPE lxt;

            internal ushort lidExpected;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct PROOFLEXOUT
        {
            internal string pwszCopyright;

            internal IntPtr lex;

            internal uint cchCopyright;

            internal uint version;

            internal bool fReadOnly;

            internal ushort lid;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct WSIB
        {
            internal string pwsz;

            internal unsafe IntPtr* prglex;

            internal UIntPtr cch;

            internal UIntPtr clex;

            internal SpellerState sstate;

            internal uint ichStart;

            internal UIntPtr cchUse;
        }

        private struct SPELLERSUGGESTION
        {
            internal unsafe char* pwsz;

            internal uint ichSugg;

            internal uint cchSugg;

            internal uint iRating;

            public unsafe SPELLERSUGGESTION(uint ichSugg, uint cchSugg, uint iRating, char* pwsz)
                : this()
            {
                this.ichSugg = ichSugg;
                this.cchSugg = cchSugg;
                this.iRating = iRating;
                this.pwsz = pwsz;
            }
        }

        private struct WSRB
        {
            internal unsafe char* pwsz;

            internal unsafe SpellChecker.SPELLERSUGGESTION* prgsugg;

            internal uint ichError;

            internal uint cchError;

            internal uint ichProcess;

            internal uint cchProcess;

            internal SpellerStatus sstat;

            internal uint csz;

            internal uint cszAlloc;

            internal uint cchMac;

            internal uint cchAlloc;

            public WSRB(uint ichError, uint cchError, uint ichProcess, uint cchProcess, SpellerStatus sstat, uint csz, uint cchMac)
                : this()
            {
                this.ichError = ichError;
                this.cchError = cchError;
                this.ichProcess = ichProcess;
                this.cchProcess = cchProcess;
                this.sstat = sstat;
                this.csz = csz;
                this.cchMac = cchMac;
            }
        }

        private delegate PTEC PROOFINIT(out IntPtr pid, ref PROOFPARAMS pxpar);

        private delegate PTEC PROOFTERMINATE(IntPtr id, bool fForce);

        private delegate PTEC PROOFSETOPTIONS(IntPtr id, uint iOptionSelect, uint iOptVal);

        private delegate PTEC PROOFOPENLEX(IntPtr id, ref PROOFLEXIN plxin, ref PROOFLEXOUT plxout);

        private delegate PTEC PROOFCLOSELEX(IntPtr id, IntPtr lex, bool force);

        private delegate PTEC SPELLERCHECK(IntPtr sid, SPELLERCOMMAND scmd, ref WSIB psib, ref WSRB psrb);

        private delegate PTEC SPELLERADDUDR(IntPtr sid, IntPtr lex, [MarshalAs(UnmanagedType.LPTStr)] string add);

        private delegate PTEC SPELLERDELUDR(IntPtr sid, IntPtr lex, [MarshalAs(UnmanagedType.LPTStr)] string delete);

        private delegate PTEC SPELLERCLEARUDR(IntPtr sid, IntPtr lex);

        private delegate IntPtr SPELLERBUILTINUDR(IntPtr sid, PROOFLEXTYPE lxt);

        internal const int MAX_TEXT_LENGTH = 64;

        private const SpellingOptions s_spellingOptions = SpellingOptions.IgnoreAllCaps | SpellingOptions.IgnoreMixedDigits | SpellingOptions.IgnoreSingleLetter;

        private const uint MAJOR_VERSION = 3u;

        private const uint MINOR_VERSION = 0u;

        private const uint BUILD_NO = 0u;

        private const uint PROOFTHISAPIVERSION = 50331648u;

        private readonly int dependantFilesHashCode;

        private static SpellChecker.Language[] s_languages = new[]
            {
                new Language("ar", "mssp3ar.dll", "mssp3ar.lex", 3073), new Language("cs", "mssp3cz.dll", "mssp3cz.lex", 1029),
                new Language("da", "mssp3da.dll", "mssp3da.lex", 1030), new Language("de", "mssp3ge.dll", "mssp3geP.lex", 1031),
                new Language("en", "msspell3.dll", "mssp3en.lex", 1033), new Language("en-us", "msspell3.dll", "mssp3en.lex", 1033),
                new Language("en-gb", "msspell3.dll", "mssp3en.lex", 2057), new Language("en-au", "msspell3.dll", "mssp3ena.lex", 3081),
                new Language("en-ca", "msspell3.dll", "mssp3en.lex", 4105), new Language("en-nz", "msspell3.dll", "mssp3en.lex", 2057),
                new Language("es", "mssp3es.dll", "mssp3es.lex", 3082), new Language("fi", "mssp3fi.dll", "mssp3fi.lex", 1035),
                new Language("fr", "mssp3fr.dll", "mssp3fr.lex", 1036), new Language("gl", "mssp3gl.dll", "mssp3gl.lex", 1110),
                new Language("he", "mssp3hb.dll", "mssp3hb.lex", 1037), new Language("id", "mssp3in.dll", "mssp3in.lex", 1057),
                new Language("it", "mssp3it.dll", "mssp3it.lex", 1040), new Language("ko", "mssp3ko.dll", "mssp3ko.lex", 1042),
                new Language("lt", "mssp3lt.dll", "mssp3lt.lex", 0), new Language("nl", "mssp3nl.dll", "mssp3nl.lex", 1043),
                new Language("nb", "mssp3nb.dll", "mssp3nb.lex", 1044), new Language("nn", "mssp3no.dll", "mssp3no.lex", 2068),
                new Language("pl", "mssp3pl.dll", "mssp3pl.lex", 1045), new Language("pt", "mssp3pt.dll", "mssp3pt.lex", 2070),
                new Language("pt-br", "mssp3pb.dll", "mssp3pb.lex", 1046), new Language("ro", "mssp3ro.dll", "mssp3ro.lex", 0),
                new Language("ru", "mssp3ru.dll", "mssp3ru.lex", 1049), new Language("sv", "mssp3sw.dll", "mssp3sw.lex", 1053),
                new Language("tr", "mssp3tr.dll", "mssp3tr.lex", 1055), new Language("uk", "mssp3ua.dll", "mssp3ua.lex", 1058)
            };

        private static Dictionary<string, Language> s_languageTable = BuildLanguageTable();

        private Speller m_speller;

        private WordCollection m_ignoredWords;

        private WordCollection m_alwaysMisspelledWords;

        private readonly CultureInfo m_culture;

        private Dictionary<string, WordSpelling> m_wordSpellingCache = new Dictionary<string, WordSpelling>();

        public WordCollection AlwaysMisspelledWords
        {
            get
            {
                if (this.m_alwaysMisspelledWords == null)
                {
                    this.m_alwaysMisspelledWords = new WordCollection(StringComparer.Create(this.m_culture, false));
                }
                return this.m_alwaysMisspelledWords;
            }
        }

        public WordCollection IgnoredWords
        {
            get
            {
                if (this.m_ignoredWords == null)
                {
                    this.m_ignoredWords = new WordCollection(StringComparer.Create(this.m_culture, false));
                    this.m_ignoredWords.CollectionChanged += new CollectionChangeEventHandler(this.OnIgnoredWordsChanged);
                }
                return this.m_ignoredWords;
            }
        }

        private bool IsDisposed
        {
            get
            {
                return this.m_speller == null;
            }
        }

        private SpellChecker(CultureInfo culture, SpellChecker.Language language)
        {
            this.m_culture = culture;
            this.m_speller = new SpellChecker.Speller(language.LibraryFullPath);
            this.m_speller.AddLexicon(language.LCID, language.LexiconFullPath);

            var libraryTimestamp = File.GetLastWriteTime(language.LibraryFullPath);
            var lexiconTimestamp = File.GetLastWriteTime(language.LexiconFullPath);

            this.dependantFilesHashCode =
                string.Concat(libraryTimestamp.ToString(CultureInfo.InvariantCulture), lexiconTimestamp.ToString(CultureInfo.InvariantCulture)).GetHashCode();
        }

        public static SpellChecker FromCulture(CultureInfo culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException("culture");
            }
            if (culture.Equals(CultureInfo.InvariantCulture))
            {
                return null;
            }

            Language language;
            if (s_languageTable.TryGetValue(culture.Name, out language) && language.IsAvailable)
            {
                return new SpellChecker(culture, language);
            }

            return FromCulture(culture.Parent);
        }

        public int GetDependantFilesHashCode()
        {
            return this.dependantFilesHashCode;
        }

        public WordSpelling Check(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (this.IsDisposed)
            {
                throw new ObjectDisposedException("SpellChecker");
            }

            if (text.Length == 0)
            {
                return WordSpelling.SpelledCorrectly;
            }

            if (this.m_alwaysMisspelledWords != null && this.m_alwaysMisspelledWords.Contains(text))
            {
                return WordSpelling.Unrecognized;
            }

            WordSpelling wordSpelling;
            lock (this.m_wordSpellingCache)
            {
                if (this.m_wordSpellingCache.TryGetValue(text, out wordSpelling))
                {
                    return wordSpelling;
                }
                SpellerStatus spellerStatus = this.m_speller.Check(text);

                if (spellerStatus == SpellerStatus.NoErrors)
                {
                    wordSpelling = WordSpelling.SpelledCorrectly;
                }
                else
                {
                    wordSpelling = spellerStatus == SpellerStatus.ErrorCapitalization ? WordSpelling.CasedIncorrectly : WordSpelling.Unrecognized;
                }

                this.m_wordSpellingCache[text] = wordSpelling;
            }
            return wordSpelling;
        }

        public void Dispose()
        {
            try
            {
                if (this.m_speller != null)
                {
                    this.m_speller.Dispose();
                }
            }
            finally
            {
                this.m_speller = null;
                this.m_wordSpellingCache = null;
            }
        }

        private void OnIgnoredWordsChanged(object sender, CollectionChangeEventArgs e)
        {
            if (this.IsDisposed)
            {
                return;
            }
            switch (e.Action)
            {
                case CollectionChangeAction.Add:
                    this.m_speller.AddIgnoredWord((string)e.Element);
                    return;
                case CollectionChangeAction.Remove:
                    this.m_speller.RemoveIgnoredWord((string)e.Element);
                    return;
                case CollectionChangeAction.Refresh:
                    this.m_speller.ClearIgnoredWords();
                    return;
                default:
                    return;
            }
        }

        private static Dictionary<string, Language> BuildLanguageTable()
        {
            Dictionary<string, Language> dictionary = new Dictionary<string, Language>(s_languages.Length, StringComparer.OrdinalIgnoreCase);

            Language[] array = s_languages;
            foreach (Language language in array)
            {
                dictionary.Add(language.Name, language);
            }

            return dictionary;
        }
    }
}
