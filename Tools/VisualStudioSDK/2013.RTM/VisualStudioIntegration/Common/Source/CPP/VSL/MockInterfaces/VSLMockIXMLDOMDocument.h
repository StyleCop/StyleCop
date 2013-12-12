/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IXMLDOMDOCUMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IXMLDOMDOCUMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IXMLDOMDocumentNotImpl :
	public IXMLDOMDocument
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IXMLDOMDocumentNotImpl)

public:

	typedef IXMLDOMDocument Interface;

	STDMETHOD(get_doctype)(
		/*[out,retval]*/ IXMLDOMDocumentType** /*documentType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_implementation)(
		/*[out,retval]*/ IXMLDOMImplementation** /*impl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_documentElement)(
		/*[out,retval]*/ IXMLDOMElement** /*DOMElement*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(putref_documentElement)(
		/*[in]*/ IXMLDOMElement* /*DOMElement*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(createElement)(
		/*[in]*/ BSTR /*tagName*/,
		/*[out,retval]*/ IXMLDOMElement** /*element*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(createDocumentFragment)(
		/*[out,retval]*/ IXMLDOMDocumentFragment** /*docFrag*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(createTextNode)(
		/*[in]*/ BSTR /*data*/,
		/*[out,retval]*/ IXMLDOMText** /*text*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(createComment)(
		/*[in]*/ BSTR /*data*/,
		/*[out,retval]*/ IXMLDOMComment** /*comment*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(createCDATASection)(
		/*[in]*/ BSTR /*data*/,
		/*[out,retval]*/ IXMLDOMCDATASection** /*cdata*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(createProcessingInstruction)(
		/*[in]*/ BSTR /*target*/,
		/*[in]*/ BSTR /*data*/,
		/*[out,retval]*/ IXMLDOMProcessingInstruction** /*pi*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(createAttribute)(
		/*[in]*/ BSTR /*name*/,
		/*[out,retval]*/ IXMLDOMAttribute** /*attribute*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(createEntityReference)(
		/*[in]*/ BSTR /*name*/,
		/*[out,retval]*/ IXMLDOMEntityReference** /*entityRef*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(getElementsByTagName)(
		/*[in]*/ BSTR /*tagName*/,
		/*[out,retval]*/ IXMLDOMNodeList** /*resultList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(createNode)(
		/*[in]*/ VARIANT /*Type*/,
		/*[in]*/ BSTR /*name*/,
		/*[in]*/ BSTR /*namespaceURI*/,
		/*[retval,out]*/ IXMLDOMNode** /*node*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(nodeFromID)(
		/*[in]*/ BSTR /*idString*/,
		/*[retval,out]*/ IXMLDOMNode** /*node*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(load)(
		/*[in]*/ VARIANT /*xmlSource*/,
		/*[out,retval]*/ VARIANT_BOOL* /*isSuccessful*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_readyState)(
		/*[retval,out]*/ long* /*value*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_parseError)(
		/*[retval,out]*/ IXMLDOMParseError** /*errorObj*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_url)(
		/*[retval,out]*/ BSTR* /*urlString*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_async)(
		/*[retval,out]*/ VARIANT_BOOL* /*isAsync*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_async)(
		/*[in]*/ VARIANT_BOOL /*isAsync*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(abort)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(loadXML)(
		/*[in]*/ BSTR /*bstrXML*/,
		/*[out,retval]*/ VARIANT_BOOL* /*isSuccessful*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(save)(
		/*[in]*/ VARIANT /*desination*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_validateOnParse)(
		/*[retval,out]*/ VARIANT_BOOL* /*isValidating*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_validateOnParse)(
		/*[in]*/ VARIANT_BOOL /*isValidating*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_resolveExternals)(
		/*[retval,out]*/ VARIANT_BOOL* /*isResolving*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_resolveExternals)(
		/*[in]*/ VARIANT_BOOL /*isResolving*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_preserveWhiteSpace)(
		/*[retval,out]*/ VARIANT_BOOL* /*isPreserving*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_preserveWhiteSpace)(
		/*[in]*/ VARIANT_BOOL /*isPreserving*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_onreadystatechange)(
		/*[in]*/ VARIANT /*readystatechangeSink*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_ondataavailable)(
		/*[in]*/ VARIANT /*ondataavailableSink*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_ontransformnode)(
		/*[in]*/ VARIANT /*ontransformnodeSink*/)VSL_STDMETHOD_NOTIMPL

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

