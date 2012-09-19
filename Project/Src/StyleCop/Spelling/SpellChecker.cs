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
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;

    internal sealed class SpellChecker : IDisposable
    {

        public int GetDependantFilesHashCode()
        {
            return this.dependantFilesHashCode;
        }

        private readonly int dependantFilesHashCode;
        
        private WordCollection alwaysMisspelledWords;

        private readonly CultureInfo culture;

        private WordCollection ignoredWords;

        private Speller speller;

        private Dictionary<string, WordSpelling> wordSpellingCache = new Dictionary<string, WordSpelling>();
        
        internal const int MaximumTextLength = 0x40;
        
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

        private static readonly Dictionary<string, Language> LanguageTable = BuildLanguageTable();

        private static readonly TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;

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

        private static Dictionary<string, Language> BuildLanguageTable()
        {
            Dictionary<string, Language> dictionary = new Dictionary<string, Language>(Languages.Length, StringComparer.OrdinalIgnoreCase);
            foreach (Language language in Languages)
            {
                dictionary.Add(language.Name, language);
            }
            return dictionary;
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

            if (LanguageTable.TryGetValue(culture.Name, out language) && language.IsAvailable)
            {
                return new SpellChecker(culture, language);
            }

            return FromCulture(culture.Parent);
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

        private bool IsDisposed
        {
            get
            {
                return (this.speller == null);
            }
        }

        private class Language
        {
            internal readonly bool IsAvailable;

            internal readonly ushort Lcid;

            internal readonly string LexiconFullPath;

            internal readonly string LibraryFullPath;

            internal readonly string Name;

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
        }

        private static class NativeMethods
        {
            // Methods
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool FreeLibrary(IntPtr hModule);

            [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
            internal static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern IntPtr LoadLibrary(string lpFileName);
        }

        private delegate SpellChecker.PTEC PROOFCLOSELEX(IntPtr id, IntPtr lex, bool force);

        private delegate SpellChecker.PTEC PROOFINIT(out IntPtr pid, ref SpellChecker.PROOFPARAMS pxpar);

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

        private delegate SpellChecker.PTEC PROOFOPENLEX(IntPtr id, ref SpellChecker.PROOFLEXIN plxin, ref SpellChecker.PROOFLEXOUT plxout);

        [StructLayout(LayoutKind.Sequential)]
        private struct PROOFPARAMS
        {
            internal uint VersionApi;
        }

        private delegate SpellChecker.PTEC PROOFSETOPTIONS(IntPtr id, uint iOptionSelect, uint iOptVal);

        private delegate SpellChecker.PTEC PROOFTERMINATE(IntPtr id, bool fForce);

        [StructLayout(LayoutKind.Sequential)]
        private struct PTEC
        {
            internal uint Code;

            internal SpellChecker.PTEC_MAJOR Major
            {
                get
                {
                    return (((SpellChecker.PTEC_MAJOR)this.Code) & ((SpellChecker.PTEC_MAJOR)0xff));
                }
            }

            internal SpellChecker.PTEC_MINOR Minor
            {
                get
                {
                    return (SpellChecker.PTEC_MINOR)(this.Code >> 0x10);
                }
            }

            internal bool Succeeded
            {
                get
                {
                    return (this.Code == 0);
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

        private sealed class Speller : IDisposable
        {
            private SPELLERADDUDR m_addUdr;

            private SPELLERCHECK m_check;

            private SPELLERCLEARUDR m_clearUdr;

            private PROOFCLOSELEX m_closeLex;

            private SPELLERDELUDR m_deleteUdr;

            private IntPtr m_id;

            private IntPtr m_ignoredDictionary;

            private IntPtr[] m_lexicons;

            [SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
            private IntPtr m_libraryHandle;

            private PROOFOPENLEX m_openLex;

            private PROOFTERMINATE m_terminate;

            internal Speller(string path)
            {
                IntPtr ptr;
                this.m_libraryHandle = SpellChecker.NativeMethods.LoadLibrary(path);
                if (this.m_libraryHandle == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }
                SpellChecker.PROOFINIT proc = GetProc<SpellChecker.PROOFINIT>(this.m_libraryHandle, "SpellerInit");
                SpellChecker.PROOFSETOPTIONS proofsetoptions = GetProc<SpellChecker.PROOFSETOPTIONS>(this.m_libraryHandle, "SpellerSetOptions");
                this.m_terminate = GetProc<SpellChecker.PROOFTERMINATE>(this.m_libraryHandle, "SpellerTerminate");
                this.m_openLex = GetProc<SpellChecker.PROOFOPENLEX>(this.m_libraryHandle, "SpellerOpenLex");
                this.m_closeLex = GetProc<SpellChecker.PROOFCLOSELEX>(this.m_libraryHandle, "SpellerCloseLex");
                this.m_check = GetProc<SpellChecker.SPELLERCHECK>(this.m_libraryHandle, "SpellerCheck");
                this.m_addUdr = GetProc<SpellChecker.SPELLERADDUDR>(this.m_libraryHandle, "SpellerAddUdr");
                this.m_deleteUdr = GetProc<SpellChecker.SPELLERDELUDR>(this.m_libraryHandle, "SpellerDelUdr");
                this.m_clearUdr = GetProc<SpellChecker.SPELLERCLEARUDR>(this.m_libraryHandle, "SpellerClearUdr");
                SpellChecker.PROOFPARAMS pxpar = new SpellChecker.PROOFPARAMS { VersionApi = 0x3000000 };
                CheckErrorCode(proc(out ptr, ref pxpar));
                this.m_id = ptr;
                CheckErrorCode(proofsetoptions(ptr, 0, 0x20006));
                this.InitIgnoreDictionary();
            }

            internal void AddIgnoredWord(string word)
            {
                CheckErrorCode(this.m_addUdr(this.m_id, this.m_ignoredDictionary, word));
            }

            private void AddLexicon(IntPtr lex)
            {
                IntPtr[] ptrArray;
                int length;
                if (this.m_lexicons == null)
                {
                    ptrArray = new IntPtr[1];
                    length = 0;
                }
                else
                {
                    ptrArray = new IntPtr[this.m_lexicons.Length + 1];
                    this.m_lexicons.CopyTo(ptrArray, 0);
                    length = this.m_lexicons.Length;
                }
                ptrArray[length] = lex;
                this.m_lexicons = ptrArray;
            }

            internal void AddLexicon(ushort lcid, string path)
            {
                SpellChecker.PROOFLEXIN plxin = new SpellChecker.PROOFLEXIN { pwszLex = path, lxt = SpellChecker.PROOFLEXTYPE.Main, lidExpected = lcid };
                SpellChecker.PROOFLEXOUT plxout = new SpellChecker.PROOFLEXOUT { cchCopyright = 0, fReadOnly = true };
                CheckErrorCode(this.m_openLex(this.m_id, ref plxin, ref plxout));
                this.AddLexicon(plxout.lex);
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
                    lock (this)
                    {
                        error = this.m_check(this.m_id, SPELLERCOMMAND.VerifyBuffer, ref wSIB, ref wSRB);
                    }

                    CheckErrorCode(error);
                    return wSRB.sstat;
                }
            }

            private static void CheckErrorCode(SpellChecker.PTEC error)
            {
                if (!error.Succeeded)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Unexpected proofing tool error code: {0}.", new object[] { error }));
                }
            }

            internal void ClearIgnoredWords()
            {
                CheckErrorCode(this.m_clearUdr(this.m_id, this.m_ignoredDictionary));
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
                        foreach (IntPtr ptr in this.m_lexicons)
                        {
                            CheckErrorCode(this.m_closeLex(this.m_id, ptr, true));
                        }
                        this.m_lexicons = null;
                    }
                    if (this.m_id != IntPtr.Zero)
                    {
                        CheckErrorCode(this.m_terminate(this.m_id, true));
                        this.m_id = IntPtr.Zero;
                    }
                    if (this.m_libraryHandle != IntPtr.Zero)
                    {
                        if (!SpellChecker.NativeMethods.FreeLibrary(this.m_libraryHandle))
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

            ~Speller()
            {
                this.Dispose(false);
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

            private void InitIgnoreDictionary()
            {
                SpellChecker.SPELLERBUILTINUDR proc = GetProc<SpellChecker.SPELLERBUILTINUDR>(this.m_libraryHandle, "SpellerBuiltinUdr");
                this.m_ignoredDictionary = proc(this.m_id, SpellChecker.PROOFLEXTYPE.User);
                if (this.m_ignoredDictionary == IntPtr.Zero)
                {
                    throw new InvalidOperationException("Failed to get the ignored dictionary handle.");
                }
            }

            internal void RemoveIgnoredWord(string word)
            {
                CheckErrorCode(this.m_deleteUdr(this.m_id, this.m_ignoredDictionary, word));
            }
        }

        private delegate SpellChecker.PTEC SPELLERADDUDR(IntPtr sid, IntPtr lex, [MarshalAs(UnmanagedType.LPTStr)] string add);

        private delegate IntPtr SPELLERBUILTINUDR(IntPtr sid, SpellChecker.PROOFLEXTYPE lxt);

        private delegate SpellChecker.PTEC SPELLERCHECK(IntPtr sid, SpellChecker.SPELLERCOMMAND scmd, ref SpellChecker.WSIB psib, ref SpellChecker.WSRB psrb);

        private delegate SpellChecker.PTEC SPELLERCLEARUDR(IntPtr sid, IntPtr lex);

        private enum SPELLERCOMMAND : uint
        {
            Anagram = 7,

            Suggest = 3,

            SuggestMore = 4,

            VerifyBuffer = 2,

            VerifyBufferAutoReplace = 10,

            Wildcard = 6
        }

        private delegate SpellChecker.PTEC SPELLERDELUDR(IntPtr sid, IntPtr lex, [MarshalAs(UnmanagedType.LPTStr)] string delete);

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

        [StructLayout(LayoutKind.Sequential)]
        private struct SPELLERSUGGESTION
        {
            internal unsafe char* pwsz;

            internal uint ichSugg;

            internal uint cchSugg;

            internal uint iRating;
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
    }
}