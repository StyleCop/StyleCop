/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSOUTPUTWINDOWPANE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSOUTPUTWINDOWPANE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsOutputWindowPaneNotImpl :
	public IVsOutputWindowPane
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsOutputWindowPaneNotImpl)

public:

	typedef IVsOutputWindowPane Interface;

	STDMETHOD(OutputString)(
		/*[in]*/ LPCOLESTR /*pszOutputString*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Activate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Hide)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Clear)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FlushToTaskList)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OutputTaskItemString)(
		/*[in]*/ LPCOLESTR /*pszOutputString*/,
		/*[in]*/ VSTASKPRIORITY /*nPriority*/,
		/*[in]*/ VSTASKCATEGORY /*nCategory*/,
		/*[in]*/ LPCOLESTR /*pszSubcategory*/,
		/*[in]*/ VSTASKBITMAP /*nBitmap*/,
		/*[in]*/ LPCOLESTR /*pszFilename*/,
		/*[in]*/ ULONG /*nLineNum*/,
		/*[in]*/ LPCOLESTR /*pszTaskItemText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OutputTaskItemStringEx)(
		/*[in]*/ LPCOLESTR /*pszOutputString*/,
		/*[in]*/ VSTASKPRIORITY /*nPriority*/,
		/*[in]*/ VSTASKCATEGORY /*nCategory*/,
		/*[in]*/ LPCOLESTR /*pszSubcategory*/,
		/*[in]*/ VSTASKBITMAP /*nBitmap*/,
		/*[in]*/ LPCOLESTR /*pszFilename*/,
		/*[in]*/ ULONG /*nLineNum*/,
		/*[in]*/ LPCOLESTR /*pszTaskItemText*/,
		/*[in]*/ LPCOLESTR /*pszLookupKwd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetName)(
		/*[in]*/ BSTR* /*pbstrPaneName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetName)(
		/*[in]*/ LPCOLESTR /*pszPaneName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OutputStringThreadSafe)(
		/*[in]*/ LPCOLESTR /*pszOutputString*/)VSL_STDMETHOD_NOTIMPL
};