class IXMLDOMDocumentMockImpl :
	public IXMLDOMDocument,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IXMLDOMDocumentMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IXMLDOMDocumentMockImpl)

	typedef IXMLDOMDocument Interface;
	struct get_doctypeValidValues
	{
		/*[out,retval]*/ IXMLDOMDocumentType** documentType;
		HRESULT retValue;
	};

	STDMETHOD(get_doctype)(
		/*[out,retval]*/ IXMLDOMDocumentType** documentType)
	{
		VSL_DEFINE_MOCK_METHOD(get_doctype)

		VSL_SET_VALIDVALUE_INTERFACE(documentType);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_implementationValidValues
	{
		/*[out,retval]*/ IXMLDOMImplementation** impl;
		HRESULT retValue;
	};

	STDMETHOD(get_implementation)(
		/*[out,retval]*/ IXMLDOMImplementation** impl)
	{
		VSL_DEFINE_MOCK_METHOD(get_implementation)

		VSL_SET_VALIDVALUE_INTERFACE(impl);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_documentElementValidValues
	{
		/*[out,retval]*/ IXMLDOMElement** DOMElement;
		HRESULT retValue;
	};

	STDMETHOD(get_documentElement)(
		/*[out,retval]*/ IXMLDOMElement** DOMElement)
	{
		VSL_DEFINE_MOCK_METHOD(get_documentElement)

		VSL_SET_VALIDVALUE_INTERFACE(DOMElement);

		VSL_RETURN_VALIDVALUES();
	}
	struct putref_documentElementValidValues
	{
		/*[in]*/ IXMLDOMElement* DOMElement;
		HRESULT retValue;
	};

	STDMETHOD(putref_documentElement)(
		/*[in]*/ IXMLDOMElement* DOMElement)
	{
		VSL_DEFINE_MOCK_METHOD(putref_documentElement)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(DOMElement);

		VSL_RETURN_VALIDVALUES();
	}
	struct createElementValidValues
	{
		/*[in]*/ BSTR tagName;
		/*[out,retval]*/ IXMLDOMElement** element;
		HRESULT retValue;
	};

	STDMETHOD(createElement)(
		/*[in]*/ BSTR tagName,
		/*[out,retval]*/ IXMLDOMElement** element)
	{
		VSL_DEFINE_MOCK_METHOD(createElement)

		VSL_CHECK_VALIDVALUE_BSTR(tagName);

		VSL_SET_VALIDVALUE_INTERFACE(element);

		VSL_RETURN_VALIDVALUES();
	}
	struct createDocumentFragmentValidValues
	{
		/*[out,retval]*/ IXMLDOMDocumentFragment** docFrag;
		HRESULT retValue;
	};

	STDMETHOD(createDocumentFragment)(
		/*[out,retval]*/ IXMLDOMDocumentFragment** docFrag)
	{
		VSL_DEFINE_MOCK_METHOD(createDocumentFragment)

		VSL_SET_VALIDVALUE_INTERFACE(docFrag);

		VSL_RETURN_VALIDVALUES();
	}
	struct createTextNodeValidValues
	{
		/*[in]*/ BSTR data;
		/*[out,retval]*/ IXMLDOMText** text;
		HRESULT retValue;
	};

	STDMETHOD(createTextNode)(
		/*[in]*/ BSTR data,
		/*[out,retval]*/ IXMLDOMText** text)
	{
		VSL_DEFINE_MOCK_METHOD(createTextNode)

		VSL_CHECK_VALIDVALUE_BSTR(data);

		VSL_SET_VALIDVALUE_INTERFACE(text);

		VSL_RETURN_VALIDVALUES();
	}
	struct createCommentValidValues
	{
		/*[in]*/ BSTR data;
		/*[out,retval]*/ IXMLDOMComment** comment;
		HRESULT retValue;
	};

	STDMETHOD(createComment)(
		/*[in]*/ BSTR data,
		/*[out,retval]*/ IXMLDOMComment** comment)
	{
		VSL_DEFINE_MOCK_METHOD(createComment)

		VSL_CHECK_VALIDVALUE_BSTR(data);

		VSL_SET_VALIDVALUE_INTERFACE(comment);

		VSL_RETURN_VALIDVALUES();
	}
	struct createCDATASectionValidValues
	{
		/*[in]*/ BSTR data;
		/*[out,retval]*/ IXMLDOMCDATASection** cdata;
		HRESULT retValue;
	};

	STDMETHOD(createCDATASection)(
		/*[in]*/ BSTR data,
		/*[out,retval]*/ IXMLDOMCDATASection** cdata)
	{
		VSL_DEFINE_MOCK_METHOD(createCDATASection)

		VSL_CHECK_VALIDVALUE_BSTR(data);

		VSL_SET_VALIDVALUE_INTERFACE(cdata);

		VSL_RETURN_VALIDVALUES();
	}
	struct createProcessingInstructionValidValues
	{
		/*[in]*/ BSTR target;
		/*[in]*/ BSTR data;
		/*[out,retval]*/ IXMLDOMProcessingInstruction** pi;
		HRESULT retValue;
	};

	STDMETHOD(createProcessingInstruction)(
		/*[in]*/ BSTR target,
		/*[in]*/ BSTR data,
		/*[out,retval]*/ IXMLDOMProcessingInstruction** pi)
	{
		VSL_DEFINE_MOCK_METHOD(createProcessingInstruction)

		VSL_CHECK_VALIDVALUE_BSTR(target);

		VSL_CHECK_VALIDVALUE_BSTR(data);

		VSL_SET_VALIDVALUE_INTERFACE(pi);

		VSL_RETURN_VALIDVALUES();
	}
	struct createAttributeValidValues
	{
		/*[in]*/ BSTR name;
		/*[out,retval]*/ IXMLDOMAttribute** attribute;
		HRESULT retValue;
	};

	STDMETHOD(createAttribute)(
		/*[in]*/ BSTR name,
		/*[out,retval]*/ IXMLDOMAttribute** attribute)
	{
		VSL_DEFINE_MOCK_METHOD(createAttribute)

		VSL_CHECK_VALIDVALUE_BSTR(name);

		VSL_SET_VALIDVALUE_INTERFACE(attribute);

		VSL_RETURN_VALIDVALUES();
	}
	struct createEntityReferenceValidValues
	{
		/*[in]*/ BSTR name;
		/*[out,retval]*/ IXMLDOMEntityReference** entityRef;
		HRESULT retValue;
	};

	STDMETHOD(createEntityReference)(
		/*[in]*/ BSTR name,
		/*[out,retval]*/ IXMLDOMEntityReference** entityRef)
	{
		VSL_DEFINE_MOCK_METHOD(createEntityReference)

		VSL_CHECK_VALIDVALUE_BSTR(name);

		VSL_SET_VALIDVALUE_INTERFACE(entityRef);

		VSL_RETURN_VALIDVALUES();
	}
	struct getElementsByTagNameValidValues
	{
		/*[in]*/ BSTR tagName;
		/*[out,retval]*/ IXMLDOMNodeList** resultList;
		HRESULT retValue;
	};

	STDMETHOD(getElementsByTagName)(
		/*[in]*/ BSTR tagName,
		/*[out,retval]*/ IXMLDOMNodeList** resultList)
	{
		VSL_DEFINE_MOCK_METHOD(getElementsByTagName)

		VSL_CHECK_VALIDVALUE_BSTR(tagName);

		VSL_SET_VALIDVALUE_INTERFACE(resultList);

		VSL_RETURN_VALIDVALUES();
	}
	struct createNodeValidValues
	{
		/*[in]*/ VARIANT Type;
		/*[in]*/ BSTR name;
		/*[in]*/ BSTR namespaceURI;
		/*[retval,out]*/ IXMLDOMNode** node;
		HRESULT retValue;
	};

	STDMETHOD(createNode)(
		/*[in]*/ VARIANT Type,
		/*[in]*/ BSTR name,
		/*[in]*/ BSTR namespaceURI,
		/*[retval,out]*/ IXMLDOMNode** node)
	{
		VSL_DEFINE_MOCK_METHOD(createNode)

		VSL_CHECK_VALIDVALUE(Type);

		VSL_CHECK_VALIDVALUE_BSTR(name);

		VSL_CHECK_VALIDVALUE_BSTR(namespaceURI);

		VSL_SET_VALIDVALUE_INTERFACE(node);

		VSL_RETURN_VALIDVALUES();
	}
	struct nodeFromIDValidValues
	{
		/*[in]*/ BSTR idString;
		/*[retval,out]*/ IXMLDOMNode** node;
		HRESULT retValue;
	};

	STDMETHOD(nodeFromID)(
		/*[in]*/ BSTR idString,
		/*[retval,out]*/ IXMLDOMNode** node)
	{
		VSL_DEFINE_MOCK_METHOD(nodeFromID)

		VSL_CHECK_VALIDVALUE_BSTR(idString);

		VSL_SET_VALIDVALUE_INTERFACE(node);

		VSL_RETURN_VALIDVALUES();
	}
	struct loadValidValues
	{
		/*[in]*/ VARIANT xmlSource;
		/*[out,retval]*/ VARIANT_BOOL* isSuccessful;
		HRESULT retValue;
	};

	STDMETHOD(load)(
		/*[in]*/ VARIANT xmlSource,
		/*[out,retval]*/ VARIANT_BOOL* isSuccessful)
	{
		VSL_DEFINE_MOCK_METHOD(load)

		VSL_CHECK_VALIDVALUE(xmlSource);

		VSL_SET_VALIDVALUE(isSuccessful);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_readyStateValidValues
	{
		/*[retval,out]*/ long* value;
		HRESULT retValue;
	};

	STDMETHOD(get_readyState)(
		/*[retval,out]*/ long* value)
	{
		VSL_DEFINE_MOCK_METHOD(get_readyState)

		VSL_SET_VALIDVALUE(value);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_parseErrorValidValues
	{
		/*[retval,out]*/ IXMLDOMParseError** errorObj;
		HRESULT retValue;
	};

	STDMETHOD(get_parseError)(
		/*[retval,out]*/ IXMLDOMParseError** errorObj)
	{
		VSL_DEFINE_MOCK_METHOD(get_parseError)

		VSL_SET_VALIDVALUE_INTERFACE(errorObj);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_urlValidValues
	{
		/*[retval,out]*/ BSTR* urlString;
		HRESULT retValue;
	};

	STDMETHOD(get_url)(
		/*[retval,out]*/ BSTR* urlString)
	{
		VSL_DEFINE_MOCK_METHOD(get_url)

		VSL_SET_VALIDVALUE_BSTR(urlString);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_asyncValidValues
	{
		/*[retval,out]*/ VARIANT_BOOL* isAsync;
		HRESULT retValue;
	};

	STDMETHOD(get_async)(
		/*[retval,out]*/ VARIANT_BOOL* isAsync)
	{
		VSL_DEFINE_MOCK_METHOD(get_async)

		VSL_SET_VALIDVALUE(isAsync);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_asyncValidValues
	{
		/*[in]*/ VARIANT_BOOL isAsync;
		HRESULT retValue;
	};

	STDMETHOD(put_async)(
		/*[in]*/ VARIANT_BOOL isAsync)
	{
		VSL_DEFINE_MOCK_METHOD(put_async)

		VSL_CHECK_VALIDVALUE(isAsync);

		VSL_RETURN_VALIDVALUES();
	}
	struct abortValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(abort)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(abort)

		VSL_RETURN_VALIDVALUES();
	}
	struct loadXMLValidValues
	{
		/*[in]*/ BSTR bstrXML;
		/*[out,retval]*/ VARIANT_BOOL* isSuccessful;
		HRESULT retValue;
	};

	STDMETHOD(loadXML)(
		/*[in]*/ BSTR bstrXML,
		/*[out,retval]*/ VARIANT_BOOL* isSuccessful)
	{
		VSL_DEFINE_MOCK_METHOD(loadXML)

		VSL_CHECK_VALIDVALUE_BSTR(bstrXML);

		VSL_SET_VALIDVALUE(isSuccessful);

		VSL_RETURN_VALIDVALUES();
	}
	struct saveValidValues
	{
		/*[in]*/ VARIANT desination;
		HRESULT retValue;
	};

	STDMETHOD(save)(
		/*[in]*/ VARIANT desination)
	{
		VSL_DEFINE_MOCK_METHOD(save)

		VSL_CHECK_VALIDVALUE(desination);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_validateOnParseValidValues
	{
		/*[retval,out]*/ VARIANT_BOOL* isValidating;
		HRESULT retValue;
	};

	STDMETHOD(get_validateOnParse)(
		/*[retval,out]*/ VARIANT_BOOL* isValidating)
	{
		VSL_DEFINE_MOCK_METHOD(get_validateOnParse)

		VSL_SET_VALIDVALUE(isValidating);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_validateOnParseValidValues
	{
		/*[in]*/ VARIANT_BOOL isValidating;
		HRESULT retValue;
	};

	STDMETHOD(put_validateOnParse)(
		/*[in]*/ VARIANT_BOOL isValidating)
	{
		VSL_DEFINE_MOCK_METHOD(put_validateOnParse)

		VSL_CHECK_VALIDVALUE(isValidating);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_resolveExternalsValidValues
	{
		/*[retval,out]*/ VARIANT_BOOL* isResolving;
		HRESULT retValue;
	};

	STDMETHOD(get_resolveExternals)(
		/*[retval,out]*/ VARIANT_BOOL* isResolving)
	{
		VSL_DEFINE_MOCK_METHOD(get_resolveExternals)

		VSL_SET_VALIDVALUE(isResolving);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_resolveExternalsValidValues
	{
		/*[in]*/ VARIANT_BOOL isResolving;
		HRESULT retValue;
	};

	STDMETHOD(put_resolveExternals)(
		/*[in]*/ VARIANT_BOOL isResolving)
	{
		VSL_DEFINE_MOCK_METHOD(put_resolveExternals)

		VSL_CHECK_VALIDVALUE(isResolving);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_preserveWhiteSpaceValidValues
	{
		/*[retval,out]*/ VARIANT_BOOL* isPreserving;
		HRESULT retValue;
	};

	STDMETHOD(get_preserveWhiteSpace)(
		/*[retval,out]*/ VARIANT_BOOL* isPreserving)
	{
		VSL_DEFINE_MOCK_METHOD(get_preserveWhiteSpace)

		VSL_SET_VALIDVALUE(isPreserving);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_preserveWhiteSpaceValidValues
	{
		/*[in]*/ VARIANT_BOOL isPreserving;
		HRESULT retValue;
	};

	STDMETHOD(put_preserveWhiteSpace)(
		/*[in]*/ VARIANT_BOOL isPreserving)
	{
		VSL_DEFINE_MOCK_METHOD(put_preserveWhiteSpace)

		VSL_CHECK_VALIDVALUE(isPreserving);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_onreadystatechangeValidValues
	{
		/*[in]*/ VARIANT readystatechangeSink;
		HRESULT retValue;
	};

	STDMETHOD(put_onreadystatechange)(
		/*[in]*/ VARIANT readystatechangeSink)
	{
		VSL_DEFINE_MOCK_METHOD(put_onreadystatechange)

		VSL_CHECK_VALIDVALUE(readystatechangeSink);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ondataavailableValidValues
	{
		/*[in]*/ VARIANT ondataavailableSink;
		HRESULT retValue;
	};

	STDMETHOD(put_ondataavailable)(
		/*[in]*/ VARIANT ondataavailableSink)
	{
		VSL_DEFINE_MOCK_METHOD(put_ondataavailable)

		VSL_CHECK_VALIDVALUE(ondataavailableSink);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ontransformnodeValidValues
	{
		/*[in]*/ VARIANT ontransformnodeSink;
		HRESULT retValue;
	};

	STDMETHOD(put_ontransformnode)(
		/*[in]*/ VARIANT ontransformnodeSink)
	{
		VSL_DEFINE_MOCK_METHOD(put_ontransformnode)

		VSL_CHECK_VALIDVALUE(ontransformnodeSink);

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

#endif // IXMLDOMDOCUMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
