/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLEOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLEOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IOleObjectNotImpl :
	public IOleObject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleObjectNotImpl)

public:

	typedef IOleObject Interface;

	STDMETHOD(SetClientSite)(
		/*[in,unique]*/ IOleClientSite* /*pClientSite*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClientSite)(
		/*[out]*/ IOleClientSite** /*ppClientSite*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetHostNames)(
		/*[in]*/ LPCOLESTR /*szContainerApp*/,
		/*[in,unique]*/ LPCOLESTR /*szContainerObj*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)(
		/*[in]*/ DWORD /*dwSaveOption*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetMoniker)(
		/*[in]*/ DWORD /*dwWhichMoniker*/,
		/*[in,unique]*/ IMoniker* /*pmk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMoniker)(
		/*[in]*/ DWORD /*dwAssign*/,
		/*[in]*/ DWORD /*dwWhichMoniker*/,
		/*[out]*/ IMoniker** /*ppmk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InitFromData)(
		/*[in,unique]*/ IDataObject* /*pDataObject*/,
		/*[in]*/ BOOL /*fCreation*/,
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClipboardData)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[out]*/ IDataObject** /*ppDataObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DoVerb)(
		/*[in]*/ LONG /*iVerb*/,
		/*[in,unique]*/ LPMSG /*lpmsg*/,
		/*[in,unique]*/ IOleClientSite* /*pActiveSite*/,
		/*[in]*/ LONG /*lindex*/,
		/*[in]*/ HWND /*hwndParent*/,
		/*[in,unique]*/ LPCRECT /*lprcPosRect*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumVerbs)(
		/*[out]*/ IEnumOLEVERB** /*ppEnumOleVerb*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Update)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsUpToDate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUserClassID)(
		/*[out]*/ CLSID* /*pClsid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUserType)(
		/*[in]*/ DWORD /*dwFormOfType*/,
		/*[out]*/ LPOLESTR* /*pszUserType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetExtent)(
		/*[in]*/ DWORD /*dwDrawAspect*/,
		/*[in]*/ SIZEL* /*psizel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExtent)(
		/*[in]*/ DWORD /*dwDrawAspect*/,
		/*[out]*/ SIZEL* /*psizel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Advise)(
		/*[in,unique]*/ IAdviseSink* /*pAdvSink*/,
		/*[out]*/ DWORD* /*pdwConnection*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Unadvise)(
		/*[in]*/ DWORD /*dwConnection*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumAdvise)(
		/*[out]*/ IEnumSTATDATA** /*ppenumAdvise*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMiscStatus)(
		/*[in]*/ DWORD /*dwAspect*/,
		/*[out]*/ DWORD* /*pdwStatus*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetColorScheme)(
		/*[in]*/ LOGPALETTE* /*pLogpal*/)VSL_STDMETHOD_NOTIMPL
};

