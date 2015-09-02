/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#include "stdafx.h"

#include "VSLHierarchy.h"
#include "VSLHierarchyNode.h"

using namespace VSL;

VSL_DEFINE_SERVICE_MOCK(IVsShellServiceMock, IVsShellNotImpl);
VSL_DEFINE_SERVICE_MOCK(IVsUIShellServiceMock, IVsUIShellNotImpl);

typedef ServiceList<IVsShellServiceMock, ServiceList<IVsUIShellServiceMock, ServiceListTerminator> > IServiceProviderServiceList;
typedef InterfaceImplList<VSL::IServiceProviderImpl<IServiceProviderServiceList>, IUnknownInterfaceListTerminator<IServiceProvider> > IServiceProviderMockInterfaceList;

VSL_DECLARE_COM_MOCK(IServiceProviderMock, IServiceProviderMockInterfaceList){};

template <class Base_T = VsUIHierarchyItemBase<> >
class TestItem : public Base_T
{

VSL_DECLARE_NOT_COPYABLE(TestItem)

protected:
	TestItem()
	{
	}

public:
	typedef typename Base_T Base;
	typedef typename Base_T::ItemInterface ItemInterface;

	TestItem(ItemInterface* p):
		Base_T(p)
	{
	}

	TestItem(Base_T& rParent):
		Base_T(*static_cast<Base_T::BaseClass*>(&rParent))
	{
	}

	virtual const ATL::CComBSTR& GetCanonicalName() const
	{
		static CComBSTR bstr = __WFILE__;
		return bstr;
	}

	virtual VSITEMID ParseCanonicalName(_In_ LPCOLESTR pszName) const
	{
		(pszName);
		return VSITEMID_NIL;
	}

	virtual IOleCommandTarget* GetIOleCommandTarget()
	{
		return NULL;
	}

	virtual IDispatch* GetIDispatch()
	{
		return NULL;
	}

	virtual const GUID& GetTypeGuid() const
	{
		return CLSID_ManualResetEvent;
	}

	virtual const GUID& GetCmdUIGuid() const
	{
		return CLSID_StdEvent;
	}

	virtual const ATL::CComBSTR& GetCaption() const
	{
		static CComBSTR bstr = __WFILE__;
		return bstr;
	}

	virtual const ATL::CComBSTR& GetEditLabel() const
	{
		static CComBSTR bstr = __WFILE__;
		return bstr;
	}

	virtual void SetEditLabel(BSTR bstrEditLabel)
	{
		VSL_CHECKBOOLEAN(CComBSTR(__WFILE__) == bstrEditLabel, E_FAIL);		
	}

	virtual const ATL::CComBSTR& GetName() const
	{
		static CComBSTR bstr = __WFILE__;
		return bstr;
	}
};

class TestRoot : public VsHierarchyRootItemBase<TestItem<> >
{

VSL_DECLARE_NOT_COPYABLE(TestRoot)

public:

#pragma warning(push)
#pragma warning(disable : 4355) // 'this' : used in base member initializer list
	TestRoot():
		VsHierarchyRootItemBase<TestItem<> >(this)
	{
		SetSelection(this);
	}
#pragma warning(pop)

	void SetSelectionToItem(TestItem& item)
	{
		SetSelection(&item);
	}

	virtual bool IsExpandedByDefault() const
	{
		return true;
	}

	virtual ImageListWin32Control& GetIconImageList()
	{
		static ImageListWin32Control control;
		return control;
	}
};

template <
	class Base_T = TestItem<IVsUIHierarchyItem > >
class VsUIHierarchyItemMock :
	public Base_T,
	public IOleCommandTargetMockImpl
{
public:

VSL_DEFINE_IUNKNOWN_NOTIMPL

	typedef HierarchyNode<HierarchyNodeTraits<typename Base_T::ItemInterface*> > HierarchyNode;

	virtual const GUID& GetGuidProperty(_In_ VSHPROPID propid) const
	{
		(propid);
		return CLSID_ManualResetEvent;
	}

	virtual void SetGuidProperty(_In_ VSHPROPID propid,	_In_ REFGUID rguid)
	{
		(propid, rguid);
		VSL_CHECKBOOLEAN(CLSID_SynchronizeContainer == rguid, E_FAIL);
	}

	virtual void GetProperty(_In_ VSHPROPID propid, _Out_ VARIANT* pVar)
	{
		(propid);
		CComVariant var = E_UNEXPECTED;
		var.Detach(pVar);
	}

	virtual void SetProperty(_In_ VSHPROPID propid, _In_ VARIANT& rVar)
	{
		(propid);
		VSL_CHECKBOOLEAN(S_FALSE == rVar.lVal, E_FAIL);		
	}

	virtual const CComBSTR& GetCanonicalName() const
	{
		static CComBSTR bstr = __WFILE__;
		return bstr;
	}

	virtual VSITEMID ParseCanonicalName(_In_ LPCOLESTR pszName) const
	{
		VSL_CHECKBOOLEAN(CString(__WFILE__) == CString(pszName), E_FAIL);		
		return VSITEMID_SELECTION;
	}

	virtual VSITEMID GetVSITEMID() const
	{
		return reinterpret_cast<VSITEMID>(static_cast<const Base_T::ItemInterface* const>(this));
	}

	static bool& GetIOleCommandTargetReturnsNull()
	{
		static bool b = true;
		return b;
	}

	virtual IOleCommandTarget* GetIOleCommandTarget()
	{
		if(GetIOleCommandTargetReturnsNull())
		{
			return NULL;
		}
		else
		{
			return this;
		}
	}

	virtual bool IsVisible() const
	{
		return true;
	}

	HierarchyNode* m_pNode;

	virtual HIMAGELIST GetIconImageList() const
	{
		VSL_CREATE_ERROR_HRESULT(DISP_E_MEMBERNOTFOUND); // indicates that Visual Studio should supply the image list if possible
		return NULL;
	}

	virtual UINT GetIconIndex() const
	{
		// indicates that Visual Studio should supply the image index from it's own image list if possible
		VSL_CREATE_ERROR_HRESULT(DISP_E_MEMBERNOTFOUND);
		return 0;
	}

	virtual UINT GetOpenFolderIconIndex() const
	{
		// indicates that Visual Studio should supply the image index from it's own image list if possible
		VSL_CREATE_ERROR_HRESULT(DISP_E_MEMBERNOTFOUND);
		return 0;
	}

	virtual UINT GetStateIconIndex() const
	{
		// indicates that Visual Studio should supply the image index from it's own image list if possible
		VSL_CREATE_ERROR_HRESULT(DISP_E_MEMBERNOTFOUND);
		return 0;
	}

	virtual bool IsExpandable() const
	{
		return true;
	}

	virtual bool IsExpandedByDefault() const
	{
		return false;
	}

	virtual ISelectionContainer* GetISelectionContainer()
	{
		return NULL;
	}

	virtual IDispatch* GetIDispatch()
	{
		return NULL;
	}

	virtual IVsUserContext* GetIVsUserContext()
	{
		return NULL;
	}
};

