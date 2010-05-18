/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", Scope = "resource", Target = "Microsoft.VisualStudio.Tools.Resources.resources")]

namespace Microsoft.VisualStudio.Tools {

    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;

    /// <include file='doc\RegPkg.uex' path='docs/doc[@for="RegPkg"]/*' />
    /// <devdoc>
    /// Registers a Visual Studio package.
    /// </devdoc>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Pkg")]
    public static class RegPkg {

        public enum RegistrationMode {
            None = 0x0,
            Register = 0x1,
            [SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased")]
            VRG = 0x2,
            [SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased")]
            REG = 0x3,
            [SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased")]
            RGS = 0x4,
            [SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased")]
            [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
            RGS_RGM = 0x5,
            [SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased")]
            WIX = 0x6,
            Unregister = 0x7,
            [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
            PkgDef = 0x8
        };

        private static string RegistrationNameFromMode(RegistrationMode mode) {
            string modeName = null;
            switch (mode) {
                case RegistrationMode.None:
                case RegistrationMode.Register:
                    modeName = string.Empty;
                    break;

                case RegistrationMode.VRG:
                    modeName = "vrgfile";
                    break;

                case RegistrationMode.REG:
                    modeName = "regfile";
                    break;

                case RegistrationMode.RGS:
                case RegistrationMode.RGS_RGM:
                    modeName = "rgsfile";
                    break;

                case RegistrationMode.WIX:
                    modeName = "wixfile";
                    break;

                case RegistrationMode.PkgDef:
                    modeName = "pkgdeffile";
                    break;

                default:
                    throw new ArgumentException(Resources.UnknownMode);
            }

            return modeName;
        }

        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct ParseResult {
            [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public RegistrationMode mode;
            [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public string fileName;
            [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public string outputFile;
            [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public string registryRoot;
            [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public RegistrationMethod registrationMethod;
            [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public bool isRANU;
        }

        private static bool consoleMode;
        private static string outFile;


        /// <include file='doc\RegPkg.uex' path='docs/doc[@for="RegPkg.CreateReg"]/*' />
        /// <devdoc>
        /// Creates regfile format data for the given file name.
        /// </devdoc>
        public static string CreateReg(ParseResult args) {
            if (string.IsNullOrEmpty(args.fileName)) {
                throw new ArgumentNullException("fileName");
            }

            // Calcuate the registry root
            //
            RegistryRoot regRoot = new RegistryRoot(args.fileName, args.registryRoot, args.isRANU);

            RegFileHive hive = new RegFileHive(regRoot);
            using (RegPkgContext cxt = new RegPkgContext(hive, args.registrationMethod)) {
                ProcessAssembly(args.fileName, hive, cxt, true, RegistrationMode.REG);
                return hive.ToString();
            }
        }

        /// <include file='doc\RegPkg.uex' path='docs/doc[@for="RegPkg.CreatePkgDef"]/*' />
        /// <devdoc>
        /// Creates pkgdef format data for the given file name.
        /// </devdoc>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public static string CreatePkgDef(ParseResult args) {
            if (string.IsNullOrEmpty(args.fileName)) {
                throw new ArgumentNullException("fileName");
            }

            PkgDefFileHive hive = new PkgDefFileHive();
            using (RegPkgContext cxt = new RegPkgContext(hive, args.registrationMethod)) {
                ProcessAssembly(args.fileName, hive, cxt, true, RegistrationMode.PkgDef);
                return hive.ToString();
            }
        }

        /// <include file='doc\RegPkg.uex' path='docs/doc[@for="RegPkg.CreateRgs"]/*' />
        /// <devdoc>
        /// Creates rgsfile format data for the given file name.
        /// </devdoc>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Rgs")]
        public static string[] CreateRgs(ParseResult args) {
            if (string.IsNullOrEmpty(args.fileName)) {
                throw new ArgumentNullException("fileName");
            }

            // Calcuate the registry root
            //
            RegistryRoot regRoot = new RegistryRoot(args.fileName, args.registryRoot, args.isRANU);

            bool createRgm = (RegistrationMode.RGS_RGM == args.mode);
            RgsFileHive hive = new RgsFileHive(regRoot, createRgm);
            using (RegPkgContext cxt = new RegPkgContext(hive, args.registrationMethod)) {
                ProcessAssembly(args.fileName, hive, cxt, true, RegistrationMode.RGS);
                return hive.GetStrings();
            }
        }

        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Wix")]
        public static string CreateWix(ParseResult args) {
            if (string.IsNullOrEmpty(args.fileName)) {
                throw new ArgumentNullException("fileName");
            }

            // Create the RegistryRoot object.
            RegistryRoot regRoot = new RegistryRoot(args.fileName, args.registryRoot, args.isRANU);

            WixRegHive hive = new WixRegHive(regRoot, args.fileName);
            using (RegPkgContext cxt = new RegPkgContext(hive, args.registrationMethod)) {
                ProcessAssembly(args.fileName, hive, cxt, true, RegistrationMode.WIX);
                return hive.ToString();
            }
        }

        /// <include file='doc\RegPkg.uex' path='docs/doc[@for="RegPkg.CreateVrg"]/*' />
        /// <devdoc>
        /// Creates vrgfile format data for the given file name.
        /// </devdoc>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Vrg")]
        public static string CreateVrg(ParseResult args) {
            if (string.IsNullOrEmpty(args.fileName)) {
                throw new ArgumentNullException("fileName");
            }

            // Calcuate the registry root
            //
            RegistryRoot regRoot = new RegistryRoot(args.fileName, args.registryRoot, args.isRANU);

            RegFileHive hive = new VrgFileHive(regRoot);
            using (RegPkgContext cxt = new RegPkgContext(hive, args.registrationMethod)) {
                ProcessAssembly(args.fileName, hive, cxt, true, RegistrationMode.VRG);
                return hive.ToString();
            }
        }

        /// <devdoc>
        ///     This method looks for the MsiTokenAttribute with the given name,
        ///     and if it finds it, returns the value.  If it doesn't find it
        ///     it will return "name", which is the default value of the token.
        /// </devdoc>
        private static string GetTokenValue(Type componentType, string name) {
            object[] attrs = componentType.GetCustomAttributes(typeof(MsiTokenAttribute), true);
            foreach(MsiTokenAttribute attr in attrs) {
                if (attr.Name.Equals(name)) {
                    return attr.Value;
                }
            }
            return name;
        }

        /// <devdoc>
        ///     Helper routine.  Returns "true" if value matches arg.
        ///     Does some smart checking based on arguments that can
        ///     have colons.
        /// </devdoc>
        private static bool IsArg(string value, string arg, bool supportColon) {
            // if "arg" has a : in it, parse that off.
            //
            if (supportColon) {
                int index = value.IndexOf(':');
                if (index != -1) {
                    value = value.Substring(0, index);
                }
            }
            return string.Compare(value, arg, StringComparison.OrdinalIgnoreCase) == 0;
        }

        /// <devdoc>
        ///     Main entry point.  Usage:
        ///
        ///     regpkg [/root:<root>] [/regfile:<regfile>] [/rgsfile:<rgsfile> [/rgm]] [/vrgfile:<vrgfile>] [/codebase | /assembly] [/unregister] AssemblyPath
        ///
        ///     Option                  Description
        ///     ------------------------------------
        ///     /root:root              The Visual Studio root to apply the registration to.  If no
        ///                             root is specified the root will be taken from the
        ///                             DefaultRegistryRootAttribute on the packages in the assembly.
        ///                             If there is more than one root listed, this is an error and
        ///                             registration will terminate. If the /pkgdef switch is used,
        ///                             then this value is ignored.
        ///     /regfile:regfile        Instead of making changes to the registry, this option will
        ///                             route changes to the provided registry file.  Cannot be used
        ///                             in conjunction with /vrgfile or /rgsfile.
        ///     /rgsfile:rgsfile        Instead of making changes to the registry, this option will
        ///                             route changes to the provided registry file.  Cannot be used
        ///                             in conjunction with /vrgfile or /regfile.
        ///     /rgm                    Only valid when used in conjunction with /rgsfile, this option
        ///                             will generate a corresponding rgm merge file.
        ///     /vrgfile:vrgfile        Instead of making changes to the registry, this option will
        ///                             create a MSI compliant vrg file.  Cannot be used in
        ///                             conjunction with /root or /regfile or /rgsfile
        ///     /wixfile:WixFile        Creates a registration script compatible with Wix's XML format.
        /// 
        ///     /codebase | /assembly   Registers objects with the CodeBase specification in the registry
        ///                             if /codebase is specified.  Registers objects with the Assembly
        ///                             specification in the registry.  Overrides the default setting of 
        ///                             the package and its objects.
        ///     /RANU                   Register the package inside the user's specific registry hive.
        ///                             This parameter can be used to develop the package with an user
        ///                             account that is not a machine's administrator.
        ///     /unregister             Removes the registration information from the registry.  
        ///                             Cannot be used with /regfile or /vrgfile
        ///     AssemblyPath            The path to the file name to register.
        ///
        /// </devdoc>
        private static int Main(string[] arguments) {

            consoleMode = true;

            try {
                ParseResult parseResult = ParseArgs(arguments);
                outFile = parseResult.outputFile;
                switch(parseResult.mode) {
                    case RegistrationMode.Register:
                        Register(parseResult);
                        break;
                    case RegistrationMode.VRG:
                        WriteFile(CreateVrg(parseResult), outFile);
                        break;
                    case RegistrationMode.REG:
                        WriteFile(CreateReg(parseResult), outFile);
                        break;
                    case RegistrationMode.PkgDef:
                        WriteFile(CreatePkgDef(parseResult), outFile);
                        break;
                    case RegistrationMode.RGS:
                        WriteFile(CreateRgs(parseResult)[0], outFile);
                        break;
                    case RegistrationMode.RGS_RGM:
                        string[] files = CreateRgs(parseResult);
                        WriteFile(files[0], outFile);
                        WriteFile(files[1], Path.ChangeExtension(outFile, ".rgm"));
                        break;
                    case RegistrationMode.WIX:
                        WriteFile(CreateWix(parseResult), outFile);
                        break;
                    case RegistrationMode.Unregister:
                        Unregister(parseResult);
                        break;
                    default:
                        WriteLine(Resources.RegPkg_Usage);
                        break;
                }
            }
            catch (Exception e) {
                ReflectionTypeLoadException typeLoadException = e as ReflectionTypeLoadException;
                if (null != typeLoadException) {
                    Console.Error.WriteLine(string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_Error, typeLoadException.Message));
                    foreach(Exception exLoader in typeLoadException.LoaderExceptions) {
                        Console.Error.WriteLine(exLoader.Message);
                    }
                }
                else {
                    while (e != null) {
                        if (e.Message != null && e.Message.Length > 0) {
                            Console.Error.WriteLine(string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_Error, e.Message));
                        }
                        e = e.InnerException;
                    }
                }
                return 1;
            }
            return 0;
        }

        /// <devdoc>
        ///     Parses arguments.  Throws an exception if there is an error in argument parsing.
        ///     Returns a MODE constant to register in a partiulcar mode, or 0 to do nothing.
        /// </devdoc>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        private static ParseResult ParseArgs(string[] arguments) {

            ParseResult result;
            result.mode = 0;
            bool createRgm = false;
            result.registryRoot = null;
            result.outputFile = null;
            result.fileName = null;
            result.isRANU = false;

            result.registrationMethod = RegistrationMethod.Default;

            for (int i = 0; i < arguments.Length; i++) {
                string arg = arguments[i];
                if (string.IsNullOrEmpty(arg)) {
                    continue;
                }
                arg = arg.Trim();
                if (string.IsNullOrEmpty(arg)) {
                    continue;
                }
                if (arg[0] == '/' || arg[0] == '-') {
                    arg = arg.Substring(1);
                }
                else {
                    if (result.fileName != null) {
                        throw new ArgumentException(Resources.RegPkg_MultipleFiles);
                    }
                    result.fileName = arg;
                    if (!File.Exists(result.fileName)) {
                        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_FileNotExist, result.fileName));
                    }
                    continue;
                }

                if (IsArg(arg, "unregister", false)) {
                    ValidateMode(result.mode, RegistrationMode.Unregister);
                    result.mode = RegistrationMode.Unregister;
                }
                else if (IsArg(arg, "regfile", true)) {
                    ValidateMode(result.mode, RegistrationMode.REG);
                    result.mode = RegistrationMode.REG;
                    result.outputFile = ParseSubArg(arg);
                }
                else if (IsArg(arg, "pkgdeffile", true)) {
                  ValidateMode(result.mode, RegistrationMode.PkgDef);
                  result.mode = RegistrationMode.PkgDef;
                  result.outputFile = ParseSubArg(arg);
                }
                else if (IsArg(arg, "rgsfile", true)) {
                    ValidateMode(result.mode, RegistrationMode.RGS);
                    result.mode = RegistrationMode.RGS;
                    result.outputFile = ParseSubArg(arg);
                }
                else if (IsArg(arg, "vrgfile", true)) {
                    ValidateMode(result.mode, RegistrationMode.VRG);
                    result.mode = RegistrationMode.VRG;
                    result.outputFile = ParseSubArg(arg);
                }
                else if (IsArg(arg, "wixfile", true)) {
                    ValidateMode(result.mode, RegistrationMode.WIX);
                    result.mode = RegistrationMode.WIX;
                    result.outputFile = ParseSubArg(arg);
                }
                else if (IsArg(arg, "codebase", true)) {
                    if (result.registrationMethod != RegistrationMethod.Default)
                        throw new ArgumentException(Resources.RegPkg_MultipleRegistrationMethods);
                    result.registrationMethod = RegistrationMethod.CodeBase;
                }
                else if (IsArg(arg, "assembly", true)) {
                    if (result.registrationMethod != RegistrationMethod.Default)
                        throw new ArgumentException(Resources.RegPkg_MultipleRegistrationMethods);
                    result.registrationMethod = RegistrationMethod.Assembly;
                }

                else if (IsArg(arg, "root", true)) {
                    if (result.registryRoot != null) {
                        throw new ArgumentException(Resources.RegPkg_MultipleRoots);
                    }
                    result.registryRoot = ParseSubArg(arg);
                }
                else if (IsArg(arg, "rgm", false)) {
                    createRgm = true;
                }
                else if (IsArg(arg, "ranu", false)) {
                    result.isRANU = true;
                }
                else if (IsArg(arg, "?", false) || IsArg(arg, "help", false)) {
                    // abort the parse loop.  Returning a zero mode
                    // will cause main to print the usage.
                    result.mode = RegistrationMode.None;
                    return result;
                }
                else {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_InvalidParameter, arg));
                }
            }

            if (result.mode == 0 && result.fileName != null) {
                result.mode = RegistrationMode.Register;
            }

            if (createRgm) {
                if (result.mode != RegistrationMode.RGS) {
                    throw new ArgumentException(Resources.RegPkg_RgmNeedsRgs);
                }
                else {
                    result.mode = RegistrationMode.RGS_RGM;
                }
            }

            if (result.mode != 0 && result.fileName == null) {
                throw new ArgumentException(Resources.RegPkg_NoFileSpecified);
            }

            return result;
        }

        /// <devdoc>
        ///     Parses a sub argument.  Sub arguments are arguments that
        ///     come after a ":" in an argument.
        /// </devdoc>
        private static string ParseSubArg(string arg) {
            // First, check if anything lives after the : in arg
            int index = arg.IndexOf(':');
            if (index == -1) {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_MalformedArg, arg));
            }

            string subArg = null;

            index++;
            if (index < arg.Length) {
                subArg = arg.Substring(index).Trim();
            }

            if (string.IsNullOrEmpty(subArg)) {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_MissingSubarg, arg));
            }

            return subArg;
        }

