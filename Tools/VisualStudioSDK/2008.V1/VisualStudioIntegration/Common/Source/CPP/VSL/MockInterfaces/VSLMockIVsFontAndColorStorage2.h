/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFONTANDCOLORSTORAGE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFONTANDCOLORSTORAGE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFontAndColorStorage2NotImpl :
	public IVsFontAndColorStorage2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFontAndColorStorage2NotImpl)

public:

	typedef IVsFontAndColorStorage2 Interface;

	STDMETHOD(RevertFontToDefault)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RevertItemToDefault)(
		/*[in]*/ LPCOLESTR /*szName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RevertAllItemsToDefault)()VSL_STDMETHOD_NOTIMPL
};

class IVsFontAndColorStorage2MockImpl :
	public IVsFontAndColorStorage2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFontAndColorStorage2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFontAndColorStorage2MockImpl)

	typedef IVsFontAndColorStorage2 Interface;
	struct RevertFontToDefaultValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RevertFontToDefault)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RevertFontToDefault)

		VSL_RETURN_VALIDVALUES();
	}
	struct RevertItemToDefaultValidValues
	{
		/*[in]*/ LPCOLESTR szName;
		HRESULT retValue;
	};

	STDMETHOD(RevertItemToDefault)(
		/*[in]*/ LPCOLESTR szName)
	{
		VSL_DEFINE_MOCK_METHOD(RevertItemToDefault)

		VSL_CHECK_VALIDVALUE_STRINGW(szName);

		VSL_RETURN_VALIDVALUES();
	}
	struct RevertAllItemsToDefaultValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RevertAllItemsToDefault)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RevertAllItemsToDefault)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFONTANDCOLORSTORAGE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