class VsUIHierarchyRootItemMock :
	public VsUIHierarchyItemMock<>,
	public CComObjectRootEx<CComSingleThreadModel>
{
public:

	VsUIHierarchyRootItemMock()
	{
	}

	static HRESULT CreateInstance(VsUIHierarchyRootItemMock** pp)
	{
		VsUIHierarchyRootItemMock* pRootItem = NULL;
		HRESULT hRes = E_OUTOFMEMORY;
		ATLTRY(pRootItem = new VsUIHierarchyRootItemMock())
		if (pRootItem != NULL)
		{
			pRootItem->SetVoid(NULL);
			pRootItem->InternalFinalConstructAddRef();
			hRes = pRootItem->_AtlInitialConstruct();
			if (SUCCEEDED(hRes))
				hRes = pRootItem->FinalConstruct();
			if (SUCCEEDED(hRes))
				hRes = pRootItem->_AtlFinalConstruct();
			pRootItem->InternalFinalConstructRelease();
			if (hRes != S_OK)
			{
				delete pRootItem;
				pRootItem = NULL;
			}
		}
		VSL_CHECKHRESULT(hRes);
		*pp = pRootItem;
		return S_OK;
	}

	bool IsValidVSITEMID(_In_ VSITEMID itemid)
	{
		return (VSITEMID_SELECTION == itemid);
	}

	virtual IVsHierarchyEvents* GetIVsHierarchyEvents()
	{
		// Derived class needs to implement this properly
		VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);
		return NULL;
	}

	ItemInterface& GetItem(_In_ VSITEMID itemid)
	{
		VSL_CHECKBOOLEAN(IsValidVSITEMID(itemid), E_INVALIDARG);
		return *this;
	}

	virtual const GUID& GetGuidProperty(_In_ VSITEMID itemid, _In_ VSHPROPID propid) const
	{
		(itemid, propid);
		return CLSID_ManualResetEvent;
	}

	virtual void SetGuidProperty(_In_ VSITEMID itemid, _In_ VSHPROPID propid,	_In_ REFGUID rguid)
	{
		(itemid, propid, rguid);
		VSL_CHECKBOOLEAN(CLSID_SynchronizeContainer == rguid, E_FAIL);
	}

	virtual void GetProperty(_In_ VSITEMID itemid, _In_ VSHPROPID propid, _Out_ VARIANT* pVar) const
	{
		(itemid, propid);
		CComVariant var = E_UNEXPECTED;
		var.Detach(pVar);
	}

	virtual void SetProperty(_In_ VSITEMID itemid, _In_ VSHPROPID propid, _In_ VARIANT& rVar)
	{
		(itemid, propid);
		VSL_CHECKBOOLEAN(S_FALSE == rVar.lVal, E_FAIL);		
	}

	virtual ImageListWin32Control& GetIconImageList()
	{
		static ImageListWin32Control control;
		return control;
	}

	virtual HICON GetIconHandle() const
	{
		return NULL;
	}

	virtual HICON GetOpenFolderIconHandle() const
	{
		return GetIconHandle();
	}

	virtual bool IsExpanded() const
	{
		return false;
	}

	virtual void SetExpanded(bool bExpanded)
	{
		(bExpanded);
	}

	void Dispose()
	{
	}
};

