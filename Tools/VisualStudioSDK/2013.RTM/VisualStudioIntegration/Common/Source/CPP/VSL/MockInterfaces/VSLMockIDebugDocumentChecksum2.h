/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGDOCUMENTCHECKSUM2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGDOCUMENTCHECKSUM2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugDocumentChecksum2NotImpl :
	public IDebugDocumentChecksum2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDocumentChecksum2NotImpl)

public:

	typedef IDebugDocumentChecksum2 Interface;

	STDMETHOD(GetChecksumAndAlgorithmId)(
		/*[out]*/ GUID* /*pRetVal*/,
		/*[in]*/ ULONG /*cMaxBytes*/,
		/*[out,length_is(*pcNumBytes),size_is(cMaxBytes)]*/ BYTE* /*pChecksum*/,
		/*[out]*/ ULONG* /*pcNumBytes*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugDocumentChecksum2MockImpl :
	public IDebugDocumentChecksum2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDocumentChecksum2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugDocumentChecksum2MockImpl)

	typedef IDebugDocumentChecksum2 Interface;
	struct GetChecksumAndAlgorithmIdValidValues
	{
		/*[out]*/ GUID* pRetVal;
		/*[in]*/ ULONG cMaxBytes;
		/*[out,length_is(*pcNumBytes),size_is(cMaxBytes)]*/ BYTE* pChecksum;
		/*[out]*/ ULONG* pcNumBytes;
		HRESULT retValue;
	};

	STDMETHOD(GetChecksumAndAlgorithmId)(
		/*[out]*/ GUID* pRetVal,
		/*[in]*/ ULONG cMaxBytes,
		/*[out,length_is(*pcNumBytes),size_is(cMaxBytes)]*/ BYTE* pChecksum,
		/*[out]*/ ULONG* pcNumBytes)
	{
		VSL_DEFINE_MOCK_METHOD(GetChecksumAndAlgorithmId)

		VSL_SET_VALIDVALUE(pRetVal);

		VSL_CHECK_VALIDVALUE(cMaxBytes);

		VSL_SET_VALIDVALUE_MEMCPY(pChecksum, cMaxBytes*sizeof(pChecksum[0]), *(validValues.pcNumBytes)*sizeof(validValues.pChecksum[0]));

		VSL_SET_VALIDVALUE(pcNumBytes);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGDOCUMENTCHECKSUM2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
