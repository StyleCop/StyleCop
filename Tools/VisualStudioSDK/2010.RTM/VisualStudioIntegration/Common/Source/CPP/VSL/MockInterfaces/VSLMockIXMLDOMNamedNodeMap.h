/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IXMLDOMNAMEDNODEMAP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IXMLDOMNAMEDNODEMAP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "XmlDom.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IXMLDOMNamedNodeMapNotImpl :
	public IXMLDOMNamedNodeMap
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IXMLDOMNamedNodeMapNotImpl)

public:

	typedef IXMLDOMNamedNodeMap Interface;

	STDMETHOD(getNamedItem)(
		/*[in]*/ BSTR /*name*/,
		/*[out,retval]*/ IXMLDOMNode** /*namedItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(setNamedItem)(
		/*[in]*/ IXMLDOMNode* /*newItem*/,
		/*[out,retval]*/ IXMLDOMNode** /*nameItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(removeNamedItem)(
		/*[in]*/ BSTR /*name*/,
		/*[out,retval]*/ IXMLDOMNode** /*namedItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_item)(
		/*[in]*/ long /*index*/,
		/*[out,retval]*/ IXMLDOMNode** /*listItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_length)(
		/*[out,retval]*/ long* /*listLength*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(getQualifiedItem)(
		/*[in]*/ BSTR /*baseName*/,
		/*[in]*/ BSTR /*namespaceURI*/,
		/*[out,retval]*/ IXMLDOMNode** /*qualifiedItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(removeQualifiedItem)(
		/*[in]*/ BSTR /*baseName*/,
		/*[in]*/ BSTR /*namespaceURI*/,
		/*[out,retval]*/ IXMLDOMNode** /*qualifiedItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(nextNode)(
		/*[out,retval]*/ IXMLDOMNode** /*nextItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(reset)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get__newEnum)(
		/*[retval,out]*/ IUnknown** /*ppUnk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfoCount)(
		/*[out]*/ UINT* /*pctinfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfo)(
		/*[in]*/ UINT /*iTInfo*/,
		/*[in]*/ LCID /*lcid*/,
		/*[out]*/ ITypeInfo** /*ppTInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetIDsOfNames)(
		/*[in]*/ REFIID /*riid*/,
		/*[in,size_is(cNames)]*/ LPOLESTR* /*rgszNames*/,
		/*[in]*/ UINT /*cNames*/,
		/*[in]*/ LCID /*lcid*/,
		/*[out,size_is(cNames)]*/ DISPID* /*rgDispId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Invoke)(
		/*[in]*/ DISPID /*dispIdMember*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in]*/ LCID /*lcid*/,
		/*[in]*/ WORD /*wFlags*/,
		/*[in,out]*/ DISPPARAMS* /*pDispParams*/,
		/*[out]*/ VARIANT* /*pVarResult*/,
		/*[out]*/ EXCEPINFO* /*pExcepInfo*/,
		/*[out]*/ UINT* /*puArgErr*/)VSL_STDMETHOD_NOTIMPL
};