class IVsUIHierarchyImplTest :
	public UnitTestBase,
	public IVsUIHierarchyImpl<IVsUIHierarchyImplTest, VsUIHierarchyRootItemMock, IVsHierarchyImpl<IVsUIHierarchyImplTest, VsUIHierarchyRootItemMock, IVsUIHierarchy> >
{
public:

VSL_DEFINE_IUNKNOWN_NOTIMPL

	IVsUIHierarchyImplTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		IVsHierarchy* pIVsHierarchy = static_cast<IVsHierarchy*>(static_cast<IVsHierarchyImpl*>(this));

		IServiceProviderMock mock;
		CComQIPtr<IServiceProvider> spIServiceProvider = mock.GetIUnknownNoAddRef();

		// IVsHierarchy methods
		UTCHK(S_OK == pIVsHierarchy->SetSite(spIServiceProvider));

		{
		CComPtr<IServiceProvider> spRetrieved;
		UTCHK(S_OK == pIVsHierarchy->GetSite(&spRetrieved));
		UTCHK(spRetrieved == spIServiceProvider);
		}

		{
		GUID guid;
		UTCHK(E_INVALIDARG == pIVsHierarchy->GetGuidProperty(VSITEMID_SELECTION, VSHPROPID_Name, NULL));
		UTCHK(E_INVALIDARG == pIVsHierarchy->GetGuidProperty(VSITEMID_SELECTION, VSHPROPID_NIL, &guid));
		UTCHK(E_INVALIDARG == pIVsHierarchy->GetGuidProperty(VSITEMID_SELECTION, VSHPROPID_LAST+1, &guid));
		UTCHK(E_INVALIDARG == pIVsHierarchy->GetGuidProperty(VSITEMID_SELECTION, VSHPROPID_FIRST2-1, &guid));
		UTCHK(S_OK == pIVsHierarchy->GetGuidProperty(VSITEMID_SELECTION, VSHPROPID_Name, &guid));
		UTCHK(guid == CLSID_ManualResetEvent);
		}

		{
		UTCHK(E_INVALIDARG == pIVsHierarchy->SetGuidProperty(VSITEMID_SELECTION, VSHPROPID_NIL, CLSID_SynchronizeContainer));
		UTCHK(E_INVALIDARG == pIVsHierarchy->SetGuidProperty(VSITEMID_SELECTION, VSHPROPID_LAST+1, CLSID_SynchronizeContainer));
		UTCHK(E_INVALIDARG == pIVsHierarchy->SetGuidProperty(VSITEMID_SELECTION, VSHPROPID_FIRST2-1, CLSID_SynchronizeContainer));
		UTCHK(S_OK == pIVsHierarchy->SetGuidProperty(VSITEMID_SELECTION, VSHPROPID_Name, CLSID_SynchronizeContainer));
		}

		{
		CComVariant var;
		UTCHK(E_INVALIDARG == pIVsHierarchy->GetProperty(VSITEMID_SELECTION, VSHPROPID_Name, NULL));
		UTCHK(E_INVALIDARG == pIVsHierarchy->GetProperty(VSITEMID_SELECTION, VSHPROPID_NIL, &var));
		UTCHK(E_INVALIDARG == pIVsHierarchy->GetProperty(VSITEMID_SELECTION, VSHPROPID_LAST+1, &var));
		UTCHK(E_INVALIDARG == pIVsHierarchy->GetProperty(VSITEMID_SELECTION, VSHPROPID_FIRST2-1, &var));
		UTCHK(S_OK == pIVsHierarchy->GetProperty(VSITEMID_SELECTION, VSHPROPID_Name, &var));
		UTCHK(var.lVal == E_UNEXPECTED);
		}

		{
		CComVariant var = S_FALSE;
		UTCHK(E_INVALIDARG == pIVsHierarchy->SetProperty(VSITEMID_SELECTION, VSHPROPID_NIL, var));
		UTCHK(E_INVALIDARG == pIVsHierarchy->SetProperty(VSITEMID_SELECTION, VSHPROPID_LAST+1, var));
		UTCHK(E_INVALIDARG == pIVsHierarchy->SetProperty(VSITEMID_SELECTION, VSHPROPID_FIRST2-1, var));
		UTCHK(S_OK == pIVsHierarchy->SetProperty(VSITEMID_SELECTION, VSHPROPID_Name, var));
		}

		{
		VSITEMID itemId;
		UTCHK(E_NOTIMPL == pIVsHierarchy->GetNestedHierarchy(VSITEMID_SELECTION, GUID_NULL, NULL, &itemId));
		}
		
#ifdef VSL_TEST_HIERARCHY_METHODS_CALLED
		{
		CComBSTR bstr;
		UTCHK(E_INVALIDARG == pIVsHierarchy->GetCanonicalName(VSITEMID_SELECTION, NULL));
		UTCHK(S_OK == pIVsHierarchy->GetCanonicalName(VSITEMID_SELECTION, &bstr));
		UTCHK(bstr == __WFILE__);
		}
#else // VSL_TEST_HIERARCHY_METHODS_CALLED
		{
		CComBSTR bstr;
		UTCHK(E_INVALIDARG == pIVsHierarchy->GetCanonicalName(VSITEMID_SELECTION, NULL));
		UTCHK(E_NOTIMPL == pIVsHierarchy->GetCanonicalName(VSITEMID_SELECTION, &bstr));
		}
#endif // VSL_TEST_HIERARCHY_METHODS_CALLED

#ifdef VSL_TEST_HIERARCHY_METHODS_CALLED
		{
		VSITEMID itemId;
		UTCHK(E_INVALIDARG == pIVsHierarchy->ParseCanonicalName(NULL, NULL));
		UTCHK(E_INVALIDARG == pIVsHierarchy->ParseCanonicalName(L"", &itemId));
		UTCHK(S_OK == pIVsHierarchy->ParseCanonicalName(__WFILE__, &itemId));
		UTCHK(itemId == VSITEMID_SELECTION);
		}
#else // VSL_TEST_HIERARCHY_METHODS_CALLED
		{
		VSITEMID itemId;
		UTCHK(E_INVALIDARG == pIVsHierarchy->ParseCanonicalName(NULL, NULL));
		UTCHK(E_INVALIDARG == pIVsHierarchy->ParseCanonicalName(L"", &itemId));
		UTCHK(E_NOTIMPL == pIVsHierarchy->ParseCanonicalName(__WFILE__, &itemId));
		}
#endif // VSL_TEST_HIERARCHY_METHODS_CALLED

		{
		IVsHierarchyEvents *pEventSink = reinterpret_cast<IVsHierarchyEvents *>(-1);
		VSCOOKIE cookie1;
		UTCHK(S_OK == pIVsHierarchy->AdviseHierarchyEvents(pEventSink, &cookie1));
		VSCOOKIE cookie2;
		UTCHK(S_OK == pIVsHierarchy->AdviseHierarchyEvents(pEventSink, &cookie2));
		VSCOOKIE cookie3;
		UTCHK(S_OK == pIVsHierarchy->AdviseHierarchyEvents(pEventSink, &cookie3));
		UTCHK(cookie1 != cookie2);
		UTCHK(cookie2 != cookie3);
		UTCHK(cookie1 != cookie3);
		UTCHK(S_OK == pIVsHierarchy->UnadviseHierarchyEvents(cookie1));
		UTCHK(S_OK == pIVsHierarchy->UnadviseHierarchyEvents(cookie2));
		UTCHK(S_OK == pIVsHierarchy->UnadviseHierarchyEvents(cookie3));
		}

		// IVsUIHierarchy methods
		IVsUIHierarchy* pIVsUIHierarchy = static_cast<IVsUIHierarchy*>(static_cast<IVsUIHierarchyImpl*>(this));

		// The mock starts with IOleCommandTarget not supported
		UTCHK(OLECMDERR_E_NOTSUPPORTED == pIVsUIHierarchy->QueryStatusCommand(VSITEMID_SELECTION, NULL, 0, NULL, NULL));
		UTCHK(WASCALLED(IOleCommandTarget, QueryStatus, 0));
		UTCHK(OLECMDERR_E_NOTSUPPORTED == pIVsUIHierarchy->ExecCommand(VSITEMID_SELECTION, NULL, 0, 0, NULL, NULL));
		UTCHK(WASCALLED(IOleCommandTarget, Exec, 0));

		// Now switch to the mock to support it.
		VsUIHierarchyRootItemMock::GetIOleCommandTargetReturnsNull() = false;

		// Have the mock method return S_FALSE to ensure that QueryStatusCommand is returning the
		// methods return value rather then it's default S_OK
		STARTVV(IOleCommandTarget, QueryStatus)
			NULL, 0, NULL, NULL, S_FALSE
		ENDVVPUSH()
		UTCHK(S_FALSE == pIVsUIHierarchy->QueryStatusCommand(VSITEMID_SELECTION, NULL, 0, NULL, NULL));
		UTCHK(WASCALLED(IOleCommandTarget, QueryStatus, 1));

		// ^Ditto
		STARTVV(IOleCommandTarget, Exec)
			NULL, 0, 0, NULL, NULL, S_FALSE
		ENDVVPUSH()
		UTCHK(S_FALSE == pIVsUIHierarchy->ExecCommand(VSITEMID_SELECTION, NULL, 0, 0, NULL, NULL));
		UTCHK(WASCALLED(IOleCommandTarget, Exec, 1));

		// Remainder of IVsHierarchy methods

		BOOL bCanClose = FALSE;
		UTCHK(S_OK == pIVsHierarchy->QueryClose(&bCanClose));
		UTCHK(bCanClose == TRUE);

		UTCHK(S_OK == pIVsHierarchy->Close());
	}
};

