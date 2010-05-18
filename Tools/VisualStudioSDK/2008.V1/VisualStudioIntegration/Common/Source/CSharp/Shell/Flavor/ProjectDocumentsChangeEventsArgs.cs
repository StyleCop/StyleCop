using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.VisualStudio.Shell.Flavor
{
    /// <include file='doc\ProjectDocumentsChangeEventArgs.uex' path='docs/doc[@for="ProjectDocumentsChangeEventArgs"]/*' />
    public sealed class ProjectDocumentsChangeEventArgs : EventArgs
	{
		private string mkDocument = null;
        /// <include file='doc\ProjectDocumentsChangeEventArgs.uex' path='docs/doc[@for="ProjectDocumentsChangeEventArgs.MkDocument"]/*' />
        /// <devdoc>
		/// Unique name of the Project item that was changed.
		/// Use IVsProject.IsDocumentInProject() to map to an itemid.
		/// </devdoc>
		public string MkDocument
		{
			get { return mkDocument; }
			set { mkDocument = value; }
		}
	}
}
