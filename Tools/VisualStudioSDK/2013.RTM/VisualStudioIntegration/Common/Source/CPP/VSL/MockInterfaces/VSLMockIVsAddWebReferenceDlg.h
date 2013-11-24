/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSADDWEBREFERENCEDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSADDWEBREFERENCEDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsAddWebReferenceDlgNotImpl :
	public IVsAddWebReferenceDlg
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAddWebReferenceDlgNotImpl)

public:

	typedef IVsAddWebReferenceDlg Interface;

	STDMETHOD(AddWebReferenceDlg)(
		/*[out]*/ BSTR* /*pbstrWebReferenceUrl*/,
		/*[out]*/ BOOL* /*pfCancelled*/)VSL_STDMETHOD_NOTIMPL
};

class IVsAddWebReferenceDlgMockImpl :
	public IVsAddWebReferenceDlg,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAddWebReferenceDlgMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsAddWebReferenceDlgMockImpl)

	typedef IVsAddWebReferenceDlg Interface;
	struct AddWebReferenceDlgValidValues
	{
		/*[out]*/ BSTR* pbstrWebReferenceUrl;
		/*[out]*/ BOOL* pfCancelled;
		HRESULT retValue;
	};

	STDMETHOD(AddWebReferenceDlg)(
		/*[out]*/ BSTR* pbstrWebReferenceUrl,
		/*[out]*/ BOOL* pfCancelled)
	{
		VSL_DEFINE_MOCK_METHOD(AddWebReferenceDlg)

		VSL_SET_VALIDVALUE_BSTR(pbstrWebReferenceUrl);

		VSL_SET_VALIDVALUE(pfCancelled);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSADDWEBREFERENCEDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
