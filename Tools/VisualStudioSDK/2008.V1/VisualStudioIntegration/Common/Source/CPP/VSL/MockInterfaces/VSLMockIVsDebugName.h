/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDEBUGNAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDEBUGNAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsDebugNameNotImpl :
	public IVsDebugName
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDebugNameNotImpl)

public:

	typedef IVsDebugName Interface;

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLocation)(
		/*[out]*/ BSTR* /*pbstrMkDoc*/,
		/*[out]*/ TextSpan* /*pspanLocation*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDebugNameMockImpl :
	public IVsDebugName,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDebugNameMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDebugNameMockImpl)

	typedef IVsDebugName Interface;
	struct GetNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLocationValidValues
	{
		/*[out]*/ BSTR* pbstrMkDoc;
		/*[out]*/ TextSpan* pspanLocation;
		HRESULT retValue;
	};

	STDMETHOD(GetLocation)(
		/*[out]*/ BSTR* pbstrMkDoc,
		/*[out]*/ TextSpan* pspanLocation)
	{
		VSL_DEFINE_MOCK_METHOD(GetLocation)

		VSL_SET_VALIDVALUE_BSTR(pbstrMkDoc);

		VSL_SET_VALIDVALUE(pspanLocation);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDEBUGNAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
