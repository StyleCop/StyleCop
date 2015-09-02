/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

typedef AddRefAndReleaseMockBase<NullBase> AddRefAndReleaseMockNullBase;

VSL_DEFINE_VIRTUAL_DESTRUCTOR_TEST_HELPER(AddRefAndReleaseMockNullBase);

class AddRefAndReleaseMockTest :
	public UnitTestBase
{
private:

	void BasicTest()
	{
		AddRefAndReleaseMockBase<NullBase> mock;
		UTCHKEX(mock.GetRefCount() == 0, _T("after construction"));
		ULONG iRefCount = mock.AddRef();
		UTCHKEX(iRefCount == 1, _T("after AddRef"));
		UTCHKEX(mock.GetRefCount() == 1, _T("after AddRef"));
		iRefCount = mock.Release();
		UTCHKEX(iRefCount == 0, _T("after Release"));
		UTCHKEX(mock.GetRefCount() == 0, _T("after Release"));
	}

	void DestructorTest()
	{
		VSL_STDMETHODTRY
		{
			AddRefAndReleaseMockBase<NullBase> mock;
			mock.AddRef();
		}
		VSL_STDMETHODCATCH()
		UTCHKEX(VSL_GET_STDMETHOD_HRESULT() == E_FAIL, _T("Destruction did not throw"));
	}

	void AddRefAfterFinalReleaseTest()
	{
		VSL_STDMETHODTRY
		{
			AddRefAndReleaseMockBase<NullBase> mock;
			mock.AddRef();
			mock.Release();
			mock.AddRef();
		}
		VSL_STDMETHODCATCH()
		UTCHKEX(VSL_GET_STDMETHOD_HRESULT() == E_FAIL, _T("AddRef after final Release did not throw"));
	}

	void AddRefWrapAroundTest()
	{
// BUGBUG - the CRT chokes on the exception thrown by AddRef here, but the above works fine
// Try again with a recent VS build and open a bug if it still repros.
#if 0
		VSL_STDMETHODTRY
		{
			AddRefAndReleaseMockBase<NullBase> mock;
			mock.SetRefCount(LONG_MAX);
			mock.AddRef();
		}
		VSL_STDMETHODCATCH()
		UTCHKEX(VSL_GET_STDMETHOD_HRESULT() == E_FAIL, _T("AddRef that would wrap ref count did not throw"));
#endif
	}

	void ExtraReleaseTest()
	{
		VSL_STDMETHODTRY
		{
			AddRefAndReleaseMockBase<NullBase> mock;
			mock.AddRef();
			mock.Release();
			mock.Release();
		}
		VSL_STDMETHODCATCH()
		UTCHKEX(VSL_GET_STDMETHOD_HRESULT() == E_FAIL, _T("Extra Release call did not throw"));
	}

public:

	AddRefAndReleaseMockTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		BasicTest();
		DestructorTest();
		AddRefAfterFinalReleaseTest();
		AddRefWrapAroundTest();
		ExtraReleaseTest();
	}
};

template <class BaseClass_T = ISimple>
class SimpleCOMMock :
	public AddRefAndReleaseMockBase<BaseClass_T>
{

VSL_DECLARE_NOT_COPYABLE(SimpleCOMMock)

public:

	SimpleCOMMock() {}

	STDMETHOD(QueryInterface)(REFIID /*iid*/, void** /*ppObject*/)
	{
		return E_NOTIMPL;
	}
};

class Supported
{
public:
	static HRESULT TestQueryInterface()
	{
		return S_OK;
	}
	static bool TestPointer(void* pVoid)
	{
		return pVoid != NULL;
	}
	static bool TestRefCount(LONG iCurrentRefCount, LONG iLastRefCount)
	{
		return iCurrentRefCount == iLastRefCount + 1;
	}
};

class NotSupported
{
public:
	static HRESULT TestQueryInterface()
	{
		return E_NOINTERFACE;
	}
	static bool TestPointer(void* pVoid)
	{
		return pVoid == NULL;
	}
	static bool TestRefCount(LONG iCurrentRefCount, LONG iLastRefCount)
	{
		return iCurrentRefCount == iLastRefCount;
	}
};

