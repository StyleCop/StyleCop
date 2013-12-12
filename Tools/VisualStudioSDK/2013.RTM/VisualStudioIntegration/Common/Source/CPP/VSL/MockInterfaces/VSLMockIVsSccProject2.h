/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSCCPROJECT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSCCPROJECT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsSccProject2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSccProject2NotImpl :
	public IVsSccProject2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccProject2NotImpl)

public:

	typedef IVsSccProject2 Interface;

	STDMETHOD(SccGlyphChanged)(
		/*[in]*/ int /*cAffectedNodes*/,
		/*[in,size_is(cAffectedNodes)]*/ const VSITEMID[] /*rgitemidAffectedNodes*/,
		/*[in,size_is(cAffectedNodes)]*/ const VsStateIcon[] /*rgsiNewGlyphs*/,
		/*[in,size_is(cAffectedNodes)]*/ const DWORD[] /*rgdwNewSccStatus*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSccLocation)(
		/*[in]*/ LPCOLESTR /*pszSccProjectName*/,
		/*[in]*/ LPCOLESTR /*pszSccAuxPath*/,
		/*[in]*/ LPCOLESTR /*pszSccLocalPath*/,
		/*[in]*/ LPCOLESTR /*pszSccProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSccFiles)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[out]*/ CALPOLESTR* /*pCaStringsOut*/,
		/*[out]*/ CADWORD* /*pCaFlagsOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSccSpecialFiles)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ LPCOLESTR /*pszSccFile*/,
		/*[out]*/ CALPOLESTR* /*pCaStringsOut*/,
		/*[out]*/ CADWORD* /*pCaFlagsOut*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSccProject2MockImpl :
	public IVsSccProject2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccProject2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSccProject2MockImpl)

	typedef IVsSccProject2 Interface;
	struct SccGlyphChangedValidValues
	{
		/*[in]*/ int cAffectedNodes;
		/*[in,size_is(cAffectedNodes)]*/ VSITEMID* rgitemidAffectedNodes;
		/*[in,size_is(cAffectedNodes)]*/ VsStateIcon* rgsiNewGlyphs;
		/*[in,size_is(cAffectedNodes)]*/ DWORD* rgdwNewSccStatus;
		HRESULT retValue;
	};

	STDMETHOD(SccGlyphChanged)(
		/*[in]*/ int cAffectedNodes,
		/*[in,size_is(cAffectedNodes)]*/ const VSITEMID rgitemidAffectedNodes[],
		/*[in,size_is(cAffectedNodes)]*/ const VsStateIcon rgsiNewGlyphs[],
		/*[in,size_is(cAffectedNodes)]*/ const DWORD rgdwNewSccStatus[])
	{
		VSL_DEFINE_MOCK_METHOD(SccGlyphChanged)

		VSL_CHECK_VALIDVALUE(cAffectedNodes);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgitemidAffectedNodes, cAffectedNodes*sizeof(rgitemidAffectedNodes[0]), validValues.cAffectedNodes*sizeof(validValues.rgitemidAffectedNodes[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgsiNewGlyphs, cAffectedNodes*sizeof(rgsiNewGlyphs[0]), validValues.cAffectedNodes*sizeof(validValues.rgsiNewGlyphs[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgdwNewSccStatus, cAffectedNodes*sizeof(rgdwNewSccStatus[0]), validValues.cAffectedNodes*sizeof(validValues.rgdwNewSccStatus[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSccLocationValidValues
	{
		/*[in]*/ LPCOLESTR pszSccProjectName;
		/*[in]*/ LPCOLESTR pszSccAuxPath;
		/*[in]*/ LPCOLESTR pszSccLocalPath;
		/*[in]*/ LPCOLESTR pszSccProvider;
		HRESULT retValue;
	};

	STDMETHOD(SetSccLocation)(
		/*[in]*/ LPCOLESTR pszSccProjectName,
		/*[in]*/ LPCOLESTR pszSccAuxPath,
		/*[in]*/ LPCOLESTR pszSccLocalPath,
		/*[in]*/ LPCOLESTR pszSccProvider)
	{
		VSL_DEFINE_MOCK_METHOD(SetSccLocation)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSccProjectName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSccAuxPath);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSccLocalPath);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSccProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSccFilesValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[out]*/ CALPOLESTR* pCaStringsOut;
		/*[out]*/ CADWORD* pCaFlagsOut;
		HRESULT retValue;
	};

	STDMETHOD(GetSccFiles)(
		/*[in]*/ VSITEMID itemid,
		/*[out]*/ CALPOLESTR* pCaStringsOut,
		/*[out]*/ CADWORD* pCaFlagsOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetSccFiles)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE(pCaStringsOut);

		VSL_SET_VALIDVALUE(pCaFlagsOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSccSpecialFilesValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ LPCOLESTR pszSccFile;
		/*[out]*/ CALPOLESTR* pCaStringsOut;
		/*[out]*/ CADWORD* pCaFlagsOut;
		HRESULT retValue;
	};

	STDMETHOD(GetSccSpecialFiles)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ LPCOLESTR pszSccFile,
		/*[out]*/ CALPOLESTR* pCaStringsOut,
		/*[out]*/ CADWORD* pCaFlagsOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetSccSpecialFiles)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSccFile);

		VSL_SET_VALIDVALUE(pCaStringsOut);

		VSL_SET_VALIDVALUE(pCaFlagsOut);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSCCPROJECT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
