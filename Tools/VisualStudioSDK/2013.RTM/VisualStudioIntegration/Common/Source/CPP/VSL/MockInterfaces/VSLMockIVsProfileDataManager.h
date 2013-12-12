/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROFILEDATAMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROFILEDATAMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProfileDataManagerNotImpl :
	public IVsProfileDataManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProfileDataManagerNotImpl)

public:

	typedef IVsProfileDataManager Interface;

	STDMETHOD(LastResetPoint)(
		/*[out]*/ BSTR* /*pbstrResetFilename*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSettingsFiles)(
		/*[in]*/ VSPROFILELOCATIONS /*fileLocations*/,
		/*[out]*/ IVsProfileSettingsFileCollection** /*ppCollection*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDefaultSettingsLocation)(
		/*[out]*/ BSTR* /*pbstrSettingsLocation*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUniqueExportFileName)(
		/*[in]*/ VSPROFILEGETFILENAME /*flags*/,
		/*[out]*/ BSTR* /*pbstrExportFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSettingsFileExtension)(
		/*[out]*/ BSTR* /*pbstrSettingsFileExtension*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSettingsForExport)(
		/*[out]*/ IVsProfileSettingsTree** /*ppSettingsTree*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ExportSettings)(
		/*[in]*/ BSTR /*bstrFilePath*/,
		/*[in]*/ IVsProfileSettingsTree* /*pSettingsTree*/,
		/*[out]*/ IVsSettingsErrorInformation** /*ppsettingsErrorInformation*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ImportSettings)(
		/*[in]*/ IVsProfileSettingsTree* /*pSettingsTree*/,
		/*[out]*/ IVsSettingsErrorInformation** /*ppsettingsErrorInformation*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ResetSettings)(
		/*[in]*/ IVsProfileSettingsFileInfo* /*pFileInfo*/,
		/*[out]*/ IVsSettingsErrorInformation** /*ppsettingsErrorInformation*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ExportAllSettings)(
		/*[in]*/ BSTR /*bstrFilePath*/,
		/*[out]*/ IVsSettingsErrorInformation** /*ppsettingsErrorInformation*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AutoSaveAllSettings)(
		/*[out]*/ IVsSettingsErrorInformation** /*ppsettingsErrorInformation*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CheckUpdateTeamSettings)(
		/*[in]*/ VSPROFILETEAMSETTINGSFLAGS /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReportTeamSettingsChanged)(
		/*[in]*/ VSPROFILETEAMSETTINGSCHANGEDFLAGS /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowProfilesUI)()VSL_STDMETHOD_NOTIMPL
};

