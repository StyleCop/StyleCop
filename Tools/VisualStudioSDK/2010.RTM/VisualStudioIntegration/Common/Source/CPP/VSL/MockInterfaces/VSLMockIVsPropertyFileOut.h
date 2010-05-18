/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROPERTYFILEOUT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROPERTYFILEOUT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsPropertyFileOutNotImpl :
	public IVsPropertyFileOut
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPropertyFileOutNotImpl)

public:

	typedef IVsPropertyFileOut Interface;

	STDMETHOD(Close)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Write)(
		/*[in]*/ LPCOLESTR /*szPropertyName*/,
		/*[in]*/ VARIANT /*varValue*/,
		/*[in,optional]*/ LPCOLESTR /*szLineComment*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WriteSzAsBSTR)(
		/*[in]*/ LPCOLESTR /*szPropertyName*/,
		/*[in]*/ LPCOLESTR /*szValue*/,
		/*[in,optional]*/ LPCOLESTR /*szLineComment*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BeginPropertySection)(
		/*[in]*/ LPCOLESTR /*szName*/,
		/*[in]*/ LPCOLESTR /*szLineComment*/,
		/*[out]*/ IVsPropertyStreamOut** /*ppIVsPropertyStreamOut*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EndPropertySection)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Flush)()VSL_STDMETHOD_NOTIMPL
};

class IVsPropertyFileOutMockImpl :
	public IVsPropertyFileOut,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPropertyFileOutMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPropertyFileOutMockImpl)

	typedef IVsPropertyFileOut Interface;
	struct CloseValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Close)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Close)

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteValidValues
	{
		/*[in]*/ LPCOLESTR szPropertyName;
		/*[in]*/ VARIANT varValue;
		/*[in,optional]*/ LPCOLESTR szLineComment;
		HRESULT retValue;
	};

	STDMETHOD(Write)(
		/*[in]*/ LPCOLESTR szPropertyName,
		/*[in]*/ VARIANT varValue,
		/*[in,optional]*/ LPCOLESTR szLineComment)
	{
		VSL_DEFINE_MOCK_METHOD(Write)

		VSL_CHECK_VALIDVALUE_STRINGW(szPropertyName);

		VSL_CHECK_VALIDVALUE(varValue);

		VSL_CHECK_VALIDVALUE_STRINGW(szLineComment);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteSzAsBSTRValidValues
	{
		/*[in]*/ LPCOLESTR szPropertyName;
		/*[in]*/ LPCOLESTR szValue;
		/*[in,optional]*/ LPCOLESTR szLineComment;
		HRESULT retValue;
	};

	STDMETHOD(WriteSzAsBSTR)(
		/*[in]*/ LPCOLESTR szPropertyName,
		/*[in]*/ LPCOLESTR szValue,
		/*[in,optional]*/ LPCOLESTR szLineComment)
	{
		VSL_DEFINE_MOCK_METHOD(WriteSzAsBSTR)

		VSL_CHECK_VALIDVALUE_STRINGW(szPropertyName);

		VSL_CHECK_VALIDVALUE_STRINGW(szValue);

		VSL_CHECK_VALIDVALUE_STRINGW(szLineComment);

		VSL_RETURN_VALIDVALUES();
	}
	struct BeginPropertySectionValidValues
	{
		/*[in]*/ LPCOLESTR szName;
		/*[in]*/ LPCOLESTR szLineComment;
		/*[out]*/ IVsPropertyStreamOut** ppIVsPropertyStreamOut;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(BeginPropertySection)(
		/*[in]*/ LPCOLESTR szName,
		/*[in]*/ LPCOLESTR szLineComment,
		/*[out]*/ IVsPropertyStreamOut** ppIVsPropertyStreamOut,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(BeginPropertySection)

		VSL_CHECK_VALIDVALUE_STRINGW(szName);

		VSL_CHECK_VALIDVALUE_STRINGW(szLineComment);

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsPropertyStreamOut);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct EndPropertySectionValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(EndPropertySection)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(EndPropertySection)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct FlushValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Flush)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Flush)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROPERTYFILEOUT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
