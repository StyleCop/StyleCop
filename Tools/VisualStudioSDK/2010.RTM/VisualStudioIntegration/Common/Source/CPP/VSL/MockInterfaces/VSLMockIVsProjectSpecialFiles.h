/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECTSPECIALFILES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECTSPECIALFILES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProjectSpecialFilesNotImpl :
	public IVsProjectSpecialFiles
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectSpecialFilesNotImpl)

public:

	typedef IVsProjectSpecialFiles Interface;

	STDMETHOD(GetFile)(
		/*[in]*/ PSFFILEID /*fileID*/,
		/*[in]*/ PSFFLAGS /*grfFlags*/,
		/*[out]*/ VSITEMID* /*pitemid*/,
		/*[out]*/ BSTR* /*pbstrFilename*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProjectSpecialFilesMockImpl :
	public IVsProjectSpecialFiles,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectSpecialFilesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProjectSpecialFilesMockImpl)

	typedef IVsProjectSpecialFiles Interface;
	struct GetFileValidValues
	{
		/*[in]*/ PSFFILEID fileID;
		/*[in]*/ PSFFLAGS grfFlags;
		/*[out]*/ VSITEMID* pitemid;
		/*[out]*/ BSTR* pbstrFilename;
		HRESULT retValue;
	};

	STDMETHOD(GetFile)(
		/*[in]*/ PSFFILEID fileID,
		/*[in]*/ PSFFLAGS grfFlags,
		/*[out]*/ VSITEMID* pitemid,
		/*[out]*/ BSTR* pbstrFilename)
	{
		VSL_DEFINE_MOCK_METHOD(GetFile)

		VSL_CHECK_VALIDVALUE(fileID);

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_SET_VALIDVALUE(pitemid);

		VSL_SET_VALIDVALUE_BSTR(pbstrFilename);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECTSPECIALFILES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
