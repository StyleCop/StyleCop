/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMPONENTENUMERATORFACTORY3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMPONENTENUMERATORFACTORY3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "compsvcspkg80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsComponentEnumeratorFactory3NotImpl :
	public IVsComponentEnumeratorFactory3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComponentEnumeratorFactory3NotImpl)

public:

	typedef IVsComponentEnumeratorFactory3 Interface;

	STDMETHOD(GetComponentsOfPathEx)(
		/*[in]*/ BSTR /*bstrMachineName*/,
		/*[in]*/ LONG /*lEnumType*/,
		/*[in]*/ BOOL /*bForceRefresh*/,
		/*[in]*/ VSCOMPENUMEXFLAGS /*grfFlags*/,
		/*[in]*/ BSTR /*bstrPath*/,
		/*[out]*/ IEnumComponents** /*pEnumerator*/)VSL_STDMETHOD_NOTIMPL
};

class IVsComponentEnumeratorFactory3MockImpl :
	public IVsComponentEnumeratorFactory3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComponentEnumeratorFactory3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsComponentEnumeratorFactory3MockImpl)

	typedef IVsComponentEnumeratorFactory3 Interface;
	struct GetComponentsOfPathExValidValues
	{
		/*[in]*/ BSTR bstrMachineName;
		/*[in]*/ LONG lEnumType;
		/*[in]*/ BOOL bForceRefresh;
		/*[in]*/ VSCOMPENUMEXFLAGS grfFlags;
		/*[in]*/ BSTR bstrPath;
		/*[out]*/ IEnumComponents** pEnumerator;
		HRESULT retValue;
	};

	STDMETHOD(GetComponentsOfPathEx)(
		/*[in]*/ BSTR bstrMachineName,
		/*[in]*/ LONG lEnumType,
		/*[in]*/ BOOL bForceRefresh,
		/*[in]*/ VSCOMPENUMEXFLAGS grfFlags,
		/*[in]*/ BSTR bstrPath,
		/*[out]*/ IEnumComponents** pEnumerator)
	{
		VSL_DEFINE_MOCK_METHOD(GetComponentsOfPathEx)

		VSL_CHECK_VALIDVALUE_BSTR(bstrMachineName);

		VSL_CHECK_VALIDVALUE(lEnumType);

		VSL_CHECK_VALIDVALUE(bForceRefresh);

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_CHECK_VALIDVALUE_BSTR(bstrPath);

		VSL_SET_VALIDVALUE_INTERFACE(pEnumerator);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMPONENTENUMERATORFACTORY3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
