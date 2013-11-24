/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPARENTPROJECT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPARENTPROJECT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsParentProject2NotImpl :
	public IVsParentProject2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsParentProject2NotImpl)

public:

	typedef IVsParentProject2 Interface;

	STDMETHOD(CreateNestedProject)(
		/*[in]*/ VSITEMID /*itemidLoc*/,
		/*[in]*/ REFGUID /*rguidProjectType*/,
		/*[in]*/ LPCOLESTR /*lpszMoniker*/,
		/*[in]*/ LPCOLESTR /*lpszLocation*/,
		/*[in]*/ LPCOLESTR /*lpszName*/,
		/*[in]*/ VSCREATEPROJFLAGS /*grfCreateFlags*/,
		/*[in]*/ REFGUID /*rguidProjectID*/,
		/*[in]*/ REFIID /*iidProject*/,
		/*[out,iid_is(iidProject)]*/ void** /*ppProject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddNestedSolution)(
		/*[in]*/ VSITEMID /*itemidLoc*/,
		/*[in]*/ VSSLNOPENOPTIONS /*grfOpenOpts*/,
		/*[in]*/ LPCOLESTR /*pszFilename*/)VSL_STDMETHOD_NOTIMPL
};

class IVsParentProject2MockImpl :
	public IVsParentProject2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsParentProject2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsParentProject2MockImpl)

	typedef IVsParentProject2 Interface;
	struct CreateNestedProjectValidValues
	{
		/*[in]*/ VSITEMID itemidLoc;
		/*[in]*/ REFGUID rguidProjectType;
		/*[in]*/ LPCOLESTR lpszMoniker;
		/*[in]*/ LPCOLESTR lpszLocation;
		/*[in]*/ LPCOLESTR lpszName;
		/*[in]*/ VSCREATEPROJFLAGS grfCreateFlags;
		/*[in]*/ REFGUID rguidProjectID;
		/*[in]*/ REFIID iidProject;
		/*[out,iid_is(iidProject)]*/ void** ppProject;
		HRESULT retValue;
	};

	STDMETHOD(CreateNestedProject)(
		/*[in]*/ VSITEMID itemidLoc,
		/*[in]*/ REFGUID rguidProjectType,
		/*[in]*/ LPCOLESTR lpszMoniker,
		/*[in]*/ LPCOLESTR lpszLocation,
		/*[in]*/ LPCOLESTR lpszName,
		/*[in]*/ VSCREATEPROJFLAGS grfCreateFlags,
		/*[in]*/ REFGUID rguidProjectID,
		/*[in]*/ REFIID iidProject,
		/*[out,iid_is(iidProject)]*/ void** ppProject)
	{
		VSL_DEFINE_MOCK_METHOD(CreateNestedProject)

		VSL_CHECK_VALIDVALUE(itemidLoc);

		VSL_CHECK_VALIDVALUE(rguidProjectType);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszMoniker);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszLocation);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszName);

		VSL_CHECK_VALIDVALUE(grfCreateFlags);

		VSL_CHECK_VALIDVALUE(rguidProjectID);

		VSL_CHECK_VALIDVALUE(iidProject);

		VSL_SET_VALIDVALUE(ppProject);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddNestedSolutionValidValues
	{
		/*[in]*/ VSITEMID itemidLoc;
		/*[in]*/ VSSLNOPENOPTIONS grfOpenOpts;
		/*[in]*/ LPCOLESTR pszFilename;
		HRESULT retValue;
	};

	STDMETHOD(AddNestedSolution)(
		/*[in]*/ VSITEMID itemidLoc,
		/*[in]*/ VSSLNOPENOPTIONS grfOpenOpts,
		/*[in]*/ LPCOLESTR pszFilename)
	{
		VSL_DEFINE_MOCK_METHOD(AddNestedSolution)

		VSL_CHECK_VALIDVALUE(itemidLoc);

		VSL_CHECK_VALIDVALUE(grfOpenOpts);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPARENTPROJECT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
