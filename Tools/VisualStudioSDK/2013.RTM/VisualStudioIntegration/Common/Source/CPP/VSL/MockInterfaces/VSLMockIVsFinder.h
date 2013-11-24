/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFINDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFINDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFinderNotImpl :
	public IVsFinder
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFinderNotImpl)

public:

	typedef IVsFinder Interface;

	STDMETHOD(AttachTextImage)(
		/*[in]*/ IUnknown* /*pTextImage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Detach)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetScope)(
		/*[in]*/ IVsTextSpanSet* /*pSpanScope*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Init)(
		/*[in]*/ DWORD /*grfOptions*/,
		/*[in]*/ LPCOLESTR /*pszFindPattern*/,
		/*[in]*/ BOOL /*fReinit*/,
		/*[out,retval]*/ VSFINDERROR* /*pResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetPosition)(
		/*[in]*/ VSFINDPOS /*fp*/,
		/*[in]*/ TextAddress /*ta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Find)(
		/*[in]*/ VSFINDHOW /*grfFindHow*/,
		/*[in,out]*/ TextSpan* /*ptsMatch*/,
		/*[out,retval]*/ VSFINDSTATE* /*pgrfResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMatch)(
		/*[out,retval]*/ TextSpan* /*pts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMatchedSpans)(
		/*[out,retval]*/ IVsTextSpanSet** /*ppSpans*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTaggedSpans)(
		/*[out,retval]*/ IVsTextSpanSet** /*ppTags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetState)(
		/*[out]*/ LONG* /*pcFound*/,
		/*[out]*/ VSFINDERROR* /*pResult*/,
		/*[out,retval]*/ VSFINDSTATE* /*pState*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFinderMockImpl :
	public IVsFinder,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFinderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFinderMockImpl)

	typedef IVsFinder Interface;
	struct AttachTextImageValidValues
	{
		/*[in]*/ IUnknown* pTextImage;
		HRESULT retValue;
	};

	STDMETHOD(AttachTextImage)(
		/*[in]*/ IUnknown* pTextImage)
	{
		VSL_DEFINE_MOCK_METHOD(AttachTextImage)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTextImage);

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
	struct SetScopeValidValues
	{
		/*[in]*/ IVsTextSpanSet* pSpanScope;
		HRESULT retValue;
	};

	STDMETHOD(SetScope)(
		/*[in]*/ IVsTextSpanSet* pSpanScope)
	{
		VSL_DEFINE_MOCK_METHOD(SetScope)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSpanScope);

		VSL_RETURN_VALIDVALUES();
	}
	struct InitValidValues
	{
		/*[in]*/ DWORD grfOptions;
		/*[in]*/ LPCOLESTR pszFindPattern;
		/*[in]*/ BOOL fReinit;
		/*[out,retval]*/ VSFINDERROR* pResult;
		HRESULT retValue;
	};

	STDMETHOD(Init)(
		/*[in]*/ DWORD grfOptions,
		/*[in]*/ LPCOLESTR pszFindPattern,
		/*[in]*/ BOOL fReinit,
		/*[out,retval]*/ VSFINDERROR* pResult)
	{
		VSL_DEFINE_MOCK_METHOD(Init)

		VSL_CHECK_VALIDVALUE(grfOptions);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFindPattern);

		VSL_CHECK_VALIDVALUE(fReinit);

		VSL_SET_VALIDVALUE(pResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPositionValidValues
	{
		/*[in]*/ VSFINDPOS fp;
		/*[in]*/ TextAddress ta;
		HRESULT retValue;
	};

	STDMETHOD(SetPosition)(
		/*[in]*/ VSFINDPOS fp,
		/*[in]*/ TextAddress ta)
	{
		VSL_DEFINE_MOCK_METHOD(SetPosition)

		VSL_CHECK_VALIDVALUE(fp);

		VSL_CHECK_VALIDVALUE(ta);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindValidValues
	{
		/*[in]*/ VSFINDHOW grfFindHow;
		/*[in,out]*/ TextSpan* ptsMatch;
		/*[out,retval]*/ VSFINDSTATE* pgrfResult;
		HRESULT retValue;
	};

	STDMETHOD(Find)(
		/*[in]*/ VSFINDHOW grfFindHow,
		/*[in,out]*/ TextSpan* ptsMatch,
		/*[out,retval]*/ VSFINDSTATE* pgrfResult)
	{
		VSL_DEFINE_MOCK_METHOD(Find)

		VSL_CHECK_VALIDVALUE(grfFindHow);

		VSL_SET_VALIDVALUE(ptsMatch);

		VSL_SET_VALIDVALUE(pgrfResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMatchValidValues
	{
		/*[out,retval]*/ TextSpan* pts;
		HRESULT retValue;
	};

	STDMETHOD(GetMatch)(
		/*[out,retval]*/ TextSpan* pts)
	{
		VSL_DEFINE_MOCK_METHOD(GetMatch)

		VSL_SET_VALIDVALUE(pts);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMatchedSpansValidValues
	{
		/*[out,retval]*/ IVsTextSpanSet** ppSpans;
		HRESULT retValue;
	};

	STDMETHOD(GetMatchedSpans)(
		/*[out,retval]*/ IVsTextSpanSet** ppSpans)
	{
		VSL_DEFINE_MOCK_METHOD(GetMatchedSpans)

		VSL_SET_VALIDVALUE_INTERFACE(ppSpans);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTaggedSpansValidValues
	{
		/*[out,retval]*/ IVsTextSpanSet** ppTags;
		HRESULT retValue;
	};

	STDMETHOD(GetTaggedSpans)(
		/*[out,retval]*/ IVsTextSpanSet** ppTags)
	{
		VSL_DEFINE_MOCK_METHOD(GetTaggedSpans)

		VSL_SET_VALIDVALUE_INTERFACE(ppTags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStateValidValues
	{
		/*[out]*/ LONG* pcFound;
		/*[out]*/ VSFINDERROR* pResult;
		/*[out,retval]*/ VSFINDSTATE* pState;
		HRESULT retValue;
	};

	STDMETHOD(GetState)(
		/*[out]*/ LONG* pcFound,
		/*[out]*/ VSFINDERROR* pResult,
		/*[out,retval]*/ VSFINDSTATE* pState)
	{
		VSL_DEFINE_MOCK_METHOD(GetState)

		VSL_SET_VALIDVALUE(pcFound);

		VSL_SET_VALIDVALUE(pResult);

		VSL_SET_VALIDVALUE(pState);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFINDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