class HierarchyNodeStackNodesTest :
	public UnitTestBase
{
private:

	typedef HierarchyNodeTraits<unsigned int, unsigned int, HierarchyNodeTraitStackNodes> HierarchyNodeStackNodesTraits;
	typedef HierarchyNode<HierarchyNodeStackNodesTraits> Node;

	void TestNodeNotFound(unsigned int iItem, Node& rNode)
	{
		unsigned int itemNotFound = iItem;
		Node::FindInfo findInfo = {itemNotFound};
		UTCHK(false == rNode.FindIterator(findInfo));
		UTCHK(NULL == rNode.FindItemContainer(iItem));
	}

	void TestNotFound(Node& rNode)
	{
		TestNodeNotFound(0, rNode);
		TestNodeNotFound(2, rNode);
		TestNodeNotFound(312, rNode);
		TestNodeNotFound(9999999, rNode);
		TestNodeNotFound(0xFFFFFFFF, rNode);
	}

	void TestNodeFound(Node& rFindOn, Node& rToFind)
	{
		Node::FindInfo findInfo = {*rToFind};
		UTCHK(true == rFindOn.FindIterator(findInfo));
		UTCHK(&((*findInfo.rFound)->GetParent()->GetDescendantContainer()) == findInfo.pContainer);
		UTCHK(&rToFind == *(findInfo.rFound));
		UTCHK(*rToFind == *(rFindOn.FindItemContainer(*rToFind)));
	}

	void TestNodeIsNodeToFind(Node& rNode)
	{
		TestNotFound(rNode);
		Node::FindInfo findInfo = {*rNode};
		UTCHK(true == rNode.FindIterator(findInfo));
		UTCHK(NULL == findInfo.pContainer);
		UTCHK(*rNode == *(rNode.FindItemContainer(*rNode)));
	}

public:

	HierarchyNodeStackNodesTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{

		// Setup a hiearchy
		unsigned int item1 = 1;
		Node node1(NULL, item1);
			unsigned int item11 = 11;
			Node node11(&node1, item11);
				unsigned int item111 = 111;
				Node node111(&node11, item111);
				unsigned int item211 = 211;
				Node node211(&node11, item211);
					unsigned int item1211 = 1211;
					Node node1211(&node211, item1211);
				unsigned int item311 = 311;
				Node node311(&node11, item311);
			unsigned int item21 = 21;
			Node node21(&node1, item21);

		// Test that each node has the correct parent and item
		UTCHK(NULL == node1.GetParent());
		UTCHK(item1 == *node1);
			UTCHK(&node1 == node11.GetParent());
			UTCHK(item11 == *node11);
				UTCHK(&node11 == node111.GetParent());
				UTCHK(item111 == *node111);
				UTCHK(&node11 == node211.GetParent());
				UTCHK(item211 == *node211);
					UTCHK(&node211 == node1211.GetParent());
					UTCHK(item1211 == *node1211);
				UTCHK(&node11 == node311.GetParent());
				UTCHK(item311 == *node311);
			UTCHK(&node1 == node21.GetParent());
			UTCHK(item21 == *node21);

		// Test that each node has the correct descendants
		Node::DescendantContainer& rContainer1 = node1.GetDescendantContainer();
		Node::iterator i1 = rContainer1.begin();
		UTCHK(&node11 == *i1);
		UTCHK(item11 == ***i1);
			Node::DescendantContainer& rContainer11 = node11.GetDescendantContainer();
			Node::iterator i11 = rContainer11.begin();
			UTCHK(&node111 == *i11);
			UTCHK(item111 == ***i11);
			++i11;
			UTCHK(&node211 == *i11);
			UTCHK(item211 == ***i11);
				Node::DescendantContainer& rContainer211 = node211.GetDescendantContainer();
				Node::iterator i211 = rContainer211.begin();
				UTCHK(&node1211 == *i211);
				UTCHK(item1211 == ***i211);
			++i11;
			UTCHK(&node311 == *i11);
			UTCHK(item311 == ***i11);
		++i1;
		UTCHK(&node21 == *i1);
		UTCHK(item21 == ***i1);

		// Test find methods on node1
		TestNodeIsNodeToFind(node1);
			TestNodeFound(node1, node11);
				TestNodeFound(node1, node111);
				TestNodeFound(node1, node211);
					TestNodeFound(node1, node1211);
				TestNodeFound(node1, node311);
			TestNodeFound(node1, node21);

		// Test find methods on node11
		TestNodeIsNodeToFind(node11);
			TestNodeFound(node11, node111);
			TestNodeFound(node11, node211);
				TestNodeFound(node11, node1211);
			TestNodeFound(node11, node311);

		// Test find methods on node111
		TestNodeIsNodeToFind(node111);

		// Test find methods on node211
		TestNodeIsNodeToFind(node211);
			TestNodeFound(node211, node1211);

		// Test find methods on node1211
		TestNodeIsNodeToFind(node1211);

		// Test find methods on node311
		TestNodeIsNodeToFind(node311);

		// Test find methods on node21
		TestNodeIsNodeToFind(node21);
	}

};

