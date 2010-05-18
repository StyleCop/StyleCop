'<script Language='VBScript'> -- provides syntax highlighting in VId
' Convert Windows Installer MSI database to an XML manifest
Option Explicit

' Default file extensions
Const extManifest   = "wxp_From_MsiToXml"   'Windows Installer manifest XML file using schema "wiSchema.xml"
Const extDatabase   = "msi"   'Windows Installer database file
Const extTransform  = "mst"   'Windows Installer transform file

' DOM definitions
Const NODE_ELEMENT                = 1
Const NODE_ATTRIBUTE              = 2
Const NODE_TEXT                   = 3
Const NODE_CDATA_SECTION          = 4
Const NODE_ENTITY_REFERENCE       = 5
Const NODE_ENTITY                 = 6
Const NODE_PROCESSING_INSTRUCTION = 7
Const NODE_COMMENT                = 8
Const NODE_DOCUMENT               = 9
Const NODE_DOCUMENT_TYPE          = 10
Const NODE_DOCUMENT_FRAGMENT      = 11
Const NODE_NOTATION               = 12

' FileSystemObject constants
Const OverwriteIfExist = -1
Const OpenAsASCII      =  0 
Const OpenAsUnicode    = -1 
Const ForReading       =  1
Const FailIfNotExist   =  0
Const OpenAsDefault    = -2

'--------------------------------------------------------'
' Installer definitions
'--------------------------------------------------------'
Const msiOpenDatabaseModeReadOnly = 0
Const msiOpenDatabaseModeTransact = 1
Const msiOpenDatabaseModeDirect   = 2
Const msiOpenDatabaseModeCreate   = 3
Const msiViewModifySeek     = -1
Const msiViewModifyInsert   = 1
Const msiViewModifyUpdate   = 2
Const msiViewModifyAssign   = 3
Const msiViewModifyReplace  = 4
Const msiViewModifyMerge    = 5
Const msiViewModifyDelete   = 6

' Feature.Attributes mapping
Const msidbFeatureAttributesFavorSource            = &h0001
Const msidbFeatureAttributesFollowParent           = &h0002
Const msidbFeatureAttributesFavorAdvertise         = &h0004
Const msidbFeatureAttributesDisallowAdvertise      = &h0008
Const msidbFeatureAttributesUIDisallowAbsent       = &h0010
Const msidbFeatureAttributesNoUnsupportedAdvertise = &h0020

' Component.Attributes mapping
Const msidbComponentAttributesSourceOnly        = &h01
Const msidbComponentAttributesOptional          = &h02
Const msidbComponentAttributesRegistryKeyPath   = &h04
Const msidbComponentAttributesSharedDllRefCount = &h08
Const msidbComponentAttributesPermanent         = &h10
Const msidbComponentAttributesODBCDataSource    = &h20
Const msidbComponentAttributesTransitive        = &h40
Const msidbComponentAttributesNeverOverwrite    = &h80

' File.Attributes mapping
Const msidbFileAttributesReadOnly      = &h0001
Const msidbFileAttributesHidden        = &h0002
Const msidbFileAttributesSystem        = &h0004
Const msidbFileAttributesVital         = &h0200
Const msidbFileAttributesChecksum      = &h0400
Const msidbFileAttributesPatchAdded    = &h1000
Const msidbFileAttributesNoncompressed = &h2000
Const msidbFileAttributesCompressed    = &h4000

' Class.Attributes mapping
Const msidbClassAttributesRelativePath = &h0001

' IniFile actions
Const msidbIniFileActionAddLine    = 0
Const msidbIniFileActionCreateLine = 1
Const msidbIniFileActionRemoveLine = 2
Const msidbIniFileActionAddTag     = 3
Const msidbIniFileActionRemoveTag  = 4

' CustomAction.Type mapping
Const msidbCustomActionTypeTypeBits       = &h0007
Const msidbCustomActionTypeDll            = &h0001 ' Target = entry point name
Const msidbCustomActionTypeExe            = &h0002 ' Target = command line args
Const msidbCustomActionTypeTextData       = &h0003 ' Target = text string to be formatted and set into property
Const msidbCustomActionTypeJScript        = &h0005 ' Target = entry point name, null if none to call
Const msidbCustomActionTypeVBScript       = &h0006 ' Target = entry point name, null if none to call
Const msidbCustomActionTypeInstall        = &h0007 ' Target = property list for nested engine initialization
Const msidbCustomActionTypeSourceBits     = &h0030
Const msidbCustomActionTypeBinaryData     = &h0000 ' Source = Binary.Name, data stored in stream
Const msidbCustomActionTypeSourceFile     = &h0010 ' Source = File.File, file part of installation
Const msidbCustomActionTypeDirectory      = &h0020 ' Source = Directory.Directory, folder containing existing file
Const msidbCustomActionTypeProperty       = &h0030 ' Source = Property.Property, full path to executable
Const msidbCustomActionTypeReturnBits     = &h00C0
Const msidbCustomActionTypeContinue       = &h0040 ' ignore action return status, continue running
Const msidbCustomActionTypeAsync          = &h0080 ' run asynchronously
Const msidbCustomActionTypeExecuteBits    = &h0700
Const msidbCustomActionTypeFirstSequence  = &h0100 ' skip if UI sequence already run
Const msidbCustomActionTypeOncePerProcess = &h0200 ' skip if UI sequence already run in same process
Const msidbCustomActionTypeClientRepeat   = &h0300 ' run on client only if UI already run on client
Const msidbCustomActionTypeInScript       = &h0400 ' queue for execution within script
Const msidbCustomActionTypeRollback       = &h0100 ' in conjunction with InScript: queue in Rollback script
Const msidbCustomActionTypeCommit         = &h0200 ' in conjunction with InScript: run Commit ops from script on success
Const msidbCustomActionTypeNoImpersonate  = &h0800 ' no impersonation, run in system context

' ServiceControl.Event
Const msidbServiceControlEventStart           = &h0001
Const msidbServiceControlEventStop            = &h0002
Const msidbServiceControlEventRemove          = &h0008
Const msidbServiceControlEventUninstallStart  = &h0010
Const msidbServiceControlEventUninstallStop   = &h0020
Const msidbServiceControlEventUninstallRemove = &h0080

' ServiceInstall.ServiceType
Const msidbServiceInstallOwnProcess           = &h0010
Const msidbServiceInstallShareProcess         = &h0020
Const msidbServiceInstallInteractive          = &h0100

' ServiceInstall.StartType
Const msidbServiceInstallAutoStart            = &h0002
Const msidbServiceInstallDemandStart          = &h0003
Const msidbServiceInstallDisabled             = &h0004

' ServiceInstall.ErrorControl
Const msidbServiceInstallErrorIgnore          = &h0000
Const msidbServiceInstallErrorNormal          = &h0001
Const msidbServiceInstallErrorCritical        = &h0004
Const msidbServiceInstallErrorControlVital    = &h8000

' Dialog.Attributes
Const msidbDialogAttributesVisible          = &h00000001
Const msidbDialogAttributesModal            = &h00000002
Const msidbDialogAttributesMinimize         = &h00000004
Const msidbDialogAttributesSysModal         = &h00000008
Const msidbDialogAttributesKeepModeless     = &h00000010
Const msidbDialogAttributesTrackDiskSpace   = &h00000020
Const msidbDialogAttributesUseCustomPalette = &h00000040
Const msidbDialogAttributesRTLRO            = &h00000080
Const msidbDialogAttributesRightAligned     = &h00000100
Const msidbDialogAttributesLeftScroll       = &h00000200
Const msidbDialogAttributesError            = &h00010000

' Control.Attributes - common
Const msidbControlAttributesVisible         = &h00000001
Const msidbControlAttributesEnabled         = &h00000002
Const msidbControlAttributesSunken          = &h00000004
Const msidbControlAttributesIndirect        = &h00000008
Const msidbControlAttributesInteger         = &h00000010
Const msidbControlAttributesRTLRO           = &h00000020
Const msidbControlAttributesRightAligned    = &h00000040
Const msidbControlAttributesLeftScroll      = &h00000080

' Control.Attributes - Text controls
Const msidbControlAttributesTransparent     = &h00010000
Const msidbControlAttributesNoPrefix        = &h00020000
Const msidbControlAttributesNoWrap          = &h00040000
Const msidbControlAttributesFormatSize      = &h00080000
Const msidbControlAttributesUsersLanguage   = &h00100000

' Control.Attributes - Edit controls
Const msidbControlAttributesMultiline       = &h00010000
Const msidbControlAttributesPasswordInput   = &h00200000

' Control.Attributes - ProgressBar
Const msidbControlAttributesProgress95      = &h00010000

' Control.Attributes - VolumeSelectCombo and DirectoryCombo
Const msidbControlAttributesRemovableVolume = &h00010000
Const msidbControlAttributesFixedVolume     = &h00020000
Const msidbControlAttributesRemoteVolume    = &h00040000
Const msidbControlAttributesCDROMVolume     = &h00080000
Const msidbControlAttributesRAMDiskVolume   = &h00100000
Const msidbControlAttributesFloppyVolume    = &h00200000

' Control.Attributes - VolumeCostList control
Const msidbControlShowRollbackCost          = &h00400000

' Control.Attributes - ListBox and ComboBox controls
Const msidbControlAttributesSorted          = &h00010000
Const msidbControlAttributesComboList       = &h00020000

' Control.Attributes - RadioButton controls
Const msidbControlAttributesHasBorder       = &h01000000

' Control.Attributes - picture button controls - used?
Const msidbControlAttributesImageHandle     = &h00010000
Const msidbControlAttributesPushLike        = &h00020000
Const msidbControlAttributesBitmap          = &h00040000
Const msidbControlAttributesIcon            = &h00080000
Const msidbControlAttributesFixedSize       = &h00100000
Const msidbControlAttributesIconSize16      = &h00200000
Const msidbControlAttributesIconSize32      = &h00400000
Const msidbControlAttributesIconSize48      = &h00600000

' RegLocator.Root - registry hives
Const msidbRegistryRootClassesRoot          = &h00000000
Const msidbRegistryRootCurrentUser          = &h00000001
Const msidbRegistryRootLocalMachine         = &h00000002
Const msidbRegistryRootUsers                = &h00000003

' RegLocator.Type - types of registry value
Const msidbLocatorTypeDirectory             = &h00000000
Const msidbLocatorTypeFileName              = &h00000001
Const msidbLocatorTypeRawValue              = &h00000002
Const msidbLocatorType64bit                 = &h00000010

' RemoveFile.InstallMode - when to remove file
Const msidbRemoveFileInstallModeOnInstall   = &h00000001
Const msidbRemoveFileInstallModeOnRemove    = &h00000002
Const msidbRemoveFileInstallModeOnBoth      = &h00000003

' Windows API function ShowWindow constants - used in Shortcut table
Const SW_SHOWNORMAL                         = &h00000001
Const SW_SHOWMAXIMIZED                      = &h00000003
Const SW_SHOWMINNOACTIVE                    = &h00000007

