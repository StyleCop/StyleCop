//--------------------------------------------------------------------------
// Microsoft Visual Studio
//
// Copyright (c) 1998 - 2003 Microsoft Corporation Inc.
// All rights reserved
//
//
// venusids.h
// Venus command table ids
//---------------------------------------------------------------------------
//NOTE: billhie. CTC compiler cannot handle #pragma once (it issues a warning)
#ifndef __VENUSIDS_H__
#define __VENUSIDS_H__

#include "venuscmddef.h"

//----------------------------------------------------------------------------
//
// GUID Identifiers
//
// Define CommandSet GUIDs in two ways - C compiler and CTC compiler.
// ** MAKE UPDATES TO BOTH GUID DECLS BELOW **
//----------------------------------------------------------------------------
#ifdef DEFINE_GUID

//guidDirPkgGrpId
// {5ADFC620-064F-40ec-88D1-F3F4F01EFC6F}
//guidDirPkgCmdId
// {C7547851-4E3A-4e5b-9173-FA6E9C8BD82C}
DEFINE_GUID(guidVenusCmdId, 
0xc7547851, 0x4e3a, 0x4e5b, 0x91, 0x73, 0xfa, 0x6e, 0x9c, 0x8b, 0xd8, 0x2c);

// {883D561D-1199-49f3-A19E-78B5ADE9C6C1}
DEFINE_GUID(guidVenusStartPageCmdId, 
0x883d561d, 0x1199, 0x49f3, 0xa1, 0x9e, 0x78, 0xb5, 0xad, 0xe9, 0xc6, 0xc1);

#else

// {39C9C826-8EF8-4079-8C95-428F5B1C323F} Used by VenusMenu.ctc
#define CLSID_WebProjectPackage { 0x39c9c826, 0x8ef8, 0x4079, { 0x8c, 0x95, 0x42, 0x8f, 0x5b, 0x1c, 0x32, 0x3f}}

// {5BE15F81-5A3C-11d2-BF19-00C04F79EFBC}
#define guidVenusCmdId {0xc7547851, 0x4e3a, 0x4e5b, { 0x91, 0x73, 0xfa, 0x6e, 0x9c, 0x8b, 0xd8, 0x2c}}

// {883D561D-1199-49f3-A19E-78B5ADE9C6C1}
#define guidVenusStartPageCmdId { 0x883d561d, 0x1199, 0x49f3, { 0xa1, 0x9e, 0x78, 0xb5, 0xad, 0xe9, 0xc6, 0xc1 } }

#endif

//---------------------------------------------------------------------------
// Comand Table Version
//---------------------------------------------------------------------------
#define COMMANDTABLE_VERSION		1

// web package menus
#define IDM_VENUS_CSCD_ADDWEB      6
#define IDM_VENUS_WEB              8
#define IDM_VENUS_CSCD_ADDFOLDER   9
#define IDM_VENUS_CTXT_ADDREFERENCE 10
#define IDM_VENUS_CTXT_ITEMWEBREFERENCE 11

// "Add Web" Menu Groups
#define IDG_VENUS_ADDWEB_CASCADE          25
#define IDG_VENUS_ADDFOLDER               26
#define IDG_VENUS_CTX_REFERENCE           27

//Command IDs
#define icmdNewWeb                      0x002B
#define icmdOpenExistingWeb             0x002C
#define icmdAddNewWeb                   0x002D
#define icmdAddExistingWeb              0x002E
#define icmdValidatePage                0x002F
#define icmdOpenSubWeb                  0x0032
#define icmdAddAppAssemblyFolder        0x0034
#define icmdAddAppCodeFolder            0x0035
#define icmdAddAppGlobalResourcesFolder 0x0036
#define icmdAddAppLocalResourcesFolder  0x0037
#define icmdAddAppWebReferencesFolder   0x0038
#define icmdAddAppDataFolder            0x0039
#define icmdAddAppBrowsersFolder        0x0040
#define icmdAddAppThemesFolder          0x0041
#define icmdRunFxCop                    0x0042
#define icmdFxCopConfig                 0x0043
#define icmdBuildLicenseDll             0x0044
#define icmdUpdateReference             0x0045
#define icmdRemoveWebReference          0x0046

// "Web" Menu Groups - Start at 0x100 - they share the same menu guid with 
// commands "guidVenusCmdId"
#define IDG_VS_BUILD_VAILIDATION        0x0100
#define IDG_VENUS_CTX_SUBWEB            0x0101
#define IDG_CTX_REFERENCE               0x0102
#define IDG_CTX_PUBLISH                 0x0103
#define IDG_CTX_BUILD                   0x0104
#define IDG_VENUS_RUN_FXCOP             0x0105
#define IDG_VENUS_RUN_FXCOP_CTXT_PROJ   0x0106
#define IDG_VENUS_CTX_ITEM_WEBREFERENCE  0x0107


// Start Page commands (introduced in Whidbey, some re-used in Orcas)
// *** These are referenced in Web.vssettings and WebExpress.vssettings 
// do not change the numbers without updating that file as well!
#define cmdidStartPageCreatePersonalWebSite		0x5000
#define cmdidStartPageCreateWebSite				0x5001
#define cmdidStartPageCreateWebService			0x5002
#define cmdidStartPageStarterKit				0x5003
#define cmdidStartPageCommunity					0x5004
#define cmdidStartPageIntroduction				0x5005
#define cmdidStartPageGuidedTour				0x5006
#define cmdidStartPageWhatsNew					0x5007
#define cmdidStartPageHowDoI					0x5008

// Orcas Start Page commands for VWDExpress and other SKUs 
// *** These are referenced in WebExpress.vssettings 
// do not change the numbers without updating that file as well!

#define cmdidVWDStartPageVideoFeatureTour                0x5009
#define cmdidVWDStartPageLearnWebDevelopment             0x500A
#define cmdidVWDStartPageWhatsNew                        0x500B
#define cmdidVWDStartPageBeginnerDeveloperLearningCenter 0x500C
#define cmdidVWDStartPageASPNETDownloads                 0x500D
#define cmdidVWDStartPageASPNETForums                    0x500E
#define cmdidVWDStartPageASPNETCommunitySite             0x500F
#define cmdidVWDStartPageCreateYourFirstWebSite          0x5010
#define cmdidVWDStartPageExplore3rdPartyExtensions       0x5011

#endif
// End of venusids.h
