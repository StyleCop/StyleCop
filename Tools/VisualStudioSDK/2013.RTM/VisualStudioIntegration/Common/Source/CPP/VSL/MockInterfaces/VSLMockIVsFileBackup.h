/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFILEBACKUP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFILEBACKUP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsFileBackupNotImpl :
	public IVsFileBackup
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFileBackupNotImpl)

public:

	typedef IVsFileBackup Interface;

	STDMETHOD(BackupFile)(
		/*[in]*/ LPCOLESTR /*pszBackupFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsBackupFileObsolete)(
		/*[out]*/ BOOL* /*pbObsolete*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFileBackupMockImpl :
	public IVsFileBackup,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFileBackupMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFileBackupMockImpl)

	typedef IVsFileBackup Interface;
	struct BackupFileValidValues
	{
		/*[in]*/ LPCOLESTR pszBackupFileName;
		HRESULT retValue;
	};

	STDMETHOD(BackupFile)(
		/*[in]*/ LPCOLESTR pszBackupFileName)
	{
		VSL_DEFINE_MOCK_METHOD(BackupFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pszBackupFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsBackupFileObsoleteValidValues
	{
		/*[out]*/ BOOL* pbObsolete;
		HRESULT retValue;
	};

	STDMETHOD(IsBackupFileObsolete)(
		/*[out]*/ BOOL* pbObsolete)
	{
		VSL_DEFINE_MOCK_METHOD(IsBackupFileObsolete)

		VSL_SET_VALIDVALUE(pbObsolete);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFILEBACKUP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
