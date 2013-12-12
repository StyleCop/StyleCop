/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFINDSYMBOLEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFINDSYMBOLEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFindSymbolEventsNotImpl :
	public IVsFindSymbolEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindSymbolEventsNotImpl)

public:

	typedef IVsFindSymbolEvents Interface;

	STDMETHOD(OnUserOptionsChanged)(
		/*[in]*/ REFGUID /*guidSymbolScope*/,
		/*[in]*/ const VSOBSEARCHCRITERIA2* /*pobSrch*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFindSymbolEventsMockImpl :
	public IVsFindSymbolEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindSymbolEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFindSymbolEventsMockImpl)

	typedef IVsFindSymbolEvents Interface;
	struct OnUserOptionsChangedValidValues
	{
		/*[in]*/ REFGUID guidSymbolScope;
		/*[in]*/ VSOBSEARCHCRITERIA2* pobSrch;
		HRESULT retValue;
	};

	STDMETHOD(OnUserOptionsChanged)(
		/*[in]*/ REFGUID guidSymbolScope,
		/*[in]*/ const VSOBSEARCHCRITERIA2* pobSrch)
	{
		VSL_DEFINE_MOCK_METHOD(OnUserOptionsChanged)

		VSL_CHECK_VALIDVALUE(guidSymbolScope);

		VSL_CHECK_VALIDVALUE_POINTER(pobSrch);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFINDSYMBOLEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
