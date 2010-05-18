/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGMEMORYBYTES2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGMEMORYBYTES2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugMemoryBytes2NotImpl :
	public IDebugMemoryBytes2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugMemoryBytes2NotImpl)

public:

	typedef IDebugMemoryBytes2 Interface;

	STDMETHOD(ReadAt)(
		/*[in]*/ IDebugMemoryContext2* /*pStartContext*/,
		/*[in]*/ DWORD /*dwCount*/,
		/*[out,size_is(dwCount),length_is(*pdwRead)]*/ BYTE* /*rgbMemory*/,
		/*[out]*/ DWORD* /*pdwRead*/,
		/*[in,out,ptr]*/ DWORD* /*pdwUnreadable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WriteAt)(
		/*[in]*/ IDebugMemoryContext2* /*pStartContext*/,
		/*[in]*/ DWORD /*dwCount*/,
		/*[in,size_is(dwCount),length_is(dwCount)]*/ BYTE* /*rgbMemory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSize)(
		/*[out]*/ UINT64* /*pqwSize*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugMemoryBytes2MockImpl :
	public IDebugMemoryBytes2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugMemoryBytes2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugMemoryBytes2MockImpl)

	typedef IDebugMemoryBytes2 Interface;
	struct ReadAtValidValues
	{
		/*[in]*/ IDebugMemoryContext2* pStartContext;
		/*[in]*/ DWORD dwCount;
		/*[out,size_is(dwCount),length_is(*pdwRead)]*/ BYTE* rgbMemory;
		/*[out]*/ DWORD* pdwRead;
		/*[in,out,ptr]*/ DWORD* pdwUnreadable;
		HRESULT retValue;
	};

	STDMETHOD(ReadAt)(
		/*[in]*/ IDebugMemoryContext2* pStartContext,
		/*[in]*/ DWORD dwCount,
		/*[out,size_is(dwCount),length_is(*pdwRead)]*/ BYTE* rgbMemory,
		/*[out]*/ DWORD* pdwRead,
		/*[in,out,ptr]*/ DWORD* pdwUnreadable)
	{
		VSL_DEFINE_MOCK_METHOD(ReadAt)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStartContext);

		VSL_CHECK_VALIDVALUE(dwCount);

		VSL_SET_VALIDVALUE_MEMCPY(rgbMemory, dwCount*sizeof(rgbMemory[0]), *(validValues.pdwRead)*sizeof(validValues.rgbMemory[0]));

		VSL_SET_VALIDVALUE(pdwRead);

		VSL_SET_VALIDVALUE(pdwUnreadable);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteAtValidValues
	{
		/*[in]*/ IDebugMemoryContext2* pStartContext;
		/*[in]*/ DWORD dwCount;
		/*[in,size_is(dwCount),length_is(dwCount)]*/ BYTE* rgbMemory;
		HRESULT retValue;
	};

	STDMETHOD(WriteAt)(
		/*[in]*/ IDebugMemoryContext2* pStartContext,
		/*[in]*/ DWORD dwCount,
		/*[in,size_is(dwCount),length_is(dwCount)]*/ BYTE* rgbMemory)
	{
		VSL_DEFINE_MOCK_METHOD(WriteAt)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStartContext);

		VSL_CHECK_VALIDVALUE(dwCount);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgbMemory, dwCount*sizeof(rgbMemory[0]), validValues.dwCount*sizeof(validValues.rgbMemory[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSizeValidValues
	{
		/*[out]*/ UINT64* pqwSize;
		HRESULT retValue;
	};

	STDMETHOD(GetSize)(
		/*[out]*/ UINT64* pqwSize)
	{
		VSL_DEFINE_MOCK_METHOD(GetSize)

		VSL_SET_VALIDVALUE(pqwSize);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGMEMORYBYTES2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
