/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTASKITEM3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTASKITEM3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTaskItem3NotImpl :
	public IVsTaskItem3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTaskItem3NotImpl)

public:

	typedef IVsTaskItem3 Interface;

	STDMETHOD(GetTaskProvider)(
		/*[out]*/ IVsTaskProvider3** /*ppProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTaskName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetColumnValue)(
		/*[in]*/ int /*iField*/,
		/*[out]*/ VSTASKVALUETYPE* /*ptvtType*/,
		/*[out]*/ VSTASKVALUEFLAGS* /*ptvfFlags*/,
		/*[out]*/ VARIANT* /*pvarValue*/,
		/*[out]*/ BSTR* /*pbstrAccessibilityName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTipText)(
		/*[in]*/ int /*iField*/,
		/*[out]*/ BSTR* /*pbstrTipText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetColumnValue)(
		/*[in]*/ int /*iField*/,
		/*[in]*/ VARIANT* /*pvarValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsDirty)(
		/*[out]*/ BOOL* /*pfDirty*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEnumCount)(
		/*[in]*/ int /*iField*/,
		/*[out]*/ int* /*pnValues*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEnumValue)(
		/*[in]*/ int /*iField*/,
		/*[in]*/ int /*iValue*/,
		/*[out]*/ VARIANT* /*pvarValue*/,
		/*[out]*/ BSTR* /*pbstrAccessibilityName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnLinkClicked)(
		/*[in]*/ int /*iField*/,
		/*[in]*/ int /*iLinkIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNavigationStatusText)(
		/*[out]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDefaultEditField)(
		/*[out]*/ int* /*piField*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSurrogateProviderGuid)(
		/*[out]*/ GUID* /*pguidProvider*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTaskItem3MockImpl :
	public IVsTaskItem3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTaskItem3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTaskItem3MockImpl)

	typedef IVsTaskItem3 Interface;
	struct GetTaskProviderValidValues
	{
		/*[out]*/ IVsTaskProvider3** ppProvider;
		HRESULT retValue;
	};

	STDMETHOD(GetTaskProvider)(
		/*[out]*/ IVsTaskProvider3** ppProvider)
	{
		VSL_DEFINE_MOCK_METHOD(GetTaskProvider)

		VSL_SET_VALIDVALUE_INTERFACE(ppProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTaskNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetTaskName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetTaskName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetColumnValueValidValues
	{
		/*[in]*/ int iField;
		/*[out]*/ VSTASKVALUETYPE* ptvtType;
		/*[out]*/ VSTASKVALUEFLAGS* ptvfFlags;
		/*[out]*/ VARIANT* pvarValue;
		/*[out]*/ BSTR* pbstrAccessibilityName;
		HRESULT retValue;
	};

	STDMETHOD(GetColumnValue)(
		/*[in]*/ int iField,
		/*[out]*/ VSTASKVALUETYPE* ptvtType,
		/*[out]*/ VSTASKVALUEFLAGS* ptvfFlags,
		/*[out]*/ VARIANT* pvarValue,
		/*[out]*/ BSTR* pbstrAccessibilityName)
	{
		VSL_DEFINE_MOCK_METHOD(GetColumnValue)

		VSL_CHECK_VALIDVALUE(iField);

		VSL_SET_VALIDVALUE(ptvtType);

		VSL_SET_VALIDVALUE(ptvfFlags);

		VSL_SET_VALIDVALUE_VARIANT(pvarValue);

		VSL_SET_VALIDVALUE_BSTR(pbstrAccessibilityName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTipTextValidValues
	{
		/*[in]*/ int iField;
		/*[out]*/ BSTR* pbstrTipText;
		HRESULT retValue;
	};

	STDMETHOD(GetTipText)(
		/*[in]*/ int iField,
		/*[out]*/ BSTR* pbstrTipText)
	{
		VSL_DEFINE_MOCK_METHOD(GetTipText)

		VSL_CHECK_VALIDVALUE(iField);

		VSL_SET_VALIDVALUE_BSTR(pbstrTipText);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetColumnValueValidValues
	{
		/*[in]*/ int iField;
		/*[in]*/ VARIANT* pvarValue;
		HRESULT retValue;
	};

	STDMETHOD(SetColumnValue)(
		/*[in]*/ int iField,
		/*[in]*/ VARIANT* pvarValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetColumnValue)

		VSL_CHECK_VALIDVALUE(iField);

		VSL_CHECK_VALIDVALUE_POINTER(pvarValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsDirtyValidValues
	{
		/*[out]*/ BOOL* pfDirty;
		HRESULT retValue;
	};

	STDMETHOD(IsDirty)(
		/*[out]*/ BOOL* pfDirty)
	{
		VSL_DEFINE_MOCK_METHOD(IsDirty)

		VSL_SET_VALIDVALUE(pfDirty);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEnumCountValidValues
	{
		/*[in]*/ int iField;
		/*[out]*/ int* pnValues;
		HRESULT retValue;
	};

	STDMETHOD(GetEnumCount)(
		/*[in]*/ int iField,
		/*[out]*/ int* pnValues)
	{
		VSL_DEFINE_MOCK_METHOD(GetEnumCount)

		VSL_CHECK_VALIDVALUE(iField);

		VSL_SET_VALIDVALUE(pnValues);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEnumValueValidValues
	{
		/*[in]*/ int iField;
		/*[in]*/ int iValue;
		/*[out]*/ VARIANT* pvarValue;
		/*[out]*/ BSTR* pbstrAccessibilityName;
		HRESULT retValue;
	};

	STDMETHOD(GetEnumValue)(
		/*[in]*/ int iField,
		/*[in]*/ int iValue,
		/*[out]*/ VARIANT* pvarValue,
		/*[out]*/ BSTR* pbstrAccessibilityName)
	{
		VSL_DEFINE_MOCK_METHOD(GetEnumValue)

		VSL_CHECK_VALIDVALUE(iField);

		VSL_CHECK_VALIDVALUE(iValue);

		VSL_SET_VALIDVALUE_VARIANT(pvarValue);

		VSL_SET_VALIDVALUE_BSTR(pbstrAccessibilityName);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnLinkClickedValidValues
	{
		/*[in]*/ int iField;
		/*[in]*/ int iLinkIndex;
		HRESULT retValue;
	};

	STDMETHOD(OnLinkClicked)(
		/*[in]*/ int iField,
		/*[in]*/ int iLinkIndex)
	{
		VSL_DEFINE_MOCK_METHOD(OnLinkClicked)

		VSL_CHECK_VALIDVALUE(iField);

		VSL_CHECK_VALIDVALUE(iLinkIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNavigationStatusTextValidValues
	{
		/*[out]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(GetNavigationStatusText)(
		/*[out]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetNavigationStatusText)

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDefaultEditFieldValidValues
	{
		/*[out]*/ int* piField;
		HRESULT retValue;
	};

	STDMETHOD(GetDefaultEditField)(
		/*[out]*/ int* piField)
	{
		VSL_DEFINE_MOCK_METHOD(GetDefaultEditField)

		VSL_SET_VALIDVALUE(piField);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSurrogateProviderGuidValidValues
	{
		/*[out]*/ GUID* pguidProvider;
		HRESULT retValue;
	};

	STDMETHOD(GetSurrogateProviderGuid)(
		/*[out]*/ GUID* pguidProvider)
	{
		VSL_DEFINE_MOCK_METHOD(GetSurrogateProviderGuid)

		VSL_SET_VALIDVALUE(pguidProvider);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTASKITEM3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
