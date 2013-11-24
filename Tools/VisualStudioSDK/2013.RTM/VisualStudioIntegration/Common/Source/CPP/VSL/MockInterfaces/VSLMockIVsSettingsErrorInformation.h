/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSETTINGSERRORINFORMATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSETTINGSERRORINFORMATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSettingsErrorInformationNotImpl :
	public IVsSettingsErrorInformation
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSettingsErrorInformationNotImpl)

public:

	typedef IVsSettingsErrorInformation Interface;

	STDMETHOD(GetCompletionStatus)(
		/*[out,retval]*/ VSSETTINGSCOMPLETIONSTATUS* /*pdwCompletionStatus*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetErrorCount)(
		/*[out,retval]*/ int* /*pnErrors*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetErrorInfo)(
		/*[in]*/ int /*nErrorIndex*/,
		/*[out]*/ VSSETTINGSERRORTYPES* /*pdwErrorType*/,
		/*[out]*/ BSTR* /*pbstrError*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSettingsErrorInformationMockImpl :
	public IVsSettingsErrorInformation,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSettingsErrorInformationMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSettingsErrorInformationMockImpl)

	typedef IVsSettingsErrorInformation Interface;
	struct GetCompletionStatusValidValues
	{
		/*[out,retval]*/ VSSETTINGSCOMPLETIONSTATUS* pdwCompletionStatus;
		HRESULT retValue;
	};

	STDMETHOD(GetCompletionStatus)(
		/*[out,retval]*/ VSSETTINGSCOMPLETIONSTATUS* pdwCompletionStatus)
	{
		VSL_DEFINE_MOCK_METHOD(GetCompletionStatus)

		VSL_SET_VALIDVALUE(pdwCompletionStatus);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetErrorCountValidValues
	{
		/*[out,retval]*/ int* pnErrors;
		HRESULT retValue;
	};

	STDMETHOD(GetErrorCount)(
		/*[out,retval]*/ int* pnErrors)
	{
		VSL_DEFINE_MOCK_METHOD(GetErrorCount)

		VSL_SET_VALIDVALUE(pnErrors);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetErrorInfoValidValues
	{
		/*[in]*/ int nErrorIndex;
		/*[out]*/ VSSETTINGSERRORTYPES* pdwErrorType;
		/*[out]*/ BSTR* pbstrError;
		HRESULT retValue;
	};

	STDMETHOD(GetErrorInfo)(
		/*[in]*/ int nErrorIndex,
		/*[out]*/ VSSETTINGSERRORTYPES* pdwErrorType,
		/*[out]*/ BSTR* pbstrError)
	{
		VSL_DEFINE_MOCK_METHOD(GetErrorInfo)

		VSL_CHECK_VALIDVALUE(nErrorIndex);

		VSL_SET_VALIDVALUE(pdwErrorType);

		VSL_SET_VALIDVALUE_BSTR(pbstrError);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSETTINGSERRORINFORMATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
