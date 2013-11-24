/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased",
   Scope = "namespace", Target = "Microsoft.VsSDK.UnitTestLibrary")]

[module: SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase",
   Scope = "namespace", Target = "Microsoft.VsSDK.UnitTestLibrary")]

namespace Microsoft.VsSDK.UnitTestLibrary
{
	/// <summary>
	/// Arguments passed to the callback functions used by the GenericMockFactory
	/// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
	public class CallbackArgs : EventArgs
	{
		private object[] parameters;
		private object returnValue;

		/// <summary>
		/// Builds a new CallbackArgs using an array of objects as values for the parameters.
		/// </summary>
		public CallbackArgs(object[] parameters)
		{
			this.parameters = parameters;
		}

		/// <summary>
		/// Get the value of a specific parameter.
		/// </summary>
		public object GetParameter(int index)
		{
			return parameters[index];
		}

		/// <summary>
		/// Set the value of a parameter.
		/// </summary>
		public void SetParameter(int index, object value)
		{
			parameters[index] = value;
		}

		/// <summary>
		/// The return value of the method.
		/// </summary>
		public object ReturnValue
		{
			get { return returnValue; }
			set { returnValue = value; }
		}
	}

	/// <summary>
	/// Base class for dynamicaly generated mock objects.
	/// </summary>
    [System.Runtime.InteropServices.ComVisible(true)]
	public abstract class BaseMock
	{
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		protected Dictionary<string, EventHandler<CallbackArgs>> callbacks;

        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected Dictionary<string, object[]> returnValues;
		private Dictionary<string, object> data;
        private Dictionary<string, int> callsCount;

		protected BaseMock()
		{
			callbacks = new Dictionary<string, EventHandler<CallbackArgs>>();
			returnValues = new Dictionary<string, object[]>();
			data = new Dictionary<string, object>();
            callsCount = new Dictionary<string, int>();
		}

		#region Public methods for Initialization
		/// <summary>
		/// Provide an array of values that will be used as return values in the 
		/// mock object method implementation. Index 0 being the return value index 1
		/// the value assigned to the first parameter (assuming it is ref/out),...
		/// To remove an entry, pass a null ArrayList.
		/// </summary>
		/// <param name="methodName">Name of the method the values are for. Case sensitive.</param>
		/// <param name="valuesToReturn">List of objects to return.
		/// Index 0 is the return value while higher indexes are used for ref/out parameters.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames")]
		public void AddMethodReturnValues(string methodName, object[] returnValues)
		{
			if (this.returnValues.ContainsKey(methodName))
			{
				this.returnValues.Remove(methodName);
			}
			if (returnValues != null)
			{
				this.returnValues.Add(methodName, returnValues);
			}
		}

		/// <summary>
		/// Provide a call back method that the mock object will call when
		/// methodName is called on the mock object.
		/// As long as no value were specified for AddMethodReturnValues,
		/// the callBackMethod can set the value in the array list to set
		/// which value should be returned (return value and ref/out parameters).
		/// To remove an entry pass null as the callBackMethod.
		/// </summary>
		/// <param name="methodName">Name of the method for which the callback is provided</param>
		/// <param name="callBackMethod">Method to call when methodName is called on the mock object</param>
		public void AddMethodCallback(string methodName, EventHandler<CallbackArgs> callback)
		{
			if (callbacks.ContainsKey(methodName))
			{
				callbacks.Remove(methodName);
			}
			if (null != callback)
			{
				callbacks.Add(methodName, callback);
			}
		}

		#endregion

        /// <summary>
        /// Any data that is needed in the implementation of the callback
        /// can be saved here.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object this[string name]
        {
            get { return data[name]; }
            set { this.data[name] = value; }
        }

        #region Functions to handle the conters of funtion calls.
        /// <summary>
        /// Returns the number of times a function is called.
        /// </summary>
        /// <param name="name">Function name.</param>
        public int FunctionCalls(string name)
        {
            if (callsCount.ContainsKey(name))
            {
                return callsCount[name];
            }
            return 0;
        }

        /// <summary>
        /// Returns the sum of the number of times each function exposed by this
        /// object was called.
        /// </summary>
        public int TotalCallsAllFunctions()
        {
            int total = 0;
            foreach (int i in callsCount.Values)
            {
                total += i;
            }
            return total;
        }

        /// <summary>
        /// This function is called by the code generated by the GenericMockFactory
        /// when a function is called.
        /// </summary>
        /// <param name="name">Full name of the function.</param>
        protected void IncrementFunctionCalls(string name)
        {
            // A function name can not be empty.
            if (string.IsNullOrEmpty(name))
                return;

            if (callsCount.ContainsKey(name))
            {
                callsCount[name] += 1;
            }
            else
            {
                callsCount[name] = 1;
            }
        }

        /// <summary>
        /// Clears all the data about the number of times aech function is called.
        /// </summary>
        public void ResetAllFunctionCalls()
        {
            callsCount.Clear();
        }

        /// <summary>
        /// Clears the data about the number of times a specific function is called.
        /// </summary>
        /// <param name="name">Function name.</param>
        public void ResetFunctionCalls(string name)
        {
            if (!string.IsNullOrEmpty(name) && callsCount.ContainsKey(name))
            {
                callsCount.Remove(name);
            }
        }
        #endregion
    }
}
