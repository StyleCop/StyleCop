/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBBROWSINGSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBBROWSINGSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsbrowse.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsWebBrowsingServiceNotImpl :
	public IVsWebBrowsingService
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebBrowsingServiceNotImpl)

public:

	typedef IVsWebBrowsingService Interface;

	STDMETHOD(CreateWebBrowser)(
		/*[in]*/ VSCREATEWEBBROWSER /*dwCreateFlags*/,
		/*[in]*/ REFGUID /*rguidOwner*/,
		/*[in]*/ LPCOLESTR /*lpszBaseCaption*/,
		/*[in]*/ LPCOLESTR /*lpszStartURL*/,
		/*[in]*/ IVsWebBrowserUser* /*pUser*/,
		/*[out]*/ IVsWebBrowser** /*ppBrowser*/,
		/*[out]*/ IVsWindowFrame** /*ppFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFirstWebBrowser)(
		/*[in]*/ REFGUID /*rguidPersistenceSlot*/,
		/*[out]*/ IVsWindowFrame** /*ppFrame*/,
		/*[out]*/ IVsWebBrowser** /*ppBrowser*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWebBrowserEnum)(
		/*[in]*/ REFGUID /*rguidPersistenceSlot*/,
		/*[out]*/ IEnumWindowFrames** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateExternalWebBrowser)(
		/*[in]*/ VSCREATEWEBBROWSER /*dwCreateFlags*/,
		/*[in]*/ VSPREVIEWRESOLUTION /*dwResolution*/,
		/*[in]*/ LPCOLESTR /*lpszURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateWebBrowserEx)(
		/*[in]*/ VSCREATEWEBBROWSER /*dwCreateFlags*/,
		/*[in]*/ REFGUID /*rguidPersistenceSlot*/,
		/*[in]*/ DWORD /*dwId*/,
		/*[in]*/ LPCOLESTR /*lpszBaseCaption*/,
		/*[in]*/ LPCOLESTR /*lpszStartURL*/,
		/*[in]*/ IVsWebBrowserUser* /*pUser*/,
		/*[out]*/ IVsWebBrowser** /*ppBrowser*/,
		/*[out]*/ IVsWindowFrame** /*ppFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Navigate)(
		/*[in]*/ LPCOLESTR /*lpszURL*/,
		/*[in]*/ VSWBNAVIGATEFLAGS /*dwNaviageFlags*/,
		/*[out]*/ IVsWindowFrame** /*ppFrame*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWebBrowsingServiceMockImpl :
	public IVsWebBrowsingService,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebBrowsingServiceMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWebBrowsingServiceMockImpl)

	typedef IVsWebBrowsingService Interface;
	struct CreateWebBrowserValidValues
	{
		/*[in]*/ VSCREATEWEBBROWSER dwCreateFlags;
		/*[in]*/ REFGUID rguidOwner;
		/*[in]*/ LPCOLESTR lpszBaseCaption;
		/*[in]*/ LPCOLESTR lpszStartURL;
		/*[in]*/ IVsWebBrowserUser* pUser;
		/*[out]*/ IVsWebBrowser** ppBrowser;
		/*[out]*/ IVsWindowFrame** ppFrame;
		HRESULT retValue;
	};

	STDMETHOD(CreateWebBrowser)(
		/*[in]*/ VSCREATEWEBBROWSER dwCreateFlags,
		/*[in]*/ REFGUID rguidOwner,
		/*[in]*/ LPCOLESTR lpszBaseCaption,
		/*[in]*/ LPCOLESTR lpszStartURL,
		/*[in]*/ IVsWebBrowserUser* pUser,
		/*[out]*/ IVsWebBrowser** ppBrowser,
		/*[out]*/ IVsWindowFrame** ppFrame)
	{
		VSL_DEFINE_MOCK_METHOD(CreateWebBrowser)

		VSL_CHECK_VALIDVALUE(dwCreateFlags);

		VSL_CHECK_VALIDVALUE(rguidOwner);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszBaseCaption);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszStartURL);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUser);

		VSL_SET_VALIDVALUE_INTERFACE(ppBrowser);

		VSL_SET_VALIDVALUE_INTERFACE(ppFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFirstWebBrowserValidValues
	{
		/*[in]*/ REFGUID rguidPersistenceSlot;
		/*[out]*/ IVsWindowFrame** ppFrame;
		/*[out]*/ IVsWebBrowser** ppBrowser;
		HRESULT retValue;
	};

	STDMETHOD(GetFirstWebBrowser)(
		/*[in]*/ REFGUID rguidPersistenceSlot,
		/*[out]*/ IVsWindowFrame** ppFrame,
		/*[out]*/ IVsWebBrowser** ppBrowser)
	{
		VSL_DEFINE_MOCK_METHOD(GetFirstWebBrowser)

		VSL_CHECK_VALIDVALUE(rguidPersistenceSlot);

		VSL_SET_VALIDVALUE_INTERFACE(ppFrame);

		VSL_SET_VALIDVALUE_INTERFACE(ppBrowser);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetWebBrowserEnumValidValues
	{
		/*[in]*/ REFGUID rguidPersistenceSlot;
		/*[out]*/ IEnumWindowFrames** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(GetWebBrowserEnum)(
		/*[in]*/ REFGUID rguidPersistenceSlot,
		/*[out]*/ IEnumWindowFrames** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(GetWebBrowserEnum)

		VSL_CHECK_VALIDVALUE(rguidPersistenceSlot);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateExternalWebBrowserValidValues
	{
		/*[in]*/ VSCREATEWEBBROWSER dwCreateFlags;
		/*[in]*/ VSPREVIEWRESOLUTION dwResolution;
		/*[in]*/ LPCOLESTR lpszURL;
		HRESULT retValue;
	};

	STDMETHOD(CreateExternalWebBrowser)(
		/*[in]*/ VSCREATEWEBBROWSER dwCreateFlags,
		/*[in]*/ VSPREVIEWRESOLUTION dwResolution,
		/*[in]*/ LPCOLESTR lpszURL)
	{
		VSL_DEFINE_MOCK_METHOD(CreateExternalWebBrowser)

		VSL_CHECK_VALIDVALUE(dwCreateFlags);

		VSL_CHECK_VALIDVALUE(dwResolution);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateWebBrowserExValidValues
	{
		/*[in]*/ VSCREATEWEBBROWSER dwCreateFlags;
		/*[in]*/ REFGUID rguidPersistenceSlot;
		/*[in]*/ DWORD dwId;
		/*[in]*/ LPCOLESTR lpszBaseCaption;
		/*[in]*/ LPCOLESTR lpszStartURL;
		/*[in]*/ IVsWebBrowserUser* pUser;
		/*[out]*/ IVsWebBrowser** ppBrowser;
		/*[out]*/ IVsWindowFrame** ppFrame;
		HRESULT retValue;
	};

	STDMETHOD(CreateWebBrowserEx)(
		/*[in]*/ VSCREATEWEBBROWSER dwCreateFlags,
		/*[in]*/ REFGUID rguidPersistenceSlot,
		/*[in]*/ DWORD dwId,
		/*[in]*/ LPCOLESTR lpszBaseCaption,
		/*[in]*/ LPCOLESTR lpszStartURL,
		/*[in]*/ IVsWebBrowserUser* pUser,
		/*[out]*/ IVsWebBrowser** ppBrowser,
		/*[out]*/ IVsWindowFrame** ppFrame)
	{
		VSL_DEFINE_MOCK_METHOD(CreateWebBrowserEx)

		VSL_CHECK_VALIDVALUE(dwCreateFlags);

		VSL_CHECK_VALIDVALUE(rguidPersistenceSlot);

		VSL_CHECK_VALIDVALUE(dwId);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszBaseCaption);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszStartURL);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUser);

		VSL_SET_VALIDVALUE_INTERFACE(ppBrowser);

		VSL_SET_VALIDVALUE_INTERFACE(ppFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct NavigateValidValues
	{
		/*[in]*/ LPCOLESTR lpszURL;
		/*[in]*/ VSWBNAVIGATEFLAGS dwNaviageFlags;
		/*[out]*/ IVsWindowFrame** ppFrame;
		HRESULT retValue;
	};

	STDMETHOD(Navigate)(
		/*[in]*/ LPCOLESTR lpszURL,
		/*[in]*/ VSWBNAVIGATEFLAGS dwNaviageFlags,
		/*[out]*/ IVsWindowFrame** ppFrame)
	{
		VSL_DEFINE_MOCK_METHOD(Navigate)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszURL);

		VSL_CHECK_VALIDVALUE(dwNaviageFlags);

		VSL_SET_VALIDVALUE_INTERFACE(ppFrame);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBBROWSINGSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
