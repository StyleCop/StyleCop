//------------------------------------------------------------------------------
// <copyright file="OleMenuCommandService.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

/*
 */
namespace Microsoft.VisualStudio.Shell {
    
    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
    using IServiceProvider = System.IServiceProvider;

    /// <include file='doc\OleMenuCommandService.uex' path='docs/doc[@for="OleMenuCommandService"]/*' />
    /// <devdoc>
    ///    
    /// </devdoc>
    [CLSCompliant(false)]
    [System.Runtime.InteropServices.ComVisible(true)]
    public class OleMenuCommandService : System.ComponentModel.Design.MenuCommandService, IOleCommandTarget {

        internal static TraceSwitch MENUSERVICE = new TraceSwitch("MENUSERVICE", "MenuCommandService: Track menu command routing");

        private IOleCommandTarget _parentTarget;
        private IServiceProvider _provider;

        private static uint _queryStatusCount = 0;

        /// <include file='doc\OleMenuCommandService.uex' path='docs/doc[@for="OleMenuCommandService.OleMenuCommandService"]/*' />
        /// <devdoc>
        ///     Creates a new menu command service.
        /// </devdoc>
        public OleMenuCommandService(IServiceProvider serviceProvider) : base(serviceProvider){   
            _provider = serviceProvider;
        }


        /// <include file='doc\OleMenuCommandService.uex' path='docs/doc[@for="OleMenuCommandService.OleMenuCommandService1"]/*' />
        /// <devdoc>
        ///     Creates a new menu command service.
        /// </devdoc>
        public OleMenuCommandService(IServiceProvider serviceProvider, IOleCommandTarget parentCommandTarget) : base(serviceProvider) {
            if (parentCommandTarget == null) {
                throw new ArgumentNullException("parentCommandTarget");
            }
            _parentTarget = parentCommandTarget;
            _provider = serviceProvider;
        }

        /// <include file='doc\OleMenuCommandService.uex' path='docs/doc[@for="OleMenuCommandService.ServiceProvider"]/*' />
        /// <devdoc>
        ///     Returns the service provider.
        /// </devdoc>
        [Obsolete("This method is obsolete and will be removed before the end of M3.2.  Use the proected GetService method instead.")]
        protected IServiceProvider ServiceProvider {
            get {
                return _provider;
            }
        }

        private MenuCommand FindCommand(Guid guid, int id, ref int hrReturn) {
            hrReturn = (int)Microsoft.VisualStudio.OLE.Interop.Constants.OLECMDERR_E_UNKNOWNGROUP;

            MenuCommand result = null;

            //first query the IMenuCommandService and ask it to FindCommand
            IMenuCommandService menuCommandService = GetService(typeof(IMenuCommandService)) as IMenuCommandService;
            if (menuCommandService != null)
            {
            	result = menuCommandService.FindCommand(new CommandID(guid, (int)id));	
            }
            //if the IMenuCommandService cames back w/o a command, then ask ourselves
            if (result == null && this != menuCommandService)
            {
            	result = FindCommand(guid, (int)id);
            }

            if(result == null) {
                ICollection commands = GetCommandList(guid);
                if(commands != null) {                
                    // The default error now must be "Not Supported" because the command group is known
                    hrReturn = (int)Microsoft.VisualStudio.OLE.Interop.Constants.OLECMDERR_E_NOTSUPPORTED;
                    Debug.WriteLineIf(MENUSERVICE.TraceVerbose, "\t...VSMCS Found group");
                    // Get the list of command inside this group
                    foreach (MenuCommand command in commands) {
                        // we are looping again on the list of commands to check the DynamicItemMatch
                        // but this is unavoidable in this context....
                        // If the command is a OleMenuCommand, then we can try to do a dynamic match
                        OleMenuCommand vsCommand = command as OleMenuCommand;
                        if ( (null != vsCommand) && (vsCommand.DynamicItemMatch(id)) )
                        {
                            Debug.WriteLineIf(MENUSERVICE.TraceVerbose, "\t...VSMCS Found command2");
                            hrReturn = NativeMethods.S_OK;
                            result = command;
                        }
                    }            
                }
            }else {
                Debug.WriteLineIf(MENUSERVICE.TraceVerbose, "\t... VSMCS Found command");
                hrReturn = NativeMethods.S_OK;
            }
            return result;
        }


