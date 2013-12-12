/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGERROREVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGERROREVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugErrorEvent2NotImpl :
	public IDebugErrorEvent2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugErrorEvent2NotImpl)

public:

	typedef IDebugErrorEvent2 Interface;

	STDMETHOD(GetErrorMessage)(
		/*[out]*/ MESSAGETYPE* /*pMessageType*/,
		/*[out]*/ BSTR* /*pbstrErrorFormat*/,
		/*[out]*/ HRESULT* /*phrErrorReason*/,
		/*[out]*/ DWORD* /*pdwType*/,
		/*[out]*/ BSTR* /*pbstrHelpFileName*/,
		/*[out]*/ DWORD* /*pdwHelpId*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugErrorEvent2MockImpl :
	public IDebugErrorEvent2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugErrorEvent2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugErrorEvent2MockImpl)

	typedef IDebugErrorEvent2 Interface;
	struct GetErrorMessageValidValues
	{
		/*[out]*/ MESSAGETYPE* pMessageType;
		/*[out]*/ BSTR* pbstrErrorFormat;
		/*[out]*/ HRESULT* phrErrorReason;
		/*[out]*/ DWORD* pdwType;
		/*[out]*/ BSTR* pbstrHelpFileName;
		/*[out]*/ DWORD* pdwHelpId;
		HRESULT retValue;
	};

	STDMETHOD(GetErrorMessage)(
		/*[out]*/ MESSAGETYPE* pMessageType,
		/*[out]*/ BSTR* pbstrErrorFormat,
		/*[out]*/ HRESULT* phrErrorReason,
		/*[out]*/ DWORD* pdwType,
		/*[out]*/ BSTR* pbstrHelpFileName,
		/*[out]*/ DWORD* pdwHelpId)
	{
		VSL_DEFINE_MOCK_METHOD(GetErrorMessage)

		VSL_SET_VALIDVALUE(pMessageType);

		VSL_SET_VALIDVALUE_BSTR(pbstrErrorFormat);

		VSL_SET_VALIDVALUE(phrErrorReason);

		VSL_SET_VALIDVALUE(pdwType);

		VSL_SET_VALIDVALUE_BSTR(pbstrHelpFileName);

		VSL_SET_VALIDVALUE(pdwHelpId);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGERROREVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