'--------------------------------------------------------'
' Windows Installer database table schema columns
' generated by WiSchema.vbs from standard MSI schema
'--------------------------------------------------------'
Const ActionText_Action      = 1
Const ActionText_Description = 2
Const ActionText_Template    = 3
Const AdminExecuteSequence_Action    = 1
Const AdminExecuteSequence_Condition = 2
Const AdminExecuteSequence_Sequence  = 3
Const AdminUISequence_Action    = 1
Const AdminUISequence_Condition = 2
Const AdminUISequence_Sequence  = 3
Const AdvtExecuteSequence_Action    = 1
Const AdvtExecuteSequence_Condition = 2
Const AdvtExecuteSequence_Sequence  = 3
Const AdvtUISequence_Action    = 1
Const AdvtUISequence_Condition = 2
Const AdvtUISequence_Sequence  = 3
Const AppId_AppId                = 1
Const AppId_RemoteServerName     = 2
Const AppId_LocalService         = 3
Const AppId_ServiceParameters    = 4
Const AppId_DllSurrogate         = 5
Const AppId_ActivateAtStorage    = 6
Const AppId_RunAsInteractiveUser = 7
Const AppSearch_Property   = 1
Const AppSearch_Signature_ = 2
Const BBControl_Billboard_ = 1
Const BBControl_BBControl  = 2
Const BBControl_Type       = 3
Const BBControl_X          = 4
Const BBControl_Y          = 5
Const BBControl_Width      = 6
Const BBControl_Height     = 7
Const BBControl_Attributes = 8
Const BBControl_Text       = 9
Const Billboard_Billboard = 1
Const Billboard_Feature_  = 2
Const Billboard_Action    = 3
Const Billboard_Ordering  = 4
Const Binary_Name = 1
Const Binary_Data = 2
Const BindImage_File_ = 1
Const BindImage_Path  = 2
Const CCPSearch_Signature_ = 1
Const CheckBox_Property = 1
Const CheckBox_Value    = 2
Const Class_CLSID            = 1
Const Class_Context          = 2
Const Class_Component_       = 3
Const Class_ProgId_Default   = 4
Const Class_Description      = 5
Const Class_AppId_           = 6
Const Class_FileTypeMask     = 7
Const Class_Icon_            = 8
Const Class_IconIndex        = 9
Const Class_DefInprocHandler =10
Const Class_Argument         =11
Const Class_Feature_         =12
Const Class_Attributes       =13
Const ComboBox_Property = 1
Const ComboBox_Order    = 2
Const ComboBox_Value    = 3
Const ComboBox_Text     = 4
Const CompLocator_Signature_  = 1
Const CompLocator_ComponentId = 2
Const CompLocator_Type        = 3
Const Complus_Component_ = 1
Const Complus_ExpType    = 2
Const Component_Component   = 1
Const Component_ComponentId = 2
Const Component_Directory_  = 3
Const Component_Attributes  = 4
Const Component_Condition   = 5
Const Component_KeyPath     = 6
Const Condition_Feature_  = 1
Const Condition_Level     = 2
Const Condition_Condition = 3
Const Control_Dialog_      = 1
Const Control_Control      = 2
Const Control_Type         = 3
Const Control_X            = 4
Const Control_Y            = 5
Const Control_Width        = 6
Const Control_Height       = 7
Const Control_Attributes   = 8
Const Control_Property     = 9
Const Control_Text         =10
Const Control_Control_Next =11
Const Control_Help         =12
Const ControlCondition_Dialog_   = 1
Const ControlCondition_Control_  = 2
Const ControlCondition_Action    = 3
Const ControlCondition_Condition = 4
Const ControlEvent_Dialog_   = 1
Const ControlEvent_Control_  = 2
Const ControlEvent_Event     = 3
Const ControlEvent_Argument  = 4
Const ControlEvent_Condition = 5
Const ControlEvent_Ordering  = 6
Const CreateFolder_Directory_ = 1
Const CreateFolder_Component_ = 2
Const CustomAction_Action = 1
Const CustomAction_Type   = 2
Const CustomAction_Source = 3
Const CustomAction_Target = 4
Const Dialog_Dialog          = 1
Const Dialog_HCentering      = 2
Const Dialog_VCentering      = 3
Const Dialog_Width           = 4
Const Dialog_Height          = 5
Const Dialog_Attributes      = 6
Const Dialog_Title           = 7
Const Dialog_Control_First   = 8
Const Dialog_Control_Default = 9
Const Dialog_Control_Cancel  =10
Const Directory_Directory        = 1
Const Directory_Directory_Parent = 2
Const Directory_DefaultDir       = 3
Const DrLocator_Signature_ = 1
Const DrLocator_Parent     = 2
Const DrLocator_Path       = 3
Const DrLocator_Depth      = 4
Const DuplicateFile_FileKey    = 1
Const DuplicateFile_Component_ = 2
Const DuplicateFile_File_      = 3
Const DuplicateFile_DestName   = 4
Const DuplicateFile_DestFolder = 5
Const Environment_Environment = 1
Const Environment_Name        = 2
Const Environment_Value       = 3
Const Environment_Component_  = 4
Const Error_Error   = 1
Const Error_Message = 2
Const EventMapping_Dialog_   = 1
Const EventMapping_Control_  = 2
Const EventMapping_Event     = 3
Const EventMapping_Attribute = 4
Const Extension_Extension  = 1
Const Extension_Component_ = 2
Const Extension_ProgId_    = 3
Const Extension_MIME_      = 4
Const Extension_Feature_   = 5
Const Feature_Feature        = 1
Const Feature_Feature_Parent = 2
Const Feature_Title          = 3
Const Feature_Description    = 4
Const Feature_Display        = 5
Const Feature_Level          = 6
Const Feature_Directory_     = 7
Const Feature_Attributes     = 8
Const FeatureComponents_Feature_   = 1
Const FeatureComponents_Component_ = 2
Const File_File       = 1
Const File_Component_ = 2
Const File_FileName   = 3
Const File_FileSize   = 4
Const File_Version    = 5
Const File_Language   = 6
Const File_Attributes = 7
Const File_Sequence   = 8
Const Font_File_     = 1
Const Font_FontTitle = 2
Const Icon_Name = 1
Const Icon_Data = 2
Const IniFile_IniFile     = 1
Const IniFile_FileName    = 2
Const IniFile_DirProperty = 3
Const IniFile_Section     = 4
Const IniFile_Key         = 5
Const IniFile_Value       = 6
Const IniFile_Action      = 7
Const IniFile_Component_  = 8
Const IniLocator_Signature_ = 1
Const IniLocator_FileName   = 2
Const IniLocator_Section    = 3
Const IniLocator_Key        = 4
Const IniLocator_Field      = 5
Const IniLocator_Type       = 6
Const InstallExecuteSequence_Action    = 1
Const InstallExecuteSequence_Condition = 2
Const InstallExecuteSequence_Sequence  = 3
Const InstallUISequence_Action    = 1
Const InstallUISequence_Condition = 2
Const InstallUISequence_Sequence  = 3
Const IsolatedComponent_Component_Shared      = 1
Const IsolatedComponent_Component_Application = 2
Const LaunchCondition_Condition   = 1
Const LaunchCondition_Description = 2
Const ListBox_Property = 1
Const ListBox_Order    = 2
Const ListBox_Value    = 3
Const ListBox_Text     = 4
Const ListView_Property = 1
Const ListView_Order    = 2
Const ListView_Value    = 3
Const ListView_Text     = 4
Const ListView_Binary_  = 5
Const LockPermissions_LockObject = 1
Const LockPermissions_Table      = 2
Const LockPermissions_Domain     = 3
Const LockPermissions_User       = 4
Const LockPermissions_Permission = 5
Const MIME_ContentType = 1
Const MIME_Extension_  = 2
Const MIME_CLSID       = 3
Const Media_DiskId       = 1
Const Media_LastSequence = 2
Const Media_DiskPrompt   = 3
Const Media_Cabinet      = 4
Const Media_VolumeLabel  = 5
Const Media_Source       = 6
Const ModuleSignature_ModuleID = 1
Const ModuleSignature_Language = 2
Const ModuleSignature_Version  = 3
Const MoveFile_FileKey      = 1
Const MoveFile_Component_   = 2
Const MoveFile_SourceName   = 3
Const MoveFile_DestName     = 4
Const MoveFile_SourceFolder = 5
Const MoveFile_DestFolder   = 6
Const MoveFile_Options      = 7
Const MsiAssembly_Component_       = 1
Const MsiAssembly_Feature_         = 2
Const MsiAssembly_File_Manifest    = 3
Const MsiAssembly_File_Application = 4
Const MsiAssembly_Attributes       = 5
Const MsiAssemblyName_Component_ = 1
Const MsiAssemblyName_Name       = 2
Const MsiAssemblyName_Value      = 3
Const ODBCAttribute_Driver_   = 1
Const ODBCAttribute_Attribute = 2
Const ODBCAttribute_Value     = 3
Const ODBCDataSource_DataSource        = 1
Const ODBCDataSource_Component_        = 2
Const ODBCDataSource_Description       = 3
Const ODBCDataSource_DriverDescription = 4
Const ODBCDataSource_Registration      = 5
Const ODBCDriver_Driver      = 1
Const ODBCDriver_Component_  = 2
Const ODBCDriver_Description = 3
Const ODBCDriver_File_       = 4
Const ODBCDriver_File_Setup  = 5
Const ODBCSourceAttribute_DataSource_ = 1
Const ODBCSourceAttribute_Attribute   = 2
Const ODBCSourceAttribute_Value       = 3
Const ODBCTranslator_Translator  = 1
Const ODBCTranslator_Component_  = 2
Const ODBCTranslator_Description = 3
Const ODBCTranslator_File_       = 4
Const ODBCTranslator_File_Setup  = 5
Const Patch_File_      = 1
Const Patch_Sequence   = 2
Const Patch_PatchSize  = 3
Const Patch_Attributes = 4
Const Patch_Header     = 5
Const PatchPackage_PatchId = 1
Const PatchPackage_Media_  = 2
Const ProgId_ProgId        = 1
Const ProgId_ProgId_Parent = 2
Const ProgId_Class_        = 3
Const ProgId_Description   = 4
Const ProgId_Icon_         = 5
Const ProgId_IconIndex     = 6
Const Property_Property = 1
Const Property_Value    = 2
Const PublishComponent_ComponentId = 1
Const PublishComponent_Qualifier   = 2
Const PublishComponent_Component_  = 3
Const PublishComponent_AppData     = 4
Const PublishComponent_Feature_    = 5
Const RadioButton_Property = 1
Const RadioButton_Order    = 2
Const RadioButton_Value    = 3
Const RadioButton_X        = 4
Const RadioButton_Y        = 5
Const RadioButton_Width    = 6
Const RadioButton_Height   = 7
Const RadioButton_Text     = 8
Const RadioButton_Help     = 9
Const RegLocator_Signature_ = 1
Const RegLocator_Root       = 2
Const RegLocator_Key        = 3
Const RegLocator_Name       = 4
Const RegLocator_Type       = 5
Const Registry_Registry   = 1
Const Registry_Root       = 2
Const Registry_Key        = 3
Const Registry_Name       = 4
Const Registry_Value      = 5
Const Registry_Component_ = 6
Const RemoveFile_FileKey     = 1
Const RemoveFile_Component_  = 2
Const RemoveFile_FileName    = 3
Const RemoveFile_DirProperty = 4
Const RemoveFile_InstallMode = 5
Const RemoveIniFile_RemoveIniFile = 1
Const RemoveIniFile_FileName      = 2
Const RemoveIniFile_DirProperty   = 3
Const RemoveIniFile_Section       = 4
Const RemoveIniFile_Key           = 5
Const RemoveIniFile_Value         = 6
Const RemoveIniFile_Action        = 7
Const RemoveIniFile_Component_    = 8
Const RemoveRegistry_RemoveRegistry = 1
Const RemoveRegistry_Root           = 2
Const RemoveRegistry_Key            = 3
Const RemoveRegistry_Name           = 4
Const RemoveRegistry_Component_     = 5
Const ReserveCost_ReserveKey    = 1
Const ReserveCost_Component_    = 2
Const ReserveCost_ReserveFolder = 3
Const ReserveCost_ReserveLocal  = 4
Const ReserveCost_ReserveSource = 5
Const SelfReg_File_ = 1
Const SelfReg_Cost  = 2
Const ServiceControl_ServiceControl = 1
Const ServiceControl_Name           = 2
Const ServiceControl_Event          = 3
Const ServiceControl_Arguments      = 4
Const ServiceControl_Wait           = 5
Const ServiceControl_Component_     = 6
Const ServiceInstall_ServiceInstall = 1
Const ServiceInstall_Name           = 2
Const ServiceInstall_DisplayName    = 3
Const ServiceInstall_ServiceType    = 4
Const ServiceInstall_StartType      = 5
Const ServiceInstall_ErrorControl   = 6
Const ServiceInstall_LoadOrderGroup = 7
Const ServiceInstall_Dependencies   = 8
Const ServiceInstall_StartName      = 9
Const ServiceInstall_Password       =10
Const ServiceInstall_Arguments      =11
Const ServiceInstall_Component_     =12
Const ServiceInstall_Description    =13
Const Shortcut_Shortcut    = 1
Const Shortcut_Directory_  = 2
Const Shortcut_Name        = 3
Const Shortcut_Component_  = 4
Const Shortcut_Target      = 5
Const Shortcut_Arguments   = 6
Const Shortcut_Description = 7
Const Shortcut_Hotkey      = 8
Const Shortcut_Icon_       = 9
Const Shortcut_IconIndex   =10
Const Shortcut_ShowCmd     =11
Const Shortcut_WkDir       =12
Const Signature_Signature  = 1
Const Signature_FileName   = 2
Const Signature_MinVersion = 3
Const Signature_MaxVersion = 4
Const Signature_MinSize    = 5
Const Signature_MaxSize    = 6
Const Signature_MinDate    = 7
Const Signature_MaxDate    = 8
Const Signature_Languages  = 9
Const TextStyle_TextStyle = 1
Const TextStyle_FaceName  = 2
Const TextStyle_Size      = 3
Const TextStyle_Color     = 4
Const TextStyle_StyleBits = 5
Const TypeLib_LibID       = 1
Const TypeLib_Language    = 2
Const TypeLib_Component_  = 3
Const TypeLib_Version     = 4
Const TypeLib_Description = 5
Const TypeLib_Directory_  = 6
Const TypeLib_Feature_    = 7
Const TypeLib_Cost        = 8
Const UIText_Key  = 1
Const UIText_Text = 2
Const Upgrade_UpgradeCode    = 1
Const Upgrade_VersionMin     = 2
Const Upgrade_VersionMax     = 3
Const Upgrade_Language       = 4
Const Upgrade_Attributes     = 5
Const Upgrade_Remove         = 6
Const Upgrade_ActionProperty = 7
Const Verb_Extension_ = 1
Const Verb_Verb       = 2
Const Verb_Sequence   = 3
Const Verb_Command    = 4
Const Verb_Argument   = 5
Const Validation_Table       = 1
Const Validation_Column      = 2
Const Validation_Nullable    = 3
Const Validation_MinValue    = 4
Const Validation_MaxValue    = 5
Const Validation_KeyTable    = 6
Const Validation_KeyColumn   = 7
Const Validation_Category    = 8
Const Validation_Set         = 9
Const Validation_Description =10

'--------------------------------------------------------'
' Boolean control attribute to bit translation
'--------------------------------------------------------'
Dim dialogAttributes : dialogAttributes = Array("Hidden","Modeless","NoMinimize","SystemModal","KeepModeless","TrackDiskSpace","CustomPalette","RightToLeft","RightAligned","LeftScroll")
Dim   commonControlAttributes :   commonControlAttributes = Array("Hidden","Disabled","Sunken","Indirect","Integer","RightToLeft","RightAligned","LeftScroll")
Dim     textControlAttributes :     textControlAttributes = Array("Transparent","NoPrefix","NoWrap","FormatSize","UserLanguage")
Dim     editControlAttributes :     editControlAttributes = Array("Multiline", Empty, Empty, Empty,    Empty, "Password")
Dim progressControlAttributes : progressControlAttributes = Array("ProgressBlocks")
Dim   volumeControlAttributes :   volumeControlAttributes = Array("Removable","Fixed","Remote","CDROM","RAMDisk","Floppy","ShowRollbackCost")
Dim  listboxControlAttributes :  listboxControlAttributes = Array("Sorted",Empty    , Empty  , Empty, "UserLanguage")
Dim listviewControlAttributes : listviewControlAttributes = Array("Sorted",Empty    , Empty  , Empty, "FixedSize","Icon16","Icon32")
Dim comboboxControlAttributes : comboboxControlAttributes = Array("Sorted","ComboList")
Dim    radioControlAttributes :    radioControlAttributes = Array("Image","PushLike","Bitmap","Icon", "FixedSize","Icon16","Icon32",Empty,"HasBorder")
Dim   buttonControlAttributes :   buttonControlAttributes = Array("Image", Empty    ,"Bitmap","Icon", "FixedSize","Icon16","Icon32")
Dim     iconControlAttributes :     iconControlAttributes = Array("Image", Empty    , Empty  , Empty, "FixedSize","Icon16","Icon32")
Dim   bitmapControlAttributes :   bitmapControlAttributes = Array("Image", Empty    , Empty  , Empty, "FixedSize")
Dim checkboxControlAttributes : checkboxControlAttributes = Array( Empty, "PushLike","Bitmap","Icon", "FixedSize","Icon16","Icon32")

Dim commonControlAttributesInvert : commonControlAttributesInvert = msidbControlAttributesVisible + msidbControlAttributesEnabled
Dim dialogAttributesInvert : dialogAttributesInvert = msidbDialogAttributesVisible + msidbDialogAttributesModal + msidbDialogAttributesMinimize

