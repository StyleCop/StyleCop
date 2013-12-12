/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUSERCONTEXTITEMPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUSERCONTEXTITEMPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsUserContextItemProviderNotImpl :
	public IVsUserContextItemProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserContextItemProviderNotImpl)

public:

	typedef IVsUserContextItemProvider Interface;

	STDMETHOD(GetProperty)(
		/*[in]*/ VSCIPPROPID /*property*/,
		/*[out,retval]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetProperty)(
		/*[in]*/ VSCIPPROPID /*property*/,
		/*[in]*/ VARIANT /*var*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(KeywordLookup)(
		/*[in]*/ LPCOLESTR /*pwzTargetAttr*/,
		/*[in]*/ LPCOLESTR /*pwzTargetAttrValue*/,
		/*[out]*/ IVsUserContextItemCollection** /*ppList*/,
		/*[in]*/ IVsMonitorUserContext* /*pCMUC*/,
		/*[in]*/ BOOL /*fCheckIdle*/,
		/*[in]*/ BOOL /*fContinueInterrupt*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PackedAttributeLookup)(
		/*[in]*/ LPCOLESTR /*pwzRequired*/,
		/*[in]*/ LPCOLESTR /*pwzScope*/,
		/*[out]*/ IVsUserContextItemCollection** /*ppList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LookupEnabled)(
		/*[out]*/ BOOL* /*pfLookupEnabled*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUserContextItemProviderMockImpl :
	public IVsUserContextItemProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserContextItemProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUserContextItemProviderMockImpl)

	typedef IVsUserContextItemProvider Interface;
	struct GetPropertyValidValues
	{
		/*[in]*/ VSCIPPROPID property;
		/*[out,retval]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetProperty)(
		/*[in]*/ VSCIPPROPID property,
		/*[out,retval]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetProperty)

		VSL_CHECK_VALIDVALUE(property);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPropertyValidValues
	{
		/*[in]*/ VSCIPPROPID property;
		/*[in]*/ VARIANT var;
		HRESULT retValue;
	};

	STDMETHOD(SetProperty)(
		/*[in]*/ VSCIPPROPID property,
		/*[in]*/ VARIANT var)
	{
		VSL_DEFINE_MOCK_METHOD(SetProperty)

		VSL_CHECK_VALIDVALUE(property);

		VSL_CHECK_VALIDVALUE(var);

		VSL_RETURN_VALIDVALUES();
	}
	struct KeywordLookupValidValues
	{
		/*[in]*/ LPCOLESTR pwzTargetAttr;
		/*[in]*/ LPCOLESTR pwzTargetAttrValue;
		/*[out]*/ IVsUserContextItemCollection** ppList;
		/*[in]*/ IVsMonitorUserContext* pCMUC;
		/*[in]*/ BOOL fCheckIdle;
		/*[in]*/ BOOL fContinueInterrupt;
		HRESULT retValue;
	};

	STDMETHOD(KeywordLookup)(
		/*[in]*/ LPCOLESTR pwzTargetAttr,
		/*[in]*/ LPCOLESTR pwzTargetAttrValue,
		/*[out]*/ IVsUserContextItemCollection** ppList,
		/*[in]*/ IVsMonitorUserContext* pCMUC,
		/*[in]*/ BOOL fCheckIdle,
		/*[in]*/ BOOL fContinueInterrupt)
	{
		VSL_DEFINE_MOCK_METHOD(KeywordLookup)

		VSL_CHECK_VALIDVALUE_STRINGW(pwzTargetAttr);

		VSL_CHECK_VALIDVALUE_STRINGW(pwzTargetAttrValue);

		VSL_SET_VALIDVALUE_INTERFACE(ppList);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCMUC);

		VSL_CHECK_VALIDVALUE(fCheckIdle);

		VSL_CHECK_VALIDVALUE(fContinueInterrupt);

		VSL_RETURN_VALIDVALUES();
	}
	struct PackedAttributeLookupValidValues
	{
		/*[in]*/ LPCOLESTR pwzRequired;
		/*[in]*/ LPCOLESTR pwzScope;
		/*[out]*/ IVsUserContextItemCollection** ppList;
		HRESULT retValue;
	};

	STDMETHOD(PackedAttributeLookup)(
		/*[in]*/ LPCOLESTR pwzRequired,
		/*[in]*/ LPCOLESTR pwzScope,
		/*[out]*/ IVsUserContextItemCollection** ppList)
	{
		VSL_DEFINE_MOCK_METHOD(PackedAttributeLookup)

		VSL_CHECK_VALIDVALUE_STRINGW(pwzRequired);

		VSL_CHECK_VALIDVALUE_STRINGW(pwzScope);

		VSL_SET_VALIDVALUE_INTERFACE(ppList);

		VSL_RETURN_VALIDVALUES();
	}
	struct LookupEnabledValidValues
	{
		/*[out]*/ BOOL* pfLookupEnabled;
		HRESULT retValue;
	};

	STDMETHOD(LookupEnabled)(
		/*[out]*/ BOOL* pfLookupEnabled)
	{
		VSL_DEFINE_MOCK_METHOD(LookupEnabled)

		VSL_SET_VALIDVALUE(pfLookupEnabled);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUSERCONTEXTITEMPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
