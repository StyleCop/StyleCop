/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUISHELLOPENDOCUMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUISHELLOPENDOCUMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsUIShellOpenDocumentNotImpl :
	public IVsUIShellOpenDocument
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIShellOpenDocumentNotImpl)

public:

	typedef IVsUIShellOpenDocument Interface;

	STDMETHOD(IsDocumentOpen)(
		/*[in]*/ IVsUIHierarchy* /*pHierCaller*/,
		/*[in]*/ VSITEMID /*itemidCaller*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[in]*/ VSIDOFLAGS /*grfIDO*/,
		/*[out]*/ IVsUIHierarchy** /*ppHierOpen*/,
		/*[out]*/ VSITEMID* /*pitemidOpen*/,
		/*[out]*/ IVsWindowFrame** /*ppWindowFrame*/,
		/*[out,retval]*/ BOOL* /*pfOpen*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsDocumentInAProject)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[out]*/ IVsUIHierarchy** /*ppUIH*/,
		/*[out]*/ VSITEMID* /*pitemid*/,
		/*[out]*/ IServiceProvider** /*ppSP*/,
		/*[out,retval]*/ VSDOCINPROJECT* /*pDocInProj*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenDocumentViaProject)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[out]*/ IServiceProvider** /*ppSP*/,
		/*[out]*/ IVsUIHierarchy** /*ppHier*/,
		/*[out]*/ VSITEMID* /*pitemid*/,
		/*[out,retval]*/ IVsWindowFrame** /*ppWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenStandardEditor)(
		/*[in]*/ VSOSEFLAGS /*grfOpenStandard*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[in]*/ LPCOLESTR /*pszOwnerCaption*/,
		/*[in]*/ IVsUIHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ IUnknown* /*punkDocDataExisting*/,
		/*[in]*/ IServiceProvider* /*pSP*/,
		/*[out,retval]*/ IVsWindowFrame** /*ppWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenStandardPreviewer)(
		/*[in]*/ VSOSPFLAGS /*ospOpenDocPreviewer*/,
		/*[in]*/ LPCOLESTR /*pszURL*/,
		/*[in]*/ VSPREVIEWRESOLUTION /*resolution*/,
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStandardEditorFactory)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in,out]*/ GUID* /*pguidEditorType*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[out]*/ BSTR* /*pbstrPhysicalView*/,
		/*[out,retval]*/ IVsEditorFactory** /*ppEF*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MapLogicalView)(
		/*[in]*/ REFGUID /*rguidEditorType*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[out,retval]*/ BSTR* /*pbstrPhysicalView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenSpecificEditor)(
		/*[in]*/ VSOSPEFLAGS /*grfOpenSpecific*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ REFGUID /*rguidEditorType*/,
		/*[in]*/ LPCOLESTR /*pszPhysicalView*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[in]*/ LPCOLESTR /*pszOwnerCaption*/,
		/*[in]*/ IVsUIHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ IUnknown* /*punkDocDataExisting*/,
		/*[in]*/ IServiceProvider* /*pSPHierContext*/,
		/*[out,retval]*/ IVsWindowFrame** /*ppWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InitializeEditorInstance)(
		/*[in]*/ VSIEIFLAGS /*grfIEI*/,
		/*[in]*/ IUnknown* /*punkDocView*/,
		/*[in]*/ IUnknown* /*punkDocData*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ REFGUID /*rguidEditorType*/,
		/*[in]*/ LPCOLESTR /*pszPhysicalView*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[in]*/ LPCOLESTR /*pszOwnerCaption*/,
		/*[in]*/ LPCOLESTR /*pszEditorCaption*/,
		/*[in]*/ IVsUIHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ IUnknown* /*punkDocDataExisting*/,
		/*[in]*/ IServiceProvider* /*pSPHierContext*/,
		/*[in]*/ REFGUID /*rguidCmdUI*/,
		/*[out,retval]*/ IVsWindowFrame** /*ppWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsSpecificDocumentViewOpen)(
		/*[in]*/ IVsUIHierarchy* /*pHierCaller*/,
		/*[in]*/ VSITEMID /*itemidCaller*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ REFGUID /*rguidEditorType*/,
		/*[in]*/ LPCOLESTR /*pszPhysicalView*/,
		/*[in]*/ VSIDOFLAGS /*grfIDO*/,
		/*[out]*/ IVsUIHierarchy** /*ppHierOpen*/,
		/*[out]*/ VSITEMID* /*pitemidOpen*/,
		/*[out]*/ IVsWindowFrame** /*ppWindowFrame*/,
		/*[out,retval]*/ BOOL* /*pfOpen*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenDocumentViaProjectWithSpecific)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ VSSPECIFICEDITORFLAGS /*grfEditorFlags*/,
		/*[in]*/ REFGUID /*rguidEditorType*/,
		/*[in]*/ LPCOLESTR /*pszPhysicalView*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[out]*/ IServiceProvider** /*ppSP*/,
		/*[out]*/ IVsUIHierarchy** /*ppHier*/,
		/*[out]*/ VSITEMID* /*pitemid*/,
		/*[out,retval]*/ IVsWindowFrame** /*ppWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenCopyOfStandardEditor)(
		/*[in]*/ IVsWindowFrame* /*pWindowFrame*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[out,retval]*/ IVsWindowFrame** /*ppNewWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFirstDefaultPreviewer)(
		/*[out]*/ BSTR* /*pbstrDefBrowserPath*/,
		/*[out]*/ BOOL* /*pfIsInternalBrowser*/,
		/*[out]*/ BOOL* /*pfIsSystemBrowser*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SearchProjectsForRelativePath)(
		/*[in]*/ VSRELPATHSEARCHFLAGS /*grfRPS*/,
		/*[in]*/ LPCOLESTR /*pszRelPath*/,
		/*[out,retval]*/ BSTR* /*pbstrAbsPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddStandardPreviewer)(
		/*[in]*/ LPCOLESTR /*pszExePath*/,
		/*[in]*/ LPCOLESTR /*pszDisplayName*/,
		/*[in]*/ BOOL /*fUseDDE*/,
		/*[in]*/ LPCOLESTR /*pszDDEService*/,
		/*[in]*/ LPCOLESTR /*pszDDETopicOpenURL*/,
		/*[in]*/ LPCOLESTR /*pszDDEItemOpenURL*/,
		/*[in]*/ LPCOLESTR /*pszDDETopicActivate*/,
		/*[in]*/ LPCOLESTR /*pszDDEItemActivate*/,
		/*[in]*/ VSASPFLAGS /*aspAddPreviewerFlags*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUIShellOpenDocumentMockImpl :
	public IVsUIShellOpenDocument,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIShellOpenDocumentMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUIShellOpenDocumentMockImpl)

	typedef IVsUIShellOpenDocument Interface;
	struct IsDocumentOpenValidValues
	{
		/*[in]*/ IVsUIHierarchy* pHierCaller;
		/*[in]*/ VSITEMID itemidCaller;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[in]*/ VSIDOFLAGS grfIDO;
		/*[out]*/ IVsUIHierarchy** ppHierOpen;
		/*[out]*/ VSITEMID* pitemidOpen;
		/*[out]*/ IVsWindowFrame** ppWindowFrame;
		/*[out,retval]*/ BOOL* pfOpen;
		HRESULT retValue;
	};

	STDMETHOD(IsDocumentOpen)(
		/*[in]*/ IVsUIHierarchy* pHierCaller,
		/*[in]*/ VSITEMID itemidCaller,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[in]*/ VSIDOFLAGS grfIDO,
		/*[out]*/ IVsUIHierarchy** ppHierOpen,
		/*[out]*/ VSITEMID* pitemidOpen,
		/*[out]*/ IVsWindowFrame** ppWindowFrame,
		/*[out,retval]*/ BOOL* pfOpen)
	{
		VSL_DEFINE_MOCK_METHOD(IsDocumentOpen)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierCaller);

		VSL_CHECK_VALIDVALUE(itemidCaller);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_CHECK_VALIDVALUE(grfIDO);

		VSL_SET_VALIDVALUE_INTERFACE(ppHierOpen);

		VSL_SET_VALIDVALUE(pitemidOpen);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_SET_VALIDVALUE(pfOpen);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsDocumentInAProjectValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[out]*/ IVsUIHierarchy** ppUIH;
		/*[out]*/ VSITEMID* pitemid;
		/*[out]*/ IServiceProvider** ppSP;
		/*[out,retval]*/ VSDOCINPROJECT* pDocInProj;
		HRESULT retValue;
	};

	STDMETHOD(IsDocumentInAProject)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[out]*/ IVsUIHierarchy** ppUIH,
		/*[out]*/ VSITEMID* pitemid,
		/*[out]*/ IServiceProvider** ppSP,
		/*[out,retval]*/ VSDOCINPROJECT* pDocInProj)
	{
		VSL_DEFINE_MOCK_METHOD(IsDocumentInAProject)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_SET_VALIDVALUE_INTERFACE(ppUIH);

		VSL_SET_VALIDVALUE(pitemid);

		VSL_SET_VALIDVALUE_INTERFACE(ppSP);

		VSL_SET_VALIDVALUE(pDocInProj);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenDocumentViaProjectValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[out]*/ IServiceProvider** ppSP;
		/*[out]*/ IVsUIHierarchy** ppHier;
		/*[out]*/ VSITEMID* pitemid;
		/*[out,retval]*/ IVsWindowFrame** ppWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(OpenDocumentViaProject)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[out]*/ IServiceProvider** ppSP,
		/*[out]*/ IVsUIHierarchy** ppHier,
		/*[out]*/ VSITEMID* pitemid,
		/*[out,retval]*/ IVsWindowFrame** ppWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(OpenDocumentViaProject)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_SET_VALIDVALUE_INTERFACE(ppSP);

		VSL_SET_VALIDVALUE_INTERFACE(ppHier);

		VSL_SET_VALIDVALUE(pitemid);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenStandardEditorValidValues
	{
		/*[in]*/ VSOSEFLAGS grfOpenStandard;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[in]*/ LPCOLESTR pszOwnerCaption;
		/*[in]*/ IVsUIHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ IUnknown* punkDocDataExisting;
		/*[in]*/ IServiceProvider* pSP;
		/*[out,retval]*/ IVsWindowFrame** ppWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(OpenStandardEditor)(
		/*[in]*/ VSOSEFLAGS grfOpenStandard,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[in]*/ LPCOLESTR pszOwnerCaption,
		/*[in]*/ IVsUIHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ IUnknown* punkDocDataExisting,
		/*[in]*/ IServiceProvider* pSP,
		/*[out,retval]*/ IVsWindowFrame** ppWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(OpenStandardEditor)

		VSL_CHECK_VALIDVALUE(grfOpenStandard);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_CHECK_VALIDVALUE_STRINGW(pszOwnerCaption);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocDataExisting);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSP);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenStandardPreviewerValidValues
	{
		/*[in]*/ VSOSPFLAGS ospOpenDocPreviewer;
		/*[in]*/ LPCOLESTR pszURL;
		/*[in]*/ VSPREVIEWRESOLUTION resolution;
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(OpenStandardPreviewer)(
		/*[in]*/ VSOSPFLAGS ospOpenDocPreviewer,
		/*[in]*/ LPCOLESTR pszURL,
		/*[in]*/ VSPREVIEWRESOLUTION resolution,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(OpenStandardPreviewer)

		VSL_CHECK_VALIDVALUE(ospOpenDocPreviewer);

		VSL_CHECK_VALIDVALUE_STRINGW(pszURL);

		VSL_CHECK_VALIDVALUE(resolution);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStandardEditorFactoryValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in,out]*/ GUID* pguidEditorType;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[out]*/ BSTR* pbstrPhysicalView;
		/*[out,retval]*/ IVsEditorFactory** ppEF;
		HRESULT retValue;
	};

	STDMETHOD(GetStandardEditorFactory)(
		/*[in]*/ DWORD dwReserved,
		/*[in,out]*/ GUID* pguidEditorType,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[out]*/ BSTR* pbstrPhysicalView,
		/*[out,retval]*/ IVsEditorFactory** ppEF)
	{
		VSL_DEFINE_MOCK_METHOD(GetStandardEditorFactory)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_SET_VALIDVALUE(pguidEditorType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_SET_VALIDVALUE_BSTR(pbstrPhysicalView);

		VSL_SET_VALIDVALUE_INTERFACE(ppEF);

		VSL_RETURN_VALIDVALUES();
	}
	struct MapLogicalViewValidValues
	{
		/*[in]*/ REFGUID rguidEditorType;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[out,retval]*/ BSTR* pbstrPhysicalView;
		HRESULT retValue;
	};

	STDMETHOD(MapLogicalView)(
		/*[in]*/ REFGUID rguidEditorType,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[out,retval]*/ BSTR* pbstrPhysicalView)
	{
		VSL_DEFINE_MOCK_METHOD(MapLogicalView)

		VSL_CHECK_VALIDVALUE(rguidEditorType);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_SET_VALIDVALUE_BSTR(pbstrPhysicalView);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenSpecificEditorValidValues
	{
		/*[in]*/ VSOSPEFLAGS grfOpenSpecific;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ REFGUID rguidEditorType;
		/*[in]*/ LPCOLESTR pszPhysicalView;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[in]*/ LPCOLESTR pszOwnerCaption;
		/*[in]*/ IVsUIHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ IUnknown* punkDocDataExisting;
		/*[in]*/ IServiceProvider* pSPHierContext;
		/*[out,retval]*/ IVsWindowFrame** ppWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(OpenSpecificEditor)(
		/*[in]*/ VSOSPEFLAGS grfOpenSpecific,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ REFGUID rguidEditorType,
		/*[in]*/ LPCOLESTR pszPhysicalView,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[in]*/ LPCOLESTR pszOwnerCaption,
		/*[in]*/ IVsUIHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ IUnknown* punkDocDataExisting,
		/*[in]*/ IServiceProvider* pSPHierContext,
		/*[out,retval]*/ IVsWindowFrame** ppWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(OpenSpecificEditor)

		VSL_CHECK_VALIDVALUE(grfOpenSpecific);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(rguidEditorType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPhysicalView);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_CHECK_VALIDVALUE_STRINGW(pszOwnerCaption);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocDataExisting);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSPHierContext);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct InitializeEditorInstanceValidValues
	{
		/*[in]*/ VSIEIFLAGS grfIEI;
		/*[in]*/ IUnknown* punkDocView;
		/*[in]*/ IUnknown* punkDocData;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ REFGUID rguidEditorType;
		/*[in]*/ LPCOLESTR pszPhysicalView;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[in]*/ LPCOLESTR pszOwnerCaption;
		/*[in]*/ LPCOLESTR pszEditorCaption;
		/*[in]*/ IVsUIHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ IUnknown* punkDocDataExisting;
		/*[in]*/ IServiceProvider* pSPHierContext;
		/*[in]*/ REFGUID rguidCmdUI;
		/*[out,retval]*/ IVsWindowFrame** ppWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(InitializeEditorInstance)(
		/*[in]*/ VSIEIFLAGS grfIEI,
		/*[in]*/ IUnknown* punkDocView,
		/*[in]*/ IUnknown* punkDocData,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ REFGUID rguidEditorType,
		/*[in]*/ LPCOLESTR pszPhysicalView,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[in]*/ LPCOLESTR pszOwnerCaption,
		/*[in]*/ LPCOLESTR pszEditorCaption,
		/*[in]*/ IVsUIHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ IUnknown* punkDocDataExisting,
		/*[in]*/ IServiceProvider* pSPHierContext,
		/*[in]*/ REFGUID rguidCmdUI,
		/*[out,retval]*/ IVsWindowFrame** ppWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(InitializeEditorInstance)

		VSL_CHECK_VALIDVALUE(grfIEI);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocView);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocData);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(rguidEditorType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPhysicalView);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_CHECK_VALIDVALUE_STRINGW(pszOwnerCaption);

		VSL_CHECK_VALIDVALUE_STRINGW(pszEditorCaption);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocDataExisting);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSPHierContext);

		VSL_CHECK_VALIDVALUE(rguidCmdUI);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsSpecificDocumentViewOpenValidValues
	{
		/*[in]*/ IVsUIHierarchy* pHierCaller;
		/*[in]*/ VSITEMID itemidCaller;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ REFGUID rguidEditorType;
		/*[in]*/ LPCOLESTR pszPhysicalView;
		/*[in]*/ VSIDOFLAGS grfIDO;
		/*[out]*/ IVsUIHierarchy** ppHierOpen;
		/*[out]*/ VSITEMID* pitemidOpen;
		/*[out]*/ IVsWindowFrame** ppWindowFrame;
		/*[out,retval]*/ BOOL* pfOpen;
		HRESULT retValue;
	};

	STDMETHOD(IsSpecificDocumentViewOpen)(
		/*[in]*/ IVsUIHierarchy* pHierCaller,
		/*[in]*/ VSITEMID itemidCaller,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ REFGUID rguidEditorType,
		/*[in]*/ LPCOLESTR pszPhysicalView,
		/*[in]*/ VSIDOFLAGS grfIDO,
		/*[out]*/ IVsUIHierarchy** ppHierOpen,
		/*[out]*/ VSITEMID* pitemidOpen,
		/*[out]*/ IVsWindowFrame** ppWindowFrame,
		/*[out,retval]*/ BOOL* pfOpen)
	{
		VSL_DEFINE_MOCK_METHOD(IsSpecificDocumentViewOpen)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierCaller);

		VSL_CHECK_VALIDVALUE(itemidCaller);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(rguidEditorType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPhysicalView);

		VSL_CHECK_VALIDVALUE(grfIDO);

		VSL_SET_VALIDVALUE_INTERFACE(ppHierOpen);

		VSL_SET_VALIDVALUE(pitemidOpen);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_SET_VALIDVALUE(pfOpen);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenDocumentViaProjectWithSpecificValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ VSSPECIFICEDITORFLAGS grfEditorFlags;
		/*[in]*/ REFGUID rguidEditorType;
		/*[in]*/ LPCOLESTR pszPhysicalView;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[out]*/ IServiceProvider** ppSP;
		/*[out]*/ IVsUIHierarchy** ppHier;
		/*[out]*/ VSITEMID* pitemid;
		/*[out,retval]*/ IVsWindowFrame** ppWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(OpenDocumentViaProjectWithSpecific)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ VSSPECIFICEDITORFLAGS grfEditorFlags,
		/*[in]*/ REFGUID rguidEditorType,
		/*[in]*/ LPCOLESTR pszPhysicalView,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[out]*/ IServiceProvider** ppSP,
		/*[out]*/ IVsUIHierarchy** ppHier,
		/*[out]*/ VSITEMID* pitemid,
		/*[out,retval]*/ IVsWindowFrame** ppWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(OpenDocumentViaProjectWithSpecific)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(grfEditorFlags);

		VSL_CHECK_VALIDVALUE(rguidEditorType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPhysicalView);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_SET_VALIDVALUE_INTERFACE(ppSP);

		VSL_SET_VALIDVALUE_INTERFACE(ppHier);

		VSL_SET_VALIDVALUE(pitemid);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenCopyOfStandardEditorValidValues
	{
		/*[in]*/ IVsWindowFrame* pWindowFrame;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[out,retval]*/ IVsWindowFrame** ppNewWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(OpenCopyOfStandardEditor)(
		/*[in]*/ IVsWindowFrame* pWindowFrame,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[out,retval]*/ IVsWindowFrame** ppNewWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(OpenCopyOfStandardEditor)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pWindowFrame);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_SET_VALIDVALUE_INTERFACE(ppNewWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFirstDefaultPreviewerValidValues
	{
		/*[out]*/ BSTR* pbstrDefBrowserPath;
		/*[out]*/ BOOL* pfIsInternalBrowser;
		/*[out]*/ BOOL* pfIsSystemBrowser;
		HRESULT retValue;
	};

	STDMETHOD(GetFirstDefaultPreviewer)(
		/*[out]*/ BSTR* pbstrDefBrowserPath,
		/*[out]*/ BOOL* pfIsInternalBrowser,
		/*[out]*/ BOOL* pfIsSystemBrowser)
	{
		VSL_DEFINE_MOCK_METHOD(GetFirstDefaultPreviewer)

		VSL_SET_VALIDVALUE_BSTR(pbstrDefBrowserPath);

		VSL_SET_VALIDVALUE(pfIsInternalBrowser);

		VSL_SET_VALIDVALUE(pfIsSystemBrowser);

		VSL_RETURN_VALIDVALUES();
	}
	struct SearchProjectsForRelativePathValidValues
	{
		/*[in]*/ VSRELPATHSEARCHFLAGS grfRPS;
		/*[in]*/ LPCOLESTR pszRelPath;
		/*[out,retval]*/ BSTR* pbstrAbsPath;
		HRESULT retValue;
	};

	STDMETHOD(SearchProjectsForRelativePath)(
		/*[in]*/ VSRELPATHSEARCHFLAGS grfRPS,
		/*[in]*/ LPCOLESTR pszRelPath,
		/*[out,retval]*/ BSTR* pbstrAbsPath)
	{
		VSL_DEFINE_MOCK_METHOD(SearchProjectsForRelativePath)

		VSL_CHECK_VALIDVALUE(grfRPS);

		VSL_CHECK_VALIDVALUE_STRINGW(pszRelPath);

		VSL_SET_VALIDVALUE_BSTR(pbstrAbsPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddStandardPreviewerValidValues
	{
		/*[in]*/ LPCOLESTR pszExePath;
		/*[in]*/ LPCOLESTR pszDisplayName;
		/*[in]*/ BOOL fUseDDE;
		/*[in]*/ LPCOLESTR pszDDEService;
		/*[in]*/ LPCOLESTR pszDDETopicOpenURL;
		/*[in]*/ LPCOLESTR pszDDEItemOpenURL;
		/*[in]*/ LPCOLESTR pszDDETopicActivate;
		/*[in]*/ LPCOLESTR pszDDEItemActivate;
		/*[in]*/ VSASPFLAGS aspAddPreviewerFlags;
		HRESULT retValue;
	};

	STDMETHOD(AddStandardPreviewer)(
		/*[in]*/ LPCOLESTR pszExePath,
		/*[in]*/ LPCOLESTR pszDisplayName,
		/*[in]*/ BOOL fUseDDE,
		/*[in]*/ LPCOLESTR pszDDEService,
		/*[in]*/ LPCOLESTR pszDDETopicOpenURL,
		/*[in]*/ LPCOLESTR pszDDEItemOpenURL,
		/*[in]*/ LPCOLESTR pszDDETopicActivate,
		/*[in]*/ LPCOLESTR pszDDEItemActivate,
		/*[in]*/ VSASPFLAGS aspAddPreviewerFlags)
	{
		VSL_DEFINE_MOCK_METHOD(AddStandardPreviewer)

		VSL_CHECK_VALIDVALUE_STRINGW(pszExePath);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDisplayName);

		VSL_CHECK_VALIDVALUE(fUseDDE);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDDEService);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDDETopicOpenURL);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDDEItemOpenURL);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDDETopicActivate);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDDEItemActivate);

		VSL_CHECK_VALIDVALUE(aspAddPreviewerFlags);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUISHELLOPENDOCUMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
