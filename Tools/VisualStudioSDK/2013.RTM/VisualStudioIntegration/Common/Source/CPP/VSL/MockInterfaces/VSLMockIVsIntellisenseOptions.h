/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSINTELLISENSEOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSINTELLISENSEOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsIntellisenseOptionsNotImpl :
	public IVsIntellisenseOptions
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntellisenseOptionsNotImpl)

public:

	typedef IVsIntellisenseOptions Interface;

	STDMETHOD(SetCompletorSize)(
		/*[in]*/ long /*uSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCompletorSize)(
		/*[out]*/ long* /*uSize*/)VSL_STDMETHOD_NOTIMPL
};

class IVsIntellisenseOptionsMockImpl :
	public IVsIntellisenseOptions,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntellisenseOptionsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsIntellisenseOptionsMockImpl)

	typedef IVsIntellisenseOptions Interface;
	struct SetCompletorSizeValidValues
	{
		/*[in]*/ long uSize;
		HRESULT retValue;
	};

	STDMETHOD(SetCompletorSize)(
		/*[in]*/ long uSize)
	{
		VSL_DEFINE_MOCK_METHOD(SetCompletorSize)

		VSL_CHECK_VALIDVALUE(uSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCompletorSizeValidValues
	{
		/*[out]*/ long* uSize;
		HRESULT retValue;
	};

	STDMETHOD(GetCompletorSize)(
		/*[out]*/ long* uSize)
	{
		VSL_DEFINE_MOCK_METHOD(GetCompletorSize)

		VSL_SET_VALIDVALUE(uSize);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSINTELLISENSEOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
