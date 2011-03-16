//-----------------------------------------------------------------------
// <copyright file="CsLanguageService.cs">
//     MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Xml;

    /// <summary>
    /// Parses a C# code file.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Camel case better serves in this case.")]
    public partial class CsLanguageService
    {
        #region Private Static Fields

        /// <summary>
        /// Static debug class.
        /// </summary>
        private static CsDebug debug = new CsDebug();

        #endregion Private Static Fields

        #region Private Fields

        /// <summary>
        /// Active preprocessor definitions.
        /// </summary>
        private Dictionary<string, object> preprocessorDefinitions = new Dictionary<string, object>();

        /// <summary>
        /// The optional partial element service.
        /// </summary>
        private IPartialElementsService partialElementService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the CsLanguageService class.
        /// </summary>
        public CsLanguageService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CsLanguageService class.
        /// </summary>
        /// <param name="preprocessorDefinitions">Optional preprocessor definitions to be applied when parsing source code.</param>
        public CsLanguageService(IEnumerable<PreprocessorDefinition> preprocessorDefinitions)
        {
            Param.Ignore(preprocessorDefinitions);

            // Store the preprocessor definitions.
            if (preprocessorDefinitions != null)
            {
                foreach (PreprocessorDefinition definition in preprocessorDefinitions)
                {
                    this.AddOrUpdatePreprocessorDefinition(definition);
                }
            }

            this.RegisterServices(null);
        }

        /// <summary>
        /// Initializes a new instance of the CsLanguageService class.
        /// </summary>
        /// <param name="service">Optional service which which influences the code model output.</param>
        public CsLanguageService(ICSharpCodeModelService service)
        {
            Param.Ignore(service);
            this.RegisterServices(new ICSharpCodeModelService[] { service });
        }

        /// <summary>
        /// Initializes a new instance of the CsLanguageService class.
        /// </summary>
        /// <param name="services">Optional services which which influence the code model output.</param>
        public CsLanguageService(IEnumerable<ICSharpCodeModelService> services)
        {
            Param.Ignore(services);
            this.RegisterServices(services);
        }

        /// <summary>
        /// Initializes a new instance of the CsLanguageService class.
        /// </summary>
        /// <param name="preprocessorDefinitions">Optional preprocessor definitions to be applied when parsing source code.</param>
        /// <param name="service">Optional service which which influences the code model output.</param>
        public CsLanguageService(IEnumerable<PreprocessorDefinition> preprocessorDefinitions, ICSharpCodeModelService service)
            : this(preprocessorDefinitions)
        {
            Param.Ignore(preprocessorDefinitions);
            Param.Ignore(service);

            this.RegisterServices(new ICSharpCodeModelService[] { service });
        }

        /// <summary>
        /// Initializes a new instance of the CsLanguageService class.
        /// </summary>
        /// <param name="preprocessorDefinitions">Optional preprocessor definitions to be applied when parsing source code.</param>
        /// <param name="services">Optional services which which influence the code model output.</param>
        public CsLanguageService(IEnumerable<PreprocessorDefinition> preprocessorDefinitions, IEnumerable<ICSharpCodeModelService> services)
            : this(preprocessorDefinitions)
        {
            Param.Ignore(preprocessorDefinitions);
            Param.Ignore(services);

            this.RegisterServices(services);
        }

        #endregion Public Constructors

        #region Public Static Properties

        /// <summary>
        /// Gets the debug functionality for the language service.
        /// </summary>
        public static CsDebug Debug
        {
            get
            {
                return debug;
            }
        }

        #endregion Public Static Properties

        #region Public Properties

        /// <summary>
        /// Gets the partial element service, if one has been provided.
        /// </summary>
        public IPartialElementsService PartialElementService
        {
            get
            {
                return this.partialElementService;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Creates a document for the given source code.
        /// </summary>
        /// <param name="sourceCode">The source code to parse.</param>
        /// <param name="name">The name of the source code.</param>
        /// <param name="path">The path to the source code.</param>
        /// <returns>Returns the document.</returns>
        /// <exception cref="SyntaxException">Throw a syntax exception if the code cannot be parsed according to the C# specification.</exception>
        public CsDocument CreateCodeModel(string sourceCode, string name, string path)
        {
            Param.RequireNotNull(sourceCode, "sourceCode");
            Param.RequireValidString(name, "name");
            Param.RequireValidString(path, "path");

            using (StringReader reader = new StringReader(sourceCode))
            {
                return this.CreateCodeModelInternal(new Code(reader, name, path));
            }
        }

        /// <summary>
        /// Creates a document for the given source code.
        /// </summary>
        /// <param name="sourceCode">The source code to parse.</param>
        /// <param name="name">The name of the source code.</param>
        /// <param name="path">The path to the source code.</param>
        /// <returns>Returns the document.</returns>
        /// <exception cref="SyntaxException">Throw a syntax exception if the code cannot be parsed according to the C# specification.</exception>
        public CsDocument CreateCodeModel(TextReader sourceCode, string name, string path)
        {
            Param.RequireNotNull(sourceCode, "sourceCode");
            Param.RequireValidString(name, "name");
            Param.RequireValidString(path, "path");

            return this.CreateCodeModelInternal(new Code(sourceCode, name, path));
        }

        /// <summary>
        /// Adds one preprocessor definition or updates an existing preprocessor definition.
        /// </summary>
        /// <param name="preprocessorDefinition">The definition to add or update.</param>
        public void AddOrUpdatePreprocessorDefinition(PreprocessorDefinition preprocessorDefinition)
        {
            Param.RequireNotNull(preprocessorDefinition, "preprocessorDefinition");

            if (!this.preprocessorDefinitions.ContainsKey(preprocessorDefinition.Name))
            {
                this.preprocessorDefinitions.Add(preprocessorDefinition.Name, preprocessorDefinition.Value);
            }
            else
            {
                this.preprocessorDefinitions[preprocessorDefinition.Name] = preprocessorDefinition.Value;
            }
        }

        /// <summary>
        /// Removes the preprocessor definition with the given name.
        /// </summary>
        /// <param name="name">The name of the definition to remove.</param>
        public void RemovePreprocessorDefinition(string name)
        {
            Param.RequireValidString(name, "name");
            this.preprocessorDefinitions.Remove(name);
        }

        #endregion Public Methods

        #region Internal Static Methods

        /// <summary>
        /// Gets the type of the given preprocessor symbol.
        /// </summary>
        /// <param name="preprocessor">The preprocessor symbol.</param>
        /// <param name="bodyIndex">Returns the start index of the body of the preprocessor.</param>
        /// <returns>Returns the type or null if the type cannot be determined.</returns>
        internal static string GetPreprocessorDirectiveType(Symbol preprocessor, out int bodyIndex)
        {
            Param.AssertNotNull(preprocessor, "preprocessor");
            CsLanguageService.Debug.Assert(preprocessor.SymbolType == SymbolType.PreprocessorDirective, "Expected a preprocessor directive");

            // Get the preprocessor type. This is the second word in the statement.
            bodyIndex = -1;
            int startIndex = -1;
            int endIndex = -1;

            // Move to the start of the second word.
            for (int i = 1; i < preprocessor.Text.Length; ++i)
            {
                if (char.IsLetter(preprocessor.Text[i]))
                {
                    startIndex = i;
                    break;
                }
            }

            if (startIndex == -1)
            {
                return null;
            }

            // Move to the end of the word.
            for (endIndex = startIndex; endIndex < preprocessor.Text.Length; ++endIndex)
            {
                if (!char.IsLetter(preprocessor.Text[endIndex]))
                {
                    break;
                }
            }

            --endIndex;
            if (endIndex < startIndex)
            {
                return null;
            }

            // The body start index is just past the endIndex.
            bodyIndex = endIndex + 1;

            // Get the word.
            return preprocessor.Text.Substring(startIndex, endIndex - startIndex + 1);
        }

        #endregion Internal Static Methods

        #region Internal Methods

        /// <summary>
        /// Creates a document for the given source code.
        /// </summary>
        /// <param name="sourceCode">The source code to parse.</param>
        /// <returns>Returns the document.</returns>
        /// <exception cref="SyntaxException">Throw a syntax exception if the code cannot be parsed according to the C# specification.</exception>
        internal CsDocument CreateCodeModelInternal(Code sourceCode)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");

            // Create the lexer object for the code string.
            var lexer = new CodeLexer(this, sourceCode, new CodeReader(sourceCode));

            // Parse the document.
            var parser = new CodeParser(this, lexer, this.preprocessorDefinitions);
            parser.ParseCodeModel();

            return parser.Document;
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Registers optional services.
        /// </summary>
        /// <param name="services">The optional services.</param>
        private void RegisterServices(IEnumerable<ICSharpCodeModelService> services)
        {
            Param.Ignore(services);

            if (services != null)
            {
                foreach (ICSharpCodeModelService service in services)
                {
                    IPartialElementsService p = service as IPartialElementsService;
                    if (p != null)
                    {
                        this.partialElementService = p;
                    }
                }
            }
        }

        #endregion Private Methods
    }
}
