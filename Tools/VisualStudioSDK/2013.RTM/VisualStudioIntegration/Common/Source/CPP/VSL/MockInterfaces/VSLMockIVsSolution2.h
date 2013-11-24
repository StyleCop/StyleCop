/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSOLUTION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSOLUTION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSolution2NotImpl :
	public IVsSolution2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolution2NotImpl)

public:

	typedef IVsSolution2 Interface;

	STDMETHOD(UpdateProjectFileLocation)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProjectEnum)(
		/*[in]*/ VSENUMPROJFLAGS /*grfEnumFlags*/,
		/*[in]*/ REFGUID /*rguidEnumOnlyThisType*/,
		/*[out]*/ IEnumHierarchies** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateProject)(
		/*[in]*/ REFGUID /*rguidProjectType*/,
		/*[in]*/ LPCOLESTR /*lpszMoniker*/,
		/*[in]*/ LPCOLESTR /*lpszLocation*/,
		/*[in]*/ LPCOLESTR /*lpszName*/,
		/*[in]*/ VSCREATEPROJFLAGS /*grfCreateFlags*/,
		/*[in]*/ REFIID /*iidProject*/,
		/*[out,iid_is(iidProject)]*/ void** /*ppProject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GenerateUniqueProjectName)(
		/*[in]*/ LPCOLESTR /*lpszRoot*/,
		/*[out]*/ BSTR* /*pbstrProjectName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProjectOfGuid)(
		/*[in]*/ REFGUID /*rguidProjectID*/,
		/*[out]*/ IVsHierarchy** /*ppHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGuidOfProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[out]*/ GUID* /*pguidProjectID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSolutionInfo)(
		/*[out]*/ BSTR* /*pbstrSolutionDirectory*/,
		/*[out]*/ BSTR* /*pbstrSolutionFile*/,
		/*[out]*/ BSTR* /*pbstrUserOptsFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseSolutionEvents)(
		/*[in]*/ IVsSolutionEvents* /*pSink*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseSolutionEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveSolutionElement)(
		/*[in]*/ VSSLNSAVEOPTIONS /*grfSaveOpts*/,
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSCOOKIE /*docCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseSolutionElement)(
		/*[in]*/ VSSLNCLOSEOPTIONS /*grfCloseOpts*/,
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSCOOKIE /*docCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProjectOfProjref)(
		/*[in]*/ LPCOLESTR /*pszProjref*/,
		/*[out]*/ IVsHierarchy** /*ppHierarchy*/,
		/*[out]*/ BSTR* /*pbstrUpdatedProjref*/,
		/*[out]*/ VSUPDATEPROJREFREASON* /*puprUpdateReason*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProjrefOfProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[out]*/ BSTR* /*pbstrProjref*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProjectInfoOfProjref)(
		/*[in]*/ LPCOLESTR /*pszProjref*/,
		/*[in]*/ VSHPROPID /*propid*/,
		/*[out]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddVirtualProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ VSADDVPFLAGS /*grfAddVPFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemOfProjref)(
		/*[in]*/ LPCOLESTR /*pszProjref*/,
		/*[out]*/ IVsHierarchy** /*ppHierarchy*/,
		/*[out]*/ VSITEMID* /*pitemid*/,
		/*[out]*/ BSTR* /*pbstrUpdatedProjref*/,
		/*[out]*/ VSUPDATEPROJREFREASON* /*puprUpdateReason*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProjrefOfItem)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[out]*/ BSTR* /*pbstrProjref*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemInfoOfProjref)(
		/*[in]*/ LPCOLESTR /*pszProjref*/,
		/*[in]*/ VSHPROPID /*propid*/,
		/*[out]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProjectOfUniqueName)(
		/*[in]*/ LPCOLESTR /*pszUniqueName*/,
		/*[out]*/ IVsHierarchy** /*ppHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUniqueNameOfProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[out]*/ BSTR* /*pbstrUniqueName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProperty)(
		/*[in]*/ VSPROPID /*propid*/,
		/*[out]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetProperty)(
		/*[in]*/ VSPROPID /*propid*/,
		/*[in]*/ VARIANT /*var*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenSolutionFile)(
		/*[in]*/ VSSLNOPENOPTIONS /*grfOpenOpts*/,
		/*[in]*/ LPCOLESTR /*pszFilename*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryEditSolutionFile)(
		/*[out]*/ DWORD* /*pdwEditResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateSolution)(
		/*[in,unique]*/ LPCOLESTR /*lpszLocation*/,
		/*[in,unique]*/ LPCOLESTR /*lpszName*/,
		/*[in]*/ VSCREATESOLUTIONFLAGS /*grfCreateFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProjectFactory)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in,out]*/ GUID* /*pguidProjectType*/,
		/*[in]*/ LPCOLESTR /*pszMkProject*/,
		/*[out,retval]*/ IVsProjectFactory** /*ppProjectFactory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProjectTypeGuid)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ LPCOLESTR /*pszMkProject*/,
		/*[out,retval]*/ GUID* /*pguidProjectType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenSolutionViaDlg)(
		/*[in]*/ LPCOLESTR /*pszStartDirectory*/,
		/*[in]*/ BOOL /*fDefaultToAllProjectsFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddVirtualProjectEx)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ VSADDVPFLAGS /*grfAddVPFlags*/,
		/*[in]*/ REFGUID /*rguidProjectID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryRenameProject)(
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ LPCOLESTR /*pszMkOldName*/,
		/*[in]*/ LPCOLESTR /*pszMkNewName*/,
		/*[in]*/ DWORD /*dwReserved*/,
		/*[out]*/ BOOL* /*pfRenameCanContinue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterRenameProject)(
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ LPCOLESTR /*pszMkOldName*/,
		/*[in]*/ LPCOLESTR /*pszMkNewName*/,
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveVirtualProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ VSREMOVEVPFLAGS /*grfRemoveVPFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateNewProjectViaDlg)(
		/*[in]*/ LPCOLESTR /*pszExpand*/,
		/*[in]*/ LPCOLESTR /*pszSelect*/,
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetVirtualProjectFlags)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[out]*/ VSADDVPFLAGS* /*pgrfAddVPFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GenerateNextDefaultProjectName)(
		/*[in]*/ LPCOLESTR /*pszBaseName*/,
		/*[in]*/ LPCOLESTR /*pszLocation*/,
		/*[out]*/ BSTR* /*pbstrProjectName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProjectFilesInSolution)(
		/*[in]*/ VSGETPROJFILESFLAGS /*grfGetOpts*/,
		/*[in]*/ ULONG /*cProjects*/,
		/*[out,size_is(cProjects),length_is(*pcProjectsFetched)]*/ BSTR* /*rgbstrProjectNames*/,
		/*[out]*/ ULONG* /*pcProjectsFetched*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanCreateNewProjectAtLocation)(
		/*[in]*/ BOOL /*fCreateNewSolution*/,
		/*[in]*/ LPCOLESTR /*pszFullProjectFilePath*/,
		/*[out]*/ BOOL* /*pfCanCreate*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSolution2MockImpl :
	public IVsSolution2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolution2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSolution2MockImpl)

	typedef IVsSolution2 Interface;
	struct UpdateProjectFileLocationValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(UpdateProjectFileLocation)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateProjectFileLocation)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProjectEnumValidValues
	{
		/*[in]*/ VSENUMPROJFLAGS grfEnumFlags;
		/*[in]*/ REFGUID rguidEnumOnlyThisType;
		/*[out]*/ IEnumHierarchies** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(GetProjectEnum)(
		/*[in]*/ VSENUMPROJFLAGS grfEnumFlags,
		/*[in]*/ REFGUID rguidEnumOnlyThisType,
		/*[out]*/ IEnumHierarchies** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjectEnum)

		VSL_CHECK_VALIDVALUE(grfEnumFlags);

		VSL_CHECK_VALIDVALUE(rguidEnumOnlyThisType);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateProjectValidValues
	{
		/*[in]*/ REFGUID rguidProjectType;
		/*[in]*/ LPCOLESTR lpszMoniker;
		/*[in]*/ LPCOLESTR lpszLocation;
		/*[in]*/ LPCOLESTR lpszName;
		/*[in]*/ VSCREATEPROJFLAGS grfCreateFlags;
		/*[in]*/ REFIID iidProject;
		/*[out,iid_is(iidProject)]*/ void** ppProject;
		HRESULT retValue;
	};

	STDMETHOD(CreateProject)(
		/*[in]*/ REFGUID rguidProjectType,
		/*[in]*/ LPCOLESTR lpszMoniker,
		/*[in]*/ LPCOLESTR lpszLocation,
		/*[in]*/ LPCOLESTR lpszName,
		/*[in]*/ VSCREATEPROJFLAGS grfCreateFlags,
		/*[in]*/ REFIID iidProject,
		/*[out,iid_is(iidProject)]*/ void** ppProject)
	{
		VSL_DEFINE_MOCK_METHOD(CreateProject)

		VSL_CHECK_VALIDVALUE(rguidProjectType);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszMoniker);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszLocation);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszName);

		VSL_CHECK_VALIDVALUE(grfCreateFlags);

		VSL_CHECK_VALIDVALUE(iidProject);

		VSL_SET_VALIDVALUE(ppProject);

		VSL_RETURN_VALIDVALUES();
	}
	struct GenerateUniqueProjectNameValidValues
	{
		/*[in]*/ LPCOLESTR lpszRoot;
		/*[out]*/ BSTR* pbstrProjectName;
		HRESULT retValue;
	};

	STDMETHOD(GenerateUniqueProjectName)(
		/*[in]*/ LPCOLESTR lpszRoot,
		/*[out]*/ BSTR* pbstrProjectName)
	{
		VSL_DEFINE_MOCK_METHOD(GenerateUniqueProjectName)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszRoot);

		VSL_SET_VALIDVALUE_BSTR(pbstrProjectName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProjectOfGuidValidValues
	{
		/*[in]*/ REFGUID rguidProjectID;
		/*[out]*/ IVsHierarchy** ppHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(GetProjectOfGuid)(
		/*[in]*/ REFGUID rguidProjectID,
		/*[out]*/ IVsHierarchy** ppHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjectOfGuid)

		VSL_CHECK_VALIDVALUE(rguidProjectID);

		VSL_SET_VALIDVALUE_INTERFACE(ppHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetGuidOfProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[out]*/ GUID* pguidProjectID;
		HRESULT retValue;
	};

	STDMETHOD(GetGuidOfProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[out]*/ GUID* pguidProjectID)
	{
		VSL_DEFINE_MOCK_METHOD(GetGuidOfProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_SET_VALIDVALUE(pguidProjectID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSolutionInfoValidValues
	{
		/*[out]*/ BSTR* pbstrSolutionDirectory;
		/*[out]*/ BSTR* pbstrSolutionFile;
		/*[out]*/ BSTR* pbstrUserOptsFile;
		HRESULT retValue;
	};

	STDMETHOD(GetSolutionInfo)(
		/*[out]*/ BSTR* pbstrSolutionDirectory,
		/*[out]*/ BSTR* pbstrSolutionFile,
		/*[out]*/ BSTR* pbstrUserOptsFile)
	{
		VSL_DEFINE_MOCK_METHOD(GetSolutionInfo)

		VSL_SET_VALIDVALUE_BSTR(pbstrSolutionDirectory);

		VSL_SET_VALIDVALUE_BSTR(pbstrSolutionFile);

		VSL_SET_VALIDVALUE_BSTR(pbstrUserOptsFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseSolutionEventsValidValues
	{
		/*[in]*/ IVsSolutionEvents* pSink;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseSolutionEvents)(
		/*[in]*/ IVsSolutionEvents* pSink,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseSolutionEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSink);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseSolutionEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseSolutionEvents)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseSolutionEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveSolutionElementValidValues
	{
		/*[in]*/ VSSLNSAVEOPTIONS grfSaveOpts;
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSCOOKIE docCookie;
		HRESULT retValue;
	};

	STDMETHOD(SaveSolutionElement)(
		/*[in]*/ VSSLNSAVEOPTIONS grfSaveOpts,
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSCOOKIE docCookie)
	{
		VSL_DEFINE_MOCK_METHOD(SaveSolutionElement)

		VSL_CHECK_VALIDVALUE(grfSaveOpts);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(docCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseSolutionElementValidValues
	{
		/*[in]*/ VSSLNCLOSEOPTIONS grfCloseOpts;
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSCOOKIE docCookie;
		HRESULT retValue;
	};

	STDMETHOD(CloseSolutionElement)(
		/*[in]*/ VSSLNCLOSEOPTIONS grfCloseOpts,
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSCOOKIE docCookie)
	{
		VSL_DEFINE_MOCK_METHOD(CloseSolutionElement)

		VSL_CHECK_VALIDVALUE(grfCloseOpts);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(docCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProjectOfProjrefValidValues
	{
		/*[in]*/ LPCOLESTR pszProjref;
		/*[out]*/ IVsHierarchy** ppHierarchy;
		/*[out]*/ BSTR* pbstrUpdatedProjref;
		/*[out]*/ VSUPDATEPROJREFREASON* puprUpdateReason;
		HRESULT retValue;
	};

	STDMETHOD(GetProjectOfProjref)(
		/*[in]*/ LPCOLESTR pszProjref,
		/*[out]*/ IVsHierarchy** ppHierarchy,
		/*[out]*/ BSTR* pbstrUpdatedProjref,
		/*[out]*/ VSUPDATEPROJREFREASON* puprUpdateReason)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjectOfProjref)

		VSL_CHECK_VALIDVALUE_STRINGW(pszProjref);

		VSL_SET_VALIDVALUE_INTERFACE(ppHierarchy);

		VSL_SET_VALIDVALUE_BSTR(pbstrUpdatedProjref);

		VSL_SET_VALIDVALUE(puprUpdateReason);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProjrefOfProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[out]*/ BSTR* pbstrProjref;
		HRESULT retValue;
	};

	STDMETHOD(GetProjrefOfProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[out]*/ BSTR* pbstrProjref)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjrefOfProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_SET_VALIDVALUE_BSTR(pbstrProjref);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProjectInfoOfProjrefValidValues
	{
		/*[in]*/ LPCOLESTR pszProjref;
		/*[in]*/ VSHPROPID propid;
		/*[out]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetProjectInfoOfProjref)(
		/*[in]*/ LPCOLESTR pszProjref,
		/*[in]*/ VSHPROPID propid,
		/*[out]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjectInfoOfProjref)

		VSL_CHECK_VALIDVALUE_STRINGW(pszProjref);

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddVirtualProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ VSADDVPFLAGS grfAddVPFlags;
		HRESULT retValue;
	};

	STDMETHOD(AddVirtualProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ VSADDVPFLAGS grfAddVPFlags)
	{
		VSL_DEFINE_MOCK_METHOD(AddVirtualProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(grfAddVPFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemOfProjrefValidValues
	{
		/*[in]*/ LPCOLESTR pszProjref;
		/*[out]*/ IVsHierarchy** ppHierarchy;
		/*[out]*/ VSITEMID* pitemid;
		/*[out]*/ BSTR* pbstrUpdatedProjref;
		/*[out]*/ VSUPDATEPROJREFREASON* puprUpdateReason;
		HRESULT retValue;
	};

	STDMETHOD(GetItemOfProjref)(
		/*[in]*/ LPCOLESTR pszProjref,
		/*[out]*/ IVsHierarchy** ppHierarchy,
		/*[out]*/ VSITEMID* pitemid,
		/*[out]*/ BSTR* pbstrUpdatedProjref,
		/*[out]*/ VSUPDATEPROJREFREASON* puprUpdateReason)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemOfProjref)

		VSL_CHECK_VALIDVALUE_STRINGW(pszProjref);

		VSL_SET_VALIDVALUE_INTERFACE(ppHierarchy);

		VSL_SET_VALIDVALUE(pitemid);

		VSL_SET_VALIDVALUE_BSTR(pbstrUpdatedProjref);

		VSL_SET_VALIDVALUE(puprUpdateReason);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProjrefOfItemValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ VSITEMID itemid;
		/*[out]*/ BSTR* pbstrProjref;
		HRESULT retValue;
	};

	STDMETHOD(GetProjrefOfItem)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ VSITEMID itemid,
		/*[out]*/ BSTR* pbstrProjref)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjrefOfItem)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE_BSTR(pbstrProjref);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemInfoOfProjrefValidValues
	{
		/*[in]*/ LPCOLESTR pszProjref;
		/*[in]*/ VSHPROPID propid;
		/*[out]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetItemInfoOfProjref)(
		/*[in]*/ LPCOLESTR pszProjref,
		/*[in]*/ VSHPROPID propid,
		/*[out]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemInfoOfProjref)

		VSL_CHECK_VALIDVALUE_STRINGW(pszProjref);

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProjectOfUniqueNameValidValues
	{
		/*[in]*/ LPCOLESTR pszUniqueName;
		/*[out]*/ IVsHierarchy** ppHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(GetProjectOfUniqueName)(
		/*[in]*/ LPCOLESTR pszUniqueName,
		/*[out]*/ IVsHierarchy** ppHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjectOfUniqueName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszUniqueName);

		VSL_SET_VALIDVALUE_INTERFACE(ppHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUniqueNameOfProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[out]*/ BSTR* pbstrUniqueName;
		HRESULT retValue;
	};

	STDMETHOD(GetUniqueNameOfProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[out]*/ BSTR* pbstrUniqueName)
	{
		VSL_DEFINE_MOCK_METHOD(GetUniqueNameOfProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_SET_VALIDVALUE_BSTR(pbstrUniqueName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPropertyValidValues
	{
		/*[in]*/ VSPROPID propid;
		/*[out]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetProperty)(
		/*[in]*/ VSPROPID propid,
		/*[out]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPropertyValidValues
	{
		/*[in]*/ VSPROPID propid;
		/*[in]*/ VARIANT var;
		HRESULT retValue;
	};

	STDMETHOD(SetProperty)(
		/*[in]*/ VSPROPID propid,
		/*[in]*/ VARIANT var)
	{
		VSL_DEFINE_MOCK_METHOD(SetProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_CHECK_VALIDVALUE(var);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenSolutionFileValidValues
	{
		/*[in]*/ VSSLNOPENOPTIONS grfOpenOpts;
		/*[in]*/ LPCOLESTR pszFilename;
		HRESULT retValue;
	};

	STDMETHOD(OpenSolutionFile)(
		/*[in]*/ VSSLNOPENOPTIONS grfOpenOpts,
		/*[in]*/ LPCOLESTR pszFilename)
	{
		VSL_DEFINE_MOCK_METHOD(OpenSolutionFile)

		VSL_CHECK_VALIDVALUE(grfOpenOpts);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryEditSolutionFileValidValues
	{
		/*[out]*/ DWORD* pdwEditResult;
		HRESULT retValue;
	};

	STDMETHOD(QueryEditSolutionFile)(
		/*[out]*/ DWORD* pdwEditResult)
	{
		VSL_DEFINE_MOCK_METHOD(QueryEditSolutionFile)

		VSL_SET_VALIDVALUE(pdwEditResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateSolutionValidValues
	{
		/*[in,unique]*/ LPCOLESTR lpszLocation;
		/*[in,unique]*/ LPCOLESTR lpszName;
		/*[in]*/ VSCREATESOLUTIONFLAGS grfCreateFlags;
		HRESULT retValue;
	};

	STDMETHOD(CreateSolution)(
		/*[in,unique]*/ LPCOLESTR lpszLocation,
		/*[in,unique]*/ LPCOLESTR lpszName,
		/*[in]*/ VSCREATESOLUTIONFLAGS grfCreateFlags)
	{
		VSL_DEFINE_MOCK_METHOD(CreateSolution)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszLocation);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszName);

		VSL_CHECK_VALIDVALUE(grfCreateFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProjectFactoryValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in,out]*/ GUID* pguidProjectType;
		/*[in]*/ LPCOLESTR pszMkProject;
		/*[out,retval]*/ IVsProjectFactory** ppProjectFactory;
		HRESULT retValue;
	};

	STDMETHOD(GetProjectFactory)(
		/*[in]*/ DWORD dwReserved,
		/*[in,out]*/ GUID* pguidProjectType,
		/*[in]*/ LPCOLESTR pszMkProject,
		/*[out,retval]*/ IVsProjectFactory** ppProjectFactory)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjectFactory)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_SET_VALIDVALUE(pguidProjectType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkProject);

		VSL_SET_VALIDVALUE_INTERFACE(ppProjectFactory);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProjectTypeGuidValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ LPCOLESTR pszMkProject;
		/*[out,retval]*/ GUID* pguidProjectType;
		HRESULT retValue;
	};

	STDMETHOD(GetProjectTypeGuid)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ LPCOLESTR pszMkProject,
		/*[out,retval]*/ GUID* pguidProjectType)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjectTypeGuid)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkProject);

		VSL_SET_VALIDVALUE(pguidProjectType);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenSolutionViaDlgValidValues
	{
		/*[in]*/ LPCOLESTR pszStartDirectory;
		/*[in]*/ BOOL fDefaultToAllProjectsFilter;
		HRESULT retValue;
	};

	STDMETHOD(OpenSolutionViaDlg)(
		/*[in]*/ LPCOLESTR pszStartDirectory,
		/*[in]*/ BOOL fDefaultToAllProjectsFilter)
	{
		VSL_DEFINE_MOCK_METHOD(OpenSolutionViaDlg)

		VSL_CHECK_VALIDVALUE_STRINGW(pszStartDirectory);

		VSL_CHECK_VALIDVALUE(fDefaultToAllProjectsFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddVirtualProjectExValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ VSADDVPFLAGS grfAddVPFlags;
		/*[in]*/ REFGUID rguidProjectID;
		HRESULT retValue;
	};

	STDMETHOD(AddVirtualProjectEx)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ VSADDVPFLAGS grfAddVPFlags,
		/*[in]*/ REFGUID rguidProjectID)
	{
		VSL_DEFINE_MOCK_METHOD(AddVirtualProjectEx)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(grfAddVPFlags);

		VSL_CHECK_VALIDVALUE(rguidProjectID);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryRenameProjectValidValues
	{
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ LPCOLESTR pszMkOldName;
		/*[in]*/ LPCOLESTR pszMkNewName;
		/*[in]*/ DWORD dwReserved;
		/*[out]*/ BOOL* pfRenameCanContinue;
		HRESULT retValue;
	};

	STDMETHOD(QueryRenameProject)(
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ LPCOLESTR pszMkOldName,
		/*[in]*/ LPCOLESTR pszMkNewName,
		/*[in]*/ DWORD dwReserved,
		/*[out]*/ BOOL* pfRenameCanContinue)
	{
		VSL_DEFINE_MOCK_METHOD(QueryRenameProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkOldName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkNewName);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_SET_VALIDVALUE(pfRenameCanContinue);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterRenameProjectValidValues
	{
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ LPCOLESTR pszMkOldName;
		/*[in]*/ LPCOLESTR pszMkNewName;
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterRenameProject)(
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ LPCOLESTR pszMkOldName,
		/*[in]*/ LPCOLESTR pszMkNewName,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterRenameProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkOldName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkNewName);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveVirtualProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ VSREMOVEVPFLAGS grfRemoveVPFlags;
		HRESULT retValue;
	};

	STDMETHOD(RemoveVirtualProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ VSREMOVEVPFLAGS grfRemoveVPFlags)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveVirtualProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(grfRemoveVPFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateNewProjectViaDlgValidValues
	{
		/*[in]*/ LPCOLESTR pszExpand;
		/*[in]*/ LPCOLESTR pszSelect;
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(CreateNewProjectViaDlg)(
		/*[in]*/ LPCOLESTR pszExpand,
		/*[in]*/ LPCOLESTR pszSelect,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(CreateNewProjectViaDlg)

		VSL_CHECK_VALIDVALUE_STRINGW(pszExpand);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSelect);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetVirtualProjectFlagsValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[out]*/ VSADDVPFLAGS* pgrfAddVPFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetVirtualProjectFlags)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[out]*/ VSADDVPFLAGS* pgrfAddVPFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetVirtualProjectFlags)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_SET_VALIDVALUE(pgrfAddVPFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GenerateNextDefaultProjectNameValidValues
	{
		/*[in]*/ LPCOLESTR pszBaseName;
		/*[in]*/ LPCOLESTR pszLocation;
		/*[out]*/ BSTR* pbstrProjectName;
		HRESULT retValue;
	};

	STDMETHOD(GenerateNextDefaultProjectName)(
		/*[in]*/ LPCOLESTR pszBaseName,
		/*[in]*/ LPCOLESTR pszLocation,
		/*[out]*/ BSTR* pbstrProjectName)
	{
		VSL_DEFINE_MOCK_METHOD(GenerateNextDefaultProjectName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszBaseName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszLocation);

		VSL_SET_VALIDVALUE_BSTR(pbstrProjectName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProjectFilesInSolutionValidValues
	{
		/*[in]*/ VSGETPROJFILESFLAGS grfGetOpts;
		/*[in]*/ ULONG cProjects;
		/*[out,size_is(cProjects),length_is(*pcProjectsFetched)]*/ BSTR* rgbstrProjectNames;
		/*[out]*/ ULONG* pcProjectsFetched;
		HRESULT retValue;
	};

	STDMETHOD(GetProjectFilesInSolution)(
		/*[in]*/ VSGETPROJFILESFLAGS grfGetOpts,
		/*[in]*/ ULONG cProjects,
		/*[out,size_is(cProjects),length_is(*pcProjectsFetched)]*/ BSTR* rgbstrProjectNames,
		/*[out]*/ ULONG* pcProjectsFetched)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjectFilesInSolution)

		VSL_CHECK_VALIDVALUE(grfGetOpts);

		VSL_CHECK_VALIDVALUE(cProjects);

		VSL_SET_VALIDVALUE_MEMCPY(rgbstrProjectNames, cProjects*sizeof(rgbstrProjectNames[0]), *(validValues.pcProjectsFetched)*sizeof(validValues.rgbstrProjectNames[0]));

		VSL_SET_VALIDVALUE(pcProjectsFetched);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanCreateNewProjectAtLocationValidValues
	{
		/*[in]*/ BOOL fCreateNewSolution;
		/*[in]*/ LPCOLESTR pszFullProjectFilePath;
		/*[out]*/ BOOL* pfCanCreate;
		HRESULT retValue;
	};

	STDMETHOD(CanCreateNewProjectAtLocation)(
		/*[in]*/ BOOL fCreateNewSolution,
		/*[in]*/ LPCOLESTR pszFullProjectFilePath,
		/*[out]*/ BOOL* pfCanCreate)
	{
		VSL_DEFINE_MOCK_METHOD(CanCreateNewProjectAtLocation)

		VSL_CHECK_VALIDVALUE(fCreateNewSolution);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFullProjectFilePath);

		VSL_SET_VALIDVALUE(pfCanCreate);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSOLUTION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
