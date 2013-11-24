/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGDOCUMENTTEXTEVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGDOCUMENTTEXTEVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugDocumentTextEvents2NotImpl :
	public IDebugDocumentTextEvents2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDocumentTextEvents2NotImpl)

public:

	typedef IDebugDocumentTextEvents2 Interface;

	STDMETHOD(onDestroy)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(onInsertText)(
		/*[in]*/ TEXT_POSITION /*pos*/,
		/*[in]*/ DWORD /*dwNumToInsert*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(onRemoveText)(
		/*[in]*/ TEXT_POSITION /*pos*/,
		/*[in]*/ DWORD /*dwNumToRemove*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(onReplaceText)(
		/*[in]*/ TEXT_POSITION /*pos*/,
		/*[in]*/ DWORD /*dwNumToReplace*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(onUpdateTextAttributes)(
		/*[in]*/ TEXT_POSITION /*pos*/,
		/*[in]*/ DWORD /*dwNumToUpdate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(onUpdateDocumentAttributes)(
		/*[in]*/ TEXT_DOC_ATTR_2 /*textdocattr*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugDocumentTextEvents2MockImpl :
	public IDebugDocumentTextEvents2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDocumentTextEvents2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugDocumentTextEvents2MockImpl)

	typedef IDebugDocumentTextEvents2 Interface;
	struct onDestroyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(onDestroy)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(onDestroy)

		VSL_RETURN_VALIDVALUES();
	}
	struct onInsertTextValidValues
	{
		/*[in]*/ TEXT_POSITION pos;
		/*[in]*/ DWORD dwNumToInsert;
		HRESULT retValue;
	};

	STDMETHOD(onInsertText)(
		/*[in]*/ TEXT_POSITION pos,
		/*[in]*/ DWORD dwNumToInsert)
	{
		VSL_DEFINE_MOCK_METHOD(onInsertText)

		VSL_CHECK_VALIDVALUE(pos);

		VSL_CHECK_VALIDVALUE(dwNumToInsert);

		VSL_RETURN_VALIDVALUES();
	}
	struct onRemoveTextValidValues
	{
		/*[in]*/ TEXT_POSITION pos;
		/*[in]*/ DWORD dwNumToRemove;
		HRESULT retValue;
	};

	STDMETHOD(onRemoveText)(
		/*[in]*/ TEXT_POSITION pos,
		/*[in]*/ DWORD dwNumToRemove)
	{
		VSL_DEFINE_MOCK_METHOD(onRemoveText)

		VSL_CHECK_VALIDVALUE(pos);

		VSL_CHECK_VALIDVALUE(dwNumToRemove);

		VSL_RETURN_VALIDVALUES();
	}
	struct onReplaceTextValidValues
	{
		/*[in]*/ TEXT_POSITION pos;
		/*[in]*/ DWORD dwNumToReplace;
		HRESULT retValue;
	};

	STDMETHOD(onReplaceText)(
		/*[in]*/ TEXT_POSITION pos,
		/*[in]*/ DWORD dwNumToReplace)
	{
		VSL_DEFINE_MOCK_METHOD(onReplaceText)

		VSL_CHECK_VALIDVALUE(pos);

		VSL_CHECK_VALIDVALUE(dwNumToReplace);

		VSL_RETURN_VALIDVALUES();
	}
	struct onUpdateTextAttributesValidValues
	{
		/*[in]*/ TEXT_POSITION pos;
		/*[in]*/ DWORD dwNumToUpdate;
		HRESULT retValue;
	};

	STDMETHOD(onUpdateTextAttributes)(
		/*[in]*/ TEXT_POSITION pos,
		/*[in]*/ DWORD dwNumToUpdate)
	{
		VSL_DEFINE_MOCK_METHOD(onUpdateTextAttributes)

		VSL_CHECK_VALIDVALUE(pos);

		VSL_CHECK_VALIDVALUE(dwNumToUpdate);

		VSL_RETURN_VALIDVALUES();
	}
	struct onUpdateDocumentAttributesValidValues
	{
		/*[in]*/ TEXT_DOC_ATTR_2 textdocattr;
		HRESULT retValue;
	};

	STDMETHOD(onUpdateDocumentAttributes)(
		/*[in]*/ TEXT_DOC_ATTR_2 textdocattr)
	{
		VSL_DEFINE_MOCK_METHOD(onUpdateDocumentAttributes)

		VSL_CHECK_VALIDVALUE(textdocattr);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGDOCUMENTTEXTEVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
