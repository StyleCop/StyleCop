/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IEEHELPEROBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IEEHELPEROBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IEEHelperObjectNotImpl :
	public IEEHelperObject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEEHelperObjectNotImpl)

public:

	typedef IEEHelperObject Interface;

	STDMETHOD(InitCache)(
		/*[in]*/ IEEAssemblyRefResolveComparer* /*pResolver*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTargetClass)(
		/*[in]*/ LPCOLESTR /*name*/,
		/*[in]*/ DWORD /*assemblyCookie*/,
		/*[out]*/ DWORD* /*cookie*/,
		/*[out]*/ ULONG* /*valueAttrCount*/,
		/*[out]*/ ULONG* /*viewerAttrCount*/,
		/*[out]*/ ULONG* /*visualizerAttrCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTargetAssembly)(
		/*[in]*/ LPCOLESTR /*name*/,
		/*[out]*/ DWORD* /*cookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAssembly)(
		/*[in]*/ DWORD /*assemblyCookie*/,
		/*[in]*/ GETASSEMBLY /*flags*/,
		/*[out]*/ ASSEMBLYFLAGS* /*flagsOut*/,
		/*[out]*/ BSTR* /*name*/,
		/*[out]*/ IEEDataStorage** /*assemBytes*/,
		/*[out]*/ IEEDataStorage** /*pdbBytes*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHostAssembly)(
		/*[in]*/ GETASSEMBLY /*flags*/,
		/*[out]*/ IEEDataStorage** /*assemBytes*/,
		/*[out]*/ IEEDataStorage** /*pdbBytes*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetValueAttributeProps)(
		/*[in]*/ DWORD /*classCookie*/,
		/*[in]*/ ULONG /*ordinal*/,
		/*[out]*/ BSTR* /*targetedAssembly*/,
		/*[out]*/ DWORD* /*assemLocation*/,
		/*[out]*/ BSTR* /*name*/,
		/*[out]*/ BSTR* /*value*/,
		/*[out]*/ BSTR* /*type*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetViewerAttributeProps)(
		/*[in]*/ DWORD /*classCookie*/,
		/*[in]*/ ULONG /*ordinal*/,
		/*[out]*/ BSTR* /*targetedAssembly*/,
		/*[out]*/ DWORD* /*assemLocation*/,
		/*[out]*/ BSTR* /*className*/,
		/*[out]*/ DWORD* /*classAssemLocation*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetVisualizerAttributeProps)(
		/*[in]*/ DWORD /*classCookie*/,
		/*[in]*/ ULONG /*ordinal*/,
		/*[out]*/ BSTR* /*targetedAssembly*/,
		/*[out]*/ DWORD* /*assemLocation*/,
		/*[out]*/ BSTR* /*displayClassName*/,
		/*[out]*/ DWORD* /*displayClassAssemLocation*/,
		/*[out]*/ BSTR* /*proxyClassName*/,
		/*[out]*/ DWORD* /*proxyClassAssemLocation*/,
		/*[out]*/ BSTR* /*description*/,
		/*[out]*/ ULONG* /*uiType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAssemblyRefForCookie)(
		/*[in]*/ DWORD /*cookie*/,
		/*[out]*/ IEEAssemblyRef** /*ppAssemRef*/)VSL_STDMETHOD_NOTIMPL
};

