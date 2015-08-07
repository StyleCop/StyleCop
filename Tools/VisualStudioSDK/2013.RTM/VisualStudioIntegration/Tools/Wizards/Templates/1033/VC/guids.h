// guids.h: definitions of GUIDs/IIDs/CLSIDs used in this VsPackage

/*
Do not use #pragma once, as this file needs to be included twice.  Once to declare the externs
for the GUIDs, and again right after including initguid.h to actually define the GUIDs.
*/

%ToolWindowItemStart%
// guidPersistanceSlot ID for the Tool Window
// { %ToolGuid% }
#define guid%ProjectClass%PersistenceSlot { %ToolGuid2% }
#ifdef DEFINE_GUID
DEFINE_GUID(CLSID_guidPersistanceSlot, 
%ToolGuid1% );
#endif
%ToolWindowItemEnd%

// package guid
// { %PackageGuid% }
#define guid%ProjectClass%Pkg { %PackageGuid2% }
#ifdef DEFINE_GUID
DEFINE_GUID(CLSID_%ProjectClass%,
%PackageGuid1% );
#endif

// Command set guid for our commands (used with IOleCommandTarget)
// { %CmdSetGuid% }
#define guid%ProjectClass%CmdSet { %CmdSetGuid2% }
#ifdef DEFINE_GUID
DEFINE_GUID(CLSID_%ProjectClass%CmdSet, 
%CmdSetGuid1% );
#endif

//Guid for the image list referenced in the VSCT file
// { %ImagesGuid% }
#define guidImages { %ImagesGuid2% }
#ifdef DEFINE_GUID
DEFINE_GUID(CLSID_Images, 
%ImagesGuid1% );
#endif

%EditorStart%
// Guid for the Editor Factory
// { %FactoryGuid% }
#define guid%ProjectClass%EditorFactory { %FactoryGuid2% } 
#ifdef DEFINE_GUID
DEFINE_GUID(CLSID_%ProjectClass%EditorFactory, 
%FactoryGuid1% ); 
#endif

// Guid for the Editor Document (the document is the actual editor)
// { %DocumentGuid% }
#define guid%ProjectClass%EditorDocument { %DocumentGuid2% }
#ifdef DEFINE_GUID
DEFINE_GUID(CLSID_%ProjectClass%EditorDocument, 
%DocumentGuid1% );
#endif
%EditorEnd%
