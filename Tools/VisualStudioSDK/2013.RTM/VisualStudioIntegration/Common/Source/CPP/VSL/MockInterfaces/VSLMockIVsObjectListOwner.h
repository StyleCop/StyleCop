/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSOBJECTLISTOWNER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSOBJECTLISTOWNER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsObjectListOwnerNotImpl :
	public IVsObjectListOwner
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsObjectListOwnerNotImpl)

public:

	typedef IVsObjectListOwner Interface;

	STDMETHOD(GetOptions)(
		/*[in]*/ VSOBJLISTOWNEROTPIONS* /*pOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsVisible)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ListLoadRefused)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DoWaitUI)(
		/*[in]*/ BOOL /*fStart*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifySearchHit)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ClearSearchHit)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HaveSearchHit)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CalculateExtendedText)(
		/*[in]*/ IVsObjectList* /*pList*/,
		/*[in]*/ ULONG /*iItem*/,
		/*[in]*/ LPCWSTR /*strSeperator*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExtendedText)(
		/*[out]*/ LPCWSTR* /*pwszExtText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateDisplayData)(
		/*[in]*/ IVsObjectList* /*pList*/,
		/*[in]*/ ULONG /*iItem*/,
		/*[in]*/ BOOL /*fPackageList*/,
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in,out]*/ VSTREEDISPLAYDATA* /*pData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ClearCachedData)(
		/*[in]*/ VSOBJLISTOWNERCACHEDDATAKINDS /*grfDataKinds*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ClearListFilters)(
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL
};

class IVsObjectListOwnerMockImpl :
	public IVsObjectListOwner,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsObjectListOwnerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsObjectListOwnerMockImpl)

	typedef IVsObjectListOwner Interface;
	struct GetOptionsValidValues
	{
		/*[in]*/ VSOBJLISTOWNEROTPIONS* pOptions;
		HRESULT retValue;
	};

	STDMETHOD(GetOptions)(
		/*[in]*/ VSOBJLISTOWNEROTPIONS* pOptions)
	{
		VSL_DEFINE_MOCK_METHOD(GetOptions)

		VSL_CHECK_VALIDVALUE_POINTER(pOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsVisibleValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsVisible)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsVisible)

		VSL_RETURN_VALIDVALUES();
	}
	struct ListLoadRefusedValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ListLoadRefused)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ListLoadRefused)

		VSL_RETURN_VALIDVALUES();
	}
	struct DoWaitUIValidValues
	{
		/*[in]*/ BOOL fStart;
		HRESULT retValue;
	};

	STDMETHOD(DoWaitUI)(
		/*[in]*/ BOOL fStart)
	{
		VSL_DEFINE_MOCK_METHOD(DoWaitUI)

		VSL_CHECK_VALIDVALUE(fStart);

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifySearchHitValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(NotifySearchHit)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(NotifySearchHit)

		VSL_RETURN_VALIDVALUES();
	}
	struct ClearSearchHitValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ClearSearchHit)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ClearSearchHit)

		VSL_RETURN_VALIDVALUES();
	}
	struct HaveSearchHitValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(HaveSearchHit)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(HaveSearchHit)

		VSL_RETURN_VALIDVALUES();
	}
	struct CalculateExtendedTextValidValues
	{
		/*[in]*/ IVsObjectList* pList;
		/*[in]*/ ULONG iItem;
		/*[in]*/ LPCWSTR strSeperator;
		HRESULT retValue;
	};

	STDMETHOD(CalculateExtendedText)(
		/*[in]*/ IVsObjectList* pList,
		/*[in]*/ ULONG iItem,
		/*[in]*/ LPCWSTR strSeperator)
	{
		VSL_DEFINE_MOCK_METHOD(CalculateExtendedText)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pList);

		VSL_CHECK_VALIDVALUE(iItem);

		VSL_CHECK_VALIDVALUE_STRINGW(strSeperator);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExtendedTextValidValues
	{
		/*[out]*/ LPCWSTR* pwszExtText;
		HRESULT retValue;
	};

	STDMETHOD(GetExtendedText)(
		/*[out]*/ LPCWSTR* pwszExtText)
	{
		VSL_DEFINE_MOCK_METHOD(GetExtendedText)

		VSL_SET_VALIDVALUE(pwszExtText);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateDisplayDataValidValues
	{
		/*[in]*/ IVsObjectList* pList;
		/*[in]*/ ULONG iItem;
		/*[in]*/ BOOL fPackageList;
		/*[in]*/ DWORD dwReserved;
		/*[in,out]*/ VSTREEDISPLAYDATA* pData;
		HRESULT retValue;
	};

	STDMETHOD(UpdateDisplayData)(
		/*[in]*/ IVsObjectList* pList,
		/*[in]*/ ULONG iItem,
		/*[in]*/ BOOL fPackageList,
		/*[in]*/ DWORD dwReserved,
		/*[in,out]*/ VSTREEDISPLAYDATA* pData)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateDisplayData)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pList);

		VSL_CHECK_VALIDVALUE(iItem);

		VSL_CHECK_VALIDVALUE(fPackageList);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_SET_VALIDVALUE(pData);

		VSL_RETURN_VALIDVALUES();
	}
	struct ClearCachedDataValidValues
	{
		/*[in]*/ VSOBJLISTOWNERCACHEDDATAKINDS grfDataKinds;
		HRESULT retValue;
	};

	STDMETHOD(ClearCachedData)(
		/*[in]*/ VSOBJLISTOWNERCACHEDDATAKINDS grfDataKinds)
	{
		VSL_DEFINE_MOCK_METHOD(ClearCachedData)

		VSL_CHECK_VALIDVALUE(grfDataKinds);

		VSL_RETURN_VALIDVALUES();
	}
	struct ClearListFiltersValidValues
	{
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(ClearListFilters)(
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(ClearListFilters)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSOBJECTLISTOWNER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
