// Guids.c
//

#include "initguid.h"
#include "Guids.h"
#include <VSShellInterfaces.h>

#define _MIDL_USE_GUIDDEF_ // Necessary to build without compilation errors
#include "%ProjectName%.c"
%EditorStart%
// There is no library that defines the GUIDs for the interfaces defined inside
// TOM.h, so we have to define here the GUIDs that are used inside our code.
// You can find these GUIDs looking at the definition of the interfaces in TOM.h.
DEFINE_GUID(IID_ITextDocument,
    0x8CC497C0, 0xA1DF, 0x11ce, 0x80, 0x98, 0x00, 0xAA, 0x00, 0x47, 0xBE, 0x5D);
%EditorEnd%
