/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPERSISTSOLUTIONOPTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPERSISTSOLUTIONOPTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPersistSolutionOptsNotImpl :
	public IVsPersistSolutionOpts
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPersistSolutionOptsNotImpl)

public:

	typedef IVsPersistSolutionOpts Interface;

	STDMETHOD(SaveUserOptions)(
		/*[in]*/ IVsSolutionPersistence* /*pPersistence*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadUserOptions)(
		/*[in]*/ IVsSolutionPersistence* /*pPersistence*/,
		/*[in]*/ VSLOADUSEROPTS /*grfLoadOpts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WriteUserOptions)(
		/*[in]*/ IStream* /*pOptionsStream*/,
		/*[in]*/ LPCOLESTR /*pszKey*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReadUserOptions)(
		/*[in]*/ IStream* /*pOptionsStream*/,
		/*[in]*/ LPCOLESTR /*pszKey*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPersistSolutionOptsMockImpl :
	public IVsPersistSolutionOpts,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPersistSolutionOptsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPersistSolutionOptsMockImpl)

	typedef IVsPersistSolutionOpts Interface;
	struct SaveUserOptionsValidValues
	{
		/*[in]*/ IVsSolutionPersistence* pPersistence;
		HRESULT retValue;
	};

	STDMETHOD(SaveUserOptions)(
		/*[in]*/ IVsSolutionPersistence* pPersistence)
	{
		VSL_DEFINE_MOCK_METHOD(SaveUserOptions)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPersistence);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadUserOptionsValidValues
	{
		/*[in]*/ IVsSolutionPersistence* pPersistence;
		/*[in]*/ VSLOADUSEROPTS grfLoadOpts;
		HRESULT retValue;
	};

	STDMETHOD(LoadUserOptions)(
		/*[in]*/ IVsSolutionPersistence* pPersistence,
		/*[in]*/ VSLOADUSEROPTS grfLoadOpts)
	{
		VSL_DEFINE_MOCK_METHOD(LoadUserOptions)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPersistence);

		VSL_CHECK_VALIDVALUE(grfLoadOpts);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteUserOptionsValidValues
	{
		/*[in]*/ IStream* pOptionsStream;
		/*[in]*/ LPCOLESTR pszKey;
		HRESULT retValue;
	};

	STDMETHOD(WriteUserOptions)(
		/*[in]*/ IStream* pOptionsStream,
		/*[in]*/ LPCOLESTR pszKey)
	{
		VSL_DEFINE_MOCK_METHOD(WriteUserOptions)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOptionsStream);

		VSL_CHECK_VALIDVALUE_STRINGW(pszKey);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReadUserOptionsValidValues
	{
		/*[in]*/ IStream* pOptionsStream;
		/*[in]*/ LPCOLESTR pszKey;
		HRESULT retValue;
	};

	STDMETHOD(ReadUserOptions)(
		/*[in]*/ IStream* pOptionsStream,
		/*[in]*/ LPCOLESTR pszKey)
	{
		VSL_DEFINE_MOCK_METHOD(ReadUserOptions)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOptionsStream);

		VSL_CHECK_VALIDVALUE_STRINGW(pszKey);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPERSISTSOLUTIONOPTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
