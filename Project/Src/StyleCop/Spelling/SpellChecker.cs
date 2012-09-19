// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpellChecker.cs" company="http://stylecop.codeplex.com">
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
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.Spelling
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;

    internal sealed class SpellChecker : IDisposable
    {
        #region Constants

        internal const int MaximumTextLength = 0x40;

        #endregion

        #region Static Fields

        private static readonly Language[] Languages = new[]
            {
                new Language("ar", "mssp7ar.dll", "mssp7ar.lex", 0xc01), new Language("cs", "mssp7cz.dll", "mssp7cz.lex", 0x405),
                new Language("da", "mssp7da.dll", "mssp7da.lex", 0x406), new Language("de", "mssp7ge.dll", "mssp7geP.lex", 0x407),
                new Language("en", "mssp7en.dll", "mssp7en.lex", 0x409), new Language("en-us", "mssp7en.dll", "mssp7en.lex", 0x409),
                new Language("en-gb", "mssp7en.dll", "mssp7en.lex", 0x809), new Language("en-au", "mssp7en.dll", "mssp7en.lex", 0xc09),
                new Language("en-ca", "mssp7en.dll", "mssp7en.lex", 0x1009), new Language("en-nz", "mssp7en.dll", "mssp7en.lex", 0x809),
                new Language("es", "mssp7es.dll", "mssp7es.lex", 0xc0a), new Language("fi", "mssp7fi.dll", "mssp7fi.lex", 0x40b),
                new Language("fr", "mssp7fr.dll", "mssp7fr.lex", 0x40c), new Language("gl", "mssp7gl.dll", "mssp7gl.lex", 0x456),
                new Language("he", "mssp7hb.dll", "mssp7hb.lex", 0x40d), new Language("id", "mssp7in.dll", "mssp7in.lex", 0x421),
                new Language("it", "mssp7it.dll", "mssp7it.lex", 0x410), new Language("ko", "mssp7ko.dll", "mssp7ko.lex", 0x412),
                new Language("lt", "mssp7lt.dll", "mssp7lt.lex", 0), new Language("nl", "mssp7nl.dll", "mssp7nl.lex", 0x413),
                new Language("nb", "mssp7nb.dll", "mssp7nb.lex", 0x414), new Language("nn", "mssp7no.dll", "mssp7no.lex", 0x814),
                new Language("pl", "mssp7pl.dll", "mssp7pl.lex", 0x415), new Language("pt", "mssp7pt.dll", "mssp7pt.lex", 0x816),
                new Language("pt-br", "mssp7pb.dll", "mssp7pb.lex", 0x416), new Language("ro", "mssp7ro.dll", "mssp7ro.lex", 0),
                new Language("ru", "mssp7ru.dll", "mssp7ru.lex", 0x419), new Language("sv", "mssp7sw.dll", "mssp7sw.lex", 0x41d),
                new Language("tr", "mssp7tr.dll", "mssp7tr.lex", 0x41f), new Language("uk", "mssp7ua.dll", "mssp7ua.lex", 0x422)
            };

        private static readonly TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;

        // The Languages array above needs to be initialized before this static executes.
        private static Dictionary<string, Language> languageTable = BuildLanguageTable();

        #endregion

        #region Fields

        private readonly CultureInfo culture;

        private readonly int dependantFilesHashCode;

        private WordCollection alwaysMisspelledWords;

        private WordCollection ignoredWords;

        private Speller speller;

        private Dictionary<string, WordSpelling> wordSpellingCache = new Dictionary<string, WordSpelling>();

        #endregion

        #region Constructors and Destructors

        private SpellChecker(CultureInfo culture, Language language)
        {
            this.culture = culture;
            this.speller = new Speller(language.LibraryFullPath);
            this.speller.AddLexicon(language.Lcid, language.LexiconFullPath);

            var libraryTimestamp = File.GetLastWriteTime(language.LibraryFullPath);
            var lexiconTimestamp = File.GetLastWriteTime(language.LexiconFullPath);

            this.dependantFilesHashCode =
                string.Concat(libraryTimestamp.ToString(CultureInfo.InvariantCulture), lexiconTimestamp.ToString(CultureInfo.InvariantCulture)).GetHashCode();
        }

        #endregion

        #region Delegates

        private delegate PTEC PROOFCLOSELEX(IntPtr id, IntPtr lex, bool force);

        private delegate PTEC PROOFINIT(out IntPtr pid, ref PROOFPARAMS pxpar);

        private delegate PTEC PROOFOPENLEX(IntPtr id, ref PROOFLEXIN plxin, ref PROOFLEXOUT plxout);

        private delegate PTEC PROOFSETOPTIONS(IntPtr id, uint iOptionSelect, uint iOptVal);

        private delegate PTEC PROOFTERMINATE(IntPtr id, bool fForce);

        private delegate PTEC SPELLERADDUDR(IntPtr sid, IntPtr lex, [MarshalAs(UnmanagedType.LPTStr)] string add);

        private delegate IntPtr SPELLERBUILTINUDR(IntPtr sid, PROOFLEXTYPE lxt);

        private delegate PTEC SPELLERCHECK(IntPtr sid, SPELLERCOMMAND scmd, ref WSIB psib, ref WSRB psrb);

        private delegate PTEC SPELLERCLEARUDR(IntPtr sid, IntPtr lex);

        private delegate PTEC SPELLERDELUDR(IntPtr sid, IntPtr lex, [MarshalAs(UnmanagedType.LPTStr)] string delete);

        #endregion

        #region Enums

        private enum PROOFLEXTYPE : uint
        {
            ChangeAlways = 1,

            ChangeOnce = 0,

            Exclude = 3,

            IgnoreAlways = 2,

            Main = 4,

            Max = 6,

            SysUdr = 5,

            User = 2
        }

        private enum PTEC_MAJOR : uint
        {
            BufferTooSmall = 6,

            IOErrorMainLex = 3,

            IOErrorUserLex = 4,

            ModuleError = 2,

            ModuleNotLoaded = 8,

            NoErrors = 0,

            NotFound = 7,

            NotSupported = 5,

            OOM = 1
        }

        private enum PTEC_MINOR : uint
        {
            EntryTooLong = 0x8f,

            FileCreate = 0x8a,

            FileOpenError = 0x92,

            FileRead = 0x88,

            FileShare = 0x8b,

            FileTooLargeError = 0x93,

            FileWrite = 0x89,

            InvalidCmd = 0x85,

            InvalidEntry = 0x8e,

            InvalidFormat = 0x86,

            InvalidID = 0x81,

            InvalidLanguage = 150,

            InvalidMainLex = 0x83,

            InvalidUserLex = 0x84,

            InvalidWsc = 130,

            MainLexCountExceeded = 0x90,

            ModuleAlreadyBusy = 0x80,

            ModuleNotTerminated = 140,

            OperNotMatchedUserLex = 0x87,

            ProtectModeOnly = 0x95,

            UserLexCountExceeded = 0x91,

            UserLexFull = 0x8d,

            UserLexReadOnly = 0x94
        }

        private enum SPELLERCOMMAND : uint
        {
            Anagram = 7,

            Suggest = 3,

            SuggestMore = 4,

            VerifyBuffer = 2,

            VerifyBufferAutoReplace = 10,

            Wildcard = 6
        }

        private enum SPELLEROPTIONSELECT : uint
        {
            AutoReplace = 2,

            Bits = 0,

            PossibleBits = 1
        }

        [Flags]
        private enum SpellerState : uint
        {
            IsContinued = 1,

            IsEditedChange = 4,

            NoStateInfo = 0,

            StartsSentence = 2
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

        [Flags]
        private enum SpellingOptions : uint
        {
            ArabicBothStrict = 0x30000000,

            ArabicNone = 0,

            ArabicStrictAlefHamza = 0x10000000,

            ArabicStrictFinalYaa = 0x20000000,

            FindInitialNumerals = 0x800,

            FindRepeatWord = 0x40,

            FrenchAccentedUppercase = 0x20000000,

            FrenchDialectDefault = 0,

            FrenchUnaccentedUppercase = 0x10000000,

            GermanUsePrereform = 0x10000000,

            HebrewFullScript = 0,

            HebrewMixedAuthorizedScript = 0x30000000,

            HebrewMixedScript = 0x20000000,

            HebrewPartialScript = 0x10000000,

            IgnoreAllCaps = 2,

            IgnoreInitialCap = 0x40000,

            IgnoreMixedDigits = 4,

            IgnoreRomanNumerals = 8,

            IgnoreSingleLetter = 0x20000,

            KoreanDefault = 0,

            KoreanNoAuxCombine = 0x10000000,

            KoreanNoCompoundNounProc = 0x40000000,

            KoreanNoMissSpellDictSearch = 0x20000000,

            LangMode = 0xf0000000,

            RateSuggestions = 0x400,

            RussianDialectDefault = 0,

            RussianIE = 0x10000000,

            RussianIO = 0x20000000,

            SglStepSugg = 0x10000,

            SuggestFromUserLex = 1
        }

        #endregion

        #region Public Properties

        public WordCollection AlwaysMisspelledWords
        {
            get
            {
                if (this.alwaysMisspelledWords == null)
                {
                    this.alwaysMisspelledWords = new WordCollection(StringComparer.Create(this.culture, false));
                }

                return this.alwaysMisspelledWords;
            }
        }

        public WordCollection IgnoredWords
        {
            get
            {
                if (this.ignoredWords == null)
                {
                    this.ignoredWords = new WordCollection(StringComparer.Create(this.culture, false));
                    this.ignoredWords.CollectionChanged += new CollectionChangeEventHandler(this.OnIgnoredWordsChanged);
                }

                return this.ignoredWords;
            }
        }

        #endregion

        #region Properties

        private bool IsDisposed
        {
            get
            {
                return this.speller == null;
            }
        }

        #endregion

        #region Public Methods and Operators

        public static SpellChecker FromCulture(CultureInfo culture)
        {
            Language language;
            if (culture == null)
            {
                throw new ArgumentNullException("culture");
            }

            if (culture.Equals(CultureInfo.InvariantCulture))
            {
                return null;
            }

            if (languageTable.TryGetValue(culture.Name, out language) && language.IsAvailable)
            {
                return new SpellChecker(culture, language);
            }

            return FromCulture(culture.Parent);
        }

        public WordSpelling Check(string text)
        {
            WordSpelling spelledCorrectly;
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

            if ((this.alwaysMisspelledWords != null) && this.alwaysMisspelledWords.Contains(text))
            {
                return WordSpelling.Unrecognized;
            }

            lock (this.wordSpellingCache)
            {
                if (this.wordSpellingCache.TryGetValue(text, out spelledCorrectly))
                {
                    return spelledCorrectly;
                }

                SpellerStatus status = this.speller.Check(text);
                if (status != SpellerStatus.NoErrors)
                {
                    status = this.speller.Check(UsaTextInfo.ToTitleCase(text));
                }

                if (status == SpellerStatus.NoErrors)
                {
                    spelledCorrectly = WordSpelling.SpelledCorrectly;
                }
                else
                {
                    spelledCorrectly = WordSpelling.Unrecognized;
                }

                this.wordSpellingCache[text] = spelledCorrectly;
            }

            return spelledCorrectly;
        }

        public void Dispose()
        {
            try
            {
                if (this.speller != null)
                {
                    this.speller.Dispose();
                }
            }
            finally
            {
                this.speller = null;
                this.wordSpellingCache = null;
            }
        }

        public int GetDependantFilesHashCode()
        {
            return this.dependantFilesHashCode;
        }

        #endregion

        #region Methods

        private static Dictionary<string, Language> BuildLanguageTable()
        {
            Dictionary<string, Language> dictionary = new Dictionary<string, Language>(Languages.Length, StringComparer.OrdinalIgnoreCase);
            foreach (Language language in Languages)
            {
                dictionary.Add(language.Name, language);
            }

            return dictionary;
        }

        private void OnIgnoredWordsChanged(object sender, CollectionChangeEventArgs e)
        {
            if (!this.IsDisposed)
            {
                switch (e.Action)
                {
                    case CollectionChangeAction.Add:
                        this.speller.AddIgnoredWord((string)e.Element);
                        return;

                    case CollectionChangeAction.Remove:
                        this.speller.RemoveIgnoredWord((string)e.Element);
                        return;

                    case CollectionChangeAction.Refresh:
                        this.speller.ClearIgnoredWords();
                        return;
                }
            }
        }

        #endregion

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct PROOFLEXIN
        {
            internal string pwszLex;

            internal bool fCreate;

            internal SpellChecker.PROOFLEXTYPE lxt;

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

        [StructLayout(LayoutKind.Sequential)]
        private struct PROOFPARAMS
        {
            internal uint VersionApi;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PTEC
        {
            internal uint Code;

            internal PTEC_MAJOR Major
            {
                get
                {
                    return ((PTEC_MAJOR)this.Code) & ((PTEC_MAJOR)0xff);
                }
            }

            internal PTEC_MINOR Minor
            {
                get
                {
                    return (PTEC_MINOR)(this.Code >> 0x10);
                }
            }

            internal bool Succeeded
            {
                get
                {
                    return this.Code == 0;
                }
            }

            public override string ToString()
            {
                string str = ("0x" + this.Code.ToString("X", CultureInfo.InvariantCulture)) + " -- " + this.Major.ToString();
                if (this.Minor != 0)
                {
                    str = str + ":" + this.Minor.ToString();
                }

                return str;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SPELLERSUGGESTION
        {
            internal unsafe char* pwsz;

            internal uint ichSugg;

            internal uint cchSugg;

            internal uint iRating;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct WSIB
        {
            internal string pwsz;

            internal unsafe IntPtr* prglex;

            internal UIntPtr cch;

            internal UIntPtr clex;

            internal SpellChecker.SpellerState sstate;

            internal uint ichStart;

            internal UIntPtr cchUse;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WSRB
        {
            internal unsafe char* pwsz;

            internal unsafe SpellChecker.SPELLERSUGGESTION* prgsugg;

            internal uint ichError;

            internal uint cchError;

            internal uint ichProcess;

            internal uint cchProcess;

            internal SpellChecker.SpellerStatus sstat;

            internal uint csz;

            internal uint cszAlloc;

            internal uint cchMac;

            internal uint cchAlloc;
        }

        private static class NativeMethods
        {
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool FreeLibrary(IntPtr hModule);

            [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
            internal static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern IntPtr LoadLibrary(string lpFileName);
        }

        private class Language
        {
            #region Fields

            internal readonly bool IsAvailable;

            internal readonly ushort Lcid;

            internal readonly string LexiconFullPath;

            internal readonly string LibraryFullPath;

            internal readonly string Name;

            #endregion

            #region Constructors and Destructors

            internal Language(string name, string library, string lexicon, ushort lcid)
            {
                this.Name = name;
                this.Lcid = lcid;
                this.LibraryFullPath = Probe(library);
                this.LexiconFullPath = Probe(lexicon);

                if (this.LibraryFullPath != null && this.LexiconFullPath != null)
                {
                    IntPtr handle = NativeMethods.LoadLibrary(this.LibraryFullPath);

                    if (handle == IntPtr.Zero)
                    {
                        this.IsAvailable = false;
                    }
                    else
                    {
                        this.IsAvailable = true;
                        if (!NativeMethods.FreeLibrary(handle))
                        {
                            throw new Win32Exception();
                        }
                    }
                }
            }

            #endregion

            #region Methods

            private static string Probe(string library)
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string libraryPath = Path.Combine(baseDirectory, library);
                if (File.Exists(libraryPath))
                {
                    return libraryPath;
                }

                baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (baseDirectory == null)
                {
                    return null;
                }

                libraryPath = Path.Combine(baseDirectory, library);
                if (File.Exists(libraryPath))
                {
                    return libraryPath;
                }

                return null;
            }

            #endregion
        }

        private sealed class Speller : IDisposable
        {
            #region Fields

            private SPELLERADDUDR addUdr;

            private SPELLERCHECK check;

            private SPELLERCLEARUDR clearUdr;

            private PROOFCLOSELEX closeLex;

            private SPELLERDELUDR deleteUdr;

            private IntPtr id;

            private IntPtr ignoredDictionary;

            private IntPtr[] lexicons;

            private IntPtr libraryHandle;

            private PROOFOPENLEX openLex;

            private PROOFTERMINATE terminate;

            #endregion

            #region Constructors and Destructors

            internal Speller(string path)
            {
                IntPtr ptr;
                this.libraryHandle = NativeMethods.LoadLibrary(path);
                if (this.libraryHandle == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }

                PROOFINIT proc = GetProc<PROOFINIT>(this.libraryHandle, "SpellerInit");
                PROOFSETOPTIONS proofsetoptions = GetProc<PROOFSETOPTIONS>(this.libraryHandle, "SpellerSetOptions");
                this.terminate = GetProc<PROOFTERMINATE>(this.libraryHandle, "SpellerTerminate");
                this.openLex = GetProc<PROOFOPENLEX>(this.libraryHandle, "SpellerOpenLex");
                this.closeLex = GetProc<PROOFCLOSELEX>(this.libraryHandle, "SpellerCloseLex");
                this.check = GetProc<SPELLERCHECK>(this.libraryHandle, "SpellerCheck");
                this.addUdr = GetProc<SPELLERADDUDR>(this.libraryHandle, "SpellerAddUdr");
                this.deleteUdr = GetProc<SPELLERDELUDR>(this.libraryHandle, "SpellerDelUdr");
                this.clearUdr = GetProc<SPELLERCLEARUDR>(this.libraryHandle, "SpellerClearUdr");
                PROOFPARAMS pxpar = new PROOFPARAMS { VersionApi = 0x3000000 };
                CheckErrorCode(proc(out ptr, ref pxpar));
                this.id = ptr;
                CheckErrorCode(proofsetoptions(ptr, 0, 0x20006));
                this.InitIgnoreDictionary();
            }

            ~Speller()
            {
                this.Dispose(false);
            }

            #endregion

            #region Public Methods and Operators

            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }

            #endregion

            #region Methods

            internal void AddIgnoredWord(string word)
            {
                CheckErrorCode(this.addUdr(this.id, this.ignoredDictionary, word));
            }

            internal void AddLexicon(ushort lcid, string path)
            {
                PROOFLEXIN plxin = new PROOFLEXIN { pwszLex = path, lxt = PROOFLEXTYPE.Main, lidExpected = lcid };
                PROOFLEXOUT plxout = new PROOFLEXOUT { cchCopyright = 0, fReadOnly = true };
                CheckErrorCode(this.openLex(this.id, ref plxin, ref plxout));
                this.AddLexicon(plxout.lex);
            }

            internal unsafe SpellerStatus Check(string word)
            {
                char* pwsz = stackalloc char[65];
                SPELLERSUGGESTION* prgsugg = stackalloc SPELLERSUGGESTION[checked(1 * sizeof(SPELLERSUGGESTION) / sizeof(SPELLERSUGGESTION))];

                fixed (IntPtr* lexicons2 = this.lexicons)
                {
                    WSIB wSib = default(WSIB);
                    wSib.pwsz = word;
                    wSib.ichStart = 0u;
                    wSib.cch = (UIntPtr)((ulong)word.Length);
                    wSib.cchUse = wSib.cch;
                    wSib.prglex = lexicons2;
                    wSib.clex = (UIntPtr)((ulong)this.lexicons.Length);
                    wSib.sstate = SpellerState.StartsSentence;

                    WSRB wSrb = default(WSRB);
                    wSrb.pwsz = pwsz;
                    wSrb.cchAlloc = 65u;
                    wSrb.cszAlloc = 1u;
                    wSrb.prgsugg = prgsugg;

                    PTEC error;
                    lock (this)
                    {
                        error = this.check(this.id, SPELLERCOMMAND.VerifyBuffer, ref wSib, ref wSrb);
                    }

                    CheckErrorCode(error);
                    return wSrb.sstat;
                }
            }

            internal void ClearIgnoredWords()
            {
                CheckErrorCode(this.clearUdr(this.id, this.ignoredDictionary));
            }

            internal void RemoveIgnoredWord(string word)
            {
                CheckErrorCode(this.deleteUdr(this.id, this.ignoredDictionary, word));
            }

            private static void CheckErrorCode(SpellChecker.PTEC error)
            {
                if (!error.Succeeded)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Unexpected proofing tool error code: {0}.", new object[] { error }));
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

            private void AddLexicon(IntPtr lex)
            {
                IntPtr[] ptrArray;
                int length;
                if (this.lexicons == null)
                {
                    ptrArray = new IntPtr[1];
                    length = 0;
                }
                else
                {
                    ptrArray = new IntPtr[this.lexicons.Length + 1];
                    this.lexicons.CopyTo(ptrArray, 0);
                    length = this.lexicons.Length;
                }

                ptrArray[length] = lex;
                this.lexicons = ptrArray;
            }

            private void Dispose(bool disposing)
            {
                try
                {
                    if (this.lexicons != null)
                    {
                        foreach (IntPtr ptr in this.lexicons)
                        {
                            CheckErrorCode(this.closeLex(this.id, ptr, true));
                        }

                        this.lexicons = null;
                    }

                    if (this.id != IntPtr.Zero)
                    {
                        CheckErrorCode(this.terminate(this.id, true));
                        this.id = IntPtr.Zero;
                    }

                    if (this.libraryHandle != IntPtr.Zero)
                    {
                        if (!NativeMethods.FreeLibrary(this.libraryHandle))
                        {
                            throw new Win32Exception();
                        }

                        this.libraryHandle = IntPtr.Zero;
                    }
                }
                finally
                {
                    if (disposing)
                    {
                        this.terminate = null;
                        this.closeLex = null;
                        this.openLex = null;
                        this.check = null;
                        this.addUdr = null;
                        this.clearUdr = null;
                        this.deleteUdr = null;
                    }
                }
            }

            private void InitIgnoreDictionary()
            {
                SPELLERBUILTINUDR proc = GetProc<SPELLERBUILTINUDR>(this.libraryHandle, "SpellerBuiltinUdr");
                this.ignoredDictionary = proc(this.id, PROOFLEXTYPE.User);
                if (this.ignoredDictionary == IntPtr.Zero)
                {
                    throw new InvalidOperationException("Failed to get the ignored dictionary handle.");
                }
            }

            #endregion
        }
    }
}