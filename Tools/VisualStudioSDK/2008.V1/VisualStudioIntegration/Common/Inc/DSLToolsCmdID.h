
/***************************************************************************
    Copyright (c) Microsoft Corporation, All rights reserved.             
    This code sample is provided "AS IS" without warranty of any kind, 
    it is not recommended for use in a production environment.
***************************************************************************/

// CommonModelingCmdID.h
// Command IDs used in defining command bars
//

// do not use #pragma once - used by ctc compiler
#ifndef __COMMONCMDID_H_
#define __COMMONCMDID_H_

///////////////////////////////////////////////////////////////////////////////
// Guids

#define guidCommonModelingPackage	{ 0xd1091694, 0xea72, 0x4bdd, { 0x89, 0x18, 0x78, 0x32, 0x4c, 0xc2, 0x54, 0x48 } }
#define guidCommonModelingCmdSet	{ 0x499281f3, 0x7df8, 0x41e2, { 0x8a, 0xc8, 0x21, 0x55, 0x0f, 0xd1, 0x8e, 0xbc } }
#define guidCommonModelingMenu		{ 0xdd10eab8, 0x25d0, 0x44e0, { 0xbd, 0x6e, 0x98, 0x1f, 0x3b, 0xed, 0x6a, 0xf2 } }
#define	guidCompartmentShapeCmdSet	{ 0x24ceac08, 0xf085, 0x4f65, { 0x9f, 0x8e, 0xb5, 0xb9, 0x90, 0x10, 0x7d, 0x5d } }
#define guidSwimlaneShapeCmdSet		{ 0x930fb0a6, 0x83a8, 0x4a5b, { 0x87, 0x55, 0x45, 0xde, 0xed, 0x77, 0x9e, 0xb7 } }

///////////////////////////////////////////////////////////////////////////////
// Menu IDs

#define menuidCommandWellMenu 0x0100
#define menuidCompartmentShapeAdd 0x0200
#define menuidSwimlaneShapeAddBefore 0x0300
#define menuidSwimlaneShapeAddAfter 0x0400

///////////////////////////////////////////////////////////////////////////////
// Menu Group IDs

#define grpidExplorerMenuGroup 0x1030
#define grpidExplorerCommandWellMenuGroup 0x1032
#define grpidValidateCommands 0x1035
#define grpidCompartmentShapeMenuGroup 0x1040
#define grpidCompartmentShapeAddCommands 0x1050
#define grpidLayoutMenuGroup 0x1060
#define grpidSwimlaneShapeMenuGroup 0x1070
#define grpidSwimlaneShapeAddBeforeCommands 0x1080
#define grpidSwimlaneShapeAddAfterCommands 0x1090

///////////////////////////////////////////////////////////////////////////////
// Command IDs

#define cmdidValidateModel	0x1
#define cmdidExplorerDeleteAll 0x2
#define cmdidExplorerPopulate 0x3
#define cmdidExplorerCascadePopulate 0x4
#define cmdidValidate 0x5
#define cmdidExplorerAddModelElement 0x6 // this is a DYNAMICITEMSTART menu item, so keep it's definition last.

#define cmdidCompartmentShapeExpandCollapse 0x10
#define cmdidCompartmentItemAdd 0x130
#define cmdidCompartmentItemEdit 0x40
#define cmdidCompartmentClassAddItem 0x50

#define cmdidRerouteLine 0x200

#define cmdidSwimlaneAddBefore 0x0010
#define cmdidSwimlaneAddAfter 0x1010

#endif // __COMMONCMDID_H_
