/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIERARCHY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIERARCHY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsHierarchyNotImpl :
	public IVsHierarchy
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyNotImpl)

public:

	typedef IVsHierarchy Interface;

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* /*pSP*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSite)(
		/*[out]*/ IServiceProvider** /*ppSP*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryClose)(
		/*[out]*/ BOOL* /*pfCanClose*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGuidProperty)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ VSHPROPID /*propid*/,
		/*[out]*/ GUID* /*pguid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetGuidProperty)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ VSHPROPID /*propid*/,
		/*[in]*/ REFGUID /*rguid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProperty)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ VSHPROPID /*propid*/,
		/*[out]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetProperty)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ VSHPROPID /*propid*/,
		/*[in]*/ VARIANT /*var*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNestedHierarchy)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ REFIID /*iidHierarchyNested*/,
		/*[out,iid_is(iidHierarchyNested)]*/ void** /*ppHierarchyNested*/,
		/*[out]*/ VSITEMID* /*pitemidNested*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCanonicalName)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ParseCanonicalName)(
		/*[in]*/ LPCOLESTR /*pszName*/,
		/*[out]*/ VSITEMID* /*pitemid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Unused0)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseHierarchyEvents)(
		/*[in]*/ IVsHierarchyEvents* /*pEventSink*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseHierarchyEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Unused1)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Unused2)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Unused3)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Unused4)()VSL_STDMETHOD_NOTIMPL
};

class IVsHierarchyMockImpl :
	public IVsHierarchy,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHierarchyMockImpl)

	typedef IVsHierarchy Interface;
	struct SetSiteValidValues
	{
		/*[in]*/ IServiceProvider* pSP;
		HRESULT retValue;
	};

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* pSP)
	{
		VSL_DEFINE_MOCK_METHOD(SetSite)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSP);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSiteValidValues
	{
		/*[out]*/ IServiceProvider** ppSP;
		HRESULT retValue;
	};

	STDMETHOD(GetSite)(
		/*[out]*/ IServiceProvider** ppSP)
	{
		VSL_DEFINE_MOCK_METHOD(GetSite)

		VSL_SET_VALIDVALUE_INTERFACE(ppSP);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryCloseValidValues
	{
		/*[out]*/ BOOL* pfCanClose;
		HRESULT retValue;
	};

	STDMETHOD(QueryClose)(
		/*[out]*/ BOOL* pfCanClose)
	{
		VSL_DEFINE_MOCK_METHOD(QueryClose)

		VSL_SET_VALIDVALUE(pfCanClose);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Close)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Close)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetGuidPropertyValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ VSHPROPID propid;
		/*[out]*/ GUID* pguid;
		HRESULT retValue;
	};

	STDMETHOD(GetGuidProperty)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ VSHPROPID propid,
		/*[out]*/ GUID* pguid)
	{
		VSL_DEFINE_MOCK_METHOD(GetGuidProperty)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE(pguid);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetGuidPropertyValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ VSHPROPID propid;
		/*[in]*/ REFGUID rguid;
		HRESULT retValue;
	};

	STDMETHOD(SetGuidProperty)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ VSHPROPID propid,
		/*[in]*/ REFGUID rguid)
	{
		VSL_DEFINE_MOCK_METHOD(SetGuidProperty)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(propid);

		VSL_CHECK_VALIDVALUE(rguid);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPropertyValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ VSHPROPID propid;
		/*[out]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetProperty)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ VSHPROPID propid,
		/*[out]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetProperty)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPropertyValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ VSHPROPID propid;
		/*[in]*/ VARIANT var;
		HRESULT retValue;
	};

	STDMETHOD(SetProperty)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ VSHPROPID propid,
		/*[in]*/ VARIANT var)
	{
		VSL_DEFINE_MOCK_METHOD(SetProperty)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(propid);

		VSL_CHECK_VALIDVALUE(var);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNestedHierarchyValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ REFIID iidHierarchyNested;
		/*[out,iid_is(iidHierarchyNested)]*/ void** ppHierarchyNested;
		/*[out]*/ VSITEMID* pitemidNested;
		HRESULT retValue;
	};

	STDMETHOD(GetNestedHierarchy)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ REFIID iidHierarchyNested,
		/*[out,iid_is(iidHierarchyNested)]*/ void** ppHierarchyNested,
		/*[out]*/ VSITEMID* pitemidNested)
	{
		VSL_DEFINE_MOCK_METHOD(GetNestedHierarchy)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(iidHierarchyNested);

		VSL_SET_VALIDVALUE(ppHierarchyNested);

		VSL_SET_VALIDVALUE(pitemidNested);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCanonicalNameValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetCanonicalName)(
		/*[in]*/ VSITEMID itemid,
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetCanonicalName)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct ParseCanonicalNameValidValues
	{
		/*[in]*/ LPCOLESTR pszName;
		/*[out]*/ VSITEMID* pitemid;
		HRESULT retValue;
	};

	STDMETHOD(ParseCanonicalName)(
		/*[in]*/ LPCOLESTR pszName,
		/*[out]*/ VSITEMID* pitemid)
	{
		VSL_DEFINE_MOCK_METHOD(ParseCanonicalName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszName);

		VSL_SET_VALIDVALUE(pitemid);

		VSL_RETURN_VALIDVALUES();
	}
	struct Unused0ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Unused0)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Unused0)

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseHierarchyEventsValidValues
	{
		/*[in]*/ IVsHierarchyEvents* pEventSink;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseHierarchyEvents)(
		/*[in]*/ IVsHierarchyEvents* pEventSink,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseHierarchyEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pEventSink);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseHierarchyEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseHierarchyEvents)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseHierarchyEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct Unused1ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Unused1)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Unused1)

		VSL_RETURN_VALIDVALUES();
	}
	struct Unused2ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Unused2)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Unused2)

		VSL_RETURN_VALIDVALUES();
	}
	struct Unused3ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Unused3)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Unused3)

		VSL_RETURN_VALIDVALUES();
	}
	struct Unused4ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Unused4)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Unused4)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHIERARCHY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
