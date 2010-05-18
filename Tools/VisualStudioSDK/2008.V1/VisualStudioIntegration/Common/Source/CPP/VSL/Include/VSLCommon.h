/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLCOMMON_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLCOMMON_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

// VSL includes
#include <VSL.h>
#include <VSLErrorHandlers.h>
#include <VSLExceptionHandlers.h>

// STL includes
#include <limits>
#ifndef VSL_DELEGATE_CONTAINER
#include <list>
#define VSL_DELEGATE_CONTAINER(FunctorPtr) std::list< FunctorPtr >
#endif

namespace VSL
{

class TypeNull
{
};

#if 0 // FUTURE - include if needed
template <typename Type_T, const Type_T Default_T>
class TypeWithDefault
{
public:
	typedef Type_T Type;
	inline static Type GetDefault()
	{
		return Default_T;
	}
};
#endif

template <typename PointerType_T>
class PointerWithNullDefault
{

VSL_DECLARE_NONINSTANTIABLE_CLASS(PointerWithNullDefault)

public:

	typedef PointerType_T* Type;

	inline static Type GetDefault()
	{
		return NULL;
	}
};

template <class TypeToCacheWithDefault_T>
class LocalCache
{

VSL_DECLARE_NOT_COPYABLE(LocalCache)

public:
	typedef TypeToCacheWithDefault_T TypeToCacheWithDefault;
	typedef typename TypeToCacheWithDefault::Type CachedType;

	enum { bIsGlobal = 0 };

	LocalCache():
		m_Cached(TypeToCacheWithDefault_T::GetDefault())
	{
	}

	CachedType& Get()
	{
		return m_Cached;
	}

	const CachedType& Get() const
	{
		return m_Cached;
	}

	void Set(const CachedType& rToCache)
	{
		m_Cached = rToCache;
	}

private:

	CachedType m_Cached;

};

template <class TypeToCacheWithDefault_T>
class GlobalCache
{

VSL_DECLARE_NOT_COPYABLE(GlobalCache)

public:
	typedef TypeToCacheWithDefault_T TypeToCacheWithDefault;
	typedef typename TypeToCacheWithDefault::Type CachedType;

	enum
	{
		bIsGlobal = 1, // For run-time
		IsGlobal, // For compile-time
	};

	GlobalCache() {}

	CachedType& Get()
	{
		static CachedType cached = TypeToCacheWithDefault::GetDefault();
		return cached;
	}

	const CachedType& Get() const
	{
		return const_cast<GlobalCache*>(this)->Get();
	}

	void Set(const CachedType& rToCache)
	{
		Get() = rToCache;
	}
};

/*
FUTURE - A thread safe caches could be added.
*/

template <class Unique_T, class Count_T = unsigned int>
class GlobalRefCount
{

VSL_DECLARE_NONINSTANTIABLE_CLASS(GlobalRefCount)

public:

	typedef Count_T Count;

	static Count_T& Get()
	{
		static Count_T iRefCount = 0;
		return iRefCount;
	}

	static bool CanIncrement()
	{
#pragma push_macro("max")
#undef max
		return Get() != std::numeric_limits<Count>::max();
#pragma pop_macro("max")
	}

	static void ErrorIfCanNotIncrement()
	{
		VSL_CHECKBOOLEAN(CanIncrement(), E_UNEXPECTED);
	}

	static bool CanDecrement()
	{
		return Get() != 0;
	}
};

// TODO - Unit test this
template <class T>
class __declspec(uuid("9959BC5B-A014-4f2b-8A04-715FA173A8E2")) __declspec(novtable) IProvideCppClass :
	public IUnknown
{
public:
	virtual T& GetCppClass()
	{
		return *(static_cast<T*>(this));
	}
};

class InterfaceSupportsErrorInfoListTerminator
{

VSL_DECLARE_NONINSTANTIABLE_CLASS(InterfaceSupportsErrorInfoListTerminator)

public:
	static HRESULT InterfaceSupportsErrorInfo(REFIID /*riid*/)
	{
		return S_FALSE;
	}
};

template <class Interface_T, class Next_T = InterfaceSupportsErrorInfoListTerminator>
class InterfaceSupportsErrorInfoList
{

VSL_DECLARE_NONINSTANTIABLE_CLASS(InterfaceSupportsErrorInfoList)

public:

