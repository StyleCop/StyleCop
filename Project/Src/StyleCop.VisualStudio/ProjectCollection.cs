//-----------------------------------------------------------------------
// <copyright file="ProjectCollection.cs">
//   MS-PL
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
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;
    using EnvDTE;

    /// <summary>
    /// A collection of the various types of project lists that we use.
    /// </summary>
    [SuppressMessage(
        "Microsoft.Design", 
        "CA1010:CollectionsShouldImplementGenericInterface", 
        Justification = "The collection always stores the type Project. There is no need for it to be generic.")]
    public class ProjectCollection : IEnumerable
    {
        #region Private Fields

        /// <summary>
        /// The list of currently selected projects.
        /// </summary>
        private IEnumerable selectedProjects;

        /// <summary>
        /// The list of projects in the solution.
        /// </summary>
        private Projects solutionProjects;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the ProjectCollection class.
        /// </summary>
        public ProjectCollection()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the selected projects collection.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "The property must be set.")]
        public IEnumerable SelectedProjects
        {
            get 
            { 
                return this.selectedProjects; 
            }

            set 
            { 
                Param.RequireNotNull(value, "SelectedProjects");
                this.selectedProjects = value; 
            }
        }
        
        /// <summary>
        /// Gets or sets the collection of projects in the solution.
        /// </summary>
        public Projects SolutionProjects
        {
            get 
            { 
                return this.solutionProjects; 
            }

            set 
            { 
                Param.RequireNotNull(value, "SolutionProjects");
                this.solutionProjects = value; 
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns an enumerator from the selected projects collection or the solution projects collection.
        /// </summary>
        /// <returns>Returns the project enumerator.</returns>
        public IEnumerator GetEnumerator()
        {
            if (this.selectedProjects != null)
            {
                return this.selectedProjects.GetEnumerator();
            }
            else if (this.solutionProjects != null)
            {
                return this.solutionProjects.GetEnumerator();
            }
            else
            {
                return null;
            }
        }

        #endregion Public Methods
    }
}