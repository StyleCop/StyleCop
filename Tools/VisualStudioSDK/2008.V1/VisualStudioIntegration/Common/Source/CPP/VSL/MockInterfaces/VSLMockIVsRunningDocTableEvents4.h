/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSRUNNINGDOCTABLEEVENTS4_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSRUNNINGDOCTABLEEVENTS4_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsRunningDocTableEvents4NotImpl :
	public IVsRunningDocTableEvents4
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRunningDocTableEvents4NotImpl)

public:

	typedef IVsRunningDocTableEvents4 Interface;

	STDMETHOD(OnBeforeFirstDocumentLock)(
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterSaveAll)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterLastDocumentUnlock)(
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ BOOL /*fClosedWithoutSaving*/)VSL_STDMETHOD_NOTIMPL
};

class IVsRunningDocTableEvents4MockImpl :
	public IVsRunningDocTableEvents4,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRunningDocTableEvents4MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsRunningDocTableEvents4MockImpl)

	typedef IVsRunningDocTableEvents4 Interface;
	struct OnBeforeFirstDocumentLockValidValues
	{
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ LPCOLESTR pszMkDocument;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeFirstDocumentLock)(
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ LPCOLESTR pszMkDocument)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeFirstDocumentLock)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterSaveAllValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnAfterSaveAll)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnAfterSaveAll)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterLastDocumentUnlockValidValues
	{
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ BOOL fClosedWithoutSaving;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterLastDocumentUnlock)(
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ BOOL fClosedWithoutSaving)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterLastDocumentUnlock)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(fClosedWithoutSaving);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSRUNNINGDOCTABLEEVENTS4_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
