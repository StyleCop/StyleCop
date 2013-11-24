/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSETTINGSWRITER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSETTINGSWRITER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSettingsWriterNotImpl :
	public IVsSettingsWriter
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSettingsWriterNotImpl)

public:

	typedef IVsSettingsWriter Interface;

	STDMETHOD(WriteSettingString)(
		/*[in]*/ LPCOLESTR /*pszSettingName*/,
		/*[in]*/ LPCOLESTR /*pszSettingValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WriteSettingLong)(
		/*[in]*/ LPCOLESTR /*pszSettingName*/,
		/*[in]*/ long /*lSettingValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WriteSettingBoolean)(
		/*[in]*/ LPCOLESTR /*pszSettingName*/,
		/*[in]*/ BOOL /*fSettingValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WriteSettingBytes)(
		/*[in]*/ LPCOLESTR /*pszSettingName*/,
		/*[in,size_is(lDataLength)]*/ BYTE* /*pSettingValue*/,
		/*[in]*/ long /*lDataLength*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WriteSettingAttribute)(
		/*[in]*/ LPCOLESTR /*pszSettingName*/,
		/*[in]*/ LPCOLESTR /*pszAttributeName*/,
		/*[in]*/ LPCOLESTR /*pszSettingValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WriteSettingXml)(
		/*[in]*/ IUnknown* /*pIXMLDOMNode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WriteSettingXmlFromString)(
		/*[in]*/ LPCOLESTR /*szXML*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WriteCategoryVersion)(
		/*[in]*/ int /*nMajor*/,
		/*[in]*/ int /*nMinor*/,
		/*[in]*/ int /*nBuild*/,
		/*[in]*/ int /*nRevision*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReportError)(
		/*[in]*/ LPCOLESTR /*pszError*/,
		/*[in]*/ VSSETTINGSERRORTYPES /*dwErrorType*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSettingsWriterMockImpl :
	public IVsSettingsWriter,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSettingsWriterMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSettingsWriterMockImpl)

	typedef IVsSettingsWriter Interface;
	struct WriteSettingStringValidValues
	{
		/*[in]*/ LPCOLESTR pszSettingName;
		/*[in]*/ LPCOLESTR pszSettingValue;
		HRESULT retValue;
	};

	STDMETHOD(WriteSettingString)(
		/*[in]*/ LPCOLESTR pszSettingName,
		/*[in]*/ LPCOLESTR pszSettingValue)
	{
		VSL_DEFINE_MOCK_METHOD(WriteSettingString)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSettingName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSettingValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteSettingLongValidValues
	{
		/*[in]*/ LPCOLESTR pszSettingName;
		/*[in]*/ long lSettingValue;
		HRESULT retValue;
	};

	STDMETHOD(WriteSettingLong)(
		/*[in]*/ LPCOLESTR pszSettingName,
		/*[in]*/ long lSettingValue)
	{
		VSL_DEFINE_MOCK_METHOD(WriteSettingLong)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSettingName);

		VSL_CHECK_VALIDVALUE(lSettingValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteSettingBooleanValidValues
	{
		/*[in]*/ LPCOLESTR pszSettingName;
		/*[in]*/ BOOL fSettingValue;
		HRESULT retValue;
	};

	STDMETHOD(WriteSettingBoolean)(
		/*[in]*/ LPCOLESTR pszSettingName,
		/*[in]*/ BOOL fSettingValue)
	{
		VSL_DEFINE_MOCK_METHOD(WriteSettingBoolean)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSettingName);

		VSL_CHECK_VALIDVALUE(fSettingValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteSettingBytesValidValues
	{
		/*[in]*/ LPCOLESTR pszSettingName;
		/*[in,size_is(lDataLength)]*/ BYTE* pSettingValue;
		/*[in]*/ long lDataLength;
		HRESULT retValue;
	};

	STDMETHOD(WriteSettingBytes)(
		/*[in]*/ LPCOLESTR pszSettingName,
		/*[in,size_is(lDataLength)]*/ BYTE* pSettingValue,
		/*[in]*/ long lDataLength)
	{
		VSL_DEFINE_MOCK_METHOD(WriteSettingBytes)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSettingName);

		VSL_CHECK_VALIDVALUE_MEMCMP(pSettingValue, lDataLength*sizeof(pSettingValue[0]), validValues.lDataLength*sizeof(validValues.pSettingValue[0]));

		VSL_CHECK_VALIDVALUE(lDataLength);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteSettingAttributeValidValues
	{
		/*[in]*/ LPCOLESTR pszSettingName;
		/*[in]*/ LPCOLESTR pszAttributeName;
		/*[in]*/ LPCOLESTR pszSettingValue;
		HRESULT retValue;
	};

	STDMETHOD(WriteSettingAttribute)(
		/*[in]*/ LPCOLESTR pszSettingName,
		/*[in]*/ LPCOLESTR pszAttributeName,
		/*[in]*/ LPCOLESTR pszSettingValue)
	{
		VSL_DEFINE_MOCK_METHOD(WriteSettingAttribute)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSettingName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszAttributeName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSettingValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteSettingXmlValidValues
	{
		/*[in]*/ IUnknown* pIXMLDOMNode;
		HRESULT retValue;
	};

	STDMETHOD(WriteSettingXml)(
		/*[in]*/ IUnknown* pIXMLDOMNode)
	{
		VSL_DEFINE_MOCK_METHOD(WriteSettingXml)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIXMLDOMNode);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteSettingXmlFromStringValidValues
	{
		/*[in]*/ LPCOLESTR szXML;
		HRESULT retValue;
	};

	STDMETHOD(WriteSettingXmlFromString)(
		/*[in]*/ LPCOLESTR szXML)
	{
		VSL_DEFINE_MOCK_METHOD(WriteSettingXmlFromString)

		VSL_CHECK_VALIDVALUE_STRINGW(szXML);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteCategoryVersionValidValues
	{
		/*[in]*/ int nMajor;
		/*[in]*/ int nMinor;
		/*[in]*/ int nBuild;
		/*[in]*/ int nRevision;
		HRESULT retValue;
	};

	STDMETHOD(WriteCategoryVersion)(
		/*[in]*/ int nMajor,
		/*[in]*/ int nMinor,
		/*[in]*/ int nBuild,
		/*[in]*/ int nRevision)
	{
		VSL_DEFINE_MOCK_METHOD(WriteCategoryVersion)

		VSL_CHECK_VALIDVALUE(nMajor);

		VSL_CHECK_VALIDVALUE(nMinor);

		VSL_CHECK_VALIDVALUE(nBuild);

		VSL_CHECK_VALIDVALUE(nRevision);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReportErrorValidValues
	{
		/*[in]*/ LPCOLESTR pszError;
		/*[in]*/ VSSETTINGSERRORTYPES dwErrorType;
		HRESULT retValue;
	};

	STDMETHOD(ReportError)(
		/*[in]*/ LPCOLESTR pszError,
		/*[in]*/ VSSETTINGSERRORTYPES dwErrorType)
	{
		VSL_DEFINE_MOCK_METHOD(ReportError)

		VSL_CHECK_VALIDVALUE_STRINGW(pszError);

		VSL_CHECK_VALIDVALUE(dwErrorType);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSETTINGSWRITER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
