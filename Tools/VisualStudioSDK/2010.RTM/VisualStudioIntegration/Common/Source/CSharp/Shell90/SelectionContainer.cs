
namespace Microsoft.VisualStudio.Shell
{
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    using ISelectionContainer = Microsoft.VisualStudio.Shell.Interop.ISelectionContainer;

    /// <include file='doc\SelectionContainer.uex' path='docs/doc[@for="SelectionContainer"]/*' />
    /// <devdoc>
    /// This class implements the ISelectionContainer interface. It can be used to show
    /// informations on the property window.
    /// </devdoc>
    [CLSCompliant(false)]
    public class SelectionContainer : 
        ISelectionContainer
    {
        private ICollection     _selectableObjects;
        private ICollection     _selectedObjects;
        private readonly bool   _selectableReadOnly;
        private readonly bool   _selectedReadOnly;

        private static ICollection _emptyCollection = new Object[0];

        // Constants for selection container flags.
        /// <include file='doc\SelectionContainer.uex' path='docs/doc[@for="SelectionContainer.ALL"]/*' />
        public const uint ALL = 0x1;
        /// <include file='doc\SelectionContainer.uex' path='docs/doc[@for="SelectionContainer.SELECTED"]/*' />
        public const uint SELECTED = 0x2;

        private const int SELOBJ_ACTIVATE_WINDOW = 0x1;


        /// <include file='doc\SelectionContainer.uex' path='docs/doc[@for="SelectionContainer.SelectionContainer"]/*' />
        /// <devdoc>
        /// Creates a container with empty collections of selected and selectable objects.
        /// </devdoc>
        public SelectionContainer()
        {
            _selectableObjects = _emptyCollection;
            _selectedObjects = _emptyCollection;
        }

        /// <include file='doc\SelectionContainer.uex' path='docs/doc[@for="SelectionContainer.SelectionContainer1"]/*' />
        /// <devdoc>
        /// Creates a selection container with empty collections of selected and selectable objects.
        /// </devdoc>
        /// <param name="selectableReadOnly">Specifies if the collection of the selectable objects is read only.</param>
        /// <param name="selectedReadOnly">Specifies if the selection is read only.</param>
        public SelectionContainer(bool selectableReadOnly, bool selectedReadOnly) : this()
        {
            _selectableReadOnly = selectableReadOnly;
            _selectedReadOnly = selectedReadOnly;
        }

        /// <include file='doc\SelectionContainer.uex' path='docs/doc[@for="SelectionContainer.SelectableObjects"]/*' />
        /// <devdoc>
        /// Get or set the collection of the selectable objects
        /// </devdoc>
        public ICollection SelectableObjects
        {
            get
            {
                return _selectableObjects;
            }
            set
            {
                if (value == null)
                {
                    value = _emptyCollection;
                }
                _selectableObjects = value;
            }
        }

        /// <include file='doc\SelectionContainer.uex' path='docs/doc[@for="SelectionContainer.SelectedObjects"]/*' />
        /// <devdoc>
        /// Get or set the collection of the selected objects.
        /// </devdoc>
        public ICollection SelectedObjects
        {
            get
            {
                return _selectedObjects;
            }
            set
            {
                if (value == null)
                {
                    value = _emptyCollection;
                }
                _selectedObjects = value;
            }
        }

        /// <include file='doc\SelectionContainer.uex' path='docs/doc[@for="SelectionContainer.SelectedObjectsChanged"]/*' />
        /// <devdoc>
        /// This event is fired when the selection changes.
        /// </devdoc>
        public event EventHandler SelectedObjectsChanged;

        /// <include file='doc\SelectionContainer.uex' path='docs/doc[@for="SelectionContainer.ActivateObjects"]/*' />
        /// <devdoc>
        /// Activates the selected objects. Its default implementation is empty.
        /// </devdoc>
        protected virtual void ActivateObjects()
        {
            // This default implementation of this function is empty.
        }

        // Helper function to change the selected objects
        private void ChangeSelection(object[] prgUnkObjects, int dwFlags)
        {
            // Check if it is possible to change the selection.
            if (_selectedReadOnly) throw new InvalidOperationException();
            // Store the array of selected object in the internal array
            SelectedObjects = prgUnkObjects;
            // Raise the "Selected objects changed" event.
            if (SelectedObjectsChanged != null) SelectedObjectsChanged(this, EventArgs.Empty);
            // Check if the objects need to be activated
            if ( (dwFlags & SELOBJ_ACTIVATE_WINDOW) != 0 )
            {
                ActivateObjects();
            }
        }

   
    
#region ISelectionContainer Members

        /// <include file='doc\SelectionContainer.uex' path='docs/doc[@for="SelectionContainer.ISelectionContainer.CountObjects"]/*' />
        /// <internalonly/>
        int ISelectionContainer.CountObjects(uint dwFlags, out uint pc)
        {
            switch (dwFlags)
            {
                case ALL:
                    pc = (uint)SelectableObjects.Count;
                    break;

                case SELECTED:
                    pc = (uint)SelectedObjects.Count;
                    break;

                default:
                    throw new ArgumentException(string.Format(Resources.Culture, Resources.General_UnsupportedValue, dwFlags), "dwFlags");
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\SelectionContainer.uex' path='docs/doc[@for="SelectionContainer.ISelectionContainer.GetObjects"]/*' />
        /// <internalonly/>
        int ISelectionContainer.GetObjects(uint dwFlags, uint cObjects, object[] apUnkObjects)
        {
            ICollection objects = null;

            switch (dwFlags)
            {
                case ALL:
                    objects = SelectableObjects;
                    break;

                case SELECTED:
                    objects = SelectedObjects;
                    break;

                default:
                    throw new ArgumentException(string.Format(Resources.Culture, Resources.General_UnsupportedValue, dwFlags), "dwFlags");
            }

            int idx = 0;
            foreach (object obj in objects)
            {
                if (idx >= cObjects || idx >= apUnkObjects.Length)
                {
                    break;
                }
                apUnkObjects[idx++] = obj;
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\SelectionContainer.uex' path='docs/doc[@for="SelectionContainer.ISelectionContainer.SelectObjects"]/*' />
        /// <internalonly/>
        int ISelectionContainer.SelectObjects(uint cSelect, object[] apUnkSelect, uint dwFlags)
        {
            ChangeSelection(apUnkSelect, (int)dwFlags);
            return NativeMethods.S_OK;
        }

#endregion
    }
}
