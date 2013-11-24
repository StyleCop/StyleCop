/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROPERTYPROXYEESIDE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROPERTYPROXYEESIDE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IPropertyProxyEESideNotImpl :
	public IPropertyProxyEESide
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPropertyProxyEESideNotImpl)

public:

	typedef IPropertyProxyEESide Interface;

	STDMETHOD(InitSourceDataProvider)(
		/*[out]*/ IEEDataStorage** /*dataOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetManagedViewerCreationData)(
		/*[out]*/ BSTR* /*assemName*/,
		/*[out]*/ IEEDataStorage** /*assemBytes*/,
		/*[out]*/ IEEDataStorage** /*assemPdb*/,
		/*[out]*/ BSTR* /*className*/,
		/*[out]*/ ASSEMBLYLOCRESOLUTION* /*alr*/,
		/*[out]*/ BOOL* /*replacementOk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetInitialData)(
		/*[out]*/ IEEDataStorage** /*dataOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateReplacementObject)(
		/*[in]*/ IEEDataStorage* /*dataIn*/,
		/*[out]*/ IEEDataStorage** /*dataOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InPlaceUpdateObject)(
		/*[in]*/ IEEDataStorage* /*dataIn*/,
		/*[out]*/ IEEDataStorage** /*dataOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ResolveAssemblyReference)(
		/*[in]*/ LPCOLESTR /*assemName*/,
		/*[in]*/ GETASSEMBLY /*flags*/,
		/*[out]*/ IEEDataStorage** /*assemBytes*/,
		/*[out]*/ IEEDataStorage** /*assemPdb*/,
		/*[out]*/ BSTR* /*assemLocation*/,
		/*[out]*/ ASSEMBLYLOCRESOLUTION* /*alr*/)VSL_STDMETHOD_NOTIMPL
};

class IPropertyProxyEESideMockImpl :
	public IPropertyProxyEESide,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPropertyProxyEESideMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPropertyProxyEESideMockImpl)

	typedef IPropertyProxyEESide Interface;
	struct InitSourceDataProviderValidValues
	{
		/*[out]*/ IEEDataStorage** dataOut;
		HRESULT retValue;
	};

	STDMETHOD(InitSourceDataProvider)(
		/*[out]*/ IEEDataStorage** dataOut)
	{
		VSL_DEFINE_MOCK_METHOD(InitSourceDataProvider)

		VSL_SET_VALIDVALUE_INTERFACE(dataOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetManagedViewerCreationDataValidValues
	{
		/*[out]*/ BSTR* assemName;
		/*[out]*/ IEEDataStorage** assemBytes;
		/*[out]*/ IEEDataStorage** assemPdb;
		/*[out]*/ BSTR* className;
		/*[out]*/ ASSEMBLYLOCRESOLUTION* alr;
		/*[out]*/ BOOL* replacementOk;
		HRESULT retValue;
	};

	STDMETHOD(GetManagedViewerCreationData)(
		/*[out]*/ BSTR* assemName,
		/*[out]*/ IEEDataStorage** assemBytes,
		/*[out]*/ IEEDataStorage** assemPdb,
		/*[out]*/ BSTR* className,
		/*[out]*/ ASSEMBLYLOCRESOLUTION* alr,
		/*[out]*/ BOOL* replacementOk)
	{
		VSL_DEFINE_MOCK_METHOD(GetManagedViewerCreationData)

		VSL_SET_VALIDVALUE_BSTR(assemName);

		VSL_SET_VALIDVALUE_INTERFACE(assemBytes);

		VSL_SET_VALIDVALUE_INTERFACE(assemPdb);

		VSL_SET_VALIDVALUE_BSTR(className);

		VSL_SET_VALIDVALUE(alr);

		VSL_SET_VALIDVALUE(replacementOk);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetInitialDataValidValues
	{
		/*[out]*/ IEEDataStorage** dataOut;
		HRESULT retValue;
	};

	STDMETHOD(GetInitialData)(
		/*[out]*/ IEEDataStorage** dataOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetInitialData)

		VSL_SET_VALIDVALUE_INTERFACE(dataOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateReplacementObjectValidValues
	{
		/*[in]*/ IEEDataStorage* dataIn;
		/*[out]*/ IEEDataStorage** dataOut;
		HRESULT retValue;
	};

	STDMETHOD(CreateReplacementObject)(
		/*[in]*/ IEEDataStorage* dataIn,
		/*[out]*/ IEEDataStorage** dataOut)
	{
		VSL_DEFINE_MOCK_METHOD(CreateReplacementObject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(dataIn);

		VSL_SET_VALIDVALUE_INTERFACE(dataOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct InPlaceUpdateObjectValidValues
	{
		/*[in]*/ IEEDataStorage* dataIn;
		/*[out]*/ IEEDataStorage** dataOut;
		HRESULT retValue;
	};

	STDMETHOD(InPlaceUpdateObject)(
		/*[in]*/ IEEDataStorage* dataIn,
		/*[out]*/ IEEDataStorage** dataOut)
	{
		VSL_DEFINE_MOCK_METHOD(InPlaceUpdateObject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(dataIn);

		VSL_SET_VALIDVALUE_INTERFACE(dataOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResolveAssemblyReferenceValidValues
	{
		/*[in]*/ LPCOLESTR assemName;
		/*[in]*/ GETASSEMBLY flags;
		/*[out]*/ IEEDataStorage** assemBytes;
		/*[out]*/ IEEDataStorage** assemPdb;
		/*[out]*/ BSTR* assemLocation;
		/*[out]*/ ASSEMBLYLOCRESOLUTION* alr;
		HRESULT retValue;
	};

	STDMETHOD(ResolveAssemblyReference)(
		/*[in]*/ LPCOLESTR assemName,
		/*[in]*/ GETASSEMBLY flags,
		/*[out]*/ IEEDataStorage** assemBytes,
		/*[out]*/ IEEDataStorage** assemPdb,
		/*[out]*/ BSTR* assemLocation,
		/*[out]*/ ASSEMBLYLOCRESOLUTION* alr)
	{
		VSL_DEFINE_MOCK_METHOD(ResolveAssemblyReference)

		VSL_CHECK_VALIDVALUE_STRINGW(assemName);

		VSL_CHECK_VALIDVALUE(flags);

		VSL_SET_VALIDVALUE_INTERFACE(assemBytes);

		VSL_SET_VALIDVALUE_INTERFACE(assemPdb);

		VSL_SET_VALIDVALUE_BSTR(assemLocation);

		VSL_SET_VALIDVALUE(alr);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPROPERTYPROXYEESIDE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
