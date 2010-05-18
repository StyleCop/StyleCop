/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDYNAMICTABPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDYNAMICTABPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsDynamicTabProviderNotImpl :
	public IVsDynamicTabProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDynamicTabProviderNotImpl)

public:

	typedef IVsDynamicTabProvider Interface;

	STDMETHOD(GetTabStopElements)(
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[in]*/ long /*iLine*/,
		/*[out]*/ UINT* /*cEl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTabStop)(
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[in]*/ long /*iLine*/,
		/*[out]*/ TabStop* /*sTabStop*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDynamicTabProviderMockImpl :
	public IVsDynamicTabProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDynamicTabProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDynamicTabProviderMockImpl)

	typedef IVsDynamicTabProvider Interface;
	struct GetTabStopElementsValidValues
	{
		/*[in]*/ IVsTextLines* pBuffer;
		/*[in]*/ long iLine;
		/*[out]*/ UINT* cEl;
		HRESULT retValue;
	};

	STDMETHOD(GetTabStopElements)(
		/*[in]*/ IVsTextLines* pBuffer,
		/*[in]*/ long iLine,
		/*[out]*/ UINT* cEl)
	{
		VSL_DEFINE_MOCK_METHOD(GetTabStopElements)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_SET_VALIDVALUE(cEl);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTabStopValidValues
	{
		/*[in]*/ IVsTextLines* pBuffer;
		/*[in]*/ long iLine;
		/*[out]*/ TabStop* sTabStop;
		HRESULT retValue;
	};

	STDMETHOD(GetTabStop)(
		/*[in]*/ IVsTextLines* pBuffer,
		/*[in]*/ long iLine,
		/*[out]*/ TabStop* sTabStop)
	{
		VSL_DEFINE_MOCK_METHOD(GetTabStop)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_SET_VALIDVALUE(sTabStop);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDYNAMICTABPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
