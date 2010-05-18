/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLCONTAINERS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLCONTAINERS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include <VSL.h>

namespace VSL
{

/*
The purpose of StaticArray is to faciltate returning an array by reference from a method
without losing size information, as occurs when a built-in array is passed by reference where it
is simply reduced to a raw pointer.

The m_Array member must be public and the class constructors can not be defined to facilitate,
array style initialization, so that element are not default constructed.

An instance of StaticArray can only be created by using struct style initialization to initialize
the public member m_Array via array style initialization, so it doesn't quite emulate a built-in
array perfectly, but operator[] works as expected.

For example:

	StaticArray<int, 3> initializedArray =
	{
		{
			1,
			2,
			3
		}
	};

Because we are emulating the internal built-in array, we bounds check only by assert as the design
intent is for client's to use NumberOfElements to ensure they don't overrun the array, as they 
would need to ARRAYSIZE to ensurean built-in array is not overrun.
*/

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
template <class Type_T, size_t NumberOfElements_T>
class StaticArray
{
private:
	C_ASSERT(NumberOfElements_T > 0);
	VSL_DECLARE_ASSIGNMENT_OPERATOR(StaticArray);

	bool IndexInBounds(size_t i) const
	{
		return (i >= 0 && i < NumberOfElements);
	}
	
public:

#pragma warning(push)
#pragma warning(disable : 4480) // nonstandard extension used: specifying underlying type for enum ''
	enum : size_t {NumberOfElements = NumberOfElements_T};
#pragma warning(pop)

	typedef Type_T Type;

	typedef Type_T ArrayType[NumberOfElements_T];

	typedef const Type_T* const_iterator;

	ArrayType m_Array;

	Type_T& operator[](size_t i)
	{
		VSL_ASSERT(IndexInBounds(i));
		return m_Array[i]; 
	}

	const Type_T& operator[](size_t i) const
	{
		VSL_ASSERT(IndexInBounds(i));
		return m_Array[i]; 
	}

	size_t size() const
	{
		return NumberOfElements;
	}

	const Type_T* begin() const
	{
		return &(m_Array[0]);
	}

	const Type_T* end() const
	{
		return m_Array + NumberOfElements;
	}
};
#pragma warning(pop)

} // namespace VSL

#endif VSLMOCKSYSTEMINTERFACE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5