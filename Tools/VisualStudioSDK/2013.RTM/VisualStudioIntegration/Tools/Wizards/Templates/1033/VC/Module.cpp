/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

#include "stdafx.h"

#include "CommonIncludes.h"

class PackageModule :
	public CAtlDllModuleT<PackageModule> 
{
};

PackageModule _AtlModule;

// This macro is used as default registry root when a NULL parameter is passed to VSDllRegisterServer
// or VSDllUnregisterServer. For sample code we set as default the experimental instance, but for production
// code you should change it to the standard VisualStudio instance that is LREGKEY_VISUALSTUDIOROOT.
#define DEFAULT_REGISTRY_ROOT LREGKEY_VISUALSTUDIOROOT

// Since this project defines an oleautomation interface, the typelib needs to be registered.
#define VSL_REGISTER_TYPE_LIB TRUE

// Must come after declaration of _AtlModule and DEFAULT_REGISTRY_ROOT
#include <VSLPackageDllEntryPoints.cpp>

