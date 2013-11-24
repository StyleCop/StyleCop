/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTRACKPROJECTDOCUMENTSEVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTRACKPROJECTDOCUMENTSEVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsTrackProjectDocumentsEvents2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsTrackProjectDocumentsEvents2NotImpl :
	public IVsTrackProjectDocumentsEvents2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTrackProjectDocumentsEvents2NotImpl)

public:

	typedef IVsTrackProjectDocumentsEvents2 Interface;

	STDMETHOD(OnQueryAddFiles)(
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ int /*cFiles*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgpszMkDocuments*/,
		/*[in,size_is(cFiles)]*/ const VSQUERYADDFILEFLAGS[] /*rgFlags*/,
		/*[out]*/ VSQUERYADDFILERESULTS* /*pSummaryResult*/,
		/*[out,size_is(cFiles)]*/ VSQUERYADDFILERESULTS[] /*rgResults*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterAddFilesEx)(
		/*[in]*/ int /*cProjects*/,
		/*[in]*/ int /*cFiles*/,
		/*[in,size_is(cProjects)]*/ IVsProject*[] /*rgpProjects*/,
		/*[in,size_is(cProjects)]*/ const int[] /*rgFirstIndices*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgpszMkDocuments*/,
		/*[in,size_is(cFiles)]*/ const VSADDFILEFLAGS[] /*rgFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterAddDirectoriesEx)(
		/*[in]*/ int /*cProjects*/,
		/*[in]*/ int /*cDirectories*/,
		/*[in,size_is(cProjects)]*/ IVsProject*[] /*rgpProjects*/,
		/*[in,size_is(cProjects)]*/ const int[] /*rgFirstIndices*/,
		/*[in,size_is(cDirectories)]*/ const LPCOLESTR[] /*rgpszMkDocuments*/,
		/*[in,size_is(cDirectories)]*/ const VSADDDIRECTORYFLAGS[] /*rgFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterRemoveFiles)(
		/*[in]*/ int /*cProjects*/,
		/*[in]*/ int /*cFiles*/,
		/*[in,size_is(cProjects)]*/ IVsProject*[] /*rgpProjects*/,
		/*[in,size_is(cProjects)]*/ const int[] /*rgFirstIndices*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgpszMkDocuments*/,
		/*[in,size_is(cFiles)]*/ const VSREMOVEFILEFLAGS[] /*rgFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterRemoveDirectories)(
		/*[in]*/ int /*cProjects*/,
		/*[in]*/ int /*cDirectories*/,
		/*[in,size_is(cProjects)]*/ IVsProject*[] /*rgpProjects*/,
		/*[in,size_is(cProjects)]*/ const int[] /*rgFirstIndices*/,
		/*[in,size_is(cDirectories)]*/ const LPCOLESTR[] /*rgpszMkDocuments*/,
		/*[in,size_is(cDirectories)]*/ const VSREMOVEDIRECTORYFLAGS[] /*rgFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnQueryRenameFiles)(
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ int /*cFiles*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgszMkOldNames*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgszMkNewNames*/,
		/*[in,size_is(cFiles)]*/ const VSQUERYRENAMEFILEFLAGS[] /*rgflags*/,
		/*[out]*/ VSQUERYRENAMEFILERESULTS* /*pSummaryResult*/,
		/*[out,size_is(cFiles)]*/ VSQUERYRENAMEFILERESULTS[] /*rgResults*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterRenameFiles)(
		/*[in]*/ int /*cProjects*/,
		/*[in]*/ int /*cFiles*/,
		/*[in,size_is(cProjects)]*/ IVsProject*[] /*rgpProjects*/,
		/*[in,size_is(cProjects)]*/ const int[] /*rgFirstIndices*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgszMkOldNames*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgszMkNewNames*/,
		/*[in,size_is(cFiles)]*/ const VSRENAMEFILEFLAGS[] /*rgflags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnQueryRenameDirectories)(
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ int /*cDirs*/,
		/*[in,size_is(cDirs)]*/ const LPCOLESTR[] /*rgszMkOldNames*/,
		/*[in,size_is(cDirs)]*/ const LPCOLESTR[] /*rgszMkNewNames*/,
		/*[in,size_is(cDirs)]*/ const VSQUERYRENAMEDIRECTORYFLAGS[] /*rgflags*/,
		/*[out]*/ VSQUERYRENAMEDIRECTORYRESULTS* /*pSummaryResult*/,
		/*[out,size_is(cDirs)]*/ VSQUERYRENAMEDIRECTORYRESULTS[] /*rgResults*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterRenameDirectories)(
		/*[in]*/ int /*cProjects*/,
		/*[in]*/ int /*cDirs*/,
		/*[in,size_is(cProjects)]*/ IVsProject*[] /*rgpProjects*/,
		/*[in,size_is(cProjects)]*/ const int[] /*rgFirstIndices*/,
		/*[in,size_is(cDirs)]*/ const LPCOLESTR[] /*rgszMkOldNames*/,
		/*[in,size_is(cDirs)]*/ const LPCOLESTR[] /*rgszMkNewNames*/,
		/*[in,size_is(cDirs)]*/ const VSRENAMEDIRECTORYFLAGS[] /*rgflags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnQueryAddDirectories)(
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ int /*cDirectories*/,
		/*[in,size_is(cDirectories)]*/ const LPCOLESTR[] /*rgpszMkDocuments*/,
		/*[in,size_is(cDirectories)]*/ const VSQUERYADDDIRECTORYFLAGS[] /*rgFlags*/,
		/*[out]*/ VSQUERYADDDIRECTORYRESULTS* /*pSummaryResult*/,
		/*[out,size_is(cDirectories)]*/ VSQUERYADDDIRECTORYRESULTS[] /*rgResults*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnQueryRemoveFiles)(
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ int /*cFiles*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgpszMkDocuments*/,
		/*[in,size_is(cFiles)]*/ const VSQUERYREMOVEFILEFLAGS[] /*rgFlags*/,
		/*[out]*/ VSQUERYREMOVEFILERESULTS* /*pSummaryResult*/,
		/*[out,size_is(cFiles)]*/ VSQUERYREMOVEFILERESULTS[] /*rgResults*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnQueryRemoveDirectories)(
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ int /*cDirectories*/,
		/*[in,size_is(cDirectories)]*/ const LPCOLESTR[] /*rgpszMkDocuments*/,
		/*[in,size_is(cDirectories)]*/ const VSQUERYREMOVEDIRECTORYFLAGS[] /*rgFlags*/,
		/*[out]*/ VSQUERYREMOVEDIRECTORYRESULTS* /*pSummaryResult*/,
		/*[out,size_is(cDirectories)]*/ VSQUERYREMOVEDIRECTORYRESULTS[] /*rgResults*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterSccStatusChanged)(
		/*[in]*/ int /*cProjects*/,
		/*[in]*/ int /*cFiles*/,
		/*[in,size_is(cProjects)]*/ IVsProject*[] /*rgpProjects*/,
		/*[in,size_is(cProjects)]*/ const int[] /*rgFirstIndices*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgpszMkDocuments*/,
		/*[in,size_is(cFiles)]*/ const DWORD[] /*rgdwSccStatus*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTrackProjectDocumentsEvents2MockImpl :
	public IVsTrackProjectDocumentsEvents2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTrackProjectDocumentsEvents2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTrackProjectDocumentsEvents2MockImpl)

	typedef IVsTrackProjectDocumentsEvents2 Interface;
	struct OnQueryAddFilesValidValues
	{
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ int cFiles;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgpszMkDocuments;
		/*[in,size_is(cFiles)]*/ VSQUERYADDFILEFLAGS* rgFlags;
		/*[out]*/ VSQUERYADDFILERESULTS* pSummaryResult;
		/*[out,size_is(cFiles)]*/ VSQUERYADDFILERESULTS* rgResults;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryAddFiles)(
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ int cFiles,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgpszMkDocuments[],
		/*[in,size_is(cFiles)]*/ const VSQUERYADDFILEFLAGS rgFlags[],
		/*[out]*/ VSQUERYADDFILERESULTS* pSummaryResult,
		/*[out,size_is(cFiles)]*/ VSQUERYADDFILERESULTS rgResults[])
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryAddFiles)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE(cFiles);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszMkDocuments, cFiles*sizeof(rgpszMkDocuments[0]), validValues.cFiles*sizeof(validValues.rgpszMkDocuments[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFlags, cFiles*sizeof(rgFlags[0]), validValues.cFiles*sizeof(validValues.rgFlags[0]));

		VSL_SET_VALIDVALUE(pSummaryResult);

		VSL_SET_VALIDVALUE_MEMCPY(rgResults, cFiles*sizeof(rgResults[0]), validValues.cFiles*sizeof(validValues.rgResults[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterAddFilesExValidValues
	{
		/*[in]*/ int cProjects;
		/*[in]*/ int cFiles;
		/*[in,size_is(cProjects)]*/ IVsProject** rgpProjects;
		/*[in,size_is(cProjects)]*/ int* rgFirstIndices;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgpszMkDocuments;
		/*[in,size_is(cFiles)]*/ VSADDFILEFLAGS* rgFlags;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterAddFilesEx)(
		/*[in]*/ int cProjects,
		/*[in]*/ int cFiles,
		/*[in,size_is(cProjects)]*/ IVsProject* rgpProjects[],
		/*[in,size_is(cProjects)]*/ const int rgFirstIndices[],
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgpszMkDocuments[],
		/*[in,size_is(cFiles)]*/ const VSADDFILEFLAGS rgFlags[])
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterAddFilesEx)

		VSL_CHECK_VALIDVALUE(cProjects);

		VSL_CHECK_VALIDVALUE(cFiles);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpProjects, cProjects, validValues.cProjects);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFirstIndices, cProjects*sizeof(rgFirstIndices[0]), validValues.cProjects*sizeof(validValues.rgFirstIndices[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszMkDocuments, cFiles*sizeof(rgpszMkDocuments[0]), validValues.cFiles*sizeof(validValues.rgpszMkDocuments[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFlags, cFiles*sizeof(rgFlags[0]), validValues.cFiles*sizeof(validValues.rgFlags[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterAddDirectoriesExValidValues
	{
		/*[in]*/ int cProjects;
		/*[in]*/ int cDirectories;
		/*[in,size_is(cProjects)]*/ IVsProject** rgpProjects;
		/*[in,size_is(cProjects)]*/ int* rgFirstIndices;
		/*[in,size_is(cDirectories)]*/ LPCOLESTR* rgpszMkDocuments;
		/*[in,size_is(cDirectories)]*/ VSADDDIRECTORYFLAGS* rgFlags;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterAddDirectoriesEx)(
		/*[in]*/ int cProjects,
		/*[in]*/ int cDirectories,
		/*[in,size_is(cProjects)]*/ IVsProject* rgpProjects[],
		/*[in,size_is(cProjects)]*/ const int rgFirstIndices[],
		/*[in,size_is(cDirectories)]*/ const LPCOLESTR rgpszMkDocuments[],
		/*[in,size_is(cDirectories)]*/ const VSADDDIRECTORYFLAGS rgFlags[])
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterAddDirectoriesEx)

		VSL_CHECK_VALIDVALUE(cProjects);

		VSL_CHECK_VALIDVALUE(cDirectories);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpProjects, cProjects, validValues.cProjects);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFirstIndices, cProjects*sizeof(rgFirstIndices[0]), validValues.cProjects*sizeof(validValues.rgFirstIndices[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszMkDocuments, cDirectories*sizeof(rgpszMkDocuments[0]), validValues.cDirectories*sizeof(validValues.rgpszMkDocuments[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFlags, cDirectories*sizeof(rgFlags[0]), validValues.cDirectories*sizeof(validValues.rgFlags[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterRemoveFilesValidValues
	{
		/*[in]*/ int cProjects;
		/*[in]*/ int cFiles;
		/*[in,size_is(cProjects)]*/ IVsProject** rgpProjects;
		/*[in,size_is(cProjects)]*/ int* rgFirstIndices;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgpszMkDocuments;
		/*[in,size_is(cFiles)]*/ VSREMOVEFILEFLAGS* rgFlags;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterRemoveFiles)(
		/*[in]*/ int cProjects,
		/*[in]*/ int cFiles,
		/*[in,size_is(cProjects)]*/ IVsProject* rgpProjects[],
		/*[in,size_is(cProjects)]*/ const int rgFirstIndices[],
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgpszMkDocuments[],
		/*[in,size_is(cFiles)]*/ const VSREMOVEFILEFLAGS rgFlags[])
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterRemoveFiles)

		VSL_CHECK_VALIDVALUE(cProjects);

		VSL_CHECK_VALIDVALUE(cFiles);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpProjects, cProjects, validValues.cProjects);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFirstIndices, cProjects*sizeof(rgFirstIndices[0]), validValues.cProjects*sizeof(validValues.rgFirstIndices[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszMkDocuments, cFiles*sizeof(rgpszMkDocuments[0]), validValues.cFiles*sizeof(validValues.rgpszMkDocuments[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFlags, cFiles*sizeof(rgFlags[0]), validValues.cFiles*sizeof(validValues.rgFlags[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterRemoveDirectoriesValidValues
	{
		/*[in]*/ int cProjects;
		/*[in]*/ int cDirectories;
		/*[in,size_is(cProjects)]*/ IVsProject** rgpProjects;
		/*[in,size_is(cProjects)]*/ int* rgFirstIndices;
		/*[in,size_is(cDirectories)]*/ LPCOLESTR* rgpszMkDocuments;
		/*[in,size_is(cDirectories)]*/ VSREMOVEDIRECTORYFLAGS* rgFlags;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterRemoveDirectories)(
		/*[in]*/ int cProjects,
		/*[in]*/ int cDirectories,
		/*[in,size_is(cProjects)]*/ IVsProject* rgpProjects[],
		/*[in,size_is(cProjects)]*/ const int rgFirstIndices[],
		/*[in,size_is(cDirectories)]*/ const LPCOLESTR rgpszMkDocuments[],
		/*[in,size_is(cDirectories)]*/ const VSREMOVEDIRECTORYFLAGS rgFlags[])
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterRemoveDirectories)

		VSL_CHECK_VALIDVALUE(cProjects);

		VSL_CHECK_VALIDVALUE(cDirectories);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpProjects, cProjects, validValues.cProjects);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFirstIndices, cProjects*sizeof(rgFirstIndices[0]), validValues.cProjects*sizeof(validValues.rgFirstIndices[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszMkDocuments, cDirectories*sizeof(rgpszMkDocuments[0]), validValues.cDirectories*sizeof(validValues.rgpszMkDocuments[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFlags, cDirectories*sizeof(rgFlags[0]), validValues.cDirectories*sizeof(validValues.rgFlags[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnQueryRenameFilesValidValues
	{
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ int cFiles;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgszMkOldNames;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgszMkNewNames;
		/*[in,size_is(cFiles)]*/ VSQUERYRENAMEFILEFLAGS* rgflags;
		/*[out]*/ VSQUERYRENAMEFILERESULTS* pSummaryResult;
		/*[out,size_is(cFiles)]*/ VSQUERYRENAMEFILERESULTS* rgResults;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryRenameFiles)(
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ int cFiles,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgszMkOldNames[],
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgszMkNewNames[],
		/*[in,size_is(cFiles)]*/ const VSQUERYRENAMEFILEFLAGS rgflags[],
		/*[out]*/ VSQUERYRENAMEFILERESULTS* pSummaryResult,
		/*[out,size_is(cFiles)]*/ VSQUERYRENAMEFILERESULTS rgResults[])
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryRenameFiles)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE(cFiles);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszMkOldNames, cFiles*sizeof(rgszMkOldNames[0]), validValues.cFiles*sizeof(validValues.rgszMkOldNames[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszMkNewNames, cFiles*sizeof(rgszMkNewNames[0]), validValues.cFiles*sizeof(validValues.rgszMkNewNames[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgflags, cFiles*sizeof(rgflags[0]), validValues.cFiles*sizeof(validValues.rgflags[0]));

		VSL_SET_VALIDVALUE(pSummaryResult);

		VSL_SET_VALIDVALUE_MEMCPY(rgResults, cFiles*sizeof(rgResults[0]), validValues.cFiles*sizeof(validValues.rgResults[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterRenameFilesValidValues
	{
		/*[in]*/ int cProjects;
		/*[in]*/ int cFiles;
		/*[in,size_is(cProjects)]*/ IVsProject** rgpProjects;
		/*[in,size_is(cProjects)]*/ int* rgFirstIndices;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgszMkOldNames;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgszMkNewNames;
		/*[in,size_is(cFiles)]*/ VSRENAMEFILEFLAGS* rgflags;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterRenameFiles)(
		/*[in]*/ int cProjects,
		/*[in]*/ int cFiles,
		/*[in,size_is(cProjects)]*/ IVsProject* rgpProjects[],
		/*[in,size_is(cProjects)]*/ const int rgFirstIndices[],
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgszMkOldNames[],
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgszMkNewNames[],
		/*[in,size_is(cFiles)]*/ const VSRENAMEFILEFLAGS rgflags[])
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterRenameFiles)

		VSL_CHECK_VALIDVALUE(cProjects);

		VSL_CHECK_VALIDVALUE(cFiles);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpProjects, cProjects, validValues.cProjects);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFirstIndices, cProjects*sizeof(rgFirstIndices[0]), validValues.cProjects*sizeof(validValues.rgFirstIndices[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszMkOldNames, cFiles*sizeof(rgszMkOldNames[0]), validValues.cFiles*sizeof(validValues.rgszMkOldNames[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszMkNewNames, cFiles*sizeof(rgszMkNewNames[0]), validValues.cFiles*sizeof(validValues.rgszMkNewNames[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgflags, cFiles*sizeof(rgflags[0]), validValues.cFiles*sizeof(validValues.rgflags[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnQueryRenameDirectoriesValidValues
	{
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ int cDirs;
		/*[in,size_is(cDirs)]*/ LPCOLESTR* rgszMkOldNames;
		/*[in,size_is(cDirs)]*/ LPCOLESTR* rgszMkNewNames;
		/*[in,size_is(cDirs)]*/ VSQUERYRENAMEDIRECTORYFLAGS* rgflags;
		/*[out]*/ VSQUERYRENAMEDIRECTORYRESULTS* pSummaryResult;
		/*[out,size_is(cDirs)]*/ VSQUERYRENAMEDIRECTORYRESULTS* rgResults;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryRenameDirectories)(
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ int cDirs,
		/*[in,size_is(cDirs)]*/ const LPCOLESTR rgszMkOldNames[],
		/*[in,size_is(cDirs)]*/ const LPCOLESTR rgszMkNewNames[],
		/*[in,size_is(cDirs)]*/ const VSQUERYRENAMEDIRECTORYFLAGS rgflags[],
		/*[out]*/ VSQUERYRENAMEDIRECTORYRESULTS* pSummaryResult,
		/*[out,size_is(cDirs)]*/ VSQUERYRENAMEDIRECTORYRESULTS rgResults[])
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryRenameDirectories)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE(cDirs);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszMkOldNames, cDirs*sizeof(rgszMkOldNames[0]), validValues.cDirs*sizeof(validValues.rgszMkOldNames[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszMkNewNames, cDirs*sizeof(rgszMkNewNames[0]), validValues.cDirs*sizeof(validValues.rgszMkNewNames[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgflags, cDirs*sizeof(rgflags[0]), validValues.cDirs*sizeof(validValues.rgflags[0]));

		VSL_SET_VALIDVALUE(pSummaryResult);

		VSL_SET_VALIDVALUE_MEMCPY(rgResults, cDirs*sizeof(rgResults[0]), validValues.cDirs*sizeof(validValues.rgResults[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterRenameDirectoriesValidValues
	{
		/*[in]*/ int cProjects;
		/*[in]*/ int cDirs;
		/*[in,size_is(cProjects)]*/ IVsProject** rgpProjects;
		/*[in,size_is(cProjects)]*/ int* rgFirstIndices;
		/*[in,size_is(cDirs)]*/ LPCOLESTR* rgszMkOldNames;
		/*[in,size_is(cDirs)]*/ LPCOLESTR* rgszMkNewNames;
		/*[in,size_is(cDirs)]*/ VSRENAMEDIRECTORYFLAGS* rgflags;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterRenameDirectories)(
		/*[in]*/ int cProjects,
		/*[in]*/ int cDirs,
		/*[in,size_is(cProjects)]*/ IVsProject* rgpProjects[],
		/*[in,size_is(cProjects)]*/ const int rgFirstIndices[],
		/*[in,size_is(cDirs)]*/ const LPCOLESTR rgszMkOldNames[],
		/*[in,size_is(cDirs)]*/ const LPCOLESTR rgszMkNewNames[],
		/*[in,size_is(cDirs)]*/ const VSRENAMEDIRECTORYFLAGS rgflags[])
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterRenameDirectories)

		VSL_CHECK_VALIDVALUE(cProjects);

		VSL_CHECK_VALIDVALUE(cDirs);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpProjects, cProjects, validValues.cProjects);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFirstIndices, cProjects*sizeof(rgFirstIndices[0]), validValues.cProjects*sizeof(validValues.rgFirstIndices[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszMkOldNames, cDirs*sizeof(rgszMkOldNames[0]), validValues.cDirs*sizeof(validValues.rgszMkOldNames[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszMkNewNames, cDirs*sizeof(rgszMkNewNames[0]), validValues.cDirs*sizeof(validValues.rgszMkNewNames[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgflags, cDirs*sizeof(rgflags[0]), validValues.cDirs*sizeof(validValues.rgflags[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnQueryAddDirectoriesValidValues
	{
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ int cDirectories;
		/*[in,size_is(cDirectories)]*/ LPCOLESTR* rgpszMkDocuments;
		/*[in,size_is(cDirectories)]*/ VSQUERYADDDIRECTORYFLAGS* rgFlags;
		/*[out]*/ VSQUERYADDDIRECTORYRESULTS* pSummaryResult;
		/*[out,size_is(cDirectories)]*/ VSQUERYADDDIRECTORYRESULTS* rgResults;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryAddDirectories)(
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ int cDirectories,
		/*[in,size_is(cDirectories)]*/ const LPCOLESTR rgpszMkDocuments[],
		/*[in,size_is(cDirectories)]*/ const VSQUERYADDDIRECTORYFLAGS rgFlags[],
		/*[out]*/ VSQUERYADDDIRECTORYRESULTS* pSummaryResult,
		/*[out,size_is(cDirectories)]*/ VSQUERYADDDIRECTORYRESULTS rgResults[])
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryAddDirectories)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE(cDirectories);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszMkDocuments, cDirectories*sizeof(rgpszMkDocuments[0]), validValues.cDirectories*sizeof(validValues.rgpszMkDocuments[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFlags, cDirectories*sizeof(rgFlags[0]), validValues.cDirectories*sizeof(validValues.rgFlags[0]));

		VSL_SET_VALIDVALUE(pSummaryResult);

		VSL_SET_VALIDVALUE_MEMCPY(rgResults, cDirectories*sizeof(rgResults[0]), validValues.cDirectories*sizeof(validValues.rgResults[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnQueryRemoveFilesValidValues
	{
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ int cFiles;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgpszMkDocuments;
		/*[in,size_is(cFiles)]*/ VSQUERYREMOVEFILEFLAGS* rgFlags;
		/*[out]*/ VSQUERYREMOVEFILERESULTS* pSummaryResult;
		/*[out,size_is(cFiles)]*/ VSQUERYREMOVEFILERESULTS* rgResults;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryRemoveFiles)(
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ int cFiles,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgpszMkDocuments[],
		/*[in,size_is(cFiles)]*/ const VSQUERYREMOVEFILEFLAGS rgFlags[],
		/*[out]*/ VSQUERYREMOVEFILERESULTS* pSummaryResult,
		/*[out,size_is(cFiles)]*/ VSQUERYREMOVEFILERESULTS rgResults[])
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryRemoveFiles)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE(cFiles);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszMkDocuments, cFiles*sizeof(rgpszMkDocuments[0]), validValues.cFiles*sizeof(validValues.rgpszMkDocuments[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFlags, cFiles*sizeof(rgFlags[0]), validValues.cFiles*sizeof(validValues.rgFlags[0]));

		VSL_SET_VALIDVALUE(pSummaryResult);

		VSL_SET_VALIDVALUE_MEMCPY(rgResults, cFiles*sizeof(rgResults[0]), validValues.cFiles*sizeof(validValues.rgResults[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnQueryRemoveDirectoriesValidValues
	{
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ int cDirectories;
		/*[in,size_is(cDirectories)]*/ LPCOLESTR* rgpszMkDocuments;
		/*[in,size_is(cDirectories)]*/ VSQUERYREMOVEDIRECTORYFLAGS* rgFlags;
		/*[out]*/ VSQUERYREMOVEDIRECTORYRESULTS* pSummaryResult;
		/*[out,size_is(cDirectories)]*/ VSQUERYREMOVEDIRECTORYRESULTS* rgResults;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryRemoveDirectories)(
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ int cDirectories,
		/*[in,size_is(cDirectories)]*/ const LPCOLESTR rgpszMkDocuments[],
		/*[in,size_is(cDirectories)]*/ const VSQUERYREMOVEDIRECTORYFLAGS rgFlags[],
		/*[out]*/ VSQUERYREMOVEDIRECTORYRESULTS* pSummaryResult,
		/*[out,size_is(cDirectories)]*/ VSQUERYREMOVEDIRECTORYRESULTS rgResults[])
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryRemoveDirectories)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE(cDirectories);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszMkDocuments, cDirectories*sizeof(rgpszMkDocuments[0]), validValues.cDirectories*sizeof(validValues.rgpszMkDocuments[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFlags, cDirectories*sizeof(rgFlags[0]), validValues.cDirectories*sizeof(validValues.rgFlags[0]));

		VSL_SET_VALIDVALUE(pSummaryResult);

		VSL_SET_VALIDVALUE_MEMCPY(rgResults, cDirectories*sizeof(rgResults[0]), validValues.cDirectories*sizeof(validValues.rgResults[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterSccStatusChangedValidValues
	{
		/*[in]*/ int cProjects;
		/*[in]*/ int cFiles;
		/*[in,size_is(cProjects)]*/ IVsProject** rgpProjects;
		/*[in,size_is(cProjects)]*/ int* rgFirstIndices;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgpszMkDocuments;
		/*[in,size_is(cFiles)]*/ DWORD* rgdwSccStatus;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterSccStatusChanged)(
		/*[in]*/ int cProjects,
		/*[in]*/ int cFiles,
		/*[in,size_is(cProjects)]*/ IVsProject* rgpProjects[],
		/*[in,size_is(cProjects)]*/ const int rgFirstIndices[],
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgpszMkDocuments[],
		/*[in,size_is(cFiles)]*/ const DWORD rgdwSccStatus[])
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterSccStatusChanged)

		VSL_CHECK_VALIDVALUE(cProjects);

		VSL_CHECK_VALIDVALUE(cFiles);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpProjects, cProjects, validValues.cProjects);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFirstIndices, cProjects*sizeof(rgFirstIndices[0]), validValues.cProjects*sizeof(validValues.rgFirstIndices[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszMkDocuments, cFiles*sizeof(rgpszMkDocuments[0]), validValues.cFiles*sizeof(validValues.rgpszMkDocuments[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgdwSccStatus, cFiles*sizeof(rgdwSccStatus[0]), validValues.cFiles*sizeof(validValues.rgdwSccStatus[0]));

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTRACKPROJECTDOCUMENTSEVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