'--------------------------------------------------------'
' Boolean permission to bit translation
'--------------------------------------------------------'
Dim standardPermissions : standardPermissions = Array("Delete","ReadPermission","ChangePermission","TakeOwnership","Synchronize")
Dim registryPermissions : registryPermissions = Array("Read",  "Write", "CreateSubkeys","EnumerateSubkeys","Notify","CreateLink")
Dim     filePermissions :     filePermissions = Array("Read",  "Write",   "Append",     "ReadExtendedAttributes","WriteExtendedAttributes","Execute",  Empty,       "ReadAttributes","WriteAttributes")
Dim   folderPermissions :   folderPermissions = Array("Read","CreateFile","CreateChild","ReadExtendedAttributes","WriteExtendedAttributes","Traverse","DeleteChild","ReadAttributes","WriteAttributes")
Dim  genericPermissions :  genericPermissions = Array("GenericAll","GenericExecute","GenericWrite","GenericRead")

'--------------------------------------------------------'
' Main execution
'--------------------------------------------------------'
Public installer      'As Installer
Public database       'As Database
Public fileStream     'As FileStream
Public manifestFolder 'As String
' XML document formatting state variables
Public tags(20), indentLevel, currentLine, tagOpen, elementText, hasChildren

Public lastDiskId     'As integer
Public featureDisplay 'As integer
Public dictView       'As Dictionary
Public fCreate, fVerbose, fOpenModel, fHelp, fNoQuit, fUIOnly, fNoUI, fNoSeqTables
Public fNoBinary, fUnicode, fNoOnError, fNoSumInfo, fProcessAll, fExportBinaries, fMergeModule
Public argIndex : argIndex = 0
Public productName, productAuthor
Public fileSystem
Public ModuleName, ModuleId, ModuleIdUnderscored, ModuleLanguage, ModuleVersion
Public dictComponents : Set dictComponents = CreateObject("Scripting.Dictionary")
Public dictDirectories : Set dictDirectories = CreateObject("Scripting.Dictionary")
    

	Dim databasePath : databasePath = GetArgument(extDatabase)
	If IsEmpty(databasePath) Or fHelp Then
		Wscript.Echo "--Convert a Windows Installer database to an XML installation manifest --" &_
			vbNewLine & "The 1st argument is path to the MSI database to query,  default extension: .msi" &_
			vbNewLine & "The 2nd argument is path to the XML manifest to create, default extension: .wim" &_
			vbNewLine & "The following case-insensitive option arguments may be specified in any order:" &_
			vbNewLine & "  /u or -u  output XML file in Unicode rather than ANSI" &_
			vbNewLine & "  /b or -b  binary elements not processed to XML bin.base64 (Binary and Icon)" &_
			vbNewLine & "  /s or -s  exclude standard sequence table actions, process Custom and dialogs" &_
			vbNewLine & "  /p or -p  exclude Package element generation rom summary information stream" &_
			vbNewLine & "  /n or -n  no UI elements processed" &_
			vbNewLine & "  /o or -o  only UI elements processed, add /b or -b to process Binary table" &_
			vbNewLine & "  /v or -v  verbose output to standard out, useful for debugging" &_
			vbNewLine & "  /k or -k  keep compiling after reporting an error, may produce invalid output" &_
			vbNewLine & "  /a or -a  process all tables, converting them into XML form" &_
			vbNewLine & "  /e or -e  debug option to turn off error handling to get better compile error" &_
			vbNewLine & "  /x or -x  export binary streams from Binary and Icon tables" &_
			vbNewLine & "  /m or -m  merge module" &_
			vbNewLine & "  /? or -?  show this help info, same as if no arguments supplied"
		Wscript.Quit 1
	End If

	' Connect to Windows Installer, create dictionary for views
	REM On Error Resume Next
	Set installer = Nothing
	Set installer = Wscript.CreateObject("WindowsInstaller.Installer") : CheckError
	Set dictView  = Wscript.CreateObject("Scripting.Dictionary") : CheckError
	Set fileSystem = Wscript.CreateObject("Scripting.FileSystemObject") : CheckError

	' Load database and create output manifest file
	Dim manifestPath : manifestPath = GetArgument(extManifest)
	Dim extraArg     : extraArg = GetArgument(Empty) ' extra call to pull in trailing flags
	If Not fNoOnError Then On Error Resume Next
    If IsEmpty(databasePath) Then Fail "Missing output manifest argument"
    Set database = installer.OpenDatabase(databasePath, msiOpenDatabaseModeReadOnly) : CheckError
    Set fileStream = fileSystem.CreateTextFile(manifestPath, OverwriteIfExist, fUnicode) : CheckError
    Dim manifestFile : Set manifestFile = fileSystem.GetFile(manifestPath)
    manifestFolder = manifestFile.ParentFolder.Path
    Set manifestFile = Nothing
	' print a warning that this tool isn't perfect
	WScript.Echo vbNewLine & _
	   vbNewLine & _
	   vbNewLine & "WARNING:  MsiToXml.vbs is not always up to date.  The XML produced may not " &_
	   vbNewLine & "compile properly and is almost certainly a suboptimal implementation for your" &_
	   vbNewLine & "MSI." &vbNewLine & _
	   vbNewLine & "   I suggest using MsiToXml once to get an initial draft of your MSI in XML" &_
	   vbNewLine & "then cleaning up the XML to compile well." &_
	   vbNewLine & "                                                      -- robmen via wiX" & vbNewLine

	indentLevel = 0
	ProcessProductElement
	Set database = Nothing
	fileStream.Close : CheckError
	Set fileStream = Nothing
	Wscript.Quit 0