class HierarchyNodeHeapNodesTest :
	public UnitTestBase
{
public:

	HierarchyNodeHeapNodesTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		typedef HierarchyNodeTraits<unsigned int, unsigned int, HierarchyNodeTraitHeapNodes> HierarchyNodeHeapNodesTraits;

		// Setup a hiearchy
		unsigned int item1 = 1;
		HierarchyNode<HierarchyNodeHeapNodesTraits> node1(item1);
		HierarchyNode<HierarchyNodeHeapNodesTraits>* pNode1 = &node1;
			unsigned int item11 = 11;
			HierarchyNode<HierarchyNodeHeapNodesTraits>* pNode11 = pNode1->AddDescendant(item11);
				unsigned int item111 = 111;
				HierarchyNode<HierarchyNodeHeapNodesTraits>* pNode111 = pNode11->AddDescendant(item111);
				unsigned int item211 = 211;
				HierarchyNode<HierarchyNodeHeapNodesTraits>* pNode211 = pNode11->AddDescendant(item211);
					unsigned int item1211 = 1211;
					HierarchyNode<HierarchyNodeHeapNodesTraits>* pNode1211 = pNode211->AddDescendant(item1211);
				unsigned int item311 = 311;
				HierarchyNode<HierarchyNodeHeapNodesTraits>* pNode311 = pNode11->AddDescendant(item311);
			unsigned int item21 = 21;
			HierarchyNode<HierarchyNodeHeapNodesTraits>* pNode21 = pNode1->AddDescendant(item21);

		// Test that each node has the correct parent and item
		UTCHK(NULL == pNode1->GetParent());
		UTCHK(item1 == **pNode1);
			UTCHK(pNode1 == pNode11->GetParent());
			UTCHK(item11 == **pNode11);
				UTCHK(pNode11 == pNode111->GetParent());
				UTCHK(item111 == **pNode111);
				UTCHK(pNode11 == pNode211->GetParent());
				UTCHK(item211 == **pNode211);
					UTCHK(pNode211 == pNode1211->GetParent());
					UTCHK(item1211 == **pNode1211);
				UTCHK(pNode11 == pNode311->GetParent());
				UTCHK(item311 == **pNode311);
			UTCHK(pNode1 == pNode21->GetParent());
			UTCHK(item21 == **pNode21);

		// Test that each node has the correct descendants
		HierarchyNode<HierarchyNodeHeapNodesTraits>::DescendantContainer& rContainer1 = pNode1->GetDescendantContainer();
		HierarchyNode<HierarchyNodeHeapNodesTraits>::iterator i1 = rContainer1.begin();
		UTCHK(pNode11 == *i1);
		UTCHK(item11 == ***i1);
			HierarchyNode<HierarchyNodeHeapNodesTraits>::DescendantContainer& rContainer11 = pNode11->GetDescendantContainer();
			HierarchyNode<HierarchyNodeHeapNodesTraits>::iterator i11 = rContainer11.begin();
			UTCHK(pNode111 == *i11);
			UTCHK(item111 == ***i11);
			++i11;
			UTCHK(pNode211 == *i11);
			UTCHK(item211 == ***i11);
				HierarchyNode<HierarchyNodeHeapNodesTraits>::DescendantContainer& rContainer211 = pNode211->GetDescendantContainer();
				HierarchyNode<HierarchyNodeHeapNodesTraits>::iterator i211 = rContainer211.begin();
				UTCHK(pNode1211 == *i211);
				UTCHK(item1211 == ***i211);
			++i11;
			UTCHK(pNode311 == *i11);
			UTCHK(item311 == ***i11);
		++i1;
		UTCHK(pNode21 == *i1);
		UTCHK(item21 == ***i1);
	}
};

class VsHierarchyRootItemBaseTest :
	public UnitTestBase
{
public:

	VsHierarchyRootItemBaseTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		typedef TestRoot HierarchyRoot;
		typedef TestItem<> HierarchyItem;

		HierarchyRoot root;
		HierarchyItem::Base& rRootBase = root;
		HierarchyItem item11(rRootBase);
		VSITEMID itemId11 = reinterpret_cast<VSITEMID>(static_cast<HierarchyItem::ItemInterface*>(&item11));
		HierarchyItem item21(rRootBase);
		VSITEMID itemId21 = reinterpret_cast<VSITEMID>(static_cast<HierarchyItem::ItemInterface*>(&item21));
		
		// Get VsHierarchyRootItemBase::GetItem
		HRESULT VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		UTCHK(static_cast<HierarchyRoot::ItemInterface*>(&root) == &root.GetItem(VSITEMID_NIL));

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_INVALIDARG);

		UTCHK(static_cast<HierarchyRoot::ItemInterface*>(&root) == &root.GetItem(VSITEMID_ROOT));
		UTCHK(static_cast<HierarchyRoot::ItemInterface*>(&root) == &root.GetItem(VSITEMID_SELECTION));
		UTCHK(static_cast<HierarchyRoot::ItemInterface*>(&item11) == &root.GetItem(itemId11));

		root.SetSelectionToItem(item11);

		UTCHK(static_cast<HierarchyRoot::ItemInterface*>(&root) == &root.GetItem(VSITEMID_ROOT));
		UTCHK(static_cast<HierarchyRoot::ItemInterface*>(&item11) == &root.GetItem(VSITEMID_SELECTION));
		UTCHK(static_cast<HierarchyRoot::ItemInterface*>(&item11) == &root.GetItem(itemId11));

		// Get VsHierarchyRootItemBase::GetGuidProperty
		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		root.GetGuidProperty(VSITEMID_ROOT, VSHPROPID_ProjectIDGuid);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_NOTIMPL);

		// Get VsHierarchyRootItemBase::SetGuidProperty
		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		root.SetGuidProperty(VSITEMID_ROOT, VSHPROPID_Name, CLSID_SynchronizeContainer);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_UNEXPECTED);

		// Get VsHierarchyRootItemBase::GetProperty - VSHPROPID_Root
		{
		CComVariant var;
		root.GetProperty(VSITEMID_ROOT, VSHPROPID_Root, &var);
		UTCHK(static_cast<VSITEMID>(var.intVal) == VSITEMID_ROOT);
		}

		// Get VsHierarchyRootItemBase::GetProperty - VSHPROPID_NextSibling
		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		CComVariant var;
		root.GetProperty(VSITEMID_ROOT, VSHPROPID_NextSibling, &var);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_INVALIDARG);

		root.SetSelectionToItem(root);

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		CComVariant var;
		root.GetProperty(VSITEMID_SELECTION, VSHPROPID_NextSibling, &var);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_INVALIDARG);

		root.SetSelectionToItem(item11);

		{
		CComVariant var;
		root.GetProperty(VSITEMID_SELECTION, VSHPROPID_NextSibling, &var);
		UTCHK(static_cast<VSITEMID>(var.intVal) == itemId21);
		}

		{
		CComVariant var;
		root.GetProperty(itemId11, VSHPROPID_NextSibling, &var);
		UTCHK(static_cast<VSITEMID>(var.intVal) == itemId21);
		}

		// Get VsHierarchyRootItemBase::GetProperty - VSHPROPID_NextVisibleSibling
		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		CComVariant var;
		root.GetProperty(VSITEMID_ROOT, VSHPROPID_NextVisibleSibling, &var);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_INVALIDARG);

		root.SetSelectionToItem(root);

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		CComVariant var;
		root.GetProperty(VSITEMID_SELECTION, VSHPROPID_NextVisibleSibling, &var);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_INVALIDARG);

		root.SetSelectionToItem(item11);

		{
		CComVariant var;
		root.GetProperty(VSITEMID_SELECTION, VSHPROPID_NextVisibleSibling, &var);
		UTCHK(static_cast<VSITEMID>(var.intVal) == itemId21);
		}

		{
		CComVariant var;
		root.GetProperty(itemId11, VSHPROPID_NextVisibleSibling, &var);
		UTCHK(static_cast<VSITEMID>(var.intVal) == itemId21);
		}

		// Get VsHierarchyRootItemBase::GetProperty - VSHPROPID_IconImgList
		{
		CComVariant var;
		root.GetProperty(itemId11, VSHPROPID_IconImgList, &var);
		UTCHK(static_cast<VSITEMID>(var.intVal) != NULL);
		}

		// Get VsHierarchyRootItemBase::SetProperty
		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		CComVariant var = S_FALSE;
		root.SetProperty(VSITEMID_ROOT, VSHPROPID_Name, var);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_NOTIMPL);
	}
};

