/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLHIERARCHYNODE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLHIERARCHYNODE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

// VSL includes
#include <VSL.h>
#include <VSLErrorHandlers.h>
#include <VSLExceptionHandlers.h>

// STL includes
#ifndef VSL_HIERARCHYNODE_DECENDANT_CONTAINER
#include <list>
#define VSL_HIERARCHYNODE_DECENDANT_CONTAINER std::list
#endif

namespace VSL
{

class HierarchyNodeTraitHeapNodes
{
	enum {
		NodesOnHeap
	};
};

class HierarchyNodeTraitStackNodes
{
	enum {
		NodesOnStack
	};
};

// If ItemContainer_T is specified then it must be of type that has contructor acceptiong an Item_T&
// Additionally ItemContainer_T address of operator must return an ItemContainer_T* not an Item_T*
template <
	class Item_T,
	class ItemContainer_T = Item_T,
	class HeapNodes_T = HierarchyNodeTraitHeapNodes>
class HierarchyNodeTraits
{
public:
	typedef Item_T Item;
	typedef ItemContainer_T ItemContainer;
	typedef HeapNodes_T HeapNodes;
};

template <class Traits_T>
class HierarchyNode
{

VSL_DECLARE_NOT_COPYABLE_OR_DEFAULT_CONSTRUCTABLE(HierarchyNode)

public:

	typedef typename Traits_T::Item Item;
	typedef typename Traits_T::ItemContainer ItemContainer;
	typedef VSL_HIERARCHYNODE_DECENDANT_CONTAINER<HierarchyNode*> DescendantContainer;
	typedef typename DescendantContainer::iterator iterator;

	HierarchyNode(const Item& rItem):
		m_pParent(NULL),
		m_Item(rItem)
	{
	}

__if_exists(Traits_T::HeapNodes::NodesOnHeap)
{
private:
}

	HierarchyNode(_In_opt_ HierarchyNode* pParent, _In_ const Item& rItem):
		m_pParent(pParent),
		m_Item(rItem)
	{
		DescendFromParent();
	}

public:

	~HierarchyNode()
	{
	__if_exists(Traits_T::HeapNodes::NodesOnHeap)
	{
		for(iterator i = m_DescendantContainer.begin(); i != m_DescendantContainer.end(); ++i)
		{
			delete *i;
		}
	}
	}

	HierarchyNode* GetParent()
	{
		return m_pParent;
	}

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512)  // assignment operator could not be generated
	struct FindInfo
	{
		const Item& rItemKey;
		DescendantContainer* pContainer;
		iterator rFound;
	};
#pragma warning(pop)

	/*
	If the item matching rFindInfo.rItemKey is the current node, then the method returns true and
	rFindInfo.pContainer will be NULL and rFound will have been assigned to.  The item can be retrieved
	via by dereferencing the node FindIterator was called on.
	
	If the item is found on a descendant, then the method returns true and rFindInfo.pContainer 
	will be set to point to the container the item's node is contained in, rFound will be set to a 
	valid iterator pointing to the item in the container.

	If no item is found the method returns false.
	*/
	bool FindIterator(_Inout_ FindInfo& rFindInfo)
	{
		if(rFindInfo.rItemKey == m_Item)
		{
			rFindInfo.pContainer = NULL;
			return true;
		}

		for(iterator i = m_DescendantContainer.begin(); i != m_DescendantContainer.end(); ++i)
		{
			if(rFindInfo.rItemKey == ***i)
			{
				rFindInfo.pContainer = &m_DescendantContainer;
				rFindInfo.rFound = i;
				return true;
			}

			if((*i)->FindIterator(rFindInfo))
			{
				return true;
			}
		}

		return false;
	}

	/*
	Returns a pointer to the item corresponding to rItemKey if found.

	Returns NULL if the item corresponding to rItemKey is not found.
	*/
	ItemContainer* FindItemContainer(const Item& rItemKey)
	{
		if(m_Item == rItemKey)
		{
			return &m_Item;
		}
		FindInfo findInfo = { rItemKey };
		if(FindIterator(findInfo) && NULL != findInfo.pContainer)
		{
			return &((*findInfo.rFound)->m_Item);
		}
		return NULL;
	}

	DescendantContainer& GetDescendantContainer()
	{
		return m_DescendantContainer;
	}

	bool HasDescendants()
	{
		return !m_DescendantContainer.empty();
	}

	Item operator*()
	{
		return m_Item;
	}

__if_exists(Traits_T::HeapNodes::NodesOnHeap)
{
	HierarchyNode* AddDescendant(const Item& rItem)
	{
		return new HierarchyNode(this, rItem);
	}

}

	void RemoveDescendant(HierarchyNode* pNode)
	{
		m_DescendantContainer.remove(pNode);
	}

private:

	void DescendFromParent()
	{
		if(NULL != m_pParent)
		{
			m_pParent->m_DescendantContainer.push_back(this);
		}
	}

	HierarchyNode* m_pParent;

	ItemContainer m_Item;

	DescendantContainer m_DescendantContainer;
};

} // namespace VSL

#endif // VSLHIERARCHYNODE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
