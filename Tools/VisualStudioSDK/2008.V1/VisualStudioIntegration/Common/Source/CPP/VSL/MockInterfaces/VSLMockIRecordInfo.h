/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IRECORDINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IRECORDINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OAIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IRecordInfoNotImpl :
	public IRecordInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IRecordInfoNotImpl)

public:

	typedef IRecordInfo Interface;

	STDMETHOD(RecordInit)(
		/*[out]*/ PVOID /*pvNew*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordClear)(
		/*[in]*/ PVOID /*pvExisting*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordCopy)(
		/*[in]*/ PVOID /*pvExisting*/,
		/*[out]*/ PVOID /*pvNew*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGuid)(
		/*[out]*/ GUID* /*pguid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSize)(
		/*[out]*/ ULONG* /*pcbSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfo)(
		/*[out]*/ ITypeInfo** /*ppTypeInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetField)(
		/*[in]*/ PVOID /*pvData*/,
		/*[in]*/ LPCOLESTR /*szFieldName*/,
		/*[out]*/ VARIANT* /*pvarField*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFieldNoCopy)(
		/*[in]*/ PVOID /*pvData*/,
		/*[in]*/ LPCOLESTR /*szFieldName*/,
		/*[out]*/ VARIANT* /*pvarField*/,
		/*[out]*/ PVOID* /*ppvDataCArray*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PutField)(
		/*[in]*/ ULONG /*wFlags*/,
		/*[in,out]*/ PVOID /*pvData*/,
		/*[in]*/ LPCOLESTR /*szFieldName*/,
		/*[in]*/ VARIANT* /*pvarField*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PutFieldNoCopy)(
		/*[in]*/ ULONG /*wFlags*/,
		/*[in,out]*/ PVOID /*pvData*/,
		/*[in]*/ LPCOLESTR /*szFieldName*/,
		/*[in]*/ VARIANT* /*pvarField*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFieldNames)(
		/*[in,out]*/ ULONG* /*pcNames*/,
		/*[out,size_is(*pcNames),length_is(*pcNames)]*/ BSTR* /*rgBstrNames*/)VSL_STDMETHOD_NOTIMPL

	virtual BOOL STDMETHODCALLTYPE IsMatchingType(
		/*[in]*/ IRecordInfo* /*pRecordInfo*/){ return BOOL(); }

	virtual PVOID STDMETHODCALLTYPE RecordCreate(){ return PVOID(); }

	STDMETHOD(RecordCreateCopy)(
		/*[in]*/ PVOID /*pvSource*/,
		/*[out]*/ PVOID* /*ppvDest*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordDestroy)(
		/*[in]*/ PVOID /*pvRecord*/)VSL_STDMETHOD_NOTIMPL
};

