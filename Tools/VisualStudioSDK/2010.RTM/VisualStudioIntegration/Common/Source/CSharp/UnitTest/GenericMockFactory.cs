/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;

namespace Microsoft.VsSDK.UnitTestLibrary
{
    /// <summary>
    /// This class creates Mock object classes implementing specific interfaces.
    /// </summary>
    public class GenericMockFactory
    {
        private static AssemblyBuilder dynamicAssembly;
        private static ModuleBuilder dynamicModule;
        private static Dictionary<String, Type> cachedTypes;

        private Type generatedType;
        private string className;
        private Type[] interfaces;

        // Static constructor used to initilize the static variables.
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static GenericMockFactory()
        {
            AppDomain domain = System.Threading.Thread.GetDomain();
            AssemblyName assemblyName = new AssemblyName("MockFactoryAssembly");
            dynamicAssembly = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            dynamicModule = dynamicAssembly.DefineDynamicModule("MockFactoryModule", "MockFactoryAssembly.dll", true);
            cachedTypes = new Dictionary<String, Type>();
        }

        static public void Save()
        {
            dynamicAssembly.Save("MockFactoryAssembly.dll");
        }

        /// <summary>
        /// Creates an instance of the factory for a specific class.
        /// </summary>
        /// <param name="className">The name of the class that this factory will create.</param>
        /// <param name="interfaces">The interfaces implemented by the generated class.</param>
        public GenericMockFactory(string className, Type[] interfaces)
        {
            // Initialize the instance's variables.
            this.className = className;
            this.interfaces = interfaces;
        }

        /// <summary>
        /// This is similar to GetGeneratedType, but instead of returning the Type
        /// it returns an instance of that type
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public BaseMock GetInstance()
        {
            return (BaseMock)Activator.CreateInstance(GetGeneratedType());
        }

        /// <summary>
        /// Create a new class type dynamicly.
        /// The type will be derived from BaseMock.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Type GetGeneratedType()
        {
            // Check if we have created this type before;
            if (null == generatedType)
                generatedType = CreateType(className, interfaces);

            return generatedType;
        }

        private static void AddTypeToList(Type t, List<Type> typeList)
        {
            if (typeList.Contains(t))
            {
                return;
            }
            typeList.Add(t);
            foreach (Type i in t.GetInterfaces())
            {
                AddTypeToList(i, typeList);
            }
        }

