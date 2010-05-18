/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLCOM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLCOM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

// VSL includes
#include <VSLCommon.h>

namespace VSL
{

//Base is the user's class that derives from NonCocreateableComObjectRoot and whatever
//interfaces the user wants to support on the object
template <class Base_T>
class NonCocreateableComObject : public Base_T
{
public:
	typedef Base_T Base;
	typedef typename Base_T::ConstructorArgument ConstructorArgument;
	NonCocreateableComObject(ConstructorArgument& rConstructorArgument):
		Base(rConstructorArgument)
	{
		_pAtlModule->Lock();
	}
	// Set refcount to -(LONG_MAX/2) to protect destruction and 
	// also catch mismatched Release in debug builds
	virtual ~NonCocreateableComObject()
	{
		m_dwRef = -(LONG_MAX/2);
		FinalRelease();
#ifdef _ATL_DEBUG_INTERFACES
		_AtlDebugInterfacesModule.DeleteNonAddRefThunk(_GetRawUnknown());
#endif
		_pAtlModule->Unlock();
	}
	//If InternalAddRef or InternalRelease is undefined then your class
	//doesn't derive from NonCocreateableComObjectRoot
	STDMETHOD_(ULONG, AddRef)() {return InternalAddRef();}
	STDMETHOD_(ULONG, Release)()
	{
		ULONG l = InternalRelease();
		if (l == 0)
			delete this;
		return l;
	}
	//if _InternalQueryInterface is undefined then you forgot BEGIN_COM_MAP
	STDMETHOD(QueryInterface)(REFIID iid, void ** ppvObject)
	{return _InternalQueryInterface(iid, ppvObject);}
	template <class Q>
	HRESULT STDMETHODCALLTYPE QueryInterface(Q** pp)
	{
		return QueryInterface(__uuidof(Q), (void**)pp);
	}

	static HRESULT WINAPI CreateInstance(NonCocreateableComObject<Base>** pp, ConstructorArgument& rConstructorArgument);
};

template <class Base>
HRESULT WINAPI NonCocreateableComObject<Base>::CreateInstance(NonCocreateableComObject<Base>** pp, ConstructorArgument& rConstructorArgument)
{
	ATLASSERT(pp != NULL);
	if (pp == NULL)
		return E_POINTER;
	*pp = NULL;

	HRESULT hRes = E_OUTOFMEMORY;
	NonCocreateableComObject<Base>* p = NULL;
	ATLTRY(p = new NonCocreateableComObject<Base>(rConstructorArgument))
	if (p != NULL)
	{
		p->SetVoid(NULL);
		p->InternalFinalConstructAddRef();
		hRes = p->_AtlInitialConstruct();
		if (SUCCEEDED(hRes))
			hRes = p->FinalConstruct();
		if (SUCCEEDED(hRes))
			hRes = p->_AtlFinalConstruct();
		p->InternalFinalConstructRelease();
		if (hRes != S_OK)
		{
			delete p;
			p = NULL;
		}
	}
	*pp = p;
	return hRes;
}

} // namespace VSL

#endif // VSLCOM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