template <class Mock_T, class InterfaceList_T>
class InternalQueryInterfaceTestBase :
	public UnitTestBase
{
public:

	template <class Interface_T, class Test_T>
	void TestForInterface(Mock_T &mock)
	{
		void* pVoid = NULL;
		LONG iLastRefCount = mock.GetRefCount();
		UTCHKEX(InterfaceList_T::InternalQueryInterface(&mock, __uuidof(Interface_T), &pVoid) == Test_T::TestQueryInterface(), _T(""));
		UTCHKEX(Test_T::TestPointer(pVoid), _T(""));
		UTCHKEX(Test_T::TestRefCount(mock.GetRefCount(), iLastRefCount), _T(""));
	}

	InternalQueryInterfaceTestBase(const char* const szTestName):
		UnitTestBase(szTestName)
	{
	}
};

class IUnknownInterfaceListTerminatorDefaultTest :
	public InternalQueryInterfaceTestBase<SimpleCOMMock<>, IUnknownInterfaceListTerminatorDefault>
{
private:

public:
	IUnknownInterfaceListTerminatorDefaultTest(_In_opt_ const char* const szTestName):
		InternalQueryInterfaceTestBase(szTestName)
	{
		// compile time test
		C_ASSERT(IUnknownInterfaceListTerminatorDefault::NumberOfInterfaces == 1);

		// runtime tests
		SimpleCOMMock<> mock;
		TestForInterface<IUnknown, Supported>(mock);
		TestForInterface<IDispatch, NotSupported>(mock);
		mock.SetRefCount(0);
	}
};

class NullInterfaceListTerminator
{

VSL_DECLARE_NOT_COPYABLE(NullInterfaceListTerminator)

public:

	NullInterfaceListTerminator() {}

	~NullInterfaceListTerminator()	{} // This should not be virtual, or it will cause a false positive

	enum { NumberOfInterfaces = 0 };

	template<typename This_T>
	static HRESULT InternalQueryInterface(This_T* /*pThis*/, REFIID /*iid*/, void** /*ppObject*/)
	{
		return E_NOINTERFACE;
	}
};

typedef InterfaceList<ISimple, IUnknownInterfaceListTerminatorDefault> SimpleInterfaceList;
typedef SimpleCOMMock<SimpleInterfaceList > SimpleMockInterfaceList;

class InterfaceListTest :
	public InternalQueryInterfaceTestBase<SimpleCOMMock<>, SimpleMockInterfaceList>
{
protected:

public:
	InterfaceListTest(_In_opt_ const char* const szTestName):
		InternalQueryInterfaceTestBase(szTestName)
	{
		// compile time test
		SimpleMockInterfaceList obj1;
		C_ASSERT(SimpleMockInterfaceList::NumberOfInterfaces == 2);

		// runtime tests
		SimpleCOMMock<> mock;
		TestForInterface<IUnknown, Supported>(mock);
		TestForInterface<ISimple, Supported>(mock);
		TestForInterface<IDispatch, NotSupported>(mock);
		mock.SetRefCount(0);
	}
};

template <class ISimpleMock_T>
class ISimpleMockTestBase :
	public UnitTestBase
{
public:
	template <class Interface_T, class Test_T>
	void TestForInterface(ISimpleMock_T &mock)
	{
		void* pVoid = NULL;
		LONG iLastRefCount = mock.GetRefCount();
		UTCHKEX(mock.QueryInterface(__uuidof(Interface_T), &pVoid) == Test_T::TestQueryInterface(), _T(""));
		UTCHKEX(Test_T::TestPointer(pVoid), _T(""));
		UTCHKEX(Test_T::TestRefCount(mock.GetRefCount(), iLastRefCount), _T(""));
	}

	ISimpleMockTestBase(const char* const szTestName):
		UnitTestBase(szTestName)
	{
		ISimpleMock_T mock;
		TestForInterface<IUnknown, Supported>(mock);
		TestForInterface<ISimple, Supported>(mock);
		TestForInterface<IDispatch, NotSupported>(mock);
		UTCHKEX(mock.QueryInterface(__uuidof(IUnknown), NULL) == E_POINTER, _T(""));
		UTCHKEX(mock.GetRefCount() == 2, _T("Ensure AddRef was not called after failing to pass in the out pointer"));
		mock.SetRefCount(0);
	}
};

class QueryInterfaceMockBaseHasVirtualDestructorTestHelper :
	public VirtualDestructorUnitTestHelper<QueryInterfaceMockBase<NullInterfaceListTerminator, QueryInterfaceMockBaseHasVirtualDestructorTestHelper> >
{
public:
	virtual ~QueryInterfaceMockBaseHasVirtualDestructorTestHelper() {}
};