	static HRESULT InterfaceSupportsErrorInfo(REFIID riid)
	{
		if(__uuidof(Interface_T) == riid)
		{
			return S_OK;
		}
		return Next_T::InterfaceSupportsErrorInfo(riid);
	}
};

template <class InterfaceList_T>
class ISupportErrorInfoImpl :
	public ISupportErrorInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISupportErrorInfoImpl);

public:

	STDMETHOD(InterfaceSupportsErrorInfo)(REFIID riid)
	{
		return InterfaceList_T::InterfaceSupportsErrorInfo(riid);
	}
};

class CallingConventionStandard
{
public:
	enum 
	{
		StandardCall
	};
};

class CallingConventionDefault
{
public:
	enum 
	{
		Default
	};
};

#define VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS_DEFAULTED typename Return_T = TypeNull, typename Parameter1_T = TypeNull, typename Parameter2_T = TypeNull, typename Parameter3_T = TypeNull
#define VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS typename Return_T, typename Parameter1_T, typename Parameter2_T, typename Parameter3_T
#define VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM1_TO_LAST , Parameter1_T VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM2_TO_LAST
#define VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM2_TO_LAST , Parameter2_T VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM3_TO_LAST
#define VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM3_TO_LAST , Parameter3_T
// Last is always empty as it serves as a place holder should additional parameters need to be added
#define VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM4_TO_LAST

template <VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS_DEFAULTED>
class Functor
{
VSL_DEFINE_NON_DEFAULT_CONSTRUCTABLE_BASE_CLASS_WITH_PROTECTED_COPY(Functor)
};

template <class CallingConvention_T, VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS_DEFAULTED>
class FunctionPointerFunctor
{
VSL_DECLARE_NONINSTANTIABLE_CLASS(FunctionPointerFunctor)
};

template <class Class_T, class CallingConvention_T, VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS_DEFAULTED>
class MemberFunctionPointerFunctor
{
VSL_DECLARE_NONINSTANTIABLE_CLASS(MemberFunctionPointerFunctor)
};

template <VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS_DEFAULTED>
class Delegate
{
VSL_DECLARE_NONINSTANTIABLE_CLASS(Delegate)
};


template <VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class Functor<Return_T () VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM1_TO_LAST>
{

VSL_DEFINE_NON_DEFAULT_CONSTRUCTABLE_BASE_CLASS_WITH_PROTECTED_COPY(Functor)

public:
	virtual Return_T operator()() = 0;
};

template <class CallingConvention_T, VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class FunctionPointerFunctor<CallingConvention_T, Return_T () VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM1_TO_LAST> : 
	public Functor<Return_T ()>
{
private:

	FunctionPointerFunctor();

public:

	// Compiler generated destructor, assignment operator, and copy constructor are fine

	typedef Return_T (*FunctionPointer)();

	virtual Return_T operator()()
	{
		return m_pFunction();
	}

	FunctionPointerFunctor(_In_ FunctionPointer pFunction):
		m_pFunction(VSL_CHECKPOINTER(pFunction, E_POINTER))
	{
	}

private:
	FunctionPointer m_pFunction;
};

template <class Class_T, class CallingConvention_T, VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class MemberFunctionPointerFunctor<Class_T, CallingConvention_T, Return_T () VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM1_TO_LAST> : 
	public Functor<Return_T ()>
{
private:

	MemberFunctionPointerFunctor();

public:

	// Compiler generated destructor, assignment operator, and copy constructor are fine

	__if_exists(CallingConvention_T::StandardCall)
	{
	typedef Return_T (__stdcall	Class_T::*MemberFunctionPointer)();
	}
	__if_not_exists(CallingConvention_T::StandardCall)
	{
	typedef Return_T (Class_T::*MemberFunctionPointer)();
	}

	virtual Return_T operator()()
	{
		return (m_pInstance->*m_pMemberFunction)();
	}

	MemberFunctionPointerFunctor(_In_ Class_T* pInstance, _In_ MemberFunctionPointer pMemberFunction):
		m_pInstance(VSL_CHECKPOINTER(pInstance, E_POINTER)),
		m_pMemberFunction(pMemberFunction) // TODO - test member function pointer isn't NULL
	{
	}

private:
	Class_T* m_pInstance;
	MemberFunctionPointer m_pMemberFunction;
};