class IVsOutputWindowPaneMockImpl :
	public IVsOutputWindowPane,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsOutputWindowPaneMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsOutputWindowPaneMockImpl)

	typedef IVsOutputWindowPane Interface;
	struct OutputStringValidValues
	{
		/*[in]*/ LPCOLESTR pszOutputString;
		HRESULT retValue;
	};

	STDMETHOD(OutputString)(
		/*[in]*/ LPCOLESTR pszOutputString)
	{
		VSL_DEFINE_MOCK_METHOD(OutputString)

		VSL_CHECK_VALIDVALUE_STRINGW(pszOutputString);

		VSL_RETURN_VALIDVALUES();
	}
	struct ActivateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Activate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Activate)

		VSL_RETURN_VALIDVALUES();
	}
	struct HideValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Hide)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Hide)

		VSL_RETURN_VALIDVALUES();
	}
	struct ClearValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Clear)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Clear)

		VSL_RETURN_VALIDVALUES();
	}
	struct FlushToTaskListValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(FlushToTaskList)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(FlushToTaskList)

		VSL_RETURN_VALIDVALUES();
	}
	struct OutputTaskItemStringValidValues
	{
		/*[in]*/ LPCOLESTR pszOutputString;
		/*[in]*/ VSTASKPRIORITY nPriority;
		/*[in]*/ VSTASKCATEGORY nCategory;
		/*[in]*/ LPCOLESTR pszSubcategory;
		/*[in]*/ VSTASKBITMAP nBitmap;
		/*[in]*/ LPCOLESTR pszFilename;
		/*[in]*/ ULONG nLineNum;
		/*[in]*/ LPCOLESTR pszTaskItemText;
		HRESULT retValue;
	};

	STDMETHOD(OutputTaskItemString)(
		/*[in]*/ LPCOLESTR pszOutputString,
		/*[in]*/ VSTASKPRIORITY nPriority,
		/*[in]*/ VSTASKCATEGORY nCategory,
		/*[in]*/ LPCOLESTR pszSubcategory,
		/*[in]*/ VSTASKBITMAP nBitmap,
		/*[in]*/ LPCOLESTR pszFilename,
		/*[in]*/ ULONG nLineNum,
		/*[in]*/ LPCOLESTR pszTaskItemText)
	{
		VSL_DEFINE_MOCK_METHOD(OutputTaskItemString)

		VSL_CHECK_VALIDVALUE_STRINGW(pszOutputString);

		VSL_CHECK_VALIDVALUE(nPriority);

		VSL_CHECK_VALIDVALUE(nCategory);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSubcategory);

		VSL_CHECK_VALIDVALUE(nBitmap);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_CHECK_VALIDVALUE(nLineNum);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTaskItemText);

		VSL_RETURN_VALIDVALUES();
	}
	struct OutputTaskItemStringExValidValues
	{
		/*[in]*/ LPCOLESTR pszOutputString;
		/*[in]*/ VSTASKPRIORITY nPriority;
		/*[in]*/ VSTASKCATEGORY nCategory;
		/*[in]*/ LPCOLESTR pszSubcategory;
		/*[in]*/ VSTASKBITMAP nBitmap;
		/*[in]*/ LPCOLESTR pszFilename;
		/*[in]*/ ULONG nLineNum;
		/*[in]*/ LPCOLESTR pszTaskItemText;
		/*[in]*/ LPCOLESTR pszLookupKwd;
		HRESULT retValue;
	};

	STDMETHOD(OutputTaskItemStringEx)(
		/*[in]*/ LPCOLESTR pszOutputString,
		/*[in]*/ VSTASKPRIORITY nPriority,
		/*[in]*/ VSTASKCATEGORY nCategory,
		/*[in]*/ LPCOLESTR pszSubcategory,
		/*[in]*/ VSTASKBITMAP nBitmap,
		/*[in]*/ LPCOLESTR pszFilename,
		/*[in]*/ ULONG nLineNum,
		/*[in]*/ LPCOLESTR pszTaskItemText,
		/*[in]*/ LPCOLESTR pszLookupKwd)
	{
		VSL_DEFINE_MOCK_METHOD(OutputTaskItemStringEx)

		VSL_CHECK_VALIDVALUE_STRINGW(pszOutputString);

		VSL_CHECK_VALIDVALUE(nPriority);

		VSL_CHECK_VALIDVALUE(nCategory);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSubcategory);

		VSL_CHECK_VALIDVALUE(nBitmap);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_CHECK_VALIDVALUE(nLineNum);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTaskItemText);

		VSL_CHECK_VALIDVALUE_STRINGW(pszLookupKwd);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNameValidValues
	{
		/*[in]*/ BSTR* pbstrPaneName;
		HRESULT retValue;
	};

	STDMETHOD(GetName)(
		/*[in]*/ BSTR* pbstrPaneName)
	{
		VSL_DEFINE_MOCK_METHOD(GetName)

		VSL_CHECK_VALIDVALUE_POINTER(pbstrPaneName);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetNameValidValues
	{
		/*[in]*/ LPCOLESTR pszPaneName;
		HRESULT retValue;
	};

	STDMETHOD(SetName)(
		/*[in]*/ LPCOLESTR pszPaneName)
	{
		VSL_DEFINE_MOCK_METHOD(SetName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszPaneName);

		VSL_RETURN_VALIDVALUES();
	}
	struct OutputStringThreadSafeValidValues
	{
		/*[in]*/ LPCOLESTR pszOutputString;
		HRESULT retValue;
	};

	STDMETHOD(OutputStringThreadSafe)(
		/*[in]*/ LPCOLESTR pszOutputString)
	{
		VSL_DEFINE_MOCK_METHOD(OutputStringThreadSafe)

		VSL_CHECK_VALIDVALUE_STRINGW(pszOutputString);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSOUTPUTWINDOWPANE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
