// CommandIds.h
// Command IDs used in defining command bars
//

// do not use #pragma once - used by ctc compiler
#ifndef __COMMANDIDS_H_
#define __COMMANDIDS_H_

///////////////////////////////////////////////////////////////////////////////
// Menu IDs
%EditorStart%
#define IDM_TLB_RTF                0x0001                // toolbar
#define IDMX_RTF                0x0002                // context menu
#define IDM_RTFMNU_ALIGN            0x0004
#define IDM_RTFMNU_SIZE                0x0005
%EditorEnd%


///////////////////////////////////////////////////////////////////////////////
// Menu Group IDs
%EditorStart%
#define IDG_RTF_FMT_FONT1            0x1000
#define IDG_RTF_FMT_FONT2            0x1001
#define IDG_RTF_FMT_INDENT            0x1002
#define IDG_RTF_FMT_BULLET            0x1003

#define IDG_RTF_TLB_FONT1            0x1004
#define IDG_RTF_TLB_FONT2            0x1005
#define IDG_RTF_TLB_INDENT            0x1006
#define IDG_RTF_TLB_BULLET            0x1007
#define IDG_RTF_TLB_FONT_COMBOS            0x1008

#define IDG_RTF_CTX_EDIT            0x1009
#define IDG_RTF_CTX_PROPS            0x100a

#define IDG_RTF_EDITOR_CMDS            0x100b
%EditorEnd%
#define MyMenuGroup                 0x1020

///////////////////////////////////////////////////////////////////////////////
// Command IDs

%MenuItemStart%#define %CommandID% 0x100%MenuItemEnd%
%ToolWindowItemStart%#define %ToolCommandID% 0x101%ToolWindowItemEnd%
%EditorStart%#define commandIDStrike 0x102%EditorEnd%

///////////////////////////////////////////////////////////////////////////////
// Bitmap IDs
#define bmpPic1 1
#define bmpPic2 2
#define bmpPicSearch 3
#define bmpPicX 4
#define bmpPicArrows 5
#define bmpPicStrikethrough 6

#endif // __COMMANDIDS_H_
