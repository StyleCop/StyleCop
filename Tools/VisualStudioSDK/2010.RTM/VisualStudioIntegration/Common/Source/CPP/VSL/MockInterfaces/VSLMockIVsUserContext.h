/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUSERCONTEXT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUSERCONTEXT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "context.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsUserContextNotImpl :
	public IVsUserContext
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserContextNotImpl)

public:

	typedef IVsUserContext Interface;

	STDMETHOD(AddAttribute)(
		/*[in]*/ VSUSERCONTEXTATTRIBUTEUSAGE /*usage*/,
		/*[in]*/ LPCOLESTR /*szName*/,
		/*[in]*/ LPCOLESTR /*szValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveAttribute)(
		/*[in]*/ LPCOLESTR /*szName*/,
		/*[in]*/ LPCOLESTR /*szValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddSubcontext)(
		/*[in]*/ IVsUserContext* /*pSubCtx*/,
		/*[in]*/ int /*lPriority*/,
		/*[out,retval]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveSubcontext)(
		/*[in]*/ VSCOOKIE /*dwcookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CountAttributes)(
		/*[in]*/ LPCOLESTR /*pszName*/,
		/*[in]*/ BOOL /*fIncludeChildren*/,
		/*[out,retval]*/ int* /*pc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAttribute)(
		/*[in]*/ int /*iAttribute*/,
		/*[in]*/ LPCOLESTR /*pszName*/,
		/*[in]*/ BOOL /*fIncludeChildren*/,
		/*[out]*/ BSTR* /*pbstrName*/,
		/*[out,retval]*/ BSTR* /*pbstrValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CountSubcontexts)(
		/*[out,retval]*/ int* /*pc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSubcontext)(
		/*[in]*/ int /*i*/,
		/*[out,retval]*/ IVsUserContext** /*ppSubCtx*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsDirty)(
		/*[out,retval]*/ BOOL* /*pfDirty*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDirty)(
		/*[in]*/ BOOL /*fDirty*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Update)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseUpdate)(
		/*[in]*/ IVsUserContextUpdate* /*pUpdate*/,
		/*[out,retval]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseUpdate)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAttrUsage)(
		/*[in]*/ int /*index*/,
		/*[in]*/ BOOL /*fIncludeChildren*/,
		/*[out,retval]*/ VSUSERCONTEXTATTRIBUTEUSAGE* /*pUsage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveAllSubcontext)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPriority)(
		/*[out,retval]*/ int* /*lPriority*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveAttributeIncludeChildren)(
		/*[in]*/ LPCOLESTR /*szName*/,
		/*[in]*/ LPCOLESTR /*szValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAttributePri)(
		/*[in]*/ int /*iAttribute*/,
		/*[in]*/ LPCOLESTR /*pszName*/,
		/*[in]*/ BOOL /*fIncludeChildren*/,
		/*[out]*/ int* /*piPriority*/,
		/*[out]*/ BSTR* /*pbstrName*/,
		/*[out,retval]*/ BSTR* /*pbstrValue*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUserContextMockImpl :
	public IVsUserContext,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserContextMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUserContextMockImpl)

	typedef IVsUserContext Interface;
	struct AddAttributeValidValues
	{
		/*[in]*/ VSUSERCONTEXTATTRIBUTEUSAGE usage;
		/*[in]*/ LPCOLESTR szName;
		/*[in]*/ LPCOLESTR szValue;
		HRESULT retValue;
	};

	STDMETHOD(AddAttribute)(
		/*[in]*/ VSUSERCONTEXTATTRIBUTEUSAGE usage,
		/*[in]*/ LPCOLESTR szName,
		/*[in]*/ LPCOLESTR szValue)
	{
		VSL_DEFINE_MOCK_METHOD(AddAttribute)

		VSL_CHECK_VALIDVALUE(usage);

		VSL_CHECK_VALIDVALUE_STRINGW(szName);

		VSL_CHECK_VALIDVALUE_STRINGW(szValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveAttributeValidValues
	{
		/*[in]*/ LPCOLESTR szName;
		/*[in]*/ LPCOLESTR szValue;
		HRESULT retValue;
	};

	STDMETHOD(RemoveAttribute)(
		/*[in]*/ LPCOLESTR szName,
		/*[in]*/ LPCOLESTR szValue)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveAttribute)

		VSL_CHECK_VALIDVALUE_STRINGW(szName);

		VSL_CHECK_VALIDVALUE_STRINGW(szValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddSubcontextValidValues
	{
		/*[in]*/ IVsUserContext* pSubCtx;
		/*[in]*/ int lPriority;
		/*[out,retval]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AddSubcontext)(
		/*[in]*/ IVsUserContext* pSubCtx,
		/*[in]*/ int lPriority,
		/*[out,retval]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AddSubcontext)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSubCtx);

		VSL_CHECK_VALIDVALUE(lPriority);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveSubcontextValidValues
	{
		/*[in]*/ VSCOOKIE dwcookie;
		HRESULT retValue;
	};

	STDMETHOD(RemoveSubcontext)(
		/*[in]*/ VSCOOKIE dwcookie)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveSubcontext)

		VSL_CHECK_VALIDVALUE(dwcookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct CountAttributesValidValues
	{
		/*[in]*/ LPCOLESTR pszName;
		/*[in]*/ BOOL fIncludeChildren;
		/*[out,retval]*/ int* pc;
		HRESULT retValue;
	};

	STDMETHOD(CountAttributes)(
		/*[in]*/ LPCOLESTR pszName,
		/*[in]*/ BOOL fIncludeChildren,
		/*[out,retval]*/ int* pc)
	{
		VSL_DEFINE_MOCK_METHOD(CountAttributes)

		VSL_CHECK_VALIDVALUE_STRINGW(pszName);

		VSL_CHECK_VALIDVALUE(fIncludeChildren);

		VSL_SET_VALIDVALUE(pc);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAttributeValidValues
	{
		/*[in]*/ int iAttribute;
		/*[in]*/ LPCOLESTR pszName;
		/*[in]*/ BOOL fIncludeChildren;
		/*[out]*/ BSTR* pbstrName;
		/*[out,retval]*/ BSTR* pbstrValue;
		HRESULT retValue;
	};

	STDMETHOD(GetAttribute)(
		/*[in]*/ int iAttribute,
		/*[in]*/ LPCOLESTR pszName,
		/*[in]*/ BOOL fIncludeChildren,
		/*[out]*/ BSTR* pbstrName,
		/*[out,retval]*/ BSTR* pbstrValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetAttribute)

		VSL_CHECK_VALIDVALUE(iAttribute);

		VSL_CHECK_VALIDVALUE_STRINGW(pszName);

		VSL_CHECK_VALIDVALUE(fIncludeChildren);

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_SET_VALIDVALUE_BSTR(pbstrValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct CountSubcontextsValidValues
	{
		/*[out,retval]*/ int* pc;
		HRESULT retValue;
	};

	STDMETHOD(CountSubcontexts)(
		/*[out,retval]*/ int* pc)
	{
		VSL_DEFINE_MOCK_METHOD(CountSubcontexts)

		VSL_SET_VALIDVALUE(pc);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSubcontextValidValues
	{
		/*[in]*/ int i;
		/*[out,retval]*/ IVsUserContext** ppSubCtx;
		HRESULT retValue;
	};

	STDMETHOD(GetSubcontext)(
		/*[in]*/ int i,
		/*[out,retval]*/ IVsUserContext** ppSubCtx)
	{
		VSL_DEFINE_MOCK_METHOD(GetSubcontext)

		VSL_CHECK_VALIDVALUE(i);

		VSL_SET_VALIDVALUE_INTERFACE(ppSubCtx);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsDirtyValidValues
	{
		/*[out,retval]*/ BOOL* pfDirty;
		HRESULT retValue;
	};

	STDMETHOD(IsDirty)(
		/*[out,retval]*/ BOOL* pfDirty)
	{
		VSL_DEFINE_MOCK_METHOD(IsDirty)

		VSL_SET_VALIDVALUE(pfDirty);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDirtyValidValues
	{
		/*[in]*/ BOOL fDirty;
		HRESULT retValue;
	};

	STDMETHOD(SetDirty)(
		/*[in]*/ BOOL fDirty)
	{
		VSL_DEFINE_MOCK_METHOD(SetDirty)

		VSL_CHECK_VALIDVALUE(fDirty);

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
	struct AdviseUpdateValidValues
	{
		/*[in]*/ IVsUserContextUpdate* pUpdate;
		/*[out,retval]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseUpdate)(
		/*[in]*/ IVsUserContextUpdate* pUpdate,
		/*[out,retval]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseUpdate)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUpdate);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseUpdateValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseUpdate)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseUpdate)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAttrUsageValidValues
	{
		/*[in]*/ int index;
		/*[in]*/ BOOL fIncludeChildren;
		/*[out,retval]*/ VSUSERCONTEXTATTRIBUTEUSAGE* pUsage;
		HRESULT retValue;
	};

	STDMETHOD(GetAttrUsage)(
		/*[in]*/ int index,
		/*[in]*/ BOOL fIncludeChildren,
		/*[out,retval]*/ VSUSERCONTEXTATTRIBUTEUSAGE* pUsage)
	{
		VSL_DEFINE_MOCK_METHOD(GetAttrUsage)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE(fIncludeChildren);

		VSL_SET_VALIDVALUE(pUsage);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveAllSubcontextValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RemoveAllSubcontext)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RemoveAllSubcontext)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPriorityValidValues
	{
		/*[out,retval]*/ int* lPriority;
		HRESULT retValue;
	};

	STDMETHOD(GetPriority)(
		/*[out,retval]*/ int* lPriority)
	{
		VSL_DEFINE_MOCK_METHOD(GetPriority)

		VSL_SET_VALIDVALUE(lPriority);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveAttributeIncludeChildrenValidValues
	{
		/*[in]*/ LPCOLESTR szName;
		/*[in]*/ LPCOLESTR szValue;
		HRESULT retValue;
	};

	STDMETHOD(RemoveAttributeIncludeChildren)(
		/*[in]*/ LPCOLESTR szName,
		/*[in]*/ LPCOLESTR szValue)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveAttributeIncludeChildren)

		VSL_CHECK_VALIDVALUE_STRINGW(szName);

		VSL_CHECK_VALIDVALUE_STRINGW(szValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAttributePriValidValues
	{
		/*[in]*/ int iAttribute;
		/*[in]*/ LPCOLESTR pszName;
		/*[in]*/ BOOL fIncludeChildren;
		/*[out]*/ int* piPriority;
		/*[out]*/ BSTR* pbstrName;
		/*[out,retval]*/ BSTR* pbstrValue;
		HRESULT retValue;
	};

	STDMETHOD(GetAttributePri)(
		/*[in]*/ int iAttribute,
		/*[in]*/ LPCOLESTR pszName,
		/*[in]*/ BOOL fIncludeChildren,
		/*[out]*/ int* piPriority,
		/*[out]*/ BSTR* pbstrName,
		/*[out,retval]*/ BSTR* pbstrValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetAttributePri)

		VSL_CHECK_VALIDVALUE(iAttribute);

		VSL_CHECK_VALIDVALUE_STRINGW(pszName);

		VSL_CHECK_VALIDVALUE(fIncludeChildren);

		VSL_SET_VALIDVALUE(piPriority);

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_SET_VALIDVALUE_BSTR(pbstrValue);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUSERCONTEXT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
