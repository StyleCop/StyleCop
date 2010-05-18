/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROFILESETTINGSTREE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROFILESETTINGSTREE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsProfileSettingsTreeNotImpl :
	public IVsProfileSettingsTree
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProfileSettingsTreeNotImpl)

public:

	typedef IVsProfileSettingsTree Interface;

	STDMETHOD(GetChildCount)(
		/*[out]*/ int* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetChild)(
		/*[in]*/ int /*index*/,
		/*[out]*/ IVsProfileSettingsTree** /*ppChildTree*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEnabledChildCount)(
		/*[out]*/ int* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDisplayName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDescription)(
		/*[out]*/ BSTR* /*pbstrDescription*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCategory)(
		/*[out]*/ BSTR* /*pbstrCategory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRegisteredName)(
		/*[out]*/ BSTR* /*pbstrRegisteredName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNameForID)(
		/*[out]*/ BSTR* /*pbstrNameForID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFullPath)(
		/*[out]*/ BSTR* /*pbstrFullPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPackage)(
		/*[out]*/ BSTR* /*pbstrPackage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetIsAutomationPropBased)(
		/*[out]*/ BOOL* /*pfAutoProp*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEnabled)(
		/*[out]*/ BOOL* /*pfEnabled*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetEnabled)(
		/*[in]*/ BOOL /*fEnabled*/,
		/*[in]*/ BOOL /*fIncludeChildren*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetVisible)(
		/*[out]*/ BOOL* /*pfVisible*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAlternatePath)(
		/*[out]*/ BSTR* /*pbstrAlternatePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetIsPlaceholder)(
		/*[out]*/ BOOL* /*pfPlaceholder*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRepresentedNode)(
		/*[out]*/ IVsProfileSettingsTree** /*ppRepresentedNode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSecurityLevel)(
		/*[out]*/ VSPROFILECATEGORYSECURITY* /*pSecurityLevel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSensitivityLevel)(
		/*[out]*/ VSPROFILECATEGORYSENSITIVITY* /*pSensitivityLevel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindChildTree)(
		/*[in]*/ BSTR /*bstrNameSearch*/,
		/*[out]*/ IVsProfileSettingsTree** /*ppChildTree*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddChildTree)(
		/*[in]*/ IVsProfileSettingsTree* /*pChildTree*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RevisePlacements)(
		/*[in]*/ IVsProfileSettingsTree* /*pTreeRoot*/,
		/*[in]*/ IVsProfileSettingsTree* /*pTreeRootBasis*/,
		/*[in]*/ BSTR /*bstrCurrentParent*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProfileSettingsTreeMockImpl :
	public IVsProfileSettingsTree,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProfileSettingsTreeMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProfileSettingsTreeMockImpl)

	typedef IVsProfileSettingsTree Interface;
	struct GetChildCountValidValues
	{
		/*[out]*/ int* pCount;
		HRESULT retValue;
	};

	STDMETHOD(GetChildCount)(
		/*[out]*/ int* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetChildCount)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetChildValidValues
	{
		/*[in]*/ int index;
		/*[out]*/ IVsProfileSettingsTree** ppChildTree;
		HRESULT retValue;
	};

	STDMETHOD(GetChild)(
		/*[in]*/ int index,
		/*[out]*/ IVsProfileSettingsTree** ppChildTree)
	{
		VSL_DEFINE_MOCK_METHOD(GetChild)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE_INTERFACE(ppChildTree);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEnabledChildCountValidValues
	{
		/*[out]*/ int* pCount;
		HRESULT retValue;
	};

	STDMETHOD(GetEnabledChildCount)(
		/*[out]*/ int* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetEnabledChildCount)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDisplayNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetDisplayName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetDisplayName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDescriptionValidValues
	{
		/*[out]*/ BSTR* pbstrDescription;
		HRESULT retValue;
	};

	STDMETHOD(GetDescription)(
		/*[out]*/ BSTR* pbstrDescription)
	{
		VSL_DEFINE_MOCK_METHOD(GetDescription)

		VSL_SET_VALIDVALUE_BSTR(pbstrDescription);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCategoryValidValues
	{
		/*[out]*/ BSTR* pbstrCategory;
		HRESULT retValue;
	};

	STDMETHOD(GetCategory)(
		/*[out]*/ BSTR* pbstrCategory)
	{
		VSL_DEFINE_MOCK_METHOD(GetCategory)

		VSL_SET_VALIDVALUE_BSTR(pbstrCategory);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRegisteredNameValidValues
	{
		/*[out]*/ BSTR* pbstrRegisteredName;
		HRESULT retValue;
	};

	STDMETHOD(GetRegisteredName)(
		/*[out]*/ BSTR* pbstrRegisteredName)
	{
		VSL_DEFINE_MOCK_METHOD(GetRegisteredName)

		VSL_SET_VALIDVALUE_BSTR(pbstrRegisteredName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNameForIDValidValues
	{
		/*[out]*/ BSTR* pbstrNameForID;
		HRESULT retValue;
	};

	STDMETHOD(GetNameForID)(
		/*[out]*/ BSTR* pbstrNameForID)
	{
		VSL_DEFINE_MOCK_METHOD(GetNameForID)

		VSL_SET_VALIDVALUE_BSTR(pbstrNameForID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFullPathValidValues
	{
		/*[out]*/ BSTR* pbstrFullPath;
		HRESULT retValue;
	};

	STDMETHOD(GetFullPath)(
		/*[out]*/ BSTR* pbstrFullPath)
	{
		VSL_DEFINE_MOCK_METHOD(GetFullPath)

		VSL_SET_VALIDVALUE_BSTR(pbstrFullPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPackageValidValues
	{
		/*[out]*/ BSTR* pbstrPackage;
		HRESULT retValue;
	};

	STDMETHOD(GetPackage)(
		/*[out]*/ BSTR* pbstrPackage)
	{
		VSL_DEFINE_MOCK_METHOD(GetPackage)

		VSL_SET_VALIDVALUE_BSTR(pbstrPackage);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetIsAutomationPropBasedValidValues
	{
		/*[out]*/ BOOL* pfAutoProp;
		HRESULT retValue;
	};

	STDMETHOD(GetIsAutomationPropBased)(
		/*[out]*/ BOOL* pfAutoProp)
	{
		VSL_DEFINE_MOCK_METHOD(GetIsAutomationPropBased)

		VSL_SET_VALIDVALUE(pfAutoProp);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEnabledValidValues
	{
		/*[out]*/ BOOL* pfEnabled;
		HRESULT retValue;
	};

	STDMETHOD(GetEnabled)(
		/*[out]*/ BOOL* pfEnabled)
	{
		VSL_DEFINE_MOCK_METHOD(GetEnabled)

		VSL_SET_VALIDVALUE(pfEnabled);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetEnabledValidValues
	{
		/*[in]*/ BOOL fEnabled;
		/*[in]*/ BOOL fIncludeChildren;
		HRESULT retValue;
	};

	STDMETHOD(SetEnabled)(
		/*[in]*/ BOOL fEnabled,
		/*[in]*/ BOOL fIncludeChildren)
	{
		VSL_DEFINE_MOCK_METHOD(SetEnabled)

		VSL_CHECK_VALIDVALUE(fEnabled);

		VSL_CHECK_VALIDVALUE(fIncludeChildren);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetVisibleValidValues
	{
		/*[out]*/ BOOL* pfVisible;
		HRESULT retValue;
	};

	STDMETHOD(GetVisible)(
		/*[out]*/ BOOL* pfVisible)
	{
		VSL_DEFINE_MOCK_METHOD(GetVisible)

		VSL_SET_VALIDVALUE(pfVisible);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAlternatePathValidValues
	{
		/*[out]*/ BSTR* pbstrAlternatePath;
		HRESULT retValue;
	};

	STDMETHOD(GetAlternatePath)(
		/*[out]*/ BSTR* pbstrAlternatePath)
	{
		VSL_DEFINE_MOCK_METHOD(GetAlternatePath)

		VSL_SET_VALIDVALUE_BSTR(pbstrAlternatePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetIsPlaceholderValidValues
	{
		/*[out]*/ BOOL* pfPlaceholder;
		HRESULT retValue;
	};

	STDMETHOD(GetIsPlaceholder)(
		/*[out]*/ BOOL* pfPlaceholder)
	{
		VSL_DEFINE_MOCK_METHOD(GetIsPlaceholder)

		VSL_SET_VALIDVALUE(pfPlaceholder);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRepresentedNodeValidValues
	{
		/*[out]*/ IVsProfileSettingsTree** ppRepresentedNode;
		HRESULT retValue;
	};

	STDMETHOD(GetRepresentedNode)(
		/*[out]*/ IVsProfileSettingsTree** ppRepresentedNode)
	{
		VSL_DEFINE_MOCK_METHOD(GetRepresentedNode)

		VSL_SET_VALIDVALUE_INTERFACE(ppRepresentedNode);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSecurityLevelValidValues
	{
		/*[out]*/ VSPROFILECATEGORYSECURITY* pSecurityLevel;
		HRESULT retValue;
	};

	STDMETHOD(GetSecurityLevel)(
		/*[out]*/ VSPROFILECATEGORYSECURITY* pSecurityLevel)
	{
		VSL_DEFINE_MOCK_METHOD(GetSecurityLevel)

		VSL_SET_VALIDVALUE(pSecurityLevel);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSensitivityLevelValidValues
	{
		/*[out]*/ VSPROFILECATEGORYSENSITIVITY* pSensitivityLevel;
		HRESULT retValue;
	};

	STDMETHOD(GetSensitivityLevel)(
		/*[out]*/ VSPROFILECATEGORYSENSITIVITY* pSensitivityLevel)
	{
		VSL_DEFINE_MOCK_METHOD(GetSensitivityLevel)

		VSL_SET_VALIDVALUE(pSensitivityLevel);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindChildTreeValidValues
	{
		/*[in]*/ BSTR bstrNameSearch;
		/*[out]*/ IVsProfileSettingsTree** ppChildTree;
		HRESULT retValue;
	};

	STDMETHOD(FindChildTree)(
		/*[in]*/ BSTR bstrNameSearch,
		/*[out]*/ IVsProfileSettingsTree** ppChildTree)
	{
		VSL_DEFINE_MOCK_METHOD(FindChildTree)

		VSL_CHECK_VALIDVALUE_BSTR(bstrNameSearch);

		VSL_SET_VALIDVALUE_INTERFACE(ppChildTree);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddChildTreeValidValues
	{
		/*[in]*/ IVsProfileSettingsTree* pChildTree;
		HRESULT retValue;
	};

	STDMETHOD(AddChildTree)(
		/*[in]*/ IVsProfileSettingsTree* pChildTree)
	{
		VSL_DEFINE_MOCK_METHOD(AddChildTree)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pChildTree);

		VSL_RETURN_VALIDVALUES();
	}
	struct RevisePlacementsValidValues
	{
		/*[in]*/ IVsProfileSettingsTree* pTreeRoot;
		/*[in]*/ IVsProfileSettingsTree* pTreeRootBasis;
		/*[in]*/ BSTR bstrCurrentParent;
		HRESULT retValue;
	};

	STDMETHOD(RevisePlacements)(
		/*[in]*/ IVsProfileSettingsTree* pTreeRoot,
		/*[in]*/ IVsProfileSettingsTree* pTreeRootBasis,
		/*[in]*/ BSTR bstrCurrentParent)
	{
		VSL_DEFINE_MOCK_METHOD(RevisePlacements)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTreeRoot);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTreeRootBasis);

		VSL_CHECK_VALIDVALUE_BSTR(bstrCurrentParent);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROFILESETTINGSTREE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
