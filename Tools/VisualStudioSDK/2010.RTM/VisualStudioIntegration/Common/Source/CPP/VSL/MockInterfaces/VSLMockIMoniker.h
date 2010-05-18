/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IMONIKER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IMONIKER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IMonikerNotImpl :
	public IMoniker
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IMonikerNotImpl)

public:

	typedef IMoniker Interface;

	STDMETHOD(BindToObject)(
		/*[in,unique]*/ IBindCtx* /*pbc*/,
		/*[in,unique]*/ IMoniker* /*pmkToLeft*/,
		/*[in]*/ REFIID /*riidResult*/,
		/*[out,iid_is(riidResult)]*/ void** /*ppvResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BindToStorage)(
		/*[in,unique]*/ IBindCtx* /*pbc*/,
		/*[in,unique]*/ IMoniker* /*pmkToLeft*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ void** /*ppvObj*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reduce)(
		/*[in,unique]*/ IBindCtx* /*pbc*/,
		/*[in]*/ DWORD /*dwReduceHowFar*/,
		/*[in,out,unique]*/ IMoniker** /*ppmkToLeft*/,
		/*[out]*/ IMoniker** /*ppmkReduced*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ComposeWith)(
		/*[in,unique]*/ IMoniker* /*pmkRight*/,
		/*[in]*/ BOOL /*fOnlyIfNotGeneric*/,
		/*[out]*/ IMoniker** /*ppmkComposite*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Enum)(
		/*[in]*/ BOOL /*fForward*/,
		/*[out]*/ IEnumMoniker** /*ppenumMoniker*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsEqual)(
		/*[in,unique]*/ IMoniker* /*pmkOtherMoniker*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Hash)(
		/*[out]*/ DWORD* /*pdwHash*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsRunning)(
		/*[in,unique]*/ IBindCtx* /*pbc*/,
		/*[in,unique]*/ IMoniker* /*pmkToLeft*/,
		/*[in,unique]*/ IMoniker* /*pmkNewlyRunning*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTimeOfLastChange)(
		/*[in,unique]*/ IBindCtx* /*pbc*/,
		/*[in,unique]*/ IMoniker* /*pmkToLeft*/,
		/*[out]*/ FILETIME* /*pFileTime*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Inverse)(
		/*[out]*/ IMoniker** /*ppmk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CommonPrefixWith)(
		/*[in,unique]*/ IMoniker* /*pmkOther*/,
		/*[out]*/ IMoniker** /*ppmkPrefix*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RelativePathTo)(
		/*[in,unique]*/ IMoniker* /*pmkOther*/,
		/*[out]*/ IMoniker** /*ppmkRelPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDisplayName)(
		/*[in,unique]*/ IBindCtx* /*pbc*/,
		/*[in,unique]*/ IMoniker* /*pmkToLeft*/,
		/*[out]*/ LPOLESTR* /*ppszDisplayName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ParseDisplayName)(
		/*[in,unique]*/ IBindCtx* /*pbc*/,
		/*[in,unique]*/ IMoniker* /*pmkToLeft*/,
		/*[in]*/ LPOLESTR /*pszDisplayName*/,
		/*[out]*/ ULONG* /*pchEaten*/,
		/*[out]*/ IMoniker** /*ppmkOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsSystemMoniker)(
		/*[out]*/ DWORD* /*pdwMksys*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsDirty)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Load)(
		/*[in,unique]*/ IStream* /*pStm*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Save)(
		/*[in,unique]*/ IStream* /*pStm*/,
		/*[in]*/ BOOL /*fClearDirty*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSizeMax)(
		/*[out]*/ ULARGE_INTEGER* /*pcbSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClassID)(
		/*[out]*/ CLSID* /*pClassID*/)VSL_STDMETHOD_NOTIMPL
};

