/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSASYNCHOPENFROMSCCPROJECTEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSASYNCHOPENFROMSCCPROJECTEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsAsynchOpenFromSccProjectEventsNotImpl :
	public IVsAsynchOpenFromSccProjectEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAsynchOpenFromSccProjectEventsNotImpl)

public:

	typedef IVsAsynchOpenFromSccProjectEvents Interface;

	STDMETHOD(OnFilesDownloaded)(
		/*[in]*/ int /*cFiles*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgpszFullPaths*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnLoadComplete)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnLoadFailed)()VSL_STDMETHOD_NOTIMPL
};

class IVsAsynchOpenFromSccProjectEventsMockImpl :
	public IVsAsynchOpenFromSccProjectEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAsynchOpenFromSccProjectEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsAsynchOpenFromSccProjectEventsMockImpl)

	typedef IVsAsynchOpenFromSccProjectEvents Interface;
	struct OnFilesDownloadedValidValues
	{
		/*[in]*/ int cFiles;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgpszFullPaths;
		HRESULT retValue;
	};

	STDMETHOD(OnFilesDownloaded)(
		/*[in]*/ int cFiles,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgpszFullPaths[])
	{
		VSL_DEFINE_MOCK_METHOD(OnFilesDownloaded)

		VSL_CHECK_VALIDVALUE(cFiles);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszFullPaths, cFiles*sizeof(rgpszFullPaths[0]), validValues.cFiles*sizeof(validValues.rgpszFullPaths[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnLoadCompleteValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnLoadComplete)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnLoadComplete)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnLoadFailedValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnLoadFailed)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnLoadFailed)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSASYNCHOPENFROMSCCPROJECTEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
