/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLSHORTNAMEDEFINES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLSHORTNAMEDEFINES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

// Short versions for brevity in client code, so long as the shortname isn't already defined.
// If this causes conflicts, just include the necessary definition before this header file.

// VSLErrorHandlers.h

#ifndef CHKEX
#define CHKEX VSL_CHECKBOOLEAN_EX
#endif

#ifndef CHK
#define CHK VSL_CHECKBOOLEAN
#endif

#ifndef CHKBOOLEX
#define CHKBOOLEX VSL_CHECKBOOL_EX
#endif

#ifndef CHKBOOL
#define CHKBOOL VSL_CHECKBOOL
#endif

#ifndef CHKBOOLGLEEX
#define CHKBOOLGLEEX VSL_CHECKBOOL_GLE_EX
#endif

#ifndef CHKBOOLGLE
#define CHKBOOLGLE VSL_CHECKBOOL_GLE
#endif

#ifndef CHKHANDLEGLEEX
#define CHKHANDLEGLEEX VSL_CHECKHANDLE_GLE_EX
#endif

#ifndef CHKHANDLEGLE
#define CHKHANDLEGLE VSL_CHECKHANDLE_GLE
#endif

#ifndef CHKHREX
#define CHKHREX VSL_CHECKHRESULT_EX
#endif

#ifndef CHKHR
#define CHKHR VSL_CHECKHRESULT
#endif

#ifndef ERRHREX
#define ERRHREX VSL_CREATE_ERROR_HRESULT_EX
#endif

#ifndef ERRHR
#define ERRHR VSL_CREATE_ERROR_HRESULT
#endif

#ifndef CHKW32EX
#define CHKW32EX VSL_CHECKWIN32_EX
#endif

#ifndef CHKW32
#define CHKW32 VSL_CHECKWIN32
#endif

#ifndef ERRW32EX
#define ERRW32EX VSL_CREATE_ERROR_WIN32_EX
#endif

#ifndef ERRW32
#define ERRW32 VSL_CREATE_ERROR_WIN32
#endif

#ifndef CHKPTREX
#define CHKPTREX VSL_CHECKPOINTER_EX
#endif

#ifndef CHKPTR
#define CHKPTR VSL_CHECKPOINTER
#endif

#ifndef CHKPTRDEF
#define CHKPTRDEF VSL_CHECKPOINTER_DEFAULT 
#endif

// VSLUnitTest.h

#ifndef UTHCHKEX
#define UTHCHKEX VSL_UTHELPERCHECK_EX
#endif

#ifndef UTHCHK
#define UTHCHK VSL_UTHELPERCHECK
#endif

#ifndef UTCHKEX
#define UTCHKEX VSL_UTCHECK_EX
#endif

#ifndef UTCHK
#define UTCHK VSL_UTCHECK
#endif

#ifndef UTRUN
#define UTRUN VSL_UTRUN
#endif

#ifndef CREATEVV
#define CREATEVV VSL_CREATE_VALIDVALUES
#endif

#ifndef PUSHVV
#define PUSHVV VSL_PUSH_VALIDVALUES
#endif

#ifndef SETVV
#define SETVV VSL_SET_VALIDVALUES
#endif

#ifndef STARTVV
#define	STARTVV VSL_START_VALIDVALUES_STATIC
#endif

#ifndef ENDVVPUSH
#define	ENDVVPUSH VSL_END_VALIDVALUES_PUSH
#endif

#ifndef ENDVVSET
#define	ENDVVSET VSL_END_VALIDVALUES_SET
#endif

#ifndef PUSHVV1
#define PUSHVV1 VSL_PUSH_VALIDVALUES1
#endif

#ifndef PUSHVV2
#define PUSHVV2 VSL_PUSH_VALIDVALUES2
#endif

#ifndef PUSHVV3
#define PUSHVV3 VSL_PUSH_VALIDVALUES3
#endif

#ifndef PUSHVV4
#define PUSHVV4 VSL_PUSH_VALIDVALUES4
#endif

#ifndef SETVV1
#define SETVV1 VSL_SET_VALIDVALUES1
#endif

#ifndef SETVV2
#define SETVV2 VSL_SET_VALIDVALUES2
#endif

#ifndef SETVV3
#define SETVV3 VSL_SET_VALIDVALUES3
#endif

#ifndef SETVV4
#define SETVV4 VSL_SET_VALIDVALUES4
#endif

#ifndef VVNOT0
#define VVNOT0 VSL_VALIDVALUE_SIMPLE_VERIFY
#endif

#ifndef WASCALLED
#define WASCALLED VSL_WAS_METHOD_CALLED
#endif

#ifndef WASCALLED0
#define WASCALLED0 VSL_WAS_METHODNOARGS_CALLED
#endif

// VSLPackage.h

#ifndef VSQS
#define VSQS VsIServiceProviderUtilities<>::QueryService
#endif

#ifndef VSQCS
#define VSQCS(guidService, Interface_T, ppService) VsIServiceProviderUtilities<>::QueryCachedService<Interface_T, guidService>(ppService)
#endif

#endif // VSLSHORTNAMEDEFINES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
