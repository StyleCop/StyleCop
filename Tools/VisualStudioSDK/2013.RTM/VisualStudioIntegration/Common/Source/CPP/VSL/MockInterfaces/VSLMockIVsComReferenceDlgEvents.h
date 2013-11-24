/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMREFERENCEDLGEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMREFERENCEDLGEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsComReferenceDlgEventsNotImpl :
	public IVsComReferenceDlgEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComReferenceDlgEventsNotImpl)

public:

	typedef IVsComReferenceDlgEvents Interface;

	STDMETHOD(OnQueryChecked)(
		/*[in]*/ PCOMREFERENCEINFO /*pItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnQueryUnchecked)(
		/*[in]*/ PCOMREFERENCEINFO /*pItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnWarnMissingTypelibs)(
		/*[in]*/ UINT /*cCnt*/,
		/*[in,size_is(cCnt)]*/ PCOMREFERENCEINFO* /*rgpItems*/)VSL_STDMETHOD_NOTIMPL
};

class IVsComReferenceDlgEventsMockImpl :
	public IVsComReferenceDlgEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComReferenceDlgEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsComReferenceDlgEventsMockImpl)

	typedef IVsComReferenceDlgEvents Interface;
	struct OnQueryCheckedValidValues
	{
		/*[in]*/ PCOMREFERENCEINFO pItem;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryChecked)(
		/*[in]*/ PCOMREFERENCEINFO pItem)
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryChecked)

		VSL_CHECK_VALIDVALUE(pItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnQueryUncheckedValidValues
	{
		/*[in]*/ PCOMREFERENCEINFO pItem;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryUnchecked)(
		/*[in]*/ PCOMREFERENCEINFO pItem)
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryUnchecked)

		VSL_CHECK_VALIDVALUE(pItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnWarnMissingTypelibsValidValues
	{
		/*[in]*/ UINT cCnt;
		/*[in,size_is(cCnt)]*/ PCOMREFERENCEINFO* rgpItems;
		HRESULT retValue;
	};

	STDMETHOD(OnWarnMissingTypelibs)(
		/*[in]*/ UINT cCnt,
		/*[in,size_is(cCnt)]*/ PCOMREFERENCEINFO* rgpItems)
	{
		VSL_DEFINE_MOCK_METHOD(OnWarnMissingTypelibs)

		VSL_CHECK_VALIDVALUE(cCnt);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpItems, cCnt*sizeof(rgpItems[0]), validValues.cCnt*sizeof(validValues.rgpItems[0]));

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMREFERENCEDLGEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
