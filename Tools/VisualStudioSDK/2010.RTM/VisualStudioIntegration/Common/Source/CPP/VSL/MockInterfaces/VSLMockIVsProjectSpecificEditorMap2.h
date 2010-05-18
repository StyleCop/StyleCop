/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECTSPECIFICEDITORMAP2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECTSPECIFICEDITORMAP2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProjectSpecificEditorMap2NotImpl :
	public IVsProjectSpecificEditorMap2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectSpecificEditorMap2NotImpl)

public:

	typedef IVsProjectSpecificEditorMap2 Interface;

	STDMETHOD(GetSpecificLanguageService)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[out,retval]*/ GUID* /*pguidLanguageService*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSpecificEditorProperty)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ VSPSEPROPID /*propid*/,
		/*[out,retval]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSpecificEditorProperty)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ VSPSEPROPID /*propid*/,
		/*[in]*/ VARIANT /*var*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSpecificEditorType)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[out,retval]*/ GUID* /*pguidEditorType*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProjectSpecificEditorMap2MockImpl :
	public IVsProjectSpecificEditorMap2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectSpecificEditorMap2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProjectSpecificEditorMap2MockImpl)

	typedef IVsProjectSpecificEditorMap2 Interface;
	struct GetSpecificLanguageServiceValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[out,retval]*/ GUID* pguidLanguageService;
		HRESULT retValue;
	};

	STDMETHOD(GetSpecificLanguageService)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[out,retval]*/ GUID* pguidLanguageService)
	{
		VSL_DEFINE_MOCK_METHOD(GetSpecificLanguageService)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_SET_VALIDVALUE(pguidLanguageService);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSpecificEditorPropertyValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ VSPSEPROPID propid;
		/*[out,retval]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetSpecificEditorProperty)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ VSPSEPROPID propid,
		/*[out,retval]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetSpecificEditorProperty)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSpecificEditorPropertyValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ VSPSEPROPID propid;
		/*[in]*/ VARIANT var;
		HRESULT retValue;
	};

	STDMETHOD(SetSpecificEditorProperty)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ VSPSEPROPID propid,
		/*[in]*/ VARIANT var)
	{
		VSL_DEFINE_MOCK_METHOD(SetSpecificEditorProperty)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(propid);

		VSL_CHECK_VALIDVALUE(var);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSpecificEditorTypeValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[out,retval]*/ GUID* pguidEditorType;
		HRESULT retValue;
	};

	STDMETHOD(GetSpecificEditorType)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[out,retval]*/ GUID* pguidEditorType)
	{
		VSL_DEFINE_MOCK_METHOD(GetSpecificEditorType)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_SET_VALIDVALUE(pguidEditorType);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECTSPECIFICEDITORMAP2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
