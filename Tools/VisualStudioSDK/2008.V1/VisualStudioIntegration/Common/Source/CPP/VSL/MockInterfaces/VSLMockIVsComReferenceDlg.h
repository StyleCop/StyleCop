/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMREFERENCEDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMREFERENCEDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsComReferenceDlgNotImpl :
	public IVsComReferenceDlg
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComReferenceDlgNotImpl)

public:

	typedef IVsComReferenceDlg Interface;

	STDMETHOD(AddReferences)(
		/*[in]*/ UINT /*cRefs*/,
		/*[in]*/ PCOMREFERENCEINFO /*rgNewRefs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetCheckedReferences)(
		/*[in]*/ UINT /*cRefs*/,
		/*[in]*/ PCOMREFERENCE /*rgRefs*/,
		/*[in]*/ UINT /*cLockedRefs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseReferenceEvents)(
		/*[in]*/ IVsComReferenceDlgEvents* /*pEvents*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseReferenceEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowReferencesDialog)(
		/*[in]*/ REFSHOWFLAGS /*dwReserved*/,
		/*[in]*/ LPOLESTR /*pszReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumReferences)(
		/*[out]*/ IEnumComReferences** /*ppenum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumCheckedReferences)(
		/*[out]*/ IEnumComReferences** /*ppenum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumRemovedReferences)(
		/*[out]*/ IEnumComReferences** /*ppenum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetReferenceInfo)(
		/*[in]*/ REFGUID /*guidTypelib*/,
		/*[in]*/ WORD /*wVerMajor*/,
		/*[in]*/ WORD /*wVerMinor*/,
		/*[out]*/ PCOMREFERENCEINFO* /*ppRefInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FreeReferenceInfo)(
		/*[in]*/ PCOMREFERENCEINFO /*pRefInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPropertyPage)(
		/*[out]*/ DWORD_PTR* /*phPage*/,
		/*[in]*/ LPCOLESTR /*pszReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDisplayInfo)(
		/*[in]*/ REFSHOWFLAGS /*dwShow*/,
		/*[in]*/ LPOLESTR /*pszHelpFile*/,
		/*[in]*/ DWORD /*dwHelpContextId*/,
		/*[in]*/ LPOLESTR /*pszTitles*/)VSL_STDMETHOD_NOTIMPL
};