        /// <include file='doc\OleMenuCommandService.uex' path='docs/doc[@for="OleMenuCommandService.GlobalInvoke"]/*' />
        /// <devdoc>
        ///     Invokes a command on the local form or in the global environment.
        ///     The local form is first searched for the given command ID.  If it is
        ///     found, it is invoked.  Otherwise the the command ID is passed to the
        ///     global environment command handler, if one is available.
        /// </devdoc>
        public override bool GlobalInvoke(CommandID commandID) {

            // is it local?
            if(base.GlobalInvoke(commandID)) {
                return true;
            }
            
            // pass it to the global handler
            IVsUIShell uiShellSvc = GetService(typeof(SVsUIShell)) as IVsUIShell;
            if (uiShellSvc != null) {
                Object dummy = null;
                Guid tmpGuid = commandID.Guid;
                if ( NativeMethods.Failed(uiShellSvc.PostExecCommand(ref tmpGuid, (uint)commandID.ID, 0, ref dummy)) )
                    return false;
                return true;
            }
            return false;
        }

        /// <include file='doc\OleMenuCommandService.uex' path='docs/doc[@for="OleMenuCommandService.GlobalInvoke1"]/*' />
        /// <devdoc>
        ///     Invokes a command on the local form or in the global environment.
        ///     The local form is first searched for the given command ID.  If it is
        ///     found, it is invoked.  Otherwise the the command ID is passed to the
        ///     global environment command handler, if one is available.
        /// </devdoc>
        public override bool GlobalInvoke(CommandID commandID, object arg) {

            // is it local?
            if(base.GlobalInvoke(commandID, arg)) {
                return true;
            }

            // pass it to the global handler
            IVsUIShell uiShellSvc = GetService(typeof(SVsUIShell)) as IVsUIShell;
            if (uiShellSvc == null)
                return false;

            Object dummy = arg;
            Guid tmpGuid = commandID.Guid;
            if ( NativeMethods.Failed(uiShellSvc.PostExecCommand(ref tmpGuid, (uint)commandID.ID, 0, ref dummy)) )
                return false;
            return true;
        }

        /// <include file='doc\OleMenuCommandService.uex' path='docs/doc[@for="OleMenuCommandService.OnCommandChanged"]/*' />
        /// <devdoc>
        ///     This is called by a menu command when it's status has changed.
        /// </devdoc>
        protected override void OnCommandsChanged(MenuCommandsChangedEventArgs e) {

            base.OnCommandsChanged(e);

            if (0 == _queryStatusCount) {
                // UpdateCommandUI(0) can not be called inside QueryStatus because this will cause an infinite
                // sequence of calls to QueryStatus during idle time.
                IVsUIShell uiShellSvc = GetService(typeof(SVsUIShell)) as IVsUIShell;
                if (uiShellSvc != null) {
                    NativeMethods.ThrowOnFailure(uiShellSvc.UpdateCommandUI(0));
                }
            }
        }

        /// <include file='doc\OleMenuCommandService.uex' path='docs/doc[@for="OleMenuCommandService.ShowContextMenu"]/*' />
        /// <devdoc>
        ///     Shows the context menu with the given command ID at the given
        ///     location.
        /// </devdoc>
        public override void ShowContextMenu(CommandID menuID, int x, int y) {
            
            IOleComponentUIManager cui = GetService(typeof(NativeMethods.OleComponentUIManager)) as IOleComponentUIManager;
            Debug.Assert(cui != null, "no component UI manager, so we can't display a context menu");
            if (cui != null) {
                POINTS[] pt = new POINTS[] { new POINTS() };
                pt[0].x = (short)x;
                pt[0].y = (short)y;

                Guid tmpGuid = menuID.Guid;
                NativeMethods.ThrowOnFailure( cui.ShowContextMenu(0, ref tmpGuid, menuID.ID, pt, this) );
            }
        }

        private uint HiWord(uint val) {
            return ((val >> 16) & 0xFFFF);
        }
        private uint LoWord(uint val) {
            return (val & 0xFFFF);
        }

