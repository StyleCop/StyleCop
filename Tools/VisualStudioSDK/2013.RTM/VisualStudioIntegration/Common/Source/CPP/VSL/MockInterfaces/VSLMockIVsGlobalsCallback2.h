/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSGLOBALSCALLBACK2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSGLOBALSCALLBACK2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsGlobalsCallback2NotImpl :
	public IVsGlobalsCallback2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsGlobalsCallback2NotImpl)

public:

	typedef IVsGlobalsCallback2 Interface;

	STDMETHOD(WriteVariablesToData)(
		/*[in]*/ LPCOLESTR /*pVariableName*/,
		/*[in]*/ VARIANT* /*varData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReadData)(
		/*[in]*/ IUnknown* /*pGlobals*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ClearVariables)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(VariableChanged)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanModifySource)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetParent)(
		/*[in]*/ IDispatch** /*ppOut*/)VSL_STDMETHOD_NOTIMPL
};

class IVsGlobalsCallback2MockImpl :
	public IVsGlobalsCallback2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsGlobalsCallback2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsGlobalsCallback2MockImpl)

	typedef IVsGlobalsCallback2 Interface;
	struct WriteVariablesToDataValidValues
	{
		/*[in]*/ LPCOLESTR pVariableName;
		/*[in]*/ VARIANT* varData;
		HRESULT retValue;
	};

	STDMETHOD(WriteVariablesToData)(
		/*[in]*/ LPCOLESTR pVariableName,
		/*[in]*/ VARIANT* varData)
	{
		VSL_DEFINE_MOCK_METHOD(WriteVariablesToData)

		VSL_CHECK_VALIDVALUE_STRINGW(pVariableName);

		VSL_CHECK_VALIDVALUE_POINTER(varData);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReadDataValidValues
	{
		/*[in]*/ IUnknown* pGlobals;
		HRESULT retValue;
	};

	STDMETHOD(ReadData)(
		/*[in]*/ IUnknown* pGlobals)
	{
		VSL_DEFINE_MOCK_METHOD(ReadData)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pGlobals);

		VSL_RETURN_VALIDVALUES();
	}
	struct ClearVariablesValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ClearVariables)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ClearVariables)

		VSL_RETURN_VALIDVALUES();
	}
	struct VariableChangedValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(VariableChanged)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(VariableChanged)

		VSL_RETURN_VALIDVALUES();
	}
	struct CanModifySourceValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CanModifySource)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CanModifySource)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParentValidValues
	{
		/*[in]*/ IDispatch** ppOut;
		HRESULT retValue;
	};

	STDMETHOD(GetParent)(
		/*[in]*/ IDispatch** ppOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetParent)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ppOut);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSGLOBALSCALLBACK2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
