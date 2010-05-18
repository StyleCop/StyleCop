/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSL_REGISTER_TYPE_LIB
#define VSL_REGISTER_TYPE_LIB FALSE
#endif VSL_REGISTER_TYPE_LIB

#pragma warning(push) // Sometimes true, sometimes not.
#pragma warning(disable : 4702) // warning C4702: unreachable code

// Initializes ATL
extern "C"
BOOL WINAPI DllMain(HINSTANCE /*hInstance*/, DWORD dwReason, LPVOID lpReserved)
{
	VSL_STDMETHODTRY{

	return _AtlModule.DllMain(dwReason, lpReserved);

	}VSL_STDMETHODCATCH()

	return FALSE;
}

// Used by COM to determine whether the DLL can be unloaded
STDAPI DllCanUnloadNow()
{
	VSL_STDMETHODTRY{

	return _AtlModule.DllCanUnloadNow();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

// Returns a class factory to create an object of the requested type
STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, LPVOID* ppv)
{
	VSL_STDMETHODTRY{

	return _AtlModule.GetClassObject(rclsid, riid, ppv);

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}


STDMETHODIMP VSDllRegisterServerInternal(_In_opt_ wchar_t* strRegRoot, bool shouldRegister, bool isRanu)
{
	VSL_STDMETHODTRY{

	VsRegistryUtilities::SetRegRoot(NULL==strRegRoot ? DEFAULT_REGISTRY_ROOT : strRegRoot, isRanu);

	//Set ATL to register the typelib as RANU if requested by the caller.
	AtlSetPerUserRegistration(isRanu);

	if(shouldRegister)
	{
		return _AtlModule.RegisterServer(VSL_REGISTER_TYPE_LIB);
	}
	else
	{
		HRESULT hr = _AtlModule.UnregisterServer(VSL_REGISTER_TYPE_LIB);

		// If the type library was already unregistered, ignore the failure
		return (TYPE_E_REGISTRYACCESS == hr) ? S_OK : hr;
	}
	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

// Registers COM objects normally and registers VS Packages to the specified VS registry hive under HKCU
STDAPI VSDllRegisterServerUser(_In_opt_ wchar_t* strRegRoot)
{
	return VSDllRegisterServerInternal(strRegRoot, true, true);
}

// Unregisters COM objects normally and unregisters VS Packages from the specified VS registry hive under HKCU
STDAPI VSDllUnregisterServerUser(__in_opt wchar_t* strRegRoot)
{
	return VSDllRegisterServerInternal(strRegRoot, false, true);
}

// Registers COM objects normally and registers VS Packages to the specified VS registry hive
STDAPI VSDllRegisterServer(__in_opt wchar_t* strRegRoot)
{
	return VSDllRegisterServerInternal(strRegRoot, true, false);
}

// Unregisters COM objects normally and unregisters VS Packages from the specified VS registry hive
STDAPI VSDllUnregisterServer(__in_opt wchar_t* strRegRoot)
{
	return VSDllRegisterServerInternal(strRegRoot, false, false);
}

// Registers COM objects normally and registers VS Packages to the default VS registry hive
STDAPI DllRegisterServer()
{
	return VSDllRegisterServer(NULL);
}

// Unregisters COM objects normally and unregisters VS Packages from the default VS registry hive
STDAPI DllUnregisterServer()
{
	return VSDllUnregisterServer(NULL);
}

#pragma warning(pop)
