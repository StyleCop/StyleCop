/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPROPERTY2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPROPERTY2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugProperty2NotImpl :
	public IDebugProperty2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProperty2NotImpl)

public:

	typedef IDebugProperty2 Interface;

	STDMETHOD(GetPropertyInfo)(
		/*[in]*/ DEBUGPROP_INFO_FLAGS /*dwFields*/,
		/*[in]*/ DWORD /*dwRadix*/,
		/*[in]*/ DWORD /*dwTimeout*/,
		/*[in,ptr,size_is(dwArgCount),length_is(dwArgCount)]*/ IDebugReference2** /*rgpArgs*/,
		/*[in]*/ DWORD /*dwArgCount*/,
		/*[out]*/ DEBUG_PROPERTY_INFO* /*pPropertyInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetValueAsString)(
		/*[in]*/ LPCOLESTR /*pszValue*/,
		/*[in]*/ DWORD /*dwRadix*/,
		/*[in]*/ DWORD /*dwTimeout*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetValueAsReference)(
		/*[in,ptr,size_is(dwArgCount),length_is(dwArgCount)]*/ IDebugReference2** /*rgpArgs*/,
		/*[in]*/ DWORD /*dwArgCount*/,
		/*[in]*/ IDebugReference2* /*pValue*/,
		/*[in]*/ DWORD /*dwTimeout*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumChildren)(
		/*[in]*/ DEBUGPROP_INFO_FLAGS /*dwFields*/,
		/*[in]*/ DWORD /*dwRadix*/,
		/*[in]*/ REFGUID /*guidFilter*/,
		/*[in]*/ DBG_ATTRIB_FLAGS /*dwAttribFilter*/,
		/*[in,ptr]*/ LPCOLESTR /*pszNameFilter*/,
		/*[in]*/ DWORD /*dwTimeout*/,
		/*[out]*/ IEnumDebugPropertyInfo2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetParent)(
		/*[out]*/ IDebugProperty2** /*ppParent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDerivedMostProperty)(
		/*[out]*/ IDebugProperty2** /*ppDerivedMost*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMemoryBytes)(
		/*[out]*/ IDebugMemoryBytes2** /*ppMemoryBytes*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMemoryContext)(
		/*[out]*/ IDebugMemoryContext2** /*ppMemory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSize)(
		/*[out]*/ DWORD* /*pdwSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetReference)(
		/*[out]*/ IDebugReference2** /*ppReference*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExtendedInfo)(
		/*[in]*/ REFGUID /*guidExtendedInfo*/,
		/*[out]*/ VARIANT* /*pExtendedInfo*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugProperty2MockImpl :
	public IDebugProperty2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProperty2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugProperty2MockImpl)

	typedef IDebugProperty2 Interface;
	struct GetPropertyInfoValidValues
	{
		/*[in]*/ DEBUGPROP_INFO_FLAGS dwFields;
		/*[in]*/ DWORD dwRadix;
		/*[in]*/ DWORD dwTimeout;
		/*[in,ptr,size_is(dwArgCount),length_is(dwArgCount)]*/ IDebugReference2** rgpArgs;
		/*[in]*/ DWORD dwArgCount;
		/*[out]*/ DEBUG_PROPERTY_INFO* pPropertyInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetPropertyInfo)(
		/*[in]*/ DEBUGPROP_INFO_FLAGS dwFields,
		/*[in]*/ DWORD dwRadix,
		/*[in]*/ DWORD dwTimeout,
		/*[in,ptr,size_is(dwArgCount),length_is(dwArgCount)]*/ IDebugReference2** rgpArgs,
		/*[in]*/ DWORD dwArgCount,
		/*[out]*/ DEBUG_PROPERTY_INFO* pPropertyInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetPropertyInfo)

		VSL_CHECK_VALIDVALUE(dwFields);

		VSL_CHECK_VALIDVALUE(dwRadix);

		VSL_CHECK_VALIDVALUE(dwTimeout);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpArgs, dwArgCount, validValues.dwArgCount);

		VSL_CHECK_VALIDVALUE(dwArgCount);

		VSL_SET_VALIDVALUE(pPropertyInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetValueAsStringValidValues
	{
		/*[in]*/ LPCOLESTR pszValue;
		/*[in]*/ DWORD dwRadix;
		/*[in]*/ DWORD dwTimeout;
		HRESULT retValue;
	};

	STDMETHOD(SetValueAsString)(
		/*[in]*/ LPCOLESTR pszValue,
		/*[in]*/ DWORD dwRadix,
		/*[in]*/ DWORD dwTimeout)
	{
		VSL_DEFINE_MOCK_METHOD(SetValueAsString)

		VSL_CHECK_VALIDVALUE_STRINGW(pszValue);

		VSL_CHECK_VALIDVALUE(dwRadix);

		VSL_CHECK_VALIDVALUE(dwTimeout);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetValueAsReferenceValidValues
	{
		/*[in,ptr,size_is(dwArgCount),length_is(dwArgCount)]*/ IDebugReference2** rgpArgs;
		/*[in]*/ DWORD dwArgCount;
		/*[in]*/ IDebugReference2* pValue;
		/*[in]*/ DWORD dwTimeout;
		HRESULT retValue;
	};

	STDMETHOD(SetValueAsReference)(
		/*[in,ptr,size_is(dwArgCount),length_is(dwArgCount)]*/ IDebugReference2** rgpArgs,
		/*[in]*/ DWORD dwArgCount,
		/*[in]*/ IDebugReference2* pValue,
		/*[in]*/ DWORD dwTimeout)
	{
		VSL_DEFINE_MOCK_METHOD(SetValueAsReference)

		VSL_CHECK_VALIDVALUE_ARRAY(rgpArgs, dwArgCount, validValues.dwArgCount);

		VSL_CHECK_VALIDVALUE(dwArgCount);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pValue);

		VSL_CHECK_VALIDVALUE(dwTimeout);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumChildrenValidValues
	{
		/*[in]*/ DEBUGPROP_INFO_FLAGS dwFields;
		/*[in]*/ DWORD dwRadix;
		/*[in]*/ REFGUID guidFilter;
		/*[in]*/ DBG_ATTRIB_FLAGS dwAttribFilter;
		/*[in,ptr]*/ LPCOLESTR pszNameFilter;
		/*[in]*/ DWORD dwTimeout;
		/*[out]*/ IEnumDebugPropertyInfo2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumChildren)(
		/*[in]*/ DEBUGPROP_INFO_FLAGS dwFields,
		/*[in]*/ DWORD dwRadix,
		/*[in]*/ REFGUID guidFilter,
		/*[in]*/ DBG_ATTRIB_FLAGS dwAttribFilter,
		/*[in,ptr]*/ LPCOLESTR pszNameFilter,
		/*[in]*/ DWORD dwTimeout,
		/*[out]*/ IEnumDebugPropertyInfo2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumChildren)

		VSL_CHECK_VALIDVALUE(dwFields);

		VSL_CHECK_VALIDVALUE(dwRadix);

		VSL_CHECK_VALIDVALUE(guidFilter);

		VSL_CHECK_VALIDVALUE(dwAttribFilter);

		VSL_CHECK_VALIDVALUE_STRINGW(pszNameFilter);

		VSL_CHECK_VALIDVALUE(dwTimeout);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParentValidValues
	{
		/*[out]*/ IDebugProperty2** ppParent;
		HRESULT retValue;
	};

	STDMETHOD(GetParent)(
		/*[out]*/ IDebugProperty2** ppParent)
	{
		VSL_DEFINE_MOCK_METHOD(GetParent)

		VSL_SET_VALIDVALUE_INTERFACE(ppParent);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDerivedMostPropertyValidValues
	{
		/*[out]*/ IDebugProperty2** ppDerivedMost;
		HRESULT retValue;
	};

	STDMETHOD(GetDerivedMostProperty)(
		/*[out]*/ IDebugProperty2** ppDerivedMost)
	{
		VSL_DEFINE_MOCK_METHOD(GetDerivedMostProperty)

		VSL_SET_VALIDVALUE_INTERFACE(ppDerivedMost);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMemoryBytesValidValues
	{
		/*[out]*/ IDebugMemoryBytes2** ppMemoryBytes;
		HRESULT retValue;
	};

	STDMETHOD(GetMemoryBytes)(
		/*[out]*/ IDebugMemoryBytes2** ppMemoryBytes)
	{
		VSL_DEFINE_MOCK_METHOD(GetMemoryBytes)

		VSL_SET_VALIDVALUE_INTERFACE(ppMemoryBytes);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMemoryContextValidValues
	{
		/*[out]*/ IDebugMemoryContext2** ppMemory;
		HRESULT retValue;
	};

	STDMETHOD(GetMemoryContext)(
		/*[out]*/ IDebugMemoryContext2** ppMemory)
	{
		VSL_DEFINE_MOCK_METHOD(GetMemoryContext)

		VSL_SET_VALIDVALUE_INTERFACE(ppMemory);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSizeValidValues
	{
		/*[out]*/ DWORD* pdwSize;
		HRESULT retValue;
	};

	STDMETHOD(GetSize)(
		/*[out]*/ DWORD* pdwSize)
	{
		VSL_DEFINE_MOCK_METHOD(GetSize)

		VSL_SET_VALIDVALUE(pdwSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetReferenceValidValues
	{
		/*[out]*/ IDebugReference2** ppReference;
		HRESULT retValue;
	};

	STDMETHOD(GetReference)(
		/*[out]*/ IDebugReference2** ppReference)
	{
		VSL_DEFINE_MOCK_METHOD(GetReference)

		VSL_SET_VALIDVALUE_INTERFACE(ppReference);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExtendedInfoValidValues
	{
		/*[in]*/ REFGUID guidExtendedInfo;
		/*[out]*/ VARIANT* pExtendedInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetExtendedInfo)(
		/*[in]*/ REFGUID guidExtendedInfo,
		/*[out]*/ VARIANT* pExtendedInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetExtendedInfo)

		VSL_CHECK_VALIDVALUE(guidExtendedInfo);

		VSL_SET_VALIDVALUE_VARIANT(pExtendedInfo);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPROPERTY2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
