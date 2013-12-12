/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ISTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ISTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IStorageNotImpl :
	public IStorage
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IStorageNotImpl)

public:

	typedef IStorage Interface;

	STDMETHOD(CreateStream)(
		/*[in,string]*/ const OLECHAR* /*pwcsName*/,
		/*[in]*/ DWORD /*grfMode*/,
		/*[in]*/ DWORD /*reserved1*/,
		/*[in]*/ DWORD /*reserved2*/,
		/*[out]*/ IStream** /*ppstm*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenStream)(
		/*[in,string]*/ const OLECHAR* /*pwcsName*/,
		/*[in,unique]*/ void* /*reserved1*/,
		/*[in]*/ DWORD /*grfMode*/,
		/*[in]*/ DWORD /*reserved2*/,
		/*[out]*/ IStream** /*ppstm*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateStorage)(
		/*[in,string]*/ const OLECHAR* /*pwcsName*/,
		/*[in]*/ DWORD /*grfMode*/,
		/*[in]*/ DWORD /*reserved1*/,
		/*[in]*/ DWORD /*reserved2*/,
		/*[out]*/ IStorage** /*ppstg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenStorage)(
		/*[in,unique,string]*/ const OLECHAR* /*pwcsName*/,
		/*[in,unique]*/ IStorage* /*pstgPriority*/,
		/*[in]*/ DWORD /*grfMode*/,
		/*[in,unique]*/ SNB /*snbExclude*/,
		/*[in]*/ DWORD /*reserved*/,
		/*[out]*/ IStorage** /*ppstg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CopyTo)(
		/*[in]*/ DWORD /*ciidExclude*/,
		/*[in,unique,size_is(ciidExclude)]*/ const IID* /*rgiidExclude*/,
		/*[in,unique]*/ SNB /*snbExclude*/,
		/*[in,unique]*/ IStorage* /*pstgDest*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MoveElementTo)(
		/*[in,string]*/ const OLECHAR* /*pwcsName*/,
		/*[in,unique]*/ IStorage* /*pstgDest*/,
		/*[in,string]*/ const OLECHAR* /*pwcsNewName*/,
		/*[in]*/ DWORD /*grfFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Commit)(
		/*[in]*/ DWORD /*grfCommitFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Revert)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumElements)(
		/*[in]*/ DWORD /*reserved1*/,
		/*[in,unique,size_is(1)]*/ void* /*reserved2*/,
		/*[in]*/ DWORD /*reserved3*/,
		/*[out]*/ IEnumSTATSTG** /*ppenum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DestroyElement)(
		/*[in,string]*/ const OLECHAR* /*pwcsName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RenameElement)(
		/*[in,string]*/ const OLECHAR* /*pwcsOldName*/,
		/*[in,string]*/ const OLECHAR* /*pwcsNewName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetElementTimes)(
		/*[in,unique,string]*/ const OLECHAR* /*pwcsName*/,
		/*[in,unique]*/ const FILETIME* /*pctime*/,
		/*[in,unique]*/ const FILETIME* /*patime*/,
		/*[in,unique]*/ const FILETIME* /*pmtime*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetClass)(
		/*[in]*/ REFCLSID /*clsid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetStateBits)(
		/*[in]*/ DWORD /*grfStateBits*/,
		/*[in]*/ DWORD /*grfMask*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Stat)(
		/*[out]*/ STATSTG* /*pstatstg*/,
		/*[in]*/ DWORD /*grfStatFlag*/)VSL_STDMETHOD_NOTIMPL
};

