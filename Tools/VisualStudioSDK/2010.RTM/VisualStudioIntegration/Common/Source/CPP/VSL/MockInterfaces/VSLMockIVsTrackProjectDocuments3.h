/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTRACKPROJECTDOCUMENTS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTRACKPROJECTDOCUMENTS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsTrackProjectDocuments80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsTrackProjectDocuments3NotImpl :
	public IVsTrackProjectDocuments3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTrackProjectDocuments3NotImpl)

public:

	typedef IVsTrackProjectDocuments3 Interface;

	STDMETHOD(BeginQueryBatch)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EndQueryBatch)(
		/*[out,retval]*/ BOOL* /*pfActionOK*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CancelQueryBatch)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnQueryAddFilesEx)(
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ int /*cFiles*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgpszNewMkDocuments*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgpszSrcMkDocuments*/,
		/*[in,size_is(cFiles)]*/ const VSQUERYADDFILEFLAGS[] /*rgFlags*/,
		/*[out]*/ VSQUERYADDFILERESULTS* /*pSummaryResult*/,
		/*[out,size_is(cFiles)]*/ VSQUERYADDFILERESULTS[] /*rgResults*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HandsOffFiles)(
		/*[in]*/ HANDSOFFMODE /*grfRequiredAccess*/,
		/*[in]*/ int /*cFiles*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgpszMkDocuments*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HandsOnFiles)(
		/*[in]*/ int /*cFiles*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgpszMkDocuments*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTrackProjectDocuments3MockImpl :
	public IVsTrackProjectDocuments3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTrackProjectDocuments3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTrackProjectDocuments3MockImpl)

	typedef IVsTrackProjectDocuments3 Interface;
	struct BeginQueryBatchValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(BeginQueryBatch)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(BeginQueryBatch)

		VSL_RETURN_VALIDVALUES();
	}
	struct EndQueryBatchValidValues
	{
		/*[out,retval]*/ BOOL* pfActionOK;
		HRESULT retValue;
	};

	STDMETHOD(EndQueryBatch)(
		/*[out,retval]*/ BOOL* pfActionOK)
	{
		VSL_DEFINE_MOCK_METHOD(EndQueryBatch)

		VSL_SET_VALIDVALUE(pfActionOK);

		VSL_RETURN_VALIDVALUES();
	}
	struct CancelQueryBatchValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CancelQueryBatch)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CancelQueryBatch)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnQueryAddFilesExValidValues
	{
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ int cFiles;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgpszNewMkDocuments;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgpszSrcMkDocuments;
		/*[in,size_is(cFiles)]*/ VSQUERYADDFILEFLAGS* rgFlags;
		/*[out]*/ VSQUERYADDFILERESULTS* pSummaryResult;
		/*[out,size_is(cFiles)]*/ VSQUERYADDFILERESULTS* rgResults;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryAddFilesEx)(
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ int cFiles,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgpszNewMkDocuments[],
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgpszSrcMkDocuments[],
		/*[in,size_is(cFiles)]*/ const VSQUERYADDFILEFLAGS rgFlags[],
		/*[out]*/ VSQUERYADDFILERESULTS* pSummaryResult,
		/*[out,size_is(cFiles)]*/ VSQUERYADDFILERESULTS rgResults[])
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryAddFilesEx)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE(cFiles);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszNewMkDocuments, cFiles*sizeof(rgpszNewMkDocuments[0]), validValues.cFiles*sizeof(validValues.rgpszNewMkDocuments[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszSrcMkDocuments, cFiles*sizeof(rgpszSrcMkDocuments[0]), validValues.cFiles*sizeof(validValues.rgpszSrcMkDocuments[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFlags, cFiles*sizeof(rgFlags[0]), validValues.cFiles*sizeof(validValues.rgFlags[0]));

		VSL_SET_VALIDVALUE(pSummaryResult);

		VSL_SET_VALIDVALUE_MEMCPY(rgResults, cFiles*sizeof(rgResults[0]), validValues.cFiles*sizeof(validValues.rgResults[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct HandsOffFilesValidValues
	{
		/*[in]*/ HANDSOFFMODE grfRequiredAccess;
		/*[in]*/ int cFiles;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgpszMkDocuments;
		HRESULT retValue;
	};

	STDMETHOD(HandsOffFiles)(
		/*[in]*/ HANDSOFFMODE grfRequiredAccess,
		/*[in]*/ int cFiles,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgpszMkDocuments[])
	{
		VSL_DEFINE_MOCK_METHOD(HandsOffFiles)

		VSL_CHECK_VALIDVALUE(grfRequiredAccess);

		VSL_CHECK_VALIDVALUE(cFiles);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszMkDocuments, cFiles*sizeof(rgpszMkDocuments[0]), validValues.cFiles*sizeof(validValues.rgpszMkDocuments[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct HandsOnFilesValidValues
	{
		/*[in]*/ int cFiles;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgpszMkDocuments;
		HRESULT retValue;
	};

	STDMETHOD(HandsOnFiles)(
		/*[in]*/ int cFiles,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgpszMkDocuments[])
	{
		VSL_DEFINE_MOCK_METHOD(HandsOnFiles)

		VSL_CHECK_VALIDVALUE(cFiles);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszMkDocuments, cFiles*sizeof(rgpszMkDocuments[0]), validValues.cFiles*sizeof(validValues.rgpszMkDocuments[0]));

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTRACKPROJECTDOCUMENTS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
