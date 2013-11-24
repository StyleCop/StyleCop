/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLECLIENTSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLECLIENTSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OleIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IOleClientSiteNotImpl :
	public IOleClientSite
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleClientSiteNotImpl)

public:

	typedef IOleClientSite Interface;

	STDMETHOD(SaveObject)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMoniker)(
		/*[in]*/ DWORD /*dwAssign*/,
		/*[in]*/ DWORD /*dwWhichMoniker*/,
		/*[out]*/ IMoniker** /*ppmk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContainer)(
		/*[out]*/ IOleContainer** /*ppContainer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowObject)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnShowWindow)(
		/*[in]*/ BOOL /*fShow*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RequestNewObjectLayout)()VSL_STDMETHOD_NOTIMPL
};

class IOleClientSiteMockImpl :
	public IOleClientSite,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleClientSiteMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleClientSiteMockImpl)

	typedef IOleClientSite Interface;
	struct SaveObjectValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(SaveObject)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(SaveObject)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMonikerValidValues
	{
		/*[in]*/ DWORD dwAssign;
		/*[in]*/ DWORD dwWhichMoniker;
		/*[out]*/ IMoniker** ppmk;
		HRESULT retValue;
	};

	STDMETHOD(GetMoniker)(
		/*[in]*/ DWORD dwAssign,
		/*[in]*/ DWORD dwWhichMoniker,
		/*[out]*/ IMoniker** ppmk)
	{
		VSL_DEFINE_MOCK_METHOD(GetMoniker)

		VSL_CHECK_VALIDVALUE(dwAssign);

		VSL_CHECK_VALIDVALUE(dwWhichMoniker);

		VSL_SET_VALIDVALUE_INTERFACE(ppmk);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContainerValidValues
	{
		/*[out]*/ IOleContainer** ppContainer;
		HRESULT retValue;
	};

	STDMETHOD(GetContainer)(
		/*[out]*/ IOleContainer** ppContainer)
	{
		VSL_DEFINE_MOCK_METHOD(GetContainer)

		VSL_SET_VALIDVALUE_INTERFACE(ppContainer);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowObjectValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ShowObject)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ShowObject)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnShowWindowValidValues
	{
		/*[in]*/ BOOL fShow;
		HRESULT retValue;
	};

	STDMETHOD(OnShowWindow)(
		/*[in]*/ BOOL fShow)
	{
		VSL_DEFINE_MOCK_METHOD(OnShowWindow)

		VSL_CHECK_VALIDVALUE(fShow);

		VSL_RETURN_VALIDVALUES();
	}
	struct RequestNewObjectLayoutValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RequestNewObjectLayout)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RequestNewObjectLayout)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLECLIENTSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