class IStorageMockImpl :
	public IStorage,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IStorageMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IStorageMockImpl)

	typedef IStorage Interface;
	struct CreateStreamValidValues
	{
		/*[in,string]*/ OLECHAR* pwcsName;
		/*[in]*/ DWORD grfMode;
		/*[in]*/ DWORD reserved1;
		/*[in]*/ DWORD reserved2;
		/*[out]*/ IStream** ppstm;
		HRESULT retValue;
	};

	STDMETHOD(CreateStream)(
		/*[in,string]*/ const OLECHAR* pwcsName,
		/*[in]*/ DWORD grfMode,
		/*[in]*/ DWORD reserved1,
		/*[in]*/ DWORD reserved2,
		/*[out]*/ IStream** ppstm)
	{
		VSL_DEFINE_MOCK_METHOD(CreateStream)

		VSL_CHECK_VALIDVALUE_STRINGW(pwcsName);

		VSL_CHECK_VALIDVALUE(grfMode);

		VSL_CHECK_VALIDVALUE(reserved1);

		VSL_CHECK_VALIDVALUE(reserved2);

		VSL_SET_VALIDVALUE_INTERFACE(ppstm);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenStreamValidValues
	{
		/*[in,string]*/ OLECHAR* pwcsName;
		/*[in,unique]*/ void* reserved1;
		/*[in]*/ DWORD grfMode;
		/*[in]*/ DWORD reserved2;
		/*[out]*/ IStream** ppstm;
		HRESULT retValue;
		size_t reserved1_size_in_bytes;
	};

	STDMETHOD(OpenStream)(
		/*[in,string]*/ const OLECHAR* pwcsName,
		/*[in,unique]*/ void* reserved1,
		/*[in]*/ DWORD grfMode,
		/*[in]*/ DWORD reserved2,
		/*[out]*/ IStream** ppstm)
	{
		VSL_DEFINE_MOCK_METHOD(OpenStream)

		VSL_CHECK_VALIDVALUE_STRINGW(pwcsName);

		VSL_CHECK_VALIDVALUE_PVOID(reserved1);

		VSL_CHECK_VALIDVALUE(grfMode);

		VSL_CHECK_VALIDVALUE(reserved2);

		VSL_SET_VALIDVALUE_INTERFACE(ppstm);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateStorageValidValues
	{
		/*[in,string]*/ OLECHAR* pwcsName;
		/*[in]*/ DWORD grfMode;
		/*[in]*/ DWORD reserved1;
		/*[in]*/ DWORD reserved2;
		/*[out]*/ IStorage** ppstg;
		HRESULT retValue;
	};

	STDMETHOD(CreateStorage)(
		/*[in,string]*/ const OLECHAR* pwcsName,
		/*[in]*/ DWORD grfMode,
		/*[in]*/ DWORD reserved1,
		/*[in]*/ DWORD reserved2,
		/*[out]*/ IStorage** ppstg)
	{
		VSL_DEFINE_MOCK_METHOD(CreateStorage)

		VSL_CHECK_VALIDVALUE_STRINGW(pwcsName);

		VSL_CHECK_VALIDVALUE(grfMode);

		VSL_CHECK_VALIDVALUE(reserved1);

		VSL_CHECK_VALIDVALUE(reserved2);

		VSL_SET_VALIDVALUE_INTERFACE(ppstg);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenStorageValidValues
	{
		/*[in,unique,string]*/ OLECHAR* pwcsName;
		/*[in,unique]*/ IStorage* pstgPriority;
		/*[in]*/ DWORD grfMode;
		/*[in,unique]*/ SNB snbExclude;
		/*[in]*/ DWORD reserved;
		/*[out]*/ IStorage** ppstg;
		HRESULT retValue;
	};

	STDMETHOD(OpenStorage)(
		/*[in,unique,string]*/ const OLECHAR* pwcsName,
		/*[in,unique]*/ IStorage* pstgPriority,
		/*[in]*/ DWORD grfMode,
		/*[in,unique]*/ SNB snbExclude,
		/*[in]*/ DWORD reserved,
		/*[out]*/ IStorage** ppstg)
	{
		VSL_DEFINE_MOCK_METHOD(OpenStorage)

		VSL_CHECK_VALIDVALUE_STRINGW(pwcsName);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pstgPriority);

		VSL_CHECK_VALIDVALUE(grfMode);

		VSL_CHECK_VALIDVALUE(snbExclude);

		VSL_CHECK_VALIDVALUE(reserved);

		VSL_SET_VALIDVALUE_INTERFACE(ppstg);

		VSL_RETURN_VALIDVALUES();
	}
	struct CopyToValidValues
	{
		/*[in]*/ DWORD ciidExclude;
		/*[in,unique,size_is(ciidExclude)]*/ IID* rgiidExclude;
		/*[in,unique]*/ SNB snbExclude;
		/*[in,unique]*/ IStorage* pstgDest;
		HRESULT retValue;
	};

	STDMETHOD(CopyTo)(
		/*[in]*/ DWORD ciidExclude,
		/*[in,unique,size_is(ciidExclude)]*/ const IID* rgiidExclude,
		/*[in,unique]*/ SNB snbExclude,
		/*[in,unique]*/ IStorage* pstgDest)
	{
		VSL_DEFINE_MOCK_METHOD(CopyTo)

		VSL_CHECK_VALIDVALUE(ciidExclude);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgiidExclude, ciidExclude*sizeof(rgiidExclude[0]), validValues.ciidExclude*sizeof(validValues.rgiidExclude[0]));

		VSL_CHECK_VALIDVALUE(snbExclude);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pstgDest);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveElementToValidValues
	{
		/*[in,string]*/ OLECHAR* pwcsName;
		/*[in,unique]*/ IStorage* pstgDest;
		/*[in,string]*/ OLECHAR* pwcsNewName;
		/*[in]*/ DWORD grfFlags;
		HRESULT retValue;
	};

	STDMETHOD(MoveElementTo)(
		/*[in,string]*/ const OLECHAR* pwcsName,
		/*[in,unique]*/ IStorage* pstgDest,
		/*[in,string]*/ const OLECHAR* pwcsNewName,
		/*[in]*/ DWORD grfFlags)
	{
		VSL_DEFINE_MOCK_METHOD(MoveElementTo)

		VSL_CHECK_VALIDVALUE_STRINGW(pwcsName);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pstgDest);

		VSL_CHECK_VALIDVALUE_STRINGW(pwcsNewName);

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct CommitValidValues
	{
		/*[in]*/ DWORD grfCommitFlags;
		HRESULT retValue;
	};

	STDMETHOD(Commit)(
		/*[in]*/ DWORD grfCommitFlags)
	{
		VSL_DEFINE_MOCK_METHOD(Commit)

		VSL_CHECK_VALIDVALUE(grfCommitFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct RevertValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Revert)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Revert)

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumElementsValidValues
	{
		/*[in]*/ DWORD reserved1;
		/*[in,unique,size_is(1)]*/ void* reserved2;
		/*[in]*/ DWORD reserved3;
		/*[out]*/ IEnumSTATSTG** ppenum;
		HRESULT retValue;
		size_t reserved2_size_in_bytes;
	};

	STDMETHOD(EnumElements)(
		/*[in]*/ DWORD reserved1,
		/*[in,unique,size_is(1)]*/ void* reserved2,
		/*[in]*/ DWORD reserved3,
		/*[out]*/ IEnumSTATSTG** ppenum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumElements)

		VSL_CHECK_VALIDVALUE(reserved1);

		VSL_CHECK_VALIDVALUE_MEMCMP(reserved2, 1, 1);

		VSL_CHECK_VALIDVALUE(reserved3);

		VSL_SET_VALIDVALUE_INTERFACE(ppenum);

		VSL_RETURN_VALIDVALUES();
	}
	struct DestroyElementValidValues
	{
		/*[in,string]*/ OLECHAR* pwcsName;
		HRESULT retValue;
	};

	STDMETHOD(DestroyElement)(
		/*[in,string]*/ const OLECHAR* pwcsName)
	{
		VSL_DEFINE_MOCK_METHOD(DestroyElement)

		VSL_CHECK_VALIDVALUE_STRINGW(pwcsName);

		VSL_RETURN_VALIDVALUES();
	}
	struct RenameElementValidValues
	{
		/*[in,string]*/ OLECHAR* pwcsOldName;
		/*[in,string]*/ OLECHAR* pwcsNewName;
		HRESULT retValue;
	};

	STDMETHOD(RenameElement)(
		/*[in,string]*/ const OLECHAR* pwcsOldName,
		/*[in,string]*/ const OLECHAR* pwcsNewName)
	{
		VSL_DEFINE_MOCK_METHOD(RenameElement)

		VSL_CHECK_VALIDVALUE_STRINGW(pwcsOldName);

		VSL_CHECK_VALIDVALUE_STRINGW(pwcsNewName);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetElementTimesValidValues
	{
		/*[in,unique,string]*/ OLECHAR* pwcsName;
		/*[in,unique]*/ FILETIME* pctime;
		/*[in,unique]*/ FILETIME* patime;
		/*[in,unique]*/ FILETIME* pmtime;
		HRESULT retValue;
	};

	STDMETHOD(SetElementTimes)(
		/*[in,unique,string]*/ const OLECHAR* pwcsName,
		/*[in,unique]*/ const FILETIME* pctime,
		/*[in,unique]*/ const FILETIME* patime,
		/*[in,unique]*/ const FILETIME* pmtime)
	{
		VSL_DEFINE_MOCK_METHOD(SetElementTimes)

		VSL_CHECK_VALIDVALUE_STRINGW(pwcsName);

		VSL_CHECK_VALIDVALUE_POINTER(pctime);

		VSL_CHECK_VALIDVALUE_POINTER(patime);

		VSL_CHECK_VALIDVALUE_POINTER(pmtime);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetClassValidValues
	{
		/*[in]*/ REFCLSID clsid;
		HRESULT retValue;
	};

	STDMETHOD(SetClass)(
		/*[in]*/ REFCLSID clsid)
	{
		VSL_DEFINE_MOCK_METHOD(SetClass)

		VSL_CHECK_VALIDVALUE(clsid);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetStateBitsValidValues
	{
		/*[in]*/ DWORD grfStateBits;
		/*[in]*/ DWORD grfMask;
		HRESULT retValue;
	};

	STDMETHOD(SetStateBits)(
		/*[in]*/ DWORD grfStateBits,
		/*[in]*/ DWORD grfMask)
	{
		VSL_DEFINE_MOCK_METHOD(SetStateBits)

		VSL_CHECK_VALIDVALUE(grfStateBits);

		VSL_CHECK_VALIDVALUE(grfMask);

		VSL_RETURN_VALIDVALUES();
	}
	struct StatValidValues
	{
		/*[out]*/ STATSTG* pstatstg;
		/*[in]*/ DWORD grfStatFlag;
		HRESULT retValue;
	};

	STDMETHOD(Stat)(
		/*[out]*/ STATSTG* pstatstg,
		/*[in]*/ DWORD grfStatFlag)
	{
		VSL_DEFINE_MOCK_METHOD(Stat)

		VSL_SET_VALIDVALUE(pstatstg);

		VSL_CHECK_VALIDVALUE(grfStatFlag);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ISTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
