/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IXMLDOMNOTATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IXMLDOMNOTATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IXMLDOMNotationNotImpl :
	public IXMLDOMNotation
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IXMLDOMNotationNotImpl)

public:

	typedef IXMLDOMNotation Interface;

	STDMETHOD(get_publicId)(
		/*[out,retval]*/ VARIANT* /*publicID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_systemId)(
		/*[out,retval]*/ VARIANT* /*systemID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_nodeName)(
		/*[out,retval]*/ BSTR* /*name*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_nodeValue)(
		/*[out,retval]*/ VARIANT* /*value*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_nodeValue)(
		/*[in]*/ VARIANT /*value*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_nodeType)(
		/*[out,retval]*/ DOMNodeType* /*type*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_parentNode)(
		/*[out,retval]*/ IXMLDOMNode** /*parent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_childNodes)(
		/*[out,retval]*/ IXMLDOMNodeList** /*childList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_firstChild)(
		/*[out,retval]*/ IXMLDOMNode** /*firstChild*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_lastChild)(
		/*[out,retval]*/ IXMLDOMNode** /*lastChild*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_previousSibling)(
		/*[out,retval]*/ IXMLDOMNode** /*previousSibling*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_nextSibling)(
		/*[out,retval]*/ IXMLDOMNode** /*nextSibling*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_attributes)(
		/*[out,retval]*/ IXMLDOMNamedNodeMap** /*attributeMap*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(insertBefore)(
		/*[in]*/ IXMLDOMNode* /*newChild*/,
		/*[in]*/ VARIANT /*refChild*/,
		/*[out,retval]*/ IXMLDOMNode** /*outNewChild*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(replaceChild)(
		/*[in]*/ IXMLDOMNode* /*newChild*/,
		/*[in]*/ IXMLDOMNode* /*oldChild*/,
		/*[out,retval]*/ IXMLDOMNode** /*outOldChild*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(removeChild)(
		/*[in]*/ IXMLDOMNode* /*childNode*/,
		/*[out,retval]*/ IXMLDOMNode** /*oldChild*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(appendChild)(
		/*[in]*/ IXMLDOMNode* /*newChild*/,
		/*[out,retval]*/ IXMLDOMNode** /*outNewChild*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(hasChildNodes)(
		/*[out,retval]*/ VARIANT_BOOL* /*hasChild*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ownerDocument)(
		/*[out,retval]*/ IXMLDOMDocument** /*DOMDocument*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(cloneNode)(
		/*[in]*/ VARIANT_BOOL /*deep*/,
		/*[out,retval]*/ IXMLDOMNode** /*cloneRoot*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_nodeTypeString)(
		/*[retval,out]*/ BSTR* /*nodeType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_text)(
		/*[retval,out]*/ BSTR* /*text*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_text)(
		/*[in]*/ BSTR /*text*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_specified)(
		/*[out,retval]*/ VARIANT_BOOL* /*isSpecified*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_definition)(
		/*[retval,out]*/ IXMLDOMNode** /*definitionNode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_nodeTypedValue)(
		/*[retval,out]*/ VARIANT* /*typedValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_nodeTypedValue)(
		/*[in]*/ VARIANT /*typedValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_dataType)(
		/*[retval,out]*/ VARIANT* /*dataTypeName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_dataType)(
		/*[in]*/ BSTR /*dataTypeName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_xml)(
		/*[retval,out]*/ BSTR* /*xmlString*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(transformNode)(
		/*[in]*/ IXMLDOMNode* /*stylesheet*/,
		/*[retval,out]*/ BSTR* /*xmlString*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(selectNodes)(
		/*[in]*/ BSTR /*queryString*/,
		/*[retval,out]*/ IXMLDOMNodeList** /*resultList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(selectSingleNode)(
		/*[in]*/ BSTR /*queryString*/,
		/*[retval,out]*/ IXMLDOMNode** /*resultNode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_parsed)(
		/*[retval,out]*/ VARIANT_BOOL* /*isParsed*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_namespaceURI)(
		/*[retval,out]*/ BSTR* /*namespaceURI*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_prefix)(
		/*[retval,out]*/ BSTR* /*prefixString*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_baseName)(
		/*[retval,out]*/ BSTR* /*nameString*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(transformNodeToObject)(
		/*[in]*/ IXMLDOMNode* /*stylesheet*/,
		/*[in]*/ VARIANT /*outputObject*/)VSL_STDMETHOD_NOTIMPL

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