class IXMLDOMNamedNodeMapMockImpl :
	public IXMLDOMNamedNodeMap,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IXMLDOMNamedNodeMapMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IXMLDOMNamedNodeMapMockImpl)

	typedef IXMLDOMNamedNodeMap Interface;
	struct getNamedItemValidValues
	{
		/*[in]*/ BSTR name;
		/*[out,retval]*/ IXMLDOMNode** namedItem;
		HRESULT retValue;
	};

	STDMETHOD(getNamedItem)(
		/*[in]*/ BSTR name,
		/*[out,retval]*/ IXMLDOMNode** namedItem)
	{
		VSL_DEFINE_MOCK_METHOD(getNamedItem)

		VSL_CHECK_VALIDVALUE_BSTR(name);

		VSL_SET_VALIDVALUE_INTERFACE(namedItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct setNamedItemValidValues
	{
		/*[in]*/ IXMLDOMNode* newItem;
		/*[out,retval]*/ IXMLDOMNode** nameItem;
		HRESULT retValue;
	};

	STDMETHOD(setNamedItem)(
		/*[in]*/ IXMLDOMNode* newItem,
		/*[out,retval]*/ IXMLDOMNode** nameItem)
	{
		VSL_DEFINE_MOCK_METHOD(setNamedItem)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(newItem);

		VSL_SET_VALIDVALUE_INTERFACE(nameItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct removeNamedItemValidValues
	{
		/*[in]*/ BSTR name;
		/*[out,retval]*/ IXMLDOMNode** namedItem;
		HRESULT retValue;
	};

	STDMETHOD(removeNamedItem)(
		/*[in]*/ BSTR name,
		/*[out,retval]*/ IXMLDOMNode** namedItem)
	{
		VSL_DEFINE_MOCK_METHOD(removeNamedItem)

		VSL_CHECK_VALIDVALUE_BSTR(name);

		VSL_SET_VALIDVALUE_INTERFACE(namedItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_itemValidValues
	{
		/*[in]*/ long index;
		/*[out,retval]*/ IXMLDOMNode** listItem;
		HRESULT retValue;
	};

	STDMETHOD(get_item)(
		/*[in]*/ long index,
		/*[out,retval]*/ IXMLDOMNode** listItem)
	{
		VSL_DEFINE_MOCK_METHOD(get_item)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE_INTERFACE(listItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_lengthValidValues
	{
		/*[out,retval]*/ long* listLength;
		HRESULT retValue;
	};

	STDMETHOD(get_length)(
		/*[out,retval]*/ long* listLength)
	{
		VSL_DEFINE_MOCK_METHOD(get_length)

		VSL_SET_VALIDVALUE(listLength);

		VSL_RETURN_VALIDVALUES();
	}
	struct getQualifiedItemValidValues
	{
		/*[in]*/ BSTR baseName;
		/*[in]*/ BSTR namespaceURI;
		/*[out,retval]*/ IXMLDOMNode** qualifiedItem;
		HRESULT retValue;
	};

	STDMETHOD(getQualifiedItem)(
		/*[in]*/ BSTR baseName,
		/*[in]*/ BSTR namespaceURI,
		/*[out,retval]*/ IXMLDOMNode** qualifiedItem)
	{
		VSL_DEFINE_MOCK_METHOD(getQualifiedItem)

		VSL_CHECK_VALIDVALUE_BSTR(baseName);

		VSL_CHECK_VALIDVALUE_BSTR(namespaceURI);

		VSL_SET_VALIDVALUE_INTERFACE(qualifiedItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct removeQualifiedItemValidValues
	{
		/*[in]*/ BSTR baseName;
		/*[in]*/ BSTR namespaceURI;
		/*[out,retval]*/ IXMLDOMNode** qualifiedItem;
		HRESULT retValue;
	};

	STDMETHOD(removeQualifiedItem)(
		/*[in]*/ BSTR baseName,
		/*[in]*/ BSTR namespaceURI,
		/*[out,retval]*/ IXMLDOMNode** qualifiedItem)
	{
		VSL_DEFINE_MOCK_METHOD(removeQualifiedItem)

		VSL_CHECK_VALIDVALUE_BSTR(baseName);

		VSL_CHECK_VALIDVALUE_BSTR(namespaceURI);

		VSL_SET_VALIDVALUE_INTERFACE(qualifiedItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct nextNodeValidValues
	{
		/*[out,retval]*/ IXMLDOMNode** nextItem;
		HRESULT retValue;
	};

	STDMETHOD(nextNode)(
		/*[out,retval]*/ IXMLDOMNode** nextItem)
	{
		VSL_DEFINE_MOCK_METHOD(nextNode)

		VSL_SET_VALIDVALUE_INTERFACE(nextItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct resetValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(reset)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(reset)

		VSL_RETURN_VALIDVALUES();
	}
	struct get__newEnumValidValues
	{
		/*[retval,out]*/ IUnknown** ppUnk;
		HRESULT retValue;
	};

	STDMETHOD(get__newEnum)(
		/*[retval,out]*/ IUnknown** ppUnk)
	{
		VSL_DEFINE_MOCK_METHOD(get__newEnum)

		VSL_SET_VALIDVALUE_INTERFACE(ppUnk);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeInfoCountValidValues
	{
		/*[out]*/ UINT* pctinfo;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeInfoCount)(
		/*[out]*/ UINT* pctinfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeInfoCount)

		VSL_SET_VALIDVALUE(pctinfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeInfoValidValues
	{
		/*[in]*/ UINT iTInfo;
		/*[in]*/ LCID lcid;
		/*[out]*/ ITypeInfo** ppTInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeInfo)(
		/*[in]*/ UINT iTInfo,
		/*[in]*/ LCID lcid,
		/*[out]*/ ITypeInfo** ppTInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeInfo)

		VSL_CHECK_VALIDVALUE(iTInfo);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_SET_VALIDVALUE_INTERFACE(ppTInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetIDsOfNamesValidValues
	{
		/*[in]*/ REFIID riid;
		/*[in,size_is(cNames)]*/ LPOLESTR* rgszNames;
		/*[in]*/ UINT cNames;
		/*[in]*/ LCID lcid;
		/*[out,size_is(cNames)]*/ DISPID* rgDispId;
		HRESULT retValue;
	};

	STDMETHOD(GetIDsOfNames)(
		/*[in]*/ REFIID riid,
		/*[in,size_is(cNames)]*/ LPOLESTR* rgszNames,
		/*[in]*/ UINT cNames,
		/*[in]*/ LCID lcid,
		/*[out,size_is(cNames)]*/ DISPID* rgDispId)
	{
		VSL_DEFINE_MOCK_METHOD(GetIDsOfNames)

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszNames, cNames*sizeof(rgszNames[0]), validValues.cNames*sizeof(validValues.rgszNames[0]));

		VSL_CHECK_VALIDVALUE(cNames);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_SET_VALIDVALUE_MEMCPY(rgDispId, cNames*sizeof(rgDispId[0]), validValues.cNames*sizeof(validValues.rgDispId[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct InvokeValidValues
	{
		/*[in]*/ DISPID dispIdMember;
		/*[in]*/ REFIID riid;
		/*[in]*/ LCID lcid;
		/*[in]*/ WORD wFlags;
		/*[in,out]*/ DISPPARAMS* pDispParams;
		/*[out]*/ VARIANT* pVarResult;
		/*[out]*/ EXCEPINFO* pExcepInfo;
		/*[out]*/ UINT* puArgErr;
		HRESULT retValue;
	};

	STDMETHOD(Invoke)(
		/*[in]*/ DISPID dispIdMember,
		/*[in]*/ REFIID riid,
		/*[in]*/ LCID lcid,
		/*[in]*/ WORD wFlags,
		/*[in,out]*/ DISPPARAMS* pDispParams,
		/*[out]*/ VARIANT* pVarResult,
		/*[out]*/ EXCEPINFO* pExcepInfo,
		/*[out]*/ UINT* puArgErr)
	{
		VSL_DEFINE_MOCK_METHOD(Invoke)

		VSL_CHECK_VALIDVALUE(dispIdMember);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_CHECK_VALIDVALUE(wFlags);

		VSL_SET_VALIDVALUE(pDispParams);

		VSL_SET_VALIDVALUE_VARIANT(pVarResult);

		VSL_SET_VALIDVALUE(pExcepInfo);

		VSL_SET_VALIDVALUE(puArgErr);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IXMLDOMNAMEDNODEMAP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
