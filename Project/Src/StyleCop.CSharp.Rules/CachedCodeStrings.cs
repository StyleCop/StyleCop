// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CachedCodeStrings.cs" company="https://github.com/StyleCop">
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
// <summary>
//   Loaded and cached code strings used within the DocumentationRules analyzer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Globalization;

    /// <summary>
    /// Loaded and cached code strings used within the DocumentationRules analyzer.
    /// </summary>
    public static class CachedCodeStrings
    {
        #region Static Fields

        /// <summary>
        /// The text for "class".
        /// </summary>
        private static string classText;

        private static CultureInfo culture;

        /// <summary>
        /// Example header text string "Finalizes an instance of the {0} class".
        /// </summary>
        private static string exampleHeaderSummaryForDestructor;

        /// <summary>
        /// Example header text string "Initializes a new instance of the {0} class".
        /// </summary>
        private static string exampleHeaderSummaryForInstanceConstructor;

        /// <summary>
        /// Example header text string "Prevents an instance of the class from being created".
        /// </summary>
        private static string exampleHeaderSummaryForPrivateInstanceConstructor;

        /// <summary>
        /// Example header text string "Initializes static data within the {0} class".
        /// </summary>
        private static string exampleHeaderSummaryForStaticConstructor;

        /// <summary>
        /// Header text string "Gets a value indicating whether".
        /// </summary>
        private static string headerSummaryForBooleanGetAccessor;

        /// <summary>
        /// Header text string "Gets or sets a value indicating whether".
        /// </summary>
        private static string headerSummaryForBooleanGetAndSetAccessor;

        /// <summary>
        /// Header text string "Sets a value indicating whether".
        /// </summary>
        private static string headerSummaryForBooleanSetAccessor;

        /// <summary>
        /// Header text string "Finalizes an instance of the {0} class".
        /// </summary>
        private static string headerSummaryForDestructor;

        /// <summary>
        /// Header text string "Gets".
        /// </summary>
        private static string headerSummaryForGetAccessor;

        /// <summary>
        /// Header text string "Gets or sets".
        /// </summary>
        private static string headerSummaryForGetAndSetAccessor;

        /// <summary>
        /// Header text string "Initializes a new instance of the {0} class".
        /// </summary>
        private static string headerSummaryForInstanceConstructor;

        /// <summary>
        /// Header text string "Prevents an instance of the class from being created".
        /// </summary>
        private static string headerSummaryForPrivateInstanceConstructor;

        /// <summary>
        /// Header text string "Sets".
        /// </summary>
        private static string headerSummaryForSetAccessor;

        /// <summary>
        /// Header text string "Initializes static data within the {0} class".
        /// </summary>
        private static string headerSummaryForStaticConstructor;

        /// <summary>
        /// Header text string "The parameter is not used".
        /// </summary>
        private static string parameterNotUsed;

        /// <summary>
        /// The text for "struct".
        /// </summary>
        private static string structText;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the text for "class".
        /// </summary>
        public static string ClassText
        {
            get
            {
                if (classText == null)
                {
                    classText = CodeStrings.Class;
                }

                return classText;
            }
        }

        /// <summary>
        /// Gets or sets the CultureInfo we will analyze with.
        /// </summary>
        public static CultureInfo Culture
        {
            get
            {
                return culture;
            }

            set
            {
                if (value == null)
                {
                    value = new CultureInfo("en-US");
                }

                if (culture == null || culture.EnglishName != value.EnglishName)
                {
                    ClearCachedStrings();
                    culture = value;
                    CodeStrings.Culture = value;
                }
            }
        }

        /// <summary>
        /// Gets example header text string "Finalizes an instance of the {0} class".
        /// </summary>
        public static string ExampleHeaderSummaryForDestructor
        {
            get
            {
                if (exampleHeaderSummaryForDestructor == null)
                {
                    exampleHeaderSummaryForDestructor = CodeStrings.ExampleHeaderSummaryForDestructor;
                }

                return exampleHeaderSummaryForDestructor;
            }
        }

        /// <summary>
        /// Gets example header text string "Initializes a new instance of the {0} {1}".
        /// </summary>
        public static string ExampleHeaderSummaryForInstanceConstructor
        {
            get
            {
                if (exampleHeaderSummaryForInstanceConstructor == null)
                {
                    exampleHeaderSummaryForInstanceConstructor = CodeStrings.ExampleHeaderSummaryForInstanceConstructor;
                }

                return exampleHeaderSummaryForInstanceConstructor;
            }
        }

        /// <summary>
        /// Gets example header text string "Prevents a default instance of the {0} {1} from being created".
        /// </summary>
        public static string ExampleHeaderSummaryForPrivateInstanceConstructor
        {
            get
            {
                if (exampleHeaderSummaryForPrivateInstanceConstructor == null)
                {
                    exampleHeaderSummaryForPrivateInstanceConstructor = CodeStrings.ExampleHeaderSummaryForPrivateInstanceConstructor;
                }

                return exampleHeaderSummaryForPrivateInstanceConstructor;
            }
        }

        /// <summary>
        /// Gets example header text string "Initializes static data within the {0} class".
        /// </summary>
        public static string ExampleHeaderSummaryForStaticConstructor
        {
            get
            {
                if (exampleHeaderSummaryForStaticConstructor == null)
                {
                    exampleHeaderSummaryForStaticConstructor = CodeStrings.ExampleHeaderSummaryForStaticConstructor;
                }

                return exampleHeaderSummaryForStaticConstructor;
            }
        }

        /// <summary>
        /// Gets header text string "Gets a value indicating whether".
        /// </summary>
        public static string HeaderSummaryForBooleanGetAccessor
        {
            get
            {
                if (headerSummaryForBooleanGetAccessor == null)
                {
                    headerSummaryForBooleanGetAccessor = CodeStrings.HeaderSummaryForBooleanGetAccessor;
                }

                return headerSummaryForBooleanGetAccessor;
            }
        }

        /// <summary>
        /// Gets header text string "Gets or sets a value indicating whether".
        /// </summary>
        public static string HeaderSummaryForBooleanGetAndSetAccessor
        {
            get
            {
                if (headerSummaryForBooleanGetAndSetAccessor == null)
                {
                    headerSummaryForBooleanGetAndSetAccessor = CodeStrings.HeaderSummaryForBooleanGetAndSetAccessor;
                }

                return headerSummaryForBooleanGetAndSetAccessor;
            }
        }

        /// <summary>
        /// Gets header text string "Sets a value indicating whether".
        /// </summary>
        public static string HeaderSummaryForBooleanSetAccessor
        {
            get
            {
                if (headerSummaryForBooleanSetAccessor == null)
                {
                    headerSummaryForBooleanSetAccessor = CodeStrings.HeaderSummaryForBooleanSetAccessor;
                }

                return headerSummaryForBooleanSetAccessor;
            }
        }

        /// <summary>
        /// Gets header text string "Finalizes an instance of the {0} class".
        /// </summary>
        public static string HeaderSummaryForDestructor
        {
            get
            {
                if (headerSummaryForDestructor == null)
                {
                    headerSummaryForDestructor = CodeStrings.HeaderSummaryForDestructor;
                }

                return headerSummaryForDestructor;
            }
        }

        /// <summary>
        /// Gets header text string "Gets".
        /// </summary>
        public static string HeaderSummaryForGetAccessor
        {
            get
            {
                if (headerSummaryForGetAccessor == null)
                {
                    headerSummaryForGetAccessor = CodeStrings.HeaderSummaryForGetAccessor;
                }

                return headerSummaryForGetAccessor;
            }
        }

        /// <summary>
        /// Gets header text string "Gets or sets".
        /// </summary>
        public static string HeaderSummaryForGetAndSetAccessor
        {
            get
            {
                if (headerSummaryForGetAndSetAccessor == null)
                {
                    headerSummaryForGetAndSetAccessor = CodeStrings.HeaderSummaryForGetAndSetAccessor;
                }

                return headerSummaryForGetAndSetAccessor;
            }
        }

        /// <summary>
        /// Gets header text string "Initializes a new instance of the {0} {1}".
        /// </summary>
        public static string HeaderSummaryForInstanceConstructor
        {
            get
            {
                if (headerSummaryForInstanceConstructor == null)
                {
                    headerSummaryForInstanceConstructor = CodeStrings.HeaderSummaryForInstanceConstructor;
                }

                return headerSummaryForInstanceConstructor;
            }
        }

        /// <summary>
        /// Gets header text string "Prevents an instance of the class from being created".
        /// </summary>
        public static string HeaderSummaryForPrivateInstanceConstructor
        {
            get
            {
                if (headerSummaryForPrivateInstanceConstructor == null)
                {
                    headerSummaryForPrivateInstanceConstructor = CodeStrings.HeaderSummaryForPrivateInstanceConstructor;
                }

                return headerSummaryForPrivateInstanceConstructor;
            }
        }

        /// <summary>
        /// Gets header text string "Sets".
        /// </summary>
        public static string HeaderSummaryForSetAccessor
        {
            get
            {
                if (headerSummaryForSetAccessor == null)
                {
                    headerSummaryForSetAccessor = CodeStrings.HeaderSummaryForSetAccessor;
                }

                return headerSummaryForSetAccessor;
            }
        }

        /// <summary>
        /// Gets header text string "Initializes static data within the {0} class".
        /// </summary>
        public static string HeaderSummaryForStaticConstructor
        {
            get
            {
                if (headerSummaryForStaticConstructor == null)
                {
                    headerSummaryForStaticConstructor = CodeStrings.HeaderSummaryForStaticConstructor;
                }

                return headerSummaryForStaticConstructor;
            }
        }

        /// <summary>
        /// Gets header text string "The parameter is not used".
        /// </summary>
        public static string ParameterNotUsed
        {
            get
            {
                if (parameterNotUsed == null)
                {
                    parameterNotUsed = CodeStrings.ParameterNotUsed;
                }

                return parameterNotUsed;
            }
        }

        /// <summary>
        /// Gets the text for "struct".
        /// </summary>
        public static string StructText
        {
            get
            {
                if (structText == null)
                {
                    structText = CodeStrings.Struct;
                }

                return structText;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reset the cached strings.
        /// </summary>
        private static void ClearCachedStrings()
        {
            headerSummaryForBooleanGetAccessor = null;
            headerSummaryForBooleanGetAndSetAccessor = null;
            headerSummaryForBooleanSetAccessor = null;
            headerSummaryForGetAccessor = null;
            headerSummaryForGetAndSetAccessor = null;
            headerSummaryForSetAccessor = null;
            headerSummaryForStaticConstructor = null;
            exampleHeaderSummaryForStaticConstructor = null;
            headerSummaryForPrivateInstanceConstructor = null;
            exampleHeaderSummaryForPrivateInstanceConstructor = null;
            headerSummaryForInstanceConstructor = null;
            exampleHeaderSummaryForInstanceConstructor = null;
            headerSummaryForDestructor = null;
            exampleHeaderSummaryForDestructor = null;
            parameterNotUsed = null;
            classText = null;
            structText = null;
        }

        #endregion
    }
}