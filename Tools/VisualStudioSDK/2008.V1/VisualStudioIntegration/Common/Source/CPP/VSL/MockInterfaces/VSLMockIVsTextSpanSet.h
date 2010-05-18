/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTSPANSET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTSPANSET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textfind.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsTextSpanSetNotImpl :
	public IVsTextSpanSet
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextSpanSetNotImpl)

public:

	typedef IVsTextSpanSet Interface;

	STDMETHOD(AttachTextImage)(
		/*[in]*/ IUnknown* /*pText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Detach)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SuspendTracking)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ResumeTracking)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Add)(
		/*[in]*/ LONG /*cel*/,
		/*[in,size_is(cel)]*/ const TextSpan* /*pSpan*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCount)(
		/*[out,retval]*/ LONG* /*pcel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAt)(
		/*[in]*/ LONG /*iEl*/,
		/*[out,retval]*/ TextSpan* /*pSpan*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveAll)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Sort)(
		/*[in]*/ DWORD /*SortOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddFromEnum)(
		/*[in]*/ IVsEnumTextSpans* /*pEnum*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextSpanSetMockImpl :
	public IVsTextSpanSet,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextSpanSetMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextSpanSetMockImpl)

	typedef IVsTextSpanSet Interface;
	struct AttachTextImageValidValues
	{
		/*[in]*/ IUnknown* pText;
		HRESULT retValue;
	};

	STDMETHOD(AttachTextImage)(
		/*[in]*/ IUnknown* pText)
	{
		VSL_DEFINE_MOCK_METHOD(AttachTextImage)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pText);

		VSL_RETURN_VALIDVALUES();
	}
	struct DetachValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Detach)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Detach)

		VSL_RETURN_VALIDVALUES();
	}
	struct SuspendTrackingValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(SuspendTracking)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(SuspendTracking)

		VSL_RETURN_VALIDVALUES();
	}
	struct ResumeTrackingValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ResumeTracking)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ResumeTracking)

		VSL_RETURN_VALIDVALUES();
	}
	struct AddValidValues
	{
		/*[in]*/ LONG cel;
		/*[in,size_is(cel)]*/ TextSpan* pSpan;
		HRESULT retValue;
	};

	STDMETHOD(Add)(
		/*[in]*/ LONG cel,
		/*[in,size_is(cel)]*/ const TextSpan* pSpan)
	{
		VSL_DEFINE_MOCK_METHOD(Add)

		VSL_CHECK_VALIDVALUE(cel);

		VSL_CHECK_VALIDVALUE_MEMCMP(pSpan, cel*sizeof(pSpan[0]), validValues.cel*sizeof(validValues.pSpan[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCountValidValues
	{
		/*[out,retval]*/ LONG* pcel;
		HRESULT retValue;
	};

	STDMETHOD(GetCount)(
		/*[out,retval]*/ LONG* pcel)
	{
		VSL_DEFINE_MOCK_METHOD(GetCount)

		VSL_SET_VALIDVALUE(pcel);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAtValidValues
	{
		/*[in]*/ LONG iEl;
		/*[out,retval]*/ TextSpan* pSpan;
		HRESULT retValue;
	};

	STDMETHOD(GetAt)(
		/*[in]*/ LONG iEl,
		/*[out,retval]*/ TextSpan* pSpan)
	{
		VSL_DEFINE_MOCK_METHOD(GetAt)

		VSL_CHECK_VALIDVALUE(iEl);

		VSL_SET_VALIDVALUE(pSpan);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveAllValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RemoveAll)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RemoveAll)

		VSL_RETURN_VALIDVALUES();
	}
	struct SortValidValues
	{
		/*[in]*/ DWORD SortOptions;
		HRESULT retValue;
	};

	STDMETHOD(Sort)(
		/*[in]*/ DWORD SortOptions)
	{
		VSL_DEFINE_MOCK_METHOD(Sort)

		VSL_CHECK_VALIDVALUE(SortOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddFromEnumValidValues
	{
		/*[in]*/ IVsEnumTextSpans* pEnum;
		HRESULT retValue;
	};

	STDMETHOD(AddFromEnum)(
		/*[in]*/ IVsEnumTextSpans* pEnum)
	{
		VSL_DEFINE_MOCK_METHOD(AddFromEnum)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pEnum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTSPANSET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