class ISimpleImpl :
	public AddRefAndReleaseMockBase<QueryInterfaceMockBase<SimpleInterfaceList, ISimpleImpl> >
{
};

class QueryInterfaceMockBaseTest :
	public ISimpleMockTestBase<ISimpleImpl>
{
public:
	QueryInterfaceMockBaseTest(_In_opt_ const char* const szTestName):
		ISimpleMockTestBase(szTestName)
	{
	}
};

class ISimpleImpl2 :
	public COMMockBase<SimpleInterfaceList, ISimpleImpl2>
{
};

class COMMockBaseTest :
	public ISimpleMockTestBase<ISimpleImpl2>
{
public:
	COMMockBaseTest(_In_opt_ const char* const szTestName):
		ISimpleMockTestBase(szTestName)
	{
	}
};

typedef 
	InterfaceList<ISimple3, 
	InterfaceList<ISimple2, 
	InterfaceList<ISimple, IUnknownInterfaceListTerminator<ISimple2>, ISimple2> > >
		ISimpleAndDerivedInterfaceList;

VSL_DECLARE_COM_MOCK(ISimpleAndDerivedImpl, ISimpleAndDerivedInterfaceList){};

class ISimpleAndDerivedInterfaceListTest :
	public ISimpleMockTestBase<ISimpleAndDerivedImpl>
{
public:
	ISimpleAndDerivedInterfaceListTest(_In_opt_ const char* const szTestName):
		ISimpleMockTestBase(szTestName)
	{
	}
};

class I2MethodsNotImpl :
	public I2Methods
{
public:

	typedef I2Methods Interface;

	// Allow use of compiler generated copy constructors, destructor, and assignment operator

	STDMETHOD(Method1)()VSL_STDMETHOD_NOTIMPL
	STDMETHOD(Method2)()VSL_STDMETHOD_NOTIMPL

};

template <class Base_T = I2MethodsNotImpl>
class I2MethodsMethod1Impl :
	public Base_T
{
public:

	// Allow use of compiler generated copy constructors, destructor, and assignment operator

	STDMETHOD(Method1)()
	{
		return S_OK;
	}
};

template <class Base_T = I2MethodsNotImpl>
class I2MethodsMethod2Impl :
	public Base_T
{
public:

	// Allow use of compiler generated copy constructors, destructor, and assignment operator

	STDMETHOD(Method2)()
	{
		return S_OK;
	}
};

typedef InterfaceImplList<I2MethodsMethod1Impl<>, IUnknownInterfaceListTerminatorDefault> I2MethodsInterfaceList;

VSL_DECLARE_COM_MOCK(I2MethodsPartialImpl, I2MethodsInterfaceList){};

template <class Mock_T>
class GetInterfaceFromMockTestBase :
	public UnitTestBase
{
public:
	template <class Interface_T>
	Interface_T* GetInterfaceFromMock(Mock_T &mock)
	{
		IUnknown* pIUnknown = mock.GetIUnknownNoAddRef();

		Interface_T* pInterface = NULL;
		LONG iLastRefCount = mock.GetRefCount();
		UTCHKEX(pIUnknown->QueryInterface(__uuidof(Interface_T), reinterpret_cast<void**>(&pInterface)) == Supported::TestQueryInterface(), _T(""));
		UTCHKEX(Supported::TestPointer(pInterface), _T(""));
		UTCHKEX(Supported::TestRefCount(mock.GetRefCount(), iLastRefCount), _T(""));
		return pInterface;
	}

	GetInterfaceFromMockTestBase(const char* const szTestName):
		UnitTestBase(szTestName)
	{
	}
};

class I2MethodsPartialImplTest :
	public GetInterfaceFromMockTestBase<I2MethodsPartialImpl>
{
public:
	I2MethodsPartialImplTest(_In_opt_ const char* const szTestName):
		GetInterfaceFromMockTestBase(szTestName)
	{
		I2MethodsPartialImpl mock;

		I2Methods* pI2Methods = GetInterfaceFromMock<I2Methods>(mock);

		UTCHKEX(pI2Methods->Method1() == S_OK, _T(""));
		UTCHKEX(pI2Methods->Method2() == E_NOTIMPL, _T(""));

		mock.SetRefCount(0);
	}
};

typedef InterfaceImplList<I2MethodsMethod2Impl<I2MethodsMethod1Impl<> >, IUnknownInterfaceListTerminatorDefault > I2MethodsInterfaceListFullImpl;

