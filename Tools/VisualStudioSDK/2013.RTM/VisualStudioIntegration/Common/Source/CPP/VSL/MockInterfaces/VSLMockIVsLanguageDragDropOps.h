/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLANGUAGEDRAGDROPOPS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLANGUAGEDRAGDROPOPS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLanguageDragDropOpsNotImpl :
	public IVsLanguageDragDropOps
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageDragDropOpsNotImpl)

public:

	typedef IVsLanguageDragDropOps Interface;

	STDMETHOD(DragSetup)(
		/*[in]*/ IDataObject* /*pDO*/,
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[out]*/ BOOL* /*pfDocumentContainsTextData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsTextDataAtLocation)(
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[in]*/ long /*iLine*/,
		/*[in]*/ long /*iCol*/,
		/*[out]*/ BOOL* /*pfIsTextDataValidAtLoc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DragCleanup)(
		/*[in]*/ IVsTextLines* /*pBuffer*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLanguageDragDropOpsMockImpl :
	public IVsLanguageDragDropOps,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageDragDropOpsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLanguageDragDropOpsMockImpl)

	typedef IVsLanguageDragDropOps Interface;
	struct DragSetupValidValues
	{
		/*[in]*/ IDataObject* pDO;
		/*[in]*/ IVsTextLines* pBuffer;
		/*[out]*/ BOOL* pfDocumentContainsTextData;
		HRESULT retValue;
	};

	STDMETHOD(DragSetup)(
		/*[in]*/ IDataObject* pDO,
		/*[in]*/ IVsTextLines* pBuffer,
		/*[out]*/ BOOL* pfDocumentContainsTextData)
	{
		VSL_DEFINE_MOCK_METHOD(DragSetup)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDO);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_SET_VALIDVALUE(pfDocumentContainsTextData);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsTextDataAtLocationValidValues
	{
		/*[in]*/ IVsTextLines* pBuffer;
		/*[in]*/ long iLine;
		/*[in]*/ long iCol;
		/*[out]*/ BOOL* pfIsTextDataValidAtLoc;
		HRESULT retValue;
	};

	STDMETHOD(IsTextDataAtLocation)(
		/*[in]*/ IVsTextLines* pBuffer,
		/*[in]*/ long iLine,
		/*[in]*/ long iCol,
		/*[out]*/ BOOL* pfIsTextDataValidAtLoc)
	{
		VSL_DEFINE_MOCK_METHOD(IsTextDataAtLocation)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iCol);

		VSL_SET_VALIDVALUE(pfIsTextDataValidAtLoc);

		VSL_RETURN_VALIDVALUES();
	}
	struct DragCleanupValidValues
	{
		/*[in]*/ IVsTextLines* pBuffer;
		HRESULT retValue;
	};

	STDMETHOD(DragCleanup)(
		/*[in]*/ IVsTextLines* pBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(DragCleanup)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLANGUAGEDRAGDROPOPS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
