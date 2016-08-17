//--------------------------------------------------------------------------
// <copyright file="CommandSet.cs">
//  MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.VisualStudio
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.Design;
    using Microsoft.VisualStudio.Shell;
    using StyleCop;

    /// <summary>
    /// Abstract CommandSet.
    /// </summary>
    internal abstract class CommandSet : MarshalByRefObject
    {
        #region Private Fields

        /// <summary>
        /// List of added commands.
        /// </summary>
        private IList<OleMenuCommand> commandset;

        /// <summary>
        /// Menu Command Service.
        /// </summary>
        private IMenuCommandService menuService;

        /// <summary>
        /// Service Provider.
        /// </summary>
        private IServiceProvider serviceProvider;

        #endregion Private Fields

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the CommandSet class.
        /// </summary>
        /// <param name="serviceProvider">Service Provider.</param>
        protected CommandSet(IServiceProvider serviceProvider)
        {
            Param.RequireNotNull(serviceProvider, "serviceProvider");
            this.serviceProvider = serviceProvider;
            this.commandset = new Collection<OleMenuCommand>();
        }

        #endregion Protected Constructors

        #region Protected Properties

        /// <summary>
        /// Gets the CommandSet's MenuService.
        /// </summary>
        protected IMenuCommandService MenuService
        {
            get
            {
                if (this.menuService == null)
                {
                    this.menuService = (IMenuCommandService)this.ServiceProvider.GetService(typeof(IMenuCommandService));
                }

                return this.menuService;
            }
        }

        /// <summary>
        /// Gets an internal list of commands that this class should add to the MenuService when <seealso cref="Initialize"/> is called.
        /// </summary>
        protected IList<OleMenuCommand> CommandList
        {
            get
            {
                return this.commandset;
            }
        }

        /// <summary>
        /// Gets the CommandSet's ServiceProvider.
        /// </summary>
        protected IServiceProvider ServiceProvider
        {
            get
            {
                return this.serviceProvider;
            }
        }

        #endregion Protected Properties

        #region Protected Internal Methods

        /// <summary>
        /// Loops through the MenuCommands in 'CommandSet' and adds them to the menu service.
        /// </summary>
        protected internal virtual void Initialize()
        {
            this.menuService = (IMenuCommandService)this.serviceProvider.GetService(typeof(IMenuCommandService));
            System.Diagnostics.Debug.Assert(this.MenuService != null, "this.MenuService is null");
            if (this.MenuService != null)
            {
                foreach (OleMenuCommand dynCmd in this.commandset)
                {
                    this.MenuService.AddCommand(dynCmd);
                }
            }
        }

        #endregion Protected Internal Methods

        #region Protected Static Methods

        /// <summary>
        /// Checks a menu item to see if it is valid to invoke the menu item.
        /// </summary>
        /// <param name="menuCommand">True if menu item can be invoked; false otherwise.</param>
        protected static void CheckMenuItemValidity(OleMenuCommand menuCommand)
        {
            Param.RequireNotNull(menuCommand, "menuCommand");

            if (!(menuCommand.Visible && menuCommand.Enabled && menuCommand.Supported))
            {
                throw new InvalidOperationException();
            }
        }

        #endregion Protected Static Methods
    }
}