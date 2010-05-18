//------------------------------------------------------------------------------
// <copyright file="VSConstants.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio {

    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.TextManager.Interop;
    using Microsoft.VisualStudio.OLE.Interop;
    using System.ComponentModel;

    [CLSCompliant(false)]
    public sealed class VSConstants {

        private VSConstants() { }


        /// <summary>
        /// 
        /// </summary>
        public static class WellKnownToolboxStringMaps
        {
            public const string MultiTargeting = "MultiTargeting:{FBB22D27-7B21-42AC-88C8-595F94BDBCA5}";
        }

        /// <summary>
        /// 
        /// </summary>
        public static class ToolboxMultitargetingFields
        {
            /// <summary>The full type name, e.g. System.Windows.Forms.Button</summary>
            public const string TypeName = "TypeName";
            /// <summary>The full assembly name (strong name), including version</summary>
            public const string AssemblyName = "AssemblyName";
            /// <summary>A semicolon-delimited list of TFMs this item supports (without profiles)</summary>
            public const string Frameworks = "Frameworks";
            /// <summary>The GUID of the package that implements IVsProvideTargetedToolboxItems and knows about this item type</summary>
            public const string ItemProvider = "ItemProvider";
            /// <summary>A boolean value indicating whether to use the project target framework's version in toolbox item tooltips</summary>
            public const string UseProjectTargetFrameworkVersionInTooltip = "UseProjectTargetFrameworkVersionInTooltip";
        }

        /// <summary>
        /// 
        /// </summary>
        public static class CMDSETID
        {
            /// <summary></summary>
            public const string StandardCommandSet97_string = "{5EFC7975-14BC-11CF-9B2B-00AA00573819}";
            /// <summary></summary>
            public static readonly Guid StandardCommandSet97_guid = new Guid(StandardCommandSet97_string);

            /// <summary></summary>
            public const string StandardCommandSet2K_string = "{1496A755-94DE-11D0-8C3F-00C04FC2AAE2}";
            /// <summary></summary>
            public static readonly Guid StandardCommandSet2K_guid = new Guid(StandardCommandSet2K_string);

            /// <summary>
            /// GUID for the Visual Studio 2010 command set. This is a set of new commands added to Visual Studio 2010.
            /// </summary>
            public const string StandardCommandSet2010_string = "{5DD0BB59-7076-4C59-88D3-DE36931F63F0}";
            /// <summary>
            /// GUID for the Visual Studio 2010 command set. This is a set of new commands added to Visual Studio 2010.
            /// </summary>
            public static readonly Guid StandardCommandSet2010_guid = new Guid(StandardCommandSet2010_string);

            /// <summary>Command Group GUID for commands that only apply to the UIHierarchyWindow.</summary>
            public const string UIHierarchyWindowCommandSet_string = "{60481700-078B-11D1-AAF8-00A0C9055A90}";
            /// <summary>Command Group GUID for commands that only apply to the UIHierarchyWindow.</summary>
            public static readonly Guid UIHierarchyWindowCommandSet_guid = new Guid(UIHierarchyWindowCommandSet_string);

            /// <summary></summary>
            public const string VsDocOutlinePackageCommandSet_string = "{21AF45B0-FFA5-11D0-B63F-00A0C922E851}";
            /// <summary></summary>
            public static readonly Guid VsDocOutlinePackageCommandSet_guid = new Guid(VsDocOutlinePackageCommandSet_string);
        }


        // VS Command ID's

        public const int cmdidToolsOptions = 264;

        /// Common OLE GUIDs
        public static readonly Guid IID_IUnknown = new Guid("{00000000-0000-0000-C000-000000000046}");


        /// <summary>This GUID identifies commands fired as a resoult of a WM_APPCOMMAND message received by the main window.</summary>
        public static readonly Guid GUID_AppCommand = new Guid("{12F1A339-02B9-46E6-BDAF-1071F76056BF}");

        [Guid("12F1A339-02B9-46e6-BDAF-1071F76056BF")]
        public enum AppCommandCmdID
        {
            BrowserBackward = 1,
            BrowserForward = 2,
            BrowserRefresh = 3,
            BrowserStop = 4,
            BrowserSearch = 5,
            BrowserFavorites = 6,
            BrowserHome = 7,
            VolumeMute = 8,
            VolumeDown = 9,
            VolumeUp = 10,
            MediaNextTrack = 11,
            MediaPreviousTrack = 12,
            MediaStop = 13,
            MediaPlayPause = 14,
            LaunchMail = 15,
            LaunchMediaSelect = 16,
            LaunchApp1 = 17,
            LaunchApp2 = 18,
            BassDown = 19,
            BassBoost = 20,
            BassUp = 21,
            TrebleDown = 22,
            TrebleUp = 23,
            MicrophoneVolumeMute = 24,
            MicrophoneVolumeDown = 25,
            MicrophoneVolumeUp = 26
        };

        /// <summary>This GUID identifies the standard set of commands known by VisualStudio 97 (version 6).</summary>
        public static readonly Guid GUID_VSStandardCommandSet97 = new Guid("{5EFC7975-14BC-11CF-9B2B-00AA00573819}");

        [Guid("5EFC7975-14BC-11CF-9B2B-00AA00573819")]
        public enum VSStd97CmdID
        {
            AlignBottom = 1,
            AlignHorizontalCenters = 2,
            AlignLeft = 3,
            AlignRight = 4,
            AlignToGrid = 5,
            AlignTop = 6,
            AlignVerticalCenters = 7,
            ArrangeBottom = 8,
            ArrangeRight = 9,
            BringForward = 10,
            BringToFront = 11,
            CenterHorizontally = 12,
            CenterVertically = 13,
            Code = 14,
            Copy = 15,
            Cut = 16,
            Delete = 17,
            FontName = 18,
            FontNameGetList = 500,
            FontSize = 19,
            FontSizeGetList = 501,
            Group = 20,
            HorizSpaceConcatenate = 21,
            HorizSpaceDecrease = 22,
            HorizSpaceIncrease = 23,
            HorizSpaceMakeEqual = 24,
            LockControls = 369,
            InsertObject = 25,
            Paste = 26,
            Print = 27,
            Properties = 28,
            Redo = 29,
            MultiLevelRedo = 30,
            SelectAll = 31,
            SendBackward = 32,
            SendToBack = 33,
            ShowTable = 34,
            SizeToControl = 35,
            SizeToControlHeight = 36,
            SizeToControlWidth = 37,
            SizeToFit = 38,
            SizeToGrid = 39,
            SnapToGrid = 40,
            TabOrder = 41,
            Toolbox = 42,
            Undo = 43,
            MultiLevelUndo = 44,
            Ungroup = 45,
            VertSpaceConcatenate = 46,
            VertSpaceDecrease = 47,
            VertSpaceIncrease = 48,
            VertSpaceMakeEqual = 49,
            ZoomPercent = 50,
            BackColor = 51,
            Bold = 52,
            BorderColor = 53,
            BorderDashDot = 54,
            BorderDashDotDot = 55,
            BorderDashes = 56,
            BorderDots = 57,
            BorderShortDashes = 58,
            BorderSolid = 59,
            BorderSparseDots = 60,
            BorderWidth1 = 61,
            BorderWidth2 = 62,
            BorderWidth3 = 63,
            BorderWidth4 = 64,
            BorderWidth5 = 65,
            BorderWidth6 = 66,
            BorderWidthHairline = 67,
            Flat = 68,
            ForeColor = 69,
            Italic = 70,
            JustifyCenter = 71,
            JustifyGeneral = 72,
            JustifyLeft = 73,
            JustifyRight = 74,
            Raised = 75,
            Sunken = 76,
            Underline = 77,
            Chiseled = 78,
            Etched = 79,
            Shadowed = 80,
            CompDebug1 = 81,
            CompDebug2 = 82,
            CompDebug3 = 83,
            CompDebug4 = 84,
            CompDebug5 = 85,
            CompDebug6 = 86,
            CompDebug7 = 87,
            CompDebug8 = 88,
            CompDebug9 = 89,
            CompDebug10 = 90,
            CompDebug11 = 91,
            CompDebug12 = 92,
            CompDebug13 = 93,
            CompDebug14 = 94,
            CompDebug15 = 95,
            ExistingSchemaEdit = 96,
            Find = 97,
            GetZoom = 98,
            QueryOpenDesign = 99,
            QueryOpenNew = 100,
            SingleTableDesign = 101,
            SingleTableNew = 102,
            ShowGrid = 103,
            NewTable = 104,
            CollapsedView = 105,
            FieldView = 106,
            VerifySQL = 107,
            HideTable = 108,

            PrimaryKey = 109,
            Save = 110,
            SaveAs = 111,
            SortAscending = 112,

            SortDescending = 113,
            AppendQuery = 114,
            CrosstabQuery = 115,
            DeleteQuery = 116,
            MakeTableQuery = 117,

            SelectQuery = 118,
            UpdateQuery = 119,
            Parameters = 120,
            Totals = 121,
            ViewCollapsed = 122,

            ViewFieldList = 123,


            ViewKeys = 124,
            ViewGrid = 125,
            InnerJoin = 126,

            RightOuterJoin = 127,
            LeftOuterJoin = 128,
            FullOuterJoin = 129,
            UnionJoin = 130,
            ShowSQLPane = 131,

            ShowGraphicalPane = 132,
            ShowDataPane = 133,
            ShowQBEPane = 134,
            SelectAllFields = 135,

            OLEObjectMenuButton = 136,

            // ids on the ole verbs menu - these must be sequential ie verblist0-verblist9
            ObjectVerbList0 = 137,
            ObjectVerbList1 = 138,
            ObjectVerbList2 = 139,
            ObjectVerbList3 = 140,
            ObjectVerbList4 = 141,
            ObjectVerbList5 = 142,
            ObjectVerbList6 = 143,
            ObjectVerbList7 = 144,
            ObjectVerbList8 = 145,
            ObjectVerbList9 = 146,  // Unused on purpose!

            ConvertObject = 147,
            CustomControl = 148,
            CustomizeItem = 149,
            Rename = 150,

            Import = 151,
            NewPage = 152,
            Move = 153,
            Cancel = 154,

            Font = 155,

            ExpandLinks = 156,
            ExpandImages = 157,
            ExpandPages = 158,
            RefocusDiagram = 159,
            TransitiveClosure = 160,
            CenterDiagram = 161,
            ZoomIn = 162,
            ZoomOut = 163,
            RemoveFilter = 164,
            HidePane = 165,
            DeleteTable = 166,
            DeleteRelationship = 167,
            Remove = 168,
            JoinLeftAll = 169,
            JoinRightAll = 170,
            AddToOutput = 171,      // Add selected fields to query output
            OtherQuery = 172,      // change query type to 'other'
            GenerateChangeScript = 173,
            SaveSelection = 174,     // Save current selection
            AutojoinCurrent = 175,     // Autojoin current tables
            AutojoinAlways = 176,     // Toggle Autojoin state
            EditPage = 177,     // Launch editor for url
            ViewLinks = 178,     // Launch new webscope for url
            Stop = 179,     // Stope webscope rendering
            Pause = 180,     // Pause webscope rendering
            Resume = 181,     // Resume webscope rendering
            FilterDiagram = 182,     // Filter webscope diagram
            ShowAllObjects = 183,     // Show All objects in webscope diagram
            ShowApplications = 184,     // Show Application objects in webscope diagram
            ShowOtherObjects = 185,     // Show other objects in webscope diagram
            ShowPrimRelationships = 186,     // Show primary relationships
            Expand = 187,     // Expand links
            Collapse = 188,     // Collapse links
            Refresh = 189,     // Refresh Webscope diagram
            Layout = 190,     // Layout websope diagram
            ShowResources = 191,     // Show resouce objects in webscope diagram
            InsertHTMLWizard = 192,     // Insert HTML using a Wizard
            ShowDownloads = 193,     // Show download objects in webscope diagram
            ShowExternals = 194,     // Show external objects in webscope diagram
            ShowInBoundLinks = 195,     // Show inbound links in webscope diagram
            ShowOutBoundLinks = 196,     // Show out bound links in webscope diagram
            ShowInAndOutBoundLinks = 197,     // Show in and out bound links in webscope diagram
            Preview = 198,     // Preview page
            Open = 261,     // Open
            OpenWith = 199,     // Open with
            ShowPages = 200,     // Show HTML pages
            RunQuery = 201,      // Runs a query
            ClearQuery = 202,      // Clears the query's associated cursor
            RecordFirst = 203,      // Go to first record in set
            RecordLast = 204,      // Go to last record in set
            RecordNext = 205,      // Go to next record in set
            RecordPrevious = 206,      // Go to previous record in set
            RecordGoto = 207,      // Go to record via dialog
            RecordNew = 208,      // Add a record to set

            InsertNewMenu = 209,     // menu designer
            InsertSeparator = 210,     // menu designer
            EditMenuNames = 211,     // menu designer

            DebugExplorer = 212,
            DebugProcesses = 213,
            ViewThreadsWindow = 214,
            WindowUIList = 215,

            // ids on the file menu
            NewProject = 216,
            OpenProject = 217,
            OpenProjectFromWeb = 450,
            OpenSolution = 218,
            CloseSolution = 219,
            FileNew = 221,
            NewProjectFromExisting = 385,
            FileOpen = 222,
            FileOpenFromWeb = 451,
            FileClose = 223,
            SaveSolution = 224,
            SaveSolutionAs = 225,
            SaveProjectItemAs = 226,
            PageSetup = 227,
            PrintPreview = 228,
            Exit = 229,

            // ids on the edit menu
            Replace = 230,
            Goto = 231,

            // ids on the view menu
            PropertyPages = 232,
            FullScreen = 233,
            ProjectExplorer = 234,
            PropertiesWindow = 235,
            TaskListWindow = 236,
            OutputWindow = 237,
            ObjectBrowser = 238,
            DocOutlineWindow = 239,
            ImmediateWindow = 240,
            WatchWindow = 241,
            LocalsWindow = 242,
            CallStack = 243,
            AutosWindow = DebugReserved1,
            ThisWindow = DebugReserved2,

            // ids on project menu
            AddNewItem = 220,
            AddExistingItem = 244,
            NewFolder = 245,
            SetStartupProject = 246,
            ProjectSettings = 247,
            ProjectReferences = 367,

            // ids on the debug menu
            StepInto = 248,
            StepOver = 249,
            StepOut = 250,
            RunToCursor = 251,
            AddWatch = 252,
            EditWatch = 253,
            QuickWatch = 254,

            ToggleBreakpoint = 255,
            ClearBreakpoints = 256,
            ShowBreakpoints = 257,
            SetNextStatement = 258,
            ShowNextStatement = 259,
            EditBreakpoint = 260,
            DetachDebugger = 262,

            // ids on the tools menu
            CustomizeKeyboard = 263,
            ToolsOptions = 264,

            // ids on the windows menu
            NewWindow = 265,
            Split = 266,
            Cascade = 267,
            TileHorz = 268,
            TileVert = 269,

            // ids on the help menu
            TechSupport = 270,

            // NOTE cmdidAbout and cmdidDebugOptions must be consecutive
            //      cmd after cmdidDebugOptions (ie 273) must not be used
            About = 271,
            DebugOptions = 272,

            // ids on the watch context menu
            // CollapseWatch appears as 'Collapse Parent', on any
            // non-top-level item
            DeleteWatch = 274,
            CollapseWatch = 275,
            // ids 276, 277, 278, 279, 280 are in use
            // below 
            // ids on the property browser context menu
            PbrsToggleStatus = 282,
            PropbrsHide = 283,

            // ids on the docking context menu
            DockingView = 284,
            HideActivePane = 285,
            // ids for window selection via keyboard
            PaneNextPane = 316,  //(listed below in order)
            PanePrevPane = 317,  //(listed below in order)
            PaneNextTab = 286,
            PanePrevTab = 287,
            PaneCloseToolWindow = 288,
            PaneActivateDocWindow = 289,
            DockingViewMDI = 290,
            DockingViewFloater = 291,
            AutoHideWindow = 292,
            MoveToDropdownBar = 293,
            FindCmd = 294,  // internal Find commands
            Start = 295,
            Restart = 296,

            AddinManager = 297,

            MultiLevelUndoList = 298,
            MultiLevelRedoList = 299,

            ToolboxAddTab = 300,
            ToolboxDeleteTab = 301,
            ToolboxRenameTab = 302,
            ToolboxTabMoveUp = 303,
            ToolboxTabMoveDown = 304,
            ToolboxRenameItem = 305,
            ToolboxListView = 306,
            //(below) cmdidSearchSetCombo        307

            WindowUIGetList = 308,
            InsertValuesQuery = 309,

            ShowProperties = 310,

            ThreadSuspend = 311,
            ThreadResume = 312,
            ThreadSetFocus = 313,
            DisplayRadix = 314,

            OpenProjectItem = 315,

            ClearPane = 318,
            GotoErrorTag = 319,

            TaskListSortByCategory = 320,
            TaskListSortByFileLine = 321,
            TaskListSortByPriority = 322,
            TaskListSortByDefaultSort = 323,
            TaskListShowTooltip = 324,
            TaskListFilterByNothing = 325,
            CancelEZDrag = 326,
            TaskListFilterByCategoryCompiler = 327,
            TaskListFilterByCategoryComment = 328,

            ToolboxAddItem = 329,
            ToolboxReset = 330,

            SaveProjectItem = 331,
            SaveOptions = 959,
            ViewForm = 332,
            ViewCode = 333,
            PreviewInBrowser = 334,
            BrowseWith = 336,
            SearchSetCombo = 307,
            SearchCombo = 337,
            EditLabel = 338,
            Exceptions = 339,
            DefineViews = 340,

            ToggleSelMode = 341,
            ToggleInsMode = 342,

            LoadUnloadedProject = 343,
            UnloadLoadedProject = 344,

            // ids on the treegrids (watch/local/threads/stack)
            ElasticColumn = 345,
            HideColumn = 346,

            TaskListPreviousView = 347,
            ZoomDialog = 348,

            // find/replace options
            FindHiddenText = 349,
            FindMatchCase = 350,
            FindWholeWord = 351,
            FindSimplePattern = 276,
            FindRegularExpression = 352,
            FindBackwards = 353,
            FindInSelection = 354,
            FindStop = 355,
            // UNUSED                               356
            FindInFiles = 277,
            ReplaceInFiles = 278,
            NextLocation = 279,  // next item in task list, find in files results, etc.
            PreviousLocation = 280,  // prev item "
            GotoQuick = 281,

            TaskListNextError = 357,
            TaskListPrevError = 358,
            TaskListFilterByCategoryUser = 359,
            TaskListFilterByCategoryShortcut = 360,
            TaskListFilterByCategoryHTML = 361,
            TaskListFilterByCurrentFile = 362,
            TaskListFilterByChecked = 363,
            TaskListFilterByUnchecked = 364,
            TaskListSortByDescription = 365,
            TaskListSortByChecked = 366,

            // 367 is used above in cmdidProjectReferences
            StartNoDebug = 368,
            // 369 is used above in cmdidLockControls

            FindNext = 370,
            FindPrev = 371,
            FindSelectedNext = 372,
            FindSelectedPrev = 373,
            SearchGetList = 374,
            InsertBreakpoint = 375,
            EnableBreakpoint = 376,
            F1Help = 377,

            //UNUSED 378-396

            MoveToNextEZCntr = 384,
            UpdateMarkerSpans = 386,
            MoveToPreviousEZCntr = 393,

            ProjectProperties = 396,
            PropSheetOrProperties = 397,

            // NOTE - the next items are debug only !!
            TshellStep = 398,
            TshellRun = 399,

            // marker commands on the codewin menu
            MarkerCmd0 = 400,
            MarkerCmd1 = 401,
            MarkerCmd2 = 402,
            MarkerCmd3 = 403,
            MarkerCmd4 = 404,
            MarkerCmd5 = 405,
            MarkerCmd6 = 406,
            MarkerCmd7 = 407,
            MarkerCmd8 = 408,
            MarkerCmd9 = 409,
            MarkerLast = 409,
            MarkerEnd = 410,  // list terminator reserved

            // user-invoked project reload and unload
            ReloadProject = 412,
            UnloadProject = 413,

            NewBlankSolution = 414,
            SelectProjectTemplate = 415,

            // document outline commands
            DetachAttachOutline = 420,
            ShowHideOutline = 421,
            SyncOutline = 422,

            RunToCallstCursor = 423,
            NoCmdsAvailable = 424,

            ContextWindow = 427,
            Alias = 428,
            GotoCommandLine = 429,
            EvaluateExpression = 430,
            ImmediateMode = 431,
            EvaluateStatement = 432,

            FindResultWindow1 = 433,
            FindResultWindow2 = 434,

            // 500 is used above in cmdidFontNameGetList
            // 501 is used above in cmdidFontSizeGetList

            RenameBookmark = 559,
            ToggleBookmark = 560,
            DeleteBookmark = 561,
            BookmarkWindowGoToBookmark = 562,
            EnableBookmark = 564,
            NewBookmarkFolder = 565,
            NextBookmarkFolder = 568,
            PrevBookmarkFolder = 569,

            // ids on the window menu - these must be sequential ie window1-morewind
            Window1 = 570,
            Window2 = 571,
            Window3 = 572,
            Window4 = 573,
            Window5 = 574,
            Window6 = 575,
            Window7 = 576,
            Window8 = 577,
            Window9 = 578,
            Window10 = 579,
            Window11 = 580,
            Window12 = 581,
            Window13 = 582,
            Window14 = 583,
            Window15 = 584,
            Window16 = 585,
            Window17 = 586,
            Window18 = 587,
            Window19 = 588,
            Window20 = 589,
            Window21 = 590,
            Window22 = 591,
            Window23 = 592,
            Window24 = 593,
            Window25 = 594,    // note cmdidWindow25 is unused on purpose!
            MoreWindows = 595,

            AutoHideAllWindows = 597,
            TaskListTaskHelp = 598,

            ClassView = 599,

            MRUProj1 = 600,
            MRUProj2 = 601,
            MRUProj3 = 602,
            MRUProj4 = 603,
            MRUProj5 = 604,
            MRUProj6 = 605,
            MRUProj7 = 606,
            MRUProj8 = 607,
            MRUProj9 = 608,
            MRUProj10 = 609,
            MRUProj11 = 610,
            MRUProj12 = 611,
            MRUProj13 = 612,
            MRUProj14 = 613,
            MRUProj15 = 614,
            MRUProj16 = 615,
            MRUProj17 = 616,
            MRUProj18 = 617,
            MRUProj19 = 618,
            MRUProj20 = 619,
            MRUProj21 = 620,
            MRUProj22 = 621,
            MRUProj23 = 622,
            MRUProj24 = 623,
            MRUProj25 = 624,   // note cmdidMRUProj25 is unused on purpose!

            SplitNext = 625,
            SplitPrev = 626,

            CloseAllDocuments = 627,
            NextDocument = 628,
            PrevDocument = 629,

            Tool1 = 630,   // note cmdidTool1 - cmdidTool24 must be
            Tool2 = 631,   // consecutive
            Tool3 = 632,
            Tool4 = 633,
            Tool5 = 634,
            Tool6 = 635,
            Tool7 = 636,
            Tool8 = 637,
            Tool9 = 638,
            Tool10 = 639,
            Tool11 = 640,
            Tool12 = 641,
            Tool13 = 642,
            Tool14 = 643,
            Tool15 = 644,
            Tool16 = 645,
            Tool17 = 646,
            Tool18 = 647,
            Tool19 = 648,
            Tool20 = 649,
            Tool21 = 650,
            Tool22 = 651,
            Tool23 = 652,
            Tool24 = 653,
            ExternalCommands = 654,

            PasteNextTBXCBItem = 655,
            ToolboxShowAllTabs = 656,
            ProjectDependencies = 657,
            CloseDocument = 658,
            ToolboxSortItems = 659,

            ViewBarView1 = 660,    //UNUSED
            ViewBarView2 = 661,    //UNUSED
            ViewBarView3 = 662,    //UNUSED
            ViewBarView4 = 663,    //UNUSED
            ViewBarView5 = 664,    //UNUSED
            ViewBarView6 = 665,    //UNUSED
            ViewBarView7 = 666,    //UNUSED
            ViewBarView8 = 667,    //UNUSED
            ViewBarView9 = 668,    //UNUSED
            ViewBarView10 = 669,    //UNUSED
            ViewBarView11 = 670,    //UNUSED
            ViewBarView12 = 671,    //UNUSED
            ViewBarView13 = 672,    //UNUSED
            ViewBarView14 = 673,    //UNUSED
            ViewBarView15 = 674,    //UNUSED
            ViewBarView16 = 675,    //UNUSED
            ViewBarView17 = 676,    //UNUSED
            ViewBarView18 = 677,    //UNUSED
            ViewBarView19 = 678,    //UNUSED
            ViewBarView20 = 679,    //UNUSED
            ViewBarView21 = 680,    //UNUSED
            ViewBarView22 = 681,    //UNUSED
            ViewBarView23 = 682,    //UNUSED
            ViewBarView24 = 683,    //UNUSED

            SolutionCfg = 684,
            SolutionCfgGetList = 685,

            //
            // Schema table commands:
            // All invoke table property dialog and select appropriate page.
            //
            ManageIndexes = 675,
            ManageRelationships = 676,
            ManageConstraints = 677,

            TaskListCustomView1 = 678,
            TaskListCustomView2 = 679,
            TaskListCustomView3 = 680,
            TaskListCustomView4 = 681,
            TaskListCustomView5 = 682,
            TaskListCustomView6 = 683,
            TaskListCustomView7 = 684,
            TaskListCustomView8 = 685,
            TaskListCustomView9 = 686,
            TaskListCustomView10 = 687,
            TaskListCustomView11 = 688,
            TaskListCustomView12 = 689,
            TaskListCustomView13 = 690,
            TaskListCustomView14 = 691,
            TaskListCustomView15 = 692,
            TaskListCustomView16 = 693,
            TaskListCustomView17 = 694,
            TaskListCustomView18 = 695,
            TaskListCustomView19 = 696,
            TaskListCustomView20 = 697,
            TaskListCustomView21 = 698,
            TaskListCustomView22 = 699,
            TaskListCustomView23 = 700,
            TaskListCustomView24 = 701,
            TaskListCustomView25 = 702,
            TaskListCustomView26 = 703,
            TaskListCustomView27 = 704,
            TaskListCustomView28 = 705,
            TaskListCustomView29 = 706,
            TaskListCustomView30 = 707,
            TaskListCustomView31 = 708,
            TaskListCustomView32 = 709,
            TaskListCustomView33 = 710,
            TaskListCustomView34 = 711,
            TaskListCustomView35 = 712,
            TaskListCustomView36 = 713,
            TaskListCustomView37 = 714,
            TaskListCustomView38 = 715,
            TaskListCustomView39 = 716,
            TaskListCustomView40 = 717,
            TaskListCustomView41 = 718,
            TaskListCustomView42 = 719,
            TaskListCustomView43 = 720,
            TaskListCustomView44 = 721,
            TaskListCustomView45 = 722,
            TaskListCustomView46 = 723,
            TaskListCustomView47 = 724,
            TaskListCustomView48 = 725,
            TaskListCustomView49 = 726,
            TaskListCustomView50 = 727,  //not used on purpose, ends the list

            WhiteSpace = 728,

            CommandWindow = 729,
            CommandWindowMarkMode = 730,
            LogCommandWindow = 731,

            Shell = 732,

            SingleChar = 733,
            ZeroOrMore = 734,
            OneOrMore = 735,
            BeginLine = 736,
            EndLine = 737,
            BeginWord = 738,
            EndWord = 739,
            CharInSet = 740,
            CharNotInSet = 741,
            Or = 742,
            Escape = 743,
            TagExp = 744,

            // Regex builder context help menu commands
            PatternMatchHelp = 745,
            RegExList = 746,

            DebugReserved1 = 747,
            DebugReserved2 = 748,
            DebugReserved3 = 749,
            //USED ABOVE                        750
            //USED ABOVE                        751
            //USED ABOVE                        752
            //USED ABOVE                        753

            //Regex builder wildcard menu commands
            WildZeroOrMore = 754,
            WildSingleChar = 755,
            WildSingleDigit = 756,
            WildCharInSet = 757,
            WildCharNotInSet = 758,

            FindWhatText = 759,
            TaggedExp1 = 760,
            TaggedExp2 = 761,
            TaggedExp3 = 762,
            TaggedExp4 = 763,
            TaggedExp5 = 764,
            TaggedExp6 = 765,
            TaggedExp7 = 766,
            TaggedExp8 = 767,
            TaggedExp9 = 768,

            EditorWidgetClick = 769,  // param 0 is the moniker as VT_BSTR, param 1 is the buffer line as VT_I4, and param 2 is the buffer index as VT_I4
            CmdWinUpdateAC = 770,

            SlnCfgMgr = 771,

            AddNewProject = 772,
            AddExistingProject = 773,
            AddExistingProjFromWeb = 774,

            AutoHideContext1 = 776,
            AutoHideContext2 = 777,
            AutoHideContext3 = 778,
            AutoHideContext4 = 779,
            AutoHideContext5 = 780,
            AutoHideContext6 = 781,
            AutoHideContext7 = 782,
            AutoHideContext8 = 783,
            AutoHideContext9 = 784,
            AutoHideContext10 = 785,
            AutoHideContext11 = 786,
            AutoHideContext12 = 787,
            AutoHideContext13 = 788,
            AutoHideContext14 = 789,
            AutoHideContext15 = 790,
            AutoHideContext16 = 791,
            AutoHideContext17 = 792,
            AutoHideContext18 = 793,
            AutoHideContext19 = 794,
            AutoHideContext20 = 795,
            AutoHideContext21 = 796,
            AutoHideContext22 = 797,
            AutoHideContext23 = 798,
            AutoHideContext24 = 799,
            AutoHideContext25 = 800,
            AutoHideContext26 = 801,
            AutoHideContext27 = 802,
            AutoHideContext28 = 803,
            AutoHideContext29 = 804,
            AutoHideContext30 = 805,
            AutoHideContext31 = 806,
            AutoHideContext32 = 807,
            AutoHideContext33 = 808,   // must remain unused

            ShellNavBackward = 809,
            ShellNavForward = 810,

            ShellNavigate1 = 811,
            ShellNavigate2 = 812,
            ShellNavigate3 = 813,
            ShellNavigate4 = 814,
            ShellNavigate5 = 815,
            ShellNavigate6 = 816,
            ShellNavigate7 = 817,
            ShellNavigate8 = 818,
            ShellNavigate9 = 819,
            ShellNavigate10 = 820,
            ShellNavigate11 = 821,
            ShellNavigate12 = 822,
            ShellNavigate13 = 823,
            ShellNavigate14 = 824,
            ShellNavigate15 = 825,
            ShellNavigate16 = 826,
            ShellNavigate17 = 827,
            ShellNavigate18 = 828,
            ShellNavigate19 = 829,
            ShellNavigate20 = 830,
            ShellNavigate21 = 831,
            ShellNavigate22 = 832,
            ShellNavigate23 = 833,
            ShellNavigate24 = 834,
            ShellNavigate25 = 835,
            ShellNavigate26 = 836,
            ShellNavigate27 = 837,
            ShellNavigate28 = 838,
            ShellNavigate29 = 839,
            ShellNavigate30 = 840,
            ShellNavigate31 = 841,
            ShellNavigate32 = 842,
            ShellNavigate33 = 843,   // must remain unused

            ShellWindowNavigate1 = 844,
            ShellWindowNavigate2 = 845,
            ShellWindowNavigate3 = 846,
            ShellWindowNavigate4 = 847,
            ShellWindowNavigate5 = 848,
            ShellWindowNavigate6 = 849,
            ShellWindowNavigate7 = 850,
            ShellWindowNavigate8 = 851,
            ShellWindowNavigate9 = 852,
            ShellWindowNavigate10 = 853,
            ShellWindowNavigate11 = 854,
            ShellWindowNavigate12 = 855,
            ShellWindowNavigate13 = 856,
            ShellWindowNavigate14 = 857,
            ShellWindowNavigate15 = 858,
            ShellWindowNavigate16 = 859,
            ShellWindowNavigate17 = 860,
            ShellWindowNavigate18 = 861,
            ShellWindowNavigate19 = 862,
            ShellWindowNavigate20 = 863,
            ShellWindowNavigate21 = 864,
            ShellWindowNavigate22 = 865,
            ShellWindowNavigate23 = 866,
            ShellWindowNavigate24 = 867,
            ShellWindowNavigate25 = 868,
            ShellWindowNavigate26 = 869,
            ShellWindowNavigate27 = 870,
            ShellWindowNavigate28 = 871,
            ShellWindowNavigate29 = 872,
            ShellWindowNavigate30 = 873,
            ShellWindowNavigate31 = 874,
            ShellWindowNavigate32 = 875,
            ShellWindowNavigate33 = 876,   // must remain unused

            // ObjectSearch cmds
            OBSDoFind = 877,
            OBSMatchCase = 878,
            OBSMatchSubString = 879,
            OBSMatchWholeWord = 880,
            OBSMatchPrefix = 881,

            // build cmds
            BuildSln = 882,
            RebuildSln = 883,
            DeploySln = 884,
            CleanSln = 885,

            BuildSel = 886,
            RebuildSel = 887,
            DeploySel = 888,
            CleanSel = 889,

            CancelBuild = 890,
            BatchBuildDlg = 891,

            BuildCtx = 892,
            RebuildCtx = 893,
            DeployCtx = 894,
            CleanCtx = 895,

            QryManageIndexes = 896,
            PrintDefault = 897,         // quick print
            BrowseDoc = 898,
            ShowStartPage = 899,

            MRUFile1 = 900,
            MRUFile2 = 901,
            MRUFile3 = 902,
            MRUFile4 = 903,
            MRUFile5 = 904,
            MRUFile6 = 905,
            MRUFile7 = 906,
            MRUFile8 = 907,
            MRUFile9 = 908,
            MRUFile10 = 909,
            MRUFile11 = 910,
            MRUFile12 = 911,
            MRUFile13 = 912,
            MRUFile14 = 913,
            MRUFile15 = 914,
            MRUFile16 = 915,
            MRUFile17 = 916,
            MRUFile18 = 917,
            MRUFile19 = 918,
            MRUFile20 = 919,
            MRUFile21 = 920,
            MRUFile22 = 921,
            MRUFile23 = 922,
            MRUFile24 = 923,
            MRUFile25 = 924,   // note cmdidMRUFile25 is unused on purpose!

            //External Tools Context Menu Commands
            // continued at 1109
            ExtToolsCurPath = 925,
            ExtToolsCurDir = 926,
            ExtToolsCurFileName = 927,
            ExtToolsCurExtension = 928,
            ExtToolsProjDir = 929,
            ExtToolsProjFileName = 930,
            ExtToolsSlnDir = 931,
            ExtToolsSlnFileName = 932,


            // Object Browsing & ClassView cmds
            // Shared shell cmds (for accessing Object Browsing functionality)
            GotoDefn = 935,
            GotoDecl = 936,
            BrowseDefn = 937,
            SyncClassView = 938,
            ShowMembers = 939,
            ShowBases = 940,
            ShowDerived = 941,
            ShowDefns = 942,
            ShowRefs = 943,
            ShowCallers = 944,
            ShowCallees = 945,

            AddClass = 946,
            AddNestedClass = 947,
            AddInterface = 948,
            AddMethod = 949,
            AddProperty = 950,
            AddEvent = 951,
            AddVariable = 952,
            ImplementInterface = 953,
            Override = 954,
            AddFunction = 955,
            AddConnectionPoint = 956,
            AddIndexer = 957,

            BuildOrder = 958,
            //959 used above for cmdidSaveOptions

            // Object Browser Tool Specific cmds
            OBShowHidden = 960,
            OBEnableGrouping = 961,
            OBSetGroupingCriteria = 962,
            OBBack = 963,
            OBForward = 964,
            OBShowPackages = 965,
            OBSearchCombo = 966,
            OBSearchOptWholeWord = 967,
            OBSearchOptSubstring = 968,
            OBSearchOptPrefix = 969,
            OBSearchOptCaseSensitive = 970,

            // ClassView Tool Specific cmds
            CVGroupingNone = 971,
            CVGroupingSortOnly = 972,
            CVGroupingGrouped = 973,
            CVShowPackages = 974,
            CVNewFolder = 975,
            CVGroupingSortAccess = 976,

            ObjectSearch = 977,
            ObjectSearchResults = 978,

            // Further Obj Browsing cmds at 1095

            // build cascade menus
            Build1 = 979,
            Build2 = 980,
            Build3 = 981,
            Build4 = 982,
            Build5 = 983,
            Build6 = 984,
            Build7 = 985,
            Build8 = 986,
            Build9 = 987,
            BuildLast = 988,

            Rebuild1 = 989,
            Rebuild2 = 990,
            Rebuild3 = 991,
            Rebuild4 = 992,
            Rebuild5 = 993,
            Rebuild6 = 994,
            Rebuild7 = 995,
            Rebuild8 = 996,
            Rebuild9 = 997,
            RebuildLast = 998,

            Clean1 = 999,
            Clean2 = 1000,
            Clean3 = 1001,
            Clean4 = 1002,
            Clean5 = 1003,
            Clean6 = 1004,
            Clean7 = 1005,
            Clean8 = 1006,
            Clean9 = 1007,
            CleanLast = 1008,

            Deploy1 = 1009,
            Deploy2 = 1010,
            Deploy3 = 1011,
            Deploy4 = 1012,
            Deploy5 = 1013,
            Deploy6 = 1014,
            Deploy7 = 1015,
            Deploy8 = 1016,
            Deploy9 = 1017,
            DeployLast = 1018,

            BuildProjPicker = 1019,
            RebuildProjPicker = 1020,
            CleanProjPicker = 1021,
            DeployProjPicker = 1022,
            ResourceView = 1023,

            ShowHomePage = 1024,
            EditMenuIDs = 1025,

            LineBreak = 1026,
            CPPIdentifier = 1027,
            QuotedString = 1028,
            SpaceOrTab = 1029,
            Integer = 1030,
            //unused 1031-1035

            CustomizeToolbars = 1036,
            MoveToTop = 1037,
            WindowHelp = 1038,

            ViewPopup = 1039,
            CheckMnemonics = 1040,

            PRSortAlphabeticaly = 1041,
            PRSortByCategory = 1042,

            ViewNextTab = 1043,

            CheckForUpdates = 1044,

            Browser1 = 1045,
            Browser2 = 1046,
            Browser3 = 1047,
            Browser4 = 1048,
            Browser5 = 1049,
            Browser6 = 1050,
            Browser7 = 1051,
            Browser8 = 1052,
            Browser9 = 1053,
            Browser10 = 1054,
            Browser11 = 1055,  //note unused on purpose to end list

            OpenDropDownOpen = 1058,
            OpenDropDownOpenWith = 1059,

            ToolsDebugProcesses = 1060,

            PaneNextSubPane = 1062,
            PanePrevSubPane = 1063,

            MoveFileToProject1 = 1070,
            MoveFileToProject2 = 1071,
            MoveFileToProject3 = 1072,
            MoveFileToProject4 = 1073,
            MoveFileToProject5 = 1074,
            MoveFileToProject6 = 1075,
            MoveFileToProject7 = 1076,
            MoveFileToProject8 = 1077,
            MoveFileToProject9 = 1078,
            MoveFileToProjectLast = 1079,  // unused in order to end list
            MoveFileToProjectPick = 1081,

            DefineSubset = 1095,
            SubsetCombo = 1096,
            SubsetGetList = 1097,
            OBSortObjectsAlpha = 1098,
            OBSortObjectsType = 1099,
            OBSortObjectsAccess = 1100,
            OBGroupObjectsType = 1101,
            OBGroupObjectsAccess = 1102,
            OBSortMembersAlpha = 1103,
            OBSortMembersType = 1104,
            OBSortMembersAccess = 1105,

            PopBrowseContext = 1106,
            GotoRef = 1107,
            OBSLookInReferences = 1108,

            ExtToolsTargetPath = 1109,
            ExtToolsTargetDir = 1110,
            ExtToolsTargetFileName = 1111,
            ExtToolsTargetExtension = 1112,
            ExtToolsCurLine = 1113,
            ExtToolsCurCol = 1114,
            ExtToolsCurText = 1115,

            BrowseNext = 1116,
            BrowsePrev = 1117,
            BrowseUnload = 1118,
            QuickObjectSearch = 1119,
            ExpandAll = 1120,
            ExtToolsBinDir = 1121,
            BookmarkWindow = 1122,
            CodeExpansionWindow = 1123,

            NextDocumentNav = 1124,
            PrevDocumentNav = 1125,
            ForwardBrowseContext = 1126,

            StandardMax = 1500,

            FindReferences = 1915,

            ///////////////////////////////////////////
            //
            // cmdidStandardMax is now thought to be
            // obsolete. Any new shell commands should
            // be added to the end of StandardCommandSet2K
            // which appears below.
            //
            // If you are not adding shell commands,
            // you shouldn't be doing it in this file! 
            //
            ///////////////////////////////////////////


            FormsFirst = 0x00006000,

            FormsLast = 0x00006FFF,

            VBEFirst = 0x00008000,


            Zoom200 = 0x00008002,
            Zoom150 = 0x00008003,
            Zoom100 = 0x00008004,
            Zoom75 = 0x00008005,
            Zoom50 = 0x00008006,
            Zoom25 = 0x00008007,
            Zoom10 = 0x00008010,


            VBELast = 0x00009FFF,

            SterlingFirst = 0x0000A000,
            SterlingLast = 0x0000BFFF,

            uieventidFirst = 0xC000,
            uieventidSelectRegion = 0xC001,
            uieventidDrop = 0xC002,
            uieventidLast = 0xDFFF,
        }

        /// <summary>
        /// GUID for the 2K command set. This is a set of standard editor commands.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid VSStd2K = new Guid("{1496A755-94DE-11D0-8C3F-00C04FC2AAE2}");

        /// <summary>
        /// Set of the standard, shared editor commands in StandardCommandSet2k.
        /// </summary>
        [Guid("1496A755-94DE-11D0-8C3F-00C04FC2AAE2")]
        public enum VSStd2KCmdID
        {
            TYPECHAR = 1,
            BACKSPACE = 2,
            RETURN = 3,
            TAB = 4,  // test
            ECMD_TAB = 4,
            BACKTAB = 5,
            DELETE = 6,
            LEFT = 7,
            LEFT_EXT = 8,
            RIGHT = 9,
            RIGHT_EXT = 10,
            UP = 11,
            UP_EXT = 12,
            DOWN = 13,
            DOWN_EXT = 14,
            HOME = 15,
            HOME_EXT = 16,
            END = 17,
            END_EXT = 18,
            BOL = 19,
            BOL_EXT = 20,
            FIRSTCHAR = 21,
            FIRSTCHAR_EXT = 22,
            EOL = 23,
            EOL_EXT = 24,
            LASTCHAR = 25,
            LASTCHAR_EXT = 26,
            PAGEUP = 27,
            PAGEUP_EXT = 28,
            PAGEDN = 29,
            PAGEDN_EXT = 30,
            TOPLINE = 31,
            TOPLINE_EXT = 32,
            BOTTOMLINE = 33,
            BOTTOMLINE_EXT = 34,
            SCROLLUP = 35,
            SCROLLDN = 36,
            SCROLLPAGEUP = 37,
            SCROLLPAGEDN = 38,
            SCROLLLEFT = 39,
            SCROLLRIGHT = 40,
            SCROLLBOTTOM = 41,
            SCROLLCENTER = 42,
            SCROLLTOP = 43,
            SELECTALL = 44,
            SELTABIFY = 45,
            SELUNTABIFY = 46,
            SELLOWCASE = 47,
            SELUPCASE = 48,
            SELTOGGLECASE = 49,
            SELTITLECASE = 50,
            SELSWAPANCHOR = 51,
            GOTOLINE = 52,
            GOTOBRACE = 53,
            GOTOBRACE_EXT = 54,
            GOBACK = 55,
            SELECTMODE = 56,
            TOGGLE_OVERTYPE_MODE = 57,
            CUT = 58,
            COPY = 59,
            PASTE = 60,
            CUTLINE = 61,
            DELETELINE = 62,
            DELETEBLANKLINES = 63,
            DELETEWHITESPACE = 64,
            DELETETOEOL = 65,
            DELETETOBOL = 66,
            OPENLINEABOVE = 67,
            OPENLINEBELOW = 68,
            INDENT = 69,
            UNINDENT = 70,
            UNDO = 71,
            UNDONOMOVE = 72,
            REDO = 73,
            REDONOMOVE = 74,
            DELETEALLTEMPBOOKMARKS = 75,
            TOGGLETEMPBOOKMARK = 76,
            GOTONEXTBOOKMARK = 77,
            GOTOPREVBOOKMARK = 78,
            FIND = 79,
            REPLACE = 80,
            REPLACE_ALL = 81,
            FINDNEXT = 82,
            FINDNEXTWORD = 83,
            FINDPREV = 84,
            FINDPREVWORD = 85,
            FINDAGAIN = 86,
            TRANSPOSECHAR = 87,
            TRANSPOSEWORD = 88,
            TRANSPOSELINE = 89,
            SELECTCURRENTWORD = 90,
            DELETEWORDRIGHT = 91,
            DELETEWORDLEFT = 92,
            WORDPREV = 93,
            WORDPREV_EXT = 94,
            WORDNEXT = 96,
            WORDNEXT_EXT = 97,
            COMMENTBLOCK = 98,
            UNCOMMENTBLOCK = 99,
            SETREPEATCOUNT = 100,
            WIDGETMARGIN_LBTNDOWN = 101,
            SHOWCONTEXTMENU = 102,
            CANCEL = 103,
            PARAMINFO = 104,
            TOGGLEVISSPACE = 105,
            TOGGLECARETPASTEPOS = 106,
            COMPLETEWORD = 107,
            SHOWMEMBERLIST = 108,
            FIRSTNONWHITEPREV = 109,
            FIRSTNONWHITENEXT = 110,
            HELPKEYWORD = 111,
            FORMATSELECTION = 112,
            OPENURL = 113,
            INSERTFILE = 114,
            TOGGLESHORTCUT = 115,
            QUICKINFO = 116,
            LEFT_EXT_COL = 117,
            RIGHT_EXT_COL = 118,
            UP_EXT_COL = 119,
            DOWN_EXT_COL = 120,
            TOGGLEWORDWRAP = 121,
            ISEARCH = 122,
            ISEARCHBACK = 123,
            BOL_EXT_COL = 124,
            EOL_EXT_COL = 125,
            WORDPREV_EXT_COL = 126,
            WORDNEXT_EXT_COL = 127,
            OUTLN_HIDE_SELECTION = 128,
            OUTLN_TOGGLE_CURRENT = 129,
            OUTLN_TOGGLE_ALL = 130,
            OUTLN_STOP_HIDING_ALL = 131,
            OUTLN_STOP_HIDING_CURRENT = 132,
            OUTLN_COLLAPSE_TO_DEF = 133,
            DOUBLECLICK = 134,
            EXTERNALLY_HANDLED_WIDGET_CLICK = 135,
            COMMENT_BLOCK = 136,
            UNCOMMENT_BLOCK = 137,
            OPENFILE = 138,
            NAVIGATETOURL = 139,

            // For editor internal use only
            HANDLEIMEMESSAGE = 140,

            SELTOGOBACK = 141,
            COMPLETION_HIDE_ADVANCED = 142,

            FORMATDOCUMENT = 143,
            OUTLN_START_AUTOHIDING = 144,

            // Last Standard Editor Command (+1)
            FINAL = 145,

            ECMD_DECREASEFILTER = 146,
            ECMD_COPYTIP = 148,
            ECMD_PASTETIP = 149,
            ECMD_LEFTCLICK = 150,
            ECMD_GOTONEXTBOOKMARKINDOC = 151,
            ECMD_GOTOPREVBOOKMARKINDOC = 152,
            ECMD_INVOKESNIPPETFROMSHORTCUT = 154,

            AUTOCOMPLETE = 155,

            ///  <include file='doc\VSConstants.uex' path='docs/doc[@for="VSStd2KCmdID.ECMD_INVOKESNIPPETPICKER2"]/*' />
            ECMD_INVOKESNIPPETPICKER2 = 156,
            ///  <include file='doc\VSConstants.uex' path='docs/doc[@for="VSStd2KCmdID.ECMD_DELETEALLBOOKMARKSINDOC"]/*' />
            ECMD_DELETEALLBOOKMARKSINDOC = 157,
            ///  <include file='doc\VSConstants.uex' path='docs/doc[@for="VSStd2KCmdID.ECMD_CONVERTTABSTOSPACES"]/*' />
            ECMD_CONVERTTABSTOSPACES = 158,
            ///  <include file='doc\VSConstants.uex' path='docs/doc[@for="VSStd2KCmdID.ECMD_CONVERTSPACESTOTABS"]/*' />
            ECMD_CONVERTSPACESTOTABS = 159,
            ///  <include file='doc\VSConstants.uex' path='docs/doc[@for="VSStd2KCmdID.ECMD_FINAL"]/*' />
            ECMD_FINAL = 160,

            ///////////////////////////////////////////////////////////////
            // Some new commands created during CTC file rationalisation
            ///////////////////////////////////////////////////////////////
            STOP = 220,
            REVERSECANCEL = 221,
            SLNREFRESH = 222,
            SAVECOPYOFITEMAS = 223,
            //
            // Shareable commands originating in the HTML editor
            //
            NEWELEMENT = 224,
            NEWATTRIBUTE = 225,
            NEWCOMPLEXTYPE = 226,
            NEWSIMPLETYPE = 227,
            NEWGROUP = 228,
            NEWATTRIBUTEGROUP = 229,
            NEWKEY = 230,
            NEWRELATION = 231,
            EDITKEY = 232,
            EDITRELATION = 233,
            MAKETYPEGLOBAL = 234,
            PREVIEWDATASET = 235,
            GENERATEDATASET = 236,
            CREATESCHEMA = 237,
            LAYOUTINDENT = 238,
            LAYOUTUNINDENT = 239,
            REMOVEHANDLER = 240,
            EDITHANDLER = 241,
            ADDHANDLER = 242,
            STYLE = 243,
            STYLEGETLIST = 244,
            FONTSTYLE = 245,
            FONTSTYLEGETLIST = 246,
            PASTEASHTML = 247,
            VIEWBORDERS = 248,
            VIEWDETAILS = 249,
            EXPANDCONTROLS = 250,
            COLLAPSECONTROLS = 251,
            SHOWSCRIPTONLY = 252,
            INSERTTABLE = 253,
            INSERTCOLLEFT = 254,
            INSERTCOLRIGHT = 255,
            INSERTROWABOVE = 256,
            INSERTROWBELOW = 257,
            DELETETABLE = 258,
            DELETECOLS = 259,
            DELETEROWS = 260,
            SELECTTABLE = 261,
            SELECTTABLECOL = 262,
            SELECTTABLEROW = 263,
            SELECTTABLECELL = 264,
            MERGECELLS = 265,
            SPLITCELL = 266,
            INSERTCELL = 267,
            DELETECELLS = 268,
            SEAMLESSFRAME = 269,
            VIEWFRAME = 270,
            DELETEFRAME = 271,
            SETFRAMESOURCE = 272,
            NEWLEFTFRAME = 273,
            NEWRIGHTFRAME = 274,
            NEWTOPFRAME = 275,
            NEWBOTTOMFRAME = 276,
            SHOWGRID = 277,
            SNAPTOGRID = 278,
            BOOKMARK = 279,
            HYPERLINK = 280,
            IMAGE = 281,
            INSERTFORM = 282,
            INSERTSPAN = 283,
            DIV = 284,
            HTMLCLIENTSCRIPTBLOCK = 285,
            HTMLSERVERSCRIPTBLOCK = 286,
            BULLETEDLIST = 287,
            NUMBEREDLIST = 288,
            EDITSCRIPT = 289,
            EDITCODEBEHIND = 290,
            DOCOUTLINEHTML = 291,
            DOCOUTLINESCRIPT = 292,
            RUNATSERVER = 293,
            WEBFORMSVERBS = 294,
            WEBFORMSTEMPLATES = 295,
            ENDTEMPLATE = 296,
            EDITDEFAULTEVENT = 297,
            SUPERSCRIPT = 298,
            SUBSCRIPT = 299,
            EDITSTYLE = 300,
            ADDIMAGEHEIGHTWIDTH = 301,
            REMOVEIMAGEHEIGHTWIDTH = 302,
            LOCKELEMENT = 303,
            VIEWSTYLEORGANIZER = 304,
            ECMD_AUTOCLOSEOVERRIDE = 305,
            NEWANY = 306,
            NEWANYATTRIBUTE = 307,
            DELETEKEY = 308,
            AUTOARRANGE = 309,
            VALIDATESCHEMA = 310,
            NEWFACET = 311,
            VALIDATEXMLDATA = 312,
            DOCOUTLINETOGGLE = 313,
            VALIDATEHTMLDATA = 314,
            VIEWXMLSCHEMAOVERVIEW = 315,
            SHOWDEFAULTVIEW = 316,
            EXPAND_CHILDREN = 317,
            COLLAPSE_CHILDREN = 318,
            TOPDOWNLAYOUT = 319,
            LEFTRIGHTLAYOUT = 320,
            INSERTCELLRIGHT = 321,
            EDITMASTER = 322,
            INSERTSNIPPET = 323,
            FORMATANDVALIDATION = 324,
            COLLAPSETAG = 325,
            SELECT_TAG = 329,
            SELECT_TAG_CONTENT = 330,
            CHECK_ACCESSIBILITY = 331,
            UNCOLLAPSETAG = 332,
            GENERATEPAGERESOURCE = 333,
            SHOWNONVISUALCONTROLS = 334,
            RESIZECOLUMN = 335,
            RESIZEROW = 336,
            MAKEABSOLUTE = 337,
            MAKERELATIVE = 338,
            MAKESTATIC = 339,
            INSERTLAYER = 340,
            UPDATEDESIGNVIEW = 341,
            UPDATESOURCEVIEW = 342,
            INSERTCAPTION = 343,
            DELETECAPTION = 344,
            MAKEPOSITIONNOTSET = 345,
            AUTOPOSITIONOPTIONS = 346,
            EDITIMAGE = 347,
            //
            // Shareable commands originating in the VC project
            //
            COMPILE = 350,
            //
            PROJSETTINGS = 352,
            LINKONLY = 353,
            //
            REMOVE = 355,
            PROJSTARTDEBUG = 356,
            PROJSTEPINTO = 357,
            ECMD_UPDATEMGDRES = 358,
            //
            //
            UPDATEWEBREF = 360,
            //
            ADDRESOURCE = 362,
            WEBDEPLOY = 363,
            ECMD_PROJTOOLORDER = 367,
            ECMD_PROJECTTOOLFILES = 368,
            ECMD_OTB_PGO_INSTRUMENT = 369,
            ECMD_OTB_PGO_OPT = 370,
            ECMD_OTB_PGO_UPDATE = 371,
            ECMD_OTB_PGO_RUNSCENARIO = 372,

            //
            // Shareable commands originating in the VB and VBA projects
            // Note that there are two versions of each command. One
            // version is originally from the main (project) menu and the
            // other version from a cascading "Add" context menu. The main
            // difference between the two commands is that the main menu
            // version starts with the text "Add" whereas this is not
            // present on the context menu version.
            //
            ADDHTMLPAGE = 400,
            ADDHTMLPAGECTX = 401,
            ADDMODULE = 402,
            ADDMODULECTX = 403,
            // unused 404
            // unused 405
            ADDWFCFORM = 406,
            // unused 407
            // unused 408
            // unused 409
            ADDWEBFORM = 410,
            ECMD_ADDMASTERPAGE = 411,
            ADDUSERCONTROL = 412,
            ECMD_ADDCONTENTPAGE = 413,
            // unused 414 to 425
            ADDDHTMLPAGE = 426,
            // unused 427 to 431
            ADDIMAGEGENERATOR = 432,
            // unused 433
            ADDINHERWFCFORM = 434,
            // unused 435
            ADDINHERCONTROL = 436,
            // unused 437
            ADDWEBUSERCONTROL = 438,
            BUILDANDBROWSE = 439,
            // unused 440
            // unused 441
            ADDTBXCOMPONENT = 442,
            // unused 443
            ADDWEBSERVICE = 444,
            ECMD_ADDSTYLESHEET = 445,
            ECMD_SETBROWSELOCATION = 446,
            ECMD_REFRESHFOLDER = 447,
            ECMD_SETBROWSELOCATIONCTX = 448,
            ECMD_VIEWMARKUP = 449,
            ECMD_NEXTMETHOD = 450,
            ECMD_PREVMETHOD = 451,
            //
            // VB refactoring commands
            //
            ECMD_RENAMESYMBOL = 452,
            ECMD_SHOWREFERENCES = 453,
            ECMD_CREATESNIPPET = 454,
            ECMD_CREATEREPLACEMENT = 455,
            ECMD_INSERTCOMMENT = 456,
            VIEWCOMPONENTDESIGNER = 457,
            GOTOTYPEDEF = 458,
            SHOWSNIPPETHIGHLIGHTING = 459,
            HIDESNIPPETHIGHLIGHTING = 460,
            //
            // Shareable commands originating in the VFP project
            //
            ADDVFPPAGE = 500,
            SETBREAKPOINT = 501,
            //
            // Shareable commands originating in the HELP WORKSHOP project
            //
            SHOWALLFILES = 600,
            ADDTOPROJECT = 601,
            ADDBLANKNODE = 602,
            ADDNODEFROMFILE = 603,
            CHANGEURLFROMFILE = 604,
            EDITTOPIC = 605,
            EDITTITLE = 606,
            MOVENODEUP = 607,
            MOVENODEDOWN = 608,
            MOVENODELEFT = 609,
            MOVENODERIGHT = 610,
            //
            // Shareable commands originating in the Deploy project
            //
            // Note there are two groups of deploy project commands.
            // The first group of deploy commands.
            ADDOUTPUT = 700,
            ADDFILE = 701,
            MERGEMODULE = 702,
            ADDCOMPONENTS = 703,
            LAUNCHINSTALLER = 704,
            LAUNCHUNINSTALL = 705,
            LAUNCHORCA = 706,
            FILESYSTEMEDITOR = 707,
            REGISTRYEDITOR = 708,
            FILETYPESEDITOR = 709,
            USERINTERFACEEDITOR = 710,
            CUSTOMACTIONSEDITOR = 711,
            LAUNCHCONDITIONSEDITOR = 712,
            EDITOR = 713,
            EXCLUDE = 714,
            REFRESHDEPENDENCIES = 715,
            VIEWOUTPUTS = 716,
            VIEWDEPENDENCIES = 717,
            VIEWFILTER = 718,

            //
            // The Second group of deploy commands.
            // Note that there is a special sub-group in which the relative 
            // positions are important (see below)
            //
            KEY = 750,
            STRING = 751,
            BINARY = 752,
            DWORD = 753,
            KEYSOLO = 754,
            IMPORT = 755,
            FOLDER = 756,
            PROJECTOUTPUT = 757,
            FILE = 758,
            ADDMERGEMODULES = 759,
            CREATESHORTCUT = 760,
            LARGEICONS = 761,
            SMALLICONS = 762,
            LIST = 763,
            DETAILS = 764,
            ADDFILETYPE = 765,
            ADDACTION = 766,
            SETASDEFAULT = 767,
            MOVEUP = 768,
            MOVEDOWN = 769,
            ADDDIALOG = 770,
            IMPORTDIALOG = 771,
            ADDFILESEARCH = 772,
            ADDREGISTRYSEARCH = 773,
            ADDCOMPONENTSEARCH = 774,
            ADDLAUNCHCONDITION = 775,
            ADDCUSTOMACTION = 776,
            OUTPUTS = 777,
            DEPENDENCIES = 778,
            FILTER = 779,
            COMPONENTS = 780,
            ENVSTRING = 781,
            CREATEEMPTYSHORTCUT = 782,
            ADDFILECONDITION = 783,
            ADDREGISTRYCONDITION = 784,
            ADDCOMPONENTCONDITION = 785,
            ADDURTCONDITION = 786,
            ADDIISCONDITION = 787,

            //
            // The relative positions of the commands within the following deploy
            // subgroup must remain unaltered, although the group as a whole may
            // be repositioned. Note that the first and last elements are special
            // boundary elements.
            SPECIALFOLDERBASE = 800,
            USERSAPPLICATIONDATAFOLDER = 800,

            COMMONFILES64FOLDER = 801,
            COMMONFILESFOLDER = 802,
            CUSTOMFOLDER = 803,
            USERSDESKTOP = 804,
            USERSFAVORITESFOLDER = 805,
            FONTSFOLDER = 806,
            GLOBALASSEMBLYCACHEFOLDER = 807,
            MODULERETARGETABLEFOLDER = 808,
            USERSPERSONALDATAFOLDER = 809,
            PROGRAMFILES64FOLDER = 810,
            PROGRAMFILESFOLDER = 811,
            USERSPROGRAMSMENU = 812,
            USERSSENDTOMENU = 813,
            SHAREDCOMPONENTSFOLDER = 814,
            USERSSTARTMENU = 815,
            USERSSTARTUPFOLDER = 816,
            SYSTEM64FOLDER = 817,
            SYSTEMFOLDER = 818,
            APPLICATIONFOLDER = 819,
            USERSTEMPLATEFOLDER = 820,
            WEBCUSTOMFOLDER = 821,
            WINDOWSFOLDER = 822,
            SPECIALFOLDERLAST = 823,
            // End of deploy sub-group
            //
            // Shareable commands originating in the Visual Studio Analyzer project
            //
            EXPORTEVENTS = 900,
            IMPORTEVENTS = 901,
            VIEWEVENT = 902,
            VIEWEVENTLIST = 903,
            VIEWCHART = 904,
            VIEWMACHINEDIAGRAM = 905,
            VIEWPROCESSDIAGRAM = 906,
            VIEWSOURCEDIAGRAM = 907,
            VIEWSTRUCTUREDIAGRAM = 908,
            VIEWTIMELINE = 909,
            VIEWSUMMARY = 910,
            APPLYFILTER = 911,
            CLEARFILTER = 912,
            STARTRECORDING = 913,
            STOPRECORDING = 914,
            PAUSERECORDING = 915,
            ACTIVATEFILTER = 916,
            SHOWFIRSTEVENT = 917,
            SHOWPREVIOUSEVENT = 918,
            SHOWNEXTEVENT = 919,
            SHOWLASTEVENT = 920,
            REPLAYEVENTS = 921,
            STOPREPLAY = 922,
            INCREASEPLAYBACKSPEED = 923,
            DECREASEPLAYBACKSPEED = 924,
            ADDMACHINE = 925,
            ADDREMOVECOLUMNS = 926,
            SORTCOLUMNS = 927,
            SAVECOLUMNSETTINGS = 928,
            RESETCOLUMNSETTINGS = 929,
            SIZECOLUMNSTOFIT = 930,
            AUTOSELECT = 931,
            AUTOFILTER = 932,
            AUTOPLAYTRACK = 933,
            GOTOEVENT = 934,
            ZOOMTOFIT = 935,
            ADDGRAPH = 936,
            REMOVEGRAPH = 937,
            CONNECTMACHINE = 938,
            DISCONNECTMACHINE = 939,
            EXPANDSELECTION = 940,
            COLLAPSESELECTION = 941,
            ADDFILTER = 942,
            ADDPREDEFINED0 = 943,
            ADDPREDEFINED1 = 944,
            ADDPREDEFINED2 = 945,
            ADDPREDEFINED3 = 946,
            ADDPREDEFINED4 = 947,
            ADDPREDEFINED5 = 948,
            ADDPREDEFINED6 = 949,
            ADDPREDEFINED7 = 950,
            ADDPREDEFINED8 = 951,
            TIMELINESIZETOFIT = 952,

            //
            // Shareable commands originating with Crystal Reports
            //
            FIELDVIEW = 1000,
            SELECTEXPERT = 1001,
            TOPNEXPERT = 1002,
            SORTORDER = 1003,
            PROPPAGE = 1004,
            HELP = 1005,
            SAVEREPORT = 1006,
            INSERTSUMMARY = 1007,
            INSERTGROUP = 1008,
            INSERTSUBREPORT = 1009,
            INSERTCHART = 1010,
            INSERTPICTURE = 1011,
            //
            // Shareable commands from the common project area (DirPrj)
            //
            SETASSTARTPAGE = 1100,
            RECALCULATELINKS = 1101,
            WEBPERMISSIONS = 1102,
            COMPARETOMASTER = 1103,
            WORKOFFLINE = 1104,
            SYNCHRONIZEFOLDER = 1105,
            SYNCHRONIZEALLFOLDERS = 1106,
            COPYPROJECT = 1107,
            IMPORTFILEFROMWEB = 1108,
            INCLUDEINPROJECT = 1109,
            EXCLUDEFROMPROJECT = 1110,
            BROKENLINKSREPORT = 1111,
            ADDPROJECTOUTPUTS = 1112,
            ADDREFERENCE = 1113,
            ADDWEBREFERENCE = 1114,
            ADDWEBREFERENCECTX = 1115,
            UPDATEWEBREFERENCE = 1116,
            RUNCUSTOMTOOL = 1117,
            SETRUNTIMEVERSION = 1118,
            VIEWREFINOBJECTBROWSER = 1119,
            PUBLISH = 1120,
            PUBLISHCTX = 1121,
            STARTOPTIONS = 1124,
            ADDREFERENCECTX = 1125,
            // note cmdidPropertyManager is consuming 1126  and it shouldn't
            STARTOPTIONSCTX = 1127,
            DETACHLOCALDATAFILECTX = 1128,
            ADDSERVICEREFERENCE = 1129,
            ADDSERVICEREFERENCECTX = 1130,
            UPDATESERVICEREFERENCE = 1131,
            CONFIGURESERVICEREFERENCE = 1132,
            //
            // Shareable commands for right drag operations
            //
            DRAG_MOVE = 1140,
            DRAG_COPY = 1141,
            DRAG_CANCEL = 1142,

            //
            // Shareable commands from the VC resource editor
            //
            TESTDIALOG = 1200,
            SPACEACROSS = 1201,
            SPACEDOWN = 1202,
            TOGGLEGRID = 1203,
            TOGGLEGUIDES = 1204,
            SIZETOTEXT = 1205,
            CENTERVERT = 1206,
            CENTERHORZ = 1207,
            FLIPDIALOG = 1208,
            SETTABORDER = 1209,
            BUTTONRIGHT = 1210,
            BUTTONBOTTOM = 1211,
            AUTOLAYOUTGROW = 1212,
            AUTOLAYOUTNORESIZE = 1213,
            AUTOLAYOUTOPTIMIZE = 1214,
            GUIDESETTINGS = 1215,
            RESOURCEINCLUDES = 1216,
            RESOURCESYMBOLS = 1217,
            OPENBINARY = 1218,
            RESOURCEOPEN = 1219,
            RESOURCENEW = 1220,
            RESOURCENEWCOPY = 1221,
            INSERT = 1222,
            EXPORT = 1223,
            CTLMOVELEFT = 1224,
            CTLMOVEDOWN = 1225,
            CTLMOVERIGHT = 1226,
            CTLMOVEUP = 1227,
            CTLSIZEDOWN = 1228,
            CTLSIZEUP = 1229,
            CTLSIZELEFT = 1230,
            CTLSIZERIGHT = 1231,
            NEWACCELERATOR = 1232,
            CAPTUREKEYSTROKE = 1233,
            INSERTACTIVEXCTL = 1234,
            INVERTCOLORS = 1235,
            FLIPHORIZONTAL = 1236,
            FLIPVERTICAL = 1237,
            ROTATE90 = 1238,
            SHOWCOLORSWINDOW = 1239,
            NEWSTRING = 1240,
            NEWINFOBLOCK = 1241,
            DELETEINFOBLOCK = 1242,
            ADJUSTCOLORS = 1243,
            LOADPALETTE = 1244,
            SAVEPALETTE = 1245,
            CHECKMNEMONICS = 1246,
            DRAWOPAQUE = 1247,
            TOOLBAREDITOR = 1248,
            GRIDSETTINGS = 1249,
            NEWDEVICEIMAGE = 1250,
            OPENDEVICEIMAGE = 1251,
            DELETEDEVICEIMAGE = 1252,
            VIEWASPOPUP = 1253,
            CHECKMENUMNEMONICS = 1254,
            SHOWIMAGEGRID = 1255,
            SHOWTILEGRID = 1256,
            MAGNIFY = 1257,
            ResProps = 1258,
            IMPORTICONIMAGE = 1259,
            EXPORTICONIMAGE = 1260,
            OPENEXTERNALEDITOR = 1261,

            //
            // Shareable commands from the VC resource editor (Image editor toolbar)
            //
            PICKRECTANGLE = 1300,
            PICKREGION = 1301,
            PICKCOLOR = 1302,
            ERASERTOOL = 1303,
            FILLTOOL = 1304,
            PENCILTOOL = 1305,
            BRUSHTOOL = 1306,
            AIRBRUSHTOOL = 1307,
            LINETOOL = 1308,
            CURVETOOL = 1309,
            TEXTTOOL = 1310,
            RECTTOOL = 1311,
            OUTLINERECTTOOL = 1312,
            FILLEDRECTTOOL = 1313,
            ROUNDRECTTOOL = 1314,
            OUTLINEROUNDRECTTOOL = 1315,
            FILLEDROUNDRECTTOOL = 1316,
            ELLIPSETOOL = 1317,
            OUTLINEELLIPSETOOL = 1318,
            FILLEDELLIPSETOOL = 1319,
            SETHOTSPOT = 1320,
            ZOOMTOOL = 1321,
            ZOOM1X = 1322,
            ZOOM2X = 1323,
            ZOOM6X = 1324,
            ZOOM8X = 1325,
            TRANSPARENTBCKGRND = 1326,
            OPAQUEBCKGRND = 1327,
            //---------------------------------------------------
            // The commands ECMD_ERASERSMALL thru ECMD_LINELARGER
            // must be left in the same order for the use of the
            // Resource Editor - They may however be relocated as
            // a complete block
            //---------------------------------------------------
            ERASERSMALL = 1328,
            ERASERMEDIUM = 1329,
            ERASERLARGE = 1330,
            ERASERLARGER = 1331,
            CIRCLELARGE = 1332,
            CIRCLEMEDIUM = 1333,
            CIRCLESMALL = 1334,
            SQUARELARGE = 1335,
            SQUAREMEDIUM = 1336,
            SQUARESMALL = 1337,
            LEFTDIAGLARGE = 1338,
            LEFTDIAGMEDIUM = 1339,
            LEFTDIAGSMALL = 1340,
            RIGHTDIAGLARGE = 1341,
            RIGHTDIAGMEDIUM = 1342,
            RIGHTDIAGSMALL = 1343,
            SPLASHSMALL = 1344,
            SPLASHMEDIUM = 1345,
            SPLASHLARGE = 1346,
            LINESMALLER = 1347,
            LINESMALL = 1348,
            LINEMEDIUM = 1349,
            LINELARGE = 1350,
            LINELARGER = 1351,
            LARGERBRUSH = 1352,
            LARGEBRUSH = 1353,
            STDBRUSH = 1354,
            SMALLBRUSH = 1355,
            SMALLERBRUSH = 1356,
            ZOOMIN = 1357,
            ZOOMOUT = 1358,
            PREVCOLOR = 1359,
            PREVECOLOR = 1360,
            NEXTCOLOR = 1361,
            NEXTECOLOR = 1362,
            IMG_OPTIONS = 1363,

            //
            // Sharable Commands from Visual Web Developer (website projects)
            //
            STARTWEBADMINTOOL = 1400,
            NESTRELATEDFILES = 1401,

            //---------------------------------------------------

            //
            // Shareable commands from WINFORMS
            //
            CANCELDRAG = 1500,
            DEFAULTACTION = 1501,
            CTLMOVEUPGRID = 1502,
            CTLMOVEDOWNGRID = 1503,
            CTLMOVELEFTGRID = 1504,
            CTLMOVERIGHTGRID = 1505,
            CTLSIZERIGHTGRID = 1506,
            CTLSIZEUPGRID = 1507,
            CTLSIZELEFTGRID = 1508,
            CTLSIZEDOWNGRID = 1509,
            NEXTCTL = 1510,
            PREVCTL = 1511,

            RENAME = 1550,
            EXTRACTMETHOD = 1551,
            ENCAPSULATEFIELD = 1552,
            EXTRACTINTERFACE = 1553,
            PROMOTELOCAL = 1554,
            REMOVEPARAMETERS = 1555,
            REORDERPARAMETERS = 1556,
            GENERATEMETHODSTUB = 1557,
            IMPLEMENTINTERFACEIMPLICIT = 1558,
            IMPLEMENTINTERFACEEXPLICIT = 1559,
            IMPLEMENTABSTRACTCLASS = 1560,
            SURROUNDWITH = 1561,

            // this is coming in with the VS2K guid?
            QUICKOBJECTSEARCH = 1119,
            ToggleWordWrapOW = 1600,
            GotoNextLocationOW = 1601,
            GotoPrevLocationOW = 1602,
            BuildOnlyProject = 1603,
            RebuildOnlyProject = 1604,
            CleanOnlyProject = 1605,
            SetBuildStartupsOnlyOnRun = 1606,
            UnhideAll = 1607,
            HideFolder = 1608,
            UnhideFolders = 1609,
            CopyFullPathName = 1610,
            SaveFolderAsSolution = 1611,
            ManageUserSettings = 1612,
            NewSolutionFolder = 1613,
            ClearPaneOW = 1615,
            GotoErrorTagOW = 1616,
            GotoNextErrorTagOW = 1617,
            GotoPrevErrorTagOW = 1618,
            ClearPaneFR1 = 1619,
            GotoErrorTagFR1 = 1620,
            GotoNextErrorTagFR1 = 1621,
            GotoPrevErrorTagFR1 = 1622,
            ClearPaneFR2 = 1623,
            GotoErrorTagFR2 = 1624,
            GotoNextErrorTagFR2 = 1625,
            GotoPrevErrorTagFR2 = 1626,
            OutputPaneCombo = 1627,
            OutputPaneComboList = 1628,
            DisableDockingChanges = 1629,
            ToggleFloat = 1630,
            ResetLayout = 1631,
            NewSolutionFolderBar = 1638,
            DataShortcut = 1639,
            NextToolWindow = 1640,
            PrevToolWindow = 1641,
            BrowseToFileInExplorer = 1642,
            ShowEzMDIFileMenu = 1643,
            PrevToolWindowNav = 1645,
            StaticAnalysisOnlyProject = 1646,
            ECMD_RUNFXCOPSEL = 1647,
            CloseAllButThis = 1650,
            //
            // Class View commands
            //
            CVShowInheritedMembers = 1651,
            CVShowBaseTypes = 1652,
            CVShowDerivedTypes = 1653,
            CVShowHidden = 1654,
            CVBack = 1655,
            CVForward = 1656,
            CVSearchCombo = 1657,
            CVSearch = 1658,
            CVSortObjectsAlpha = 1659,
            CVSortObjectsType = 1660,
            CVSortObjectsAccess = 1661,
            CVGroupObjectsType = 1662,
            CVSortMembersAlpha = 1663,
            CVSortMembersType = 1664,
            CVSortMembersAccess = 1665,
            CVTypeBrowserSettings = 1666,
            CVViewMembersAsImplementor = 1667,
            CVViewMembersAsSubclass = 1668,
            CVViewMembersAsUser = 1669,
            CVReserved1 = 1670,
            CVReserved2 = 1671,
            CVShowProjectReferences = 1672,
            CVGroupMembersType = 1673,
            CVClearSearch = 1674,
            CVFilterToType = 1675,
            CVSortByBestMatch = 1676,
            CVSearchMRUList = 1677,
            CVViewOtherMembers = 1678,
            CVSearchCmd = 1679,
            CVGoToSearchCmd = 1680,

            ControlGallery = 1700,
            //
            // Object Browser commands
            //
            OBShowInheritedMembers = 1711,
            OBShowBaseTypes = 1712,
            OBShowDerivedTypes = 1713,
            OBShowHidden = 1714,
            OBBack = 1715,
            OBForward = 1716,
            OBSearchCombo = 1717,
            OBSearch = 1718,
            OBSortObjectsAlpha = 1719,
            OBSortObjectsType = 1720,
            OBSortObjectsAccess = 1721,
            OBGroupObjectsType = 1722,
            OBSortMembersAlpha = 1723,
            OBSortMembersType = 1724,
            OBSortMembersAccess = 1725,
            OBTypeBrowserSettings = 1726,
            OBViewMembersAsImplementor = 1727,
            OBViewMembersAsSubclass = 1728,
            OBViewMembersAsUser = 1729,
            OBNamespacesView = 1730,
            OBContainersView = 1731,
            OBReserved1 = 1732,
            OBGroupMembersType = 1733,
            OBClearSearch = 1734,
            OBFilterToType = 1735,
            OBSortByBestMatch = 1736,
            OBSearchMRUList = 1737,
            OBViewOtherMembers = 1738,
            OBSearchCmd = 1739,
            OBGoToSearchCmd = 1740,
            OBShowExtensionMembers = 1741,

            FullScreen2 = 1775,
            //
            // find symbol results sorting command
            //
            FSRSortObjectsAlpha = 1776,
            FSRSortByBestMatch = 1777,
            NavigateBack = 1800,
            NavigateForward = 1801,

            ECMD_CORRECTION_1 = 1900,
            ECMD_CORRECTION_2 = 1901,
            ECMD_CORRECTION_3 = 1902,
            ECMD_CORRECTION_4 = 1903,
            ECMD_CORRECTION_5 = 1904,
            ECMD_CORRECTION_6 = 1905,
            ECMD_CORRECTION_7 = 1906,
            ECMD_CORRECTION_8 = 1907,
            ECMD_CORRECTION_9 = 1908,
            ECMD_CORRECTION_10 = 1909,

            OBAddReference = 1914,
            [Obsolete("VSStd2KCmdID.FindReferences has been deprecated; please use VSStd97CmdID.FindReferences instead.", false)]
            FindReferences = 1915,

            CodeDefView = 1926,
            CodeDefViewGoToPrev = 1927,
            CodeDefViewGoToNext = 1928,
            CodeDefViewEditDefinition = 1929,
            CodeDefViewChooseEncoding = 1930,
            ViewInClassDiagram = 1931,
            ECMD_ADDDBTABLE = 1950,
            ECMD_ADDDATATABLE = 1951,
            ECMD_ADDFUNCTION = 1952,
            ECMD_ADDRELATION = 1953,
            ECMD_ADDKEY = 1954,
            ECMD_ADDCOLUMN = 1955,
            ECMD_CONVERT_DBTABLE = 1956,
            ECMD_CONVERT_DATATABLE = 1957,
            ECMD_GENERATE_DATABASE = 1958,
            ECMD_CONFIGURE_CONNECTIONS = 1959,
            ECMD_IMPORT_XMLSCHEMA = 1960,
            ECMD_SYNC_WITH_DATABASE = 1961,
            ECMD_CONFIGURE = 1962,
            ECMD_CREATE_DATAFORM = 1963,
            ECMD_CREATE_ENUM = 1964,
            ECMD_INSERT_FUNCTION = 1965,
            ECMD_EDIT_FUNCTION = 1966,
            ECMD_SET_PRIMARY_KEY = 1967,
            ECMD_INSERT_COLUMN = 1968,
            ECMD_AUTO_SIZE = 1969,
            ECMD_SHOW_RELATION_LABELS = 1970,
            VSDGenerateDataSet = 1971,
            VSDPreview = 1972,
            VSDConfigureAdapter = 1973,
            VSDViewDatasetSchema = 1974,
            VSDDatasetProperties = 1975,
            VSDParameterizeForm = 1976,
            VSDAddChildForm = 1977,
            ECMD_EDITCONSTRAINT = 1978,
            ECMD_DELETECONSTRAINT = 1979,
            ECMD_EDITDATARELATION = 1980,
            CloseProject = 1982,
            ReloadCommandBars = 1983,
            SolutionPlatform = 1990,
            SolutionPlatformGetList = 1991,
            ECMD_DATAACCESSOR = 2000,
            ECMD_ADD_DATAACCESSOR = 2001,
            ECMD_QUERY = 2002,
            ECMD_ADD_QUERY = 2003,
            ECMD_PUBLISHSELECTION = 2005,
            ECMD_PUBLISHSLNCTX = 2006,

            CallBrowserShowCallsTo = 2010,
            CallBrowserShowCallsFrom = 2011,
            CallBrowserShowNewCallsTo = 2012,
            CallBrowserShowNewCallsFrom = 2013,
            CallBrowser1ShowCallsTo = 2014,
            CallBrowser2ShowCallsTo = 2015,
            CallBrowser3ShowCallsTo = 2016,
            CallBrowser4ShowCallsTo = 2017,
            CallBrowser5ShowCallsTo = 2018,
            CallBrowser6ShowCallsTo = 2019,
            CallBrowser7ShowCallsTo = 2020,
            CallBrowser8ShowCallsTo = 2021,
            CallBrowser9ShowCallsTo = 2022,
            CallBrowser10ShowCallsTo = 2023,
            CallBrowser11ShowCallsTo = 2024,
            CallBrowser12ShowCallsTo = 2025,
            CallBrowser13ShowCallsTo = 2026,
            CallBrowser14ShowCallsTo = 2027,
            CallBrowser15ShowCallsTo = 2028,
            CallBrowser16ShowCallsTo = 2029,
            CallBrowser1ShowCallsFrom = 2030,
            CallBrowser2ShowCallsFrom = 2031,
            CallBrowser3ShowCallsFrom = 2032,
            CallBrowser4ShowCallsFrom = 2033,
            CallBrowser5ShowCallsFrom = 2034,
            CallBrowser6ShowCallsFrom = 2035,
            CallBrowser7ShowCallsFrom = 2036,
            CallBrowser8ShowCallsFrom = 2037,
            CallBrowser9ShowCallsFrom = 2038,
            CallBrowser10ShowCallsFrom = 2039,
            CallBrowser11ShowCallsFrom = 2040,
            CallBrowser12ShowCallsFrom = 2041,
            CallBrowser13ShowCallsFrom = 2042,
            CallBrowser14ShowCallsFrom = 2043,
            CallBrowser15ShowCallsFrom = 2044,
            CallBrowser16ShowCallsFrom = 2045,
            CallBrowser1ShowFullNames = 2046,
            CallBrowser2ShowFullNames = 2047,
            CallBrowser3ShowFullNames = 2048,
            CallBrowser4ShowFullNames = 2049,
            CallBrowser5ShowFullNames = 2050,
            CallBrowser6ShowFullNames = 2051,
            CallBrowser7ShowFullNames = 2052,
            CallBrowser8ShowFullNames = 2053,
            CallBrowser9ShowFullNames = 2054,
            CallBrowser10ShowFullNames = 2055,
            CallBrowser11ShowFullNames = 2056,
            CallBrowser12ShowFullNames = 2057,
            CallBrowser13ShowFullNames = 2058,
            CallBrowser14ShowFullNames = 2059,
            CallBrowser15ShowFullNames = 2060,
            CallBrowser16ShowFullNames = 2061,
            CallBrowser1Settings = 2062,
            CallBrowser2Settings = 2063,
            CallBrowser3Settings = 2064,
            CallBrowser4Settings = 2065,
            CallBrowser5Settings = 2066,
            CallBrowser6Settings = 2067,
            CallBrowser7Settings = 2068,
            CallBrowser8Settings = 2069,
            CallBrowser9Settings = 2070,
            CallBrowser10Settings = 2071,
            CallBrowser11Settings = 2072,
            CallBrowser12Settings = 2073,
            CallBrowser13Settings = 2074,
            CallBrowser14Settings = 2075,
            CallBrowser15Settings = 2076,
            CallBrowser16Settings = 2077,
            CallBrowser1SortAlpha = 2078,
            CallBrowser2SortAlpha = 2079,
            CallBrowser3SortAlpha = 2080,
            CallBrowser4SortAlpha = 2081,
            CallBrowser5SortAlpha = 2082,
            CallBrowser6SortAlpha = 2083,
            CallBrowser7SortAlpha = 2084,
            CallBrowser8SortAlpha = 2085,
            CallBrowser9SortAlpha = 2086,
            CallBrowser10SortAlpha = 2087,
            CallBrowser11SortAlpha = 2088,
            CallBrowser12SortAlpha = 2089,
            CallBrowser13SortAlpha = 2090,
            CallBrowser14SortAlpha = 2091,
            CallBrowser15SortAlpha = 2092,
            CallBrowser16SortAlpha = 2093,
            CallBrowser1SortAccess = 2094,
            CallBrowser2SortAccess = 2095,
            CallBrowser3SortAccess = 2096,
            CallBrowser4SortAccess = 2097,
            CallBrowser5SortAccess = 2098,
            CallBrowser6SortAccess = 2099,
            CallBrowser7SortAccess = 2100,
            CallBrowser8SortAccess = 2101,
            CallBrowser9SortAccess = 2102,
            CallBrowser10SortAccess = 2103,
            CallBrowser11SortAccess = 2104,
            CallBrowser12SortAccess = 2105,
            CallBrowser13SortAccess = 2106,
            CallBrowser14SortAccess = 2107,
            CallBrowser15SortAccess = 2108,
            CallBrowser16SortAccess = 2109,
            ShowCallBrowser = 2120,
            CallBrowser1 = 2121,
            CallBrowser2 = 2122,
            CallBrowser3 = 2123,
            CallBrowser4 = 2124,
            CallBrowser5 = 2125,
            CallBrowser6 = 2126,
            CallBrowser7 = 2127,
            CallBrowser8 = 2128,
            CallBrowser9 = 2129,
            CallBrowser10 = 2130,
            CallBrowser11 = 2131,
            CallBrowser12 = 2132,
            CallBrowser13 = 2133,
            CallBrowser14 = 2134,
            CallBrowser15 = 2135,
            CallBrowser16 = 2136,
            CallBrowser17 = 2137,
            GlobalUndo = 2138,
            GlobalRedo = 2139,
            CallBrowserShowCallsToCmd = 2140,
            CallBrowserShowCallsFromCmd = 2141,
            CallBrowserShowNewCallsToCmd = 2142,
            CallBrowserShowNewCallsFromCmd = 2143,
            CallBrowser1Search = 2145,
            CallBrowser2Search = 2146,
            CallBrowser3Search = 2147,
            CallBrowser4Search = 2148,
            CallBrowser5Search = 2149,
            CallBrowser6Search = 2150,
            CallBrowser7Search = 2151,
            CallBrowser8Search = 2152,
            CallBrowser9Search = 2153,
            CallBrowser10Search = 2154,
            CallBrowser11Search = 2155,
            CallBrowser12Search = 2156,
            CallBrowser13Search = 2157,
            CallBrowser14Search = 2158,
            CallBrowser15Search = 2159,
            CallBrowser16Search = 2160,
            CallBrowser1Refresh = 2161,
            CallBrowser2Refresh = 2162,
            CallBrowser3Refresh = 2163,
            CallBrowser4Refresh = 2164,
            CallBrowser5Refresh = 2165,
            CallBrowser6Refresh = 2166,
            CallBrowser7Refresh = 2167,
            CallBrowser8Refresh = 2168,
            CallBrowser9Refresh = 2169,
            CallBrowser10Refresh = 2170,
            CallBrowser11Refresh = 2171,
            CallBrowser12Refresh = 2172,
            CallBrowser13Refresh = 2173,
            CallBrowser14Refresh = 2174,
            CallBrowser15Refresh = 2175,
            CallBrowser16Refresh = 2176,
            CallBrowser1SearchCombo = 2180,
            CallBrowser2SearchCombo = 2181,
            CallBrowser3SearchCombo = 2182,
            CallBrowser4SearchCombo = 2183,
            CallBrowser5SearchCombo = 2184,
            CallBrowser6SearchCombo = 2185,
            CallBrowser7SearchCombo = 2186,
            CallBrowser8SearchCombo = 2187,
            CallBrowser9SearchCombo = 2188,
            CallBrowser10SearchCombo = 2189,
            CallBrowser11SearchCombo = 2190,
            CallBrowser12SearchCombo = 2191,
            CallBrowser13SearchCombo = 2192,
            CallBrowser14SearchCombo = 2193,
            CallBrowser15SearchCombo = 2194,
            CallBrowser16SearchCombo = 2195,

            TaskListProviderCombo = 2200,
            TaskListProviderComboList = 2201,
            CreateUserTask = 2202,
            ErrorListShowErrors = 2210,
            ErrorListShowWarnings = 2211,
            ErrorListShowMessages = 2212,
            Registration = 2214,
            CallBrowser1SearchComboList = 2215,
            CallBrowser2SearchComboList = 2216,
            CallBrowser3SearchComboList = 2217,
            CallBrowser4SearchComboList = 2218,
            CallBrowser5SearchComboList = 2219,
            CallBrowser6SearchComboList = 2220,
            CallBrowser7SearchComboList = 2221,
            CallBrowser8SearchComboList = 2222,
            CallBrowser9SearchComboList = 2223,
            CallBrowser10SearchComboList = 2224,
            CallBrowser11SearchComboList = 2225,
            CallBrowser12SearchComboList = 2226,
            CallBrowser13SearchComboList = 2227,
            CallBrowser14SearchComboList = 2228,
            CallBrowser15SearchComboList = 2229,
            CallBrowser16SearchComboList = 2230,

            SnippetProp = 2240,
            SnippetRef = 2241,
            SnippetRepl = 2242,

            StartPage = 2245,

            EditorLineFirstColumn = 2250,
            EditorLineFirstColumnExtend = 2251,

            SEServerExplorer = 2260,
            SEDataExplorer = 2261,

            ToggleConsumeFirstCompletionMode = 2303,

            ECMD_VALIDATION_TARGET = 11281,
            ECMD_VALIDATION_TARGET_GET_LIST = 11282,
            ECMD_CSS_TARGET = 11283,
            ECMD_CSS_TARGET_GET_LIST = 11284,
            Design = 0x3000,
            DesignOn = 0x3001,
            SEDesign = 0x3003,
            NewDiagram = 0x3004,
            NewTable = 0x3006,
            NewDBItem = 0x300E,
            NewTrigger = 0x3010,
            Debug = 0x3012,
            NewProcedure = 0x3013,
            NewQuery = 0x3014,
            RefreshLocal = 0x3015,
            DbAddDataConnection = 0x3017,
            DBDefDBRef = 0x3018,
            RunCmd = 0x3019,
            RunOn = 0x301A,
            NewDBRef = 0x301B,
            SetAsDef = 0x301C,
            CreateCmdFile = 0x301D,
            Cancel = 0x301E,
            NewDatabase = 0x3020,
            NewUser = 0x3021,
            NewRole = 0x3022,
            ChangeLogin = 0x3023,
            NewView = 0x3024,
            ModifyConnection = 0x3025,
            Disconnect = 0x3026,
            CopyScript = 0x3027,
            AddSCC = 0x3028,
            RemoveSCC = 0x3029,
            GetLatest = 0x3030,
            CheckOut = 0x3031,
            CheckIn = 0x3032,
            UndoCheckOut = 0x3033,
            AddItemSCC = 0x3034,
            NewPackageSpec = 0x3035,
            NewPackageBody = 0x3036,
            InsertSQL = 0x3037,
            RunSelection = 0x3038,
            UpdateScript = 0x3039,
            NewScript = 0x303C,
            NewFunction = 0x303D,
            NewTableFunction = 0x303E,
            NewInlineFunction = 0x303F,
            AddDiagram = 0x3040,
            AddTable = 0x3041,
            AddSynonym = 0x3042,
            AddView = 0x3043,
            AddProcedure = 0x3044,
            AddFunction = 0x3045,
            AddTableFunction = 0x3046,
            AddInlineFunction = 0x3047,
            AddPkgSpec = 0x3048,
            AddPkgBody = 0x3049,
            AddTrigger = 0x304A,
            ExportData = 0x304B,
            DbnsVcsAdd = 0x304C,
            DbnsVcsRemove = 0x304D,
            DbnsVcsCheckout = 0x304E,
            DbnsVcsUndoCheckout = 0x304F,
            DbnsVcsCheckin = 0x3050,
            SERetrieveData = 0x3060,
            SEEditTextObject = 0x3061,
            DesignSQLBlock = 0x3064,
            RegisterSQLInstance = 0x3065,
            UnregisterSQLInstance = 0x3066,
            CommandWindowSaveScript = 0x3106,
            CommandWindowRunScript = 0x3107,
            CommandWindowCursorUp = 0x3108,
            CommandWindowCursorDown = 0x3109,
            CommandWindowCursorLeft = 0x310A,
            CommandWindowCursorRight = 0x310B,
            CommandWindowHistoryUp = 0x310C,
            CommandWindowHistoryDown = 0x310D,
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid VsStd2010 = new Guid("{5DD0BB59-7076-4C59-88D3-DE36931F63F0}");

        //TODO:  These need to be documented by UEX.
        /// <summary>
        /// Set of the standard, shared commands in CMDSETID.StandardCommandSet2010_guid
        /// </summary>
        [Guid("5DD0BB59-7076-4C59-88D3-DE36931F63F0")]
        public enum VSStd2010CmdID
        {
            DynamicToolBarListFirst = 0x1,
            DynamicToolBarListLast = 0x12C,

            WindowFrameDockMenu = 0x1F4,

            ShellNavigate1First = 0x3E8,
            ShellNavigate2First = 0x409,
            ShellNavigate3First = 0x42A,
            ShellNavigate4First = 0x44B,
            ShellNavigate5First = 0x46C,
            ShellNavigate6First = 0x48D,
            ShellNavigate7First = 0x4AE,
            ShellNavigate8First = 0x4CF,
            ShellNavigate9First = 0x4F0,
            ShellNavigate10First = 0x511,
            ShellNavigate11First = 0x532,
            ShellNavigate12First = 0x553,
            ShellNavigate13First = 0x574,
            ShellNavigate14First = 0x595,
            ShellNavigate15First = 0x5B6,
            ShellNavigate16First = 0x5D7,
            ShellNavigate17First = 0x5F8,
            ShellNavigate18First = 0x619,
            ShellNavigate19First = 0x63A,
            ShellNavigate20First = 0x65B,
            ShellNavigate21First = 0x67C,
            ShellNavigate22First = 0x69D,
            ShellNavigate23First = 0x6BE,
            ShellNavigate24First = 0x6DF,
            ShellNavigate25First = 0x700,
            ShellNavigate26First = 0x721,
            ShellNavigate27First = 0x742,
            ShellNavigate28First = 0x763,
            ShellNavigate29First = 0x784,
            ShellNavigate30First = 0x7A5,
            ShellNavigate31First = 0x7C6,
            ShellNavigate32First = 0x7E7,
            ShellNavigateLast = 0x807,

            ZoomIn = 0x834,
            ZoomOut = 0x835,

            OUTLN_EXPAND_ALL = 0x9C4,
            OUTLN_COLLAPSE_ALL = 0x9C5,
            OUTLN_EXPAND_CURRENT = 0x9C6,
            OUTLN_COLLAPSE_CURRENT = 0x9C7,

            ExtensionManager = 0xBB8
        }

        // Editor factory constants

        /// <devdoc>Mutually exclusive w/_OPENFILE</devdoc>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const uint CEF_CLONEFILE = 0x00000001;
        /// <devdoc>Mutually exclusive w/_CLONEFILE</devdoc>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const uint CEF_OPENFILE = 0x00000002;
        /// <devdoc>Editor factory should create editor silently.</devdoc>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const uint CEF_SILENT = 0x00000004;
        /// <devdoc>Editor factory should perform necessary fixups.</devdoc>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const uint CEF_OPENASNEW = 0x00000008;

        [Flags]
        public enum CEF : uint
        {
            /// <devdoc>Mutually exclusive w/_OPENFILE</devdoc>
            CloneFile = 0x00000001,
            /// <devdoc>Mutually exclusive w/_CLONEFILE</devdoc>
            OpenFile = 0x00000002,
            /// <devdoc>Editor factory should create editor silently.</devdoc>
            Silent = 0x00000004,
            /// <devdoc>Editor factory should perform necessary fixups.</devdoc>
            OpenAsNew = 0x00000008
        }


        /// <summary>Command Group GUID for commands that only apply to the UIHierarchyWindow.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_VsUIHierarchyWindowCmds = new Guid("{60481700-078B-11D1-AAF8-00A0C9055A90}");

        /// <summary>
        /// The following commands are special commands that only apply to the UIHierarchyWindow.
        /// They are defined as part of the command group GUID: CMDSETID.UIHierarchyWindowCommandSet_guid.
        /// </summary>
        [Guid("60481700-078b-11d1-aaf8-00a0c9055a90")]
        public enum VsUIHierarchyWindowCmdIds
        {
            /// <summary></summary>
            UIHWCMDID_RightClick = 1,
            /// <summary></summary>
            UIHWCMDID_DoubleClick = 2,
            /// <summary></summary>
            UIHWCMDID_EnterKey = 3,
            /// <summary></summary>
            UIHWCMDID_StartLabelEdit = 4,
            /// <summary></summary>
            UIHWCMDID_CommitLabelEdit = 5,
            /// <summary></summary>
            UIHWCMDID_CancelLabelEdit = 6
        }

        // Special values for IVsHierarchy and SelectionContainer pointers
        public static readonly IntPtr
            HIERARCHY_DONTCHANGE = new IntPtr(-1),
            SELCONTAINER_DONTCHANGE = new IntPtr(-1),
            HIERARCHY_DONTPROPAGATE = new IntPtr(-2),
            SELCONTAINER_DONTPROPAGATE = new IntPtr(-2);

        /// <summary>
        /// These element IDs are the only element IDs that can be used with the selection service.
        /// </summary>
        public enum VSSELELEMID
        {
            /// <summary></summary>
            SEID_UndoManager = 0,
            /// <summary></summary>
            SEID_WindowFrame = 1,
            /// <summary></summary>
            SEID_DocumentFrame = 2,
            /// <summary></summary>
            SEID_StartupProject = 3,
            /// <summary></summary>
            SEID_PropertyBrowserSID = 4,
            /// <summary></summary>
            SEID_UserContext = 5,
            /// <summary></summary>
            SEID_ResultList = 6,
            /// <summary></summary>
            SEID_LastWindowFrame = 7
        }

        // VS Guids

        /// <summary>
        /// 
        /// </summary>
        public static class VsPackageGuid
        {
            /// <summary>GUID of the HTML Editor package.</summary>
            public const string VsEnvironmentPackage_string = "{DA9FB551-C724-11D0-AE1F-00A0C90FFFC3}";
            /// <summary>GUID of the HTML Editor package.</summary>
            public static readonly Guid VsEnvironmentPackage_guid = new Guid(VsEnvironmentPackage_string);

            /// <summary>GUID of the HTML Editor package.</summary>
            public const string HtmlEditorPackage_string = "{1B437D20-F8FE-11D2-A6AE-00104BCC7269}";
            /// <summary>GUID of the HTML Editor package.</summary>
            public static readonly Guid HtmlEditorPackage_guid = new Guid(HtmlEditorPackage_string);

            /// <summary>GUID of the Task & Error List package.</summary>
            public const string VsTaskListPackage_string = "{4A9B7E50-AA16-11D0-A8C5-00A0C921A4D2}";
            /// <summary>GUID of the Task & Error List package.</summary>
            public static readonly Guid VsTaskListPackage_guid = new Guid(VsTaskListPackage_string);

            /// <summary>GUID of the Document Outline tool window package.</summary>
            public const string VsDocOutlinePackage_string = "{21AF45B0-FFA5-11D0-B63F-00A0C922E851}";
            /// <summary>GUID of the Document Outline tool window package.</summary>
            public static readonly Guid VsDocOutlinePackage_guid = new Guid(VsDocOutlinePackage_string);

        }

        /// <summary>
        /// 
        /// </summary>
        public static class VsEditorFactoryGuid
        {
            /// <summary>GUID of HTML Editor editor factory</summary>
            public const string HtmlEditor_string = "{C76D83F8-A489-11D0-8195-00A0C91BBEE3}";
            /// <summary>GUID of HTML Editor editor factory</summary>
            public static readonly Guid HtmlEditor_guid = new Guid(HtmlEditor_string);

            /// <summary>GUID of the Source Code (Text) Editor editor factory</summary>
            public const string TextEditor_string = "{8B382828-6202-11d1-8870-0000F87579D2}";
            /// <summary>GUID of the Source Code (Text) Editor editor factory</summary>
            public static readonly Guid TextEditor_guid = new Guid(TextEditor_string);

            /// <summary>Guid for editor factory to launch external (EXE based) editors</summary>
            public const string ExternalEditor_string = "{8B382828-6202-11D1-8870-0000F87579D2}";
            /// <summary>Guid for EditorFactory to launch external (EXE based) editors</summary>
            public static readonly Guid ExternalEditor_guid = new Guid(ExternalEditor_string);

            /// <summary>Guid for Project Properties Designer editor factory</summary>
            public const string ProjectDesignerEditor_string = "{04B8AB82-A572-4FEF-95CE-5222444B6B64}";
            /// <summary>Guid for Project Properties Designer editor factory</summary>
            public static readonly Guid ProjectDesignerEditor_guid = new Guid(ProjectDesignerEditor_string);

        }

        /// <summary>
        /// 
        /// </summary>
        public static class VsLanguageServiceGuid
        {
            /// <summary></summary>
            public const string HtmlLanguageService_string = "{58E975A0-F8FE-11D2-A6AE-00104BCC7269}";
            /// <summary></summary>
            public static readonly Guid HtmlLanguageService_guid = new Guid(HtmlLanguageService_string);

        }

        /// <summary>
        /// 
        /// </summary>
        public static class OutputWindowPaneGuid
        {
            /// <summary>GUID of the build output pane inside the output window.</summary>
            public const string BuildOutputPane_string = "{1BD8A850-02D1-11D1-BEE7-00A0C913D1F8}";
            /// <summary>GUID of the build output pane inside the output window.</summary>
            public static readonly Guid BuildOutputPane_guid = new Guid(BuildOutputPane_string);

            /// <summary>GUID of the sorted build output pane inside the output window.</summary>
            public const string SortedBuildOutputPane_string = "{2032B126-7C8D-48AD-8026-0E0348004FC0}";
            /// <summary>GUID of the sorted build output pane inside the output window.</summary>
            public static readonly Guid SortedBuildOutputPane_guid = new Guid(SortedBuildOutputPane_string);

            /// <summary>GUID of the debug pane inside the output window.</summary>
            public const string DebugPane_string = "{FC076020-078A-11D1-A7DF-00A0C9110051}";
            /// <summary>GUID of the debug pane inside the output window.</summary>
            public static readonly Guid DebugPane_guid = new Guid(DebugPane_string);

            /// <summary>GUID of the general output pane inside the output window.</summary>
            public const string GeneralPane_string = "{3C24D581-5591-4884-A571-9FE89915CD64}";
            /// <summary>GUID of the general output pane inside the output window.</summary>
            public static readonly Guid GeneralPane_guid = new Guid(GeneralPane_string);

        }

        /// <summary>
        /// These values are used with the VSHPROPID_ItemType property.
        /// </summary>
        public static class ItemTypeGuid
        {
            /// <summary>Physical file on disk or web (IVsProject::GetMkDocument returns a file path).</summary>
            public const string PhysicalFile_string = "{6BB5F8EE-4483-11D3-8BCF-00C04F8EC28C}";
            /// <summary>Physical file on disk or web (IVsProject::GetMkDocument returns a file path).</summary>
            public static readonly Guid PhysicalFile_guid = new Guid(PhysicalFile_string);

            /// <summary>Physical folder on disk or web (IVsProject::GetMkDocument returns a directory path).</summary>
            public const string PhysicalFolder_string = "{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}";
            /// <summary>Physical folder on disk or web (IVsProject::GetMkDocument returns a directory path).</summary>
            public static readonly Guid PhysicalFolder_guid = new Guid(PhysicalFolder_string);

            /// <summary>Non-physical folder (folder is logical and not a physical file system directory).</summary>
            public const string VirtualFolder_string = "{6BB5F8EE-4483-11D3-8BCF-00C04F8EC28C}";
            /// <summary>Non-physical folder (folder is logical and not a physical file system directory).</summary>
            public static readonly Guid VirtualFolder_guid = new Guid(VirtualFolder_string);

            /// <summary>Nested or Sub Project.</summary>
            public const string SubProject_string = "{EA6618E8-6E24-4528-94BE-6889FE16485C}";
            /// <summary>Nested or Sub Project.</summary>
            public static readonly Guid SubProject_guid = new Guid(SubProject_string);

        }

        /// <summary>
        /// 
        /// </summary>
        public static class VsDependencyTypeGuid
        {
            /// <summary>Build project dependency (used with IVsDependency::get_Type)</summary>
            public const string BuildProject_string = "{707D11B6-91CA-11D0-8A3E-00A0C91E2ACD}";
            /// <summary>Build project dependency (used with IVsDependency::get_Type)</summary>
            public static readonly Guid BuildProject_guid = new Guid(BuildProject_string);

        }

        /// <summary>
        /// These are optional IVsUserData properties that a Language Service may provide in order to influence
        /// the behavior of the Source Code (Text) Editor. The IVsUserData interface is retrieved by 
        /// QueryInterface on the IVsLanguageInfo object of the Language Service implementation.
        /// </summary>
        public static class VsLanguageUserDataGuid
        {
            /// <summary></summary>
            public const string SupportCF_HTML_string = "{27E97702-589E-11D2-8233-0080C747D9A0}";
            /// <summary></summary>
            public static readonly Guid SupportCF_HTML_guid = new Guid(SupportCF_HTML_string);

        }

        /// <summary>
        /// These are IVsUserData properties that are supported by the TextBuffer (DocData) object
        /// of the Source Code (Text) Editor. The IVsUserData interface is retrieved by 
        /// QueryInterface on the IVsTextLines object of the Text Editor.
        /// </summary>
        public static class VsTextBufferUserDataGuid
        {
            /// <summary>string: Moniker of document loaded in the buffer. It will be the full path of file if the document is a file.</summary>
            public const string VsBufferMoniker_string = "{978A8E17-4DF8-432A-9623-D530A26452BC}";
            /// <summary>string: Moniker of document loaded in the TextBuffer. It will be the full path of file if the document is a file.</summary>
            public static readonly Guid VsBufferMoniker_guid = new Guid(VsBufferMoniker_string);

            /// <summary>bool: true if buffer is a file on disk</summary>
            public const string VsBufferIsDiskFile_string = "{D9126592-1473-11D3-BEC6-0080C747D9A0}";
            /// <summary>bool: true if buffer is a file on disk</summary>
            public static readonly Guid VsBufferIsDiskFile_guid = new Guid(VsBufferIsDiskFile_string);

            /// <summary>uint: VS Text File Format (VSTFF) for buffer. codepage = bufferVSTFF & __VSTFF.VSTFF_CPMASK; vstffFlags = bufferVSTFF & __VSTFF.VSTFF_FLAGSMASK;</summary>
            public const string VsBufferEncodingVSTFF_string = "{16417F39-A6B7-4C90-89FA-770D2C60440B}";
            /// <summary>uint: VS Text File Format (VSTFF) for buffer. codepage = bufferVSTFF & __VSTFF.VSTFF_CPMASK; vstffFlags = bufferVSTFF & __VSTFF.VSTFF_FLAGSMASK;</summary>
            public static readonly Guid VsBufferEncodingVSTFF_guid = new Guid(VsBufferEncodingVSTFF_string);

            /// <summary>uint: This should only be used by editor factories that want to specify a codepage on loading from the openwith dialog. 
            /// This data is only for a set purpose.  You cannot get the value of this back.
            /// </summary>
            public const string VsBufferEncodingPromptOnLoad_string = "{99EC03F0-C843-4C09-BE74-CDCA5158D36C}";
            /// <summary>uint: This should only be used by editor factories that want to specify a codepage on loading from the openwith dialog. 
            /// This data is only for a set purpose.  You cannot get the value of this back.
            /// </summary>
            public static readonly Guid VsBufferEncodingPromptOnLoad_guid = new Guid(VsBufferEncodingPromptOnLoad_string);

            /// <summary>bool: If true and the current BufferEncoding is CHARFMT_MBCS, the buffer will runs it's HTML charset tag detection code to determine a codepage to load and save the file. The detected codepage overrides any codepage set in CHARFMT_MBCS.
            /// This is forced on in the buffer's IPersistFileFormat::LoadDocData when it sees an HTML type of file, according to the extension mapping in "$RootKey$\Languages\File Extensions".
            /// </summary>
            public const string VsBufferDetectCharSet_string = "{36358D1F-BF7E-11D1-B03A-00C04FB68006}";
            /// <summary>bool: If true and the current BufferEncoding is CHARFMT_MBCS, the buffer will runs it's HTML charset tag detection code to determine a codepage to load and save the file. The detected codepage overrides any codepage set in CHARFMT_MBCS.
            /// This is forced on in the buffer's IPersistFileFormat::LoadDocData when it sees an HTML type of file, according to the extension mapping in "$RootKey$\Languages\File Extensions".
            /// </summary>
            public static readonly Guid VsBufferDetectCharSet_guid = new Guid(VsBufferDetectCharSet_string);

            /// <summary>bool: (default = true) If true then a change to the buffer's moniker will cause the buffer to change the language service 
            /// based on the file extension of the moniker.
            /// </summary>
            public const string VsBufferDetectLangSID_string = "{17F375AC-C814-11D1-88AD-0000F87579D2}";
            /// <summary>bool: (default = true) If true then a change to the buffer's moniker will cause the buffer to change the language service 
            /// based on the file extension of the moniker.
            /// </summary>
            public static readonly Guid VsBufferDetectLangSID_guid = new Guid(VsBufferDetectLangSID_string);

            /// <summary>string: This property will be used to set the SEID_PropertyBrowserSID element of the selection for text views.  
            /// This is only used if you have a custom property browser. If this property is not set, the standard property browser 
            /// will be associated with the view.
            /// </summary>
            public const string PropertyBrowserSID_string = "{CE6DDBBA-8D13-11D1-8889-0000F87579D2}";
            /// <summary>string: This property will be used to set the SEID_PropertyBrowserSID element of the selection for text views.  
            /// This is only used if you have a custom property browser. If this property is not set, the standard property browser 
            /// will be associated with the view.
            /// </summary>
            public static readonly Guid PropertyBrowserSID_guid = new Guid(PropertyBrowserSID_string);

            /// <summary>string: This property provides a specific error message for when the buffer originates the BUFFER_E_READONLY error.
            /// Set this string to be the (localized) text you want displayed to the user.  Note that the buffer itself does not 
            /// put up UI, but only calls IVsUIShell::SetErrorInfo. The caller can decide whether to show the message to the user.
            /// </summary>
            public const string UserReadOnlyErrorString_string = "{A3BCFE56-CF1B-11D1-88B1-0000F87579D2}";
            /// <summary>string: This property provides a specific error message for when the buffer originates the BUFFER_E_READONLY error.
            /// Set this string to be the (localized) text you want displayed to the user.  Note that the buffer itself does not 
            /// put up UI, but only calls IVsUIShell::SetErrorInfo. The caller can decide whether to show the message to the user.
            /// </summary>
            public static readonly Guid UserReadOnlyErrorString_guid = new Guid(UserReadOnlyErrorString_string);

            /// <summary>object: This property is used to get access to the buffer's storage object.
            /// The returned pointer can be QI'd for IVsTextStorage and IVsPersistentTextImage.  
            /// This is a get-only property. To set the storage, use the buffer's InitializeContentEx method.
            /// </summary>
            public const string BufferStorage_string = "{D97F167A-638E-11D2-88F6-0000F87579D2}";
            /// <summary>object: This property is used to get access to the buffer's storage object.
            /// The returned pointer can be QI'd for IVsTextStorage and IVsPersistentTextImage.  
            /// This is a get-only property. To set the storage, use the buffer's InitializeContentEx method.
            /// </summary>
            public static readonly Guid BufferStorage_guid = new Guid(BufferStorage_string);

            /// <summary>object: Use this property if the file opened in the buffer is associated with list of extra files under source code control (SCC).
            /// Set this property with an implementation of IVsBufferExtraFiles in order to control how the buffer handles SCC operations.
            /// The IVsBufferExtraFiles object set will determine what files are checked out from Source Code Control (SCC) when edits are made to the buffer.
            /// This property controls the behavior of IVsTextManager2::AttemptToCheckOutBufferFromScc3 and GetBufferSccStatus3 as well as which
            /// files are passed by the buffer when it calls IVsQueryEditQuerySave2 methods.
            /// </summary>
            public const string VsBufferExtraFiles_string = "{FD494BF6-1167-4635-A20C-5C24B2D7B33D}";
            /// <summary>object: Use this property if the file opened in the buffer is associated with list of extra files under source code control (SCC).
            /// Set this property with an implementation of IVsBufferExtraFiles in order to control how the buffer handles SCC operations.
            /// The IVsBufferExtraFiles object set will determine what files are checked out from Source Code Control (SCC) when edits are made to the buffer.
            /// This property controls the behavior of IVsTextManager2::AttemptToCheckOutBufferFromScc3 and GetBufferSccStatus3 as well as which
            /// files are passed by the buffer when it calls IVsQueryEditQuerySave2 methods.
            /// </summary>
            public static readonly Guid VsBufferExtraFiles_guid = new Guid(VsBufferExtraFiles_string);

            /// <summary>bool: </summary>
            public const string VsBufferFileReload_string = "{80D2B881-81A3-4F0B-BCF0-70A0054E672F}";
            /// <summary>bool: </summary>
            public static readonly Guid VsBufferFileReload_guid = new Guid(VsBufferFileReload_string);

            /// <summary>bool: </summary>
            public const string VsInitEncodingDialogFromUserData_string = "{C2382D84-6650-4386-860F-248ECB222FC1}";
            /// <summary>bool: </summary>
            public static readonly Guid VsInitEncodingDialogFromUserData_guid = new Guid(VsInitEncodingDialogFromUserData_string);

            /// <summary>string: The ContentType for the text buffer.</summary>
            public const string VsBufferContentType_string = "{1BEB4195-98F4-4589-80E0-480CE32FF059}";
            /// <summary>string: The ContentType for the text buffer.</summary>
            public static readonly Guid VsBufferContentType_guid = new Guid(VsBufferContentType_string);

            /// <summary>string: The comma-separated list of text view roles for the text view.</summary>
            public const string VsTextViewRoles_string = "{297078FF-81A2-43D8-9CA3-4489C53C99BA}";
            /// <summary>string: The comma-separated list of text view roles for the text view.</summary>
            public static readonly Guid VsTextViewRoles_guid = new Guid(VsTextViewRoles_string);
        }

        /// <summary>
        /// Known editor property categories use with IVsTextEditorPropertyCategoryContainer interface.
        /// </summary>
        public static class EditPropyCategoryGuid
        {
            /// <summary>GUID for text manager global properties</summary>
            public const string TextManagerGlobal_string = "{6BFB60A2-48D8-424E-81A2-040ACA0B1F68}";
            /// <summary>GUID for text manager global properties</summary>
            public static readonly Guid TextManagerGlobal_guid = new Guid(TextManagerGlobal_string);

            /// <summary>GUID for view properties that override everything -- Tools.Options *and* user commands</summary>
            public const string ViewMasterSettings_string = "{D1756E7C-B7FD-49A8-B48E-87B14A55655A}";
            /// <summary>GUID for view properties that override everything -- Tools.Options *and* user commands</summary>
            public static readonly Guid ViewMasterSettings_guid = new Guid(ViewMasterSettings_string);
        }

        /// <summary>
        /// These CATID Guids are used to extend objects passed to the property browser and automation objects that support
        /// Automation Extenders. 
        /// </summary>
        public static class CATID
        {
            /// <summary></summary>
            public const string CSharpFileProperties_string = "{8D58E6AF-ED4E-48B0-8C7B-C74EF0735451}";
            public static readonly Guid CSharpFileProperties_guid = new Guid(CSharpFileProperties_string);

            /// <summary></summary>
            public const string CSharpFolderProperties_string = "{914FE278-054A-45DB-BF9E-5F22484CC84C}";
            public static readonly Guid CSharpFolderProperties_guid = new Guid(CSharpFolderProperties_string);

            /// <summary>This CATID is used to extend EnvDTE.Project automation objects for project types that support it (including VB and C# projects).</summary>
            public const string ProjectAutomationObject_string = "{610D4614-D0D5-11D2-8599-006097C68E81}";
            /// <summary>This CATID is used to extend EnvDTE.Project automation objects for project types that support it (including VB and C# projects).</summary>
            public static readonly Guid ProjectAutomationObject_guid = new Guid(ProjectAutomationObject_string);

            /// <summary>This CATID is used to extend EnvDTE.ProjectItem automation objects for project types that support it (including VB and C# projects).</summary>
            public const string ProjectItemAutomationObject_string = "{610D4615-D0D5-11D2-8599-006097C68E81}";
            /// <summary>This CATID is used to extend EnvDTE.ProjectItem automation objects for project types that support it (including VB and C# projects).</summary>
            public static readonly Guid ProjectItemAutomationObject_guid = new Guid(ProjectItemAutomationObject_string);

            /// <summary></summary>
            public const string VBAFileProperties_string = "{AC2912B2-50ED-4E62-8DFF-429B4B88FC9E}";
            public static readonly Guid VBAFileProperties_guid = new Guid(VBAFileProperties_string);

            /// <summary></summary>
            public const string VBAFolderProperties_string = "{79231B36-6213-481D-AA7D-0F931E8F2CF9}";
            public static readonly Guid VBAFolderProperties_guid = new Guid(VBAFolderProperties_string);

            /// <summary></summary>
            public const string VBFileProperties_string = "{EA5BD05D-3C72-40A5-95A0-28A2773311CA}";
            public static readonly Guid VBFileProperties_guid = new Guid(VBFileProperties_string);

            /// <summary></summary>
            public const string VBFolderProperties_string = "{932DC619-2EAA-4192-B7E6-3D15AD31DF49}";
            public static readonly Guid VBFolderProperties_guid = new Guid(VBFolderProperties_string);

            /// <summary></summary>
            public const string VBProjectProperties_string = "{E0FDC879-C32A-4751-A3D3-0B3824BD575F}";
            public static readonly Guid VBProjectProperties_guid = new Guid(VBProjectProperties_string);

            /// <summary></summary>
            public const string VBReferenceProperties_string = "{2289B812-8191-4E81-B7B3-174045AB0CB5}";
            public static readonly Guid VBReferenceProperties_guid = new Guid(VBReferenceProperties_string);

            /// <summary></summary>
            public const string VCProjectNode_string = "{EE8299CB-19B6-4F20-ABEA-E1FD9A33B683}";
            public static readonly Guid VCProjectNode_guid = new Guid(VCProjectNode_string);

            /// <summary></summary>
            public const string VCFileGroup_string = "{EE8299CA-19B6-4F20-ABEA-E1FD9A33B683}";
            public static readonly Guid VCFileGroup_guid = new Guid(VCFileGroup_string);

            /// <summary></summary>
            public const string VCFileNode_string = "{EE8299C9-19B6-4F20-ABEA-E1FD9A33B683}";
            public static readonly Guid VCFileNode_guid = new Guid(VCFileNode_string);

            /// <summary></summary>
            public const string VCAssemblyReferenceNode_string = "{FE8299C9-19B6-4F20-ABEA-E1FD9A33B683}";
            public static readonly Guid VCAssemblyReferenceNode_guid = new Guid(VCAssemblyReferenceNode_string);

            /// <summary></summary>
            public const string VCProjectReferenceNode_string = "{593DCFCE-20A7-48E4-ACA1-49ADE9049887}";
            public static readonly Guid VCProjectReferenceNode_guid = new Guid(VCProjectReferenceNode_string);

            /// <summary></summary>
            public const string VCActiveXReferenceNode_string = "{9E8182D3-C60A-44F4-A74B-14C90EF9CACE}";
            public static readonly Guid VCActiveXReferenceNode_guid = new Guid(VCActiveXReferenceNode_string);

            /// <summary></summary>
            public const string VCReferences_string = "{FE8299CA-19B6-4F20-ABEA-E1FD9A33B683}";
            public static readonly Guid VCReferences_guid = new Guid(VCReferences_string);

        }

        // Note: We don't define here the GUIDs for the standard tool windows because these
        // GUIDs are defined in Design.StandardToolWindows

        /// <summary>The document's data is HTML.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid CLSID_HtmDocData = new Guid("{62C81794-A9EC-11D0-8198-00A0C91BBEE3}");
        /// <summary>GUID of the HTML package.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid CLSID_HtmedPackage = new Guid("{1B437D20-F8FE-11D2-A6AE-00104BCC7269}");
        /// <summary>GUID of the HTML language service.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid CLSID_HtmlLanguageService = new Guid("{58E975A0-F8FE-11D2-A6AE-00104BCC7269}");
        /// <summary>GUID of the HTML editor factory.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_HtmlEditorFactory = new Guid("{C76D83F8-A489-11D0-8195-00A0C91BBEE3}");
        /// <summary>GUID of the Text editor factory.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_TextEditorFactory = new Guid("{8B382828-6202-11D1-8870-0000F87579D2}");
        /// <summary>GUID used to mark a TextBuffer in order to tell to the HTML editor factory to accept preexisting doc data.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_HTMEDAllowExistingDocData = new Guid("{5742D216-8071-4779-BF5F-A24D5F3142BA}");
        /// <summary>GUID for the environment package.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid CLSID_VsEnvironmentPackage = new Guid("{DA9FB551-C724-11D0-AE1F-00A0C90FFFC3}");
        /// <summary>GUID for the "Visual Studio" pseudo folder in the registry.</summary>
        public static readonly Guid GUID_VsNewProjectPseudoFolder = new Guid("{DCF2A94A-45B0-11D1-ADBF-00C04FB6BE4C}");
        /// <summary>GUID for the "Miscellaneous Files" project.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid CLSID_MiscellaneousFilesProject = new Guid("{A2FE74E1-B743-11D0-AE1A-00A0C90FFFC3}");
        /// <summary>GUID for Solution Items project.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid CLSID_SolutionItemsProject = new Guid("{D1DCDB85-C5E8-11D2-BFCA-00C04F990235}");
        /// <summary>Pseudo service that returns a IID_IVsOutputWindowPane interface of the General output pane in the VS environment.
        /// Querying for this service will cause the General output pane to be created if it hasn't yet been created.
        /// </summary>
        public static readonly Guid SID_SVsGeneralOutputWindowPane = new Guid("{65482C72-DEFA-41B7-902C-11C091889C83}");
        /// <summary>
        /// SUIHostCommandDispatcher service returns an object that implements IOleCommandTarget.
        /// This object handles command routing for the Environment. Use this service if you need to
        /// route a command based on the current selection/state of the Environment.
        /// </summary>
        public static readonly Guid SID_SUIHostCommandDispatcher = new Guid("{E69CD190-1276-11D1-9F64-00A0C911004F}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid CLSID_VsUIHierarchyWindow = new Guid("{7D960B07-7AF8-11D0-8E5E-00A0C911005A}");

        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_DefaultEditor = new Guid("{6AC5EF80-12BF-11D1-8E9B-00A0C911005A}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_ExternalEditor = new Guid("{8137C9E8-35FE-4AF2-87B0-DE3C45F395FD}");


        /// <summary>
        /// 
        /// </summary>
        public static class CLSID
        {
            /// <summary></summary>
            public const string MiscellaneousFilesProject_string = "{A2FE74E1-B743-11D0-AE1A-00A0C90FFFC3}";
            /// <summary></summary>
            public static readonly Guid MiscellaneousFilesProject_guid = new Guid(MiscellaneousFilesProject_string);

            /// <summary></summary>
            public const string SolutionFolderProject_string = "{2150E333-8FDC-42A3-9474-1A3956D46DE8}";
            /// <summary></summary>
            public static readonly Guid SolutionFolderProject_guid = new Guid(SolutionFolderProject_string);

            /// <summary></summary>
            public const string SolutionItemsProject_string = "{D1DCDB85-C5E8-11D2-BFCA-00C04F990235}";
            /// <summary></summary>
            public static readonly Guid SolutionItemsProject_guid = new Guid(SolutionItemsProject_string);

            /// <summary></summary>
            public const string VsTextBuffer_string = "{8E7B96A8-E33D-11D0-A6D5-A6D500C04FB67F6A}";
            /// <summary></summary>
            public static readonly Guid VsTextBuffer_guid = new Guid(VsTextBuffer_string);

            /// <summary></summary>
            public const string UnloadedProject_string = "{76E22BD3-C2EC-47F1-802B-53197756DAE8}";
            /// <summary></summary>
            public static readonly Guid UnloadedProject_guid = new Guid(UnloadedProject_string);

            /// <summary></summary>
            public const string VsCfgProviderEventsHelper_string = "{99913F1F-1EE3-11D1-8A6E-00C04F682E21}";
            /// <summary></summary>
            public static readonly Guid VsCfgProviderEventsHelper_guid = new Guid(VsCfgProviderEventsHelper_string);

            /// <summary></summary>
            public const string VsEnvironmentPackage_string = "{DA9FB551-C724-11D0-AE1F-00A0C90FFFC3}";
            /// <summary></summary>
            public static readonly Guid VsEnvironmentPackage_guid = new Guid(VsEnvironmentPackage_string);

            /// <summary></summary>
            public const string VsTaskListPackage_string = "{4A9B7E50-AA16-11D0-A8C5-00A0C921A4D2}";
            /// <summary></summary>
            public static readonly Guid VsTaskListPackage_guid = new Guid(VsTaskListPackage_string);

            /// <summary></summary>
            public const string VsUIWpfLoader_string = "{0B127700-143C-4AB5-9D39-BFF47151B563}";
            /// <summary></summary>
            public static readonly Guid VsUIWpfLoader_guid = new Guid(VsUIWpfLoader_string);

            /// <summary>DocData object of the HTML Editor</summary>
            public const string HtmDocData_string = "{62C81794-A9EC-11D0-8198-00A0C91BBEE3}";
            /// <summary></summary>
            public static readonly Guid HtmDocData_guid = new Guid(HtmDocData_string);

            /// <summary>CLSID of the UIHierarchy window tree control object</summary>
            public const string VsUIHierarchyWindow_string = "{7D960B07-7AF8-11D0-8E5E-00A0C911005A}";
            /// <summary></summary>
            public static readonly Guid VsUIHierarchyWindow_guid = new Guid(VsUIHierarchyWindow_string);

            /// <summary></summary>
            public const string VsTaskList_string = "{BC5955D5-AA0D-11D0-A8C5-00A0C921A4D2}";
            /// <summary></summary>
            public static readonly Guid VsTaskList_guid = new Guid(VsTaskList_string);

        }
        
        
        
        //--------------------------------------------------------------------
        // GUIDs for some panes of the Output Window
        //--------------------------------------------------------------------
        /// <summary>GUID of the build pane inside the output window.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_BuildOutputWindowPane = new Guid("{1BD8A850-02D1-11d1-BEE7-00A0C913D1F8}");
        /// <summary>GUID of the debug pane inside the output window.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_OutWindowDebugPane = new Guid("{FC076020-078A-11D1-A7DF-00A0C9110051}");
        /// <summary>GUID of the general output pane inside the output window.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_OutWindowGeneralPane = new Guid("{3C24D581-5591-4884-A571-9FE89915CD64}");

        // Guids for GetOutputPane.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid BuildOrder = new Guid("2032B126-7C8D-48AD-8026-0E0348004FC0");
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid BuildOutput = new Guid("1BD8A850-02D1-11D1-BEE7-00A0C913D1F8");
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid DebugOutput = new Guid("FC076020-078A-11D1-A7DF-00A0C9110051");

        //--------------------------------------------------------------------
        // standard item types, to be returned from VSHPROPID_TypeGuid
        //--------------------------------------------------------------------

        /// <summary>Physical file on disk or web (IVsProject::GetMkDocument returns a file path).</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_ItemType_PhysicalFile = new Guid("{6BB5F8EE-4483-11D3-8BCF-00C04F8EC28C}");

        /// <summary>Physical folder on disk or web (IVsProject::GetMkDocument returns a directory path).</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_ItemType_PhysicalFolder = new Guid("{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}");

        /// <summary>Non-physical folder (folder is logical and not a physical file system directory).</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_ItemType_VirtualFolder = new Guid("{6BB5F8F0-4483-11D3-8BCF-00C04F8EC28C}");

        /// <summary>A nested hierarchy project.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_ItemType_SubProject = new Guid("{EA6618E8-6E24-4528-94BE-6889FE16485C}");

        /// <summary>The BrowseFile page.</summary>
        public static readonly Guid GUID_BrowseFilePage = new Guid("2483F435-673D-4FA3-8ADD-B51442F65349");

        public static readonly Guid guidCOMPLUSLibrary = new Guid(0x1ec72fd7, 0xc820, 0x4273, 0x9a, 0x21, 0x77, 0x7a, 0x5c, 0x52, 0x2e, 0x03);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid CLSID_ComPlusOnlyDebugEngine = new Guid("449EC4CC-30D2-4032-9256-EE18EB41B62B");

        /// <summary>
        /// 
        /// </summary>
        public static class DebugEnginesGuids
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly Guid ManagedOnly = new Guid("449EC4CC-30D2-4032-9256-EE18EB41B62B");
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly Guid NativeOnly = new Guid("{3B476D35-A401-11D2-AAD4-00C04F990171}");
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly Guid Script = new Guid("{F200A7E7-DEA5-11D0-B854-00A0244A1DE2}");
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly Guid ManagedAndNative = new Guid("{92EF0900-2251-11D2-B72E-0000F87572EF}");
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly Guid SQLLocalEngine = new Guid("{E04BDE58-45EC-48DB-9807-513F78865212}");
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly Guid SqlDebugEngine2 = new Guid("{3B476D30-A401-11D2-AAD4-00C04F990171}");
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly Guid SqlDebugEngine3 = new Guid("{3B476D3A-A401-11D2-AAD4-00C04F990171}");

            public const string ManagedOnly_string = "449EC4CC-30D2-4032-9256-EE18EB41B62B";
            public static readonly Guid ManagedOnly_guid = new Guid(ManagedOnly_string);

            public const string NativeOnly_string = "{3B476D35-A401-11D2-AAD4-00C04F990171}";
            public static readonly Guid NativeOnly_guid = new Guid(NativeOnly_string);

            public const string Script_string = "{F200A7E7-DEA5-11D0-B854-00A0244A1DE2}";
            public static readonly Guid Script_guid = new Guid(Script_string);

            public const string ManagedAndNative_string = "{92EF0900-2251-11D2-B72E-0000F87572EF}";
            public static readonly Guid ManagedAndNative_guid = new Guid(ManagedAndNative_string);

            public const string SQLLocalEngine_string = "{E04BDE58-45EC-48DB-9807-513F78865212}";
            public static readonly Guid SQLLocalEngine_guid = new Guid(SQLLocalEngine_string);

            public const string SqlDebugEngine2_string = "{3B476D30-A401-11D2-AAD4-00C04F990171}";
            public static readonly Guid SqlDebugEngine2_guid = new Guid(SqlDebugEngine2_string);

            public const string SqlDebugEngine3_string = "{3B476D3A-A401-11D2-AAD4-00C04F990171}";
            public static readonly Guid SqlDebugEngine3_guid = new Guid(SqlDebugEngine3_string);

        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_VS_DEPTYPE_BUILD_PROJECT = new Guid("707d11b6-91ca-11d0-8a3e-00a0c91e2acd");

        /// <summary>The project designer guid.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_ProjectDesignerEditor = new Guid("04b8ab82-a572-4fef-95ce-5222444b6b64");

        // Build options from the idl file.
        public const uint VS_BUILDABLEPROJECTCFGOPTS_REBUILD = 1;
        public const uint VS_BUILDABLEPROJECTCFGOPTS_BUILD_SELECTION_ONLY = 2;
        public const uint VS_BUILDABLEPROJECTCFGOPTS_BUILD_ACTIVE_DOCUMENT_ONLY = 4;
        public const uint VS_BUILDABLEPROJECTCFGOPTS_PRIVATE = 0xFFFF0000;    // flags private to a particular implementation

        //--------------------------------------------------------------------
        // GUIDs used in calling IVsMonitorSelection::GetCmdUIContextCookie()
        //--------------------------------------------------------------------
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid UICONTEXT_SolutionBuilding = new Guid("{adfc4e60-0397-11d1-9f4e-00a0c911004f}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid UICONTEXT_Debugging = new Guid("{adfc4e61-0397-11d1-9f4e-00a0c911004f}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid UICONTEXT_Dragging = new Guid("{b706f393-2e5b-49e7-9e2e-b1825f639b63}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid UICONTEXT_FullScreenMode = new Guid("{adfc4e62-0397-11d1-9f4e-00a0c911004f}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid UICONTEXT_DesignMode = new Guid("{adfc4e63-0397-11d1-9f4e-00a0c911004f}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid UICONTEXT_NoSolution = new Guid("{adfc4e64-0397-11d1-9f4e-00a0c911004f}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid UICONTEXT_SolutionExists = new Guid("{f1536ef8-92ec-443c-9ed7-fdadf150da82}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid UICONTEXT_EmptySolution = new Guid("{adfc4e65-0397-11d1-9f4e-00a0c911004f}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid UICONTEXT_SolutionHasSingleProject = new Guid("{adfc4e66-0397-11d1-9f4e-00a0c911004f}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid UICONTEXT_SolutionHasMultipleProjects = new Guid("{93694fa0-0397-11d1-9f4e-00a0c911004f}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid UICONTEXT_CodeWindow = new Guid("{8fe2df1d-e0da-4ebe-9d5c-415d40e487b5}");

        /// <summary>
        /// 
        /// </summary>
        public static class UICONTEXT
        {
            /// <summary></summary>
            public const string RESXEditor_string = "{FEA4DCC9-3645-44CD-92E7-84B55A16465C}";
            /// <summary></summary>
            public static readonly Guid RESXEditor_guid = new Guid(RESXEditor_string);

            /// <summary></summary>
            public const string SettingsDesigner_string = "{515231AD-C9DC-4AA3-808F-E1B65E72081C}";
            /// <summary></summary>
            public static readonly Guid SettingsDesigner_guid = new Guid(SettingsDesigner_string);

            /// <summary></summary>
            public const string PropertyPageDesigner_string = "{86670EFA-3C28-4115-8776-A4D5BB1F27CC}";
            /// <summary></summary>
            public static readonly Guid PropertyPageDesigner_guid = new Guid(PropertyPageDesigner_string);

            /// <summary></summary>
            public const string ApplicationDesigner_string = "{D06CD5E3-D961-44DC-9D80-C89A1A8D9D56}";
            /// <summary></summary>
            public static readonly Guid ApplicationDesigner_guid = new Guid(ApplicationDesigner_string);
            
            /// <summary></summary>
            public const string VBProjOpened_string = "{9DA22B82-6211-11d2-9561-00600818403B}";
            /// <summary></summary>
            public static readonly Guid VBProjOpened_guid = new Guid(VBProjOpened_string);

            /// <summary></summary>
            public const string CodeWindow_string = "{8FE2DF1D-E0DA-4EBE-9D5C-415D40E487B5}";
            /// <summary></summary>
            public static readonly Guid CodeWindow_guid = new Guid(CodeWindow_string);

            /// <summary></summary>
            public const string DataSourceWindowAutoVisible_string = "{2E78870D-AC7C-4460-A4A1-3FE37D00EF81}";
            /// <summary></summary>
            public static readonly Guid DataSourceWindowAutoVisible_guid = new Guid(DataSourceWindowAutoVisible_string);

            /// <summary></summary>
            public const string DataSourceWizardSuppressed_string = "{5705AD15-40EE-4426-AD3E-BA750610D599}";
            /// <summary></summary>
            public static readonly Guid DataSourceWizardSuppressed_guid = new Guid(DataSourceWizardSuppressed_string);

            /// <summary></summary>
            public const string DataSourceWindowSupported_string = "{95C314C4-660B-4627-9F82-1BAF1C764BBF}";
            /// <summary></summary>
            public static readonly Guid DataSourceWindowSupported_guid = new Guid(DataSourceWindowSupported_string);

            /// <summary></summary>
            public const string Debugging_string = "{ADFC4E61-0397-11D1-9F4E-00A0C911004F}";
            /// <summary></summary>
            public static readonly Guid Debugging_guid = new Guid(Debugging_string);

            /// <summary></summary>
            public const string DesignMode_string = "{ADFC4E63-0397-11D1-9F4E-00A0C911004F}";
            /// <summary></summary>
            public static readonly Guid DesignMode_guid = new Guid(DesignMode_string);

            /// <summary></summary>
            public const string Dragging_string = "{B706F393-2E5B-49E7-9E2E-B1825F639B63}";
            /// <summary></summary>
            public static readonly Guid Dragging_guid = new Guid(Dragging_string);

            /// <summary></summary>
            public const string EmptySolution_string = "{ADFC4E65-0397-11D1-9F4E-00A0C911004F}";
            /// <summary></summary>
            public static readonly Guid EmptySolution_guid = new Guid(EmptySolution_string);

            /// <summary></summary>
            public const string FullScreenMode_string = "{ADFC4E62-0397-11D1-9F4E-00A0C911004F}";
            /// <summary></summary>
            public static readonly Guid FullScreenMode_guid = new Guid(FullScreenMode_string);

            /// <summary></summary>
            public const string HistoricalDebugging_string = "{D1B1E38F-1A7E-4236-AF55-6FA8F5FA76E6}";
            /// <summary></summary>
            public static readonly Guid HistoricalDebugging_guid = new Guid(HistoricalDebugging_string);

            /// <summary></summary>
            public const string NoSolution_string = "{ADFC4E64-0397-11D1-9F4E-00A0C911004F}";
            /// <summary></summary>
            public static readonly Guid NoSolution_guid = new Guid(NoSolution_string);

            /// <summary></summary>
            public const string NotBuildingAndNotDebugging_string = "{48EA4A80-F14E-4107-88FA-8D0016F30B9C}";
            /// <summary></summary>
            public static readonly Guid NotBuildingAndNotDebugging_guid = new Guid(NotBuildingAndNotDebugging_string);

            /// <summary></summary>
            public const string ProjectRetargeting_string = "{DE039A0E-C18F-490C-944A-888B8E86DA4B}";
            /// <summary></summary>
            public static readonly Guid ProjectRetargeting_guid = new Guid(ProjectRetargeting_string);

            /// <summary></summary>
            public const string SolutionBuilding_string = "{ADFC4E60-0397-11D1-9F4E-00A0C911004F}";
            /// <summary></summary>
            public static readonly Guid SolutionBuilding_guid = new Guid(SolutionBuilding_string);

            /// <summary></summary>
            public const string SolutionExists_string = "{F1536EF8-92EC-443C-9ED7-FDADF150DA82}";
            /// <summary></summary>
            public static readonly Guid SolutionExists_guid = new Guid(SolutionExists_string);

            /// <summary></summary>
            public const string SolutionExistsAndFullyLoaded_string = "{10534154-102D-46E2-ABA8-A6BFA25BA0BE}";
            /// <summary></summary>
            public static readonly Guid SolutionExistsAndFullyLoaded_guid = new Guid(SolutionExistsAndFullyLoaded_string);

            /// <summary></summary>
            public const string SolutionExistsAndNotBuildingAndNotDebugging_string = "{D0E4DEEC-1B53-4CDA-8559-D454583AD23B}";
            /// <summary></summary>
            public static readonly Guid SolutionExistsAndNotBuildingAndNotDebugging_guid = new Guid(SolutionExistsAndNotBuildingAndNotDebugging_string);

            /// <summary></summary>
            public const string SolutionHasMultipleProjects_string = "{93694FA0-0397-11D1-9F4E-00A0C911004F}";
            /// <summary></summary>
            public static readonly Guid SolutionHasMultipleProjects_guid = new Guid(SolutionHasMultipleProjects_string);

            /// <summary></summary>
            public const string SolutionHasSingleProject_string = "{ADFC4E66-0397-11D1-9F4E-00A0C911004F}";
            /// <summary></summary>
            public static readonly Guid SolutionHasSingleProject_guid = new Guid(SolutionHasSingleProject_string);

            /// <summary></summary>
            public const string SolutionOpening_string = "{D2567162-F94F-4091-8798-A096E61B8B50}";
            /// <summary></summary>
            public static readonly Guid SolutionOpening_guid = new Guid(SolutionOpening_string);

            /// <summary></summary>
            public const string SolutionOrProjectUpgrading_string = "{EF4F870B-7B85-4F29-9D15-CE1ABFBE733B}";
            /// <summary></summary>
            public static readonly Guid SolutionOrProjectUpgrading_guid = new Guid(SolutionOrProjectUpgrading_string);

            /// <summary></summary>
            public const string ToolboxInitialized_string = "{DC5DB425-F0FD-4403-96A1-F475CDBA9EE0}";
            /// <summary></summary>
            public static readonly Guid ToolboxInitialized_guid = new Guid(ToolboxInitialized_string);

            /// <summary></summary>
            public const string VBProject_string = "{164B10B9-B200-11D0-8C61-00A0C91E29D5}";
            /// <summary></summary>
            public static readonly Guid VBProject_guid = new Guid(VBProject_string);

            /// <summary></summary>
            public const string CSharpProject_string = "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}";
            /// <summary></summary>
            public static readonly Guid CSharpProject_guid = new Guid(CSharpProject_string);

            /// <summary></summary>
            public const string VCProject_string = "{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}";
            /// <summary></summary>
            public static readonly Guid VCProject_guid = new Guid(VCProject_string);

            /// <summary></summary>
            public const string FSharpProject_string = "{F2A71F9B-5D33-465A-A702-920D77279786}";
            /// <summary></summary>
            public static readonly Guid FSharpProject_guid = new Guid(FSharpProject_string);

            /// <summary></summary>
            public const string VBCodeAttribute_string = "{C28E28CA-E6DC-446F-BE1A-D496BEF8340A}";
            /// <summary></summary>
            public static readonly Guid VBCodeAttribute_guid = new Guid(VBCodeAttribute_string);

            /// <summary></summary>
            public const string VBCodeClass_string = "{C28E28CA-E6DC-446F-BE1A-D496BEF83401}";
            /// <summary></summary>
            public static readonly Guid VBCodeClass_guid = new Guid(VBCodeClass_string);

            /// <summary></summary>
            public const string VBCodeDelegate_string = "{C28E28CA-E6DC-446F-BE1A-D496BEF83402}";
            /// <summary></summary>
            public static readonly Guid VBCodeDelegate_guid = new Guid(VBCodeDelegate_string);

            /// <summary></summary>
            public const string VBCodeEnum_string = "{C28E28CA-E6DC-446F-BE1A-D496BEF83408}";
            /// <summary></summary>
            public static readonly Guid VBCodeEnum_guid = new Guid(VBCodeEnum_string);

            /// <summary></summary>
            public const string VBCodeFunction_string = "{C28E28CA-E6DC-446F-BE1A-D496BEF83400}";
            /// <summary></summary>
            public static readonly Guid VBCodeFunction_guid = new Guid(VBCodeFunction_string);

            /// <summary></summary>
            public const string VBCodeInterface_string = "{C28E28CA-E6DC-446F-BE1A-D496BEF83406}";
            /// <summary></summary>
            public static readonly Guid VBCodeInterface_guid = new Guid(VBCodeInterface_string);

            /// <summary></summary>
            public const string VBCodeNamespace_string = "{C28E28CA-E6DC-446F-BE1A-D496BEF83409}";
            /// <summary></summary>
            public static readonly Guid VBCodeNamespace_guid = new Guid(VBCodeNamespace_string);

            /// <summary></summary>
            public const string VBCodeParameter_string = "{C28E28CA-E6DC-446F-BE1A-D496BEF83405}";
            /// <summary></summary>
            public static readonly Guid VBCodeParameter_guid = new Guid(VBCodeParameter_string);

            /// <summary></summary>
            public const string VBCodeProperty_string = "{C28E28CA-E6DC-446F-BE1A-D496BEF83404}";
            /// <summary></summary>
            public static readonly Guid VBCodeProperty_guid = new Guid(VBCodeProperty_string);

            /// <summary></summary>
            public const string VBCodeStruct_string = "{C28E28CA-E6DC-446F-BE1A-D496BEF83407}";
            /// <summary></summary>
            public static readonly Guid VBCodeStruct_guid = new Guid(VBCodeStruct_string);

            /// <summary></summary>
            public const string VBCodeVariable_string = "{C28E28CA-E6DC-446F-BE1A-D496BEF83403}";
            /// <summary></summary>
            public static readonly Guid VBCodeVariable_guid = new Guid(VBCodeVariable_string);
        }

        
        //--------------------------------------------------------------------
        // GUIDS for built in task list views
        //--------------------------------------------------------------------
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_VsTaskListViewAll = new Guid("{1880202e-fc20-11d2-8bb1-00c04f8ec28c}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_VsTaskListViewUserTasks = new Guid("{1880202f-fc20-11d2-8bb1-00c04f8ec28c}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_VsTaskListViewShortcutTasks = new Guid("{18802030-fc20-11d2-8bb1-00c04f8ec28c}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_VsTaskListViewHTMLTasks = new Guid("{36ac1c0d-fe86-11d2-8bb1-00c04f8ec28c}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_VsTaskListViewCompilerTasks = new Guid("{18802033-fc20-11d2-8bb1-00c04f8ec28c}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_VsTaskListViewCommentTasks = new Guid("{18802034-fc20-11d2-8bb1-00c04f8ec28c}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_VsTaskListViewCurrentFileTasks = new Guid("{18802035-fc20-11d2-8bb1-00c04f8ec28c}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_VsTaskListViewCheckedTasks = new Guid("{18802036-fc20-11d2-8bb1-00c04f8ec28c}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_VsTaskListViewUncheckedTasks = new Guid("{18802037-fc20-11d2-8bb1-00c04f8ec28c}");


        /// <summary>
        /// 
        /// </summary>
        public static class VsTaskListView
        {
            //--------------------------------------------------------------------
            // GUIDS for built in task list views
            //--------------------------------------------------------------------
            /// <summary></summary>
            public static readonly Guid All = new Guid("{1880202e-fc20-11d2-8bb1-00c04f8ec28c}");
            /// <summary></summary>
            public static readonly Guid UserTasks = new Guid("{1880202f-fc20-11d2-8bb1-00c04f8ec28c}");
            /// <summary></summary>
            public static readonly Guid ShortcutTasks = new Guid("{18802030-fc20-11d2-8bb1-00c04f8ec28c}");
            /// <summary></summary>
            public static readonly Guid HTMLTasks = new Guid("{36ac1c0d-fe86-11d2-8bb1-00c04f8ec28c}");
            /// <summary></summary>
            public static readonly Guid CompilerTasks = new Guid("{18802033-fc20-11d2-8bb1-00c04f8ec28c}");
            /// <summary></summary>
            public static readonly Guid CommentTasks = new Guid("{18802034-fc20-11d2-8bb1-00c04f8ec28c}");
            /// <summary></summary>
            public static readonly Guid CurrentFileTasks = new Guid("{18802035-fc20-11d2-8bb1-00c04f8ec28c}");
            /// <summary></summary>
            public static readonly Guid CheckedTasks = new Guid("{18802036-fc20-11d2-8bb1-00c04f8ec28c}");
            /// <summary></summary>
            public static readonly Guid UncheckedTasks = new Guid("{18802037-fc20-11d2-8bb1-00c04f8ec28c}");
        }
        
        
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid CLSID_VsTaskList = new Guid("{BC5955D5-aa0d-11d0-a8c5-00a0c921a4d2}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid CLSID_VsTaskListPackage = new Guid("{4A9B7E50-aa16-11d0-a8c5-00a0c921a4d2}");


        /// <summary></summary>
        public static readonly Guid SID_SVsToolboxActiveXDataProvider = new Guid("{35222106-bb44-11d0-8c46-00c04fc2aae2}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid CLSID_VsDocOutlinePackage = new Guid("{21af45b0-ffa5-11d0-b63f-00a0c922e851}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid CLSID_VsCfgProviderEventsHelper = new Guid("{99913f1f-1ee3-11d1-8a6e-00c04f682e21}");


        //--------------------------------------------------------------------
        // Component Selector page GUIDs
        //--------------------------------------------------------------------
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_COMPlusPage = new Guid("{9A341D95-5A64-11d3-BFF9-00C04F990235}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_COMClassicPage = new Guid("{9A341D96-5A64-11d3-BFF9-00C04F990235}");
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid GUID_SolutionPage = new Guid("{9A341D97-5A64-11d3-BFF9-00C04F990235}");


        /// <summary>
        /// 
        /// </summary>
        public static class ComponentSelectorPageGuid
        {
            /// <summary>.Net managed assembly page (used with SVsComponentSelectorDlg -- Add Reference dialog)</summary>
            public const string ManagedAssemblyPage_string = "{9A341D95-5A64-11D3-BFF9-00C04F990235}";
            public static readonly Guid ManagedAssemblyPage_guid = new Guid(ManagedAssemblyPage_string);

            /// <summary>COM object page (used with SVsComponentSelectorDlg -- Add Reference dialog)</summary>
            public const string COMPage_string = "{9A341D96-5A64-11D3-BFF9-00C04F990235}";
            public static readonly Guid COMPage_guid = new Guid(COMPage_string);

            /// <summary>Projects page (used with SVsComponentSelectorDlg -- Add Reference dialog)</summary>
            public const string ProjectsPage_string = "{9A341D97-5A64-11D3-BFF9-00C04F990235}";
            public static readonly Guid ProjectsPage_guid = new Guid(ProjectsPage_string);

        }

        //--------------------------------------------------------------------
        // Logical View GUIDs
        //--------------------------------------------------------------------
        /// <summary>Kind of view for document or data: Any defined view.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid LOGVIEWID_Any = new Guid(0xffffffff, 0xffff, 0xffff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff);
        /// <summary>Kind of view for document or data: Primary (default) view.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid LOGVIEWID_Primary = Guid.Empty;
        /// <summary>Kind of view for document or data: Debugger view.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid LOGVIEWID_Debugging = new Guid("{7651A700-06E5-11D1-8EBD-00A0C90F26EA}");
        /// <summary>Kind of view for document or data: Code editor view.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid LOGVIEWID_Code = new Guid("{7651A701-06E5-11D1-8EBD-00A0C90F26EA}");
        /// <summary>Kind of view for document or data: Designer view.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid LOGVIEWID_Designer = new Guid("{7651A702-06E5-11D1-8EBD-00A0C90F26EA}");
        /// <summary>Kind of view for document or data: Text editor view.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid LOGVIEWID_TextView = new Guid("{7651A703-06E5-11D1-8EBD-00A0C90F26EA}");
        /// <summary>Kind of view for document or data: A user defined view.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Guid LOGVIEWID_UserChooseView = new Guid("{7651A704-06E5-11D1-8EBD-00A0C90F26EA}");



        /// <summary>
        /// 
        /// </summary>
        public static class LOGVIEWID
        {
            /// <summary>Kind of view for document or data: Any defined view.</summary>
            public const string Any_string = "{FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF}";
            /// <summary>Kind of view for document or data: Any defined view.</summary>
            public static readonly Guid Any_guid = new Guid(Any_string);

            /// <summary>Kind of view for document or data: Code editor view.</summary>
            public const string Code_string = "{7651A701-06E5-11D1-8EBD-00A0C90F26EA}";
            /// <summary>Kind of view for document or data: Code editor view.</summary>
            public static readonly Guid Code_guid = new Guid(Code_string);

            /// <summary>Kind of view for document or data: Debugger view.</summary>
            public const string Debugging_string = "{7651A700-06E5-11D1-8EBD-00A0C90F26EA}";
            /// <summary>Kind of view for document or data: Debugger view.</summary>
            public static readonly Guid Debugging_guid = new Guid(Debugging_string);

            /// <summary>Kind of view for document or data: Designer view.</summary>
            public const string Designer_string = "{7651A702-06E5-11D1-8EBD-00A0C90F26EA}";
            /// <summary>Kind of view for document or data: Designer view.</summary>
            public static readonly Guid Designer_guid = new Guid(Designer_string);

            /// <summary></summary>
            public const string ProjectSpecificEditor_string = "{80A3471A-6B87-433E-A75A-9D461DE0645F}";
            /// <summary></summary>
            public static readonly Guid ProjectSpecificEditor_guid = new Guid(ProjectSpecificEditor_string);

            /// <summary>Kind of view for document or data: Primary (default) view.</summary>
            public static readonly Guid Primary_guid = Guid.Empty;

            /// <summary>Kind of view for document or data: Text editor view.</summary>
            public const string TextView_string = "{7651A703-06E5-11D1-8EBD-00A0C90F26EA}";
            /// <summary>Kind of view for document or data: Text editor view.</summary>
            public static readonly Guid TextView_guid = new Guid(TextView_string);

            /// <summary>Kind of view for document or data: A user defined view.</summary>
            public const string UserChooseView_string = "{7651A704-06E5-11D1-8EBD-00A0C90F26EA}";
            /// <summary>Kind of view for document or data: A user defined view.</summary>
            public static readonly Guid UserChooseView_guid = new Guid(UserChooseView_string);

        }

        // VS Constants

        /// <summary>Special items inside a VsHierarchy: no node.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const uint VSITEMID_NIL = unchecked((uint)-1);
        /// <summary>Special items inside a VsHierarchy: the hierarchy itself.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const uint VSITEMID_ROOT = unchecked((uint)-2);
        /// <summary>Special items inside a VsHierarchy: all the currently selected items.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const uint VSITEMID_SELECTION = unchecked((uint)-3);

        public enum VSITEMID : uint
        {
            /// <summary>Special items inside a VsHierarchy: no node.</summary>
            Nil = unchecked((uint)-1),
            /// <summary>Special items inside a VsHierarchy: the hierarchy itself.</summary>
            Root= unchecked((uint)-2),
            /// <summary>Special items inside a VsHierarchy: all the currently selected items.</summary>
            Selection = unchecked((uint)-3),
        }
        
        /// <summary>Special value for a cookie (e.g. returned from IVsRunningDocumentTable.FindAndLockDocument): no cookie.</summary>
        public const uint VSCOOKIE_NIL = 0;


        // for IVsSelectionEvents flags
        /// <summary>IVsSelectionEvents.OnElementValueChanged flag: The undo manager.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const uint UndoManager = 0x0;
        /// <summary>IVsSelectionEvents.OnElementValueChanged flag: A window frame.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const uint WindowFrame = 0x1;
        /// <summary>IVsSelectionEvents.OnElementValueChanged flag: A document frame.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const uint DocumentFrame = 0x2;
        /// <summary>IVsSelectionEvents.OnElementValueChanged flag: The startup project.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const uint StartupProject = 0x3;
        /// <summary>IVsSelectionEvents.OnElementValueChanged flag: The property borowser.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const uint PropertyBrowserSID = 0x4;
        /// <summary>IVsSelectionEvents.OnElementValueChanged flag: A user context.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const uint UserContext = 0x5;

        public enum SelectionElement : uint
        {
            // for IVsSelectionEvents flags
            /// <summary>IVsSelectionEvents.OnElementValueChanged flag: The undo manager.</summary>
            UndoManager = 0x0,
            /// <summary>IVsSelectionEvents.OnElementValueChanged flag: A window frame.</summary>
            WindowFrame = 0x1,
            /// <summary>IVsSelectionEvents.OnElementValueChanged flag: A document frame.</summary>
            DocumentFrame = 0x2,
            /// <summary>IVsSelectionEvents.OnElementValueChanged flag: The startup project.</summary>
            StartupProject = 0x3,
            /// <summary>IVsSelectionEvents.OnElementValueChanged flag: The property borowser.</summary>
            PropertyBrowserSID = 0x4,
            /// <summary>IVsSelectionEvents.OnElementValueChanged flag: A user context.</summary>
            UserContext = 0x5
        }



        // VS HRESULTS

        /// <summary>VS specific error HRESULT for "Project already exists".</summary>
        public const int VS_E_PROJECTALREADYEXISTS = unchecked((int)0x80041FE0);
        /// <summary>VS specific error HRESULT for "Package not loaded".</summary>
        public const int VS_E_PACKAGENOTLOADED = unchecked((int)0x80041FE1);
        /// <summary>VS specific error HRESULT for "Project not loaded".</summary>
        public const int VS_E_PROJECTNOTLOADED = unchecked((int)0x80041FE2);
        /// <summary>VS specific error HRESULT for "Solution not open".</summary>
        public const int VS_E_SOLUTIONNOTOPEN = unchecked((int)0x80041FE3);
        /// <summary>VS specific error HRESULT for "Solution already open".</summary>
        public const int VS_E_SOLUTIONALREADYOPEN = unchecked((int)0x80041FE4);
        /// <summary>VS specific error HRESULT for "Project configuration failed".</summary>
        public const int VS_E_PROJECTMIGRATIONFAILED = unchecked((int)0x80041FE5);
        /// <summary>VS specific error HRESULT for "Incompatible document data".</summary>
        public const int VS_E_INCOMPATIBLEDOCDATA = unchecked((int)0x80041FEA);
        /// <summary>VS specific error HRESULT for "Unsupported format".</summary>
        public const int VS_E_UNSUPPORTEDFORMAT = unchecked((int)0x80041FEB);
        /// <summary>VS specific error HRESULT for "Wizard back button pressed".</summary>
        public const int VS_E_WIZARDBACKBUTTONPRESS = unchecked((int)0x80041fff);
        /// <summary>VS specific success HRESULT for "Project forwarded".</summary>
        public const int VS_S_PROJECTFORWARDED = unchecked((int)0x41ff0);
        /// <summary>VS specific success HRESULT for "Toolbox marker".</summary>
        public const int VS_S_TBXMARKER = unchecked((int)0x41ff1);

        // Selection Containter Constants
        public const uint ALL = 0x1;
        public const uint SELECTED = 0x2;

        // OLE HRESULTS - may be returned by OLE or related VS methods
        public const int
        OLE_E_OLEVERB = unchecked((int)0x80040000),
        OLE_E_ADVF = unchecked((int)0x80040001),
        OLE_E_ENUM_NOMORE = unchecked((int)0x80040002),
        OLE_E_ADVISENOTSUPPORTED = unchecked((int)0x80040003),
        OLE_E_NOCONNECTION = unchecked((int)0x80040004),
        OLE_E_NOTRUNNING = unchecked((int)0x80040005),
        OLE_E_NOCACHE = unchecked((int)0x80040006),
        OLE_E_BLANK = unchecked((int)0x80040007),
        OLE_E_CLASSDIFF = unchecked((int)0x80040008),
        OLE_E_CANT_GETMONIKER = unchecked((int)0x80040009),
        OLE_E_CANT_BINDTOSOURCE = unchecked((int)0x8004000A),
        OLE_E_STATIC = unchecked((int)0x8004000B),
        OLE_E_PROMPTSAVECANCELLED = unchecked((int)0x8004000C),
        OLE_E_INVALIDRECT = unchecked((int)0x8004000D),
        OLE_E_WRONGCOMPOBJ = unchecked((int)0x8004000E),
        OLE_E_INVALIDHWND = unchecked((int)0x8004000F),
        OLE_E_NOT_INPLACEACTIVE = unchecked((int)0x80040010),
        OLE_E_CANTCONVERT = unchecked((int)0x80040011),
        OLE_E_NOSTORAGE = unchecked((int)0x80040012);

        // OLE DISP HRESULTS - may be returned by OLE DISP or related VS methods 

        public const int
        DISP_E_UNKNOWNINTERFACE = unchecked((int)0x80020001),
        DISP_E_MEMBERNOTFOUND = unchecked((int)0x80020003),
        DISP_E_PARAMNOTFOUND = unchecked((int)0x80020004),
        DISP_E_TYPEMISMATCH = unchecked((int)0x80020005),
        DISP_E_UNKNOWNNAME = unchecked((int)0x80020006),
        DISP_E_NONAMEDARGS = unchecked((int)0x80020007),
        DISP_E_BADVARTYPE = unchecked((int)0x80020008),
        DISP_E_EXCEPTION = unchecked((int)0x80020009),
        DISP_E_OVERFLOW = unchecked((int)0x8002000A),
        DISP_E_BADINDEX = unchecked((int)0x8002000B),
        DISP_E_UNKNOWNLCID = unchecked((int)0x8002000C),
        DISP_E_ARRAYISLOCKED = unchecked((int)0x8002000D),
        DISP_E_BADPARAMCOUNT = unchecked((int)0x8002000E),
        DISP_E_PARAMNOTOPTIONAL = unchecked((int)0x8002000F),
        DISP_E_BADCALLEE = unchecked((int)0x80020010),
        DISP_E_NOTACOLLECTION = unchecked((int)0x80020011),
        DISP_E_DIVBYZERO = unchecked((int)0x80020012),
        DISP_E_BUFFERTOOSMALL = unchecked((int)0x80020013);


        //-----------------------------------------------------------------------------
        //  VS_E_BUSY is returned by interfaces to asynchronous behavior when the
        //  object in question in already busy.  For example, starting a build while
        //  a buildable project configuration object is in the process of cleaning,
        //  building or checking for out of date-ness.
        //-----------------------------------------------------------------------------
        /// <summary>
        /// VS specific error HRESULT returned by interfaces to asynchronous behavior when the
        /// object in question in already busy.
        /// </summary>
        public const int VS_E_BUSY = unchecked((int)0x80040200);
        /// <summary>
        /// Is returned by build interfaces that have parameters for specifying an array of IVsOutput's
        /// but the implementation can only apply the method to all outputs.
        /// </summary>
        public const int VS_E_SPECIFYING_OUTPUT_UNSUPPORTED = unchecked((int)0x80040201);

        // General HRESULTS

        /// <summary>HRESULT for FALSE (not an error).</summary>
        public const int S_FALSE = 0x00000001;
        /// <summary>HRESULT for generic success.</summary>
        public const int S_OK = 0x00000000;
        /// <summary>Error HRESULT for a client abort.</summary>
        public const int UNDO_E_CLIENTABORT = unchecked((int)0x80044001);
        /// <summary>Error HRESULT for out of memory.</summary>
        public const int E_OUTOFMEMORY = unchecked((int)0x8007000E);
        /// <summary>Error HRESULT for an invalid argument.</summary>
        public const int E_INVALIDARG = unchecked((int)0x80070057);
        /// <summary>Error HRESULT for a generic failure.</summary>
        public const int E_FAIL = unchecked((int)0x80004005);
        /// <summary>Error HRESULT for the request of a not implemented interface.</summary>
        public const int E_NOINTERFACE = unchecked((int)0x80004002);
        /// <summary>Error HRESULT for the call to a not implemented method.</summary>
        public const int E_NOTIMPL = unchecked((int)0x80004001);
        /// <summary>Error HRESULT for an unexpected condition.</summary>
        public const int E_UNEXPECTED = unchecked((int)0x8000FFFF);
        /// <summary>Error HRESULT for a null or invalid pointer.</summary>
        public const int E_POINTER = unchecked((int)0x80004003);
        /// <summary>Error HRESULT for an invalid HANDLE.</summary>
        public const int E_HANDLE = unchecked((int)0x80070006);
        /// <summary>Error HRESULT for an abort.</summary>
        public const int E_ABORT = unchecked((int)0x80004004);
        /// <summary>Error HRESULT for an access denied.</summary>
        public const int E_ACCESSDENIED = unchecked((int)0x80070005);
        /// <summary>Error HRESULT for a pending condition.</summary>
        public const int E_PENDING = unchecked((int)0x8000000A);

        // Window Messages
        internal const int WM_USER = 0x0400;

        // VS specific messages
        // These definitions are for broadcasting a notification message via
        //   IVsBroadcastMessageEvents::OnBroadcastMessage to indicate that the cmdbar
        //   metrics have changed.
        /// <summary>Toolbar metrics changed.</summary>
        public const int VSM_TOOLBARMETRICSCHANGE = WM_USER + 0x0C52;
        /// <summary></summary>
        public const int VSM_ENTERMODAL = WM_USER + 0x0C53;
        /// <summary></summary>
        public const int VSM_EXITMODAL = WM_USER + 0x0C54;

        // messages sent from Component Selector dialog to page dialogs.
        /// <summary>Inform of selection change on page.</summary>
        public const int CPDN_SELCHANGED = WM_USER + 1280;
        /// <summary>Inform of doubld-click on selected item on page.</summary>
        public const int CPDN_SELDBLCLICK = WM_USER + 1281;
        /// <summary>Initialize list of available components.</summary>
        public const int CPPM_INITIALIZELIST = WM_USER + 1285;
        /// <summary>Determine whether Select button should be enabled.</summary>
        public const int CPPM_QUERYCANSELECT = WM_USER + 1286;
        /// <summary>Retrieve information about selection.</summary>
        public const int CPPM_GETSELECTION = WM_USER + 1287;
        /// <summary>Initialize tab with VARIANT in VSCOMPONENTSELECTORTABINIT.</summary>
        public const int CPPM_INITIALIZETAB = WM_USER + 1288;
        /// <summary>Set multiple-selection mode for picker.</summary>
        public const int CPPM_SETMULTISELECT = WM_USER + 1289;
        /// <summary>Reset and clear selection in list of available components.</summary>
        public const int CPPM_CLEARSELECTION = WM_USER + 1290;

    }

    [CLSCompliant(false)]
    public class Win32Methods
    {
        /// <summary>
        /// Changes the parent window of the specified child window.
        /// </summary>
        /// <param name="hWnd">Handle to the child window.</param>
        /// <param name="hWndParent">Handle to the new parent window. If this parameter is NULL, the desktop window becomes the new parent window.</param>
        /// <returns>A handle to the previous parent window indicates success. NULL indicates failure.</returns>
        [DllImport("User32", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SetParent(IntPtr hWnd, IntPtr hWndParent);

        [DllImport("user32.dll", EntryPoint = "IsDialogMessageA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool IsDialogMessageA(IntPtr hDlg, ref MSG msg);

    }

    [ComImport(), Guid("9BDA66AE-CA28-4e22-AA27-8A7218A0E3FA"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown), CLSCompliant(false)]
    public interface IEventHandler
    {

        // converts the underlying codefunction into an event handler for the given event
        // if the given event is NULL, then the function will handle no events
        [PreserveSig]
        int AddHandler(string bstrEventName);

        [PreserveSig]
        int RemoveHandler(string bstrEventName);

        IVsEnumBSTR GetHandledEvents();

        bool HandlesEvent(string bstrEventName);
    }
}