template <VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class Delegate<Return_T () VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM1_TO_LAST>
{
public:

	// Compiler generated default constructor, destructor, assignment operator, and copy constructor are fine

	typedef Functor<Return_T ()>* FunctorPtr;
	typedef VSL_DELEGATE_CONTAINER(FunctorPtr) Container;

	bool IsBound()
	{
		return !(m_Container.empty());
	}

	Return_T operator()()
	{
		if(!IsBound())
		{
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);
		}

		Container::const_iterator i = m_Container.begin();
		Container::const_iterator iLast = --(m_Container.end());
		while(i != iLast)
		{
			Container::const_iterator tmp = i;
			++i;
			// tmp may be invalidated after this call as the callee could remove
			// its self
			(**tmp)();
		}

		return (**iLast)();
	}

	void operator+=(_In_ FunctorPtr pFunctor)
	{
		m_Container.push_back(pFunctor);
	}

	void operator-=(_In_ FunctorPtr pFunctor)
	{
		m_Container.remove(pFunctor);
	}

private:
	Container m_Container;
};

template <VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class Functor<Return_T (Parameter1_T) VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM2_TO_LAST>
{

VSL_DEFINE_NON_DEFAULT_CONSTRUCTABLE_BASE_CLASS_WITH_PROTECTED_COPY(Functor)

public:
	virtual Return_T operator()(Parameter1_T parameter1) = 0;
};

template <class CallingConvention_T, VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class FunctionPointerFunctor<CallingConvention_T, Return_T (Parameter1_T) VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM2_TO_LAST> : 
	public Functor<Return_T (Parameter1_T)>
{
private:

	FunctionPointerFunctor();

public:

	// Compiler generated destructor, assignment operator, and copy constructor are fine

	typedef Return_T (*FunctionPointer)(Parameter1_T);
	typedef Functor<Return_T (Parameter1_T)> ThisFunctor;

	virtual Return_T operator()(Parameter1_T parameter1)
	{
		return m_pFunction(parameter1);
	}

	FunctionPointerFunctor(_In_ FunctionPointer pFunction):
		m_pFunction(VSL_CHECKPOINTER(pFunction, E_POINTER))
	{
	}

private:
	FunctionPointer m_pFunction;
};

template <class Class_T, class CallingConvention_T, VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class MemberFunctionPointerFunctor<Class_T, CallingConvention_T, Return_T (Parameter1_T) VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM2_TO_LAST> : 
	public Functor<Return_T (Parameter1_T)>
{
private:

	MemberFunctionPointerFunctor();

public:

	// Compiler generated destructor, assignment operator, and copy constructor are fine

	__if_exists(CallingConvention_T::StandardCall)
	{
	typedef Return_T (__stdcall	Class_T::*MemberFunctionPointer)(Parameter1_T);
	}
	__if_not_exists(CallingConvention_T::StandardCall)
	{
	typedef Return_T (Class_T::*MemberFunctionPointer)(Parameter1_T);
	}

	virtual Return_T operator()(Parameter1_T parameter1)
	{
		return (m_pInstance->*m_pMemberFunction)(parameter1);
	}

	MemberFunctionPointerFunctor(_In_ Class_T* pInstance, _In_ MemberFunctionPointer pMemberFunction):
		m_pInstance(VSL_CHECKPOINTER(pInstance, E_POINTER)),
		m_pMemberFunction(pMemberFunction)  // TODO - test member function pointer isn't NULL
	{
	}

private:
	Class_T* m_pInstance;
	MemberFunctionPointer m_pMemberFunction;
};

