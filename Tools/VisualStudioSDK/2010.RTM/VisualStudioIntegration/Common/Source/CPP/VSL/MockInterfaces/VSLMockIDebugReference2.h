/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGREFERENCE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGREFERENCE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugReference2NotImpl :
	public IDebugReference2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugReference2NotImpl)

public:

	typedef IDebugReference2 Interface;

	STDMETHOD(GetReferenceInfo)(
		/*[in]*/ DEBUGREF_INFO_FLAGS /*dwFields*/,
		/*[in]*/ DWORD /*dwRadix*/,
		/*[in]*/ DWORD /*dwTimeout*/,
		/*[in,size_is(dwArgCount),length_is(dwArgCount)]*/ IDebugReference2** /*rgpArgs*/,
		/*[in]*/ DWORD /*dwArgCount*/,
		/*[out]*/ DEBUG_REFERENCE_INFO* /*pReferenceInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetValueAsString)(
		/*[in]*/ LPCOLESTR /*pszValue*/,
		/*[in]*/ DWORD /*dwRadix*/,
		/*[in]*/ DWORD /*dwTimeout*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetValueAsReference)(
		/*[in,size_is(dwArgCount),length_is(dwArgCount)]*/ IDebugReference2** /*rgpArgs*/,
		/*[in]*/ DWORD /*dwArgCount*/,
		/*[in]*/ IDebugReference2* /*pValue*/,
		/*[in]*/ DWORD /*dwTimeout*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumChildren)(
		/*[in]*/ DEBUGREF_INFO_FLAGS /*dwFields*/,
		/*[in]*/ DWORD /*dwRadix*/,
		/*[in]*/ DBG_ATTRIB_FLAGS /*dwAttribFilter*/,
		/*[in,ptr]*/ LPCOLESTR /*pszNameFilter*/,
		/*[in]*/ DWORD /*dwTimeout*/,
		/*[out]*/ IEnumDebugReferenceInfo2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetParent)(
		/*[out]*/ IDebugReference2** /*ppParent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDerivedMostReference)(
		/*[out]*/ IDebugReference2** /*ppDerivedMost*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMemoryBytes)(
		/*[out]*/ IDebugMemoryBytes2** /*ppMemoryBytes*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMemoryContext)(
		/*[out]*/ IDebugMemoryContext2** /*ppMemory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSize)(
		/*[out]*/ DWORD* /*pdwSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetReferenceType)(
		/*[in]*/ REFERENCE_TYPE /*dwRefType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Compare)(
		/*[in]*/ REFERENCE_COMPARE /*dwCompare*/,
		/*[in]*/ IDebugReference2* /*pReference*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugReference2MockImpl :
	public IDebugReference2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugReference2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugReference2MockImpl)

	typedef IDebugReference2 Interface;
	struct GetReferenceInfoValidValues
	{
		/*[in]*/ DEBUGREF_INFO_FLAGS dwFields;
		/*[in]*/ DWORD dwRadix;
		/*[in]*/ DWORD dwTimeout;
		/*[in,size_is(dwArgCount),length_is(dwArgCount)]*/ IDebugReference2** rgpArgs;
		/*[in]*/ DWORD dwArgCount;
		/*[out]*/ DEBUG_REFERENCE_INFO* pReferenceInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetReferenceInfo)(
		/*[in]*/ DEBUGREF_INFO_FLAGS dwFields,
		/*[in]*/ DWORD dwRadix,
		/*[in]*/ DWORD dwTimeout,
		/*[in,size_is(dwArgCount),length_is(dwArgCount)]*/ IDebugReference2** rgpArgs,
		/*[in]*/ DWORD dwArgCount,
		/*[out]*/ DEBUG_REFERENCE_INFO* pReferenceInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetReferenceInfo)

		VSL_CHECK_VALIDVALUE(dwFields);

		VSL_CHECK_VALIDVALUE(dwRadix);

		VSL_CHECK_VALIDVALUE(dwTimeout);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpArgs, dwArgCount, validValues.dwArgCount);

		VSL_CHECK_VALIDVALUE(dwArgCount);

		VSL_SET_VALIDVALUE(pReferenceInfo);

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
		/*[in,size_is(dwArgCount),length_is(dwArgCount)]*/ IDebugReference2** rgpArgs;
		/*[in]*/ DWORD dwArgCount;
		/*[in]*/ IDebugReference2* pValue;
		/*[in]*/ DWORD dwTimeout;
		HRESULT retValue;
	};

	STDMETHOD(SetValueAsReference)(
		/*[in,size_is(dwArgCount),length_is(dwArgCount)]*/ IDebugReference2** rgpArgs,
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
		/*[in]*/ DEBUGREF_INFO_FLAGS dwFields;
		/*[in]*/ DWORD dwRadix;
		/*[in]*/ DBG_ATTRIB_FLAGS dwAttribFilter;
		/*[in,ptr]*/ LPCOLESTR pszNameFilter;
		/*[in]*/ DWORD dwTimeout;
		/*[out]*/ IEnumDebugReferenceInfo2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumChildren)(
		/*[in]*/ DEBUGREF_INFO_FLAGS dwFields,
		/*[in]*/ DWORD dwRadix,
		/*[in]*/ DBG_ATTRIB_FLAGS dwAttribFilter,
		/*[in,ptr]*/ LPCOLESTR pszNameFilter,
		/*[in]*/ DWORD dwTimeout,
		/*[out]*/ IEnumDebugReferenceInfo2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumChildren)

		VSL_CHECK_VALIDVALUE(dwFields);

		VSL_CHECK_VALIDVALUE(dwRadix);

		VSL_CHECK_VALIDVALUE(dwAttribFilter);

		VSL_CHECK_VALIDVALUE_STRINGW(pszNameFilter);

		VSL_CHECK_VALIDVALUE(dwTimeout);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParentValidValues
	{
		/*[out]*/ IDebugReference2** ppParent;
		HRESULT retValue;
	};

	STDMETHOD(GetParent)(
		/*[out]*/ IDebugReference2** ppParent)
	{
		VSL_DEFINE_MOCK_METHOD(GetParent)

		VSL_SET_VALIDVALUE_INTERFACE(ppParent);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDerivedMostReferenceValidValues
	{
		/*[out]*/ IDebugReference2** ppDerivedMost;
		HRESULT retValue;
	};

	STDMETHOD(GetDerivedMostReference)(
		/*[out]*/ IDebugReference2** ppDerivedMost)
	{
		VSL_DEFINE_MOCK_METHOD(GetDerivedMostReference)

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
	struct SetReferenceTypeValidValues
	{
		/*[in]*/ REFERENCE_TYPE dwRefType;
		HRESULT retValue;
	};

	STDMETHOD(SetReferenceType)(
		/*[in]*/ REFERENCE_TYPE dwRefType)
	{
		VSL_DEFINE_MOCK_METHOD(SetReferenceType)

		VSL_CHECK_VALIDVALUE(dwRefType);

		VSL_RETURN_VALIDVALUES();
	}
	struct CompareValidValues
	{
		/*[in]*/ REFERENCE_COMPARE dwCompare;
		/*[in]*/ IDebugReference2* pReference;
		HRESULT retValue;
	};

	STDMETHOD(Compare)(
		/*[in]*/ REFERENCE_COMPARE dwCompare,
		/*[in]*/ IDebugReference2* pReference)
	{
		VSL_DEFINE_MOCK_METHOD(Compare)

		VSL_CHECK_VALIDVALUE(dwCompare);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pReference);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGREFERENCE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