        /// <summary>
        /// Creates a new class with a given name derived from BaseMock and implementing 
        /// a specific set of interfaces.
        /// </summary>
        /// <param name="className">The name of the class to create.</param>
        /// <param name="interfaces">The interfaces implemented by the generated class.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public static Type CreateType(string className, Type[] interfaces)
        {
            if (cachedTypes.ContainsKey(GetHashForInterfaces(interfaces)))
            {
                return cachedTypes[GetHashForInterfaces(interfaces)];
            }

            // Get some information about the base type
            Type baseType = typeof(BaseMock);

            // Methods and fields about the callbacks
            FieldInfo callbackFieldInfo = baseType.GetField("callbacks", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo callbacksContainsKey = callbackFieldInfo.FieldType.GetMethod("ContainsKey");
            MethodInfo callbackGetItem = callbackFieldInfo.FieldType.GetMethod("get_Item");
            ConstructorInfo callbackArgsCtr = typeof(CallbackArgs).GetConstructor(new Type[] { typeof(object[]) });
            MethodInfo callbackInvoke = typeof(EventHandler<CallbackArgs>).GetMethod("Invoke");
            MethodInfo callbackArgsGetParam = typeof(CallbackArgs).GetMethod("GetParameter");
            MethodInfo callbackArgsGetRetVal = typeof(CallbackArgs).GetMethod("get_ReturnValue");

            // Utility functions exposed by the base class
            MethodInfo incrementCallCount = baseType.GetMethod("IncrementFunctionCalls", BindingFlags.Instance | BindingFlags.NonPublic);

            // Methods and fields about the return values.
            FieldInfo retValuesFieldInfo = baseType.GetField("returnValues", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo retValuesContainsKey = retValuesFieldInfo.FieldType.GetMethod("ContainsKey");
            MethodInfo retValuesGetItem = retValuesFieldInfo.FieldType.GetMethod("get_Item");
            MethodInfo arrayGetLength = typeof(object[]).GetMethod("get_Length");

            // Build the list of the interfaces to implement.
            // Note that if we have a COM interface I2 that derives from the COM interface I1
            // we have to implement also I1, even if I2 implements all the methods of the base
            // interface.
            List<Type> typeList = new List<Type>();
            foreach (Type t in interfaces)
            {
                AddTypeToList(t, typeList);
            }

            // Create the type builder for this type; the new type will be a class derived
            // from the BaseType class.
            TypeBuilder newType = dynamicModule.DefineType(className, TypeAttributes.Class | TypeAttributes.Public, baseType);

            // Set the ComVisible attribute for the type. This will enable unit testing of interop scenarios where the
            // mock objetcs are supposed to implement IDispatch.
            ConstructorInfo comVisibleAttributeCtr = typeof(System.Runtime.InteropServices.ComVisibleAttribute).GetConstructor(new Type[] { typeof(bool) });
            CustomAttributeBuilder customAttribute = new CustomAttributeBuilder(comVisibleAttributeCtr, new object[] { true });
            newType.SetCustomAttribute(customAttribute);

            foreach (Type t in typeList)
            {
                // Add the informations about the implemented interface. We don't check if the type
                // is an interface because the check is performed by AddInterfaceImplementation.
                newType.AddInterfaceImplementation(t);

                // Now we have to create the interface's methods. 
                foreach (MethodInfo method in t.GetMethods())
                {
                    // Build the full name of this method; this name will also be used as index
                    // in the Disctionary of callbaks.
                    string fullMethodName = string.Format(System.Globalization.CultureInfo.InvariantCulture,
                                                          "{0}.{1}", t.FullName, method.Name);
                    Trace.WriteLine("Building method: " + fullMethodName);

                    // Get the information about parameters.
                    ParameterInfo[] parameters = method.GetParameters();
                    // Now build the array with the type of the parameters.
                    Type[] paramTypes = new Type[parameters.Length];
                    for (int i = 0; i < parameters.Length; ++i)
                    {
                        paramTypes[i] = parameters[i].ParameterType;
                    }

                    // Create a the method build with the informations about the parameter's type
                    // and the return value.
                    MethodBuilder methodBuilder = newType.DefineMethod(
                                                    fullMethodName,
                                                    MethodAttributes.Virtual | MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.NewSlot | MethodAttributes.HideBySig,
                                                    method.ReturnType,
                                                    paramTypes);
                    methodBuilder.SetImplementationFlags(MethodImplAttributes.IL | MethodImplAttributes.Managed);

                    // Add all the attributes to the parameters (e.g. 'out', 'in', ...).
                    foreach (ParameterInfo param in parameters)
                    {
                        methodBuilder.DefineParameter(param.Position + 1, param.Attributes, param.Name);
                    }


                    // Now we have to add the code for the method.
                    // The implementation of the method is simple: it will check if there is a
                    // callback defined for it; if there is no callback then it will return,
                    // otherwise it will call the event handler and return.
                    ILGenerator methodCode = methodBuilder.GetILGenerator();

                    // Define the local variables.
                    LocalBuilder paramValues = methodCode.DeclareLocal(typeof(object[]));
                    LocalBuilder callbackArgs = methodCode.DeclareLocal(typeof(CallbackArgs));
                    LocalBuilder retValuesArray = methodCode.DeclareLocal(typeof(object[]));

                    // Define the labels needed inside the method.
                    Label callbackNotDefined = methodCode.DefineLabel();
                    Label retValuesNotDefined = methodCode.DefineLabel();

                    // The first operation is to increment the counter for the calls to this function
                    methodCode.Emit(OpCodes.Ldarg_0);                   // this
                    methodCode.Emit(OpCodes.Ldstr, fullMethodName);     // Method name
                    methodCode.Emit(OpCodes.Call, incrementCallCount);  // Call the function
                    // IncrementFunctionCalls is a void function, so now the stack is clear.

                    // Check if there is a callback defined for this method
                    methodCode.Emit(OpCodes.Ldarg_0);				   // "this"
                    methodCode.Emit(OpCodes.Ldfld, callbackFieldInfo);  // get the dictionary of callbacks
                    methodCode.Emit(OpCodes.Ldstr, fullMethodName);	 // name of this method.
                    methodCode.Emit(OpCodes.Callvirt, callbacksContainsKey);

                    // Check the return code
                    methodCode.Emit(OpCodes.Ldc_I4_0);
                    methodCode.Emit(OpCodes.Beq, callbackNotDefined);

                    // Here the callback function is defined

                    // Create an array of objects with the values of the parameters.
                    methodCode.Emit(OpCodes.Ldc_I4_S, parameters.Length);
                    methodCode.Emit(OpCodes.Newarr, typeof(object));
                    methodCode.Emit(OpCodes.Stloc, paramValues);

                    // Set the values of the parameters.
                    foreach (ParameterInfo paramInfo in parameters)
                    {
                        methodCode.Emit(OpCodes.Ldloc, paramValues);
                        methodCode.Emit(OpCodes.Ldc_I4, paramInfo.Position);

                        methodCode.Emit(OpCodes.Ldarg, paramInfo.Position + 1);   // Parameter 0 is "this"
                        // If this parameter is a reference we have to get the referenced value.
                        if (paramInfo.ParameterType.IsByRef)
                        {
                            Type elemType = paramInfo.ParameterType.GetElementType();
                            if (elemType.IsValueType)
                            {
                                if (elemType.IsPrimitive)
                                {
                                    // Here we assume that element types are I4, but actually we should
                                    // consider I1,...,I8
                                    methodCode.Emit(OpCodes.Ldind_I4);
                                }
                                else
                                {
                                    methodCode.Emit(OpCodes.Ldobj, elemType);
                                }
                                methodCode.Emit(OpCodes.Box, elemType);
                            }
                            else
                            {
                                methodCode.Emit(OpCodes.Ldind_Ref);
                            }
                        }
                        if (paramInfo.ParameterType.IsValueType)
                        {
                            methodCode.Emit(OpCodes.Box, paramInfo.ParameterType);
                        }

                        methodCode.Emit(OpCodes.Stelem_Ref);
                    }

                    // Create the CallbackArgs variable using the array of parameter's values
                    methodCode.Emit(OpCodes.Ldloc, paramValues);
                    methodCode.Emit(OpCodes.Newobj, callbackArgsCtr);
                    methodCode.Emit(OpCodes.Stloc, callbackArgs);

                    // Get the callback function.
                    methodCode.Emit(OpCodes.Ldarg_0);
                    methodCode.Emit(OpCodes.Ldfld, callbackFieldInfo);
                    methodCode.Emit(OpCodes.Ldstr, fullMethodName);
                    methodCode.Emit(OpCodes.Callvirt, callbackGetItem);

                    // Keep the callback function on the stack as "this" pointer and
                    // add the other parameters.
                    methodCode.Emit(OpCodes.Ldarg_0);			   // Use this object as sender.
                    methodCode.Emit(OpCodes.Ldloc, callbackArgs);   // The arguments to the callback.
                    methodCode.Emit(OpCodes.Callvirt, callbackInvoke);

                    // After calling the callback we should set the values of the out parameters.
                    foreach (ParameterInfo param in parameters)
                    {
                        if (!param.ParameterType.IsByRef)
                        {
                            continue;
                        }
                        methodCode.Emit(OpCodes.Ldarg, param.Position + 1);
                        methodCode.Emit(OpCodes.Ldloc, callbackArgs);
                        methodCode.Emit(OpCodes.Ldc_I4, param.Position);
                        methodCode.Emit(OpCodes.Callvirt, callbackArgsGetParam);
                        if (param.ParameterType.GetElementType().IsValueType)
                        {
                            methodCode.Emit(OpCodes.Unbox_Any, param.ParameterType.GetElementType());
                            if (param.ParameterType.GetElementType().IsPrimitive)
                            {
                                // Right now we assume this is I4, but actually we should check
                                // for I1,...,I8
                                methodCode.Emit(OpCodes.Stind_I4);
                            }
                            else
                            {
                                methodCode.Emit(OpCodes.Stobj, param.ParameterType.GetElementType());
                            }
                        }
                        else
                        {
                            methodCode.Emit(OpCodes.Stind_Ref);
                        }
                    }

                    // The last step is to set the return value
                    if (method.ReturnType != typeof(void))
                    {
                        // Get the return code from the callback arguments
                        methodCode.Emit(OpCodes.Ldloc, callbackArgs);
                        methodCode.Emit(OpCodes.Callvirt, callbackArgsGetRetVal);
                        // If the return code of this method is object, no conversion is needed,
                        // otherwise we have to cast this value to the right type.
                        if (method.ReturnType != typeof(object))
                        {
                            // Here we have to switch on three case: a value type that needs unboxing,
                            // strings and any other type.
                            if (method.ReturnType.IsValueType)
                            {
                                // Unbox the type; notice that this will throw if the object is null
                                // or there is no conversion to the requested type.
                                methodCode.Emit(OpCodes.Unbox_Any, method.ReturnType);
                            }
                            else
                            {
                                // In all the other cases call the cast function.
                                methodCode.Emit(OpCodes.Castclass, method.ReturnType);
                            }
                        }
                    }
                    // Now the return value (if needed) is on the stack, so we can exit.
                    methodCode.Emit(OpCodes.Ret);

                    // ============================================================================
                    // Here we add the code for the case the callback is not defined.
                    methodCode.MarkLabel(callbackNotDefined);

                    // Check if there is an array of return values for this method.
                    // Check if there is a callback defined for this method
                    methodCode.Emit(OpCodes.Ldarg_0);				   // "this"
                    methodCode.Emit(OpCodes.Ldfld, retValuesFieldInfo); // get the dictionary of return values
                    methodCode.Emit(OpCodes.Ldstr, fullMethodName);	 // name of this method.
                    methodCode.Emit(OpCodes.Callvirt, retValuesContainsKey);

                    // Check the return code
                    methodCode.Emit(OpCodes.Ldc_I4_0);
                    methodCode.Emit(OpCodes.Beq, retValuesNotDefined);

                    // There is an entry for this method in the dictionary of return values.
                    // Get the array of values.
                    methodCode.Emit(OpCodes.Ldarg_0);
                    methodCode.Emit(OpCodes.Ldfld, retValuesFieldInfo);
                    methodCode.Emit(OpCodes.Ldstr, fullMethodName);
                    methodCode.Emit(OpCodes.Callvirt, retValuesGetItem);
                    methodCode.Emit(OpCodes.Stloc, retValuesArray);

                    // The array of return values contains in the first element the return value,
                    // then a value to assign to each parameter. The first step is to set the value
                    // of the ByRef parameters.
                    int offset = (method.ReturnType == typeof(void)) ? 0 : 1;
                    foreach (ParameterInfo paramInfo in parameters)
                    {
                        // If this parameter is not ByRef we can skip it.
                        if (!paramInfo.ParameterType.IsByRef)
                            continue;

                        // Put the parameter on the stack (add 1 because 0 is "this")
                        methodCode.Emit(OpCodes.Ldarg, paramInfo.Position + 1);

                        // Get the element in the array of values.
                        // Notice that we want an exception here if the element is not present.
                        methodCode.Emit(OpCodes.Ldloc, retValuesArray);
                        methodCode.Emit(OpCodes.Ldc_I4, paramInfo.Position + offset);
                        methodCode.Emit(OpCodes.Ldelem_Ref);

                        // Now the element is the first on the stack, so we can convert it to
                        // the type of the parameter.
                        Type elemType = paramInfo.ParameterType.GetElementType();
                        if (elemType.IsValueType)
                        {
                            methodCode.Emit(OpCodes.Unbox_Any, elemType);
                            if (elemType.IsPrimitive)
                            {
                                // As always we assume this is I4, but we should check for I1,...,I8
                                methodCode.Emit(OpCodes.Stind_I4);
                            }
                            else
                            {
                                methodCode.Emit(OpCodes.Stobj, elemType);
                            }
                        }
                        else
                        {
                            methodCode.Emit(OpCodes.Stind_Ref);
                        }
                    }

                    // Now that the parameters are done we have to set the return value.
                    if (method.ReturnType != typeof(void))
                    {
                        // Get the first element of the array
                        methodCode.Emit(OpCodes.Ldloc, retValuesArray);
                        methodCode.Emit(OpCodes.Ldc_I4_0);
                        methodCode.Emit(OpCodes.Ldelem_Ref);

                        // If the return type is object we don't need any conversion.
                        if (method.ReturnType != typeof(object))
                        {
                            if (method.ReturnType.IsValueType)
                            {
                                methodCode.Emit(OpCodes.Unbox_Any, method.ReturnType);
                            }
                            else
                            {
                                methodCode.Emit(OpCodes.Castclass, method.ReturnType);
                            }
                        }
                    }
                    methodCode.Emit(OpCodes.Ret);

                    // ============================================================================
                    // Here there is no return code defined and no callback, so we return a defaul
                    methodCode.MarkLabel(retValuesNotDefined);

                    // Simply return setting a return code if the method does not return void.
                    if (method.ReturnType != typeof(void))
                    {
                        // The first check should be if the return type is object because in this
                        // case it is assignable from any other type and this can cause unexpected
                        // results.
                        if (method.ReturnType == typeof(object))
                        {
                            methodCode.Emit(OpCodes.Ldnull);
                        }
                        else if (method.ReturnType.IsAssignableFrom(typeof(int)))
                        {
                            methodCode.Emit(OpCodes.Ldc_I4_0);
                        }
                        else if (method.ReturnType.IsValueType)
                        {
                            // Return a not initialized instance of the value type.
                            LocalBuilder localRetVal = methodCode.DeclareLocal(method.ReturnType);
                            methodCode.Emit(OpCodes.Ldloc, localRetVal);
                        }
                        else
                        {
                            methodCode.Emit(OpCodes.Ldnull);
                        }
                    }
                    methodCode.Emit(OpCodes.Ret);

                    // Now that we have the method implementation, let's declare it as the
                    // override of the interface's method.
                    newType.DefineMethodOverride(methodBuilder, method);
                }

            }
            cachedTypes.Add(GetHashForInterfaces(interfaces), newType);
            return newType.CreateType();
        }

        private static String GetHashForInterfaces(Type[] interfaces)
        {
            SortedList<String, Guid> sortedInterfaces = new SortedList<String, Guid>();
            foreach (Type type in interfaces)
            {
                sortedInterfaces.Add(type.GUID.ToString(), type.GUID);
            }

            String hash = "";
            foreach (String guid in sortedInterfaces.Keys)
            {
                hash = hash + guid;
            }
            return hash;
        }

    }


}