template <VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class Delegate<Return_T (Parameter1_T) VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM2_TO_LAST>
{
public:

	// Compiler generated default constructor, destructor, assignment operator, and copy constructor are fine

	typedef Functor<Return_T (Parameter1_T)>* FunctorPtr;
	typedef VSL_DELEGATE_CONTAINER(FunctorPtr) Container;

	bool IsBound()
	{
		return !(m_Container.empty());
	}

	Return_T operator()(Parameter1_T parameter1)
	{
		if(!IsBound())
		{
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);
		}

		Container::const_iterator i = m_Container.begin();
		Container::const_iterator iLast = --(m_Container.end());
		while(i != iLast)
		{
			Container::const_iterator tmp = i;
			++i;
			// tmp may be invalidated after this call as the callee could remove
			// its self
			(**tmp)(parameter1);
		}

		return (**iLast)(parameter1);
	}

	void operator+=(_In_ FunctorPtr pFunctor)
	{
		m_Container.push_back(pFunctor);
	}

	void operator-=(_In_ FunctorPtr pFunctor)
	{
		m_Container.remove(pFunctor);
	}

private:
	Container m_Container;
};

template <VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class Functor<Return_T (Parameter1_T, Parameter2_T) VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM3_TO_LAST>
{

VSL_DEFINE_NON_DEFAULT_CONSTRUCTABLE_BASE_CLASS_WITH_PROTECTED_COPY(Functor)

public:
	virtual Return_T operator()(Parameter1_T parameter1, Parameter2_T parameter2) = 0;
};

template <class CallingConvention_T, VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class FunctionPointerFunctor<CallingConvention_T, Return_T (Parameter1_T, Parameter2_T) VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM3_TO_LAST> : 
	public Functor<Return_T (Parameter1_T, Parameter2_T)>
{
private:

	FunctionPointerFunctor();

public:

	// Compiler generated destructor, assignment operator, and copy constructor are fine

	typedef Return_T (*FunctionPointer)(Parameter1_T, Parameter2_T);
	typedef Functor<Return_T (Parameter1_T, Parameter2_T)> ThisFunctor;

	virtual Return_T operator()(Parameter1_T parameter1, Parameter2_T parameter2)
	{
		return m_pFunction(parameter1, parameter2);
	}

	FunctionPointerFunctor(_In_ FunctionPointer pFunction):
		m_pFunction(VSL_CHECKPOINTER(pFunction, E_POINTER))
	{
	}

private:
	FunctionPointer m_pFunction;
};

template <class Class_T, class CallingConvention_T, VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class MemberFunctionPointerFunctor<Class_T, CallingConvention_T, Return_T (Parameter1_T, Parameter2_T) VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM3_TO_LAST> : 
	public Functor<Return_T (Parameter1_T, Parameter2_T)>
{
private:

	MemberFunctionPointerFunctor();

public:

	// Compiler generated destructor, assignment operator, and copy constructor are fine

	__if_exists(CallingConvention_T::StandardCall)
	{
	typedef Return_T (__stdcall	Class_T::*MemberFunctionPointer)(Parameter1_T, Parameter2_T);
	}
	__if_not_exists(CallingConvention_T::StandardCall)
	{
	typedef Return_T (Class_T::*MemberFunctionPointer)(Parameter1_T, Parameter2_T);
	}

	virtual Return_T operator()(Parameter1_T parameter1, Parameter1_T parameter2)
	{
		return (m_pInstance->*m_pMemberFunction)(parameter1, parameter2);
	}

	MemberFunctionPointerFunctor(_In_ Class_T* pInstance, _In_ MemberFunctionPointer pMemberFunction):
		m_pInstance(VSL_CHECKPOINTER(pInstance, E_POINTER)),
		m_pMemberFunction(pMemberFunction)  // TODO - test member function pointer isn't NULL
	{
	}

private:
	Class_T* m_pInstance;
	MemberFunctionPointer m_pMemberFunction;
};

