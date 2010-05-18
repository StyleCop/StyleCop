/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSETTINGSREADER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSETTINGSREADER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSettingsReaderNotImpl :
	public IVsSettingsReader
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSettingsReaderNotImpl)

public:

	typedef IVsSettingsReader Interface;

	STDMETHOD(ReadSettingString)(
		/*[in]*/ LPCOLESTR /*pszSettingName*/,
		/*[out,retval]*/ BSTR* /*pbstrSettingValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReadSettingLong)(
		/*[in]*/ LPCOLESTR /*pszSettingName*/,
		/*[out,retval]*/ long* /*plSettingValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReadSettingBoolean)(
		/*[in]*/ LPCOLESTR /*pszSettingName*/,
		/*[out,retval]*/ BOOL* /*pfSettingValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReadSettingBytes)(
		/*[in]*/ LPCOLESTR /*pszSettingName*/,
		/*[in,out]*/ BYTE* /*pSettingValue*/,
		/*[out]*/ long* /*plDataLength*/,
		/*[in]*/ long /*lDataMax*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReadSettingAttribute)(
		/*[in]*/ LPCOLESTR /*pszSettingName*/,
		/*[in]*/ LPCOLESTR /*pszAttributeName*/,
		/*[out,retval]*/ BSTR* /*pbstrSettingValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReadSettingXml)(
		/*[in]*/ LPCOLESTR /*pszSettingName*/,
		/*[out,retval]*/ IUnknown** /*ppIXMLDOMNode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReadSettingXmlAsString)(
		/*[in]*/ LPCOLESTR /*pszSettingName*/,
		/*[out,retval]*/ BSTR* /*pbstrXML*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReadCategoryVersion)(
		/*[out]*/ int* /*pnMajor*/,
		/*[out]*/ int* /*pnMinor*/,
		/*[out]*/ int* /*pnBuild*/,
		/*[out]*/ int* /*pnRevision*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReadFileVersion)(
		/*[out]*/ int* /*pnMajor*/,
		/*[out]*/ int* /*pnMinor*/,
		/*[out]*/ int* /*pnBuild*/,
		/*[out]*/ int* /*pnRevision*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReportError)(
		/*[in]*/ LPCOLESTR /*pszError*/,
		/*[in]*/ VSSETTINGSERRORTYPES /*dwErrorType*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSettingsReaderMockImpl :
	public IVsSettingsReader,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSettingsReaderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSettingsReaderMockImpl)

	typedef IVsSettingsReader Interface;
	struct ReadSettingStringValidValues
	{
		/*[in]*/ LPCOLESTR pszSettingName;
		/*[out,retval]*/ BSTR* pbstrSettingValue;
		HRESULT retValue;
	};

	STDMETHOD(ReadSettingString)(
		/*[in]*/ LPCOLESTR pszSettingName,
		/*[out,retval]*/ BSTR* pbstrSettingValue)
	{
		VSL_DEFINE_MOCK_METHOD(ReadSettingString)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSettingName);

		VSL_SET_VALIDVALUE_BSTR(pbstrSettingValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReadSettingLongValidValues
	{
		/*[in]*/ LPCOLESTR pszSettingName;
		/*[out,retval]*/ long* plSettingValue;
		HRESULT retValue;
	};

	STDMETHOD(ReadSettingLong)(
		/*[in]*/ LPCOLESTR pszSettingName,
		/*[out,retval]*/ long* plSettingValue)
	{
		VSL_DEFINE_MOCK_METHOD(ReadSettingLong)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSettingName);

		VSL_SET_VALIDVALUE(plSettingValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReadSettingBooleanValidValues
	{
		/*[in]*/ LPCOLESTR pszSettingName;
		/*[out,retval]*/ BOOL* pfSettingValue;
		HRESULT retValue;
	};

	STDMETHOD(ReadSettingBoolean)(
		/*[in]*/ LPCOLESTR pszSettingName,
		/*[out,retval]*/ BOOL* pfSettingValue)
	{
		VSL_DEFINE_MOCK_METHOD(ReadSettingBoolean)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSettingName);

		VSL_SET_VALIDVALUE(pfSettingValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReadSettingBytesValidValues
	{
		/*[in]*/ LPCOLESTR pszSettingName;
		/*[in,out]*/ BYTE* pSettingValue;
		/*[out]*/ long* plDataLength;
		/*[in]*/ long lDataMax;
		HRESULT retValue;
	};

	STDMETHOD(ReadSettingBytes)(
		/*[in]*/ LPCOLESTR pszSettingName,
		/*[in,out]*/ BYTE* pSettingValue,
		/*[out]*/ long* plDataLength,
		/*[in]*/ long lDataMax)
	{
		VSL_DEFINE_MOCK_METHOD(ReadSettingBytes)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSettingName);

		VSL_SET_VALIDVALUE(pSettingValue);

		VSL_SET_VALIDVALUE(plDataLength);

		VSL_CHECK_VALIDVALUE(lDataMax);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReadSettingAttributeValidValues
	{
		/*[in]*/ LPCOLESTR pszSettingName;
		/*[in]*/ LPCOLESTR pszAttributeName;
		/*[out,retval]*/ BSTR* pbstrSettingValue;
		HRESULT retValue;
	};

	STDMETHOD(ReadSettingAttribute)(
		/*[in]*/ LPCOLESTR pszSettingName,
		/*[in]*/ LPCOLESTR pszAttributeName,
		/*[out,retval]*/ BSTR* pbstrSettingValue)
	{
		VSL_DEFINE_MOCK_METHOD(ReadSettingAttribute)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSettingName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszAttributeName);

		VSL_SET_VALIDVALUE_BSTR(pbstrSettingValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReadSettingXmlValidValues
	{
		/*[in]*/ LPCOLESTR pszSettingName;
		/*[out,retval]*/ IUnknown** ppIXMLDOMNode;
		HRESULT retValue;
	};

	STDMETHOD(ReadSettingXml)(
		/*[in]*/ LPCOLESTR pszSettingName,
		/*[out,retval]*/ IUnknown** ppIXMLDOMNode)
	{
		VSL_DEFINE_MOCK_METHOD(ReadSettingXml)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSettingName);

		VSL_SET_VALIDVALUE_INTERFACE(ppIXMLDOMNode);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReadSettingXmlAsStringValidValues
	{
		/*[in]*/ LPCOLESTR pszSettingName;
		/*[out,retval]*/ BSTR* pbstrXML;
		HRESULT retValue;
	};

	STDMETHOD(ReadSettingXmlAsString)(
		/*[in]*/ LPCOLESTR pszSettingName,
		/*[out,retval]*/ BSTR* pbstrXML)
	{
		VSL_DEFINE_MOCK_METHOD(ReadSettingXmlAsString)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSettingName);

		VSL_SET_VALIDVALUE_BSTR(pbstrXML);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReadCategoryVersionValidValues
	{
		/*[out]*/ int* pnMajor;
		/*[out]*/ int* pnMinor;
		/*[out]*/ int* pnBuild;
		/*[out]*/ int* pnRevision;
		HRESULT retValue;
	};

	STDMETHOD(ReadCategoryVersion)(
		/*[out]*/ int* pnMajor,
		/*[out]*/ int* pnMinor,
		/*[out]*/ int* pnBuild,
		/*[out]*/ int* pnRevision)
	{
		VSL_DEFINE_MOCK_METHOD(ReadCategoryVersion)

		VSL_SET_VALIDVALUE(pnMajor);

		VSL_SET_VALIDVALUE(pnMinor);

		VSL_SET_VALIDVALUE(pnBuild);

		VSL_SET_VALIDVALUE(pnRevision);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReadFileVersionValidValues
	{
		/*[out]*/ int* pnMajor;
		/*[out]*/ int* pnMinor;
		/*[out]*/ int* pnBuild;
		/*[out]*/ int* pnRevision;
		HRESULT retValue;
	};

	STDMETHOD(ReadFileVersion)(
		/*[out]*/ int* pnMajor,
		/*[out]*/ int* pnMinor,
		/*[out]*/ int* pnBuild,
		/*[out]*/ int* pnRevision)
	{
		VSL_DEFINE_MOCK_METHOD(ReadFileVersion)

		VSL_SET_VALIDVALUE(pnMajor);

		VSL_SET_VALIDVALUE(pnMinor);

		VSL_SET_VALIDVALUE(pnBuild);

		VSL_SET_VALIDVALUE(pnRevision);

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

#endif // IVSSETTINGSREADER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
