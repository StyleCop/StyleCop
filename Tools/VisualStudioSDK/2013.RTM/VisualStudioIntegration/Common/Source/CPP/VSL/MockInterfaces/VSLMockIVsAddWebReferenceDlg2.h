/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSADDWEBREFERENCEDLG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSADDWEBREFERENCEDLG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "compsvcspkg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsAddWebReferenceDlg2NotImpl :
	public IVsAddWebReferenceDlg2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAddWebReferenceDlg2NotImpl)

public:

	typedef IVsAddWebReferenceDlg2 Interface;

	STDMETHOD(AddWebReferenceDlg)(
		/*[in]*/ IDiscoverySession* /*pDiscoverySession*/,
		/*[out]*/ BSTR* /*pbstrWebReferenceUrl*/,
		/*[out]*/ BSTR* /*pbstrWebReferenceName*/,
		/*[out]*/ IDiscoveryResult** /*ppIDiscoveryResult*/,
		/*[out]*/ BOOL* /*pfCancelled*/)VSL_STDMETHOD_NOTIMPL
};

class IVsAddWebReferenceDlg2MockImpl :
	public IVsAddWebReferenceDlg2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAddWebReferenceDlg2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsAddWebReferenceDlg2MockImpl)

	typedef IVsAddWebReferenceDlg2 Interface;
	struct AddWebReferenceDlgValidValues
	{
		/*[in]*/ IDiscoverySession* pDiscoverySession;
		/*[out]*/ BSTR* pbstrWebReferenceUrl;
		/*[out]*/ BSTR* pbstrWebReferenceName;
		/*[out]*/ IDiscoveryResult** ppIDiscoveryResult;
		/*[out]*/ BOOL* pfCancelled;
		HRESULT retValue;
	};

	STDMETHOD(AddWebReferenceDlg)(
		/*[in]*/ IDiscoverySession* pDiscoverySession,
		/*[out]*/ BSTR* pbstrWebReferenceUrl,
		/*[out]*/ BSTR* pbstrWebReferenceName,
		/*[out]*/ IDiscoveryResult** ppIDiscoveryResult,
		/*[out]*/ BOOL* pfCancelled)
	{
		VSL_DEFINE_MOCK_METHOD(AddWebReferenceDlg)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDiscoverySession);

		VSL_SET_VALIDVALUE_BSTR(pbstrWebReferenceUrl);

		VSL_SET_VALIDVALUE_BSTR(pbstrWebReferenceName);

		VSL_SET_VALIDVALUE_INTERFACE(ppIDiscoveryResult);

		VSL_SET_VALIDVALUE(pfCancelled);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSADDWEBREFERENCEDLG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