template <VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class Delegate<Return_T (Parameter1_T, Parameter2_T) VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM3_TO_LAST>
{
public:

	// Compiler generated default constructor, destructor, assignment operator, and copy constructor are fine

	typedef Functor<Return_T (Parameter1_T, Parameter2_T)>* FunctorPtr;
	typedef VSL_DELEGATE_CONTAINER(FunctorPtr) Container;

	bool IsBound()
	{
		return !(m_Container.empty());
	}

	Return_T operator()(Parameter1_T parameter1, Parameter2_T parameter2)
	{
		if(!IsBound())
		{
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);
		}

		Container::const_iterator i = m_Container.begin();
		Container::const_iterator iLast = --(m_Container.end());
		while(i != iLast)
		{
			Container::const_iterator tmp = i;
			++i;
			// tmp may be invalidated after this call as the callee could remove
			// its self
			(**tmp)(parameter1, parameter2);
		}

		return (**iLast)(parameter1, parameter2);
	}

	void operator+=(_In_ FunctorPtr pFunctor)
	{
		m_Container.push_back(pFunctor);
	}

	void operator-=(_In_ FunctorPtr pFunctor)
	{
		m_Container.remove(pFunctor);
	}

private:
	Container m_Container;
};


template <VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class Functor<Return_T (Parameter1_T, Parameter2_T, Parameter3_T) VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM4_TO_LAST>
{

VSL_DEFINE_NON_DEFAULT_CONSTRUCTABLE_BASE_CLASS_WITH_PROTECTED_COPY(Functor)

public:
	virtual Return_T operator()(Parameter1_T parameter1, Parameter2_T parameter2, Parameter3_T parameter3) = 0;
};

template <class CallingConvention_T, VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class FunctionPointerFunctor<CallingConvention_T, Return_T (Parameter1_T, Parameter2_T, Parameter3_T) VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM4_TO_LAST> : 
	public Functor<Return_T (Parameter1_T, Parameter2_T, Parameter3_T)>
{
private:

	FunctionPointerFunctor();

public:

	// Compiler generated destructor, assignment operator, and copy constructor are fine

	typedef Return_T (*FunctionPointer)(Parameter1_T, Parameter2_T, Parameter3_T);
	typedef Functor<Return_T (Parameter1_T, Parameter2_T, Parameter3_T)> ThisFunctor;

	virtual Return_T operator()(Parameter1_T parameter1, Parameter2_T parameter2, Parameter3_T parameter3)
	{
		return m_pFunction(parameter1, parameter2, parameter3);
	}

	FunctionPointerFunctor(_In_ FunctionPointer pFunction):
		m_pFunction(VSL_CHECKPOINTER(pFunction, E_POINTER))
	{
	}

private:
	FunctionPointer m_pFunction;
};

template <class Class_T, class CallingConvention_T, VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class MemberFunctionPointerFunctor<Class_T, CallingConvention_T, Return_T (Parameter1_T, Parameter2_T, Parameter3_T) VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM4_TO_LAST> : 
	public Functor<Return_T (Parameter1_T, Parameter2_T, Parameter3_T)>
{
private:

	MemberFunctionPointerFunctor();

public:

	// Compiler generated destructor, assignment operator, and copy constructor are fine

	__if_exists(CallingConvention_T::StandardCall)
	{
	typedef Return_T (__stdcall	Class_T::*MemberFunctionPointer)(Parameter1_T, Parameter2_T, Parameter3_T);
	}
	__if_not_exists(CallingConvention_T::StandardCall)
	{
	typedef Return_T (Class_T::*MemberFunctionPointer)(Parameter1_T, Parameter2_T, Parameter3_T);
	}

	virtual Return_T operator()(Parameter1_T parameter1, Parameter2_T parameter2, Parameter3_T parameter3)
	{
		return (m_pInstance->*m_pMemberFunction)(parameter1, parameter2, parameter3);
	}

	MemberFunctionPointerFunctor(_In_ Class_T* pInstance, _In_ MemberFunctionPointer pMemberFunction):
		m_pInstance(VSL_CHECKPOINTER(pInstance, E_POINTER)),
		m_pMemberFunction(pMemberFunction)  // TODO - test member function pointer isn't NULL
	{
	}

private:
	Class_T* m_pInstance;
	MemberFunctionPointer m_pMemberFunction;
};