'---------------------------------------------------------------------------------'
' Error handling and command-line parsing routines
'---------------------------------------------------------------------------------'
Function GetArgument(extension)
	If argIndex >= Wscript.Arguments.Count Then Exit Function
	Dim arg : arg = Wscript.Arguments(argIndex)
	argIndex = argIndex + 1
	Dim chFlag   : chFlag = AscW(arg)
	If (chFlag = AscW("/")) Or (chFlag = AscW("-")) Then
		chFlag = UCase(Right(arg, Len(arg)-1))
		If     chFlag = "C" Then
			fCreate = True
		ElseIf chFlag = "K" Then
			fNoQuit   = True
		ElseIf chFlag = "V" Then
			fVerbose = True
		ElseIf chFlag = "N" Then
			fNoUI    = True
		ElseIf chFlag = "O" Then
			fUIOnly  = True
		ElseIf chFlag = "B" Then
			fNoBinary = True
		ElseIf chFlag = "S" Then
			fNoSeqTables = True
		ElseIf chFlag = "P" Then
			fNoSumInfo= True
		ElseIf chFlag = "U" Then
			fUnicode = True
		ElseIf chFlag = "?" Then
			fHelp = True
		ElseIf chFlag = "E" Then
			fNoOnError = True
		ElseIf chFlag = "A" Then
			fProcessAll = True
		ElseIf chFlag = "X" Then
			fExportBinaries = True
		ElseIf chFlag = "M" Then
			fMergeModule = True
		Else
			Fail "Invalid option flag: " & arg
		End If
		GetArgument = GetArgument(extension)
	ElseIf chFlag = AscW("?") Then
		fHelp = True
	Else
		If Not IsEmpty(extension) Then
			Dim offset : offset = InStrRev(arg, "\")
			If offset = 0 Then offset = 1
			If InStr(offset, arg, ".", vbTextCompare) = 0 Then arg = arg & "." & extension
		End If
		GetArgument = arg
	End If
End Function

Sub CheckError
	Dim message, errRec
	If Err = 0 Then Exit Sub
	message = Err.Source & " " & Hex(Err) & ": " & Err.Description
	If Not installer Is Nothing Then
		Set errRec = installer.LastErrorRecord
		If Not errRec Is Nothing Then message = message & vbNewLine & errRec.FormatText
	End If
	Fail message
End Sub

Sub Fail(message)
	Wscript.Echo message
	If Not fNoQuit Then Wscript.Quit 2
End Sub

'--------------------------------------------------------'
' XML formatting functions
'--------------------------------------------------------'
Const lineWrap = 256

Sub NewElement(tag)
	If tagOpen Then Call CloseTag(Empty)
	currentLine = String(indentLevel * 3, " ") & "<" & tag
	tags(indentLevel) = tag
	indentLevel = indentLevel + 1
	tagOpen = Len(tag)
REM	hasChildren = False
End Sub

Function NeedsEscape(text)
	NeedsEscape = (InStr(text,"<") Or InStr(text,">") Or InStr(text,"&") Or InStr(text,"'") Or InStr(text,"""")) > 0
End Function

Function EscapeText(text)
	EscapeText = Replace(Replace(Replace(Replace(Replace(text,"&","&amp;"),"<","&lt;"),">","&gt;"),"'","&apos;"),"""","&quot;")
End Function


Sub AddAttribute(name, value) ' set value to Null to force empty string, else empty string cancels attribute
	Dim newText
	If Len(value) = 0 Then Exit Sub ' Null does not pass this test
	value = EscapeText(value)
	If IsEmpty(name) Then
		elementText = value
	Else
		newText = " " & name & "='" & value & "'" ' Null OK for value here
		If Len(currentLine) + Len(newText) > lineWrap Then
			fileStream.WriteLine(currentLine) : CheckError
			currentLine = String((indentLevel-1) * 3 + tagOpen + 1, " ")
		End If
		currentLine = currentLine & newText
	End If
End Sub


Sub AddEmptyAttribute(name) 
	
	Dim newText
	
	If IsEmpty(name) Then Exit Sub
	newText = " " & name & "=''"
	If Len(currentLine) + Len(newText) > lineWrap Then
		fileStream.WriteLine(currentLine) : CheckError
		currentLine = String((indentLevel-1) * 3 + tagOpen + 1, " ")
	End If
	currentLine = currentLine & newText
End Sub

Sub EndElement()
	Dim tag
	indentLevel = indentLevel - 1
	Call CloseTag(tags(indentLevel))
REM	hasChildren = True
End Sub

Function CloseTag(tag) ' not called directly, used by above functions
	If IsEmpty(currentLine) Then currentLine = String(indentLevel * 3, " ")
	If Not IsEmpty(tag) And tagOpen And IsEmpty(elementText) Then
		currentLine = currentLine & "/>" : CloseTag = True
	Else
		If tagOpen Then currentLine = currentLine & ">"
		If Not IsEmpty(elementText) Then
			currentLine = currentLine & elementText
			elementText = Empty
		End If
		If Not IsEmpty(tag) Then
REM			If hasChildren Then
REM				If Not IsEmpty(currentLine) fileStream.WriteLine(currentLine) : CheckError
REM				currentLine = String(indentLevel * 3, " ")
REM			End If
			currentLine = currentLine & "</" & tag & ">"
		End If
	End If
	tagOpen = 0
	fileStream.WriteLine(currentLine) : CheckError
	currentLine = Empty	
End Function

Sub SetElementText(text)
	If Len(text) = 0 Then
		elementText = Empty
	ElseIf (InStr(text,"<") Or InStr(text,">") Or InStr(text,"&") Or InStr(text,"'") Or InStr(text,""""))=0 Then
		elementText = text
	Else
		elementText = "<![CDATA[" & text & "]]>"
	End If
End Sub

Sub WritePartialText(text)
	elementText = text
	Call CloseTag(Empty)
End Sub

Function StripBraces(guid)
	If Len(guid) Then
		If Left(guid,1) <> "{" Or Right(guid,1) <> "}" Then Fail "GUID from database missing braces: " & guid
		StripBraces = Mid(guid, 2, Len(guid) - 2)
	End If
End Function

'--------------------------------------------------------'
' Non-UI database table processors
'--------------------------------------------------------'
Const propIgnore  = 0
Const propPackage = 1
Const propProduct = 2
Const propUI      = 3

Sub ProcessProductElement
    Dim ProcessedTables : ProcessedTables = Array("_Columns", _
                                                  "_Tables", _
                                                  "_Validation", _
                                                  "ActionText", _
                                                  "AdminExecuteSequence", _
                                                  "AdminUISequence", _
                                                  "AdvtExecuteSequence", _
                                                  "AppSearch", _
                                                  "Binary", _
                                                  "BindImage", _
                                                  "CheckBox", _
                                                  "Class", _
                                                  "ComboBox", _
                                                  "CompLocator", _
                                                  "Complus", _
                                                  "Component", _
                                                  "Condition", _
                                                  "Control", _
                                                  "ControlCondition", _
                                                  "ControlEvent", _
                                                  "CreateFolder", _
                                                  "CustomAction", _
                                                  "Dialog", _
                                                  "Directory", _
                                                  "DrLocator", _
                                                  "Environment", _
                                                  "Error", _
                                                  "EventMapping", _
                                                  "Extension", _
                                                  "Feature", _
                                                  "FeatureComponents", _
                                                  "File", _
                                                  "Font", _
                                                  "Icon", _
                                                  "InstallExecuteSequence", _
                                                  "InstallUISequence", _
                                                  "LaunchCondition", _
                                                  "ListBox", _
                                                  "ListView", _
                                                  "LockPermissions", _
                                                  "Media", _
                                                  "MsiAssembly", _
                                                  "MsiAssemblyName", _
                                                  "MsiFileHash", _
                                                  "ProgId", _
                                                  "Property", _
                                                  "RadioButton", _
                                                  "RegLocator", _ 
                                                  "Registry", _
                                                  "RemoveFile", _
                                                  "ReserveCost", _
                                                  "SelfReg", _
                                                  "ServiceControl", _
                                                  "ServiceInstall", _
                                                  "Shortcut", _
                                                  "Signature", _
                                                  "TextStyle", _
                                                  "UIText", _												   
                                                  "candle_DiskInfo", "candle_Files", "candle_Info")
                               
                                                     
	If fMergeModule Then
		ProcessModuleSignatureTable ModuleName, ModuleId, ModuleLanguage, ModuleVersion
		ModuleIdUnderscored = Replace( ModuleId, "-", "_" )
		NewElement "Module"
		AddAttribute "xmlns", "x-schema:mmschema.xml"
		AddAttribute "Name", ModuleName
		AddAttribute "Id", ModuleId
		AddAttribute "Language", ModuleLanguage
		AddAttribute "Version", ModuleVersion
	Else
		NewElement "Product"
		AddAttribute "xmlns", "x-schema:WiSchema.xml"
	End If
	
	If Not fUIOnly Then
		ProcessPropertyTable propPackage
		If Not fNoSumInfo Then
			ProcessSummaryInformation
		End If
		ProcessPropertyTable propProduct
		ProcessRegLocator
		ProcessCompLocator
		ProcessSignature
		ProcessLaunchConditionTable
		ProcessDirectoryTable Empty
		ProcessFeatureTable Empty
		ProcessMediaTable
		ProcessCustomActionTable
	End If
	If Not fNoUI Then
		NewElement "UI"
		ProcessPropertyTable propUI
		ProcessDialogTable
		ProcessControlGroupTable("RadioButton")
		ProcessControlGroupTable("ListBox")
		ProcessControlGroupTable("ListView")
		ProcessControlGroupTable("ComboBox")
		ProcessTextStyleTable
		ProcessUITextTable
		ProcessActionText
		ProcessErrorTable
		ProcessSequenceTable "InstallUISequence"
		ProcessSequenceTable "AdminUISequence"
		EndElement
	End If
	If fUIOnly Then
		ProcessBinaryTable "Binary", fNoBinary
	Else
		ProcessSequenceTable "InstallExecuteSequence"
		ProcessSequenceTable "AdminExecuteSequence"
		ProcessSequenceTable "AdvtExecuteSequence"
		ProcessBinaryTable "Binary", fNoBinary
		ProcessBinaryTable "Icon", fNoBinary
	End If
	If fProcessAll Then ProcessOtherTables ProcessedTables
	EndElement
End Sub

Sub ProcessSummaryInformation()
	Dim sumInfo : Set sumInfo = database.SummaryInformation(0) : CheckError
	If sumInfo.PropertyCount = 0 Then Exit Sub
	NewElement("Package")
	AddAttribute "Id",  StripBraces(sumInfo.Property(9)) ' PackageCode
	AddAttribute "Description",     sumInfo.Property(3)
	AddAttribute "Manufacturer",    sumInfo.Property(4)
	AddAttribute "InstallerVersion",sumInfo.Property(14)
	Dim platformAndLanguage : platformAndLanguage = Split(sumInfo.Property(7), ";")
	If UBound(platformAndLanguage) >= 0 Then AddAttribute "Platforms", platformAndLanguage(0)
	If UBound(platformAndLanguage)  = 1 Then AddAttribute "Languages", platformAndLanguage(1)
	Dim sourceFlags : sourceFlags = sumInfo.Property(15)
	If sourceFlags And 1 Then AddAttribute "ShortNames", "yes"
	If sourceFlags And 2 Then AddAttribute "Compressed", "yes"
	If sourceFlags And 4 Then AddAttribute "AdminImage", "yes"
	AddAttribute "Keywords",        sumInfo.Property(5)
	AddAttribute "Comments",        sumInfo.Property(6)
	AddAttribute "SummaryCodepage", sumInfo.Property(1)
	EndElement
End Sub


Sub ProcessPropertyTable(propSection)
	Dim table : table = "Property"
	If database.TablePersistent("Property") <> 1 Then Exit Sub
	Dim view : Set view = database.OpenView("SELECT * FROM `" & table & "`") : CheckError
	Dim row, propType, property, value
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		property = row.StringData (Property_Property)
		value    = row.StringData (Property_Value)
		Select Case (property)
		Case "UpgradeCode"     : propType = propPackage : value = StripBraces(value)
		Case "ProductCode"     : propType = propPackage : property = "Id" : value = StripBraces(value)
		Case "Manufacturer"    : propType = propPackage : property = "Manufacturer"
		Case "ProductName"     : propType = propPackage : property = "Name"
		Case "ProductLanguage" : propType = propPackage : property = "Language"
		Case "ProductVersion"  : propType = propPackage : property = "Version"
		Case "XMLSchema"       : propType = propIgnore ' should be we use this over again?
		Case "ErrorDialog"     : propType = propUI
		Case "DefaultUIFont"   : propType = propUI
		Case Else              : propType = propProduct
		End Select
		If propType = propSection Then
			If propType = propPackage Then
				AddAttribute property, value
			Else
				NewElement(table)
				elementText = StripModuleId(EscapeText(property))
				AddAttribute "Value", value
				EndElement
			End If
		End If
	Loop
End Sub


Sub PrintFileSearch (file_row)

	Dim signature, filename, minversion, maxversion
	Dim minsize, maxsize, mindate, maxdate, languages
	
	If Not file_row Is Nothing Then
		signature = file_row.StringData (1)
		filename = file_row.StringData (2)
		minversion = file_row.StringData (3)
		maxversion = file_row.StringData (4)
		minsize = file_row.StringData (5)
		maxsize = file_row.StringData (6)
		mindate = file_row.StringData (7)
		maxdate = file_row.StringData (8)
		languages = file_row.StringData (9)
		
		NewElement("FileSearch")
		elementText = StripModuleId(EscapeText(signature))
		AddAttribute "Name", filename
		AddAttribute "MinVersion", minversion
		AddAttribute "MaxVersion", maxversion
		AddAttribute "MinSize", minsize
		AddAttribute "MaxSize", maxsize
		AddAttribute "MinDate", mindate
		AddAttribute "MaxDate", maxdate
		AddAttribute "Languages", languages
		EndElement
	End If
End Sub


Sub ProcessRegLocator 

	Dim view, row
	Dim property, signature, root, key, name, valtype
	Dim file_view, file_row
	
	If database.TablePersistent("RegLocator") <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM AppSearch, RegLocator WHERE AppSearch.Signature_=RegLocator.Signature_") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		property = row.StringData (1)
		signature = row.StringData (2)
		Select Case (row.IntegerData (4))
			Case  msidbRegistryRootClassesRoot 	: root = "HKCR"
			Case  msidbRegistryRootCurrentUser 	: root = "HKCU"
			Case  msidbRegistryRootLocalMachine : root = "HKLM"
			Case  msidbRegistryRootUsers 		: root = "HKU"
			Case Else : Fail "Unknown Registry root in RegLocator: " & row.IntegerData(4)
		End Select
		key = row.StringData (5)
		name = row.StringData (6)
		Select Case (row.IntegerData (7))
			Case msidbLocatorTypeDirectory 	: valtype = "directory"
			Case msidbLocatorTypeFileName 	: valtype = "file"
			Case msidbLocatorTypeRawValue	: valtype = "registry"
			Case Else : Fail "Unknown Registry value type in RegLocator: " & row.IntegerData(7)
		End Select
		
		Set file_view = database.OpenView("SELECT * FROM Signature WHERE Signature='" & signature & "'") : CheckError
		file_view.Execute : CheckError
		Set file_row = file_view.Fetch : CheckError
		
		NewElement("Property")
			elementText = StripModuleId(EscapeText(property))
			NewElement("RegistrySearch")
				elementText = StripModuleId(EscapeText(signature))
				AddAttribute "Root", root
				AddAttribute "Key", key
				AddAttribute "Name", name
				AddAttribute "Type", valtype
				
				If Not file_row Is Nothing Then
					PrintFileSearch (file_row)
				End If
			EndElement
		EndElement
	Loop
End Sub


Sub ProcessCompLocator 

	Dim view, row
	Dim property, signature, id, keypathtype
	Dim file_view, file_row
	
	If database.TablePersistent("CompLocator") <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM AppSearch, CompLocator WHERE AppSearch.Signature_=CompLocator.Signature_") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		property = row.StringData (1)
		signature = row.StringData (2)
		id = StripBraces(row.StringData (4))
		Select Case (row.IntegerData (5))
			Case msidbLocatorTypeDirectory 	: keypathtype = "directory"
			Case msidbLocatorTypeFileName 	: keypathtype = "file"
			Case Else : Fail "Unknown key path type in CompLocator: " & row.IntegerData(5)
		End Select
		
		Set file_view = database.OpenView("SELECT * FROM Signature WHERE Signature='" & signature & "'") : CheckError
		file_view.Execute : CheckError
		Set file_row = file_view.Fetch : CheckError
		
		NewElement("Property")
			elementText = StripModuleId(EscapeText(property))
			NewElement("ComponentSearch")
				elementText = EscapeText(signature)
				AddAttribute "Id", id
				AddAttribute "Type", keypathtype
				
				If Not file_row Is Nothing Then
					PrintFileSearch (file_row)
				End If
			EndElement
		EndElement
	Loop
End Sub


Function ProcessDrLocator (signature, file_row) 

	Dim view, row
	Dim parent, path, depth
	Dim ndirs, i
	
	If database.TablePersistent("DrLocator") <> 1 Then Exit Function
	Set view = database.OpenView("SELECT * FROM DrLocator WHERE Signature_='" & signature & "'") : CheckError
	view.Execute : CheckError
	Set row = view.Fetch : CheckError
	If Not row Is Nothing Then
	
		parent = row.StringData (2)
		If Not IsEmpty(parent) Then
			ndirs = ProcessDrLocator(parent, Nothing)
		End If
		path = row.StringData (3)
		depth = row.StringData (4)
		NewElement("DirectorySearch")
		elementText = StripModuleId(EscapeText(signature))
		AddAttribute "Path", path
		AddAttribute "Depth", depth
		If Not file_row Is Nothing Then
		
			PrintFileSearch (file_row)
			For i=0 To ndirs
				EndElement
			Next
		Else
			ProcessDrLocator = ndirs + 1
		End If
	Else
		ProcessDrLocator = 0
	End If
End Function


Sub ProcessSignature 

	Dim view, row
	Dim property, signature
	
	If database.TablePersistent("Signature") <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM Signature, AppSearch WHERE AppSearch.Signature_=Signature.Signature") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		property = row.StringData (10)
		signature = row.StringData (1)
		NewElement("Property")
		elementText = StripModuleId(EscapeText(property))
		ProcessDrLocator signature, row
		EndElement
	Loop
End Sub


'kwhitt - Processes every table not already processed, converting each of them to a CustomTable element
Sub ProcessOtherTables(usedTableNameArray)
	Dim databaseView : Set databaseView = database.OpenView("SELECT * FROM `_Tables` ORDER BY Name") : CheckError
	Dim columnView, tableView					'Views 
	Dim table, row, column, validateInfo		'Record
	Dim colNames, colTypes						'Record
	Dim tablename, colType, category, chType	'String
	Dim fTableProcessed, fPrimaryKey			'Boolean
	Dim index, numCols, colCount				'Integer
	Dim columnNameArray(200)					'String	
	Dim params									'Record(1) of String
	Dim	keys									'Record(32) of String
	Dim numKeyCols								'Integer
	Dim numArrayItems : numArrayItems = UBound(usedTableNameArray,1)
	databaseView.Execute : CheckError
	
	'Get all the data out of each table
	Do 
		Set	table = databaseView.Fetch : CheckError
		If table Is Nothing Then Exit Do

		tableName = table.StringData(1) '1-based - name of table

		'Ensure table hasn't already been processed
		fTableProcessed = False
		For index = LBound(usedTableNameArray,1) To UBound(usedTableNameArray,1)
			If tableName = usedTableNameArray(index) Then 
				fTableProcessed = True
				Exit For
			End If
		Next

		If fTableProcessed = False Then
		
			Set tableView = database.OpenView("SELECT * FROM `" & tableName & "`") : CheckError			
			tableView.Execute : CheckError
			Set row = tableView.Fetch : CheckError
			If Not (row Is Nothing) Then
			
			    NewElement("CustomTable")
    			elementText = EscapeText(tableName)
    			Set keys = database.PrimaryKeys(tableName) : CheckError
    			'UNDONE: need 'op' param?
    			'Get all the column text names - 1-based
    			numCols = 0
    			Set columnView = database.OpenView("SELECT * FROM `_Columns` WHERE `Table` = '" & tableName & "'") : CheckError
    			columnView.Execute : CheckError
    
    			
    			'Get all the column info
    			Set colNames = tableView.ColumnInfo(0)
    			Set colTypes = tableView.ColumnInfo(1)
    			For index = 1 To colNames.FieldCount
    
    				NewElement("Column")
    				elementText = colNames.StringData(index)
    				colType = colTypes.StringData(index)
    				chType = Left(colType,1)
    				
    				'Nullable attribute
    				If UCase(chType) = chType Then AddAttribute "Nullable", "yes"
    
    				'Localizable attribute
    				If LCase(chType) = "l" Then AddAttribute "Localizable", "yes"
    
    				'Type Attribute
    				Select Case LCase(chType)
    				Case "s", "l", "g" 
    					AddAttribute "Type", "string"
    				Case "i", "j"
    					AddAttribute "Type", "int"
    				Case "v" 
    					AddAttribute "Type", "binary"
    				End Select
    
    				'Width Attribute
    				If chType <> "v" Then AddAttribute "Width", (Right(colType,Len(colType)-1))
    					
    				'PrimaryKeys attribute
    				fPrimaryKey = false
    				For colCount = 1 to keys.FieldCount
    					If keys.StringData(colCount) = elementText Then
    						fPrimaryKey = true
    						Exit For
    					End If
    				Next
    				If fPrimaryKey = true then 
    					AddAttribute "PrimaryKey", "yes"
    				End If
    
    				EndElement 'Column
    			Next
    			'Get all the info from the current row
    			Do 
    				If row Is Nothing Then Exit Do
    				NewElement("Row")
    				For colCount = 1 to colNames.FieldCount
    					If row.StringData(colCount) <> "" Then
    						NewElement("Data")
    						elementText = EscapeText(row.StringData(colCount))
    						AddAttribute "Column", colNames.StringData(colCount)
    						EndElement 'Data
    					End If
    				Next
    				EndElement 'row
    				Set row = tableView.Fetch : CheckError
    			Loop
    			EndElement 'customtable
    		End If
		End If
	Loop
End Sub	

Sub ProcessLaunchConditionTable()
	Dim table : table = "LaunchCondition"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Dim row
	Dim view : Set view = database.OpenView("SELECT * FROM `" & table & "`") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement("Condition")
			AddAttribute "Message", row.StringData(LaunchCondition_Description)
			SetElementText          row.StringData(LaunchCondition_Condition)
		EndElement
	Loop
End Sub

Sub ProcessConditionTable(feature)
	Dim table : table = "Condition"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Dim row, params
	Set params = installer.CreateRecord(1)
	Dim view : Set view = database.OpenView("SELECT * FROM `" & table & "` WHERE `Feature_` = ?") : CheckError
	params.StringData(1) = feature
	view.Execute params : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement(table)
			AddAttribute "Level", row.IntegerData(Condition_Level)
			SetElementText        row.StringData(Condition_Condition)
		EndElement
	Loop
End Sub

Sub ProcessFeatureComponentTable(feature)
	Dim table : table = "FeatureComponents"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Dim row, params, component
	Set params = installer.CreateRecord(1)
	Dim view : Set view = database.OpenView("SELECT `Component_` FROM `" & table & "` WHERE `Feature_` = ?") : CheckError
	params.StringData(1) = feature
	view.Execute params : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		component = row.StringData(1)
		NewElement("Component")
			SetElementText        component
REM !! ProcessShortcutTable feature, component, Empty
REM !! ProcessPublishComponentTable feature, component
		ProcessClassTable feature, component 
		ProcessExtensionTable feature, component, Empty
		ProcessMsiAssemblyTable component, feature
		EndElement
	Loop
End Sub

Sub ProcessClassTable(feature, component)
	Dim row, view, view2, table, defProgId, classId
	table = "Class"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM `" & table & "` WHERE `Feature_`='" & feature & "' AND `Component_`='" & component & "'") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement(table)
		AddAttribute "Context",     row.StringData (Class_Context)
		AddAttribute "Description", row.StringData (Class_Description)
		AddAttribute "AppId", StripBraces(row.StringData (Class_AppId_))
		AddAttribute "FileTypeMask",row.StringData (Class_FileTypeMask)
		AddAttribute "Icon",        row.StringData (Class_Icon_)
		If Not row.IsNull(Class_IconIndex) Then AddAttribute "IconIndex", row.IntegerData(Class_IconIndex)
		AddAttribute "Handler",     row.StringData (Class_DefInprocHandler)
		AddAttribute "Argument",    row.StringData (Class_Argument)
		defProgId     =             row.StringData (Class_ProgId_Default)
		classId       =             row.StringData (Class_CLSID)
		elementText   = StripBraces(classId)
		If row.IntegerData(Class_Attributes) And msidbClassAttributesRelativePath Then
			AddAttribute "RelativePath", "yes"
		End If
		ProcessProgIdTable feature, component, classId, defProgId
REM   <element type='TypeLib' minOccurs = '0' maxOccurs='1'/>
		EndElement
	Loop
End Sub

Sub ProcessProgIdTable(feature, component, classId, defProgId) ' feature and component used for child Extension elements
	Dim row, view, table, query, query1, query2, progId
	table = "ProgId"
	If database.TablePersistent(table) <> 1 Then
		If Len(defProgId) Then Fail "Default ProgId for class " & classId & ", but ProgId table not present"
		Exit Sub
	End If
	query1 = "SELECT * FROM `ProgId` WHERE `Class_`='" & classId & "'"
	If IsEmpty(classId) Then        ' looking for version-independent ProgId, no classId allowed
		query1 = "SELECT * FROM `ProgId` WHERE `Class_`= NULL AND `ProgId_Parent`='" & defProgId & "'"
	ElseIf Len(defProgId) > 0 Then  ' looking for defProgId first, then others belonging to class
		query2 = query1 & " AND `ProgId`<>'" & defProgId & "'"
		query1 = query1 & " AND `ProgId`='"  & defProgId & "'"
	End If                          ' else no defProgId, looking for all belonging to class
	Set view = database.OpenView(query1) : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch
		If row Is Nothing Then
			If Not IsEmpty(query2) Then Fail "Default ProgId for class " & classId & " not present in ProgId table: " & defProgId
			Exit Do
		End If
		NewElement(table)
		progId      = row.StringData (ProgId_ProgId)
		elementText = progId
		AddAttribute "Description", row.StringData (ProgId_Description)
		If Not IsEmpty(classId) Then
			AddAttribute "Icon",    row.StringData (ProgId_Icon_)
			If Not row.IsNull(ProgId_IconIndex) Then AddAttribute "IconIndex", row.IntegerData(ProgId_IconIndex)
			ProcessExtensionTable feature, component, progId
			ProcessProgIdTable feature, component, Empty, progId
		End If
		EndElement
		If Not IsEmpty(query2) Then
			Set view = database.OpenView(query2) : CheckError
			view.Execute : CheckError
			query2 = Empty
		End If
	Loop
End Sub

Sub ProcessExtensionTable(feature, component, progId)
	Dim row, view, table, query
	table = "Extension"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	query = "SELECT * FROM `Extension` WHERE `Feature_`='" & feature & "' AND `Component_`='" & component & "' AND `ProgId_`="
	If IsEmpty(progId) Then query = query & "NULL" Else query = query & "'" & progId & "'"
	Set view = database.OpenView(query) : CheckError
	view.Execute
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement(table)
		AddAttribute "ContentType", row.StringData(Extension_MIME_)
		elementText = StripModuleId(row.StringData(Extension_Extension))
REM ~!! child MIME elements
REM ~!! child verb elements
		EndElement
	Loop
End Sub

Sub ProcessFeatureTable(parent)
	Dim table : table = "Feature"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Dim row, params, display, feature, bits
	Set params = installer.CreateRecord(1)
	Dim view : Set view = database.OpenView("SELECT * FROM `" & table & "` WHERE `Feature_Parent` = ? ORDER BY Display") : CheckError
	params.StringData(1) = parent
	view.Execute params : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		feature = row.StringData (Feature_Feature)
		If row.IsNull(Feature_Display) Then
			display = 0
		Else
			display = row.IntegerData(Feature_Display)
		End If
		If display = 0 Then
			display = "hidden"
		ElseIf (display And 1) = 1 Then
			display = "expand"
		Else
			display = Empty ' "collapse" is the default, handled when compiled
		End If
		bits    = row.IntegerData(Feature_Attributes)
		NewElement(table)
			elementText =                         feature
			AddAttribute "Title",                 row.StringData(Feature_Title)
			AddAttribute "Description",           row.StringData(Feature_Description)
			AddAttribute "Display",               display
			AddAttribute "Level",                 row.IntegerData(Feature_Level)
			AddAttribute "ConfigurableDirectory", row.StringData(Feature_Directory_)
			If bits And msidbFeatureAttributesFavorSource       Then AddAttribute "InstallDefault", "source"
			If bits And msidbFeatureAttributesFavorAdvertise    Then AddAttribute "TypicalDefault", "advertise"
			If bits And msidbFeatureAttributesFollowParent      Then AddAttribute "FollowParent",   "yes"
			If bits And msidbFeatureAttributesUIDisallowAbsent  Then AddAttribute "Absent",         "disallow"
			If bits And msidbFeatureAttributesDisallowAdvertise Then
				AddAttribute "AllowAdvertise", "no"
			ElseIf bits And msidbFeatureAttributesNoUnsupportedAdvertise Then
				AddAttribute "AllowAdvertise", "system"
			End If
			ProcessConditionTable feature
			ProcessFeatureComponentTable feature
			ProcessFeatureTable feature
		EndElement
	Loop
End Sub

Sub ProcessDirectoryTable(parent)
	Dim table : table = "Directory"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Dim row, params, query, bits, newParent, directory, names, destNames, sourceNames
	query = "SELECT * FROM `Directory`"
	If Not IsEmpty(parent) Then query = query & " WHERE `Directory_Parent` = '" & parent & "'"
	Dim view : Set view = database.OpenView(query) : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		directory = row.StringData(Directory_Directory) 
		If NOT dictDirectories.Exists(directory) Then
    		newParent = row.StringData(Directory_Directory_Parent)
    		If Not IsEmpty(parent) Or directory = newParent Or Len(newParent) = 0 Then
    		
    			NewElement(table)
    				elementText = StripModuleId( directory )
    				names = Split(row.StringData(Directory_DefaultDir), ":")
    				destNames = Split(names(0),"|")
    				AddAttribute "Name", destNames(0)
    				If UBound(destNames) = 1 Then AddAttribute "LongName", destNames(1)
    				If UBound(names) = 1 Then
    					sourceNames = Split(names(1),"|")
    					AddAttribute "SourceName", sourceNames(0)
    					If UBound(sourceNames) = 1 Then AddAttribute "LongSource", sourceNames(1)
    				End If
    				ProcessComponentTable directory
    				ProcessDirectoryTable directory
    				If fMergeModule=true AND directory = "TARGETDIR" Then
    				    ProcessOrphanedComponents
    				End If
    			EndElement
    			dictDirectories.Add directory, 1
    		End If
    	End If
	Loop
End Sub

Sub ProcessEnvironmentTable(component)

    Dim view, row, name, value, position
    
    If database.TablePersistent("Environment") = 1 Then
        Set view = database.OpenView("SELECT * FROM Environment WHERE `Component_` = '" & component & "'") : CheckError
        view.Execute : CheckError
        Do
            Set row = view.Fetch : CheckError
            If row Is Nothing Then Exit Do
            NewElement("Environment")
            elementText = row.StringData (Environment_Environment)
            name = row.StringData (Environment_Name)
            If InStr(1, name, "!") > 0 Then 
                AddAttribute "Action", "remove"
            ElseIf InStr(1, name, "=") > 0 Then 
                AddAttribute "Action", "create"
            Else
                AddAttribute "Action", "set"
            End If
            If InStr(1, name, "*") > 0 Then AddAttribute "System", "yes"
            If InStr(1, name, "-") = 0 Then AddAttribute "Permanent", "yes"
            AddAttribute "Name", Replace(Replace(Replace(Replace(Replace(name, "=", ""), "+", ""), "-", ""), "*", ""), "!", "")
            value = row.StringData (Environment_Value)
            position = InStr(1, value, "[~]")
            If position > 0 Then 
                If position = 1 Then 
                    AddAttribute "Part", "last"
                    value = Replace(value, "[~];", "")
                Else
                    AddAttribute "Part", "first"
                    value = Replace(value, ";[~]", "")
                End If
            End If
            AddAttribute "Value", value
            EndElement
        Loop
    End If
End Sub

Sub ProcessMsiAssemblyTable(component, feature)

    Dim view, row, attributes, propertyView, propertyRow
    
    If database.TablePersistent("MsiAssembly") = 1 Then
        Set view = database.OpenView("SELECT * FROM MsiAssembly WHERE `Component_` = '" & component & "' AND (Feature_='" & feature & "' OR Feature_='')") : CheckError
        view.Execute : CheckError
        Do
            Set row = view.Fetch : CheckError
            If row Is Nothing Then Exit Do
            NewElement("Assembly")
            AddAttribute "Manifest", row.StringData (MsiAssembly_File_Manifest)
            AddAttribute "Application", row.StringData (MsiAssembly_File_Application)
            attributes = row.IntegerData (MsiAssembly_Attributes)
            If attributes = 1 Then
                AddAttribute "Type", "win32"
            Else
                AddAttribute "Type", ".net"
            End If
                Set propertyView = database.OpenView("SELECT * FROM MsiAssemblyName WHERE `Component_` = '" & component & "'") : CheckError
                propertyView.Execute : CheckError
                Do
                    Set propertyRow = propertyView.Fetch : CheckError
                    If propertyRow Is Nothing Then Exit Do
                    NewElement("Property")
                        AddAttribute "Value", propertyRow.StringData (MsiAssemblyName_Value)
                        SetElementText propertyRow.StringData (MsiAssemblyName_Name)
                    EndElement
                Loop
            EndElement
        Loop
    End If
End Sub

Sub ProcessRemoveFileTable (component)

    Dim view, row, mode, modestr
    
    If database.TablePersistent("RemoveFile") = 1 Then
        Set view = database.OpenView("SELECT * FROM RemoveFile WHERE `Component_` = '" & component & "'") : CheckError
        view.Execute : CheckError
        Do
            Set row = view.Fetch : CheckError
            If row Is Nothing Then Exit Do
            NewElement("RemoveFile")
                AddAttribute "Directory", StripModuleId(row.StringData (RemoveFile_DirProperty))
                AddAttribute "Name", row.StringData (RemoveFile_FileName)
                mode = row.IntegerData (RemoveFile_InstallMode)
                Select Case mode
                    Case msidbRemoveFileInstallModeOnInstall : modestr = "install"
                    Case msidbRemoveFileInstallModeOnRemove  : modestr = "uninstall"
                    Case msidbRemoveFileInstallModeOnBoth    : modestr = "both"
                    Case Else : Fail "Unknown install mode in RemoveFileTable: " & mode
                End Select
                AddAttribute "On", modestr
                SetElementText StripModuleId(row.StringData (RemoveFile_FileKey))
            EndElement
        Loop
    End If
End Sub


Sub ProcessReserveCostTable (component)

    Dim view, row
    
    If database.TablePersistent("ReserveCost") = 1 Then
        Set view = database.OpenView("SELECT * FROM ReserveCost WHERE `Component_` = '" & component & "'") : CheckError
        view.Execute : CheckError
        Do
            Set row = view.Fetch : CheckError
            If row Is Nothing Then Exit Do
            NewElement("ReserveCost")
                AddAttribute "Directory", row.StringData (ReserveCost_ReserveFolder)
                AddAttribute "RunLocal", row.IntegerData (ReserveCost_ReserveLocal)
                AddAttribute "RunFromSource", row.IntegerData (ReserveCost_ReserveSource)
                SetElementText row.StringData (ReserveCost_ReserveKey)
            EndElement
        Loop
    End If
End Sub

Sub ProcessShortcutTable (component)

    Dim view, row, name, name_array, show, showcmd

    If database.TablePersistent("Shortcut") <> 1 Then Exit Sub
    Set view = database.OpenView("SELECT * FROM Shortcut WHERE `Component_` = '" & component & "'") : CheckError
    view.Execute : CheckError
    Do
        Set row = view.Fetch : CheckError
        If row Is Nothing Then Exit Do
        NewElement("Shortcut")
            AddAttribute "Directory", StripModuleId(row.StringData (Shortcut_Directory_))
            name = row.StringData (Shortcut_Name)
            name_array = Split(name, "|", 2, 1)
            AddAttribute "Name", name_array(0)
            If UBound(name_array) = 1 Then
                AddAttribute "LongName", name_array(1)
            End If
            AddAttribute "Target", StripModuleId(row.StringData (Shortcut_Target))
            AddAttribute "Description", row.StringData (Shortcut_Description)
            AddAttribute "Arguments", StripModuleId(row.StringData (Shortcut_Arguments))
            AddAttribute "Hotkey", row.StringData (Shortcut_Hotkey)
            AddAttribute "Icon", row.StringData (Shortcut_Icon_)
            AddAttribute "IconIndex", row.IntegerData (Shortcut_IconIndex)
            show = row.IntegerData (Shortcut_ShowCmd)
            Select Case show
                Case SW_SHOWNORMAL      : showcmd = "normal"
                Case SW_SHOWMAXIMIZED   : showcmd = "maximized"
                Case SW_SHOWMINNOACTIVE : showcmd = "maximized"
                Case Else showcmd = "normal"
            End Select
            AddAttribute "Show", showcmd
            AddAttribute "WorkingDirectory", StripModuleId(row.StringData (Shortcut_WkDir))
            SetElementText StripModuleId(row.StringData (Shortcut_Shortcut))
        EndElement
    Loop
End Sub

Sub ProcessComponentTable(directory)
	Dim row, component, bits, condition, keyPath, regKeyPath, odbcKeyPath, fileKeyPath, view, view2, table, id
	table = "Component"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM `" & table & "` WHERE `Directory_` = '" & directory & "'") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		id = row.StringData (Component_ComponentId)
		If NOT dictComponents.Exists(id) Then
    		NewElement(table)
    		component        = row.StringData (Component_Component)
    		condition        = Trim(row.StringData (Component_Condition))
    		AddAttribute "Id", StripBraces(id)
    		bits             = row.IntegerData(Component_Attributes)
    		keyPath          = row.StringData (Component_KeyPath)
    		If Len(keyPath) = 0 Then ' no key path, force "no" to all children to prevent default on compile
    			regKeyPath = ""
    			fileKeyPath = ""
    			odbcKeyPath = ""
    		ElseIf bits And msidbComponentAttributesRegistryKeyPath Then
    			regKeyPath  = keyPath
    		ElseIf bits And msidbComponentAttributesODBCDataSource  Then
    			odbcKeyPath = keyPath
    		Else
    			fileKeyPath = keyPath
    		End If
    		If bits And msidbComponentAttributesSharedDllRefCount Then AddAttribute "SharedDllRefCount", "yes"
    		If bits And msidbComponentAttributesPermanent         Then AddAttribute "Permanent",      "yes"
    		If bits And msidbComponentAttributesTransitive        Then AddAttribute "Transitive",     "yes"
    		If bits And msidbComponentAttributesNeverOverwrite    Then AddAttribute "NeverOverwrite", "yes"
    		If bits And msidbComponentAttributesOptional          Then
    			AddAttribute "Location", "either"
    		ElseIf bits And msidbComponentAttributesSourceOnly    Then
    			AddAttribute "Location", "source"
    		End If
    		If database.TablePersistent("Complus") = 1 Then
    			Set view2 = database.OpenView("SELECT * FROM `Complus` WHERE `Component_` = '" & component & "'") : CheckError
    			view2.Execute
    			Set row = view2.Fetch
    			If Not row Is Nothing Then AddAttribute "ComPlusFlags", row.IntegerData(Complus_ExpType)
    		End If
    		elementText = StripModuleId(component)
    		If Len(condition) Then
    			NewElement("Condition")
    			SetElementText condition
    			EndElement
    		End If
    		ProcessFileTable           component, filekeyPath
    		ProcessCreateFolderTable   component, directory
    		ProcessRegistryTable       component, regkeyPath
    		ProcessServiceControlTable component
    		ProcessServiceInstallTable component
    		ProcessEnvironmentTable    component
    		ProcessRemoveFileTable     component
    		ProcessReserveCostTable    component
    		ProcessShortcutTable       component
    		EndElement
    		dictComponents.Add id, 1
    	End If
	Loop
End Sub

Sub ProcessFileTable(component, keyPath)
	Dim row, names, sequence, bits, fileId, view, view2, viewMedia, rowMedia, table, value
	table = "File"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM `" & table & "` WHERE `Component_` = '" & component & "' ORDER BY `Sequence`") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement(table)
		fileId               =   row.StringData (File_File)
		names = Split(row.StringData(File_FileName), "|")
		AddAttribute "Name", names(0)
		If UBound(names) = 1 Then AddAttribute "LongName", names(1)
		AddAttribute "FileSize", row.IntegerData(File_FileSize)
		AddAttribute "Version",  row.StringData(File_Version)
		AddAttribute "Language", row.StringData(File_Language)
		sequence             =   row.IntegerData(File_Sequence)
		If sequence > 1     Then AddAttribute "Sequence", sequence
		If Not IsEmpty(keyPath) Then
			If fileId = keyPath Then AddAttribute "KeyPath", "yes"
			If Len(keyPath) = 0 Then AddAttribute "KeyPath", "no"
		End If
		bits                 =   row.IntegerData(File_Attributes)
		If bits And msidbFileAttributesReadOnly      Then AddAttribute "ReadOnly"     , "yes"
		If bits And msidbFileAttributesHidden        Then AddAttribute "Hidden"       , "yes"
		If bits And msidbFileAttributesSystem        Then AddAttribute "System"       , "yes"
		If bits And msidbFileAttributesVital         Then AddAttribute "Vital"        , "yes"
		If bits And msidbFileAttributesChecksum      Then AddAttribute "Checksum"     , "yes"
		If bits And msidbFileAttributesPatchAdded    Then AddAttribute "PatchAdded"   , "yes"
		If bits And msidbFileAttributesNoncompressed  Then AddAttribute "Compressed", "no"
		If bits And msidbFileAttributesCompressed    Then AddAttribute "Compressed"   , "yes"

		'Add Appropriate DiskId based on Media
		If database.TablePersistent("Media") = 1 Then 
			Set viewMedia = database.OpenView("SELECT * FROM `Media` ORDER BY `DiskId`") : CheckError
			viewMedia.Execute : CheckError
			Do 
				Set rowMedia = viewMedia.Fetch : CheckError
				If rowMedia Is Nothing Then Exit Do
				If rowMedia.IntegerData(Media_LastSequence) >= CLng(sequence) Then 
					AddAttribute "DiskId", rowMedia.IntegerData(Media_DiskId)
					Exit Do
				End If
			Loop
		End If

		If database.TablePersistent("BindImage") = 1 Then
			Set view2 = database.OpenView("SELECT * FROM `BindImage` WHERE `File_` = '" & fileId & "'") : CheckError
			view2.Execute
			Set row = view2.Fetch
			If Not row Is Nothing Then
				value = row.StringData(BindImage_Path)
				If Len(value) = 0 Then value = Null
				AddAttribute "BindPath", value
			End If
		End If
		If database.TablePersistent("SelfReg") = 1 Then
			Set view2 = database.OpenView("SELECT * FROM `SelfReg` WHERE `File_` = '" & fileId & "'") : CheckError
			view2.Execute
			Set row = view2.Fetch
			If Not row Is Nothing Then AddAttribute "SelfRegCost", row.IntegerData(SelfReg_Cost)
		End If
		If database.TablePersistent("Font") = 1 Then
			Set view2 = database.OpenView("SELECT * FROM `Font` WHERE `File_` = '" & fileId & "'") : CheckError
			view2.Execute
			Set row = view2.Fetch
			If Not row Is Nothing Then
				If row.IsNull(Font_FontTitle) Then
					AddAttribute "TrueType", "yes"
				Else
					AddAttribute "FontTitle", row.StringData(Font_FontTitle)
				End If
			End If
		End If
		elementText = StripModuleId(fileId)
		ProcessLockPermissionsTable fileId, "File"
REM   <element type='Shortcut'       minOccurs='0' maxOccurs='*'/><!-- Non-advertised shortcut, Target is preset to this file -->
REM   <element type='CopyFile'       minOccurs='0' maxOccurs='1'/><!-- to DuplicateFile table -->
REM   <element type='ODBCDriver'     minOccurs='0' maxOccurs='*'/>
REM   <element type='ODBCTranslator' minOccurs='0' maxOccurs='*'/>
REM   <element type='Patch'          minOccurs='0' maxOccurs='*'/><!-- to Patch table -->
		EndElement
	Loop
End Sub

Sub ProcessRegistryTable(component, keyPath)
	Dim row, names, sequence, bits, regId, view, view2, table, root
	table = "Registry"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM `" & table & "` WHERE `Component_` = '" & component & "'") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
REM !! need to skip rows used as Attributes for Class element, such as ThreadingModel, TypeLib and Version...
REM If key starts with HKCR\CLSID\ then pull off class ID and check to see if it's in Class table
		NewElement(table)
		regId               =   row.StringData (Registry_Registry)
		Select Case(row.IntegerData(Registry_Root))
			Case -1 : root = "HKMU"
			Case  0 : root = "HKCR"
			Case  1 : root = "HKCU"
			Case  2 : root = "HKLM"
			Case  3 : root = "HKU"
			Case Else : Fail "Unknown Registry root type: " & row.IntegerData(Registry_Root)
		End Select
		AddAttribute "Root",  root
		AddAttribute "Key",   row.StringData(Registry_Key)
		AddAttribute "Name",  row.StringData(Registry_Name)
		AddAttribute "Value", StripModuleId(row.StringData(Registry_Value))
		If Not IsEmpty(keyPath) Then
			If regId  = keyPath Then AddAttribute "KeyPath", "yes"
			If Len(keyPath) = 0 Then AddAttribute "KeyPath", "no"
		End If
		elementText = StripModuleId(regId)
		ProcessLockPermissionsTable regId, "Registry"
		EndElement
	Loop
End Sub

Sub ProcessCreateFolderTable(component, directory)
	Dim row, view, table
	table = "CreateFolder"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM `" & table & "` WHERE `Component_` = '" & component & "'") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement(table)
		If row.StringData(CreateFolder_Directory_) <> directory Then AddAttribute "Directory", row.StringData(CreateFolder_Directory_)
		ProcessLockPermissionsTable directory, "CreateFolder" 
REM   <element type='Shortcut'     minOccurs='0' maxOccurs='1'/>
		EndElement
	Loop
End Sub

Sub ProcessServiceControlTable(component)
	Dim row, servId, bits, view, table
	table = "ServiceControl"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM `" & table & "` WHERE `Component_` = '" & component & "'") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement(table)
		elementText = StripModuleId(row.StringData (ServiceControl_ServiceControl))
		AddAttribute "Name",  row.StringData(ServiceControl_Name)
		bits = row.IntegerData(ServiceControl_Event)

		If (bits And msidbServiceControlEventStart) = msidbServiceControlEventStart And (bits And msidbServiceControlEventUninstallStart) = msidbServiceControlEventUninstallStart Then
		   AddAttribute "Start", "both"
		ElseIf (bits And msidbServiceControlEventUninstallStart) Then
		   AddAttribute "Start", "uninstall"
		ElseIf (bits And msidbServiceControlEventStart) Then
		   AddAttribute "Start", "install"
		End If
		If (bits And msidbServiceControlEventStop) = msidbServiceControlEventStop And (bits And msidbServiceControlEventUninstallStop) = msidbServiceControlEventUninstallStop Then
		   AddAttribute "Stop", "both"
		ElseIf (bits And msidbServiceControlEventStop) Then
		   AddAttribute "Stop", "install"
		ElseIf (bits And msidbServiceControlEventUninstallStop) Then
		   AddAttribute "Stop", "uninstall"
		End If
		If (bits And msidbServiceControlEventRemove) = msidbServiceControlEventRemove And (bits And msidbServiceControlEventUninstallRemove) = msidbServiceControlEventUninstallRemove Then
		   AddAttribute "Remove", "both"
		ElseIf (bits And msidbServiceControlEventRemove) Then
		   AddAttribute "Remove", "install"
		ElseIf (bits And msidbServiceControlEventUninstallRemove) Then
		   AddAttribute "Remove", "uninstall"
		End If
		If Len(row.StringData(ServiceControl_Wait)) > 0 Then 
		   If "1" = row.StringData(ServiceControl_Wait) Then AddAttribute "Wait", "yes"
		   If "0" = row.StringData(ServiceControl_Wait) Then AddAttribute "Wait", "no"
		End If
		ProcessServiceControlArguments row.StringData(ServiceControl_Arguments)
		EndElement
	Loop
End Sub  ' ProcessServiceControlTable

Sub ProcessServiceControlArguments(arguments)
   If Len(arguments) = 0 Then Exit Sub

   Dim args, arg
   args = Split(arguments, "[~]")
   For Each arg In args
		NewElement("ServiceArgument")
		elementText = arg
		EndElement
	Next
End Sub  ' ProcessServiceControlArguments

Sub ProcessServiceInstallTable(component)
	Dim row, view, table, servId, bits
	table = "ServiceInstall"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM `" & table & "` WHERE `Component_` = '" & component & "'") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
	   If row Is Nothing Then Exit Do
		NewElement(table)
		elementText = StripModuleId(row.StringData (ServiceInstall_ServiceInstall))
		AddAttribute "Name",  row.StringData(ServiceInstall_Name)
		If Len(row.StringData(ServiceInstall_DisplayName)) > 0 Then AddAttribute "DisplayName", row.StringData(ServiceInstall_DisplayName)
		bits = row.IntegerData(ServiceInstall_ServiceType)
		If (bits And msidbServiceInstallShareProcess) = msidbServiceInstallShareProcess Then 
		   AddAttribute "Type", "shareProcess"
		ElseIf (bits And msidbServiceInstallOwnProcess)   = msidbServiceInstallOwnProcess Then   
		   AddAttribute "Type", "ownProcess"
		End If
		If (bits And msidbServiceInstallInteractive)  = msidbServiceInstallInteractive Then  AddAttribute "Interactive", "yes"

		bits = row.IntegerData(ServiceInstall_StartType)
		If (bits And msidbServiceInstallDisabled)    = msidbServiceInstallDisabled Then
		   AddAttribute "Start", "disabled"
		ElseIf (bits And msidbServiceInstallDemandStart) = msidbServiceInstallDemandStart Then
		   AddAttribute "Start", "demand"
		ElseIf (bits And msidbServiceInstallAutoStart)   = msidbServiceInstallAutoStart Then
		   AddAttribute "Start", "auto"
		End If

		bits = row.IntegerData(ServiceInstall_ErrorControl)
		If (bits And msidbServiceInstallErrorCritical)= msidbServiceInstallErrorCritical Then 
		   AddAttribute "ErrorControl", "critical"
		ElseIf (bits And msidbServiceInstallErrorNormal)  = msidbServiceInstallErrorNormal Then   
		   AddAttribute "ErrorControl", "normal"
		ElseIf (bits And msidbServiceInstallErrorIgnore)  = msidbServiceInstallErrorIgnore Then   
		   AddAttribute "ErrorControl", "ignore"
		End If
		If (bits And msidbServiceInstallErrorControlVital) = msidbServiceInstallErrorControlVital Then AddAttribute "Vital", "yes"
		If Len(row.StringData(ServiceInstall_LoadOrderGroup)) > 0 Then AddAttribute "LocalGroup", row.StringData(ServiceInstall_LoadOrderGroup)		
		If Len(row.StringData(ServiceInstall_StartName)) > 0 Then AddAttribute "Account", row.StringData(ServiceInstall_StartName)
		If Len(row.StringData(ServiceInstall_Password)) > 0 Then AddAttribute "Password", row.StringData(ServiceInstall_Password)		
		If Len(row.StringData(ServiceInstall_Arguments)) > 0 Then AddAttribute "Arguments", row.StringData(ServiceInstall_Arguments)		
		If Len(row.StringData(ServiceInstall_Description)) > 0 Then 
		   If "[~]" = row.StringData(ServiceInstall_Description) Then AddAttribute "EraseDescription", "yes" Else AddAttribute "Description", row.StringData(ServiceInstall_Description)
		End If
		ProcessServiceInstallDependencies row.StringData(ServiceInstall_Dependencies)
		EndElement
	Loop
End Sub  ' ProcessServiceInstallTable

Sub ProcessServiceInstallDependencies(dependencies)
   If Len(dependencies) = 0 Then Exit Sub

   Dim deps, dep
   deps = Split(dependencies, "[~]")
   For Each dep In deps
      If Len(dep) > 0 Then
		   NewElement("ServiceDependency")
		   If "+" = Left(dep, 1) Then 
		      AddAttribute "Group", "yes"
		      dep = Mid(dep, 2)
		   End If
		   elementText = dep
		   EndElement
		End If
	Next
End Sub  ' ProcessServiceInstallDependencies

Sub ProcessLockPermissionsTable(tableKey, tableName)
	Dim table, row, view, bits, specialPermissions, name, index, limit
	table = "LockPermissions"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Select Case(tableName)
	Case "File"         : specialPermissions = filePermissions
	Case "CreateFolder" : specialPermissions = folderPermissions
	Case "Registry"     : specialPermissions = registryPermissions
	Case Else : Fail "Invalid parent table name for LockPermissions entry: " & tableName
	End Select
	Set view = database.OpenView("SELECT * FROM `" & table & "` WHERE `LockObject` = '" & tableKey & "' AND `Table`= '" & tableName & "'") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement("Permission")
		AddAttribute "User",   row.StringData (LockPermissions_User)
		AddAttribute "Domain", row.StringData (LockPermissions_Domain)
		bits         =         row.IntegerData(LockPermissions_Permission)
REM		commonCount = UBound(standardPermissions)
		limit = UBound(specialPermissions)
		For index = 0 To 31
			If index <= limit And (bits And 1) <> 0 Then
				If index < 16 Then
					name = specialPermissions(index)
				ElseIf index < 28 Then
					name = standardPermissions(index-16)
				Else
					name =  genericPermissions(index-28)
				End If
				If IsEmpty(name) Then Fail "Unknown permission at bit position " & index
				AddAttribute name, "yes"
			End If
			bits = (bits And -2)\2 ' make even to avoid error if negative
			If index = 15 Then limit = UBound(standardPermissions) + 16
			If index = 27 Then limit = UBound( genericPermissions) + 28
		Next
		EndElement
	Loop
End Sub

Sub ProcessMediaTable
	Dim row, view, table
	table = "Media"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM `" & table & "` ORDER BY `DiskId`") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement(table)
		AddAttribute "DiskId",       row.IntegerData(Media_DiskId)
		AddAttribute "LastSequence", row.IntegerData(Media_LastSequence)
		AddAttribute "DiskPrompt",   row.StringData(Media_DiskPrompt)
		AddAttribute "Cabinet",      row.StringData(Media_Cabinet)
		AddAttribute "VolumeLabel",  row.StringData(Media_VolumeLabel)
		AddAttribute "Source",       row.StringData(Media_Source )
REM !! <element type='PatchPackage' minOccurs='0' maxOccurs='*'/>
		EndElement
	Loop
End Sub

Sub ProcessCustomActionTable
	Dim row, view, table, bits, sourceBits, targetBits, name, source, target, CAType
	table = "CustomAction"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM `" & table & "`") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement(table)
		elementText = StripModuleId(row.StringData (CustomAction_Action))
		bits        = row.IntegerData(CustomAction_Type)
		Select Case(bits And msidbCustomActionTypeSourceBits)
			Case msidbCustomActionTypeBinaryData : name = "BinaryKey"
			Case msidbCustomActionTypeSourceFile : name = "FileKey"
			Case msidbCustomActionTypeDirectory  : name = "Directory"
			Case msidbCustomActionTypeProperty   : name = "Property"
		End Select
		Select Case(bits And msidbCustomActionTypeTypeBits)
			Case 0 : Fail "Unsupported custom action type: 0"
			Case msidbCustomActionTypeDll      : CAType = "DllEntry"
			Case msidbCustomActionTypeExe      : CAType = "ExeCommand"
			Case msidbCustomActionTypeTextData : CAType = "Value"
			Case 4 : Fail "Unsupported custom action type: 4"
			Case msidbCustomActionTypeJScript  : CAType = "JScriptCall"
			Case msidbCustomActionTypeVBScript : CAType = "VBScriptCall"
			Case msidbCustomActionTypeInstall  : CAType = "InstallProperties"
		End Select
		source = row.StringData(CustomAction_Source)
		target = row.StringData(CustomAction_Target)
		If name="FileKey" AND CAType="Value" Then
		    AddAttribute "Error", Trim(target)
		Else
    		If source="" Then
    		    AddEmptyAttribute name
    		Else
    		    AddAttribute name, source
    		End If
    		If target="" Then
    		    AddEmptyAttribute CAType
    		Else
    		    AddAttribute CAType, target
    		End If
    	End If
		Select Case(bits And msidbCustomActionTypeReturnBits)
			Case 0 : name = Empty         ' default is  "check"
			Case msidbCustomActionTypeContinue : name = "ignore"
			Case msidbCustomActionTypeAsync    : name = "asyncWait" 
			Case msidbCustomActionTypeAsync +_
			     msidbCustomActionTypeContinue : name = "asyncNoWait"
		End Select
		AddAttribute "Return", name
		
		Select Case(bits And msidbCustomActionTypeExecuteBits)
			Case  0 : name = Empty               ' default is  "immediate"
			Case  msidbCustomActionTypeFirstSequence  : name = "firstSequence" 
			Case  msidbCustomActionTypeOncePerProcess : name = "oncePerProcess"
			Case  msidbCustomActionTypeClientRepeat   : name = "secondSequence"
			Case  msidbCustomActionTypeInScript       : name = "deferred"      
			Case  msidbCustomActionTypeInScript +_
			      msidbCustomActionTypeRollback       : name = "rollback"      
			Case  msidbCustomActionTypeInScript +_
			      msidbCustomActionTypeCommit         : name = "commit"        
			Case  7 : Fail "Unsupported custom action Execute type: 7"
		End Select
		AddAttribute "Execute", name
		If bits And msidbCustomActionTypeNoImpersonate Then AddAttribute "Impersonate", "no"
		EndElement
	Loop
End Sub

Sub ProcessSequenceTable(table)
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Dim view, viewDialog, viewCustom
	Set view = database.OpenView("SELECT * FROM `" & table & "` ORDER BY `Sequence`") : CheckError
	If database.TablePersistent("Dialog") = 1 Then
	    Set viewDialog = database.OpenView("SELECT NULL FROM `Dialog` WHERE `Dialog` = ?") : CheckError
	Else
		Set viewDialog = Nothing
	End If
	If database.TablePersistent("CustomAction") = 1 Then
		Set viewCustom = database.OpenView("SELECT NULL FROM `CustomAction` WHERE `Action` = ?") : CheckError
	Else
		Set viewCustom = Nothing
	End If
	Dim row, action, condition, sequence, onExit
	view.Execute : CheckError
	NewElement(table)
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		action    = row.StringData (InstallUISequence_Action)
		condition = row.StringData (InstallUISequence_Condition)
		sequence  = row.IntegerData(InstallUISequence_Sequence)
		If Not viewCustom Is Nothing Then
			viewCustom.Execute row : CheckError
			If Not viewCustom.Fetch Is Nothing Then
				NewElement "Custom"
				AddAttribute "Action", action
				action = Empty
			End If
		End If
		If Not IsEmpty(action) And Not viewDialog Is Nothing Then
			viewDialog.Execute row : CheckError
			If Not viewDialog.Fetch Is Nothing Then
				NewElement "Show"
				AddAttribute "Dialog", action
				action = Empty
			End If
		End If
		If Not fNoSeqTables Or IsEmpty(action) Then
			If Not IsEmpty(action) Then NewElement action
			If sequence < 0 Then
				Select Case(sequence)
				Case -1 : onExit = "success"
				Case -2 : onExit = "cancel"
				Case -3 : onExit = "error"
				Case -4 : onExit = "suspend"
				Case Else : Fail "Invalid OnExit sequence number: " & sequence
				End Select
				AddAttribute "OnExit", onExit
			Else
				AddAttribute "Sequence", sequence
			End If
			'!! do we need a flag to force out sequence numbers? best if not standard numbers, but how?
			SetElementText condition
			EndElement
		End If
	Loop
	EndElement
End Sub

Const encode64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/="
Const bufSize = 360

Sub ProcessBinaryTable(table, fNoBinary)
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Dim view : Set view = database.OpenView("SELECT * FROM `" & table & "`") : CheckError
	Dim row, name, length, data, line, index, char, nxtc, total, lineNum
	view.Execute : CheckError
	If fExportBinaries Then 
	    database.export table, manifestFolder, table & ".idt"
	    filesystem.DeleteFile(manifestFolder & "\" & table & ".idt")
	End If
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		name   = row.StringData (Binary_Name)
		NewElement table
		AddAttribute "Name", name
		If fNoBinary Then
		    AddAttribute "src", table & "\" & name & ".ibd"
		Else
    		total  = row.DataSize   (Binary_Data)
    		If fVerbose Then Wscript.Echo "Formatting binary data " & name & " from " & table & ", size = " & total
    		lineNum = 0
    		Do
    			data = row.ReadStream(Binary_Data, bufSize, 1)
    			length = Len(data)
    			If length = 0 Then Exit Do
    			lineNum = lineNum + 1
    			line = "<!--" & lineNum & "-->"
    			For index = 1 To length Step 3
    				char = AscB(Mid(data, index, 1))
    				line = line & Mid(encode64, (char \ 4) + 1, 1)
    				nxtc = (char Mod 4) * 16
    				If length = index Then
    					line = line & Mid(encode64, nxtc + 1, 1) & "=="
    				Else
    					char = AscB(Mid(data, index+1, 1))
    					line = line & Mid(encode64, (char \ 16) + nxtc + 1, 1)
    					nxtc = (char Mod 16) * 4
    					If length < index + 2  Then
    						line = line & Mid(encode64, nxtc + 1, 1) & "="
    					Else
    						char = AscB(Mid(data, index+2, 1))
    						line = line & Mid(encode64, (char  \  64) + nxtc + 1, 1)_
    									& Mid(encode64, (char Mod 64)        + 1, 1)
    					End If
    				End If
    			Next
    			WritePartialText(line)
    		Loop
    	End If
		EndElement
	Loop
End Sub

'--------------------------------------------------------'
' UI database table processors
'--------------------------------------------------------'
Sub ProcessUITextTable
	Dim table : table = "UIText"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Dim view : Set view = database.OpenView("SELECT * FROM `" & table & "`") : CheckError
	Dim row, text
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement(table)
		elementText = row.StringData(UIText_Key)
		text        = row.StringData(UIText_Text)
		If NeedsEscape(text) Then
			NewElement("Text")
			elementText = text
			EndElement
		Else
			AddAttribute "Text", text
		End If
		EndElement
	Loop
End Sub

Sub ProcessTextStyleTable
	Dim table : table = "TextStyle"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Dim view : Set view = database.OpenView("SELECT * FROM `" & table & "`") : CheckError
	Dim row, style, color
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement(table)
		elementText =             row.StringData (TextStyle_TextStyle)
		AddAttribute "FaceName",  row.StringData (TextStyle_FaceName)
		AddAttribute "Size",      row.StringData (TextStyle_Size)
		If Not row.IsNull(TextStyle_Color) Then
			color = row.IntegerData(TextStyle_Color)			
			AddAttribute "Red",   color       And 255
			AddAttribute "Green", color\256   And 255
			AddAttribute "Blue",  color\65536 And 255
		End If
		style = row.IntegerData(TextStyle_StyleBits)
		If style And 1 Then AddAttribute "Bold",      "yes"
		If style And 2 Then AddAttribute "Italic",    "yes"
		If style And 4 Then AddAttribute "Underline", "yes"
		If style And 8 Then AddAttribute "Strike",    "yes"
		EndElement
	Loop
End Sub

Sub ProcessDialogTable
	Dim table : table = "Dialog"
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Dim row, bits, firstControl, defaultControl, cancelControl, nextControl, index, name
	Dim view : Set view = database.OpenView("SELECT * FROM `" & table & "`") : CheckError
	view.Execute
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement(table)
		elementText = row.StringData(Dialog_Dialog)
		If row.IntegerData(Dialog_HCentering) <> 50 Then AddAttribute "X", row.IntegerData(2)
		If row.IntegerData(Dialog_VCentering) <> 50 Then AddAttribute "Y", row.IntegerData(3)
		AddAttribute "Width", row.IntegerData(Dialog_Width)
		AddAttribute "Height", row.IntegerData(Dialog_Height)
		bits = row.IntegerData(Dialog_Attributes) Xor dialogAttributesInvert
		AddAttribute "Title", row.StringData(Dialog_Title)
		firstControl   = row.StringData(Dialog_Control_First)
		defaultControl = row.StringData(Dialog_Control_Default)
		cancelControl  = row.StringData(Dialog_Control_Cancel)
		If bits And msidbDialogAttributesModal Then bits = bits And Not msidbDialogAttributesMinimize
		If bits And msidbDialogAttributesError Then AddAttribute "ErrorDialog", "yes" ' can we discover this ourselves?
REM WScript.Echo "Dialog " & elementText & " bits = " & Hex(bits)
		For index = 0 To UBound(dialogAttributes)
			If bits And 1 Then
				name = dialogAttributes(index)
				If IsEmpty(name) Then Fail "Unknown attribute at bit position " & index
				AddAttribute name, "yes"
			End If
			bits = bits\2
		Next
		Dim params : Set params = installer.CreateRecord(2)
		Dim view1 : Set view1 = database.OpenView("SELECT * FROM `Control` WHERE `Dialog_` = ?") : CheckError
		Dim view2 : Set view2 = database.OpenView("SELECT * FROM `Control` WHERE `Dialog_` = ? AND `Control` = ?") : CheckError
		nextControl = firstControl
		params.StringData(1) = elementText
		Do
			params.StringData(2) = nextControl
			view2.Execute params : CheckError
			Set row = view2.Fetch : CheckError
			If row Is Nothing Then Fail "Control " & nextControl & " not found"
			ProcessControl row, defaultControl, cancelControl, False
			nextControl = row.StringData(Control_Control_Next)
		Loop While Len(nextControl) > 0 And nextControl <> firstControl
		view1.Execute params : CheckError
		Do ' pick up remaining controls not in tab sequence
			Set row = view1.Fetch : CheckError
			If row Is Nothing Then Exit Do
			If row.IsNull(Control_Control_Next) And row.StringData(Control_Control) <> firstControl Then ProcessControl row, defaultControl, cancelControl, True
		Loop
		EndElement
	Loop
End Sub

Sub ProcessControl(row, defaultControl, cancelControl, noTab)
	Dim bits, commonCount, specialCount, specialAttributes, index, name, controlType, iconSize, text, row2, controlEvent, disabled, limit, ignoreBits, tabSkip
	Dim value
	commonCount = UBound(commonControlAttributes)
	NewElement("Control")
	elementText = row.StringData(Control_Control)
	controlType = row.StringData(Control_Type)
	AddAttribute "Type",    controlType
	AddAttribute "X",       row.IntegerData(Control_X)
	AddAttribute "Y",       row.IntegerData(Control_Y)
	AddAttribute "Width",   row.IntegerData(Control_Width)
	AddAttribute "Height",  row.IntegerData(Control_Height)
	AddAttribute "Property", row.StringData(Control_Property)
	AddAttribute "Help",     row.StringData(Control_Help)

REM  Added by v-aarong to create the CheckBox values needed
	If controlType = "CheckBox" Then
		Dim viewCheckBox : Set viewCheckBox = database.OpenView("SELECT `Value` FROM `CheckBox` WHERE `Property` = '"  & row.StringData(Control_Property) & "'") : CheckError
		viewCheckBox.Execute ' will return a single value or will fail
		Dim CheckBoxRow : Set CheckBoxRow = viewCheckBox.Fetch : CheckError
		If CheckBoxRow Is Nothing Then 
			Wscript.Echo "Unable to collect CheckBox Table entry for Control --> " & row.StringData(Control_Dialog_)& "."& row.StringData(Control_Control)
	      Else
	      	value = CheckBoxRow.StringData(1)
	      	If Len(value)=0 Then
	      		AddEmptyAttribute "CheckBoxValue"
	      	Else
				AddAttribute "CheckBoxValue", value
			End If
	      End If
	End If

	If elementText = defaultControl Then AddAttribute "Default", "yes"
	If elementText = cancelControl  Then AddAttribute "Cancel", "yes"
	Select Case(controlType)
	Case "Text"              : specialAttributes = textControlAttributes   : tabSkip = True
	Case "Edit"              : specialAttributes = editControlAttributes   : ignoreBits = msidbControlAttributesNoPrefix 'O2k bug
	Case "MaskedEdit"        : specialAttributes = editControlAttributes
	Case "PathEdit"          : specialAttributes = editControlAttributes
	Case "Icon"              : specialAttributes = iconControlAttributes     : tabSkip = True : disabled = True : ignoreBits = msidbControlAttributesIcon
	Case "Bitmap"            : specialAttributes = bitmapControlAttributes   : tabSkip = True : disabled = True : ignoreBits = msidbControlAttributesBitmap
	Case "ProgressBar"       : specialAttributes = progressControlAttributes : tabSkip = True : disabled = True
	Case "DirectoryCombo"    : specialAttributes = volumeControlAttributes
	Case "VolumeSelectCombo" : specialAttributes = volumeControlAttributes
	Case "VolumeCostList"    : specialAttributes = volumeControlAttributes   : tabSkip = True
	Case "ListBox"           : specialAttributes = listboxControlAttributes
	Case "ListView"          : specialAttributes = listviewControlAttributes
	Case "ComboBox"          : specialAttributes = comboboxControlAttributes
	Case "PushButton"        : specialAttributes = buttonControlAttributes
	Case "CheckBox"          : specialAttributes = checkboxControlAttributes
	Case "RadioButtonGroup"  : specialAttributes = radioControlAttributes
	Case "ScrollableText"    
	Case "SelectionTree"     
	Case "DirectoryList"     
	Case "GroupBox"          : tabSkip = True : disabled = True
	Case "Line"              : tabSkip = True : disabled = True
	Case "Billboard"         : tabSkip = True : disabled = True
REM	Case Else                : tabSkip = True
	Case Else  Fail "Unknown control type: " & controlType & "  Attributes = &h" & Hex(row.IntegerData(Control_Attributes))
	End Select
	bits = row.IntegerData(Control_Attributes) And Not ignoreBits
	If disabled Then bits = bits Or msidbControlAttributesEnabled
	bits = bits Xor commonControlAttributesInvert
	For index = 0 To 15
		If index < commonCount And (bits And 1) <> 0 Then
			name = commonControlAttributes(index)
			If IsEmpty(name) Then Fail "Unknown attribute at bit position " & index
			AddAttribute name, "yes"
		End If
		bits = bits\2
	Next
	If Not IsEmpty(specialAttributes) Then limit = UBound(specialAttributes) 'Else limit = -1
	For index = 0 To 15
		If bits = 0 Then Exit For
		If index <= limit Then
			name = specialAttributes(index)
		Else
			name = Empty
		End If
		If bits And 1 Then
			If IsEmpty(name) Then Fail "Unknown attribute for control type " & controlType & " at bit position " & (index + 16)
			If Left(name, 4) = "Icon" And Len(name) = 6 Then
				iconSize = iconSize + CInt(Right(name,2))
			Else
				AddAttribute name, "yes"
			End If
		End If
		bits = bits\2
	Next
	AddAttribute "IconSize", iconSize
	If noTab And Not tabSkip Then AddAttribute "TabSkip", "yes"
	If Not noTab And tabSkip Then AddAttribute "TabSkip", "no"
	If Not row.IsNull(Control_Text) Then
		text = row.StringData(Control_Text)
		If Len(text)<=20 And InStr(text,"<")=0 And InStr(text,">")=0 And InStr(text,"&")=0 And InStr(text,"'")=0 And InStr(text,"""")=0 Then
			AddAttribute "Text", text
		Else
			NewElement "Text"
			SetElementText(text)
			EndElement
		End If
	End If
	Dim params : Set params = installer.CreateRecord(2)
	params.StringData(1) = row.StringData(Control_Dialog_)
	params.StringData(2) = row.StringData(Control_Control)
	If database.TablePersistent("ControlEvent") = 1 Then
		Dim viewPublish : Set viewPublish = database.OpenView("SELECT * FROM `ControlEvent` WHERE `Dialog_` = ? AND `Control_` = ? ORDER BY `Ordering`") : CheckError
		viewPublish.Execute params : CheckError
		Do
			Set row2 = viewPublish.Fetch : CheckError
			If row2 Is Nothing Then Exit Do
			NewElement("Publish")
			controlEvent = row2.StringData(ControlEvent_Event)
			If Left(controlEvent,1) = "[" And Right(controlEvent,1) = "]" Then
				AddAttribute "Property", Mid(controlEvent, 2, Len(controlEvent)-2)
			Else
				AddAttribute "Event", controlEvent
			End If
			AddAttribute "Value", row2.StringData(ControlEvent_Argument)
			SetElementText(row2.StringData(ControlEvent_Condition))
			EndElement
		Loop
	End If
	If database.TablePersistent("EventMapping") = 1 Then
		Dim viewSubscribe : Set viewSubscribe = database.OpenView("SELECT * FROM `EventMapping` WHERE `Dialog_` = ? AND `Control_` = ?") : CheckError
		viewSubscribe.Execute params : CheckError
		Do
			Set row2 = viewSubscribe.Fetch : CheckError
			If row2 Is Nothing Then Exit Do
			NewElement("Subscribe")
			controlEvent = row2.StringData(EventMapping_Event)
			AddAttribute "Event", controlEvent
			AddAttribute "Attribute", row2.StringData(EventMapping_Attribute)
			EndElement
		Loop
	End If
	If database.TablePersistent("ControlCondition") = 1 Then
		Dim viewCondition : Set viewCondition = database.OpenView("SELECT * FROM `ControlCondition` WHERE `Dialog_` = ? AND `Control_` = ?") : CheckError
		viewCondition.Execute params : CheckError
		Do
			Set row2 = viewCondition.Fetch : CheckError
			If row2 Is Nothing Then Exit Do
			NewElement("Condition")
			AddAttribute "Action", LCase(row2.StringData(ControlCondition_Action))
			SetElementText(row2.StringData(ControlCondition_Condition))
			EndElement
		Loop
	End If
	EndElement
End Sub

Sub ProcessControlGroupTable(table)
	Dim view, view2, row, row2, bits, lastProperty, property, helpArray, attrName
	If database.TablePersistent(table) <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM `" & table & "`") : CheckError
	view.Execute ' will be sorted by Property,Order since they are the primary keys for all tables
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		property = row.StringData(ListBox_Property)
		If property <> lastProperty Then
			If Not IsEmpty(lastProperty) Then EndElement
			REM !! Query Control table to see if this is really "Icon"
			If table = "RadioButton" Then
				NewElement("RadioGroup")
				attrName = "Text"
				Set view2 = database.OpenView("SELECT `Attributes` FROM `Control` WHERE `Type`='RadioButtonGroup' AND `Property`='" & property & "'")
				view2.Execute
				Set row2 = view2.Fetch
				If Not row2 Is Nothing Then
					If row2.IntegerData(1) And (msidbControlAttributesIcon+msidbControlAttributesBitmap) Then attrName = "Icon"
				End If
			Else
				NewElement(table)
			End If
			AddAttribute "Property", property
			lastProperty = property
		End If
		If table = "RadioButton" Then
			NewElement table
			AddAttribute "X",     row.IntegerData(RadioButton_X)
			AddAttribute "Y",     row.IntegerData(RadioButton_Y)
			AddAttribute "Width", row.IntegerData(RadioButton_Width)
			AddAttribute "Height",row.IntegerData(RadioButton_Height)
			AddAttribute attrName,row.StringData (RadioButton_Text)
			helpArray     = Split(row.StringData (RadioButton_Help) & "|", "|") ' prevent error if missing delim
			AddAttribute "ToolTip", helpArray(0)
			AddAttribute "Help",    helpArray(1)
			SetElementText        row.StringData (RadioButton_Value)
		Else '"ListBox" or "ListView" ' tables identical except for Icon field only in ListView
			NewElement "ListItem"
			AddAttribute "Text",  row.StringData(ListView_Text)
			AddAttribute "Icon",  row.StringData(ListView_Binary_)
			SetElementText        row.StringData(ListView_Value)
		End If
		EndElement
	Loop
	If Not IsEmpty(lastProperty) Then EndElement
End Sub


Sub ProcessActionText

	Dim view, row
	
	If database.TablePersistent("ActionText") <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM ActionText") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement "ProgressText"
			AddAttribute "Action", row.StringData(ActionText_Action)
			AddAttribute "Template", row.StringData(ActionText_Template)
			SetElementText row.StringData(ActionText_Description)
		EndElement
	Loop
End Sub


Sub ProcessErrorTable

	Dim view, row
	
	If database.TablePersistent("Error") <> 1 Then Exit Sub
	Set view = database.OpenView("SELECT * FROM Error") : CheckError
	view.Execute : CheckError
	Do
		Set row = view.Fetch : CheckError
		If row Is Nothing Then Exit Do
		NewElement "Error"
			AddAttribute "Id", row.StringData(Error_Error)
			SetElementText row.StringData(Error_Message)
		EndElement
	Loop
End Sub


Sub ProcessModuleSignatureTable(ByRef name, ByRef id, ByRef language, ByRef version)
	Dim row, view, table
	Dim moduleid, pos
	table = "ModuleSignature"
	
	If database.TablePersistent(table) <> 1 Then Exit Sub
	
	Set view = database.OpenView("SELECT * FROM `" & table & "`") : CheckError
	view.Execute : CheckError
	Set row = view.Fetch : CheckError
	
	If Not row Is Nothing Then
		moduleid = row.StringData (ModuleSignature_ModuleID)
		language = row.StringData (ModuleSignature_Language)
		version = row.StringData (ModuleSignature_Version)

		pos = InStr(moduleid, ".")
		if pos > 0 Then
			name = Mid(moduleid, 1, pos - 1)

			id = Mid(moduleid, pos + 1, Len(moduleid) - pos)
			id = Replace(id, "_", "-")
		End If
	End If

End Sub

Function StripModuleId( str )

    If fMergeModule=true Then
        StripModuleId = Replace( str, "." & ModuleIdUnderscored, "" )
    Else
        StripModuleId = str
    End If
End Function

Sub ProcessOrphanedComponents
    
    Dim CompDirView 
    Dim DirView 
    Dim directory, directoryName
    Dim CompRow
    Dim DirRow
    Dim parentDir
    
    Set CompDirView = database.OpenView("Select Distinct Directory_ From Component") : CheckError
    CompDirView.Execute : CheckError
	Do
		Set CompRow = CompDirView.Fetch : CheckError
		If CompRow Is Nothing Then Exit Do
		directory = CompRow.StringData(1) 
		Set DirView = database.OpenView("Select * From Directory Where Directory='" & directory & "'") : CheckError
        DirView.Execute : CheckError
        Set DirRow = DirView.Fetch : CheckError
        
        If NOT DirRow Is Nothing Then
            parentDir = DirRow.StringData(Directory_Directory_Parent)
        Else
            parentDir = ""
        End If
        
        If DirRow Is Nothing or dictDirectories.Exists(parentDir) Then
        
            If NOT dictDirectories.Exists(directory) Then
                NewElement("Directory")
                    directoryName = StripModuleId( directory )
                    elementText = directoryName
                    If Len(directoryName) <= 8 Then
                        AddAttribute "Name", directory
                    Else
                        AddAttribute "Name", Left(directoryName, 8)
                        AddAttribute "LongName", directoryName
                    End If
                    ProcessComponentTable directory
                EndElement
                dictDirectories.Add directory, 1
            End If
        Else
            ProcessOrphanedDirs parentDir
        End If
	Loop
End Sub


Sub ProcessOrphanedDirs( directory )

    Dim DirView, DirRow, parentDir

    If directory <> "" Then
        Set DirView = database.OpenView("Select * From Directory Where Directory='" & directory & "'") : CheckError
        DirView.Execute : CheckError
        Set DirRow = DirView.Fetch : CheckError
        If Not DirRow Is Nothing Then
            parentDir = DirRow.StringData(Directory_Directory_Parent)
            If NOT dictDirectories.Exists(parentDir) Then
                ProcessOrphanedDirs parentDir
            Else
                directory
            End If
        Else
            ProcessDirectoryTable directory
        End If 
    End If
End Sub