VSL_DECLARE_COM_MOCK(I2MethodsFullImpl, I2MethodsInterfaceListFullImpl){};

class I2MethodsFullImplTest :
	public GetInterfaceFromMockTestBase<I2MethodsFullImpl>
{
public:
	I2MethodsFullImplTest (_In_opt_ const char* const szTestName):
		GetInterfaceFromMockTestBase(szTestName)
	{
		I2MethodsFullImpl mock;

		I2Methods* pI2Methods = GetInterfaceFromMock<I2Methods>(mock);

		UTCHKEX(pI2Methods->Method1() == S_OK, _T(""));
		UTCHKEX(pI2Methods->Method2() == S_OK, _T(""));

		mock.SetRefCount(0);
	}
};

class AtlIServiceProviderImplAdaptorMock;

// TODO - test that AtlIServiceProviderImplAdaptor has a virtual destructor

typedef InterfaceImplList<AtlIServiceProviderImplAdaptor<AtlIServiceProviderImplAdaptorMock>, InterfaceImplList<I2MethodsMethod2Impl<I2MethodsMethod1Impl<> >, IUnknownInterfaceListTerminator<IServiceProvider> > > AtlIServiceProviderImplAdaptorMockInterfaceList;

VSL_DECLARE_COM_MOCK(AtlIServiceProviderImplAdaptorMock, AtlIServiceProviderImplAdaptorMockInterfaceList)
{

BEGIN_SERVICE_MAP(AtlIServiceProviderImplAdaptorMock)
	SERVICE_ENTRY(__uuidof(I2Methods))
END_SERVICE_MAP()

};

class AtlIServiceProviderMockTest :
	public GetInterfaceFromMockTestBase<AtlIServiceProviderImplAdaptorMock>
{
public:
	AtlIServiceProviderMockTest(_In_opt_ const char* const szTestName):
		GetInterfaceFromMockTestBase(szTestName)
	{
		AtlIServiceProviderImplAdaptorMock mock;

		IServiceProvider* pIServiceProvider = GetInterfaceFromMock<IServiceProvider>(mock);

		I2Methods* pI2Methods;
		UTCHKEX(pIServiceProvider->QueryService(__uuidof(I2Methods), __uuidof(I2Methods), reinterpret_cast<void**>(&pI2Methods)) == S_OK, _T(""));
		UTCHKEX(mock.GetRefCount() == 2, _T("Ensure AddRef was called before returning I2Methods"));
		UTCHKEX(pI2Methods != NULL, _T(""));
		if(pI2Methods != NULL)
		{
			UTCHKEX(pI2Methods->Method1() == S_OK, _T(""));
			UTCHKEX(pI2Methods->Method2() == S_OK, _T(""));
		}

		mock.SetRefCount(0);
	}
};

VSL_DEFINE_SERVICE_MOCK(I2MethodsServiceProvider, I2MethodsMethod2Impl<I2MethodsMethod1Impl<> >);

typedef ServiceList<I2MethodsServiceProvider, ServiceListTerminator> IServiceProviderImplServiceList;
typedef InterfaceImplList<VSL::IServiceProviderImpl<IServiceProviderImplServiceList>, IUnknownInterfaceListTerminator<IServiceProvider> > IServiceProviderImplMockInterfaceList;

VSL_DECLARE_COM_MOCK(IServiceProviderImplMock, IServiceProviderImplMockInterfaceList){};

class IServiceProviderImplMockTest :
	public GetInterfaceFromMockTestBase<IServiceProviderImplMock>
{
public:
	IServiceProviderImplMockTest(_In_opt_ const char* const szTestName):
		GetInterfaceFromMockTestBase(szTestName)
	{
		IServiceProviderImplMock mock;

		IServiceProvider* pIServiceProvider = GetInterfaceFromMock<IServiceProvider>(mock);

		CComPtr<I2Methods> pI2Methods;
		UTCHKEX(pIServiceProvider->QueryService(__uuidof(I2Methods), __uuidof(I2Methods), reinterpret_cast<void**>(&pI2Methods)) == S_OK, _T(""));
		UTCHKEX(pI2Methods != NULL, _T(""));
		UTCHKEX(pI2Methods->Method1() == S_OK, _T(""));
		UTCHKEX(pI2Methods->Method2() == S_OK, _T(""));

		mock.SetRefCount(0);
	}
};