class IVsComReferenceDlgMockImpl :
	public IVsComReferenceDlg,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComReferenceDlgMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsComReferenceDlgMockImpl)

	typedef IVsComReferenceDlg Interface;
	struct AddReferencesValidValues
	{
		/*[in]*/ UINT cRefs;
		/*[in]*/ PCOMREFERENCEINFO rgNewRefs;
		HRESULT retValue;
	};

	STDMETHOD(AddReferences)(
		/*[in]*/ UINT cRefs,
		/*[in]*/ PCOMREFERENCEINFO rgNewRefs)
	{
		VSL_DEFINE_MOCK_METHOD(AddReferences)

		VSL_CHECK_VALIDVALUE(cRefs);

		VSL_CHECK_VALIDVALUE(rgNewRefs);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetCheckedReferencesValidValues
	{
		/*[in]*/ UINT cRefs;
		/*[in]*/ PCOMREFERENCE rgRefs;
		/*[in]*/ UINT cLockedRefs;
		HRESULT retValue;
	};

	STDMETHOD(SetCheckedReferences)(
		/*[in]*/ UINT cRefs,
		/*[in]*/ PCOMREFERENCE rgRefs,
		/*[in]*/ UINT cLockedRefs)
	{
		VSL_DEFINE_MOCK_METHOD(SetCheckedReferences)

		VSL_CHECK_VALIDVALUE(cRefs);

		VSL_CHECK_VALIDVALUE(rgRefs);

		VSL_CHECK_VALIDVALUE(cLockedRefs);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseReferenceEventsValidValues
	{
		/*[in]*/ IVsComReferenceDlgEvents* pEvents;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseReferenceEvents)(
		/*[in]*/ IVsComReferenceDlgEvents* pEvents,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseReferenceEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pEvents);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseReferenceEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseReferenceEvents)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseReferenceEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowReferencesDialogValidValues
	{
		/*[in]*/ REFSHOWFLAGS dwReserved;
		/*[in]*/ LPOLESTR pszReserved;
		HRESULT retValue;
	};

	STDMETHOD(ShowReferencesDialog)(
		/*[in]*/ REFSHOWFLAGS dwReserved,
		/*[in]*/ LPOLESTR pszReserved)
	{
		VSL_DEFINE_MOCK_METHOD(ShowReferencesDialog)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE_STRINGW(pszReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumReferencesValidValues
	{
		/*[out]*/ IEnumComReferences** ppenum;
		HRESULT retValue;
	};

	STDMETHOD(EnumReferences)(
		/*[out]*/ IEnumComReferences** ppenum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumReferences)

		VSL_SET_VALIDVALUE_INTERFACE(ppenum);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumCheckedReferencesValidValues
	{
		/*[out]*/ IEnumComReferences** ppenum;
		HRESULT retValue;
	};

	STDMETHOD(EnumCheckedReferences)(
		/*[out]*/ IEnumComReferences** ppenum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumCheckedReferences)

		VSL_SET_VALIDVALUE_INTERFACE(ppenum);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumRemovedReferencesValidValues
	{
		/*[out]*/ IEnumComReferences** ppenum;
		HRESULT retValue;
	};

	STDMETHOD(EnumRemovedReferences)(
		/*[out]*/ IEnumComReferences** ppenum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumRemovedReferences)

		VSL_SET_VALIDVALUE_INTERFACE(ppenum);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetReferenceInfoValidValues
	{
		/*[in]*/ REFGUID guidTypelib;
		/*[in]*/ WORD wVerMajor;
		/*[in]*/ WORD wVerMinor;
		/*[out]*/ PCOMREFERENCEINFO* ppRefInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetReferenceInfo)(
		/*[in]*/ REFGUID guidTypelib,
		/*[in]*/ WORD wVerMajor,
		/*[in]*/ WORD wVerMinor,
		/*[out]*/ PCOMREFERENCEINFO* ppRefInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetReferenceInfo)

		VSL_CHECK_VALIDVALUE(guidTypelib);

		VSL_CHECK_VALIDVALUE(wVerMajor);

		VSL_CHECK_VALIDVALUE(wVerMinor);

		VSL_SET_VALIDVALUE(ppRefInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct FreeReferenceInfoValidValues
	{
		/*[in]*/ PCOMREFERENCEINFO pRefInfo;
		HRESULT retValue;
	};

	STDMETHOD(FreeReferenceInfo)(
		/*[in]*/ PCOMREFERENCEINFO pRefInfo)
	{
		VSL_DEFINE_MOCK_METHOD(FreeReferenceInfo)

		VSL_CHECK_VALIDVALUE(pRefInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPropertyPageValidValues
	{
		/*[out]*/ DWORD_PTR* phPage;
		/*[in]*/ LPCOLESTR pszReserved;
		HRESULT retValue;
	};

	STDMETHOD(GetPropertyPage)(
		/*[out]*/ DWORD_PTR* phPage,
		/*[in]*/ LPCOLESTR pszReserved)
	{
		VSL_DEFINE_MOCK_METHOD(GetPropertyPage)

		VSL_SET_VALIDVALUE(phPage);

		VSL_CHECK_VALIDVALUE_STRINGW(pszReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDisplayInfoValidValues
	{
		/*[in]*/ REFSHOWFLAGS dwShow;
		/*[in]*/ LPOLESTR pszHelpFile;
		/*[in]*/ DWORD dwHelpContextId;
		/*[in]*/ LPOLESTR pszTitles;
		HRESULT retValue;
	};

	STDMETHOD(SetDisplayInfo)(
		/*[in]*/ REFSHOWFLAGS dwShow,
		/*[in]*/ LPOLESTR pszHelpFile,
		/*[in]*/ DWORD dwHelpContextId,
		/*[in]*/ LPOLESTR pszTitles)
	{
		VSL_DEFINE_MOCK_METHOD(SetDisplayInfo)

		VSL_CHECK_VALIDVALUE(dwShow);

		VSL_CHECK_VALIDVALUE_STRINGW(pszHelpFile);

		VSL_CHECK_VALIDVALUE(dwHelpContextId);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTitles);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMREFERENCEDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
