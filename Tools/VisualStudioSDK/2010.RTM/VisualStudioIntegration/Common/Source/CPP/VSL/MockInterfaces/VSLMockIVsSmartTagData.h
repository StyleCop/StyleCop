/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSMARTTAGDATA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSMARTTAGDATA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSmartTagDataNotImpl :
	public IVsSmartTagData
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSmartTagDataNotImpl)

public:

	typedef IVsSmartTagData Interface;

	STDMETHOD(GetImageIndex)(
		/*[out]*/ long* /*piIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContextMenuInfo)(
		/*[out]*/ GUID* /*guidID*/,
		/*[out]*/ long* /*nMenuID*/,
		/*[out]*/ IOleCommandTarget** /*pCmdTarget*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContextStream)(
		/*[out]*/ long* /*piPos*/,
		/*[out]*/ long* /*piLength*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnDismiss)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnInvocation)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateView)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTimerInterval)(
		/*[out]*/ long* /*piTime*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsLeftJustified)(
		/*[out]*/ BOOL* /*pfIsLeftJustified*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTipText)(
		/*[out]*/ BSTR* /*pbstrTipText*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSmartTagDataMockImpl :
	public IVsSmartTagData,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSmartTagDataMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSmartTagDataMockImpl)

	typedef IVsSmartTagData Interface;
	struct GetImageIndexValidValues
	{
		/*[out]*/ long* piIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetImageIndex)(
		/*[out]*/ long* piIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetImageIndex)

		VSL_SET_VALIDVALUE(piIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContextMenuInfoValidValues
	{
		/*[out]*/ GUID* guidID;
		/*[out]*/ long* nMenuID;
		/*[out]*/ IOleCommandTarget** pCmdTarget;
		HRESULT retValue;
	};

	STDMETHOD(GetContextMenuInfo)(
		/*[out]*/ GUID* guidID,
		/*[out]*/ long* nMenuID,
		/*[out]*/ IOleCommandTarget** pCmdTarget)
	{
		VSL_DEFINE_MOCK_METHOD(GetContextMenuInfo)

		VSL_SET_VALIDVALUE(guidID);

		VSL_SET_VALIDVALUE(nMenuID);

		VSL_SET_VALIDVALUE_INTERFACE(pCmdTarget);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContextStreamValidValues
	{
		/*[out]*/ long* piPos;
		/*[out]*/ long* piLength;
		HRESULT retValue;
	};

	STDMETHOD(GetContextStream)(
		/*[out]*/ long* piPos,
		/*[out]*/ long* piLength)
	{
		VSL_DEFINE_MOCK_METHOD(GetContextStream)

		VSL_SET_VALIDVALUE(piPos);

		VSL_SET_VALIDVALUE(piLength);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnDismissValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnDismiss)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnDismiss)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnInvocationValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnInvocation)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnInvocation)

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateViewValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(UpdateView)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(UpdateView)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTimerIntervalValidValues
	{
		/*[out]*/ long* piTime;
		HRESULT retValue;
	};

	STDMETHOD(GetTimerInterval)(
		/*[out]*/ long* piTime)
	{
		VSL_DEFINE_MOCK_METHOD(GetTimerInterval)

		VSL_SET_VALIDVALUE(piTime);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsLeftJustifiedValidValues
	{
		/*[out]*/ BOOL* pfIsLeftJustified;
		HRESULT retValue;
	};

	STDMETHOD(IsLeftJustified)(
		/*[out]*/ BOOL* pfIsLeftJustified)
	{
		VSL_DEFINE_MOCK_METHOD(IsLeftJustified)

		VSL_SET_VALIDVALUE(pfIsLeftJustified);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTipTextValidValues
	{
		/*[out]*/ BSTR* pbstrTipText;
		HRESULT retValue;
	};

	STDMETHOD(GetTipText)(
		/*[out]*/ BSTR* pbstrTipText)
	{
		VSL_DEFINE_MOCK_METHOD(GetTipText)

		VSL_SET_VALIDVALUE_BSTR(pbstrTipText);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSMARTTAGDATA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