class IMonikerMockImpl :
	public IMoniker,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IMonikerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IMonikerMockImpl)

	typedef IMoniker Interface;
	struct BindToObjectValidValues
	{
		/*[in,unique]*/ IBindCtx* pbc;
		/*[in,unique]*/ IMoniker* pmkToLeft;
		/*[in]*/ REFIID riidResult;
		/*[out,iid_is(riidResult)]*/ void** ppvResult;
		HRESULT retValue;
	};

	STDMETHOD(BindToObject)(
		/*[in,unique]*/ IBindCtx* pbc,
		/*[in,unique]*/ IMoniker* pmkToLeft,
		/*[in]*/ REFIID riidResult,
		/*[out,iid_is(riidResult)]*/ void** ppvResult)
	{
		VSL_DEFINE_MOCK_METHOD(BindToObject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pbc);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkToLeft);

		VSL_CHECK_VALIDVALUE(riidResult);

		VSL_SET_VALIDVALUE(ppvResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct BindToStorageValidValues
	{
		/*[in,unique]*/ IBindCtx* pbc;
		/*[in,unique]*/ IMoniker* pmkToLeft;
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ void** ppvObj;
		HRESULT retValue;
	};

	STDMETHOD(BindToStorage)(
		/*[in,unique]*/ IBindCtx* pbc,
		/*[in,unique]*/ IMoniker* pmkToLeft,
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ void** ppvObj)
	{
		VSL_DEFINE_MOCK_METHOD(BindToStorage)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pbc);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkToLeft);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppvObj);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReduceValidValues
	{
		/*[in,unique]*/ IBindCtx* pbc;
		/*[in]*/ DWORD dwReduceHowFar;
		/*[in,out,unique]*/ IMoniker** ppmkToLeft;
		/*[out]*/ IMoniker** ppmkReduced;
		HRESULT retValue;
	};

	STDMETHOD(Reduce)(
		/*[in,unique]*/ IBindCtx* pbc,
		/*[in]*/ DWORD dwReduceHowFar,
		/*[in,out,unique]*/ IMoniker** ppmkToLeft,
		/*[out]*/ IMoniker** ppmkReduced)
	{
		VSL_DEFINE_MOCK_METHOD(Reduce)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pbc);

		VSL_CHECK_VALIDVALUE(dwReduceHowFar);

		VSL_SET_VALIDVALUE_INTERFACE(ppmkToLeft);

		VSL_SET_VALIDVALUE_INTERFACE(ppmkReduced);

		VSL_RETURN_VALIDVALUES();
	}
	struct ComposeWithValidValues
	{
		/*[in,unique]*/ IMoniker* pmkRight;
		/*[in]*/ BOOL fOnlyIfNotGeneric;
		/*[out]*/ IMoniker** ppmkComposite;
		HRESULT retValue;
	};

	STDMETHOD(ComposeWith)(
		/*[in,unique]*/ IMoniker* pmkRight,
		/*[in]*/ BOOL fOnlyIfNotGeneric,
		/*[out]*/ IMoniker** ppmkComposite)
	{
		VSL_DEFINE_MOCK_METHOD(ComposeWith)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkRight);

		VSL_CHECK_VALIDVALUE(fOnlyIfNotGeneric);

		VSL_SET_VALIDVALUE_INTERFACE(ppmkComposite);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumValidValues
	{
		/*[in]*/ BOOL fForward;
		/*[out]*/ IEnumMoniker** ppenumMoniker;
		HRESULT retValue;
	};

	STDMETHOD(Enum)(
		/*[in]*/ BOOL fForward,
		/*[out]*/ IEnumMoniker** ppenumMoniker)
	{
		VSL_DEFINE_MOCK_METHOD(Enum)

		VSL_CHECK_VALIDVALUE(fForward);

		VSL_SET_VALIDVALUE_INTERFACE(ppenumMoniker);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsEqualValidValues
	{
		/*[in,unique]*/ IMoniker* pmkOtherMoniker;
		HRESULT retValue;
	};

	STDMETHOD(IsEqual)(
		/*[in,unique]*/ IMoniker* pmkOtherMoniker)
	{
		VSL_DEFINE_MOCK_METHOD(IsEqual)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkOtherMoniker);

		VSL_RETURN_VALIDVALUES();
	}
	struct HashValidValues
	{
		/*[out]*/ DWORD* pdwHash;
		HRESULT retValue;
	};

	STDMETHOD(Hash)(
		/*[out]*/ DWORD* pdwHash)
	{
		VSL_DEFINE_MOCK_METHOD(Hash)

		VSL_SET_VALIDVALUE(pdwHash);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsRunningValidValues
	{
		/*[in,unique]*/ IBindCtx* pbc;
		/*[in,unique]*/ IMoniker* pmkToLeft;
		/*[in,unique]*/ IMoniker* pmkNewlyRunning;
		HRESULT retValue;
	};

	STDMETHOD(IsRunning)(
		/*[in,unique]*/ IBindCtx* pbc,
		/*[in,unique]*/ IMoniker* pmkToLeft,
		/*[in,unique]*/ IMoniker* pmkNewlyRunning)
	{
		VSL_DEFINE_MOCK_METHOD(IsRunning)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pbc);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkToLeft);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkNewlyRunning);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTimeOfLastChangeValidValues
	{
		/*[in,unique]*/ IBindCtx* pbc;
		/*[in,unique]*/ IMoniker* pmkToLeft;
		/*[out]*/ FILETIME* pFileTime;
		HRESULT retValue;
	};

	STDMETHOD(GetTimeOfLastChange)(
		/*[in,unique]*/ IBindCtx* pbc,
		/*[in,unique]*/ IMoniker* pmkToLeft,
		/*[out]*/ FILETIME* pFileTime)
	{
		VSL_DEFINE_MOCK_METHOD(GetTimeOfLastChange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pbc);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkToLeft);

		VSL_SET_VALIDVALUE(pFileTime);

		VSL_RETURN_VALIDVALUES();
	}
	struct InverseValidValues
	{
		/*[out]*/ IMoniker** ppmk;
		HRESULT retValue;
	};

	STDMETHOD(Inverse)(
		/*[out]*/ IMoniker** ppmk)
	{
		VSL_DEFINE_MOCK_METHOD(Inverse)

		VSL_SET_VALIDVALUE_INTERFACE(ppmk);

		VSL_RETURN_VALIDVALUES();
	}
	struct CommonPrefixWithValidValues
	{
		/*[in,unique]*/ IMoniker* pmkOther;
		/*[out]*/ IMoniker** ppmkPrefix;
		HRESULT retValue;
	};

	STDMETHOD(CommonPrefixWith)(
		/*[in,unique]*/ IMoniker* pmkOther,
		/*[out]*/ IMoniker** ppmkPrefix)
	{
		VSL_DEFINE_MOCK_METHOD(CommonPrefixWith)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkOther);

		VSL_SET_VALIDVALUE_INTERFACE(ppmkPrefix);

		VSL_RETURN_VALIDVALUES();
	}
	struct RelativePathToValidValues
	{
		/*[in,unique]*/ IMoniker* pmkOther;
		/*[out]*/ IMoniker** ppmkRelPath;
		HRESULT retValue;
	};

	STDMETHOD(RelativePathTo)(
		/*[in,unique]*/ IMoniker* pmkOther,
		/*[out]*/ IMoniker** ppmkRelPath)
	{
		VSL_DEFINE_MOCK_METHOD(RelativePathTo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkOther);

		VSL_SET_VALIDVALUE_INTERFACE(ppmkRelPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDisplayNameValidValues
	{
		/*[in,unique]*/ IBindCtx* pbc;
		/*[in,unique]*/ IMoniker* pmkToLeft;
		/*[out]*/ LPOLESTR* ppszDisplayName;
		HRESULT retValue;
	};

	STDMETHOD(GetDisplayName)(
		/*[in,unique]*/ IBindCtx* pbc,
		/*[in,unique]*/ IMoniker* pmkToLeft,
		/*[out]*/ LPOLESTR* ppszDisplayName)
	{
		VSL_DEFINE_MOCK_METHOD(GetDisplayName)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pbc);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkToLeft);

		VSL_SET_VALIDVALUE(ppszDisplayName);

		VSL_RETURN_VALIDVALUES();
	}
	struct ParseDisplayNameValidValues
	{
		/*[in,unique]*/ IBindCtx* pbc;
		/*[in,unique]*/ IMoniker* pmkToLeft;
		/*[in]*/ LPOLESTR pszDisplayName;
		/*[out]*/ ULONG* pchEaten;
		/*[out]*/ IMoniker** ppmkOut;
		HRESULT retValue;
	};

	STDMETHOD(ParseDisplayName)(
		/*[in,unique]*/ IBindCtx* pbc,
		/*[in,unique]*/ IMoniker* pmkToLeft,
		/*[in]*/ LPOLESTR pszDisplayName,
		/*[out]*/ ULONG* pchEaten,
		/*[out]*/ IMoniker** ppmkOut)
	{
		VSL_DEFINE_MOCK_METHOD(ParseDisplayName)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pbc);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkToLeft);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDisplayName);

		VSL_SET_VALIDVALUE(pchEaten);

		VSL_SET_VALIDVALUE_INTERFACE(ppmkOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsSystemMonikerValidValues
	{
		/*[out]*/ DWORD* pdwMksys;
		HRESULT retValue;
	};

	STDMETHOD(IsSystemMoniker)(
		/*[out]*/ DWORD* pdwMksys)
	{
		VSL_DEFINE_MOCK_METHOD(IsSystemMoniker)

		VSL_SET_VALIDVALUE(pdwMksys);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsDirtyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsDirty)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsDirty)

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadValidValues
	{
		/*[in,unique]*/ IStream* pStm;
		HRESULT retValue;
	};

	STDMETHOD(Load)(
		/*[in,unique]*/ IStream* pStm)
	{
		VSL_DEFINE_MOCK_METHOD(Load)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStm);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveValidValues
	{
		/*[in,unique]*/ IStream* pStm;
		/*[in]*/ BOOL fClearDirty;
		HRESULT retValue;
	};

	STDMETHOD(Save)(
		/*[in,unique]*/ IStream* pStm,
		/*[in]*/ BOOL fClearDirty)
	{
		VSL_DEFINE_MOCK_METHOD(Save)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStm);

		VSL_CHECK_VALIDVALUE(fClearDirty);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSizeMaxValidValues
	{
		/*[out]*/ ULARGE_INTEGER* pcbSize;
		HRESULT retValue;
	};

	STDMETHOD(GetSizeMax)(
		/*[out]*/ ULARGE_INTEGER* pcbSize)
	{
		VSL_DEFINE_MOCK_METHOD(GetSizeMax)

		VSL_SET_VALIDVALUE(pcbSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetClassIDValidValues
	{
		/*[out]*/ CLSID* pClassID;
		HRESULT retValue;
	};

	STDMETHOD(GetClassID)(
		/*[out]*/ CLSID* pClassID)
	{
		VSL_DEFINE_MOCK_METHOD(GetClassID)

		VSL_SET_VALIDVALUE(pClassID);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IMONIKER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
