/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTASKITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTASKITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTaskItemNotImpl :
	public IVsTaskItem
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTaskItemNotImpl)

public:

	typedef IVsTaskItem Interface;

	STDMETHOD(get_Priority)(
		/*[out,retval]*/ VSTASKPRIORITY* /*ptpPriority*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Priority)(
		/*[in]*/ VSTASKPRIORITY /*tpPriority*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Category)(
		/*[out,retval]*/ VSTASKCATEGORY* /*pCat*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_SubcategoryIndex)(
		/*[out,retval]*/ long* /*pIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ImageListIndex)(
		/*[out,retval]*/ long* /*pIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Checked)(
		/*[out,retval]*/ BOOL* /*pfChecked*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Checked)(
		/*[in]*/ BOOL /*fChecked*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Text)(
		/*[out,retval]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Text)(
		/*[in]*/ BSTR /*bstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Document)(
		/*[out,retval]*/ BSTR* /*pbstrMkDocument*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Line)(
		/*[out,retval]*/ long* /*piLine*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Column)(
		/*[out,retval]*/ long* /*piCol*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_CanDelete)(
		/*[out,retval]*/ BOOL* /*pfCanDelete*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IsReadOnly)(
		/*[in]*/ VSTASKFIELD /*field*/,
		/*[out,retval]*/ BOOL* /*pfReadOnly*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_HasHelp)(
		/*[out,retval]*/ BOOL* /*pfHasHelp*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NavigateTo)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NavigateToHelp)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnFilterTask)(
		/*[in]*/ BOOL /*fVisible*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnDeleteTask)()VSL_STDMETHOD_NOTIMPL
};

class IVsTaskItemMockImpl :
	public IVsTaskItem,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTaskItemMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTaskItemMockImpl)

	typedef IVsTaskItem Interface;
	struct get_PriorityValidValues
	{
		/*[out,retval]*/ VSTASKPRIORITY* ptpPriority;
		HRESULT retValue;
	};

	STDMETHOD(get_Priority)(
		/*[out,retval]*/ VSTASKPRIORITY* ptpPriority)
	{
		VSL_DEFINE_MOCK_METHOD(get_Priority)

		VSL_SET_VALIDVALUE(ptpPriority);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_PriorityValidValues
	{
		/*[in]*/ VSTASKPRIORITY tpPriority;
		HRESULT retValue;
	};

	STDMETHOD(put_Priority)(
		/*[in]*/ VSTASKPRIORITY tpPriority)
	{
		VSL_DEFINE_MOCK_METHOD(put_Priority)

		VSL_CHECK_VALIDVALUE(tpPriority);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CategoryValidValues
	{
		/*[out,retval]*/ VSTASKCATEGORY* pCat;
		HRESULT retValue;
	};

	STDMETHOD(get_Category)(
		/*[out,retval]*/ VSTASKCATEGORY* pCat)
	{
		VSL_DEFINE_MOCK_METHOD(get_Category)

		VSL_SET_VALIDVALUE(pCat);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_SubcategoryIndexValidValues
	{
		/*[out,retval]*/ long* pIndex;
		HRESULT retValue;
	};

	STDMETHOD(get_SubcategoryIndex)(
		/*[out,retval]*/ long* pIndex)
	{
		VSL_DEFINE_MOCK_METHOD(get_SubcategoryIndex)

		VSL_SET_VALIDVALUE(pIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ImageListIndexValidValues
	{
		/*[out,retval]*/ long* pIndex;
		HRESULT retValue;
	};

	STDMETHOD(get_ImageListIndex)(
		/*[out,retval]*/ long* pIndex)
	{
		VSL_DEFINE_MOCK_METHOD(get_ImageListIndex)

		VSL_SET_VALIDVALUE(pIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CheckedValidValues
	{
		/*[out,retval]*/ BOOL* pfChecked;
		HRESULT retValue;
	};

	STDMETHOD(get_Checked)(
		/*[out,retval]*/ BOOL* pfChecked)
	{
		VSL_DEFINE_MOCK_METHOD(get_Checked)

		VSL_SET_VALIDVALUE(pfChecked);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_CheckedValidValues
	{
		/*[in]*/ BOOL fChecked;
		HRESULT retValue;
	};

	STDMETHOD(put_Checked)(
		/*[in]*/ BOOL fChecked)
	{
		VSL_DEFINE_MOCK_METHOD(put_Checked)

		VSL_CHECK_VALIDVALUE(fChecked);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_TextValidValues
	{
		/*[out,retval]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(get_Text)(
		/*[out,retval]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(get_Text)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_TextValidValues
	{
		/*[in]*/ BSTR bstrName;
		HRESULT retValue;
	};

	STDMETHOD(put_Text)(
		/*[in]*/ BSTR bstrName)
	{
		VSL_DEFINE_MOCK_METHOD(put_Text)

		VSL_CHECK_VALIDVALUE_BSTR(bstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DocumentValidValues
	{
		/*[out,retval]*/ BSTR* pbstrMkDocument;
		HRESULT retValue;
	};

	STDMETHOD(get_Document)(
		/*[out,retval]*/ BSTR* pbstrMkDocument)
	{
		VSL_DEFINE_MOCK_METHOD(get_Document)

		VSL_SET_VALIDVALUE_BSTR(pbstrMkDocument);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_LineValidValues
	{
		/*[out,retval]*/ long* piLine;
		HRESULT retValue;
	};

	STDMETHOD(get_Line)(
		/*[out,retval]*/ long* piLine)
	{
		VSL_DEFINE_MOCK_METHOD(get_Line)

		VSL_SET_VALIDVALUE(piLine);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ColumnValidValues
	{
		/*[out,retval]*/ long* piCol;
		HRESULT retValue;
	};

	STDMETHOD(get_Column)(
		/*[out,retval]*/ long* piCol)
	{
		VSL_DEFINE_MOCK_METHOD(get_Column)

		VSL_SET_VALIDVALUE(piCol);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CanDeleteValidValues
	{
		/*[out,retval]*/ BOOL* pfCanDelete;
		HRESULT retValue;
	};

	STDMETHOD(get_CanDelete)(
		/*[out,retval]*/ BOOL* pfCanDelete)
	{
		VSL_DEFINE_MOCK_METHOD(get_CanDelete)

		VSL_SET_VALIDVALUE(pfCanDelete);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IsReadOnlyValidValues
	{
		/*[in]*/ VSTASKFIELD field;
		/*[out,retval]*/ BOOL* pfReadOnly;
		HRESULT retValue;
	};

	STDMETHOD(get_IsReadOnly)(
		/*[in]*/ VSTASKFIELD field,
		/*[out,retval]*/ BOOL* pfReadOnly)
	{
		VSL_DEFINE_MOCK_METHOD(get_IsReadOnly)

		VSL_CHECK_VALIDVALUE(field);

		VSL_SET_VALIDVALUE(pfReadOnly);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_HasHelpValidValues
	{
		/*[out,retval]*/ BOOL* pfHasHelp;
		HRESULT retValue;
	};

	STDMETHOD(get_HasHelp)(
		/*[out,retval]*/ BOOL* pfHasHelp)
	{
		VSL_DEFINE_MOCK_METHOD(get_HasHelp)

		VSL_SET_VALIDVALUE(pfHasHelp);

		VSL_RETURN_VALIDVALUES();
	}
	struct NavigateToValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(NavigateTo)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(NavigateTo)

		VSL_RETURN_VALIDVALUES();
	}
	struct NavigateToHelpValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(NavigateToHelp)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(NavigateToHelp)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnFilterTaskValidValues
	{
		/*[in]*/ BOOL fVisible;
		HRESULT retValue;
	};

	STDMETHOD(OnFilterTask)(
		/*[in]*/ BOOL fVisible)
	{
		VSL_DEFINE_MOCK_METHOD(OnFilterTask)

		VSL_CHECK_VALIDVALUE(fVisible);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnDeleteTaskValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnDeleteTask)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnDeleteTask)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTASKITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
