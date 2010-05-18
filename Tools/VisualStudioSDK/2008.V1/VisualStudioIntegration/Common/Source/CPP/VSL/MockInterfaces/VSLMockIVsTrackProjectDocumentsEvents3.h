/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTRACKPROJECTDOCUMENTSEVENTS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTRACKPROJECTDOCUMENTSEVENTS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsTrackProjectDocumentsEvents80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsTrackProjectDocumentsEvents3NotImpl :
	public IVsTrackProjectDocumentsEvents3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTrackProjectDocumentsEvents3NotImpl)

public:

	typedef IVsTrackProjectDocumentsEvents3 Interface;

	STDMETHOD(OnBeginQueryBatch)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnEndQueryBatch)(
		/*[out,retval]*/ BOOL* /*pfActionOK*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnCancelQueryBatch)()VSL_STDMETHOD_NOTIMPL

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

class IVsTrackProjectDocumentsEvents3MockImpl :
	public IVsTrackProjectDocumentsEvents3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTrackProjectDocumentsEvents3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTrackProjectDocumentsEvents3MockImpl)

	typedef IVsTrackProjectDocumentsEvents3 Interface;
	struct OnBeginQueryBatchValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnBeginQueryBatch)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnBeginQueryBatch)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnEndQueryBatchValidValues
	{
		/*[out,retval]*/ BOOL* pfActionOK;
		HRESULT retValue;
	};

	STDMETHOD(OnEndQueryBatch)(
		/*[out,retval]*/ BOOL* pfActionOK)
	{
		VSL_DEFINE_MOCK_METHOD(OnEndQueryBatch)

		VSL_SET_VALIDVALUE(pfActionOK);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnCancelQueryBatchValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnCancelQueryBatch)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnCancelQueryBatch)

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

#endif // IVSTRACKPROJECTDOCUMENTSEVENTS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
