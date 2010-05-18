/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHELPFAVORITES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHELPFAVORITES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "VSHelp80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsHelpFavoritesNotImpl :
	public IVsHelpFavorites
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHelpFavoritesNotImpl)

public:

	typedef IVsHelpFavorites Interface;

	STDMETHOD(ShowFavorites)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddFavoriteTopic)(
		/*[in]*/ BSTR /*strTitle*/,
		/*[in]*/ BSTR /*strUrl*/,
		/*[in]*/ BSTR /*topicKeyword*/,
		/*[in]*/ BSTR /*strTopicLocale*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHelpFavoritesMockImpl :
	public IVsHelpFavorites,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHelpFavoritesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHelpFavoritesMockImpl)

	typedef IVsHelpFavorites Interface;
	struct ShowFavoritesValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ShowFavorites)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ShowFavorites)

		VSL_RETURN_VALIDVALUES();
	}
	struct AddFavoriteTopicValidValues
	{
		/*[in]*/ BSTR strTitle;
		/*[in]*/ BSTR strUrl;
		/*[in]*/ BSTR topicKeyword;
		/*[in]*/ BSTR strTopicLocale;
		HRESULT retValue;
	};

	STDMETHOD(AddFavoriteTopic)(
		/*[in]*/ BSTR strTitle,
		/*[in]*/ BSTR strUrl,
		/*[in]*/ BSTR topicKeyword,
		/*[in]*/ BSTR strTopicLocale)
	{
		VSL_DEFINE_MOCK_METHOD(AddFavoriteTopic)

		VSL_CHECK_VALIDVALUE_BSTR(strTitle);

		VSL_CHECK_VALIDVALUE_BSTR(strUrl);

		VSL_CHECK_VALIDVALUE_BSTR(topicKeyword);

		VSL_CHECK_VALIDVALUE_BSTR(strTopicLocale);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHELPFAVORITES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
