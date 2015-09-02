//--------------------------------------------------------------------------
// <copyright file="NSDataAccess.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Globalization;
using Microsoft.Navision.Runtime;
using Microsoft.Dynamics.Nav.Types;
using Microsoft.Dynamics.Nav.Types.Metadata;
using System.Diagnostics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Dynamics.Nav.Types.Data;

namespace Microsoft.Dynamics.Nav.Service
{
    /// <summary>
    /// Abstraction layer around NCL tables, which includes access to tables through NavForm objects, including source expressions defined on
    /// the form, as well as invocation of form triggers at the appropriate times.
    /// </summary>
    /// 
    internal abstract class NsDataAccess : IDisposable
    {
        #region Private fields

        private ICollection<int> calculatedFields;

        #endregion

        #region Private methods

        /// <summary>
        /// Suport the idisposable pattern
        /// </summary>
        /// <param name="disposing">true when dispose has been called, false when finalizing.</param>
        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the record object.
        /// </summary>
        public virtual NavRecord Record
        {
            get { return null; }
        }

        /// <summary>
        /// Gets access to the updateType.
        /// </summary>
        public virtual NavFormUpdateType UpdateType
        {
            get { return NavFormUpdateType.None; }
        }

        /// <summary>
        /// Gets access to the underlying form.
        /// </summary>
        public virtual NavForm Form
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the source expressions.
        /// </summary>
        public virtual IDictionary<String, NavFormSourceExpression> SourceExpressions
        {
            get { return new Dictionary<String, NavFormSourceExpression>(0); }
        }

        /// <summary>
        /// Gets the NavRecord.TableID
        /// </summary>
        public Int32 TableID
        {
            get { return (this.Record != null) ? this.Record.TableID : 0; }
        }