class IVsProfileDataManagerMockImpl :
	public IVsProfileDataManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProfileDataManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProfileDataManagerMockImpl)

	typedef IVsProfileDataManager Interface;
	struct LastResetPointValidValues
	{
		/*[out]*/ BSTR* pbstrResetFilename;
		HRESULT retValue;
	};

	STDMETHOD(LastResetPoint)(
		/*[out]*/ BSTR* pbstrResetFilename)
	{
		VSL_DEFINE_MOCK_METHOD(LastResetPoint)

		VSL_SET_VALIDVALUE_BSTR(pbstrResetFilename);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSettingsFilesValidValues
	{
		/*[in]*/ VSPROFILELOCATIONS fileLocations;
		/*[out]*/ IVsProfileSettingsFileCollection** ppCollection;
		HRESULT retValue;
	};

	STDMETHOD(GetSettingsFiles)(
		/*[in]*/ VSPROFILELOCATIONS fileLocations,
		/*[out]*/ IVsProfileSettingsFileCollection** ppCollection)
	{
		VSL_DEFINE_MOCK_METHOD(GetSettingsFiles)

		VSL_CHECK_VALIDVALUE(fileLocations);

		VSL_SET_VALIDVALUE_INTERFACE(ppCollection);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDefaultSettingsLocationValidValues
	{
		/*[out]*/ BSTR* pbstrSettingsLocation;
		HRESULT retValue;
	};

	STDMETHOD(GetDefaultSettingsLocation)(
		/*[out]*/ BSTR* pbstrSettingsLocation)
	{
		VSL_DEFINE_MOCK_METHOD(GetDefaultSettingsLocation)

		VSL_SET_VALIDVALUE_BSTR(pbstrSettingsLocation);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUniqueExportFileNameValidValues
	{
		/*[in]*/ VSPROFILEGETFILENAME flags;
		/*[out]*/ BSTR* pbstrExportFile;
		HRESULT retValue;
	};

	STDMETHOD(GetUniqueExportFileName)(
		/*[in]*/ VSPROFILEGETFILENAME flags,
		/*[out]*/ BSTR* pbstrExportFile)
	{
		VSL_DEFINE_MOCK_METHOD(GetUniqueExportFileName)

		VSL_CHECK_VALIDVALUE(flags);

		VSL_SET_VALIDVALUE_BSTR(pbstrExportFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSettingsFileExtensionValidValues
	{
		/*[out]*/ BSTR* pbstrSettingsFileExtension;
		HRESULT retValue;
	};

	STDMETHOD(GetSettingsFileExtension)(
		/*[out]*/ BSTR* pbstrSettingsFileExtension)
	{
		VSL_DEFINE_MOCK_METHOD(GetSettingsFileExtension)

		VSL_SET_VALIDVALUE_BSTR(pbstrSettingsFileExtension);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSettingsForExportValidValues
	{
		/*[out]*/ IVsProfileSettingsTree** ppSettingsTree;
		HRESULT retValue;
	};

	STDMETHOD(GetSettingsForExport)(
		/*[out]*/ IVsProfileSettingsTree** ppSettingsTree)
	{
		VSL_DEFINE_MOCK_METHOD(GetSettingsForExport)

		VSL_SET_VALIDVALUE_INTERFACE(ppSettingsTree);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExportSettingsValidValues
	{
		/*[in]*/ BSTR bstrFilePath;
		/*[in]*/ IVsProfileSettingsTree* pSettingsTree;
		/*[out]*/ IVsSettingsErrorInformation** ppsettingsErrorInformation;
		HRESULT retValue;
	};

	STDMETHOD(ExportSettings)(
		/*[in]*/ BSTR bstrFilePath,
		/*[in]*/ IVsProfileSettingsTree* pSettingsTree,
		/*[out]*/ IVsSettingsErrorInformation** ppsettingsErrorInformation)
	{
		VSL_DEFINE_MOCK_METHOD(ExportSettings)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFilePath);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSettingsTree);

		VSL_SET_VALIDVALUE_INTERFACE(ppsettingsErrorInformation);

		VSL_RETURN_VALIDVALUES();
	}
	struct ImportSettingsValidValues
	{
		/*[in]*/ IVsProfileSettingsTree* pSettingsTree;
		/*[out]*/ IVsSettingsErrorInformation** ppsettingsErrorInformation;
		HRESULT retValue;
	};

	STDMETHOD(ImportSettings)(
		/*[in]*/ IVsProfileSettingsTree* pSettingsTree,
		/*[out]*/ IVsSettingsErrorInformation** ppsettingsErrorInformation)
	{
		VSL_DEFINE_MOCK_METHOD(ImportSettings)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSettingsTree);

		VSL_SET_VALIDVALUE_INTERFACE(ppsettingsErrorInformation);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResetSettingsValidValues
	{
		/*[in]*/ IVsProfileSettingsFileInfo* pFileInfo;
		/*[out]*/ IVsSettingsErrorInformation** ppsettingsErrorInformation;
		HRESULT retValue;
	};

	STDMETHOD(ResetSettings)(
		/*[in]*/ IVsProfileSettingsFileInfo* pFileInfo,
		/*[out]*/ IVsSettingsErrorInformation** ppsettingsErrorInformation)
	{
		VSL_DEFINE_MOCK_METHOD(ResetSettings)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pFileInfo);

		VSL_SET_VALIDVALUE_INTERFACE(ppsettingsErrorInformation);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExportAllSettingsValidValues
	{
		/*[in]*/ BSTR bstrFilePath;
		/*[out]*/ IVsSettingsErrorInformation** ppsettingsErrorInformation;
		HRESULT retValue;
	};

	STDMETHOD(ExportAllSettings)(
		/*[in]*/ BSTR bstrFilePath,
		/*[out]*/ IVsSettingsErrorInformation** ppsettingsErrorInformation)
	{
		VSL_DEFINE_MOCK_METHOD(ExportAllSettings)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFilePath);

		VSL_SET_VALIDVALUE_INTERFACE(ppsettingsErrorInformation);

		VSL_RETURN_VALIDVALUES();
	}
	struct AutoSaveAllSettingsValidValues
	{
		/*[out]*/ IVsSettingsErrorInformation** ppsettingsErrorInformation;
		HRESULT retValue;
	};

	STDMETHOD(AutoSaveAllSettings)(
		/*[out]*/ IVsSettingsErrorInformation** ppsettingsErrorInformation)
	{
		VSL_DEFINE_MOCK_METHOD(AutoSaveAllSettings)

		VSL_SET_VALIDVALUE_INTERFACE(ppsettingsErrorInformation);

		VSL_RETURN_VALIDVALUES();
	}
	struct CheckUpdateTeamSettingsValidValues
	{
		/*[in]*/ VSPROFILETEAMSETTINGSFLAGS dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(CheckUpdateTeamSettings)(
		/*[in]*/ VSPROFILETEAMSETTINGSFLAGS dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(CheckUpdateTeamSettings)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReportTeamSettingsChangedValidValues
	{
		/*[in]*/ VSPROFILETEAMSETTINGSCHANGEDFLAGS dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(ReportTeamSettingsChanged)(
		/*[in]*/ VSPROFILETEAMSETTINGSCHANGEDFLAGS dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(ReportTeamSettingsChanged)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowProfilesUIValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ShowProfilesUI)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ShowProfilesUI)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROFILEDATAMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
