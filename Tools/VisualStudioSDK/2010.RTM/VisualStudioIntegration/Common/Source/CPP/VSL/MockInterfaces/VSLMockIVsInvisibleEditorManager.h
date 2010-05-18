/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSINVISIBLEEDITORMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSINVISIBLEEDITORMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsInvisibleEditorManagerNotImpl :
	public IVsInvisibleEditorManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsInvisibleEditorManagerNotImpl)

public:

	typedef IVsInvisibleEditorManager Interface;

	STDMETHOD(RegisterInvisibleEditor)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ EDITORREGFLAGS /*dwFlags*/,
		/*[in]*/ IVsSimpleDocFactory* /*pFactory*/,
		/*[out]*/ IVsInvisibleEditor** /*ppEditor*/)VSL_STDMETHOD_NOTIMPL
};

class IVsInvisibleEditorManagerMockImpl :
	public IVsInvisibleEditorManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsInvisibleEditorManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsInvisibleEditorManagerMockImpl)

	typedef IVsInvisibleEditorManager Interface;
	struct RegisterInvisibleEditorValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ EDITORREGFLAGS dwFlags;
		/*[in]*/ IVsSimpleDocFactory* pFactory;
		/*[out]*/ IVsInvisibleEditor** ppEditor;
		HRESULT retValue;
	};

	STDMETHOD(RegisterInvisibleEditor)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ EDITORREGFLAGS dwFlags,
		/*[in]*/ IVsSimpleDocFactory* pFactory,
		/*[out]*/ IVsInvisibleEditor** ppEditor)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterInvisibleEditor)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pFactory);

		VSL_SET_VALIDVALUE_INTERFACE(ppEditor);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSINVISIBLEEDITORMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