        /// <summary>
        /// Gets the RecordId of the current record.
        /// </summary>
        public virtual Byte[] Bookmark
        {
            get
            {
                if ((this.Record != null) && (this.Record.Exists(this.Record.ALRecordId)))
                {
                    return this.Record.ALRecordId.GetBytes();
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the state of the record
        /// </summary>
        public virtual NavRecordOperationTypes RecordState
        {
            get { return (this.Record != null && this.Record.Exists(this.Record.ALRecordId)) ? NavRecordOperationTypes.InDatabase : (NavRecordOperationTypes)0; }
            set { }
        }

        /// <summary>
        /// Gets a collection of calculated fields numbers
        /// </summary>
        public virtual ICollection<int> CalculatedFields
        {
            get { return this.calculatedFields; }
        }

        #endregion

        /// <summary>
        /// Gets the collection of calculated fields.
        /// </summary>
        protected ICollection<int> CalculatedFieldsInt
        {
            get
            {
                return this.calculatedFields;
            }
        }

        #region Public methods

        /// <summary>
        /// Register to listen to record events
        /// </summary>
        internal virtual void ListenForRecordEvents()
        {
        }

        /// <summary>
        /// Unregister from listening to record events
        /// </summary>
        internal virtual void StopListeningForRecordEvents()
        {
        }

        /// <summary>
        /// Return an array of form update parameters
        /// </summary>
        /// <returns>An array of parameters specifying which forms should be updated and how.</returns>
        public virtual NavFormUpdateParameters[] GetUpdateParametersArray()
        {
            return null;
        }

        /// <summary>
        /// Instantiate a NsDataAccess object from a record ID.
        /// </summary>
        /// <param name="recordId">The record ID.</param>
        /// <param name="parent">The parent object.</param>
        /// <returns>A new NsDataObject.</returns>
        public static NsDataAccess Create(Int32 recordId, NavApplicationObjectBase parent)
        {
            return new NsTableDataAccess(NavEnvironment.Instance.ApplicationFactory.GetTable(recordId, parent));
        }

        /// <summary>
        /// Instantiate a NsDataAccess object from a record.
        /// </summary>
        /// <param name="record">The record.</param>
        /// <returns>A new NsDataObject.</returns>
        public static NsDataAccess Create(NavRecord record)
        {
            if (record != null)
            {
                record.AddReference();
            }

            return new NsTableDataAccess(record);
        }

        /// <summary>
        /// Instantiate a NsDataAccess object from a form.
        /// </summary>
        /// <param name="form">The form to create.</param>
        /// <returns>A new NsDataObject.</returns>
        public static NsDataAccess Create(NavForm form)
        {
            if (form != null)
            {
                form.AddReference();
            }

            return new NsFormDataAccess(form);
        }

        /// <summary>
        /// Instantiate a NsDataAccess object from a record ID.
        /// </summary>
        /// <param name="state">The record state.</param>
        /// <returns>A new NsDataObject.</returns>
        public static NsDataAccess Create(NavRecordState state)
        {
            Boolean instantiatedForm;
            NsDataAccess access = Create(state, false, Guid.Empty, String.Empty, out instantiatedForm);
            Debug.Assert(!instantiatedForm);

            return access;
        }

        /// <summary>
        /// Instantiate a NsDataAccess object from a record ID.
        /// </summary>
        /// <param name="state">dataset state object</param>
        /// <param name="instantiateNewForm">Indicates whether to create a new form object if it doesn't exist.</param>
        /// <param name="parentFormHandle">Form handle of the parent form. Applicable only to subforms.</param>
        /// <param name="parentControlName">controlName of the control in the parent form representing the subform. Applicable only to subforms.</param>
        /// <returns>A new NsDataObject.</returns>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Unit test support")]
        public static NsDataAccess Create(
            NavRecordState state, Boolean instantiateNewForm, Guid parentFormHandle, String parentControlName)
        {
            Boolean unusedResult;
            return Create(state, instantiateNewForm, parentFormHandle, parentControlName, out unusedResult);
        }

        /// <summary>
        /// Instantiate a NsDataAccess object from a record ID.   
        /// </summary>
        /// <param name="state">dataset state object</param>
        /// <param name="instantiateNewForm">Indicates whether to create a new form object if it doesn't exist.</param>
        /// <param name="parentFormHandle">Form handle of the parent form. Applicable only to subforms.</param>
        /// <param name="parentControlName">controlName of the control in the parent form representing the subform. Applicable only to subforms.</param>
        /// <param name="instantiatedForm"> True if and only if a new form was instantiated.</param>
        /// <returns>A new NsDataObject.</returns>
        public static NsDataAccess Create(
            NavRecordState state, Boolean instantiateNewForm, Guid parentFormHandle, String parentControlName, out Boolean instantiatedForm)
        {
            instantiatedForm = false;
            if (state.IsResourceDefinedForm)
            {
                return new NsTableDataAccess(ApplicationFactory.GetResourceDefinedFormTable(state.FormId));
            }
            else if (state.FormId != 0 || state.ServerFormHandle != Guid.Empty)
            {
                NavConnection connection = NavConnection.Current;

                // Try to retrieve an existing instance of the form.
                NavForm form = connection.GetForm(state.ServerFormHandle);

                if (form == null)
                {
                    if (instantiateNewForm)
                    {
                        // Not found - create new instance.
                        if ((parentFormHandle != Guid.Empty) && (!String.IsNullOrEmpty(parentControlName)))
                        {
                            // Subform information provided - try to instantiate through the parent form
                            NavForm parentForm = connection.GetForm(parentFormHandle);
                            using (parentForm)
                            {
                                if (parentForm.TryGetUIPart(parentControlName, out form))
                                {
                                    form.AddReference();
                                }
                            }
                        }

                        if (form == null)
                        {
                            // Form not instantiated as subform, try to instantiate as independent form
                            form = NavEnvironment.Instance.ApplicationFactory.GetForm(state.FormId);
                        }

                        if (form != null)
                        {
                            instantiatedForm = true;
                            state.ServerFormHandle = form.Handle;
                            Debug.Assert(state.FormId == form.FormId);
                        }
                    }
                    else
                    {
                        throw new NavException(NavException.NCL.ErrFormNotOpen);
                    }
                }

                return new NsFormDataAccess(form);
            }
            else
            {
                Debug.Assert(state.TableId != 0);
                return new NsTableDataAccess(state.TableId);
            }
        }

        /// <summary>
        /// Performs a Find("-")
        /// </summary>
        /// <returns>Returns true on success.</returns>
        public virtual Boolean FindRecord()
        {
            return this.Find(NavRecord.FindMinus);
        }

        /// <summary>
        /// Abstraction around NavRecord.Find.
        /// </summary>
        /// <param name="searchMethod">The search method.</param>
        /// <returns>Returns true on success.</returns>
        public virtual Boolean Find(string searchMethod)
        {
            if (this.Record != null)
            {
                bool found = this.Record.ALFind(DataError.TrapError, searchMethod);
                if (found)
                {
                    this.CalculateFlowFields();
                }

                return found;
            }

            return false;
        }

        /// <summary>
        /// Abstraction around NavRecord.NEXT
        /// </summary>
        /// <param name="steps">The steps.</param>
        /// <returns>Returns the next step.</returns>
        public virtual Int32 Next(Int32 steps)
        {
            if (this.Record != null)
            {
                Int32 actualSteps = this.Record.ALNext(steps);
                if (actualSteps != 0)
                {
                    this.CalculateFlowFields();
                }

                return actualSteps;
            }

            return 0;
        }

        /// <summary>
        /// Abstraction around NavRecord.NextRecord
        /// </summary>
        /// <returns>Returns the result.</returns>
        public Boolean NextRecord()
        {
            return (this.Next(1) != 0);
        }

        /// <summary>
        /// Abstraction around NavRecord.PreviousRecord
        /// </summary>
        /// <returns>Returns the previous record.</returns>
        public Boolean PreviousRecord()
        {
            return (this.Next(-1) != 0);
        }

        /// <summary>
        /// Abstraction around NavRecord.MODIFY
        /// </summary>
        /// <param name="errorLevel">Indicates how to handle errors.</param>
        /// <param name="runApplicationTrigger">Indicates whether to run OnModify table trigger.</param>
        /// <returns>Returns true on success.</returns>
        public virtual Boolean Modify(DataError errorLevel, Boolean runApplicationTrigger)
        {
            if (this.Record == null)
            {
                return false;
            }

            return this.Record.Modify(errorLevel, runApplicationTrigger, true);
        }

        /// <summary>
        /// Abstraction around NavRecord.DELETE
        /// </summary>
        /// <param name="errorLevel">Indicates how to handle errors.</param>
        /// <param name="runApplicationTrigger">Indicates whether to run OnDelete table trigger.</param>
        /// <returns>Returns true on success.</returns>
        public virtual Boolean Delete(DataError errorLevel, Boolean runApplicationTrigger)
        {
            if (this.Record == null)
            {
                return false;
            }

            return this.Record.Delete(errorLevel, runApplicationTrigger, true);
        }

        /// <summary>
        /// Abstraction around NavRecord.RENAME
        /// </summary>
        /// <param name="errorLevel">Indicates how to handle errors.</param>
        /// <returns>Returns true on success.</returns>
        public virtual Boolean Rename(DataError errorLevel)
        {
            if (this.Record == null)
            {
                return false;
            }

            this.Record.Rename(false, errorLevel);
            return true;
        }

        /// <summary>
        /// Abstraction around NavRecord.Insert
        /// </summary>
        /// <param name="errorLevel">Indicates how to handle errors.</param>
        /// <param name="runApplicationTrigger">Indicates whether to run OnInsert table trigger.</param>
        /// <param name="belowRec">Parameter is not used.</param>
        /// <returns>Returns true on success.</returns>
        public virtual Boolean Insert(DataError errorLevel, Boolean runApplicationTrigger, Boolean belowRec)
        {
            if (this.Record == null)
            {
                return false;
            }

            return this.Record.Insert(errorLevel, runApplicationTrigger, true);
        }

        /// <summary>
        /// Abstraction around NavRecord.ValidateRecord
        /// </summary>
        /// <param name="fieldId">The field ID.</param>
        public void Validate(Int32 fieldId)
        {
            if (this.Record == null)
            {
                return;
            }

            this.Record.ALValidate(fieldId, this.Record);
        }

        /// <summary>
        /// Abstraction around NavRecord.Lookup
        /// </summary>
        /// <param name="fieldId">The field ID.</param>
        public void Lookup(Int32 fieldId)
        {
            if (this.Record == null)
            {
                return;
            }

            this.Record.Lookup(fieldId);
        }

        /// <summary>
        /// Clears the Record property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public void Clear()
        {
            if (this.Record != null)
            {
                this.Record.Clear();
            }
        }

        /// <summary>
        /// Gets an instance of the old record.
        /// </summary>
        public virtual NsDataAccess OldRecord
        {
            get
            {
                if (this.Record == null)
                {
                    return null;
                }
                else
                {
                    return NsDataAccess.Create(this.Record.OldRecord);
                }
            }
        }

        /// <summary>
        /// Assign the record from the embeeded record in the parameter.
        /// </summary>
        /// <param name="fromDataAccess">The data access.</param>
        public void CopyRecord(NsDataAccess fromDataAccess)
        {
            if ((this.Record != null) && (fromDataAccess.Record != null))
            {
                this.Record.ALCopy(fromDataAccess.Record);
            }
        }

        /// <summary>
        /// Sets current position of recDataAccess.Record based on the record bookmark
        /// </summary>
        /// <param name="dataError">Determines whether to throw in case the bookmark is not valid.</param>
        /// <param name="bookmark">Bookmark of the record.</param>
        internal virtual void SetPosition(DataError dataError, byte[] bookmark)
        {
        }

        /// <summary>
        /// Gets the saved record.
        /// </summary>
        internal virtual NavRecord SavedRecord
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets marked records.
        /// </summary>
        /// <returns>Returns the marked recordss.</returns>
        internal virtual Byte[][] GetMarkedRecords()
        {
            Debug.Assert(this.Record != null);
            List<Byte[]> marked = new List<Byte[]>();
            using (NavRecord cachedRecord = this.Record.Clone(this.Record.IsTemporary))
            using (NavRecord cachedSavedRecord = this.SavedRecord != null ? this.SavedRecord.Clone(this.SavedRecord.IsTemporary) : null)
            {
                this.Record.ALMarkedOnly = true;
                if (!this.Record.ALIsEmpty)
                {
                    if (this.Record.ALFindFirst(DataError.TrapError))
                    {
                        do
                        {
                            marked.Add(this.Record.ALRecordId.GetBytes());
                        }
                        while (this.Record.ALNext() != 0);
                    }
                }

                this.Record.ALCopy(cachedRecord);

                if (this.SavedRecord != null && cachedSavedRecord != null)
                {
                    this.SavedRecord.ALCopy(cachedSavedRecord);
                }
            }

            return marked.ToArray();
        }

        /// <summary>
        /// Sets marked records.
        /// </summary>
        /// <param name="marked">The marked bytes.</param>
        internal virtual void SetMarkedRecords(Byte[][] marked)
        {
            Debug.Assert(this.Record != null);
            this.Record.ALClearMarks();
            if (marked != null && marked.Length > 0)
            {
                using (NavRecord cachedRecord = this.Record.Clone(this.Record.IsTemporary))
                {
                    foreach (Byte[] bookmarkBytes in marked)
                    {
                        RecordBookmark bookmark = new RecordBookmark(bookmarkBytes);
                        if (bookmark != null)
                        {
                            this.Record.SetMark(bookmark.GetBytes(), true);
                        }
                    }

                    this.Record.Assign(cachedRecord);
                }
            }
        }

        /// <summary>
        /// Sets internal collection of calculated fields numbers as defined by the input parameter. 
        /// </summary>
        /// <param name="calculatedFieldsNumbers">Array of calculated fields numbers.
        /// If null, the internal collection of calculated fields numbers is not changed.</param>
        internal void SetFlowFields(int[] calculatedFieldsNumbers)
        {
            if (this.Record != null && calculatedFieldsNumbers != null)
            {
                ICollection<int> fieldNumbers = new List<int>();
                for (int i = 0; i < calculatedFieldsNumbers.Length; i++)
                {
                    NavFieldRef field = this.Record.ALField(calculatedFieldsNumbers[i]);
                    if (field != null && (field.ALClass == FieldClass.FlowField || field.ALType == NavType.BLOB))
                    {
                        if (!fieldNumbers.Contains(calculatedFieldsNumbers[i]))
                        {
                            fieldNumbers.Add(calculatedFieldsNumbers[i]);
                        }
                    }
                }

                this.calculatedFields = fieldNumbers;
            }
        }

        /// <summary>
        /// Support for calculating flowfields and BLOBs
        /// </summary>
        internal void CalculateFlowFields()
        {
            if (this.Record != null)
            {
                int[] calculatedFieldsArray = new int[this.CalculatedFields.Count];
                this.CalculatedFields.CopyTo(calculatedFieldsArray, 0);
                this.Record.CalcFields(DataError.TrapError, calculatedFieldsArray);
            }
        }


        #endregion

        #region IDisposable Members

        /// <summary>
        /// Disposes the contents of the class.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }

    #region NsTableDataAccess definition

    internal class NsTableDataAccess : NsDataAccess
    {
        private NavRecord record;
        private bool isDisposed;

        /// <summary>
        /// Initializes a new instance of the NsTableDataAccess class.
        /// </summary>
        /// <param name="recordId">The record ID.</param>
        internal NsTableDataAccess(Int32 recordId)
        {
            // Note, that there is no parent obeject avaiable for this NavRecord creation
            this.record = NavEnvironment.Instance.ApplicationFactory.GetTable(recordId, null);
        }

        /// <summary>
        /// Initializes a new instance of the NsTableDataAccess class.
        /// </summary>
        /// <param name="record">The record.</param>
        internal NsTableDataAccess(NavRecord record)
        {
            this.record = record;
        }

        /// <summary>
        /// Gets the Record property.
        /// </summary>
        public override NavRecord Record
        {
            get { return this.record; }
        }

        /// <summary>
        /// Gets internal collection of calculated fields if it is set; otherwise - a collection of calculated field numbers from the Table metadata. 
        /// Null if Record is null.
        /// </summary>
        public override ICollection<int> CalculatedFields
        {
            get
            {
                if (this.Record != null)
                {
                    return this.CalculatedFieldsInt != null ? this.CalculatedFieldsInt : this.Record.MetaTable.CalculatedFields;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Idisposable pattern support.
        /// </summary>
        /// <param name="disposing">Indicates whether to dispose managed resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!this.isDisposed)
                {
                    if (this.record != null)
                    {
                        this.record.Dispose();
                    }
                }
                this.isDisposed = true;
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Sets current position of recDataAccess.Record based on the input parameter record bookmark
        /// </summary>
        /// <param name="dataError">Determines whether to throw in case the bookmark is not valid.</param>
        /// <param name="bookmark">Bookmark of the record. Must not be null.</param>
        internal override void SetPosition(DataError dataError, byte[] bookmark)
        {
            if (bookmark == null)
            {
                throw new ArgumentNullException("bookmark");
            }

            Debug.Assert(this.Record != null);

            NavRecordId recordId = new NavRecordId(bookmark);
            if (this.Record.ALRecordId != recordId)
            {
                if (this.Record.ALCurrentKeyIndex == NavKeyRef.ALPrimaryKeyIndex && dataError == DataError.TrapError)
                {
                    if (!this.Record.ALGet(dataError, recordId))
                    {
                        this.Record.SetPrimaryKeyFieldValues(recordId);
                    }
                }
                else
                {
                    this.Record.ALGet(dataError, recordId);
                }
            }
        }
    }

    #endregion

    #region NsFormDataAccess definition

    internal class NsFormDataAccess : NsDataAccess
    {
        private NavForm form;
        private bool isDisposed;
        private NavFormUpdateType updateType;
        private List<NavFormUpdateParameters> subformUpdateParameters;
        private NavRecordOperationTypes recordState;
        private NavRecord savedRecord;
        private bool listening;
        private List<NavFormSourceExpression> nonRowBasedExpressions;
        private List<NavFormSourceExpression> rowBasedExpressions;

        /// <summary>
        /// Initializes a new instance of the NsFormDataAccess class.
        /// </summary>
        /// <param name="form">Form object to initialize from.</param>
        internal NsFormDataAccess(NavForm form)
        {
            Debug.Assert(form != null);
            this.form = form;
            this.subformUpdateParameters = new List<NavFormUpdateParameters>();
            form.UpdateRequest += new EventHandler<UpdateRequestEventArgs>(this.FormUpdateRequest);
            NavConnection.Current.DataCommittedEvent += new EventHandler(this.GetCommittedData);
        }

        private void FormUpdateRequest(object sender, UpdateRequestEventArgs eventArgs)
        {
            if (sender == null)
            {
                throw new ArgumentNullException("sender");
            }
            if (eventArgs == null)
            {
                throw new ArgumentNullException("eventArgs");
            }

            NavForm sendingForm = sender as NavForm;
            if (sendingForm == null)
            {
                throw new ArgumentException("sender");
            }

            if (sendingForm == this.Form)
            {
                // update is to the parent form
                this.updateType |= eventArgs.UpdateRequestType;
            }
            else
            {
                // If there is already an entry in the list for the subform then find and update it
                bool found = false;
                for (int i = 0; i < this.subformUpdateParameters.Count; i++)
                {
                    if (this.subformUpdateParameters[i].ServerFormHandle == sendingForm.Handle)
                    {
                        NavFormUpdateParameters parameters = this.subformUpdateParameters[i];
                        parameters.UpdateType |= eventArgs.UpdateRequestType;
                        this.subformUpdateParameters[i] = parameters;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    NavFormUpdateParameters parameters = new NavFormUpdateParameters();
                    parameters.ServerFormHandle = sendingForm.Handle;
                    parameters.UpdateType = eventArgs.UpdateRequestType;
                    this.subformUpdateParameters.Add(parameters);
                }
            }
        }

        /// <summary>
        /// Gets access to the underlying form.
        /// </summary>
        public override NavForm Form
        {
            get { return this.form; }
        }

        /// <summary>
        /// Gets access to the updateType.
        /// </summary>
        public override NavFormUpdateType UpdateType
        {
            get { return this.updateType; }
        }

        /// <summary>
        /// Return an array of form update parameters
        /// </summary>
        /// <returns>An array of parameters specifying which forms should be updated and how.</returns>
        public override NavFormUpdateParameters[] GetUpdateParametersArray()
        {
            return this.subformUpdateParameters.ToArray();
        }

        /// <summary>
        /// Gets the forms array of source expressions.
        /// </summary>
        public override IDictionary<String, NavFormSourceExpression> SourceExpressions
        {
            get { return this.Form.SourceExpressions; }
        }

        /// <summary>
        /// Gets the Record through the form.
        /// </summary>
        public override NavRecord Record
        {
            get { return this.Form.SourceTable; }
        }

        /// <summary>
        /// Gets the saved record.
        /// </summary>
        internal override NavRecord SavedRecord
        {
            get
            {
                return this.savedRecord;
            }
        }

        /// <summary>
        /// Gets or sets the state of the record
        /// </summary>
        public override NavRecordOperationTypes RecordState
        {
            get
            {
                if (this.listening &&
                    ((this.recordState & NavRecordOperationTypes.Dirty) == (NavRecordOperationTypes)0) &&
                    this.Record.CompareAllNormalFields(this.savedRecord) == false)
                {
                    this.recordState |= NavRecordOperationTypes.Dirty;
                }

                return this.recordState | base.RecordState;
            }
            set
            {
                this.recordState = value;
            }
        }

        /// <summary>
        /// Gets the internal collection of calculated fileds if it is set; otherwise - a collection of calculated field numbers from the Form metadata. 
        /// Null if Record is null.
        /// </summary>
        public override ICollection<int> CalculatedFields
        {
            get
            {
                if (this.Record != null)
                {
                    return this.CalculatedFieldsInt != null ? this.CalculatedFieldsInt : this.Form.CalculatedFields;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the list or <see cref="NavFormSourceExpression"/> that are not rowbased
        /// </summary>
        internal List<NavFormSourceExpression> NonRowBasedExpressions
        {
            get
            {
                this.GenerateSourceExpressionLists();
                return this.nonRowBasedExpressions;
            }
        }

        /// <summary>
        /// Gets the list of <see cref="NavFormSourceExpression"/> that are rowbased
        /// </summary>
        internal List<NavFormSourceExpression> RowBasedExpressions
        {
            get
            {
                this.GenerateSourceExpressionLists();
                return this.rowBasedExpressions;
            }
        }

        /// <summary>
        /// Create a NavDataSet with the formVariables in a table
        /// </summary>
        /// <returns>Returns the data set.</returns>
        internal NavDataSet GetFormVariablesState()
        {
            NavDataSet dataSet = new NavDataSet();
            dataSet.Locale = CultureInfo.InvariantCulture;
            NavDataTable dataTable = new NavDataTable();
            dataTable.Locale = CultureInfo.InvariantCulture;
            dataTable.TableName = "FormVariables";
            dataSet.Tables.Add(dataTable);
            NsFormDataAccess formDataAccess = this as NsFormDataAccess;
            if (formDataAccess != null && formDataAccess.Form != null)
            {
                foreach (NavFormSourceExpression sourceExpression in formDataAccess.RowBasedExpressions)
                {
                    NSPage.AddFieldToDataTable(sourceExpression.Id, CommonTypeInformation.ResolveClrType(NavNclTypeHelper.GetNavTypeFromType(sourceExpression.Type)), dataTable);
                }
            }
            NavDataRow dataRow = dataTable.NewRow();
            NSRecordBase.PopulateCLRTable(dataTable, this, dataRow);
            dataTable.Rows.Add(dataRow);
            return dataSet;
        }


        private void GenerateSourceExpressionLists()
        {
            if (this.nonRowBasedExpressions == null)
            {
                this.nonRowBasedExpressions = new List<NavFormSourceExpression>();
                this.rowBasedExpressions = new List<NavFormSourceExpression>();
                foreach (DataFieldDefinition dataFieldDefinition in this.Form.MasterPage.Expressions)
                {
                    if (this.SourceExpressions.ContainsKey(dataFieldDefinition.Name))
                    {
                        NavFormSourceExpression sourceExpression = this.SourceExpressions[dataFieldDefinition.Name];
                        if (dataFieldDefinition.Name.EndsWith("_DynamicCaption", StringComparison.OrdinalIgnoreCase))
                        {
                            this.nonRowBasedExpressions.Add(sourceExpression);
                        }
                        else
                        {
                            this.rowBasedExpressions.Add(sourceExpression);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Register to listen to record events
        /// </summary>
        internal override void ListenForRecordEvents()
        {
            if (this.listening || (this.Form == null) || (this.Record == null))
            {
                return;
            }

            this.savedRecord = this.Record.Clone(true);
            this.Form.SourceTableOperationsNotify += new EventHandler<NavRecordEventArgs>(this.RecordNotify);
            this.listening = true;
        }

        private void RecordNotify(object sender, NavRecordEventArgs eventArgs)
        {
            if (sender == null)
            {
                throw new ArgumentNullException("sender");
            }
            if (eventArgs == null)
            {
                throw new ArgumentNullException("eventArgs");
            }

            this.savedRecord.Assign(this.Record);
            this.recordState &= ~NavRecordOperationTypes.Dirty;
            this.recordState |= eventArgs.OperationType;
        }

        /// <summary>
        /// Unregister from listening to record events
        /// </summary>
        internal override void StopListeningForRecordEvents()
        {
            if (!this.listening || (this.Form == null))
            {
                return;
            }
            this.Form.SourceTableOperationsNotify -= new EventHandler<NavRecordEventArgs>(this.RecordNotify);
            this.savedRecord.Dispose();
            this.savedRecord = null;
            this.listening = false;
        }

        /// <summary>
        /// Implementation of the Find method.
        /// </summary>
        /// <param name="searchMethod">The search method</param>
        /// <returns>Returns true on success</returns>
        public override Boolean Find(string searchMethod)
        {
            Boolean found = this.Form.FindRecord(searchMethod);
            if (found)
            {
                CalculateFlowFields();
                this.Form.AfterGetRecord();
            }

            return found;
        }

        /// <summary>
        /// Implementation of the Next method.
        /// </summary>
        /// <param name="steps">The steps.</param>
        /// <returns>Returns the next record.</returns>
        public override Int32 Next(Int32 steps)
        {
            Int32 actualSteps = this.Form.NextRecord(steps);
            if (actualSteps != 0)
            {
                CalculateFlowFields();
                this.Form.AfterGetRecord();
            }

            return actualSteps;
        }

        /// <summary>
        /// Abstraction around NavRecord.Insert
        /// </summary>
        /// <param name="errorLevel">Indicates how to handle errors.</param>
        /// <param name="runApplicationTrigger">Indicates whether to run OnInsert table trigger.</param>
        /// <param name="belowXRec">Flag passed through to form triggers indicating whether there is a previous row to copy from.</param>
        /// <returns>Returns true on success.</returns>
        public override Boolean Insert(DataError errorLevel, Boolean runApplicationTrigger, bool belowXRec)
        {
            if (this.SourceMetadata != null && this.SourceMetadata.InsertAllowed)
            {
                if (this.Form.Insert(belowXRec))
                {
                    return base.Insert(errorLevel, runApplicationTrigger, belowXRec);
                }
            }

            return false;
        }

        /// <summary>
        /// Abstraction around NavRecord.Modify
        /// </summary>
        /// <param name="errorLevel">The error level.</param>
        /// <param name="runTrigger">Indicates whether to run triggers.</param>
        /// <returns>Returns true on success.</returns>
        public override Boolean Modify(DataError errorLevel, Boolean runTrigger)
        {
            if (this.SourceMetadata != null && this.SourceMetadata.ModifyAllowed)
            {
                if (this.Form.Modify())
                {
                    return base.Modify(errorLevel, runTrigger);
                }
            }

            return false;
        }

        /// <summary>
        /// Abstraction around NavRecord.RENAME
        /// </summary>
        /// <param name="errorLevel">Indicates how to handle errors.</param>
        /// <returns>Returns true on success.</returns>
        public override Boolean Rename(DataError errorLevel)
        {
            // Rename runs the record OnRename trigger, and afterwards sets notification through Form.Rename
            if (base.Rename(errorLevel))
            {
                this.Form.Rename();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Abstraction around NavRecord.DELETE
        /// </summary>
        /// <param name="errorLevel">The error level.</param>
        /// <param name="runTrigger">Indicates whether to run triggers.</param>
        /// <returns>Returns true on success.</returns>
        public override Boolean Delete(DataError errorLevel, Boolean runTrigger)
        {
            if (this.SourceMetadata != null && this.SourceMetadata.DeleteAllowed)
            {
                if (this.Form.Delete())
                {
                    return base.Delete(errorLevel, runTrigger);
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the Bookmark of the current record - form implementation.
        /// </summary>
        public override Byte[] Bookmark
        {
            get
            {
                if (this.Record != null)
                {
                    return this.Form.Bookmark.GetBytes();
                }
                else
                {
                    return this.Form.Handle.ToByteArray();
                }
            }
        }

        /// <summary>
        /// IDisposable pattern support.
        /// </summary>
        /// <param name="disposing">Indicates whether to dispose managed data.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!this.isDisposed)
                {
                    if (this.form != null)
                    {
                        this.StopListeningForRecordEvents();
                        this.form.UpdateRequest -= new EventHandler<UpdateRequestEventArgs>(this.FormUpdateRequest);
                        this.form.Dispose();
                    }

                    NavConnection.Current.DataCommittedEvent -= new EventHandler(this.GetCommittedData);
                }
                this.isDisposed = true;
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Sets current position of recDataAccess.Record based on the record bookmark
        /// </summary>
        /// <param name="dataError">Determines whether to throw in case the bookmark is not valid.</param>
        /// <param name="bookmark">Bookmark of the record. Must not be null.</param>
        internal override void SetPosition(DataError dataError, byte[] bookmark)
        {
            if (bookmark == null)
            {
                throw new ArgumentNullException("bookmark");
            }
            if (this.Form.Bookmark.GetBytes() != bookmark)
            {
                this.Form.SetBookmark(dataError, bookmark);
            }
        }

        internal void GetCommittedData(object sender, EventArgs e)
        {
            NavDataSet dataSet = new NavDataSet();
            NavDataTable dataTable = new NavDataTable();
            dataSet.Tables.Add(dataTable);
            NSPage.BuildCLRDataTable(dataTable, null, this);
            NavDataRow row = dataTable.NewRow();

            NavRecord cached = (this.Record != null) ? this.Record.Clone(this.Record.IsTemporary) : null;
            try
            {
                // Get the latest persisted copy of the record
                if (this.Record != null)
                {
                    if (!this.Record.ALGet(DataError.TrapError, this.Record.ALRecordId))
                    {
                        return;
                    }
                }

                NSRecordBase.PopulateCLRTable(dataTable, this, row);
                dataTable.Rows.Add(row);
            }
            finally
            {
                if (cached != null)
                {
                    this.Record.Assign(cached);
                    cached.Dispose();
                }
            }

            NavRecordState dataSetState = NSDatasetState.Create(this);
            NSClientCallback.SendCommittedDataToClient(dataSet, dataSetState);
        }

        /// <summary>
        /// Gets the SourceObjectDefinition if it exists; null if it does not.
        /// </summary>
        private SourceObjectDefinition SourceMetadata
        {
            get
            {
                if ((this.Form.MasterPage != null)
                    && (this.Form.MasterPage.PageProperties != null)
                    && (this.Form.MasterPage.PageProperties.SourceObject != null))
                {
                    return this.Form.MasterPage.PageProperties.SourceObject;
                }
                else
                {
                    return null;
                }
            }
        }
    }

    #endregion
}