class IXMLDOMNotationMockImpl :
	public IXMLDOMNotation,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IXMLDOMNotationMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IXMLDOMNotationMockImpl)

	typedef IXMLDOMNotation Interface;
	struct get_publicIdValidValues
	{
		/*[out,retval]*/ VARIANT* publicID;
		HRESULT retValue;
	};

	STDMETHOD(get_publicId)(
		/*[out,retval]*/ VARIANT* publicID)
	{
		VSL_DEFINE_MOCK_METHOD(get_publicId)

		VSL_SET_VALIDVALUE_VARIANT(publicID);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_systemIdValidValues
	{
		/*[out,retval]*/ VARIANT* systemID;
		HRESULT retValue;
	};

	STDMETHOD(get_systemId)(
		/*[out,retval]*/ VARIANT* systemID)
	{
		VSL_DEFINE_MOCK_METHOD(get_systemId)

		VSL_SET_VALIDVALUE_VARIANT(systemID);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_nodeNameValidValues
	{
		/*[out,retval]*/ BSTR* name;
		HRESULT retValue;
	};

	STDMETHOD(get_nodeName)(
		/*[out,retval]*/ BSTR* name)
	{
		VSL_DEFINE_MOCK_METHOD(get_nodeName)

		VSL_SET_VALIDVALUE_BSTR(name);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_nodeValueValidValues
	{
		/*[out,retval]*/ VARIANT* value;
		HRESULT retValue;
	};

	STDMETHOD(get_nodeValue)(
		/*[out,retval]*/ VARIANT* value)
	{
		VSL_DEFINE_MOCK_METHOD(get_nodeValue)

		VSL_SET_VALIDVALUE_VARIANT(value);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_nodeValueValidValues
	{
		/*[in]*/ VARIANT value;
		HRESULT retValue;
	};

	STDMETHOD(put_nodeValue)(
		/*[in]*/ VARIANT value)
	{
		VSL_DEFINE_MOCK_METHOD(put_nodeValue)

		VSL_CHECK_VALIDVALUE(value);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_nodeTypeValidValues
	{
		/*[out,retval]*/ DOMNodeType* type;
		HRESULT retValue;
	};

	STDMETHOD(get_nodeType)(
		/*[out,retval]*/ DOMNodeType* type)
	{
		VSL_DEFINE_MOCK_METHOD(get_nodeType)

		VSL_SET_VALIDVALUE(type);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_parentNodeValidValues
	{
		/*[out,retval]*/ IXMLDOMNode** parent;
		HRESULT retValue;
	};

	STDMETHOD(get_parentNode)(
		/*[out,retval]*/ IXMLDOMNode** parent)
	{
		VSL_DEFINE_MOCK_METHOD(get_parentNode)

		VSL_SET_VALIDVALUE_INTERFACE(parent);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_childNodesValidValues
	{
		/*[out,retval]*/ IXMLDOMNodeList** childList;
		HRESULT retValue;
	};

	STDMETHOD(get_childNodes)(
		/*[out,retval]*/ IXMLDOMNodeList** childList)
	{
		VSL_DEFINE_MOCK_METHOD(get_childNodes)

		VSL_SET_VALIDVALUE_INTERFACE(childList);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_firstChildValidValues
	{
		/*[out,retval]*/ IXMLDOMNode** firstChild;
		HRESULT retValue;
	};

	STDMETHOD(get_firstChild)(
		/*[out,retval]*/ IXMLDOMNode** firstChild)
	{
		VSL_DEFINE_MOCK_METHOD(get_firstChild)

		VSL_SET_VALIDVALUE_INTERFACE(firstChild);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_lastChildValidValues
	{
		/*[out,retval]*/ IXMLDOMNode** lastChild;
		HRESULT retValue;
	};

	STDMETHOD(get_lastChild)(
		/*[out,retval]*/ IXMLDOMNode** lastChild)
	{
		VSL_DEFINE_MOCK_METHOD(get_lastChild)

		VSL_SET_VALIDVALUE_INTERFACE(lastChild);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_previousSiblingValidValues
	{
		/*[out,retval]*/ IXMLDOMNode** previousSibling;
		HRESULT retValue;
	};

	STDMETHOD(get_previousSibling)(
		/*[out,retval]*/ IXMLDOMNode** previousSibling)
	{
		VSL_DEFINE_MOCK_METHOD(get_previousSibling)

		VSL_SET_VALIDVALUE_INTERFACE(previousSibling);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_nextSiblingValidValues
	{
		/*[out,retval]*/ IXMLDOMNode** nextSibling;
		HRESULT retValue;
	};

	STDMETHOD(get_nextSibling)(
		/*[out,retval]*/ IXMLDOMNode** nextSibling)
	{
		VSL_DEFINE_MOCK_METHOD(get_nextSibling)

		VSL_SET_VALIDVALUE_INTERFACE(nextSibling);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_attributesValidValues
	{
		/*[out,retval]*/ IXMLDOMNamedNodeMap** attributeMap;
		HRESULT retValue;
	};

	STDMETHOD(get_attributes)(
		/*[out,retval]*/ IXMLDOMNamedNodeMap** attributeMap)
	{
		VSL_DEFINE_MOCK_METHOD(get_attributes)

		VSL_SET_VALIDVALUE_INTERFACE(attributeMap);

		VSL_RETURN_VALIDVALUES();
	}
	struct insertBeforeValidValues
	{
		/*[in]*/ IXMLDOMNode* newChild;
		/*[in]*/ VARIANT refChild;
		/*[out,retval]*/ IXMLDOMNode** outNewChild;
		HRESULT retValue;
	};

	STDMETHOD(insertBefore)(
		/*[in]*/ IXMLDOMNode* newChild,
		/*[in]*/ VARIANT refChild,
		/*[out,retval]*/ IXMLDOMNode** outNewChild)
	{
		VSL_DEFINE_MOCK_METHOD(insertBefore)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(newChild);

		VSL_CHECK_VALIDVALUE(refChild);

		VSL_SET_VALIDVALUE_INTERFACE(outNewChild);

		VSL_RETURN_VALIDVALUES();
	}
	struct replaceChildValidValues
	{
		/*[in]*/ IXMLDOMNode* newChild;
		/*[in]*/ IXMLDOMNode* oldChild;
		/*[out,retval]*/ IXMLDOMNode** outOldChild;
		HRESULT retValue;
	};

	STDMETHOD(replaceChild)(
		/*[in]*/ IXMLDOMNode* newChild,
		/*[in]*/ IXMLDOMNode* oldChild,
		/*[out,retval]*/ IXMLDOMNode** outOldChild)
	{
		VSL_DEFINE_MOCK_METHOD(replaceChild)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(newChild);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(oldChild);

		VSL_SET_VALIDVALUE_INTERFACE(outOldChild);

		VSL_RETURN_VALIDVALUES();
	}
	struct removeChildValidValues
	{
		/*[in]*/ IXMLDOMNode* childNode;
		/*[out,retval]*/ IXMLDOMNode** oldChild;
		HRESULT retValue;
	};

	STDMETHOD(removeChild)(
		/*[in]*/ IXMLDOMNode* childNode,
		/*[out,retval]*/ IXMLDOMNode** oldChild)
	{
		VSL_DEFINE_MOCK_METHOD(removeChild)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(childNode);

		VSL_SET_VALIDVALUE_INTERFACE(oldChild);

		VSL_RETURN_VALIDVALUES();
	}
	struct appendChildValidValues
	{
		/*[in]*/ IXMLDOMNode* newChild;
		/*[out,retval]*/ IXMLDOMNode** outNewChild;
		HRESULT retValue;
	};

	STDMETHOD(appendChild)(
		/*[in]*/ IXMLDOMNode* newChild,
		/*[out,retval]*/ IXMLDOMNode** outNewChild)
	{
		VSL_DEFINE_MOCK_METHOD(appendChild)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(newChild);

		VSL_SET_VALIDVALUE_INTERFACE(outNewChild);

		VSL_RETURN_VALIDVALUES();
	}
	struct hasChildNodesValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* hasChild;
		HRESULT retValue;
	};

	STDMETHOD(hasChildNodes)(
		/*[out,retval]*/ VARIANT_BOOL* hasChild)
	{
		VSL_DEFINE_MOCK_METHOD(hasChildNodes)

		VSL_SET_VALIDVALUE(hasChild);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ownerDocumentValidValues
	{
		/*[out,retval]*/ IXMLDOMDocument** DOMDocument;
		HRESULT retValue;
	};

	STDMETHOD(get_ownerDocument)(
		/*[out,retval]*/ IXMLDOMDocument** DOMDocument)
	{
		VSL_DEFINE_MOCK_METHOD(get_ownerDocument)

		VSL_SET_VALIDVALUE_INTERFACE(DOMDocument);

		VSL_RETURN_VALIDVALUES();
	}
	struct cloneNodeValidValues
	{
		/*[in]*/ VARIANT_BOOL deep;
		/*[out,retval]*/ IXMLDOMNode** cloneRoot;
		HRESULT retValue;
	};

	STDMETHOD(cloneNode)(
		/*[in]*/ VARIANT_BOOL deep,
		/*[out,retval]*/ IXMLDOMNode** cloneRoot)
	{
		VSL_DEFINE_MOCK_METHOD(cloneNode)

		VSL_CHECK_VALIDVALUE(deep);

		VSL_SET_VALIDVALUE_INTERFACE(cloneRoot);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_nodeTypeStringValidValues
	{
		/*[retval,out]*/ BSTR* nodeType;
		HRESULT retValue;
	};

	STDMETHOD(get_nodeTypeString)(
		/*[retval,out]*/ BSTR* nodeType)
	{
		VSL_DEFINE_MOCK_METHOD(get_nodeTypeString)

		VSL_SET_VALIDVALUE_BSTR(nodeType);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_textValidValues
	{
		/*[retval,out]*/ BSTR* text;
		HRESULT retValue;
	};

	STDMETHOD(get_text)(
		/*[retval,out]*/ BSTR* text)
	{
		VSL_DEFINE_MOCK_METHOD(get_text)

		VSL_SET_VALIDVALUE_BSTR(text);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_textValidValues
	{
		/*[in]*/ BSTR text;
		HRESULT retValue;
	};

	STDMETHOD(put_text)(
		/*[in]*/ BSTR text)
	{
		VSL_DEFINE_MOCK_METHOD(put_text)

		VSL_CHECK_VALIDVALUE_BSTR(text);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_specifiedValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* isSpecified;
		HRESULT retValue;
	};

	STDMETHOD(get_specified)(
		/*[out,retval]*/ VARIANT_BOOL* isSpecified)
	{
		VSL_DEFINE_MOCK_METHOD(get_specified)

		VSL_SET_VALIDVALUE(isSpecified);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_definitionValidValues
	{
		/*[retval,out]*/ IXMLDOMNode** definitionNode;
		HRESULT retValue;
	};

	STDMETHOD(get_definition)(
		/*[retval,out]*/ IXMLDOMNode** definitionNode)
	{
		VSL_DEFINE_MOCK_METHOD(get_definition)

		VSL_SET_VALIDVALUE_INTERFACE(definitionNode);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_nodeTypedValueValidValues
	{
		/*[retval,out]*/ VARIANT* typedValue;
		HRESULT retValue;
	};

	STDMETHOD(get_nodeTypedValue)(
		/*[retval,out]*/ VARIANT* typedValue)
	{
		VSL_DEFINE_MOCK_METHOD(get_nodeTypedValue)

		VSL_SET_VALIDVALUE_VARIANT(typedValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_nodeTypedValueValidValues
	{
		/*[in]*/ VARIANT typedValue;
		HRESULT retValue;
	};

	STDMETHOD(put_nodeTypedValue)(
		/*[in]*/ VARIANT typedValue)
	{
		VSL_DEFINE_MOCK_METHOD(put_nodeTypedValue)

		VSL_CHECK_VALIDVALUE(typedValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_dataTypeValidValues
	{
		/*[retval,out]*/ VARIANT* dataTypeName;
		HRESULT retValue;
	};

	STDMETHOD(get_dataType)(
		/*[retval,out]*/ VARIANT* dataTypeName)
	{
		VSL_DEFINE_MOCK_METHOD(get_dataType)

		VSL_SET_VALIDVALUE_VARIANT(dataTypeName);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_dataTypeValidValues
	{
		/*[in]*/ BSTR dataTypeName;
		HRESULT retValue;
	};

	STDMETHOD(put_dataType)(
		/*[in]*/ BSTR dataTypeName)
	{
		VSL_DEFINE_MOCK_METHOD(put_dataType)

		VSL_CHECK_VALIDVALUE_BSTR(dataTypeName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_xmlValidValues
	{
		/*[retval,out]*/ BSTR* xmlString;
		HRESULT retValue;
	};

	STDMETHOD(get_xml)(
		/*[retval,out]*/ BSTR* xmlString)
	{
		VSL_DEFINE_MOCK_METHOD(get_xml)

		VSL_SET_VALIDVALUE_BSTR(xmlString);

		VSL_RETURN_VALIDVALUES();
	}
	struct transformNodeValidValues
	{
		/*[in]*/ IXMLDOMNode* stylesheet;
		/*[retval,out]*/ BSTR* xmlString;
		HRESULT retValue;
	};

	STDMETHOD(transformNode)(
		/*[in]*/ IXMLDOMNode* stylesheet,
		/*[retval,out]*/ BSTR* xmlString)
	{
		VSL_DEFINE_MOCK_METHOD(transformNode)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(stylesheet);

		VSL_SET_VALIDVALUE_BSTR(xmlString);

		VSL_RETURN_VALIDVALUES();
	}
	struct selectNodesValidValues
	{
		/*[in]*/ BSTR queryString;
		/*[retval,out]*/ IXMLDOMNodeList** resultList;
		HRESULT retValue;
	};

	STDMETHOD(selectNodes)(
		/*[in]*/ BSTR queryString,
		/*[retval,out]*/ IXMLDOMNodeList** resultList)
	{
		VSL_DEFINE_MOCK_METHOD(selectNodes)

		VSL_CHECK_VALIDVALUE_BSTR(queryString);

		VSL_SET_VALIDVALUE_INTERFACE(resultList);

		VSL_RETURN_VALIDVALUES();
	}
	struct selectSingleNodeValidValues
	{
		/*[in]*/ BSTR queryString;
		/*[retval,out]*/ IXMLDOMNode** resultNode;
		HRESULT retValue;
	};

	STDMETHOD(selectSingleNode)(
		/*[in]*/ BSTR queryString,
		/*[retval,out]*/ IXMLDOMNode** resultNode)
	{
		VSL_DEFINE_MOCK_METHOD(selectSingleNode)

		VSL_CHECK_VALIDVALUE_BSTR(queryString);

		VSL_SET_VALIDVALUE_INTERFACE(resultNode);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_parsedValidValues
	{
		/*[retval,out]*/ VARIANT_BOOL* isParsed;
		HRESULT retValue;
	};

	STDMETHOD(get_parsed)(
		/*[retval,out]*/ VARIANT_BOOL* isParsed)
	{
		VSL_DEFINE_MOCK_METHOD(get_parsed)

		VSL_SET_VALIDVALUE(isParsed);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_namespaceURIValidValues
	{
		/*[retval,out]*/ BSTR* namespaceURI;
		HRESULT retValue;
	};

	STDMETHOD(get_namespaceURI)(
		/*[retval,out]*/ BSTR* namespaceURI)
	{
		VSL_DEFINE_MOCK_METHOD(get_namespaceURI)

		VSL_SET_VALIDVALUE_BSTR(namespaceURI);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_prefixValidValues
	{
		/*[retval,out]*/ BSTR* prefixString;
		HRESULT retValue;
	};

	STDMETHOD(get_prefix)(
		/*[retval,out]*/ BSTR* prefixString)
	{
		VSL_DEFINE_MOCK_METHOD(get_prefix)

		VSL_SET_VALIDVALUE_BSTR(prefixString);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_baseNameValidValues
	{
		/*[retval,out]*/ BSTR* nameString;
		HRESULT retValue;
	};

	STDMETHOD(get_baseName)(
		/*[retval,out]*/ BSTR* nameString)
	{
		VSL_DEFINE_MOCK_METHOD(get_baseName)

		VSL_SET_VALIDVALUE_BSTR(nameString);

		VSL_RETURN_VALIDVALUES();
	}
	struct transformNodeToObjectValidValues
	{
		/*[in]*/ IXMLDOMNode* stylesheet;
		/*[in]*/ VARIANT outputObject;
		HRESULT retValue;
	};

	STDMETHOD(transformNodeToObject)(
		/*[in]*/ IXMLDOMNode* stylesheet,
		/*[in]*/ VARIANT outputObject)
	{
		VSL_DEFINE_MOCK_METHOD(transformNodeToObject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(stylesheet);

		VSL_CHECK_VALIDVALUE(outputObject);

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

#endif // IXMLDOMNOTATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