class IRecordInfoMockImpl :
	public IRecordInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IRecordInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IRecordInfoMockImpl)

	typedef IRecordInfo Interface;
	struct RecordInitValidValues
	{
		/*[out]*/ PVOID pvNew;
		HRESULT retValue;
		size_t pvNew_size_in_bytes;
	};

	STDMETHOD(RecordInit)(
		/*[out]*/ PVOID pvNew)
	{
		VSL_DEFINE_MOCK_METHOD(RecordInit)

		VSL_SET_VALIDVALUE_PVOID(pvNew);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordClearValidValues
	{
		/*[in]*/ PVOID pvExisting;
		HRESULT retValue;
		size_t pvExisting_size_in_bytes;
	};

	STDMETHOD(RecordClear)(
		/*[in]*/ PVOID pvExisting)
	{
		VSL_DEFINE_MOCK_METHOD(RecordClear)

		VSL_CHECK_VALIDVALUE_PVOID(pvExisting);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordCopyValidValues
	{
		/*[in]*/ PVOID pvExisting;
		/*[out]*/ PVOID pvNew;
		HRESULT retValue;
		size_t pvExisting_size_in_bytes;
		size_t pvNew_size_in_bytes;
	};

	STDMETHOD(RecordCopy)(
		/*[in]*/ PVOID pvExisting,
		/*[out]*/ PVOID pvNew)
	{
		VSL_DEFINE_MOCK_METHOD(RecordCopy)

		VSL_CHECK_VALIDVALUE_PVOID(pvExisting);

		VSL_SET_VALIDVALUE_PVOID(pvNew);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetGuidValidValues
	{
		/*[out]*/ GUID* pguid;
		HRESULT retValue;
	};

	STDMETHOD(GetGuid)(
		/*[out]*/ GUID* pguid)
	{
		VSL_DEFINE_MOCK_METHOD(GetGuid)

		VSL_SET_VALIDVALUE(pguid);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSizeValidValues
	{
		/*[out]*/ ULONG* pcbSize;
		HRESULT retValue;
	};

	STDMETHOD(GetSize)(
		/*[out]*/ ULONG* pcbSize)
	{
		VSL_DEFINE_MOCK_METHOD(GetSize)

		VSL_SET_VALIDVALUE(pcbSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeInfoValidValues
	{
		/*[out]*/ ITypeInfo** ppTypeInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeInfo)(
		/*[out]*/ ITypeInfo** ppTypeInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeInfo)

		VSL_SET_VALIDVALUE_INTERFACE(ppTypeInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFieldValidValues
	{
		/*[in]*/ PVOID pvData;
		/*[in]*/ LPCOLESTR szFieldName;
		/*[out]*/ VARIANT* pvarField;
		HRESULT retValue;
		size_t pvData_size_in_bytes;
	};

	STDMETHOD(GetField)(
		/*[in]*/ PVOID pvData,
		/*[in]*/ LPCOLESTR szFieldName,
		/*[out]*/ VARIANT* pvarField)
	{
		VSL_DEFINE_MOCK_METHOD(GetField)

		VSL_CHECK_VALIDVALUE_PVOID(pvData);

		VSL_CHECK_VALIDVALUE_STRINGW(szFieldName);

		VSL_SET_VALIDVALUE_VARIANT(pvarField);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFieldNoCopyValidValues
	{
		/*[in]*/ PVOID pvData;
		/*[in]*/ LPCOLESTR szFieldName;
		/*[out]*/ VARIANT* pvarField;
		/*[out]*/ PVOID* ppvDataCArray;
		HRESULT retValue;
		size_t pvData_size_in_bytes;
	};

	STDMETHOD(GetFieldNoCopy)(
		/*[in]*/ PVOID pvData,
		/*[in]*/ LPCOLESTR szFieldName,
		/*[out]*/ VARIANT* pvarField,
		/*[out]*/ PVOID* ppvDataCArray)
	{
		VSL_DEFINE_MOCK_METHOD(GetFieldNoCopy)

		VSL_CHECK_VALIDVALUE_PVOID(pvData);

		VSL_CHECK_VALIDVALUE_STRINGW(szFieldName);

		VSL_SET_VALIDVALUE_VARIANT(pvarField);

		VSL_SET_VALIDVALUE(ppvDataCArray);

		VSL_RETURN_VALIDVALUES();
	}
	struct PutFieldValidValues
	{
		/*[in]*/ ULONG wFlags;
		/*[in,out]*/ PVOID pvData;
		/*[in]*/ LPCOLESTR szFieldName;
		/*[in]*/ VARIANT* pvarField;
		HRESULT retValue;
		size_t pvData_size_in_bytes;
	};

	STDMETHOD(PutField)(
		/*[in]*/ ULONG wFlags,
		/*[in,out]*/ PVOID pvData,
		/*[in]*/ LPCOLESTR szFieldName,
		/*[in]*/ VARIANT* pvarField)
	{
		VSL_DEFINE_MOCK_METHOD(PutField)

		VSL_CHECK_VALIDVALUE(wFlags);

		VSL_SET_VALIDVALUE_PVOID(pvData);

		VSL_CHECK_VALIDVALUE_STRINGW(szFieldName);

		VSL_CHECK_VALIDVALUE_POINTER(pvarField);

		VSL_RETURN_VALIDVALUES();
	}
	struct PutFieldNoCopyValidValues
	{
		/*[in]*/ ULONG wFlags;
		/*[in,out]*/ PVOID pvData;
		/*[in]*/ LPCOLESTR szFieldName;
		/*[in]*/ VARIANT* pvarField;
		HRESULT retValue;
		size_t pvData_size_in_bytes;
	};

	STDMETHOD(PutFieldNoCopy)(
		/*[in]*/ ULONG wFlags,
		/*[in,out]*/ PVOID pvData,
		/*[in]*/ LPCOLESTR szFieldName,
		/*[in]*/ VARIANT* pvarField)
	{
		VSL_DEFINE_MOCK_METHOD(PutFieldNoCopy)

		VSL_CHECK_VALIDVALUE(wFlags);

		VSL_SET_VALIDVALUE_PVOID(pvData);

		VSL_CHECK_VALIDVALUE_STRINGW(szFieldName);

		VSL_CHECK_VALIDVALUE_POINTER(pvarField);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFieldNamesValidValues
	{
		/*[in,out]*/ ULONG* pcNames;
		/*[out,size_is(*pcNames),length_is(*pcNames)]*/ BSTR* rgBstrNames;
		HRESULT retValue;
	};

	STDMETHOD(GetFieldNames)(
		/*[in,out]*/ ULONG* pcNames,
		/*[out,size_is(*pcNames),length_is(*pcNames)]*/ BSTR* rgBstrNames)
	{
		VSL_DEFINE_MOCK_METHOD(GetFieldNames)

		VSL_SET_VALIDVALUE(pcNames);

		VSL_SET_VALIDVALUE_MEMCPY(rgBstrNames, *pcNames*sizeof(rgBstrNames[0]), *(validValues.pcNames)*sizeof(validValues.rgBstrNames[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct IsMatchingTypeValidValues
	{
		/*[in]*/ IRecordInfo* pRecordInfo;
		BOOL retValue;
	};

	virtual BOOL _stdcall IsMatchingType(
		/*[in]*/ IRecordInfo* pRecordInfo)
	{
		VSL_DEFINE_MOCK_METHOD(IsMatchingType)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pRecordInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordCreateValidValues
	{
		PVOID retValue;
	};

	virtual PVOID _stdcall RecordCreate()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordCreate)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordCreateCopyValidValues
	{
		/*[in]*/ PVOID pvSource;
		/*[out]*/ PVOID* ppvDest;
		HRESULT retValue;
		size_t pvSource_size_in_bytes;
	};

	STDMETHOD(RecordCreateCopy)(
		/*[in]*/ PVOID pvSource,
		/*[out]*/ PVOID* ppvDest)
	{
		VSL_DEFINE_MOCK_METHOD(RecordCreateCopy)

		VSL_CHECK_VALIDVALUE_PVOID(pvSource);

		VSL_SET_VALIDVALUE(ppvDest);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordDestroyValidValues
	{
		/*[in]*/ PVOID pvRecord;
		HRESULT retValue;
		size_t pvRecord_size_in_bytes;
	};

	STDMETHOD(RecordDestroy)(
		/*[in]*/ PVOID pvRecord)
	{
		VSL_DEFINE_MOCK_METHOD(RecordDestroy)

		VSL_CHECK_VALIDVALUE_PVOID(pvRecord);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IRECORDINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
