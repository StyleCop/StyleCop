/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUISHELLDOCUMENTWINDOWMGR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUISHELLDOCUMENTWINDOWMGR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsUIShellDocumentWindowMgrNotImpl :
	public IVsUIShellDocumentWindowMgr
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIShellDocumentWindowMgrNotImpl)

public:

	typedef IVsUIShellDocumentWindowMgr Interface;

	STDMETHOD(SaveDocumentWindowPositions)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ IStream* /*pStream*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReopenDocumentWindows)(
		/*[in]*/ IStream* /*pStream*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUIShellDocumentWindowMgrMockImpl :
	public IVsUIShellDocumentWindowMgr,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIShellDocumentWindowMgrMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUIShellDocumentWindowMgrMockImpl)

	typedef IVsUIShellDocumentWindowMgr Interface;
	struct SaveDocumentWindowPositionsValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ IStream* pStream;
		HRESULT retValue;
	};

	STDMETHOD(SaveDocumentWindowPositions)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ IStream* pStream)
	{
		VSL_DEFINE_MOCK_METHOD(SaveDocumentWindowPositions)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStream);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReopenDocumentWindowsValidValues
	{
		/*[in]*/ IStream* pStream;
		HRESULT retValue;
	};

	STDMETHOD(ReopenDocumentWindows)(
		/*[in]*/ IStream* pStream)
	{
		VSL_DEFINE_MOCK_METHOD(ReopenDocumentWindows)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStream);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUISHELLDOCUMENTWINDOWMGR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
