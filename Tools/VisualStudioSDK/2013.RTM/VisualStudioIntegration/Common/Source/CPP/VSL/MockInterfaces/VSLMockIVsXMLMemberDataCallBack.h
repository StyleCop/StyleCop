/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSXMLMEMBERDATACALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSXMLMEMBERDATACALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsXMLMemberDataCallBackNotImpl :
	public IVsXMLMemberDataCallBack
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsXMLMemberDataCallBackNotImpl)

public:

	typedef IVsXMLMemberDataCallBack Interface;

	STDMETHOD(GetDisplayNameForTag)(
		/*[in]*/ XMLMEMBERDATA_TAGTYPE /*nTagType*/,
		/*[in]*/ LPCOLESTR /*wszBufferIn*/,
		/*[out]*/ BSTR* /*pbstrBufferOut*/)VSL_STDMETHOD_NOTIMPL
};

class IVsXMLMemberDataCallBackMockImpl :
	public IVsXMLMemberDataCallBack,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsXMLMemberDataCallBackMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsXMLMemberDataCallBackMockImpl)

	typedef IVsXMLMemberDataCallBack Interface;
	struct GetDisplayNameForTagValidValues
	{
		/*[in]*/ XMLMEMBERDATA_TAGTYPE nTagType;
		/*[in]*/ LPCOLESTR wszBufferIn;
		/*[out]*/ BSTR* pbstrBufferOut;
		HRESULT retValue;
	};

	STDMETHOD(GetDisplayNameForTag)(
		/*[in]*/ XMLMEMBERDATA_TAGTYPE nTagType,
		/*[in]*/ LPCOLESTR wszBufferIn,
		/*[out]*/ BSTR* pbstrBufferOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetDisplayNameForTag)

		VSL_CHECK_VALIDVALUE(nTagType);

		VSL_CHECK_VALIDVALUE_STRINGW(wszBufferIn);

		VSL_SET_VALIDVALUE_BSTR(pbstrBufferOut);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSXMLMEMBERDATACALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