class IOleObjectMockImpl :
	public IOleObject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleObjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleObjectMockImpl)

	typedef IOleObject Interface;
	struct SetClientSiteValidValues
	{
		/*[in,unique]*/ IOleClientSite* pClientSite;
		HRESULT retValue;
	};

	STDMETHOD(SetClientSite)(
		/*[in,unique]*/ IOleClientSite* pClientSite)
	{
		VSL_DEFINE_MOCK_METHOD(SetClientSite)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pClientSite);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetClientSiteValidValues
	{
		/*[out]*/ IOleClientSite** ppClientSite;
		HRESULT retValue;
	};

	STDMETHOD(GetClientSite)(
		/*[out]*/ IOleClientSite** ppClientSite)
	{
		VSL_DEFINE_MOCK_METHOD(GetClientSite)

		VSL_SET_VALIDVALUE_INTERFACE(ppClientSite);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetHostNamesValidValues
	{
		/*[in]*/ LPCOLESTR szContainerApp;
		/*[in,unique]*/ LPCOLESTR szContainerObj;
		HRESULT retValue;
	};

	STDMETHOD(SetHostNames)(
		/*[in]*/ LPCOLESTR szContainerApp,
		/*[in,unique]*/ LPCOLESTR szContainerObj)
	{
		VSL_DEFINE_MOCK_METHOD(SetHostNames)

		VSL_CHECK_VALIDVALUE_STRINGW(szContainerApp);

		VSL_CHECK_VALIDVALUE_STRINGW(szContainerObj);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseValidValues
	{
		/*[in]*/ DWORD dwSaveOption;
		HRESULT retValue;
	};

	STDMETHOD(Close)(
		/*[in]*/ DWORD dwSaveOption)
	{
		VSL_DEFINE_MOCK_METHOD(Close)

		VSL_CHECK_VALIDVALUE(dwSaveOption);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetMonikerValidValues
	{
		/*[in]*/ DWORD dwWhichMoniker;
		/*[in,unique]*/ IMoniker* pmk;
		HRESULT retValue;
	};

	STDMETHOD(SetMoniker)(
		/*[in]*/ DWORD dwWhichMoniker,
		/*[in,unique]*/ IMoniker* pmk)
	{
		VSL_DEFINE_MOCK_METHOD(SetMoniker)

		VSL_CHECK_VALIDVALUE(dwWhichMoniker);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmk);

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
	struct InitFromDataValidValues
	{
		/*[in,unique]*/ IDataObject* pDataObject;
		/*[in]*/ BOOL fCreation;
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(InitFromData)(
		/*[in,unique]*/ IDataObject* pDataObject,
		/*[in]*/ BOOL fCreation,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(InitFromData)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDataObject);

		VSL_CHECK_VALIDVALUE(fCreation);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetClipboardDataValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[out]*/ IDataObject** ppDataObject;
		HRESULT retValue;
	};

	STDMETHOD(GetClipboardData)(
		/*[in]*/ DWORD dwReserved,
		/*[out]*/ IDataObject** ppDataObject)
	{
		VSL_DEFINE_MOCK_METHOD(GetClipboardData)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_SET_VALIDVALUE_INTERFACE(ppDataObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct DoVerbValidValues
	{
		/*[in]*/ LONG iVerb;
		/*[in,unique]*/ LPMSG lpmsg;
		/*[in,unique]*/ IOleClientSite* pActiveSite;
		/*[in]*/ LONG lindex;
		/*[in]*/ HWND hwndParent;
		/*[in,unique]*/ LPCRECT lprcPosRect;
		HRESULT retValue;
	};

	STDMETHOD(DoVerb)(
		/*[in]*/ LONG iVerb,
		/*[in,unique]*/ LPMSG lpmsg,
		/*[in,unique]*/ IOleClientSite* pActiveSite,
		/*[in]*/ LONG lindex,
		/*[in]*/ HWND hwndParent,
		/*[in,unique]*/ LPCRECT lprcPosRect)
	{
		VSL_DEFINE_MOCK_METHOD(DoVerb)

		VSL_CHECK_VALIDVALUE(iVerb);

		VSL_CHECK_VALIDVALUE(lpmsg);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pActiveSite);

		VSL_CHECK_VALIDVALUE(lindex);

		VSL_CHECK_VALIDVALUE(hwndParent);

		VSL_CHECK_VALIDVALUE(lprcPosRect);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumVerbsValidValues
	{
		/*[out]*/ IEnumOLEVERB** ppEnumOleVerb;
		HRESULT retValue;
	};

	STDMETHOD(EnumVerbs)(
		/*[out]*/ IEnumOLEVERB** ppEnumOleVerb)
	{
		VSL_DEFINE_MOCK_METHOD(EnumVerbs)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnumOleVerb);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Update)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Update)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsUpToDateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsUpToDate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsUpToDate)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUserClassIDValidValues
	{
		/*[out]*/ CLSID* pClsid;
		HRESULT retValue;
	};

	STDMETHOD(GetUserClassID)(
		/*[out]*/ CLSID* pClsid)
	{
		VSL_DEFINE_MOCK_METHOD(GetUserClassID)

		VSL_SET_VALIDVALUE(pClsid);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUserTypeValidValues
	{
		/*[in]*/ DWORD dwFormOfType;
		/*[out]*/ LPOLESTR* pszUserType;
		HRESULT retValue;
	};

	STDMETHOD(GetUserType)(
		/*[in]*/ DWORD dwFormOfType,
		/*[out]*/ LPOLESTR* pszUserType)
	{
		VSL_DEFINE_MOCK_METHOD(GetUserType)

		VSL_CHECK_VALIDVALUE(dwFormOfType);

		VSL_SET_VALIDVALUE(pszUserType);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetExtentValidValues
	{
		/*[in]*/ DWORD dwDrawAspect;
		/*[in]*/ SIZEL* psizel;
		HRESULT retValue;
	};

	STDMETHOD(SetExtent)(
		/*[in]*/ DWORD dwDrawAspect,
		/*[in]*/ SIZEL* psizel)
	{
		VSL_DEFINE_MOCK_METHOD(SetExtent)

		VSL_CHECK_VALIDVALUE(dwDrawAspect);

		VSL_CHECK_VALIDVALUE_POINTER(psizel);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExtentValidValues
	{
		/*[in]*/ DWORD dwDrawAspect;
		/*[out]*/ SIZEL* psizel;
		HRESULT retValue;
	};

	STDMETHOD(GetExtent)(
		/*[in]*/ DWORD dwDrawAspect,
		/*[out]*/ SIZEL* psizel)
	{
		VSL_DEFINE_MOCK_METHOD(GetExtent)

		VSL_CHECK_VALIDVALUE(dwDrawAspect);

		VSL_SET_VALIDVALUE(psizel);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseValidValues
	{
		/*[in,unique]*/ IAdviseSink* pAdvSink;
		/*[out]*/ DWORD* pdwConnection;
		HRESULT retValue;
	};

	STDMETHOD(Advise)(
		/*[in,unique]*/ IAdviseSink* pAdvSink,
		/*[out]*/ DWORD* pdwConnection)
	{
		VSL_DEFINE_MOCK_METHOD(Advise)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pAdvSink);

		VSL_SET_VALIDVALUE(pdwConnection);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseValidValues
	{
		/*[in]*/ DWORD dwConnection;
		HRESULT retValue;
	};

	STDMETHOD(Unadvise)(
		/*[in]*/ DWORD dwConnection)
	{
		VSL_DEFINE_MOCK_METHOD(Unadvise)

		VSL_CHECK_VALIDVALUE(dwConnection);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumAdviseValidValues
	{
		/*[out]*/ IEnumSTATDATA** ppenumAdvise;
		HRESULT retValue;
	};

	STDMETHOD(EnumAdvise)(
		/*[out]*/ IEnumSTATDATA** ppenumAdvise)
	{
		VSL_DEFINE_MOCK_METHOD(EnumAdvise)

		VSL_SET_VALIDVALUE_INTERFACE(ppenumAdvise);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMiscStatusValidValues
	{
		/*[in]*/ DWORD dwAspect;
		/*[out]*/ DWORD* pdwStatus;
		HRESULT retValue;
	};

	STDMETHOD(GetMiscStatus)(
		/*[in]*/ DWORD dwAspect,
		/*[out]*/ DWORD* pdwStatus)
	{
		VSL_DEFINE_MOCK_METHOD(GetMiscStatus)

		VSL_CHECK_VALIDVALUE(dwAspect);

		VSL_SET_VALIDVALUE(pdwStatus);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetColorSchemeValidValues
	{
		/*[in]*/ LOGPALETTE* pLogpal;
		HRESULT retValue;
	};

	STDMETHOD(SetColorScheme)(
		/*[in]*/ LOGPALETTE* pLogpal)
	{
		VSL_DEFINE_MOCK_METHOD(SetColorScheme)

		VSL_CHECK_VALIDVALUE_POINTER(pLogpal);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLEOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
