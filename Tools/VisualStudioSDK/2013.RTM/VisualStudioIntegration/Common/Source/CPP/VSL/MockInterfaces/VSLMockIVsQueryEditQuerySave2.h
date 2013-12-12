/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSQUERYEDITQUERYSAVE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSQUERYEDITQUERYSAVE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsQueryEditQuerySave2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsQueryEditQuerySave2NotImpl :
	public IVsQueryEditQuerySave2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsQueryEditQuerySave2NotImpl)

public:

	typedef IVsQueryEditQuerySave2 Interface;

	STDMETHOD(QueryEditFiles)(
		/*[in]*/ VSQueryEditFlags /*rgfQueryEdit*/,
		/*[in]*/ int /*cFiles*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgpszMkDocuments*/,
		/*[in,size_is(cFiles)]*/ const VSQEQSFlags[] /*rgrgf*/,
		/*[in,size_is(cFiles)]*/ const VSQEQS_FILE_ATTRIBUTE_DATA[] /*rgFileInfo*/,
		/*[out]*/ VSQueryEditResult* /*pfEditVerdict*/,
		/*[out]*/ VSQueryEditResultFlags* /*prgfMoreInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QuerySaveFiles)(
		/*[in]*/ VSQuerySaveFlags /*rgfQuerySave*/,
		/*[in]*/ int /*cFiles*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgpszMkDocuments*/,
		/*[in,size_is(cFiles)]*/ const VSQEQSFlags[] /*rgrgf*/,
		/*[in,size_is(cFiles)]*/ const VSQEQS_FILE_ATTRIBUTE_DATA[] /*rgFileInfo*/,
		/*[out,retval]*/ VSQuerySaveResult* /*pdwQSResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QuerySaveFile)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ VSQEQSFlags /*rgf*/,
		/*[in]*/ const VSQEQS_FILE_ATTRIBUTE_DATA* /*pFileInfo*/,
		/*[out,retval]*/ VSQuerySaveResult* /*pdwQSResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeclareReloadableFile)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ VSQEQSFlags /*rgf*/,
		/*[in]*/ const VSQEQS_FILE_ATTRIBUTE_DATA* /*pFileInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeclareUnreloadableFile)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ VSQEQSFlags /*rgf*/,
		/*[in]*/ const VSQEQS_FILE_ATTRIBUTE_DATA* /*pFileInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterSaveUnreloadableFile)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ VSQEQSFlags /*rgf*/,
		/*[in]*/ const VSQEQS_FILE_ATTRIBUTE_DATA* /*pFileInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsReloadable)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[out,retval]*/ BOOL* /*pbResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BeginQuerySaveBatch)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EndQuerySaveBatch)()VSL_STDMETHOD_NOTIMPL
};

class IVsQueryEditQuerySave2MockImpl :
	public IVsQueryEditQuerySave2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsQueryEditQuerySave2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsQueryEditQuerySave2MockImpl)

	typedef IVsQueryEditQuerySave2 Interface;
	struct QueryEditFilesValidValues
	{
		/*[in]*/ VSQueryEditFlags rgfQueryEdit;
		/*[in]*/ int cFiles;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgpszMkDocuments;
		/*[in,size_is(cFiles)]*/ VSQEQSFlags* rgrgf;
		/*[in,size_is(cFiles)]*/ VSQEQS_FILE_ATTRIBUTE_DATA* rgFileInfo;
		/*[out]*/ VSQueryEditResult* pfEditVerdict;
		/*[out]*/ VSQueryEditResultFlags* prgfMoreInfo;
		HRESULT retValue;
	};

	STDMETHOD(QueryEditFiles)(
		/*[in]*/ VSQueryEditFlags rgfQueryEdit,
		/*[in]*/ int cFiles,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgpszMkDocuments[],
		/*[in,size_is(cFiles)]*/ const VSQEQSFlags rgrgf[],
		/*[in,size_is(cFiles)]*/ const VSQEQS_FILE_ATTRIBUTE_DATA rgFileInfo[],
		/*[out]*/ VSQueryEditResult* pfEditVerdict,
		/*[out]*/ VSQueryEditResultFlags* prgfMoreInfo)
	{
		VSL_DEFINE_MOCK_METHOD(QueryEditFiles)

		VSL_CHECK_VALIDVALUE(rgfQueryEdit);

		VSL_CHECK_VALIDVALUE(cFiles);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszMkDocuments, cFiles*sizeof(rgpszMkDocuments[0]), validValues.cFiles*sizeof(validValues.rgpszMkDocuments[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgrgf, cFiles*sizeof(rgrgf[0]), validValues.cFiles*sizeof(validValues.rgrgf[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFileInfo, cFiles*sizeof(rgFileInfo[0]), validValues.cFiles*sizeof(validValues.rgFileInfo[0]));

		VSL_SET_VALIDVALUE(pfEditVerdict);

		VSL_SET_VALIDVALUE(prgfMoreInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct QuerySaveFilesValidValues
	{
		/*[in]*/ VSQuerySaveFlags rgfQuerySave;
		/*[in]*/ int cFiles;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgpszMkDocuments;
		/*[in,size_is(cFiles)]*/ VSQEQSFlags* rgrgf;
		/*[in,size_is(cFiles)]*/ VSQEQS_FILE_ATTRIBUTE_DATA* rgFileInfo;
		/*[out,retval]*/ VSQuerySaveResult* pdwQSResult;
		HRESULT retValue;
	};

	STDMETHOD(QuerySaveFiles)(
		/*[in]*/ VSQuerySaveFlags rgfQuerySave,
		/*[in]*/ int cFiles,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgpszMkDocuments[],
		/*[in,size_is(cFiles)]*/ const VSQEQSFlags rgrgf[],
		/*[in,size_is(cFiles)]*/ const VSQEQS_FILE_ATTRIBUTE_DATA rgFileInfo[],
		/*[out,retval]*/ VSQuerySaveResult* pdwQSResult)
	{
		VSL_DEFINE_MOCK_METHOD(QuerySaveFiles)

		VSL_CHECK_VALIDVALUE(rgfQuerySave);

		VSL_CHECK_VALIDVALUE(cFiles);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszMkDocuments, cFiles*sizeof(rgpszMkDocuments[0]), validValues.cFiles*sizeof(validValues.rgpszMkDocuments[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgrgf, cFiles*sizeof(rgrgf[0]), validValues.cFiles*sizeof(validValues.rgrgf[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgFileInfo, cFiles*sizeof(rgFileInfo[0]), validValues.cFiles*sizeof(validValues.rgFileInfo[0]));

		VSL_SET_VALIDVALUE(pdwQSResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct QuerySaveFileValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ VSQEQSFlags rgf;
		/*[in]*/ VSQEQS_FILE_ATTRIBUTE_DATA* pFileInfo;
		/*[out,retval]*/ VSQuerySaveResult* pdwQSResult;
		HRESULT retValue;
	};

	STDMETHOD(QuerySaveFile)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ VSQEQSFlags rgf,
		/*[in]*/ const VSQEQS_FILE_ATTRIBUTE_DATA* pFileInfo,
		/*[out,retval]*/ VSQuerySaveResult* pdwQSResult)
	{
		VSL_DEFINE_MOCK_METHOD(QuerySaveFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(rgf);

		VSL_CHECK_VALIDVALUE_POINTER(pFileInfo);

		VSL_SET_VALIDVALUE(pdwQSResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeclareReloadableFileValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ VSQEQSFlags rgf;
		/*[in]*/ VSQEQS_FILE_ATTRIBUTE_DATA* pFileInfo;
		HRESULT retValue;
	};

	STDMETHOD(DeclareReloadableFile)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ VSQEQSFlags rgf,
		/*[in]*/ const VSQEQS_FILE_ATTRIBUTE_DATA* pFileInfo)
	{
		VSL_DEFINE_MOCK_METHOD(DeclareReloadableFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(rgf);

		VSL_CHECK_VALIDVALUE_POINTER(pFileInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeclareUnreloadableFileValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ VSQEQSFlags rgf;
		/*[in]*/ VSQEQS_FILE_ATTRIBUTE_DATA* pFileInfo;
		HRESULT retValue;
	};

	STDMETHOD(DeclareUnreloadableFile)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ VSQEQSFlags rgf,
		/*[in]*/ const VSQEQS_FILE_ATTRIBUTE_DATA* pFileInfo)
	{
		VSL_DEFINE_MOCK_METHOD(DeclareUnreloadableFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(rgf);

		VSL_CHECK_VALIDVALUE_POINTER(pFileInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterSaveUnreloadableFileValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ VSQEQSFlags rgf;
		/*[in]*/ VSQEQS_FILE_ATTRIBUTE_DATA* pFileInfo;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterSaveUnreloadableFile)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ VSQEQSFlags rgf,
		/*[in]*/ const VSQEQS_FILE_ATTRIBUTE_DATA* pFileInfo)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterSaveUnreloadableFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(rgf);

		VSL_CHECK_VALIDVALUE_POINTER(pFileInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsReloadableValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[out,retval]*/ BOOL* pbResult;
		HRESULT retValue;
	};

	STDMETHOD(IsReloadable)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[out,retval]*/ BOOL* pbResult)
	{
		VSL_DEFINE_MOCK_METHOD(IsReloadable)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_SET_VALIDVALUE(pbResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct BeginQuerySaveBatchValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(BeginQuerySaveBatch)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(BeginQuerySaveBatch)

		VSL_RETURN_VALIDVALUES();
	}
	struct EndQuerySaveBatchValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(EndQuerySaveBatch)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(EndQuerySaveBatch)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSQUERYEDITQUERYSAVE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