class VsHierarchyItemBaseTest :
	public UnitTestBase
{
public:

	typedef TestRoot HierarchyRoot;
	typedef TestItem<> HierarchyItem;

	void TestGetGuidPropertyFailed(HierarchyItem& rItem, VSHPROPID propid, HRESULT hr)
	{
		HRESULT VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		rItem.GetGuidProperty(propid);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == hr);
	}

	void TestSetGuidPropertyFailed(HierarchyItem& rItem, VSHPROPID propid, HRESULT hr)
	{
		HRESULT VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		rItem.SetGuidProperty(propid, GUID_NULL);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == hr);
	}

	void TestGetPropertyFailed(HierarchyItem& rItem, VSHPROPID propid, HRESULT hr)
	{
		HRESULT VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		CComVariant var;
		rItem.GetProperty(propid, &var);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == hr);
	}

	void TestSetPropertyFailed(HierarchyItem& rItem, VSHPROPID propid, HRESULT hr)
	{
		HRESULT VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		CComVariant var;
		rItem.SetProperty(propid, var);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == hr);
	}
	VsHierarchyItemBaseTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{

		HierarchyRoot root;
		HierarchyItem::Base& rRootBase = root;
		HierarchyItem& item1 = root; 
		HierarchyItem item11(rRootBase);
		HierarchyItem::Base& ritem11Base = item11;
		VSITEMID itemId11 = reinterpret_cast<VSITEMID>(static_cast<HierarchyItem::ItemInterface*>(&item11));
		HierarchyItem item211(ritem11Base);
		VSITEMID itemId211 = reinterpret_cast<VSITEMID>(static_cast<HierarchyItem::ItemInterface*>(&item211));

// VsHierarchyItemBase::GetGuidProperty

		// VsHierarchyItemBase::GetGuidProperty - VSHPROPID_Parent
		TestGetGuidPropertyFailed(item1, VSHPROPID_Parent, E_UNEXPECTED);

		// VsHierarchyItemBase::GetGuidProperty - VSHPROPID_TypeGuid
#ifdef VSL_TEST_HIERARCHY_METHODS_CALLED
		UTCHK(CLSID_ManualResetEvent == item1.GetGuidProperty(VSHPROPID_TypeGuid));
#else // VSL_TEST_HIERARCHY_METHODS_CALLED
		TestGetGuidPropertyFailed(item1, VSHPROPID_TypeGuid, E_NOTIMPL);
#endif // VSL_TEST_HIERARCHY_METHODS_CALLED

		// VsHierarchyItemBase::GetGuidProperty - VSHPROPID_SaveName
		TestGetGuidPropertyFailed(item1, VSHPROPID_SaveName, E_UNEXPECTED);

		// VsHierarchyItemBase::GetGuidProperty - VSHPROPID_CmdUIGuid
		UTCHK(CLSID_StdEvent == item1.GetGuidProperty(VSHPROPID_CmdUIGuid));

		// VsHierarchyItemBase::GetGuidProperty - VSHPROPID_SelContainer
		TestGetGuidPropertyFailed(item1, VSHPROPID_SelContainer, E_UNEXPECTED);

		// VsHierarchyItemBase::GetGuidProperty - VSHPROPID_PreferredLanguageSID
		TestGetGuidPropertyFailed(item1, VSHPROPID_PreferredLanguageSID, E_NOTIMPL);
		
		// VsHierarchyItemBase::GetGuidProperty - VSHPROPID_ShowProjInSolutionPage
		TestGetGuidPropertyFailed(item1, VSHPROPID_ShowProjInSolutionPage, E_UNEXPECTED);

		// VsHierarchyItemBase::GetGuidProperty - VSHPROPID_ProjectIDGuid
		TestGetGuidPropertyFailed(item1, VSHPROPID_ProjectIDGuid, E_NOTIMPL);
		
		// VsHierarchyItemBase::GetGuidProperty - VSHPROPID_DesignerVariableNaming
		TestGetGuidPropertyFailed(item1, VSHPROPID_DesignerVariableNaming, E_UNEXPECTED);

// VsHierarchyItemBase::SetGuidProperty

		// VsHierarchyItemBase::SetGuidProperty - VSHPROPID_Parent
		TestSetGuidPropertyFailed(item1, VSHPROPID_Parent, E_UNEXPECTED);

		// VsHierarchyItemBase::SetGuidProperty - VSHPROPID_TypeGuid
		TestSetGuidPropertyFailed(item1, VSHPROPID_TypeGuid, E_NOTIMPL);

		// VsHierarchyItemBase::SetGuidProperty - VSHPROPID_SaveName
		TestSetGuidPropertyFailed(item1, VSHPROPID_SaveName, E_UNEXPECTED);

		// VsHierarchyItemBase::SetGuidProperty - VSHPROPID_CmdUIGuid
		TestSetGuidPropertyFailed(item1, VSHPROPID_CmdUIGuid, E_NOTIMPL);

		// VsHierarchyItemBase::SetGuidProperty - VSHPROPID_SelContainer
		TestSetGuidPropertyFailed(item1, VSHPROPID_SelContainer, E_UNEXPECTED);

		// VsHierarchyItemBase::SetGuidProperty - VSHPROPID_PreferredLanguageSID
		TestSetGuidPropertyFailed(item1, VSHPROPID_PreferredLanguageSID, E_NOTIMPL);
		
		// VsHierarchyItemBase::SetGuidProperty - VSHPROPID_ShowProjInSolutionPage
		TestSetGuidPropertyFailed(item1, VSHPROPID_ShowProjInSolutionPage, E_UNEXPECTED);

		// VsHierarchyItemBase::SetGuidProperty - VSHPROPID_ProjectIDGuid
		TestSetGuidPropertyFailed(item1, VSHPROPID_ProjectIDGuid, E_NOTIMPL);
		
		// VsHierarchyItemBase::SetGuidProperty - VSHPROPID_DesignerVariableNaming
		TestSetGuidPropertyFailed(item1, VSHPROPID_DesignerVariableNaming, E_UNEXPECTED);

// VsHierarchyItemBase::GetProperty

		// VsHierarchyItemBase::GetProperty - VSHPROPID_Parent
		{
		CComVariant var;
		item11.GetProperty(VSHPROPID_Parent, &var);
		UTCHK(static_cast<VSITEMID>(var.intVal) == VSITEMID_ROOT);
		}

		{
		CComVariant var;
		item211.GetProperty(VSHPROPID_Parent, &var);
		UTCHK(static_cast<VSITEMID>(var.intVal) == itemId11);
		}

		// VsHierarchyItemBase::GetProperty - VSHPROPID_FirstChild
		{
		CComVariant var;
		item1.GetProperty(VSHPROPID_FirstChild, &var);
		UTCHK(static_cast<VSITEMID>(var.intVal) == itemId11);
		}

		{
		CComVariant var;
		item11.GetProperty(VSHPROPID_FirstChild, &var);
		UTCHK(static_cast<VSITEMID>(var.intVal) == itemId211);
		}
		
		// VsHierarchyItemBase::GetProperty - VSHPROPID_TypeGuid
		TestGetPropertyFailed(item1, VSHPROPID_TypeGuid, E_UNEXPECTED);
		
		// VsHierarchyItemBase::GetProperty - VSHPROPID_SaveName
		TestGetPropertyFailed(item1, VSHPROPID_SaveName, E_NOTIMPL);
		
		// VsHierarchyItemBase::GetProperty - VSHPROPID_Caption
		{
		CComVariant var;
		item1.GetProperty(VSHPROPID_Caption, &var);
		UTCHK(CComBSTR(__WFILE__) == var.bstrVal);
		}

		// VsHierarchyItemBase::GetProperty - VSHPROPID_IconImgList
		TestGetPropertyFailed(item1, VSHPROPID_IconImgList, E_UNEXPECTED);

		// VsHierarchyItemBase::GetProperty - VSHPROPID_IconIndex
		TestGetPropertyFailed(item1, VSHPROPID_IconIndex, DISP_E_MEMBERNOTFOUND);

		// VsHierarchyItemBase::GetProperty - VSHPROPID_Expandable
		{
		CComVariant var;
		item1.GetProperty(VSHPROPID_Expandable, &var);
		UTCHK(var.boolVal == VARIANT_TRUE);
		}

		{
		CComVariant var;
		item11.GetProperty(VSHPROPID_Expandable, &var);
		UTCHK(var.boolVal == VARIANT_TRUE);
		}

		{
		CComVariant var;
		item211.GetProperty(VSHPROPID_Expandable, &var);
		UTCHK(var.boolVal == VARIANT_FALSE);
		}

		// VsHierarchyItemBase::GetProperty - VSHPROPID_ExpandByDefault
		{
		CComVariant var;
		item1.GetProperty(VSHPROPID_ExpandByDefault, &var);
		UTCHK(var.boolVal == VARIANT_TRUE);
		}

		{
		CComVariant var;
		item11.GetProperty(VSHPROPID_ExpandByDefault, &var);
		UTCHK(var.boolVal == VARIANT_FALSE);
		}

		{
		CComVariant var;
		item211.GetProperty(VSHPROPID_ExpandByDefault, &var);
		UTCHK(var.boolVal == VARIANT_FALSE);
		}

		// VsHierarchyItemBase::GetProperty - VSHPROPID_Name
#ifdef VSL_TEST_HIERARCHY_METHODS_CALLED
		{
		CComVariant var;
		item1.GetProperty(VSHPROPID_Name, &var);
		UTCHK(CComBSTR(__WFILE__) == var.bstrVal);
		}
#else // VSL_TEST_HIERARCHY_METHODS_CALLED
		TestGetPropertyFailed(item1, VSHPROPID_Name, E_NOTIMPL);
#endif // VSL_TEST_HIERARCHY_METHODS_CALLED

		// VsHierarchyItemBase::GetProperty - VSHPROPID_IconHandle
		TestGetPropertyFailed(item1, VSHPROPID_IconHandle, DISP_E_MEMBERNOTFOUND);

		// VsHierarchyItemBase::GetProperty - VSHPROPID_OpenFolderIconHandle
		TestGetPropertyFailed(item1, VSHPROPID_OpenFolderIconHandle, DISP_E_MEMBERNOTFOUND);

		// VsHierarchyItemBase::GetProperty - VSHPROPID_CmdUIGuid
		TestGetPropertyFailed(item1, VSHPROPID_CmdUIGuid, E_UNEXPECTED);

		// VsHierarchyItemBase::GetProperty - VSHPROPID_SelContainer
		TestGetPropertyFailed(item1, VSHPROPID_SelContainer, E_NOTIMPL);

		// VsHierarchyItemBase::GetProperty - VSHPROPID_BrowseObject
		TestGetPropertyFailed(item1, VSHPROPID_BrowseObject, E_NOTIMPL);

		// VsHierarchyItemBase::GetProperty - VSHPROPID_UserContext
		TestGetPropertyFailed(item1, VSHPROPID_UserContext, E_NOTIMPL);

		// VsHierarchyItemBase::GetProperty - VSHPROPID_EditLabel
#ifdef VSL_TEST_HIERARCHY_METHODS_CALLED
		{
		CComVariant var;
		item1.GetProperty(VSHPROPID_EditLabel, &var);
		UTCHK(CComBSTR(__WFILE__) == var.bstrVal);
		}
#else // VSL_TEST_HIERARCHY_METHODS_CALLED
		TestGetPropertyFailed(item1, VSHPROPID_EditLabel, E_NOTIMPL);
#endif // VSL_TEST_HIERARCHY_METHODS_CALLED
		
		// VsHierarchyItemBase::GetProperty - VSHPROPID_ExtObject
		TestGetPropertyFailed(item1, VSHPROPID_ExtObject, E_NOTIMPL);
		
		// VsHierarchyItemBase::GetProperty - VSHPROPID_ExtSelectedItem
		TestGetPropertyFailed(item1, VSHPROPID_ExtSelectedItem, E_NOTIMPL);

		// VsHierarchyItemBase::GetProperty - VSHPROPID_FirstVisibleChild
		{
		CComVariant var;
		item1.GetProperty(VSHPROPID_FirstVisibleChild, &var);
		UTCHK(static_cast<VSITEMID>(var.intVal) == itemId11);
		}

		{
		CComVariant var;
		item11.GetProperty(VSHPROPID_FirstVisibleChild, &var);
		UTCHK(static_cast<VSITEMID>(var.intVal) == itemId211);
		}

		// VsHierarchyItemBase::GetProperty - VSHPROPID_IsHiddenItem
		{
		CComVariant var;
		item11.GetProperty(VSHPROPID_IsHiddenItem, &var);
		UTCHK(var.boolVal == VARIANT_FALSE);
		}
		
		// VsHierarchyItemBase::GetProperty - VSHPROPID_IsNonMemberItem
		TestGetPropertyFailed(item1, VSHPROPID_IsNonMemberItem, E_NOTIMPL);

		// VsHierarchyItemBase::GetProperty - VSHPROPID_PreferredLanguageSID
		TestGetPropertyFailed(item1, VSHPROPID_PreferredLanguageSID, E_UNEXPECTED);

		// VsHierarchyItemBase::GetProperty - VSHPROPID_ShowProjInSolutionPage
		TestGetPropertyFailed(item1, VSHPROPID_ShowProjInSolutionPage, E_NOTIMPL);

		// VsHierarchyItemBase::GetProperty - VSHPROPID_ProjectIDGuid
		TestGetPropertyFailed(item1, VSHPROPID_ProjectIDGuid, E_UNEXPECTED);

		// VsHierarchyItemBase::GetProperty - VSHPROPID_DesignerVariableNaming
		TestGetPropertyFailed(item1, VSHPROPID_DesignerVariableNaming, E_NOTIMPL);

// VsHierarchyItemBase::SetProperty

		// VsHierarchyItemBase::SetProperty - VSHPROPID_Parent
		TestSetPropertyFailed(item1, VSHPROPID_Parent, E_NOTIMPL);

		// VsHierarchyItemBase::SetProperty - VSHPROPID_TypeGuid
		TestSetPropertyFailed(item1, VSHPROPID_TypeGuid, E_UNEXPECTED);

		// VsHierarchyItemBase::SetProperty - VSHPROPID_SaveName
		TestSetPropertyFailed(item1, VSHPROPID_SaveName, E_NOTIMPL);

		// VsHierarchyItemBase::SetProperty - VSHPROPID_CmdUIGuid
		TestSetPropertyFailed(item1, VSHPROPID_CmdUIGuid, E_UNEXPECTED);

		// VsHierarchyItemBase::SetProperty - VSHPROPID_SelContainer
		TestSetPropertyFailed(item1, VSHPROPID_SelContainer, E_NOTIMPL);

		// VsHierarchyItemBase::SetProperty - VSHPROPID_EditLabel
#ifdef VSL_TEST_HIERARCHY_METHODS_CALLED
		{
		CComVariant var(__WFILE__);
		item1.SetProperty(VSHPROPID_EditLabel, var);
		}
#else // VSL_TEST_HIERARCHY_METHODS_CALLED
		TestSetPropertyFailed(item1, VSHPROPID_EditLabel, E_NOTIMPL);
#endif // VSL_TEST_HIERARCHY_METHODS_CALLED

		// VsHierarchyItemBase::SetProperty - VSHPROPID_ExtObject
		TestSetPropertyFailed(item1, VSHPROPID_ExtObject, E_NOTIMPL);

		// VsHierarchyItemBase::SetProperty - VSHPROPID_PreferredLanguageSID
		TestSetPropertyFailed(item1, VSHPROPID_PreferredLanguageSID, E_UNEXPECTED);

		// VsHierarchyItemBase::SetProperty - VSHPROPID_ShowProjInSolutionPage
		TestSetPropertyFailed(item1, VSHPROPID_ShowProjInSolutionPage, E_NOTIMPL);

		// VsHierarchyItemBase::SetProperty - VSHPROPID_ProjectIDGuid
		TestSetPropertyFailed(item1, VSHPROPID_ProjectIDGuid, E_UNEXPECTED);

		// VsHierarchyItemBase::SetProperty - VSHPROPID_DesignerVariableNaming
		TestSetPropertyFailed(item1, VSHPROPID_DesignerVariableNaming, E_NOTIMPL);
	}
};

int _cdecl _tmain()
{
	UTRUN(IVsUIHierarchyImplTest);
	UTRUN(HierarchyNodeStackNodesTest);
	UTRUN(HierarchyNodeHeapNodesTest);
	UTRUN(VsHierarchyRootItemBaseTest);
	UTRUN(VsHierarchyItemBaseTest);
	return VSL::FailureCounter::Get();
}

