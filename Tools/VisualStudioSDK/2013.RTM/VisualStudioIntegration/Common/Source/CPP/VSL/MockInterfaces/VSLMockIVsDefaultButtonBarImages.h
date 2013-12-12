/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDEFAULTBUTTONBARIMAGES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDEFAULTBUTTONBARIMAGES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsDefaultButtonBarImagesNotImpl :
	public IVsDefaultButtonBarImages
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDefaultButtonBarImagesNotImpl)

public:

	typedef IVsDefaultButtonBarImages Interface;

	STDMETHOD(GetButtonCount)(
		/*[out]*/ long* /*pcButtons*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetImageList)(
		/*[out]*/ HANDLE* /*phImageList*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDefaultButtonBarImagesMockImpl :
	public IVsDefaultButtonBarImages,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDefaultButtonBarImagesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDefaultButtonBarImagesMockImpl)

	typedef IVsDefaultButtonBarImages Interface;
	struct GetButtonCountValidValues
	{
		/*[out]*/ long* pcButtons;
		HRESULT retValue;
	};

	STDMETHOD(GetButtonCount)(
		/*[out]*/ long* pcButtons)
	{
		VSL_DEFINE_MOCK_METHOD(GetButtonCount)

		VSL_SET_VALIDVALUE(pcButtons);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetImageListValidValues
	{
		/*[out]*/ HANDLE* phImageList;
		HRESULT retValue;
	};

	STDMETHOD(GetImageList)(
		/*[out]*/ HANDLE* phImageList)
	{
		VSL_DEFINE_MOCK_METHOD(GetImageList)

		VSL_SET_VALIDVALUE(phImageList);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDEFAULTBUTTONBARIMAGES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
