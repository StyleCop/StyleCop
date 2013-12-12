/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDOCUMENTLOCKHOLDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDOCUMENTLOCKHOLDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsDocumentLockHolderNotImpl :
	public IVsDocumentLockHolder
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDocumentLockHolderNotImpl)

public:

	typedef IVsDocumentLockHolder Interface;

	STDMETHOD(ShowDocumentHolder)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseDocumentHolder)(
		/*[in]*/ FRAMECLOSE /*dwSaveOptions*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDocumentLockHolderMockImpl :
	public IVsDocumentLockHolder,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDocumentLockHolderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDocumentLockHolderMockImpl)

	typedef IVsDocumentLockHolder Interface;
	struct ShowDocumentHolderValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ShowDocumentHolder)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ShowDocumentHolder)

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseDocumentHolderValidValues
	{
		/*[in]*/ FRAMECLOSE dwSaveOptions;
		HRESULT retValue;
	};

	STDMETHOD(CloseDocumentHolder)(
		/*[in]*/ FRAMECLOSE dwSaveOptions)
	{
		VSL_DEFINE_MOCK_METHOD(CloseDocumentHolder)

		VSL_CHECK_VALIDVALUE(dwSaveOptions);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDOCUMENTLOCKHOLDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