template <VSL_DECLARE_FUNCTOR_TEMPLATE_ARGS>
class Delegate<Return_T (Parameter1_T, Parameter2_T, Parameter3_T) VSL_SPECIALIZE_FUNCTOR_TEMPLATE_ARG_PARM4_TO_LAST>
{
public:

	// Compiler generated default constructor, destructor, assignment operator, and copy constructor are fine

	typedef Functor<Return_T (Parameter1_T, Parameter2_T, Parameter3_T)>* FunctorPtr;
	typedef VSL_DELEGATE_CONTAINER(FunctorPtr) Container;

	bool IsBound()
	{
		return !(m_Container.empty());
	}

	Return_T operator()(Parameter1_T parameter1, Parameter2_T parameter2, Parameter3_T parameter3)
	{
		if(!IsBound())
		{
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);
		}

		Container::const_iterator i = m_Container.begin();
		Container::const_iterator iLast = --(m_Container.end());
		while(i != iLast)
		{
			Container::const_iterator tmp = i;
			++i;
			// tmp may be invalidated after this call as the callee could remove
			// its self
			(**tmp)(parameter1, parameter2, parameter3);
		}

		return (**iLast)(parameter1, parameter2, parameter3);
	}

	void operator+=(_In_ FunctorPtr pFunctor)
	{
		m_Container.push_back(pFunctor);
	}

	void operator-=(_In_ FunctorPtr pFunctor)
	{
		m_Container.remove(pFunctor);
	}

private:
	Container m_Container;
};

class CoTaskMemPointerTraits
{
public:
	typedef LPVOID PointerType;
	typedef CoTaskMemPointerTraits Allocator;
	typedef CoTaskMemPointerTraits Values;
	typedef CoTaskMemPointerTraits Cloner;
	static LPVOID GetNullValue()
	{
		return NULL;
	}
	static LPVOID InitializeFromPointerType(_In_ LPVOID pVoid)
	{
		return pVoid;
	}
	static void Free(_In_ LPVOID pVoid)
	{
		::CoTaskMemFree(pVoid);
	}
};

template <class Type_T>
class StdArrayPointerTraits
{
public:
	typedef Type_T* PointerType;
	typedef StdArrayPointerTraits Allocator;
	typedef StdArrayPointerTraits Values;
	typedef StdArrayPointerTraits Cloner;
	static Type_T* GetNullValue()
	{
		return NULL;
	}
	static Type_T* InitializeFromPointerType(_In_ Type_T* pArray)
	{
		return pArray;
	}
	static void Free(_In_ Type_T* pArray)
	{
		delete [] pArray;
	}
	static void AssignFromPointerType(Type_T*& rpAssignTo, _In_ Type_T* pAssignFrom)
	{
		VSL_CHECKBOOLEAN(rpAssignTo != pAssignFrom, E_UNEXPECTED);
		if(rpAssignTo != GetNullValue())
		{
			Free(rpAssignTo);
		}
		rpAssignTo = pAssignFrom;
	}
};

// TODO - 2/2/2006 - specific unit test this (it is currently covered by DocumentPersistanceBaseTest)
template<class PointerTraits_T>
class Pointer
{
public:
	typedef typename PointerTraits_T::PointerType PointerType;
	typedef typename PointerTraits_T::Values Values;
	typedef typename PointerTraits_T::Allocator Allocator;
	typedef typename PointerTraits_T::Cloner Cloner;

	Pointer():
		m_p(Values::GetNullValue())
	{
	}

	Pointer(PointerType p):
		m_p(Cloner::InitializeFromPointerType(p))
	{
	}

// This is done, as we can't have two copies of a method under different
// __if_exists (get a multiply defined error if that is tried)
private:
__if_exists(Cloner::Clone)
{
public:
}

	Pointer(Pointer& rToCopy)
	{
		__if_exists(Cloner::Clone)
		{
		Cloner::Clone(m_p, rToCopy.m_p);
		}
	}

public:

