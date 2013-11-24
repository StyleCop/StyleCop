/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIERARCHYREFACTORNOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIERARCHYREFACTORNOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsHierarchyRefactorNotifyNotImpl :
	public IVsHierarchyRefactorNotify
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyRefactorNotifyNotImpl)

public:

	typedef IVsHierarchyRefactorNotify Interface;

	STDMETHOD(OnBeforeGlobalSymbolRenamed)(
		/*[in]*/ ULONG /*cItemsAffected*/,
		/*[in,size_is(cItemsAffected)]*/ VSITEMID[] /*rgItemsAffected*/,
		/*[in]*/ ULONG /*cRQNames*/,
		/*[in,size_is(cRQNames)]*/ LPCOLESTR[] /*rglpszRQName*/,
		/*[in]*/ LPCOLESTR /*lpszNewName*/,
		/*[in]*/ BOOL /*promptContinueOnFail*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnGlobalSymbolRenamed)(
		/*[in]*/ ULONG /*cItemsAffected*/,
		/*[in,size_is(cItemsAffected)]*/ VSITEMID[] /*rgItemsAffected*/,
		/*[in]*/ ULONG /*cRQNames*/,
		/*[in,size_is(cRQNames)]*/ LPCOLESTR[] /*rglpszRQName*/,
		/*[in]*/ LPCOLESTR /*lpszNewName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnBeforeReorderParams)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ LPCOLESTR /*lpszRQName*/,
		/*[in]*/ ULONG /*cParamIndexes*/,
		/*[in,size_is(cParamIndexes)]*/ ULONG[] /*rgParamIndexes*/,
		/*[in]*/ BOOL /*promptContinueOnFail*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnReorderParams)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ LPCOLESTR /*lpszRQName*/,
		/*[in]*/ ULONG /*cParamIndexes*/,
		/*[in,size_is(cParamIndexes)]*/ ULONG[] /*rgParamIndexes*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnBeforeRemoveParams)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ LPCOLESTR /*lpszRQName*/,
		/*[in]*/ ULONG /*cParamIndexes*/,
		/*[in,size_is(cParamIndexes)]*/ ULONG[] /*rgParamIndexes*/,
		/*[in]*/ BOOL /*promptContinueOnFail*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnRemoveParams)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ LPCOLESTR /*lpszRQName*/,
		/*[in]*/ ULONG /*cParamIndexes*/,
		/*[in,size_is(cParamIndexes)]*/ ULONG[] /*rgParamIndexes*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnBeforeAddParams)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ LPCOLESTR /*lpszRQName*/,
		/*[in]*/ ULONG /*cParams*/,
		/*[in,size_is(cParams)]*/ ULONG[] /*rgszParamIndexes*/,
		/*[in,size_is(cParams)]*/ LPCOLESTR[] /*rgszRQTypeNames*/,
		/*[in,size_is(cParams)]*/ LPCOLESTR[] /*rgszParamNames*/,
		/*[in]*/ BOOL /*promptContinueOnFail*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAddParams)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ LPCOLESTR /*lpszRQName*/,
		/*[in]*/ ULONG /*cParams*/,
		/*[in,size_is(cParams)]*/ ULONG[] /*rgszParamIndexes*/,
		/*[in,size_is(cParams)]*/ LPCOLESTR[] /*rgszRQTypeNames*/,
		/*[in,size_is(cParams)]*/ LPCOLESTR[] /*rgszParamNames*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHierarchyRefactorNotifyMockImpl :
	public IVsHierarchyRefactorNotify,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyRefactorNotifyMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHierarchyRefactorNotifyMockImpl)

	typedef IVsHierarchyRefactorNotify Interface;
	struct OnBeforeGlobalSymbolRenamedValidValues
	{
		/*[in]*/ ULONG cItemsAffected;
		/*[in,size_is(cItemsAffected)]*/ VSITEMID* rgItemsAffected;
		/*[in]*/ ULONG cRQNames;
		/*[in,size_is(cRQNames)]*/ LPCOLESTR* rglpszRQName;
		/*[in]*/ LPCOLESTR lpszNewName;
		/*[in]*/ BOOL promptContinueOnFail;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeGlobalSymbolRenamed)(
		/*[in]*/ ULONG cItemsAffected,
		/*[in,size_is(cItemsAffected)]*/ VSITEMID rgItemsAffected[],
		/*[in]*/ ULONG cRQNames,
		/*[in,size_is(cRQNames)]*/ LPCOLESTR rglpszRQName[],
		/*[in]*/ LPCOLESTR lpszNewName,
		/*[in]*/ BOOL promptContinueOnFail)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeGlobalSymbolRenamed)

		VSL_CHECK_VALIDVALUE(cItemsAffected);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgItemsAffected, cItemsAffected*sizeof(rgItemsAffected[0]), validValues.cItemsAffected*sizeof(validValues.rgItemsAffected[0]));

		VSL_CHECK_VALIDVALUE(cRQNames);

		VSL_CHECK_VALIDVALUE_MEMCMP(rglpszRQName, cRQNames*sizeof(rglpszRQName[0]), validValues.cRQNames*sizeof(validValues.rglpszRQName[0]));

		VSL_CHECK_VALIDVALUE_STRINGW(lpszNewName);

		VSL_CHECK_VALIDVALUE(promptContinueOnFail);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnGlobalSymbolRenamedValidValues
	{
		/*[in]*/ ULONG cItemsAffected;
		/*[in,size_is(cItemsAffected)]*/ VSITEMID* rgItemsAffected;
		/*[in]*/ ULONG cRQNames;
		/*[in,size_is(cRQNames)]*/ LPCOLESTR* rglpszRQName;
		/*[in]*/ LPCOLESTR lpszNewName;
		HRESULT retValue;
	};

	STDMETHOD(OnGlobalSymbolRenamed)(
		/*[in]*/ ULONG cItemsAffected,
		/*[in,size_is(cItemsAffected)]*/ VSITEMID rgItemsAffected[],
		/*[in]*/ ULONG cRQNames,
		/*[in,size_is(cRQNames)]*/ LPCOLESTR rglpszRQName[],
		/*[in]*/ LPCOLESTR lpszNewName)
	{
		VSL_DEFINE_MOCK_METHOD(OnGlobalSymbolRenamed)

		VSL_CHECK_VALIDVALUE(cItemsAffected);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgItemsAffected, cItemsAffected*sizeof(rgItemsAffected[0]), validValues.cItemsAffected*sizeof(validValues.rgItemsAffected[0]));

		VSL_CHECK_VALIDVALUE(cRQNames);

		VSL_CHECK_VALIDVALUE_MEMCMP(rglpszRQName, cRQNames*sizeof(rglpszRQName[0]), validValues.cRQNames*sizeof(validValues.rglpszRQName[0]));

		VSL_CHECK_VALIDVALUE_STRINGW(lpszNewName);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnBeforeReorderParamsValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ LPCOLESTR lpszRQName;
		/*[in]*/ ULONG cParamIndexes;
		/*[in,size_is(cParamIndexes)]*/ ULONG* rgParamIndexes;
		/*[in]*/ BOOL promptContinueOnFail;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeReorderParams)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ LPCOLESTR lpszRQName,
		/*[in]*/ ULONG cParamIndexes,
		/*[in,size_is(cParamIndexes)]*/ ULONG rgParamIndexes[],
		/*[in]*/ BOOL promptContinueOnFail)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeReorderParams)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszRQName);

		VSL_CHECK_VALIDVALUE(cParamIndexes);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgParamIndexes, cParamIndexes*sizeof(rgParamIndexes[0]), validValues.cParamIndexes*sizeof(validValues.rgParamIndexes[0]));

		VSL_CHECK_VALIDVALUE(promptContinueOnFail);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnReorderParamsValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ LPCOLESTR lpszRQName;
		/*[in]*/ ULONG cParamIndexes;
		/*[in,size_is(cParamIndexes)]*/ ULONG* rgParamIndexes;
		HRESULT retValue;
	};

	STDMETHOD(OnReorderParams)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ LPCOLESTR lpszRQName,
		/*[in]*/ ULONG cParamIndexes,
		/*[in,size_is(cParamIndexes)]*/ ULONG rgParamIndexes[])
	{
		VSL_DEFINE_MOCK_METHOD(OnReorderParams)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszRQName);

		VSL_CHECK_VALIDVALUE(cParamIndexes);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgParamIndexes, cParamIndexes*sizeof(rgParamIndexes[0]), validValues.cParamIndexes*sizeof(validValues.rgParamIndexes[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnBeforeRemoveParamsValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ LPCOLESTR lpszRQName;
		/*[in]*/ ULONG cParamIndexes;
		/*[in,size_is(cParamIndexes)]*/ ULONG* rgParamIndexes;
		/*[in]*/ BOOL promptContinueOnFail;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeRemoveParams)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ LPCOLESTR lpszRQName,
		/*[in]*/ ULONG cParamIndexes,
		/*[in,size_is(cParamIndexes)]*/ ULONG rgParamIndexes[],
		/*[in]*/ BOOL promptContinueOnFail)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeRemoveParams)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszRQName);

		VSL_CHECK_VALIDVALUE(cParamIndexes);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgParamIndexes, cParamIndexes*sizeof(rgParamIndexes[0]), validValues.cParamIndexes*sizeof(validValues.rgParamIndexes[0]));

		VSL_CHECK_VALIDVALUE(promptContinueOnFail);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnRemoveParamsValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ LPCOLESTR lpszRQName;
		/*[in]*/ ULONG cParamIndexes;
		/*[in,size_is(cParamIndexes)]*/ ULONG* rgParamIndexes;
		HRESULT retValue;
	};

	STDMETHOD(OnRemoveParams)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ LPCOLESTR lpszRQName,
		/*[in]*/ ULONG cParamIndexes,
		/*[in,size_is(cParamIndexes)]*/ ULONG rgParamIndexes[])
	{
		VSL_DEFINE_MOCK_METHOD(OnRemoveParams)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszRQName);

		VSL_CHECK_VALIDVALUE(cParamIndexes);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgParamIndexes, cParamIndexes*sizeof(rgParamIndexes[0]), validValues.cParamIndexes*sizeof(validValues.rgParamIndexes[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnBeforeAddParamsValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ LPCOLESTR lpszRQName;
		/*[in]*/ ULONG cParams;
		/*[in,size_is(cParams)]*/ ULONG* rgszParamIndexes;
		/*[in,size_is(cParams)]*/ LPCOLESTR* rgszRQTypeNames;
		/*[in,size_is(cParams)]*/ LPCOLESTR* rgszParamNames;
		/*[in]*/ BOOL promptContinueOnFail;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeAddParams)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ LPCOLESTR lpszRQName,
		/*[in]*/ ULONG cParams,
		/*[in,size_is(cParams)]*/ ULONG rgszParamIndexes[],
		/*[in,size_is(cParams)]*/ LPCOLESTR rgszRQTypeNames[],
		/*[in,size_is(cParams)]*/ LPCOLESTR rgszParamNames[],
		/*[in]*/ BOOL promptContinueOnFail)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeAddParams)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszRQName);

		VSL_CHECK_VALIDVALUE(cParams);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszParamIndexes, cParams*sizeof(rgszParamIndexes[0]), validValues.cParams*sizeof(validValues.rgszParamIndexes[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszRQTypeNames, cParams*sizeof(rgszRQTypeNames[0]), validValues.cParams*sizeof(validValues.rgszRQTypeNames[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszParamNames, cParams*sizeof(rgszParamNames[0]), validValues.cParams*sizeof(validValues.rgszParamNames[0]));

		VSL_CHECK_VALIDVALUE(promptContinueOnFail);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAddParamsValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ LPCOLESTR lpszRQName;
		/*[in]*/ ULONG cParams;
		/*[in,size_is(cParams)]*/ ULONG* rgszParamIndexes;
		/*[in,size_is(cParams)]*/ LPCOLESTR* rgszRQTypeNames;
		/*[in,size_is(cParams)]*/ LPCOLESTR* rgszParamNames;
		HRESULT retValue;
	};

	STDMETHOD(OnAddParams)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ LPCOLESTR lpszRQName,
		/*[in]*/ ULONG cParams,
		/*[in,size_is(cParams)]*/ ULONG rgszParamIndexes[],
		/*[in,size_is(cParams)]*/ LPCOLESTR rgszRQTypeNames[],
		/*[in,size_is(cParams)]*/ LPCOLESTR rgszParamNames[])
	{
		VSL_DEFINE_MOCK_METHOD(OnAddParams)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszRQName);

		VSL_CHECK_VALIDVALUE(cParams);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszParamIndexes, cParams*sizeof(rgszParamIndexes[0]), validValues.cParams*sizeof(validValues.rgszParamIndexes[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszRQTypeNames, cParams*sizeof(rgszRQTypeNames[0]), validValues.cParams*sizeof(validValues.rgszRQTypeNames[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszParamNames, cParams*sizeof(rgszParamNames[0]), validValues.cParams*sizeof(validValues.rgszParamNames[0]));

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHIERARCHYREFACTORNOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