class IEEHelperObjectMockImpl :
	public IEEHelperObject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEEHelperObjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IEEHelperObjectMockImpl)

	typedef IEEHelperObject Interface;
	struct InitCacheValidValues
	{
		/*[in]*/ IEEAssemblyRefResolveComparer* pResolver;
		HRESULT retValue;
	};

	STDMETHOD(InitCache)(
		/*[in]*/ IEEAssemblyRefResolveComparer* pResolver)
	{
		VSL_DEFINE_MOCK_METHOD(InitCache)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pResolver);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTargetClassValidValues
	{
		/*[in]*/ LPCOLESTR name;
		/*[in]*/ DWORD assemblyCookie;
		/*[out]*/ DWORD* cookie;
		/*[out]*/ ULONG* valueAttrCount;
		/*[out]*/ ULONG* viewerAttrCount;
		/*[out]*/ ULONG* visualizerAttrCount;
		HRESULT retValue;
	};

	STDMETHOD(GetTargetClass)(
		/*[in]*/ LPCOLESTR name,
		/*[in]*/ DWORD assemblyCookie,
		/*[out]*/ DWORD* cookie,
		/*[out]*/ ULONG* valueAttrCount,
		/*[out]*/ ULONG* viewerAttrCount,
		/*[out]*/ ULONG* visualizerAttrCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetTargetClass)

		VSL_CHECK_VALIDVALUE_STRINGW(name);

		VSL_CHECK_VALIDVALUE(assemblyCookie);

		VSL_SET_VALIDVALUE(cookie);

		VSL_SET_VALIDVALUE(valueAttrCount);

		VSL_SET_VALIDVALUE(viewerAttrCount);

		VSL_SET_VALIDVALUE(visualizerAttrCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTargetAssemblyValidValues
	{
		/*[in]*/ LPCOLESTR name;
		/*[out]*/ DWORD* cookie;
		HRESULT retValue;
	};

	STDMETHOD(GetTargetAssembly)(
		/*[in]*/ LPCOLESTR name,
		/*[out]*/ DWORD* cookie)
	{
		VSL_DEFINE_MOCK_METHOD(GetTargetAssembly)

		VSL_CHECK_VALIDVALUE_STRINGW(name);

		VSL_SET_VALIDVALUE(cookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAssemblyValidValues
	{
		/*[in]*/ DWORD assemblyCookie;
		/*[in]*/ GETASSEMBLY flags;
		/*[out]*/ ASSEMBLYFLAGS* flagsOut;
		/*[out]*/ BSTR* name;
		/*[out]*/ IEEDataStorage** assemBytes;
		/*[out]*/ IEEDataStorage** pdbBytes;
		HRESULT retValue;
	};

	STDMETHOD(GetAssembly)(
		/*[in]*/ DWORD assemblyCookie,
		/*[in]*/ GETASSEMBLY flags,
		/*[out]*/ ASSEMBLYFLAGS* flagsOut,
		/*[out]*/ BSTR* name,
		/*[out]*/ IEEDataStorage** assemBytes,
		/*[out]*/ IEEDataStorage** pdbBytes)
	{
		VSL_DEFINE_MOCK_METHOD(GetAssembly)

		VSL_CHECK_VALIDVALUE(assemblyCookie);

		VSL_CHECK_VALIDVALUE(flags);

		VSL_SET_VALIDVALUE(flagsOut);

		VSL_SET_VALIDVALUE_BSTR(name);

		VSL_SET_VALIDVALUE_INTERFACE(assemBytes);

		VSL_SET_VALIDVALUE_INTERFACE(pdbBytes);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHostAssemblyValidValues
	{
		/*[in]*/ GETASSEMBLY flags;
		/*[out]*/ IEEDataStorage** assemBytes;
		/*[out]*/ IEEDataStorage** pdbBytes;
		HRESULT retValue;
	};

	STDMETHOD(GetHostAssembly)(
		/*[in]*/ GETASSEMBLY flags,
		/*[out]*/ IEEDataStorage** assemBytes,
		/*[out]*/ IEEDataStorage** pdbBytes)
	{
		VSL_DEFINE_MOCK_METHOD(GetHostAssembly)

		VSL_CHECK_VALIDVALUE(flags);

		VSL_SET_VALIDVALUE_INTERFACE(assemBytes);

		VSL_SET_VALIDVALUE_INTERFACE(pdbBytes);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetValueAttributePropsValidValues
	{
		/*[in]*/ DWORD classCookie;
		/*[in]*/ ULONG ordinal;
		/*[out]*/ BSTR* targetedAssembly;
		/*[out]*/ DWORD* assemLocation;
		/*[out]*/ BSTR* name;
		/*[out]*/ BSTR* value;
		/*[out]*/ BSTR* type;
		HRESULT retValue;
	};

	STDMETHOD(GetValueAttributeProps)(
		/*[in]*/ DWORD classCookie,
		/*[in]*/ ULONG ordinal,
		/*[out]*/ BSTR* targetedAssembly,
		/*[out]*/ DWORD* assemLocation,
		/*[out]*/ BSTR* name,
		/*[out]*/ BSTR* value,
		/*[out]*/ BSTR* type)
	{
		VSL_DEFINE_MOCK_METHOD(GetValueAttributeProps)

		VSL_CHECK_VALIDVALUE(classCookie);

		VSL_CHECK_VALIDVALUE(ordinal);

		VSL_SET_VALIDVALUE_BSTR(targetedAssembly);

		VSL_SET_VALIDVALUE(assemLocation);

		VSL_SET_VALIDVALUE_BSTR(name);

		VSL_SET_VALIDVALUE_BSTR(value);

		VSL_SET_VALIDVALUE_BSTR(type);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetViewerAttributePropsValidValues
	{
		/*[in]*/ DWORD classCookie;
		/*[in]*/ ULONG ordinal;
		/*[out]*/ BSTR* targetedAssembly;
		/*[out]*/ DWORD* assemLocation;
		/*[out]*/ BSTR* className;
		/*[out]*/ DWORD* classAssemLocation;
		HRESULT retValue;
	};

	STDMETHOD(GetViewerAttributeProps)(
		/*[in]*/ DWORD classCookie,
		/*[in]*/ ULONG ordinal,
		/*[out]*/ BSTR* targetedAssembly,
		/*[out]*/ DWORD* assemLocation,
		/*[out]*/ BSTR* className,
		/*[out]*/ DWORD* classAssemLocation)
	{
		VSL_DEFINE_MOCK_METHOD(GetViewerAttributeProps)

		VSL_CHECK_VALIDVALUE(classCookie);

		VSL_CHECK_VALIDVALUE(ordinal);

		VSL_SET_VALIDVALUE_BSTR(targetedAssembly);

		VSL_SET_VALIDVALUE(assemLocation);

		VSL_SET_VALIDVALUE_BSTR(className);

		VSL_SET_VALIDVALUE(classAssemLocation);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetVisualizerAttributePropsValidValues
	{
		/*[in]*/ DWORD classCookie;
		/*[in]*/ ULONG ordinal;
		/*[out]*/ BSTR* targetedAssembly;
		/*[out]*/ DWORD* assemLocation;
		/*[out]*/ BSTR* displayClassName;
		/*[out]*/ DWORD* displayClassAssemLocation;
		/*[out]*/ BSTR* proxyClassName;
		/*[out]*/ DWORD* proxyClassAssemLocation;
		/*[out]*/ BSTR* description;
		/*[out]*/ ULONG* uiType;
		HRESULT retValue;
	};

	STDMETHOD(GetVisualizerAttributeProps)(
		/*[in]*/ DWORD classCookie,
		/*[in]*/ ULONG ordinal,
		/*[out]*/ BSTR* targetedAssembly,
		/*[out]*/ DWORD* assemLocation,
		/*[out]*/ BSTR* displayClassName,
		/*[out]*/ DWORD* displayClassAssemLocation,
		/*[out]*/ BSTR* proxyClassName,
		/*[out]*/ DWORD* proxyClassAssemLocation,
		/*[out]*/ BSTR* description,
		/*[out]*/ ULONG* uiType)
	{
		VSL_DEFINE_MOCK_METHOD(GetVisualizerAttributeProps)

		VSL_CHECK_VALIDVALUE(classCookie);

		VSL_CHECK_VALIDVALUE(ordinal);

		VSL_SET_VALIDVALUE_BSTR(targetedAssembly);

		VSL_SET_VALIDVALUE(assemLocation);

		VSL_SET_VALIDVALUE_BSTR(displayClassName);

		VSL_SET_VALIDVALUE(displayClassAssemLocation);

		VSL_SET_VALIDVALUE_BSTR(proxyClassName);

		VSL_SET_VALIDVALUE(proxyClassAssemLocation);

		VSL_SET_VALIDVALUE_BSTR(description);

		VSL_SET_VALIDVALUE(uiType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAssemblyRefForCookieValidValues
	{
		/*[in]*/ DWORD cookie;
		/*[out]*/ IEEAssemblyRef** ppAssemRef;
		HRESULT retValue;
	};

	STDMETHOD(GetAssemblyRefForCookie)(
		/*[in]*/ DWORD cookie,
		/*[out]*/ IEEAssemblyRef** ppAssemRef)
	{
		VSL_DEFINE_MOCK_METHOD(GetAssemblyRefForCookie)

		VSL_CHECK_VALIDVALUE(cookie);

		VSL_SET_VALIDVALUE_INTERFACE(ppAssemRef);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IEEHELPEROBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