        /// <devdoc>
        ///     This is the core registration routine.  It takes in a file and
        ///     a Hive object and creates the assembly information on the hive.
        /// </devdoc>
        [SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Reflection.Assembly.LoadFrom")]
        public static void ProcessAssembly(string fileName, Hive hive, RegPkgContext context, bool register, RegistrationMode mode) {

            // Open the assembly and grock its data.  For each interesting type
            // we need to set it into our context.
            //
            Assembly a = Assembly.LoadFrom(fileName);
            AssemblyName name = a.GetName();

            string regText = null;
            string rootText = string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_NotifyRoot, hive.Root);

            switch (mode)
            {
                case RegistrationMode.Register:
                    regText = string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_NotifyFileRegistering, name.Name, name.Version);
                    break;

                case RegistrationMode.VRG:
                    regText = string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_NotifyFileCreatingVRG, name.Name, name.Version, outFile);
                    break;

                case RegistrationMode.REG:
                    regText = string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_NotifyFileCreatingREG, name.Name, name.Version, outFile);
                    break;

                case RegistrationMode.PkgDef:
                    regText = string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_NotifyFileCreatingPkgDef, name.Name, name.Version, outFile);
                    break;

                case RegistrationMode.RGS:
                case RegistrationMode.RGS_RGM:
                    regText = string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_NotifyFileCreatingRGS, name.Name, name.Version, outFile);
                    break;

                case RegistrationMode.WIX:
                    regText = string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_NotifyFileCreatingWIX, name.Name, name.Version, outFile);
                    break;

                case RegistrationMode.Unregister:
                    regText = string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_NotifyFileUnregistering, name.Name, name.Version);
                    break;

                default:
                    throw new ArgumentException();
            }

            int maxText = rootText.Length;
            if (regText.Length > maxText)
            {
                maxText = regText.Length;
            }

            string b = new string('-', maxText);

            WriteLine(regText);
            WriteLine(rootText);
            WriteLine(b);

            // We need to sort types and attributes so that our output
            // is consistent.
            SortedList<Type,ArrayList> registrationTypes = new SortedList<Type, ArrayList>(TypeComparer.Default);

            foreach(Type t in a.GetTypes()) {

                // Seach the custom attributes of this type for something that
                // derives from RegistrationAttribute.  If we find it, register
                // it.
                //
                if (!t.IsAbstract) {
                    foreach (object attr in t.GetCustomAttributes(true)) {
                        if (attr is RegistrationAttribute) {
                            ArrayList list;
                            if (!registrationTypes.TryGetValue(t, out list)) {
                                list = new ArrayList();
                                registrationTypes.Add(t, list);
                            }

                            list.Add(attr);
                        }
                    }
                }
            }

            // Check if there is something to register. If no registration
            // attribute is provided, then raise an exception to notify the
            // user that nothing will happen.
            if (registrationTypes.Count == 0) {
                throw new ArgumentException(Resources.RegPkg_NoRegistrationData);
            }

            foreach(KeyValuePair<Type, ArrayList> kv in registrationTypes) {

                bool setType = false;
                kv.Value.Sort(RegistrationAttributeComparer.Default);

                foreach (RegistrationAttribute regAttr in kv.Value) {
                    // Setup the data in our context for this type.
                    //
                    if (!setType) {
                        setType = true;
                        context.SetType(kv.Key);
                    }

                    if (register)
                    {
                        regAttr.Register(context);
                    }
                    else
                    {
                        regAttr.Unregister(context);
                    }
                }
            }

            WriteLine(string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_Success, name.Name));
        }

        /// <include file='doc\RegPkg.uex' path='docs/doc[@for="RegPkg.Register"]/*' />
        /// <devdoc>
        /// Public API that registers the given filename under the given root.  If
        /// no root is specified this uses the default root for the assembly.
        /// </devdoc>
        public static void Register(ParseResult args) {
            if (string.IsNullOrEmpty(args.fileName)) {
                throw new ArgumentNullException("fileName");
            }

            // Calcuate the registry root
            //
            RegistryRoot regRoot = new RegistryRoot(args.fileName, args.registryRoot, args.isRANU);

            RegHive hive = new RegHive(regRoot);
            using (RegPkgContext cxt = new RegPkgContext(hive, args.registrationMethod)) {
                ProcessAssembly(args.fileName, hive, cxt, true, RegistrationMode.Register);
                hive.Close();
            }
        }

        /// <include file='doc\RegPkg.uex' path='docs/doc[@for="RegPkg.Unregister"]/*' />
        /// <devdoc>
        /// Public API that unregisters the given file name for the given root.  If
        /// no root is specified this uses the default root for the assembly.
        /// </devdoc>
        public static void Unregister(ParseResult args) {
            if (string.IsNullOrEmpty(args.fileName)) {
                throw new ArgumentNullException("fileName");
            }

            // Calcuate the registry root
            //
            RegistryRoot regRoot = new RegistryRoot(args.fileName, args.registryRoot, args.isRANU);

            RegHive hive = new RegHive(regRoot);
            using (RegPkgContext cxt = new RegPkgContext(hive, args.registrationMethod)) {
                ProcessAssembly(args.fileName, hive, cxt, false, RegistrationMode.Unregister);
                hive.Close();
            }
        }

        /// <devdoc>
        ///     Validates that the new mode is compatible with the current mode.
        /// </devdoc>
        private static void ValidateMode(RegistrationMode currentMode, RegistrationMode mode) {
            if (currentMode != RegistrationMode.None) {
                string errMessage = string.Empty;
                if (currentMode == mode) {
                    errMessage = string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_DuplicatedMode, RegistrationNameFromMode(mode));
                } else {
                    errMessage = string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_MultipleMode, RegistrationNameFromMode(currentMode), RegistrationNameFromMode(mode));
                }
                throw new ArgumentException(errMessage);
            }
        }

        /// <devdoc>
        ///     Takes a string of data and writes it to a file.
        /// </devdoc>
        private static void WriteFile(string data, string fileName) {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using (TextWriter writer = new StreamWriter(fs))
                {
                    writer.Write(data);
                    writer.Flush();
                }
            }
        }

        /// <devdoc>
        ///     Console wrapper that outputs to the console, but only if
        ///     we were invoked through Main.
        /// </devdoc>
        private static void WriteLine(string line) {
            if (consoleMode) {
                Console.WriteLine(line);
            }
            // Always output the string to the debugger
            Debug.WriteLine(line);

        }

        /// <devdoc>
        ///     Compares registration attributes to sort them.
        /// </devdoc>
        private sealed class RegistrationAttributeComparer : IComparer {
            public static RegistrationAttributeComparer Default = new RegistrationAttributeComparer();

            public int Compare(object a, object b) {
                RegistrationAttribute ra = (RegistrationAttribute)a;
                RegistrationAttribute rb = (RegistrationAttribute)b;

                int result = string.Compare(ra.GetType().FullName, rb.GetType().FullName, StringComparison.Ordinal);
                if (result == 0 && ra.GetType() == rb.GetType()) {
                    foreach(PropertyDescriptor prop in TypeDescriptor.GetProperties(ra.GetType())) {
                        if (typeof(IComparable).IsAssignableFrom(prop.PropertyType)) {
                            IComparable valueA = prop.GetValue(ra) as IComparable;
                            IComparable valueB = prop.GetValue(rb) as IComparable;
                            if (valueA != null && valueB != null) {
                                result = valueA.CompareTo(valueB);
                                if (result != 0) {
                                    break;
                                }
                            }

                        }
                        else if (prop.PropertyType == typeof(Type)) {
                            Type valueA = prop.GetValue(ra) as Type;
                            Type valueB = prop.GetValue(rb) as Type;
                            if (valueA != null && valueB != null) {
                                result = string.Compare(valueA.FullName, valueB.FullName, StringComparison.Ordinal);
                                if (result != 0) {
                                    break;
                                }
                            }
                        }
                        else {
                            object valueA = prop.GetValue(ra);
                            object valueB = prop.GetValue(rb);
                            if (valueA != null && valueB != null) {
                                result = string.Compare(valueA.ToString(), valueB.ToString(), StringComparison.Ordinal);
                                if (result != 0) {
                                    break;
                                }
                            }
                        }
                    }

                }

                return result;
            }
        }

        /// <devdoc>
        ///     Compares types to sort them.
        /// </devdoc>
        private sealed class TypeComparer : IComparer<Type> {
            public static TypeComparer Default = new TypeComparer();
            public int Compare(Type x, Type y) {
                if (null == x) {
                    return (null == y) ? 0 : -1;
                }
                if (null == y) {
                    return 1;
                }
                return string.Compare(x.FullName, y.FullName, StringComparison.Ordinal);
            }

            [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            [SuppressMessage("Microsoft.Performance", "CA1822:MarkMethodsAsStatic")]
            public bool Equals(Type x, Type y) {
                return x == y;
            }

            [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            [SuppressMessage("Microsoft.Performance", "CA1822:MarkMethodsAsStatic")]
            public int GetHashCode(Type obj) {
                return obj.GetHashCode();
            }

        }

        /// <devdoc>
        ///     Hive object that is used to produce .PkgDef file data.
        /// </devdoc>
        private class PkgDefFileHive : Hive
        {
          //The regroot is not needed in this class, because it is always generated as $RootKey$,
          //  therefore we can do some optimizations to work around this.

          private StringBuilder builder;
          private ArrayList children = new ArrayList();

          public PkgDefFileHive()
          {
            builder = new StringBuilder();
          }

          public override string Root
          {
            get
            {
              return "$RootKey$";
            }
          }

          public override string RootFolder
          {
              get
              {
                  return "$RootFolder$";
              }
          }

          protected virtual void AddHeader(StringBuilder b)
          {
            b.Append("Windows Registry Editor Version 5.00\r\n\r\n");
          }

          public override RegistrationAttribute.Key CreateKey(string name)
          {
            RegFileKey key = new RegFileKey(string.Format(CultureInfo.InvariantCulture, "{0}\\{1}", Root, name));
            children.Add(key);
            return key;
          }

          public override void RemoveKey(string name)
          {
            return;
          }

          public override void RemoveKeyIfEmpty(string name)
          {
            return;
          }

          public override void RemoveValue(string name, string valuename)
          {
            return;
          }

          public override string GetComponentPath(Type componentType)
          {
            return EscapePath(base.GetComponentPath(componentType));
          }

          public override string GetCodeBase(Type componentType)
          {
            return EscapePath(base.GetCodeBase(componentType));
          }

          public override string GetInprocServerPath(Type componentType)
          {
            string toReturn = base.GetInprocServerPath(componentType);
            string osPath = System.Environment.GetFolderPath(Environment.SpecialFolder.System);
            osPath = System.IO.Path.GetDirectoryName(osPath);
            toReturn = ReplaceInsensitive(toReturn, osPath, @"%windir%");
            return EscapePath(toReturn);
          }

          public override string ToString()
          {
            AddHeader(builder);
            foreach (RegFileKey key in children)
            {
              builder.Append(key.ToString());
            }
            children.Clear();
            builder.Append("\r\n");
            return builder.ToString();
          }

          static string ReplaceInsensitive(string input, string oldValue, string newValue) {
            int index = input.IndexOf(oldValue, StringComparison.CurrentCultureIgnoreCase);
            if (index != -1) {
              string s1 = input.Substring(0, index);
              string s2 = input.Substring(index + oldValue.Length);
              return s1 + newValue + s2;
            } 
            else {
              return input;
            }
          }
        }

        /// <devdoc>
        ///     Hive object that is used to produce .REG file data.
        /// </devdoc>
        private class RegFileHive : Hive {

            private readonly string root;
            private StringBuilder builder;
            private ArrayList children = new ArrayList();

            public RegFileHive(RegistryRoot regRoot) {
                builder = new StringBuilder();
                string regKey = regRoot.IsRANU ? "HKEY_CURRENT_USER" : "HKEY_LOCAL_MACHINE";
                root = string.Format(CultureInfo.InvariantCulture, @"{0}\{1}", regKey, regRoot.RegistryRootPath);
            }

            public override string Root
            {
                get
                {
                    return root;
                }
            }

            protected virtual void AddHeader(StringBuilder b) {
                b.Append("REGEDIT4\r\n\r\n");
            }

            public override RegistrationAttribute.Key CreateKey(string name) {
                RegFileKey key = new RegFileKey(string.Format(CultureInfo.InvariantCulture, "{0}\\{1}", root, name));
                children.Add(key);
                return key;
            }

            public override void RemoveKey(string name)
            {
                return;
            }

            public override void RemoveKeyIfEmpty(string name)
            {
                return;
            }

            public override void RemoveValue(string name, string valuename)
            {
                return;
            }

            public override string GetComponentPath(Type componentType) {
                return EscapePath(base.GetComponentPath(componentType));
            }

            public override string GetCodeBase(Type componentType) {
                return EscapePath(base.GetCodeBase(componentType));
            }

            public override string GetInprocServerPath(Type componentType) {
                return EscapePath(base.GetInprocServerPath(componentType));
            }

            public override string RootFolder
            {
                get
                {
                    return Registry.GetValue(root + "\\Setup\\VS", "ProductDir", "$RootFolder$").ToString();
                }
            }

            public override string ToString() {
                AddHeader(builder);
                foreach(RegFileKey key in children) {
                    builder.Append(key.ToString());
                }
                children.Clear();
                builder.Append("\r\n");
                return builder.ToString();
            }
        }

        /// <devdoc>
        ///     Key object that is used to produce .REG file data.
        /// </devdoc>
        private sealed class RegFileKey : RegistrationKeyBase {

            public RegFileKey(string path) : base(path) {
            }

            public override void Close() {
            }

            protected override RegistrationKeyBase CreateKey(string keyPath) {
                return new RegFileKey(keyPath);
            }

            public override string CreateRegistrationScript(int marginSize) {
                StringBuilder builder = new StringBuilder();

                // Add the name of the key
                builder.Append("[");
                builder.Append(this.Path);
                builder.AppendLine("]");

                // Add the default value if it is not null
                if (null != this.DefaultValue) {
                    builder.Append("@=");
                    builder.AppendLine(FormatValue(this.DefaultValue));
                }

                // Add the other labels
                foreach (string label in Values.Keys) {
                    if (null == Values[label]) {
                        continue;
                    }
                    builder.Append("\"");
                    builder.Append(Utilities.DoubleBackSlash(label));
                    builder.Append("\"=");
                    builder.AppendLine(FormatValue(Values[label]));
                }

                // Add the sub-keys
                foreach (RegistrationKeyBase key in SubKeys.Values) {
                    builder.Append(key.CreateRegistrationScript(marginSize));
                }

                return builder.ToString();
            }

            private static string FormatValue(object value) {
                if (value.GetType().IsPrimitive) {
                    return string.Format(CultureInfo.InvariantCulture, "dword:{0:X8}", value);
                }
                return string.Format(CultureInfo.InvariantCulture, "\"{0}\"", Utilities.DoubleBackSlash(value.ToString()));
            }

            public override string ToString() {
                return CreateRegistrationScript(0);
            }

        }

        /// <devdoc>
        ///     Hive object that is used to directly write to the registry
        /// </devdoc>
        private sealed class RegHive : Hive {

            private RegistryKey root;
            private RegistryRoot regRoot;

            public RegHive(RegistryRoot regRoot) {
                this.regRoot = regRoot;
                if (regRoot.IsRANU) {
                    root = Registry.CurrentUser.CreateSubKey(regRoot.RegistryRootPath);
                } else {
                    root = Registry.LocalMachine.CreateSubKey(regRoot.RegistryRootPath);
                }
            }

            public override string Root
            {
                get
                {
                    return regRoot.RegistryRootPath;
                }
            }

            public override string RootFolder
            {
                get
                {
                    string value;
                    using (RegistryKey key = root.OpenSubKey("Setup\\VS"))
                    {
                        value = key.GetValue("ProductDir", "$RootFolder$").ToString();
                    }
                    return value;
                }
            }

            public void Close() {
                root.Close();
            }

            public override RegistrationAttribute.Key CreateKey(string name) {
                return new RegKey(root.CreateSubKey(name));
            }

            public override void RemoveKey(string name)
            {
                using (RegistryKey sub = root.OpenSubKey(name))
                {
                    if (sub != null)
                    {
                        root.DeleteSubKeyTree(name);
                    }
                }
            }

            public override void RemoveKeyIfEmpty(string name)
            {
                using (RegistryKey sub = root.OpenSubKey(name))
                {
                    if (sub == null)
                        return; // already deleted, nothing to do

                    if (sub.GetSubKeyNames().Length == 0
                        && sub.GetValueNames().Length == 0)
                    {
                        root.DeleteSubKey(name);
                    }
                }
            }

            public override void RemoveValue(string name, string valuename)
            {
                using (RegistryKey key = root.OpenSubKey(name, true))
                {
                    if (null != key)
                    {
                        key.DeleteValue(valuename, false);
                    }
                }
            }
        }

        /// <devdoc>
        ///     Key object that is used to write to the registry.
        /// </devdoc>
        private sealed class RegKey : RegistrationAttribute.Key {

            private RegistryKey key;

            internal RegKey(RegistryKey key) {
                if (key == null)
                    throw new ArgumentNullException("key");
                this.key = key;
            }

            public override void Close() {
                key.Close();
            }

            public override RegistrationAttribute.Key CreateSubkey(string name) {
                return new RegKey(key.CreateSubKey(name));
            }

            public override void SetValue(string valueName, object value) {

                // short is interpreted as a stringf by RegistryKey.
                //
                if (value is short) {
                    value = (int)(short)value;
                }
                key.SetValue(valueName, value);
            }
        }

        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Pkg")]
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public sealed class RegPkgContext : RegistrationAttribute.RegistrationContext, IDisposable {

            private Hive hive;
            private Type componentType;
            private RegistrationMethod registrationMethod;

            private TextWriter log;

            public RegPkgContext(Hive hive, RegistrationMethod registerUsing) {
                this.hive = hive;
                this.registrationMethod = registerUsing;
            }

            public void Dispose() {
                if (null != log) {
                    log.Dispose();
                    log = null;
                }
            }

            public override string ComponentPath {
                get {
                    return hive.GetComponentPath(ComponentType);
                }
            }

            public override Type ComponentType {
                get {
                    return componentType;
                }
            }

            public override string InprocServerPath {
                get {
                    return hive.GetInprocServerPath(ComponentType);
                }
            }

            public override string CodeBase {
                get {
                    return hive.GetCodeBase(ComponentType);
                }
            }

            /// <summary>
            /// The path to the directory where the target host executable is.
            /// </summary>
            public override string RootFolder{
                get {
                    return hive.RootFolder;
                }
            }

            public override RegistrationMethod RegistrationMethod {
                get {
                    return registrationMethod;
                }
            }

            public override TextWriter Log {
                get {
                    if (log == null) {
                        if (consoleMode) {
                            log = Console.Out;
                        }
                        else {
                            log = new StringWriter(CultureInfo.CurrentUICulture);
                        }
                    }

                    return log;
                }
            }

            public override RegistrationAttribute.Key CreateKey(string name) {
                return hive.CreateKey(name);
            }

            public override void RemoveKey(string name) {
                hive.RemoveKey(name);
            }

            public override void RemoveKeyIfEmpty(string name) {
                hive.RemoveKeyIfEmpty(name);
            }

            public override void RemoveValue(string keyname, string valuename) {
                hive.RemoveValue(keyname, valuename);
            }


            /// <devdoc>
            /// Escape the string if needed.
            /// Its implementation is empty because we want to move to the specific escaping
            /// to the registration key because this this the object with more context about
            /// the format of strings.
            /// </devdoc>
            public override string EscapePath(string str) {
                return str;
            }

            internal void SetType(Type t) {
                componentType = t;
            }
        }

        /// <devdoc>
        ///     Hive object that is used to produce .RGS file data.
        /// </devdoc>
        private class RgsFileHive : Hive {

            private RegistryRoot                  root;
            private Hashtable                     rgmHash;
            private ArrayList                     rgmKeys;
            private RgsFileKey                    rootKey;
            private RegistrationAttribute.Key     createKey;

            public RgsFileHive(RegistryRoot regRoot, bool createRgm) {
                root = regRoot;

                if (createRgm) {
                    rgmHash = new Hashtable();
                    rgmKeys = new ArrayList();
                }

                if (createRgm) {
                    rootKey = new RgsFileKey(root.IsRANU);
                    createKey = rootKey.CreateRegRootKey(regRoot.RegistryRootPath, this);
                }
                else {
                    rootKey = new RgsFileKey(root.IsRANU);
                    createKey = rootKey.CreateSubkey(regRoot.RegistryRootPath);
                }
            }

            public override string Root
            {
                get
                {
                    return root.RegistryRootPath;
                }
            }

            public override string RootFolder
            {
                get
                {
                    return "[RootFolder]";
                }
            }

            public override RegistrationAttribute.Key CreateKey(string name) {
                return createKey.CreateSubkey(name);
            }

            public override void RemoveKey(string name) {
                return;
            }

            public override void RemoveKeyIfEmpty(string name)
            {
                return;
            }

            public override void RemoveValue(string keyName, string valueName)
            {
                return ;
            }

            public override string GetComponentPath(Type componentType) {

                string componentPath = null;

                if (componentType != null) {
                    componentPath = string.Format(CultureInfo.InvariantCulture, "[{0}]", RegPkg.GetTokenValue(componentType, "$ComponentPath"));
                    
                    // If we have been asked to generate an RGM, create a key for this component path
                    string componentID = string.Format(CultureInfo.InvariantCulture, "{0}_Path", componentType.Name.Replace('.', '_'));
                    componentPath = CreateSubstitutionString(componentID, componentPath, false);
                }

                return componentPath;
            }

            public override string GetCodeBase(Type componentType) {
                if (null == componentType) {
                    return string.Empty;
                }
                string fileName = System.IO.Path.GetFileName(componentType.Assembly.Location);
                return string.Format(CultureInfo.InvariantCulture, "{0}{1}", GetComponentPath(componentType), fileName);
            }

            public override string GetInprocServerPath(Type componentType) {

                string inprocServerPath = null;

                if (componentType != null) {
                    inprocServerPath = string.Format(CultureInfo.InvariantCulture, "[{0}]mscoree.dll", RegPkg.GetTokenValue(componentType, "SystemFolder"));
                    inprocServerPath = CreateSubstitutionString("MSCOREE_PATH", inprocServerPath, false);
                }

                return inprocServerPath;
            }

            internal string CreateSubstitutionString(string substitution, string value, bool quote) {
                if (rgmHash != null) {
                    string existing = (string)rgmHash[substitution];
                    if (existing != null && !existing.Equals(value)) {
                        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.RegPkg_DuplicateSubstitution, substitution, existing, value));
                    }
                    if (quote) {
                        value = string.Format(CultureInfo.InvariantCulture, "\"{0}\"", value);
                    }

                    rgmHash[substitution] = value;
                    if (existing == null) {
                        rgmKeys.Add(substitution);
                    }

                    return string.Format(CultureInfo.InvariantCulture, "%{0}%", substitution);
                }
                return value;
            }

            public override string ToString() {
                return string.Empty;
            }

            public string[] GetStrings() {

                string[] retVal;

                // First, all of the children.  We can get to them simply by
                // closing the roots and returning ToString on them.
                //
                rootKey.Close();

                string registryData = rootKey.ToString();

                if (rgmKeys != null) {
                    retVal = new string[2];
                    retVal[0] = registryData;

                    StringBuilder builder = new StringBuilder();
                    foreach(object key in rgmKeys) {
                        builder.Append(string.Format(CultureInfo.InvariantCulture, "{0}={1}\r\n", key, rgmHash[key]));
                    }
                    retVal[1] = builder.ToString();
                }
                else {
                    retVal = new string[] {registryData};
                }

                return retVal;
            }
        }

        /// <devdoc>
        ///     Key object that is used to produce .REG file data.
        /// </devdoc>
        private sealed class RgsFileKey : RegistrationAttribute.Key {

            private string name;
            private string keyValue = null;
            private string beginRoot;
            private string endRoot;
            private ArrayList children = new ArrayList();
            private Hashtable nameChildren = new Hashtable();
            private ArrayList values = new ArrayList();

            internal RgsFileKey(bool userKey) {
                this.name = userKey ? "HKCU" : "HKLM";
            }

            private RgsFileKey(string name) {
                this.name = string.Format(CultureInfo.InvariantCulture, "'{0}'", name);
            }

            private RgsFileKey(string root, RgsFileHive hive) {
                hive.CreateSubstitutionString("[REGROOT]", root, true);
                beginRoot = hive.CreateSubstitutionString("REGROOTBEGIN", "*[REGROOT]", false);
                endRoot = hive.CreateSubstitutionString("REGROOTEND", "[REGROOT]*", false);
            }

            public override void Close() {
            }

            public RegistrationAttribute.Key CreateRegRootKey(string root, RgsFileHive hive) {
                RgsFileKey key = new RgsFileKey(root, hive);
                children.Add(key);
                return key;
            }

            public override RegistrationAttribute.Key CreateSubkey(string keyName) {
                if (string.IsNullOrEmpty(keyName)) {
                    throw new ArgumentNullException("keyName");
                }
                // Parse subkeys
                //
                string[] subnames = keyName.Split(new char[] { '\\' });

                RgsFileKey returnSubKey = null;

                foreach(string subname in subnames) {
                    if (returnSubKey == null) {
                        returnSubKey = (RgsFileKey)nameChildren[subname];
                        if (returnSubKey == null) {
                            returnSubKey = new RgsFileKey(subname);
                            children.Add(returnSubKey);
                            nameChildren[subname] = returnSubKey;
                        }
                    }
                    else {
                        returnSubKey = (RgsFileKey)returnSubKey.CreateSubkey(subname);
                    }
                }

                return returnSubKey;
            }

            private static string FormatValue(object value) {
                // Only support string and dword values
                if (value.GetType().IsPrimitive) {
                    return string.Format(CultureInfo.InvariantCulture, "d '{0}'", value);
                }
                else {
                    return string.Format(CultureInfo.InvariantCulture, "s '{0}'", Utilities.DoubleBackSlash(value.ToString()));
                }
            }

            public override void SetValue(string valueName, object value) {

                if (value == null) {
                    throw new ArgumentNullException("value");
                }

                if (string.IsNullOrEmpty(valueName)) {
                    keyValue = FormatValue(value);
                }
                else {
                    values.Add(string.Format(CultureInfo.InvariantCulture, "val '{0}' = {1}", valueName, FormatValue(value)));
                }
            }

            public override string ToString() {
                StringBuilder builder = new StringBuilder();
                ToString(builder, string.Empty);
                return builder.ToString();
            }

            private void ToString(StringBuilder builder, string margin) {

                string CRLF = "\r\n";

                builder.Append(margin);

                if (name != null) {
                    string keyLine = name;
                    if (keyValue != null) {
                        keyLine = string.Format(CultureInfo.InvariantCulture, "{0} = {1}", name, keyValue);
                    }

                    // The key name and opening brace
                    builder.Append(keyLine);
                    builder.Append(CRLF);
                    builder.Append(margin);
                    builder.Append("{");
                }
                else {
                    Debug.Assert(beginRoot != null, "Either name or root must be non-null");
                    builder.Append(beginRoot);
                }

                builder.Append(CRLF);

                // our own values
                string newMargin = margin + "    ";
                foreach(string value in values) {
                    builder.Append(newMargin);
                    builder.Append(value);
                    builder.Append(CRLF);
                }

                // Our children
                foreach(RgsFileKey child in children) {
                    child.ToString(builder, newMargin);
                }

                // And the closing brace / end root
                builder.Append(margin);

                if (name != null) {
                    builder.Append("}");
                }
                else {
                    Debug.Assert(endRoot != null, "Either name or root must be non-null");
                    builder.Append(endRoot);
                }

                builder.Append(CRLF);
            }
        }

        /// <devdoc>
        ///     Hive object that is used to produce .VRG file data.
        /// </devdoc>
        private sealed class VrgFileHive : RegFileHive {

            public VrgFileHive(RegistryRoot regRoot) : base(regRoot) {
            }

            protected override void AddHeader(StringBuilder b) {
                b.Append("VSREG7\r\n\r\n");
            }

            public override string GetComponentPath(Type componentType) {
                return string.Format(CultureInfo.InvariantCulture, "[{0}]", RegPkg.GetTokenValue(componentType, "$ComponentPath"));
            }

            public override string GetCodeBase(Type componentType) {
                if (null == componentType) {
                    return string.Empty;
                }
                string fileName = System.IO.Path.GetFileName(componentType.Assembly.Location);
                return string.Format(CultureInfo.InvariantCulture, "{0}{1}", GetComponentPath(componentType), fileName);
            }

            public override string GetInprocServerPath(Type componentType) {
                return string.Format(CultureInfo.InvariantCulture, "[{0}]mscoree.dll", RegPkg.GetTokenValue(componentType, "SystemFolder"));
            }
        }
    }
}