	~Pointer()
	{
		Free();
	}

private:
__if_exists(Cloner::AssignFromPointerType)
{
public:
}
	const Pointer& operator=(PointerType p)
	{
		__if_exists(Cloner::AssignFromPointerType)
		{
		Cloner::AssignFromPointerType(m_p, p);
		}
		return *this;
	}

private:
__if_exists(Cloner::Clone)
{
public:
}
	const Pointer& operator=(Pointer& rToCopy)
	{
		__if_exists(Cloner::Clone)
		{
		Cloner::Clone(m_p, rToCopy.m_p);
		}
		return *this;
	}

public:

	void Free()
	{
		if(Values::GetNullValue() != m_p)
		{
			Allocator::Free(m_p);
			m_p = Values::GetNullValue();
		}
	}

	PointerType Detach()
	{
		PointerType p = m_p;
		m_p = Values::GetNullValue();
		return p;
	}

	operator PointerType() const
	{
		return m_p;
	}

__if_exists(PointerType::bProvideAddressOfOperator)
{
	PointerType* operator &()
	{
		return &m_p;
	}
}

	PointerType operator->() const
	{
		return m_p;
	}

	// FUTURE - 2/2/2006 - add Attach, operator*(), operator&(), operator->(), operator!(), operator<, operator!=, operator==

private:
	PointerType m_p;
};

typedef Pointer<CoTaskMemPointerTraits> CoTaskMemPointer;

template<class ResourceTraits_T>
class Resource
{

// FUTURE - 2/2/2006 - make this copyable
VSL_DECLARE_NOT_COPYABLE(Resource)

public:
	typedef typename ResourceTraits_T::ResourceType ResourceType;
	typedef typename ResourceTraits_T::CastType CastType;
	typedef typename ResourceTraits_T::Values Values;
	typedef typename ResourceTraits_T::Allocator Allocator;
	typedef typename ResourceTraits_T::Cloner Cloner;

	Resource():
		m_Resource(Values::GetNullValue())
	{
	}

	Resource(_In_ ResourceType resource):
		m_Resource(resource)
	{
	}

	~Resource()
	{
		Free();
	}

	void Free()
	{
		if(Values::GetNullValue() != m_Resource)
		{
			Allocator::Free(m_Resource);
			m_Resource = Values::GetNullValue();
		}
	}

	ResourceType Detach()
	{
		ResourceType resource = m_Resource;
		m_Resource = Values::GetNullValue();
		return resource;
	}

	operator CastType() const
	{
		return Values::CastToResource(m_Resource);
	}

	// FUTURE - 3/8/2006 - add Attach, operator!(), operator!=, operator==

private:
	ResourceType m_Resource;
};

class LibraryResourceTraits
{
public:
	typedef HMODULE ResourceType;
	typedef HMODULE CastType;
	typedef LibraryResourceTraits Allocator;
	typedef LibraryResourceTraits Values;
	typedef LibraryResourceTraits Cloner;
	static HMODULE GetNullValue()
	{
		return NULL;
	}
	static void Free(_In_ HMODULE hLibrary)
	{
		::FreeLibrary(hLibrary);
	}
	static HMODULE CastToResource(_In_ HMODULE hLibrary)
	{
		return hLibrary;
	}
};

class Library
{
private:

VSL_DECLARE_NOT_COPYABLE(Library);

	// FUTURE - default construction could be supported
	Library();

public:
	Library(_In_z_ wchar_t* szLibrary):
		m_hLibrary(reinterpret_cast<HMODULE>(VSL_CHECKHANDLE_GLE(::LoadLibrary(szLibrary))))
	{
	}

	// The compiler generated destructor is fine

	// FUTURE - 3/8/2006 - can add additional wrapper methods

private:
	Resource<LibraryResourceTraits> m_hLibrary;
};

#define VSL_DEFINE_IUNKNOWN_NOTIMPL \
	STDMETHOD(QueryInterface)(REFIID, void**) { return E_NOTIMPL; } \
	virtual ULONG STDMETHODCALLTYPE AddRef() { return 0; } \
	virtual ULONG STDMETHODCALLTYPE Release() { return 0; }

} // namespace VSL

#endif // VSLCOMMON_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