        /// <include file='doc\OleMenuCommandService.uex' path='docs/doc[@for="OleMenuCommandService.IOleCommandTarget.Exec"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// Executes the given command.
        /// </devdoc>
        int IOleCommandTarget.Exec(ref Guid guidGroup, uint nCmdId, uint nCmdExcept, IntPtr pIn, IntPtr vOut) {
            const uint vsCmdOptQueryParameterList = 1;
            int hr = NativeMethods.S_OK;

            MenuCommand cmd = FindCommand(guidGroup, (int)nCmdId, ref hr);
            // If the command is not supported check if it can be handled by the parent command service
            if ( (cmd== null || !cmd.Supported) && _parentTarget != null) 
            {
                return _parentTarget.Exec(ref guidGroup, nCmdId, nCmdExcept, pIn, vOut);
            }
            else if (cmd != null) {
                // Try to see if the command is a OleMenuCommand.
                OleMenuCommand vsCmd = cmd as OleMenuCommand;
                // Check the execution flags;
                uint loWord = LoWord(nCmdExcept);
                // If the command is not an OleMenuCommand, it can handle only the default
                // execution.
                if (((uint)OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT != loWord) && (null == vsCmd))
                {
                    return NativeMethods.S_OK;
                }
                object o = null;
                if (pIn != IntPtr.Zero)
                {
                    o = Marshal.GetObjectForNativeVariant(pIn);
                }
                if (null == vsCmd)
                {
                    cmd.Invoke(o);
                }
                else
                {
                    switch (loWord)
                    {
                        // Default execution of the command: call the Invoke method
                        case (uint)OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT:
                            vsCmd.Invoke(o, vOut);
                            break;

                        case (uint)OLECMDEXECOPT.OLECMDEXECOPT_SHOWHELP:
                            // Check the hi word of the flags to see what kind of help
                            // is needed. We handle only the request for the parameters list.
                            if (vsCmdOptQueryParameterList == HiWord(nCmdExcept) && IntPtr.Zero != vOut)
                            {
                                // In this case vOut is a pointer to a VARIANT that will receive
                                // the parameters description.
                                if (!string.IsNullOrEmpty(vsCmd.ParametersDescription))
                                {
                                    Marshal.GetNativeVariantForObject(vsCmd.ParametersDescription, vOut);
                                }
                            }
                            break;

                        default:
                            break;
                    }
                }
            }

            return hr;

        }

        /// <include file='doc\OleMenuCommandService.uex' path='docs/doc[@for="OleMenuCommandService.IOleCommandTarget.QueryStatus"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// Inquires about the status of a command.  A command's status indicates
        /// it's availability on the menu, it's visibility, and it's checked state.
        /// The exception thrown by this method indicates the current command status.
        /// </devdoc>
        int IOleCommandTarget.QueryStatus(ref Guid guidGroup, uint nCmdId, OLECMD[] oleCmd, IntPtr oleText) {
            _queryStatusCount += 1;
            int hr = NativeMethods.S_OK;
            try {
                for (uint i = 0; i < oleCmd.Length && NativeMethods.Succeeded(hr); i++)
                {
                    MenuCommand cmd = FindCommand(guidGroup, (int)oleCmd[i].cmdID, ref hr);

                    oleCmd[i].cmdf = 0;
                    if ((cmd != null) && NativeMethods.Succeeded(hr))
                    {
                        oleCmd[i].cmdf = (uint)cmd.OleStatus;
                    }

                    if ((oleCmd[i].cmdf & (int)NativeMethods.tagOLECMDF.OLECMDF_SUPPORTED) != 0)
                    {
                        // Find if the caller needs the text of the command
                        if (NativeMethods.OLECMDTEXT.GetFlags(oleText) == NativeMethods.OLECMDTEXT.OLECMDTEXTF.OLECMDTEXTF_NAME)
                        {
                            string textToSet = null;
                            if (cmd is DesignerVerb)
                            {
                                textToSet = ((DesignerVerb)cmd).Text;
                            }
                            else if (cmd is OleMenuCommand)
                            {
                                textToSet = ((OleMenuCommand)cmd).Text;
                            }
                            if (null != textToSet)
                            {
                                NativeMethods.OLECMDTEXT.SetText(oleText, textToSet);
                            }
                        }
                    }
                    else if (_parentTarget != null)
                    {
                        // If the command is not supported and this command service has a parent,
                        // ask the parent about the command.
                        OLECMD[] newOleArray = { oleCmd[i] };
                        hr = _parentTarget.QueryStatus(ref guidGroup, 1, newOleArray, oleText);
                        oleCmd[i] = newOleArray[0];
                    }
                    // SBurke, if the flags are zero, the shell prefers
                    // that we return not supported, or else no one else will
                    // get asked
                    //
                    if (oleCmd[i].cmdf == 0) {
                        hr = NativeMethods.OLECMDERR_E_NOTSUPPORTED;
                    }
                }
            }
            finally {
                if (0 < _queryStatusCount)
                    _queryStatusCount -= 1;
            }
            return hr;

        }
    }
}


