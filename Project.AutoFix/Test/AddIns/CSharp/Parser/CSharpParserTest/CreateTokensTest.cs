namespace StyleCop.CSharpParserTest
{
    using System;
    using System.Collections.Generic;
    using StyleCop.CSharp.CodeModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests the CsDocument's Create methods for Token types.
    /// </summary>
    [TestClass]
    public class CreateTokensTest
    {
        #region Private Fields

        private TestContext testContextInstance;
        private CsDocument document;
        private const string code = "namespace Test { }";

        #endregion Private Fields

        #region Test Members

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }

            set
            {
                testContextInstance = value;
            }
        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext context)
        {
            CsLanguageService.Debug.ThrowOnAssert = true;
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            CsLanguageService l = new CsLanguageService();
            this.document = l.CreateCodeModel(code, "Test", "Test");
        }
        
        [TestCleanup]
        public void MyTestCleanup()
        {
            this.document = null;
        }

        #endregion Test Members

        #region CodeUnits
        
        #region Argument

        [TestMethod]
        public void CsCreateArgumentTest()
        {
            this.TestArgument(this.document.CreateLiteralExpression("x"));
            this.TestArgument(this.document.CreateLiteralExpression("x"), ParameterModifiers.None);
            this.TestArgument(this.document.CreateLiteralExpression("x"), ParameterModifiers.Ref);
            this.TestArgument(this.document.CreateLiteralExpression("x"), ParameterModifiers.In);
            this.TestArgument(this.document.CreateLiteralExpression("x"), ParameterModifiers.Out);
            this.TestArgument(this.document.CreateLiteralExpression("x"), ParameterModifiers.In | ParameterModifiers.Out);
            this.TestArgument(this.document.CreateLiteralExpression("x"), ParameterModifiers.None | ParameterModifiers.Ref);
            this.TestArgument(this.document.CreateMemberAccessExpression(document.CreateLiteralExpression("x"), "y"), ParameterModifiers.None);
            this.TestArgument(this.document.CreateMethodInvocationExpression(document.CreateLiteralExpression("someMethod"), document.CreateArgumentList(null)), ParameterModifiers.None);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateArgumentWithNull1()
        {
            this.document.CreateArgument(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateArgumentWithNull2()
        {
            this.document.CreateArgument(null, ParameterModifiers.Ref);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateArgumentWithInvalidModifiers1()
        {
            this.document.CreateArgument(document.CreateLiteralExpression("x"), ParameterModifiers.Params);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateArgumentWithInvalidModifiers2()
        {
            this.document.CreateArgument(document.CreateLiteralExpression("x"), ParameterModifiers.This);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateArgumentWithInvalidModifiers3()
        {
            this.document.CreateArgument(document.CreateLiteralExpression("x"), ParameterModifiers.Ref | ParameterModifiers.In);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateArgumentWithInvalidModifiers4()
        {
            this.document.CreateArgument(document.CreateLiteralExpression("x"), ParameterModifiers.Ref | ParameterModifiers.Out);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateArgumentWithInvalidModifiers5()
        {
            this.document.CreateArgument(document.CreateLiteralExpression("x"), ParameterModifiers.Out | ParameterModifiers.Params);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateArgumentWithInvalidModifiers6()
        {
            this.document.CreateArgument(document.CreateLiteralExpression("x"), ParameterModifiers.Ref | ParameterModifiers.This);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateArgumentWithInvalidModifiers7()
        {
            this.document.CreateArgument(document.CreateLiteralExpression("x"), ParameterModifiers.Params | ParameterModifiers.This);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateArgumentWithInvalidModifiers8()
        {
            this.document.CreateArgument(document.CreateLiteralExpression("x"), (ParameterModifiers)0xFFFF);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateArgumentWithInvalidDocument()
        {
            this.document.CreateArgument(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion Argument

        #region ArgumentList

        [TestMethod]
        public void CsCreateArgumentListTest()
        {
            this.TestArgumentList();
            this.TestArgumentList(new Argument[] { });
            this.TestArgumentList(new Argument[] { this.document.CreateArgument(this.document.CreateLiteralExpression("x")) });
            this.TestArgumentList(new Argument[] { this.document.CreateArgument(this.document.CreateLiteralExpression("x")), this.document.CreateArgument(this.document.CreateLiteralExpression("y")) });
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateArgumentListWithNull1()
        {
            this.document.CreateArgumentList(new Argument[] { null });
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateArgumentListWithNull2()
        {
            this.document.CreateArgumentList(new Argument[] { null, this.document.CreateArgument(this.document.CreateLiteralExpression("y")) });
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateArgumentListWithNull3()
        {
            this.document.CreateArgumentList(new Argument[] { this.document.CreateArgument(this.document.CreateLiteralExpression("x")), null });
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateArgumentListWithNull4()
        {
            this.document.CreateArgumentList(new Argument[] { this.document.CreateArgument(this.document.CreateLiteralExpression("x")), null, this.document.CreateArgument(this.document.CreateLiteralExpression("y")) });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateArgumentListWithInvalidDocument1()
        {
            this.document.CreateArgumentList(new Argument[] { this.CreateDocument().CreateArgument(this.document.CreateLiteralExpression("x")), this.document.CreateArgument(this.document.CreateLiteralExpression("y")) });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateArgumentListWithInvalidDocument2()
        {
            this.document.CreateArgumentList(new Argument[] { this.document.CreateArgument(this.document.CreateLiteralExpression("x")), this.CreateDocument().CreateArgument(this.document.CreateLiteralExpression("y")) });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateArgumentListWithRepeatedArgument1()
        {
            Argument a = this.document.CreateArgument(this.document.CreateLiteralExpression("x"));
            this.document.CreateArgumentList(new Argument[] { a, a });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateArgumentListWithRepeatedArgument2()
        {
            Argument a = this.document.CreateArgument(this.document.CreateLiteralExpression("x"));
            this.document.CreateArgumentList(new Argument[] { a, this.document.CreateArgument(this.document.CreateLiteralExpression("y")), a });
        }

        #endregion ArgumentList

        #region FileHeader

        [TestMethod]
        public void CsCreateFileHeaderTest()
        {
            // Something
            string headerXml = "Something";
            this.TestFileHeader(
                1,
                headerXml,
                this.document.CreateSingleLineComment("// Something"));

            // Something    
            //line2
            //line3
            headerXml = "Somethingline2line3";
            this.TestFileHeader(
                3,
                headerXml,
                this.document.CreateSingleLineComment("// Something"),
                this.document.CreateSingleLineComment("//line2"),
                this.document.CreateSingleLineComment("//line3"));

            //-----------------------------------------------------------------------
            // <copyright file="File.cs">
            //     MS-PL
            // </copyright>
            //-----------------------------------------------------------------------
            headerXml = "<copyright file=\"File.cs\" company=\"Microsoft\">MS-PL</copyright>";
            this.TestFileHeader(
                5,
                headerXml,
                this.document.CreateSingleLineComment("//-----------------------------------------------------------------------"),
                this.document.CreateSingleLineComment("// <copyright file=\"File.cs\" company=\"Microsoft\">"),
                this.document.CreateSingleLineComment("//     MS-PL"),
                this.document.CreateSingleLineComment("// </copyright>"),
                this.document.CreateSingleLineComment("//-----------------------------------------------------------------------"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateFileHeaderWithNullCommentCollection()
        {
            this.document.CreateFileHeader(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateFileHeaderWithEmptyCommentCollection()
        {
            this.document.CreateFileHeader(new SingleLineComment[] { });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateFileHeaderWithSameCommentRepeated()
        {
            SingleLineComment comment = document.CreateSingleLineComment("// something");
            this.document.CreateFileHeader(comment, comment);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateFileHeaderWithSameCommentRepeated2()
        {
            SingleLineComment comment = document.CreateSingleLineComment("// something");
            this.document.CreateFileHeader(comment, document.CreateSingleLineComment("//somethingelse"), comment);
        }

        #endregion FileHeader

        #region ElementHeader

        [TestMethod]
        public void CsCreateElementHeaderTest()
        {
            // Something
            string headerXml = "Something";
            this.TestElementHeader(
                1,
                headerXml,
                this.document.CreateElementHeaderLine("/// Something"));

            // Something    
            //line2
            //line3
            headerXml = "Somethingline2line3";
            this.TestElementHeader(
                3,
                headerXml,
                this.document.CreateElementHeaderLine("/// Something"),
                this.document.CreateElementHeaderLine("///line2"),
                this.document.CreateElementHeaderLine("///line3"));

            /// <summary>
            /// Some summary.
            /// </summary>
            /// <param name="x">Some parameter.</param>
            headerXml = "<summary>Some summary.</summary><param name=\"x\">Some parameter.</param>";
            this.TestElementHeader(
                4,
                headerXml,
                this.document.CreateElementHeaderLine("/// <summary>"),
                this.document.CreateElementHeaderLine("/// Some summary."),
                this.document.CreateElementHeaderLine("/// </summary>"),
                this.document.CreateElementHeaderLine("/// <param name=\"x\">Some parameter.</param>"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderWithNullCommentCollection()
        {
            this.document.CreateElementHeader(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderWithEmptyLineCollection()
        {
            this.document.CreateElementHeader(new ElementHeaderLine[] { });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderWithSameLineRepeated()
        {
            ElementHeaderLine line = document.CreateElementHeaderLine("///something");
            this.document.CreateElementHeader(line, line);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderWithSameLineRepeated2()
        {
            ElementHeaderLine line = document.CreateElementHeaderLine("/// something");
            this.document.CreateElementHeader(line, document.CreateElementHeaderLine("///somethingelse"), line);
        }

        #endregion ElementHeader

        #endregion CodeUnits

        #region LexicalElements

        #region ElementHeaderLine

        [TestMethod]
        public void CsCreateElementHeaderLineTest()
        {
            this.TestElementHeaderLine("///");
            this.TestElementHeaderLine("/// ");
            this.TestElementHeaderLine("///	");
            this.TestElementHeaderLine("///Something");
            this.TestElementHeaderLine("/// Something");
            this.TestElementHeaderLine("///  Something");
            this.TestElementHeaderLine("///	Something");
            this.TestElementHeaderLine("///	Something");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithNullText()
        {
            this.TestElementHeaderLine(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithEmptyText()
        {
            this.TestElementHeaderLine(string.Empty);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithSpaceText()
        {
            this.TestElementHeaderLine(" ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithTabText()
        {
            this.TestElementHeaderLine("	");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithSpaceAndTabText()
        {
            this.TestElementHeaderLine(" 	 ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithMissingSlashes()
        {
            this.TestElementHeaderLine("Something");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithMissingSlashesAndSpace()
        {
            this.TestElementHeaderLine(" Something");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithTooManySlash()
        {
            this.TestElementHeaderLine("////");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithTooManySlash2()
        {
            this.TestElementHeaderLine("////Something");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithTooManySlash3()
        {
            this.TestElementHeaderLine("//// Something");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithTooManySlash4()
        {
            this.TestElementHeaderLine("//// ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithTooManySlash5()
        {
            this.TestElementHeaderLine("//////");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithTooManySlash6()
        {
            this.TestElementHeaderLine("///// ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithTooFewSlash1()
        {
            this.TestElementHeaderLine("//Hi");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithTooFewSlash2()
        {
            this.TestElementHeaderLine("// Hi");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithTooFewSlash3()
        {
            this.TestElementHeaderLine("//");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithTooFewSlash4()
        {
            this.TestElementHeaderLine("// ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithNewLine()
        {
            this.TestElementHeaderLine(@"///
            ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithTrailingSpace()
        {
            this.TestElementHeaderLine("/// Something ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithTrailingSpaces()
        {
            this.TestElementHeaderLine("/// Something   ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateElementHeaderLineWithTrailingTab()
        {
            this.TestElementHeaderLine("/// Something	");
        }

        #endregion ElementHeaderLine

        #region SingleLineComment

        [TestMethod]
        public void CsCreateSingleLineCommentsTest()
        {
            this.TestSingleLineComment("//");
            this.TestSingleLineComment("// ");
            this.TestSingleLineComment("//	");
            this.TestSingleLineComment("//Something");
            this.TestSingleLineComment("// Something");
            this.TestSingleLineComment("//  Something");
            this.TestSingleLineComment("//	Something");
            this.TestSingleLineComment("//	Something");
            this.TestSingleLineComment("////Something");
            this.TestSingleLineComment("//// Something");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithNullText()
        {
            this.TestSingleLineComment(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithEmptyText()
        {
            this.TestSingleLineComment(string.Empty);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithSpaceText()
        {
            this.TestSingleLineComment(" ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithTabText()
        {
            this.TestSingleLineComment("	");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithSpaceAndTabText()
        {
            this.TestSingleLineComment(" 	 ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithMissingSlashes()
        {
            this.TestSingleLineComment("Something");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithMissingSlashesAndSpace()
        {
            this.TestSingleLineComment(" Something");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithTripleSlash()
        {
            this.TestSingleLineComment("///");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithTripleSlash2()
        {
            this.TestSingleLineComment("///Something");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithTripleSlash3()
        {
            this.TestSingleLineComment("/// Something");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithTripleSlash4()
        {
            this.TestSingleLineComment("/// ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithNewLine()
        {
            this.TestSingleLineComment(@"//
            ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithTrailingSpace()
        {
            this.TestSingleLineComment("// Something ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithTrailingSpaces()
        {
            this.TestSingleLineComment("// Something   ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSingleLineCommentWithTrailingTab()
        {
            this.TestSingleLineComment("// Something	");
        }

        #endregion SingleLineComment

        #region MultilineComment

        [TestMethod]
        public void CsCreateMultilineCommentsTest()
        {
            this.TestMultlineComment("/* hi */");
            this.TestMultlineComment("/*hi*/");
            this.TestMultlineComment("/* hi*/");
            this.TestMultlineComment("/*hi */");
            this.TestMultlineComment("/***/");
            this.TestMultlineComment(@"/*
            hi*/");
            this.TestMultlineComment(@"/*hi
*/");
            this.TestMultlineComment(@"/*







            hi






  */");
            this.TestMultlineComment(@"/*/t*/");
            this.TestMultlineComment(@"/*/n*/");
            this.TestMultlineComment("/*/t*/");
            this.TestMultlineComment("/* /t*/");
            this.TestMultlineComment("/*/t */");
            this.TestMultlineComment("/*/t/t*/");
            this.TestMultlineComment("/*/n*/");
            this.TestMultlineComment("/*/r*/");
            this.TestMultlineComment("/*/r/n*/");
            this.TestMultlineComment("/*/n/r*/");
            this.TestMultlineComment("/* /t/r/n */");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateMultilineCommentWithWhitespace1()
        {
            this.TestMultlineComment("/* */");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateMultilineCommentWithWhitespace2()
        {
            this.TestMultlineComment("/*   */");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateMultilineCommentWithWhitespace3()
        {
            this.TestMultlineComment(@"/*
*/");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateMultilineCommentWithWhitespace4()
        {
            this.TestMultlineComment(@"/* 
                
                
                
                */");
        }

        #endregion MultilineComment

        #region Space

        [TestMethod]
        public void CsCreateSpaceTest()
        {
            this.TestWhitespace(this.document.CreateSpace(), " ", 1, 0);
            this.TestWhitespace(this.document.CreateSpaces(1), " ", 1, 0);
            this.TestWhitespace(this.document.CreateSpaces(2), "  ", 2, 0);
            this.TestWhitespace(this.document.CreateSpaces(3), "   ", 3, 0);
            this.TestWhitespace(this.document.CreateSpaces(10), "          ", 10, 0);
            this.TestWhitespace(this.document.CreateTab(), "\t", 0, 1);
            this.TestWhitespace(this.document.CreateTabs(1), "\t", 0, 1);
            this.TestWhitespace(this.document.CreateTabs(2), "\t\t", 0, 2);
            this.TestWhitespace(this.document.CreateTabs(3), "\t\t\t", 0, 3);
            this.TestWhitespace(this.document.CreateTabs(8), "\t\t\t\t\t\t\t\t", 0, 8);

            this.document.CreateSpaces(10000);
            this.document.CreateTabs(10000);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CsCreateSpaceWithZeroTest()
        {
            this.document.CreateSpaces(0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CsCreateSpaceWithNegativeTest()
        {
            this.document.CreateSpaces(-1);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CsCreateSpaceWithMinValueTest()
        {
            this.document.CreateSpaces(int.MinValue);
        }

        #endregion Space

        #region Tab

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CsCreateTabWithZeroTest()
        {
            this.document.CreateTabs(0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CsCreateTabWithNegativeTest()
        {
            this.document.CreateTabs(-1);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CsCreateTabWithMinValueTest()
        {
            this.document.CreateTabs(int.MinValue);
        }

        #endregion Tab

        #region EndOfLine

        [TestMethod]
        public void CsCreateEndOfLine()
        {
            EndOfLine eol = this.document.CreateEndOfLine();
            Assert.AreEqual(eol.Children.Count, 0);
            Assert.AreEqual(eol.CodeUnitType, CodeUnitType.LexicalElement);
            Assert.AreEqual(eol.Document, this.document);
            Assert.AreEqual(eol.Generated, false);
            Assert.AreEqual(eol.LexicalElementType, LexicalElementType.EndOfLine);
            Assert.AreEqual(eol.Text, "\n");
            Assert.AreEqual(eol.Variables.Count, 0);
        }

        #endregion EndOfLine

        #endregion LexicalElements

        #region Tokens

        [TestMethod]
        public void CsCreateSimpleTokensTest()
        {
            this.TestSimpleToken(this.document.CreateAbstractToken(), TokenType.Abstract, "abstract");
            this.TestSimpleToken(this.document.CreateAddToken(), TokenType.Add, "add");
            this.TestSimpleToken(this.document.CreateAliasToken(), TokenType.Alias, "alias");
            this.TestSimpleToken(this.document.CreateAscendingToken(), TokenType.Ascending, "ascending");
            this.TestSimpleToken(this.document.CreateAsToken(), TokenType.As, "as");
            this.TestSimpleToken(this.document.CreateAttributeColonToken(), TokenType.AttributeColon, ":");
            this.TestSimpleToken(this.document.CreateBaseColonToken(), TokenType.BaseColon, ":");
            this.TestSimpleToken(this.document.CreateBaseToken(), TokenType.Base, "base");
            this.TestSimpleToken(this.document.CreateBreakToken(), TokenType.Break, "break");
            this.TestSimpleToken(this.document.CreateByToken(), TokenType.By, "by");
            this.TestSimpleToken(this.document.CreateCaseToken(), TokenType.Case, "case");
            this.TestSimpleToken(this.document.CreateCatchToken(), TokenType.Catch, "catch");
            this.TestSimpleToken(this.document.CreateCheckedToken(), TokenType.Checked, "checked");
            this.TestSimpleToken(this.document.CreateClassToken(), TokenType.Class, "class");
            this.TestSimpleToken(this.document.CreateCloseAttributeBracketToken(), TokenType.CloseAttributeBracket, "]");
            this.TestSimpleToken(this.document.CreateCloseCurlyBracketToken(), TokenType.CloseCurlyBracket, "}");
            this.TestSimpleToken(this.document.CreateCloseGenericBracketToken(), TokenType.CloseGenericBracket, ">");
            this.TestSimpleToken(this.document.CreateCloseParenthesisToken(), TokenType.CloseParenthesis, ")");
            this.TestSimpleToken(this.document.CreateCloseSquareBracketToken(), TokenType.CloseSquareBracket, "]");
            this.TestSimpleToken(this.document.CreateCommaToken(), TokenType.Comma, ",");
            this.TestSimpleToken(this.document.CreateConstToken(), TokenType.Const, "const");
            this.TestSimpleToken(this.document.CreateContinueToken(), TokenType.Continue, "continue");
            this.TestSimpleToken(this.document.CreateDefaultToken(), TokenType.Default, "default");
            this.TestSimpleToken(this.document.CreateDefaultValueToken(), TokenType.DefaultValue, "default");
            this.TestSimpleToken(this.document.CreateDelegateToken(), TokenType.Delegate, "delegate");
            this.TestSimpleToken(this.document.CreateDescendingToken(), TokenType.Descending, "descending");
            this.TestSimpleToken(this.document.CreateDestructorTildeToken(), TokenType.DestructorTilde, "~");
            this.TestSimpleToken(this.document.CreateDoToken(), TokenType.Do, "do");
            this.TestSimpleToken(this.document.CreateElseToken(), TokenType.Else, "else");
            this.TestSimpleToken(this.document.CreateEnumToken(), TokenType.Enum, "enum");
            this.TestSimpleToken(this.document.CreateEqualsToken(), TokenType.Equals, "equals");
            this.TestSimpleToken(this.document.CreateEventToken(), TokenType.Event, "event");
            this.TestSimpleToken(this.document.CreateExplicitToken(), TokenType.Explicit, "explicit");
            this.TestSimpleToken(this.document.CreateExternDirectiveToken(), TokenType.ExternDirective, "extern");
            this.TestSimpleToken(this.document.CreateExternToken(), TokenType.Extern, "extern");
            this.TestSimpleToken(this.document.CreateFalseToken(), TokenType.False, "false");
            this.TestSimpleToken(this.document.CreateFinallyToken(), TokenType.Finally, "finally");
            this.TestSimpleToken(this.document.CreateFixedToken(), TokenType.Fixed, "fixed");
            this.TestSimpleToken(this.document.CreateForeachToken(), TokenType.Foreach, "foreach");
            this.TestSimpleToken(this.document.CreateForToken(), TokenType.For, "for");
            this.TestSimpleToken(this.document.CreateFromToken(), TokenType.From, "from");
            this.TestSimpleToken(this.document.CreateGetToken(), TokenType.Get, "get");
            this.TestSimpleToken(this.document.CreateGotoToken(), TokenType.Goto, "goto");
            this.TestSimpleToken(this.document.CreateGroupToken(), TokenType.Group, "group");
            this.TestSimpleToken(this.document.CreateIfToken(), TokenType.If, "if");
            this.TestSimpleToken(this.document.CreateImplicitToken(), TokenType.Implicit, "implicit");
            this.TestSimpleToken(this.document.CreateInterfaceToken(), TokenType.Interface, "interface");
            this.TestSimpleToken(this.document.CreateInternalToken(), TokenType.Internal, "internal");
            this.TestSimpleToken(this.document.CreateInToken(), TokenType.In, "in");
            this.TestSimpleToken(this.document.CreateIntoToken(), TokenType.Into, "into");
            this.TestSimpleToken(this.document.CreateIsToken(), TokenType.Is, "is");
            this.TestSimpleToken(this.document.CreateJoinToken(), TokenType.Join, "join");
            this.TestSimpleToken(this.document.CreateLabelColonToken(), TokenType.LabelColon, ":");
            this.TestSimpleToken(this.document.CreateLetToken(), TokenType.Let, "let");
            this.TestSimpleToken(this.document.CreateLockToken(), TokenType.Lock, "lock");
            this.TestSimpleToken(this.document.CreateNamespaceToken(), TokenType.Namespace, "namespace");
            this.TestSimpleToken(this.document.CreateNewToken(), TokenType.New, "new");
            this.TestSimpleToken(this.document.CreateNullableTypeToken(), TokenType.NullableTypeSymbol, "?");
            this.TestSimpleToken(this.document.CreateNullToken(), TokenType.Null, "null");
            this.TestSimpleToken(this.document.CreateOnToken(), TokenType.On, "on");
            this.TestSimpleToken(this.document.CreateOpenAttributeBracketToken(), TokenType.OpenAttributeBracket, "[");
            this.TestSimpleToken(this.document.CreateOpenCurlyBracketToken(), TokenType.OpenCurlyBracket, "{");
            this.TestSimpleToken(this.document.CreateOpenGenericBracketToken(), TokenType.OpenGenericBracket, "<");
            this.TestSimpleToken(this.document.CreateOpenParenthesisToken(), TokenType.OpenParenthesis, "(");
            this.TestSimpleToken(this.document.CreateOpenSquareBracketToken(), TokenType.OpenSquareBracket, "[");
            this.TestSimpleToken(this.document.CreateOperatorToken(), TokenType.Operator, "operator");
            this.TestSimpleToken(this.document.CreateOrderByToken(), TokenType.OrderBy, "orderby");
            this.TestSimpleToken(this.document.CreateOutToken(), TokenType.Out, "out");
            this.TestSimpleToken(this.document.CreateOverrideToken(), TokenType.Override, "override");
            this.TestSimpleToken(this.document.CreateParamsToken(), TokenType.Params, "params");
            this.TestSimpleToken(this.document.CreatePartialToken(), TokenType.Partial, "partial");
            this.TestSimpleToken(this.document.CreatePrivateToken(), TokenType.Private, "private");
            this.TestSimpleToken(this.document.CreateProtectedToken(), TokenType.Protected, "protected");
            this.TestSimpleToken(this.document.CreatePublicToken(), TokenType.Public, "public");
            this.TestSimpleToken(this.document.CreateReadonlyToken(), TokenType.Readonly, "readonly");
            this.TestSimpleToken(this.document.CreateRefToken(), TokenType.Ref, "ref");
            this.TestSimpleToken(this.document.CreateRemoveToken(), TokenType.Remove, "remove");
            this.TestSimpleToken(this.document.CreateReturnToken(), TokenType.Return, "return");
            this.TestSimpleToken(this.document.CreateSealedToken(), TokenType.Sealed, "sealed");
            this.TestSimpleToken(this.document.CreateSelectToken(), TokenType.Select, "select");
            this.TestSimpleToken(this.document.CreateSemicolonToken(), TokenType.Semicolon, ";");
            this.TestSimpleToken(this.document.CreateSetToken(), TokenType.Set, "set");
            this.TestSimpleToken(this.document.CreateSizeofToken(), TokenType.Sizeof, "sizeof");
            this.TestSimpleToken(this.document.CreateStackallocToken(), TokenType.Stackalloc, "stackalloc");
            this.TestSimpleToken(this.document.CreateStaticToken(), TokenType.Static, "static");
            this.TestSimpleToken(this.document.CreateStructToken(), TokenType.Struct, "struct");
            this.TestSimpleToken(this.document.CreateSwitchToken(), TokenType.Switch, "switch");
            this.TestSimpleToken(this.document.CreateThisToken(), TokenType.This, "this");
            this.TestSimpleToken(this.document.CreateThrowToken(), TokenType.Throw, "throw");
            this.TestSimpleToken(this.document.CreateTrueToken(), TokenType.True, "true");
            this.TestSimpleToken(this.document.CreateTryToken(), TokenType.Try, "try");
            this.TestSimpleToken(this.document.CreateTypeofToken(), TokenType.Typeof, "typeof");
            this.TestSimpleToken(this.document.CreateUncheckedToken(), TokenType.Unchecked, "unchecked");
            this.TestSimpleToken(this.document.CreateUnsafeToken(), TokenType.Unsafe, "unsafe");
            this.TestSimpleToken(this.document.CreateUsingDirectiveToken(), TokenType.UsingDirective, "using");
            this.TestSimpleToken(this.document.CreateUsingToken(), TokenType.Using, "using");
            this.TestSimpleToken(this.document.CreateVirtualToken(), TokenType.Virtual, "virtual");
            this.TestSimpleToken(this.document.CreateVolatileToken(), TokenType.Volatile, "volatile");
            this.TestSimpleToken(this.document.CreateWhereColonToken(), TokenType.WhereColon, ":");
            this.TestSimpleToken(this.document.CreateWhereToken(), TokenType.Where, "where");
            this.TestSimpleToken(this.document.CreateWhileDoToken(), TokenType.WhileDo, "while");
            this.TestSimpleToken(this.document.CreateWhileToken(), TokenType.While, "while");
            this.TestSimpleToken(this.document.CreateYieldToken(), TokenType.Yield, "yield");
        }

        [TestMethod]
        public void CsCreateConstructorConstraintTokenTest()
        {
        }

        [TestMethod]
        public void CsCreateGenericTypeTokenTest()
        {
        }

        [TestMethod]
        public void CsCreateLiteralTokenTest()
        {
            this.TestSimpleToken(document.CreateLiteralToken("someText"), TokenType.Literal, "someText");
            this.TestSimpleToken(document.CreateLiteralToken("SOMETEXT"), TokenType.Literal, "SOMETEXT");
            this.TestSimpleToken(document.CreateLiteralToken("sometext"), TokenType.Literal, "sometext");
            this.TestSimpleToken(document.CreateLiteralToken("1"), TokenType.Literal, "1");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLiteralTokenWithNullStringTest()
        {
            document.CreateLiteralToken(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLiteralTokenWithEmptyStringTest()
        {
            document.CreateLiteralToken(string.Empty);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLiteralTokenWithWhitespaceStringTest1()
        {
            document.CreateLiteralToken(" ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLiteralTokenWithWhitespaceStringTest2()
        {
            document.CreateLiteralToken("   ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLiteralTokenWithWhitespaceStringTest3()
        {
            document.CreateLiteralToken("\t");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLiteralTokenWithWhitespaceStringTest4()
        {
            document.CreateLiteralToken("\t ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLiteralTokenWithWhitespaceStringTest5()
        {
            document.CreateLiteralToken("\n");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLiteralTokenWithWhitespaceStringTest6()
        {
            document.CreateLiteralToken("\r");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLiteralTokenWithWhitespaceStringTest7()
        {
            document.CreateLiteralToken("\r\n");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLiteralTokenWithWhitespaceStringTest8()
        {
            document.CreateLiteralToken(" \t\r\n  \t  \n  \t  \r  \n ");
        }

        [TestMethod]
        public void CsCreateNumberTokenTest()
        {
            this.TestSimpleToken(document.CreateNumberToken(0), TokenType.Number, "0");
            this.TestSimpleToken(document.CreateNumberToken(1), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken(-1), TokenType.Number, "-1");
            this.TestSimpleToken(document.CreateNumberToken(+1), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken(0x10), TokenType.Number, "16");

            this.TestSimpleToken(document.CreateNumberToken((short)0), TokenType.Number, "0");
            this.TestSimpleToken(document.CreateNumberToken((short)1), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((short)-1), TokenType.Number, "-1");
            this.TestSimpleToken(document.CreateNumberToken((short)+1), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((short)1U), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((short)1u), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((short)1L), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((short)1UL), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((short)1Ul), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((short)1uL), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((short)1ul), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((short)1LU), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((short)1Lu), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((short)0x10), TokenType.Number, "16");
            this.TestSimpleToken(document.CreateNumberToken(short.MaxValue), TokenType.Number, "32767");
            this.TestSimpleToken(document.CreateNumberToken(short.MinValue), TokenType.Number, "-32768");

            this.TestSimpleToken(document.CreateNumberToken((int)0), TokenType.Number, "0");
            this.TestSimpleToken(document.CreateNumberToken((int)1), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((int)-1), TokenType.Number, "-1");
            this.TestSimpleToken(document.CreateNumberToken((int)+1), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((int)1U), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((int)1u), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((int)1L), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((int)1UL), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((int)1Ul), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((int)1uL), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((int)1ul), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((int)1LU), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((int)1Lu), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((int)0x10), TokenType.Number, "16");
            this.TestSimpleToken(document.CreateNumberToken(int.MaxValue), TokenType.Number, "2147483647");
            this.TestSimpleToken(document.CreateNumberToken(int.MinValue), TokenType.Number, "-2147483648");

            this.TestSimpleToken(document.CreateNumberToken((long)0), TokenType.Number, "0");
            this.TestSimpleToken(document.CreateNumberToken((long)1), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((long)-1), TokenType.Number, "-1");
            this.TestSimpleToken(document.CreateNumberToken((long)+1), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((long)1U), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((long)1u), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((long)1L), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((long)1UL), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((long)1Ul), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((long)1uL), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((long)1ul), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((long)1LU), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((long)1Lu), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken((long)0x10), TokenType.Number, "16");
            this.TestSimpleToken(document.CreateNumberToken(long.MaxValue), TokenType.Number, "9223372036854775807");
            this.TestSimpleToken(document.CreateNumberToken(long.MinValue), TokenType.Number, "-9223372036854775808");

            this.TestSimpleToken(document.CreateNumberToken("0"), TokenType.Number, "0");
            this.TestSimpleToken(document.CreateNumberToken("1"), TokenType.Number, "1");
            this.TestSimpleToken(document.CreateNumberToken("-1"), TokenType.Number, "-1");
            this.TestSimpleToken(document.CreateNumberToken("+1"), TokenType.Number, "+1");
            this.TestSimpleToken(document.CreateNumberToken("1U"), TokenType.Number, "1U");
            this.TestSimpleToken(document.CreateNumberToken("1u"), TokenType.Number, "1u");
            this.TestSimpleToken(document.CreateNumberToken("1L"), TokenType.Number, "1L");
            this.TestSimpleToken(document.CreateNumberToken("1l"), TokenType.Number, "1l");
            this.TestSimpleToken(document.CreateNumberToken("1UL"), TokenType.Number, "1UL");
            this.TestSimpleToken(document.CreateNumberToken("1Ul"), TokenType.Number, "1Ul");
            this.TestSimpleToken(document.CreateNumberToken("1uL"), TokenType.Number, "1uL");
            this.TestSimpleToken(document.CreateNumberToken("1ul"), TokenType.Number, "1ul");
            this.TestSimpleToken(document.CreateNumberToken("1LU"), TokenType.Number, "1LU");
            this.TestSimpleToken(document.CreateNumberToken("1Lu"), TokenType.Number, "1Lu");
            this.TestSimpleToken(document.CreateNumberToken("1lU"), TokenType.Number, "1lU");
            this.TestSimpleToken(document.CreateNumberToken("1lu"), TokenType.Number, "1lu");
            this.TestSimpleToken(document.CreateNumberToken("0x10"), TokenType.Number, "0x10");
            this.TestSimpleToken(document.CreateNumberToken("32767"), TokenType.Number, "32767");
            this.TestSimpleToken(document.CreateNumberToken("-32768"), TokenType.Number, "-32768");
            this.TestSimpleToken(document.CreateNumberToken("2147483647"), TokenType.Number, "2147483647");
            this.TestSimpleToken(document.CreateNumberToken("-2147483648"), TokenType.Number, "-2147483648");
            this.TestSimpleToken(document.CreateNumberToken("9223372036854775807"), TokenType.Number, "9223372036854775807");
            this.TestSimpleToken(document.CreateNumberToken("-9223372036854775808"), TokenType.Number, "-9223372036854775808");
        }

        [TestMethod]
        public void CsCreateStringTokenTest()
        {
            this.TestSimpleToken(document.CreateStringToken("\"someValue\""), TokenType.String, "\"someValue\"");
            this.TestSimpleToken(document.CreateStringToken("\"somevalue\""), TokenType.String, "\"somevalue\"");
            this.TestSimpleToken(document.CreateStringToken("\"SOMEVALUE\""), TokenType.String, "\"SOMEVALUE\"");
            this.TestSimpleToken(document.CreateStringToken("\" somevalue \""), TokenType.String, "\" somevalue \"");
            this.TestSimpleToken(document.CreateStringToken("\" \""), TokenType.String, "\" \"");
            this.TestSimpleToken(document.CreateStringToken("\"\""), TokenType.String, "\"\"");

            this.TestSimpleToken(document.CreateStringToken("@\"someValue\""), TokenType.String, "@\"someValue\"");
            this.TestSimpleToken(document.CreateStringToken("@\"somevalue\""), TokenType.String, "@\"somevalue\"");
            this.TestSimpleToken(document.CreateStringToken("@\"SOMEVALUE\""), TokenType.String, "@\"SOMEVALUE\"");
            this.TestSimpleToken(document.CreateStringToken("@\" somevalue \""), TokenType.String, "@\" somevalue \"");
            this.TestSimpleToken(document.CreateStringToken("@\" \""), TokenType.String, "@\" \"");
            this.TestSimpleToken(document.CreateStringToken("@\"\""), TokenType.String, "@\"\"");

            this.TestSimpleToken(document.CreateStringToken("'s'"), TokenType.String, "'s'");
            this.TestSimpleToken(document.CreateStringToken("'S'"), TokenType.String, "'S'");
            this.TestSimpleToken(document.CreateStringToken("' '"), TokenType.String, "' '");
            this.TestSimpleToken(document.CreateStringToken("'\t'"), TokenType.String, "'\t'");
            this.TestSimpleToken(document.CreateStringToken("''"), TokenType.String, "''");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateStringTokenWithNullStringTest()
        {
            document.CreateStringToken(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateStringTokenWithEmptyStringTest()
        {
            document.CreateStringToken(string.Empty);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateStringTokenWithBadQuotesTest1()
        {
            document.CreateStringToken("\"");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateStringTokenWithBadQuotesTest2()
        {
            document.CreateStringToken("\"'");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateStringTokenWithBadQuotesTest3()
        {
            document.CreateStringToken("'\"");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateStringTokenWithBadQuotesTest4()
        {
            document.CreateStringToken("'");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateStringTokenWithBadQuotesTest5()
        {
            document.CreateStringToken("@\"");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateStringTokenWithBadQuotesTest6()
        {
            document.CreateStringToken("\"\"@");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateStringTokenWithBadQuotesTest7()
        {
            document.CreateStringToken("@''");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateStringTokenWithBadQuotesTest8()
        {
            document.CreateStringToken(" \"\"");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateStringTokenWithBadQuotesTest9()
        {
            document.CreateStringToken("\"\" ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateStringTokenWithBadQuotesTest10()
        {
            document.CreateStringToken(" ");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateStringTokenWithBadQuotesTest11()
        {
            document.CreateStringToken("alfjalsdjf");
        }

        /// <summary>
        ///A test for CreateTypeToken
        ///</summary>
        [TestMethod]
        public void CsCreateTypeTokenTest()
        {
        }

        #endregion Tokens

        #region Operators

        [TestMethod]
        public void CsCreateOperatorsTest()
        {
            this.TestOperator(this.document.CreateAddressOfOperator(), OperatorType.AddressOf, "&");
            this.TestOperator(this.document.CreateAndEqualsOperator(), OperatorType.AndEquals, "&=");
            this.TestOperator(this.document.CreateBitwiseComplementOperator(), OperatorType.BitwiseComplement, "~");
            this.TestOperator(this.document.CreateConditionalAndOperator(), OperatorType.ConditionalAnd, "&&");
            this.TestOperator(this.document.CreateConditionalColonOperator(), OperatorType.ConditionalColon, ":");
            this.TestOperator(this.document.CreateConditionalEqualsOperator(), OperatorType.ConditionalEquals, "==");
            this.TestOperator(this.document.CreateConditionalOrOperator(), OperatorType.ConditionalOr, "||");
            this.TestOperator(this.document.CreateConditionalQuestionMarkOperator(), OperatorType.ConditionalQuestionMark, "?");
            this.TestOperator(this.document.CreateDecrementOperator(), OperatorType.Decrement, "--");
            this.TestOperator(this.document.CreateDereferenceOperator(), OperatorType.Dereference, "*");
            this.TestOperator(this.document.CreateDivisionEqualsOperator(), OperatorType.DivisionEquals, "/=");
            this.TestOperator(this.document.CreateDivisionOperator(), OperatorType.Division, "/");
            this.TestOperator(this.document.CreateEqualsOperator(), OperatorType.Equals, "=");
            this.TestOperator(this.document.CreateGreaterThanOperator(), OperatorType.GreaterThan, ">");
            this.TestOperator(this.document.CreateGreaterThanOrEqualsOperator(), OperatorType.GreaterThanOrEquals, ">=");
            this.TestOperator(this.document.CreateIncrementOperator(), OperatorType.Increment, "++");
            this.TestOperator(this.document.CreateLambdaOperator(), OperatorType.Lambda, "->");
            this.TestOperator(this.document.CreateLeftShiftEqualsOperator(), OperatorType.LeftShiftEquals, "<<=");
            this.TestOperator(this.document.CreateLeftShiftOperator(), OperatorType.LeftShift, "<<");
            this.TestOperator(this.document.CreateLessThanOperator(), OperatorType.LessThan, "<");
            this.TestOperator(this.document.CreateLessThanOrEqualsOperator(), OperatorType.LessThanOrEquals, "<=");
            this.TestOperator(this.document.CreateLogicalAndOperator(), OperatorType.LogicalAnd, "&");
            this.TestOperator(this.document.CreateLogicalOrOperator(), OperatorType.LogicalOr, "|");
            this.TestOperator(this.document.CreateLogicalXorOperator(), OperatorType.LogicalXor, "^");
            this.TestOperator(this.document.CreateMemberAccessOperator(), OperatorType.MemberAccess, ".");
            this.TestOperator(this.document.CreateMinusEqualsOperator(), OperatorType.MinusEquals, "-=");
            this.TestOperator(this.document.CreateMinusOperator(), OperatorType.Minus, "-");
            this.TestOperator(this.document.CreateModEqualsOperator(), OperatorType.ModEquals, "%=");
            this.TestOperator(this.document.CreateModOperator(), OperatorType.Mod, "%");
            this.TestOperator(this.document.CreateMultiplicationEqualsOperator(), OperatorType.MultiplicationEquals, "*=");
            this.TestOperator(this.document.CreateMultiplicationOperator(), OperatorType.Multiplication, "*");
            this.TestOperator(this.document.CreateNegativeOperator(), OperatorType.Negative, "-");
            this.TestOperator(this.document.CreateNotEqualsOperator(), OperatorType.NotEquals, "!=");
            this.TestOperator(this.document.CreateNotOperator(), OperatorType.Not, "!");
            this.TestOperator(this.document.CreateNullCoalescingSymbolOperator(), OperatorType.NullCoalescingSymbol, "??");
            this.TestOperator(this.document.CreateOrEqualsOperator(), OperatorType.OrEquals, "|=");
            this.TestOperator(this.document.CreatePlusEqualsOperator(), OperatorType.PlusEquals, "+=");
            this.TestOperator(this.document.CreatePlusOperator(), OperatorType.Plus, "+");
            this.TestOperator(this.document.CreatePointerOperator(), OperatorType.Pointer, "->");
            this.TestOperator(this.document.CreatePositiveOperator(), OperatorType.Positive, "+");
            this.TestOperator(this.document.CreateQualifiedAliasOperator(), OperatorType.QualifiedAlias, "::");
            this.TestOperator(this.document.CreateRightShiftEqualsOperator(), OperatorType.RightShiftEquals, ">>=");
            this.TestOperator(this.document.CreateRightShiftOperator(), OperatorType.RightShift, ">>");
            this.TestOperator(this.document.CreateXorEqualsOperator(), OperatorType.XorEquals, "^=");
        }

        #endregion Operators

        #region Expressions

        #region AdditionExpression

        [TestMethod]
        public void CsCreateAdditionExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            ArithmeticExpression expression = this.document.CreateAdditionExpression(left, right);
            this.TestExpression(expression, ExpressionType.Arithmetic, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.ArithmeticExpressionType, ArithmeticExpressionType.Addition);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateAdditionExpressionWithNullExpressions1()
        {
            this.document.CreateAdditionExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateAdditionExpressionWithNullExpressions2()
        {
            this.document.CreateAdditionExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateAdditionExpressionWithNullExpressions3()
        {
            this.document.CreateAdditionExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateAdditionExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateAdditionExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateAdditionExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateAdditionExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateAdditionExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateAdditionExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateAdditionExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateAdditionExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion AdditionExpression

        #region AddressOfExpression

        [TestMethod]
        public void CsCreateAddressOfExpressionTest()
        {
            LiteralExpression value = this.document.CreateLiteralExpression("x");
            UnsafeAccessExpression expression = this.document.CreateAddressOfExpression(value);
            this.TestExpression(expression, ExpressionType.UnsafeAccess, 2, 0);
            Assert.AreEqual(expression.Value, value);
            Assert.AreEqual(expression.UnsafeAccessExpressionType, UnsafeAccessExpressionType.AddressOf);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateAddressOfExpressionWithNullExpressions()
        {
            this.document.CreateAddressOfExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateAddressOfExpressionWithWrongDoc()
        {
            this.document.CreateAddressOfExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion AddressOfExpression

        #region AsExpression

        [TestMethod]
        public void CsCreateAsExpressionTest()
        {
            this.TestAsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("x"))));
            this.TestAsExpression(this.document.CreateMemberAccessExpression(this.document.CreateLiteralExpression("a"), "b"), this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("object"))));
        }

        [TestMethod, ExpectedException(typeof(SyntaxException))]
        public void CsCreateAsExpressionWithNonTypeExpression()
        {
            this.document.CreateAsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("object"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateAsExpressionWithNull1()
        {
            this.document.CreateAsExpression(null, this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("object"))));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateAsExpressionWithNull2()
        {
            this.document.CreateAsExpression(this.document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateAsExpressionWithNull3()
        {
            this.document.CreateAsExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateAsExpressionWithInvalidDocument()
        {
            this.document.CreateAsExpression(this.CreateDocument().CreateLiteralExpression("x"), this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("object"))));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateAsExpressionWithInvalidDocument2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateAsExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression(d.CreateTypeToken(d.CreateLiteralToken("object"))));
        }

        #endregion AsExpression

        #region AndEqualsExpression

        [TestMethod]
        public void CsCreateAndEqualsExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            AssignmentExpression expression = this.document.CreateAndEqualsExpression(left, right);
            this.TestExpression(expression, ExpressionType.Assignment, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.AssignmentExpressionType, AssignmentExpressionType.AndEquals);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateAndEqualsExpressionWithNullExpressions1()
        {
            this.document.CreateAndEqualsExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateAndEqualsExpressionWithNullExpressions2()
        {
            this.document.CreateAndEqualsExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateAndEqualsExpressionWithNullExpressions3()
        {
            this.document.CreateAndEqualsExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateAndEqualsExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateAndEqualsExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateAndEqualsExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateAndEqualsExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateAndEqualsExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateAndEqualsExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateAndEqualsExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateAndEqualsExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion AndEqualsExpression

        #region BitwiseComplementExpression

        [TestMethod]
        public void CsCreateBitwiseComplementExpressionTest()
        {
            LiteralExpression value = this.document.CreateLiteralExpression("x");
            UnaryExpression expression = this.document.CreateBitwiseComplementExpression(value);
            this.TestExpression(expression, ExpressionType.Unary, 2, 0);
            Assert.AreEqual(expression.Value, value);
            Assert.AreEqual(expression.UnaryExpressionType, UnaryExpressionType.BitwiseComplement);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateBitwiseComplementExpressionWithNullExpressions()
        {
            this.document.CreateBitwiseComplementExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateBitwiseComplementExpressionWithWrongDoc()
        {
            this.document.CreateBitwiseComplementExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion BitwiseComplementExpression

        #region CastExpression

        [TestMethod]
        public void CsCreateCastExpressionTest()
        {
            this.TestCastExpression(this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("x"))), this.document.CreateLiteralExpression("x"));
            this.TestCastExpression(this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("object"))), this.document.CreateMemberAccessExpression(this.document.CreateLiteralExpression("a"), "b"));
        }

        [TestMethod, ExpectedException(typeof(SyntaxException))]
        public void CsCreateCastExpressionWithNonTypeExpression()
        {
            this.document.CreateCastExpression(this.document.CreateLiteralExpression("object"), this.document.CreateLiteralExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateCastExpressionWithNull1()
        {
            this.document.CreateCastExpression(this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("object"))), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateCastExpressionWithNull2()
        {
            this.document.CreateCastExpression(null, this.document.CreateLiteralExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateCastExpressionWithNull3()
        {
            this.document.CreateCastExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateCastExpressionWithInvalidDocument()
        {
            this.document.CreateCastExpression(this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("object"))), this.CreateDocument().CreateLiteralExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateCastExpressionWithInvalidDocument2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateCastExpression(d.CreateLiteralExpression(d.CreateTypeToken(d.CreateLiteralToken("object"))), this.document.CreateLiteralExpression("x"));
        }

        #endregion CastExpression

        #region CheckedExpression

        [TestMethod]
        public void CsCreateCheckedExpressionTest()
        {
            this.TestCheckedExpression(this.document.CreateLiteralExpression("1"));
            this.TestCheckedExpression(this.document.CreatePointerAccessExpression(this.document.CreateLiteralExpression("x"), "y"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateCheckedExpressionWithNull()
        {
            this.document.CreateCheckedExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateCheckedExpressionWithInvalidDocument()
        {
            this.document.CreateCheckedExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion CheckedExpression

        #region ConditionalExpression

        [TestMethod]
        public void CsCreateConditionalExpressionTest()
        {
            this.TestConditionalExpression(this.document.CreateLiteralExpression("a"), this.document.CreateLiteralExpression("b"), this.document.CreateLiteralExpression("c"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateConditionalExpressionWithNull()
        {
            this.document.CreateConditionalExpression(null, this.document.CreateLiteralExpression("b"), this.document.CreateLiteralExpression("c"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateConditionalExpressionWithNull2()
        {
            this.document.CreateConditionalExpression(this.document.CreateLiteralExpression("a"), null, this.document.CreateLiteralExpression("c"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateConditionalExpressionWithNull3()
        {
            this.document.CreateConditionalExpression(this.document.CreateLiteralExpression("a"), this.document.CreateLiteralExpression("b"), null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateConditionalExpressionWithInvalidDocument()
        {
            this.document.CreateConditionalExpression(this.CreateDocument().CreateLiteralExpression("a"), this.document.CreateLiteralExpression("b"), this.document.CreateLiteralExpression("c"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateConditionalExpressionWithInvalidDocument2()
        {
            this.document.CreateConditionalExpression(this.document.CreateLiteralExpression("a"), this.CreateDocument().CreateLiteralExpression("b"), this.document.CreateLiteralExpression("c"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateConditionalExpressionWithInvalidDocument3()
        {
            this.document.CreateConditionalExpression(this.document.CreateLiteralExpression("a"), this.document.CreateLiteralExpression("b"), this.CreateDocument().CreateLiteralExpression("c"));
        }

        #endregion ConditionalExpression

        #region ConditionalAndExpression

        [TestMethod]
        public void CsCreateConditionalAndExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            ConditionalLogicalExpression expression = this.document.CreateConditionalAndExpression(left, right);
            this.TestExpression(expression, ExpressionType.ConditionalLogical, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.ConditionalLogicalExpressionType, ConditionalLogicalExpressionType.ConditionalAnd);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateConditionalAndExpressionWithNullExpressions1()
        {
            this.document.CreateConditionalAndExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateConditionalAndExpressionWithNullExpressions2()
        {
            this.document.CreateConditionalAndExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateConditionalAndExpressionWithNullExpressions3()
        {
            this.document.CreateConditionalAndExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateConditionalAndExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateConditionalAndExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateConditionalAndExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateConditionalAndExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateConditionalAndExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateConditionalAndExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateConditionalAndExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateConditionalAndExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion ConditionalAndExpression

        #region ConditionalOrExpression

        [TestMethod]
        public void CsCreateConditionalOrExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            ConditionalLogicalExpression expression = this.document.CreateConditionalOrExpression(left, right);
            this.TestExpression(expression, ExpressionType.ConditionalLogical, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.ConditionalLogicalExpressionType, ConditionalLogicalExpressionType.ConditionalOr);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateConditionalOrExpressionWithNullExpressions1()
        {
            this.document.CreateConditionalOrExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateConditionalOrExpressionWithNullExpressions2()
        {
            this.document.CreateConditionalOrExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateConditionalOrExpressionWithNullExpressions3()
        {
            this.document.CreateConditionalOrExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateConditionalOrExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateConditionalOrExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateConditionalOrExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateConditionalOrExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateConditionalOrExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateConditionalOrExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateConditionalOrExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateConditionalOrExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion ConditionalOrExpression

        #region DecrementPrefixExpression

        [TestMethod]
        public void CsCreateDecrementPrefixExpressionTest()
        {
            LiteralExpression child = this.document.CreateLiteralExpression("x");
            DecrementExpression expression = this.document.CreatePrefixDecrementExpression(child);
            this.TestExpression(expression, ExpressionType.Decrement, 2, 0);
            Assert.AreEqual(expression.Value, child);
            Assert.AreEqual(expression.DecrementExpressionType, DecrementExpressionType.Prefix);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDecrementPrefixExpressionWithNullExpressions()
        {
            this.document.CreatePrefixDecrementExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateDecrementPrefixExpressionWithWrongDoc()
        {
            this.document.CreatePrefixDecrementExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion DecrementPrefixExpression

        #region DecrementPostfixExpression

        [TestMethod]
        public void CsCreateDecrementPostfixExpressionTest()
        {
            LiteralExpression child = this.document.CreateLiteralExpression("x");
            DecrementExpression expression = this.document.CreatePostfixDecrementExpression(child);
            this.TestExpression(expression, ExpressionType.Decrement, 2, 0);
            Assert.AreEqual(expression.Value, child);
            Assert.AreEqual(expression.DecrementExpressionType, DecrementExpressionType.Postfix);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDecrementPostfixExpressionWithNullExpressions()
        {
            this.document.CreatePostfixDecrementExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateDecrementPostfixExpressionWithWrongDoc()
        {
            this.document.CreatePostfixDecrementExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion DecrementPostfixExpression

        #region DefaultValueExpression

        [TestMethod]
        public void CsCreateDefaultValueExpressionTest()
        {
            this.TestDefaultValueExpression(this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("int"))));
        }

        [TestMethod, ExpectedException(typeof(SyntaxException))]
        public void CsCreateDefaultValueExpressionWithNoType()
        {
            this.document.CreateDefaultValueExpression(this.document.CreateLiteralExpression("int"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDefaultValueExpressionWithNull()
        {
            this.document.CreateDefaultValueExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateDefaultValueExpressionWithInvalidDocument()
        {
            this.document.CreateDefaultValueExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion DefaultValueExpression

        #region DereferenceExpression

        [TestMethod]
        public void CsCreateDereferenceExpressionTest()
        {
            LiteralExpression value = this.document.CreateLiteralExpression("x");
            UnsafeAccessExpression expression = this.document.CreateDereferenceExpression(value);
            this.TestExpression(expression, ExpressionType.UnsafeAccess, 2, 0);
            Assert.AreEqual(expression.Value, value);
            Assert.AreEqual(expression.UnsafeAccessExpressionType, UnsafeAccessExpressionType.Dereference);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDereferenceExpressionWithNullExpressions()
        {
            this.document.CreateDereferenceExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateDereferenceExpressionWithWrongDoc()
        {
            this.document.CreateDereferenceExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion DereferenceExpression

        #region DivisionExpression

        [TestMethod]
        public void CsCreateDivisionExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            ArithmeticExpression expression = this.document.CreateDivisionExpression(left, right);
            this.TestExpression(expression, ExpressionType.Arithmetic, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.ArithmeticExpressionType, ArithmeticExpressionType.Division);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDivisionExpressionWithNullExpressions1()
        {
            this.document.CreateDivisionExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDivisionExpressionWithNullExpressions2()
        {
            this.document.CreateDivisionExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDivisionExpressionWithNullExpressions3()
        {
            this.document.CreateDivisionExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateDivisionExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateDivisionExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateDivisionExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateDivisionExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateDivisionExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateDivisionExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateDivisionExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateDivisionExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion DivisionExpression

        #region DivisionEqualsExpression

        [TestMethod]
        public void CsCreateDivisionEqualsExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            AssignmentExpression expression = this.document.CreateDivisionEqualsExpression(left, right);
            this.TestExpression(expression, ExpressionType.Assignment, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.AssignmentExpressionType, AssignmentExpressionType.DivisionEquals);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDivisionEqualsExpressionWithNullExpressions1()
        {
            this.document.CreateDivisionEqualsExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDivisionEqualsExpressionWithNullExpressions2()
        {
            this.document.CreateDivisionEqualsExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDivisionEqualsExpressionWithNullExpressions3()
        {
            this.document.CreateDivisionEqualsExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateDivisionEqualsExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateDivisionEqualsExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateDivisionEqualsExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateDivisionEqualsExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateDivisionEqualsExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateDivisionEqualsExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateDivisionEqualsExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateDivisionEqualsExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion DivisionEqualsExpression

        #region EqualsExpression

        [TestMethod]
        public void CsCreateEqualsExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            AssignmentExpression expression = this.document.CreateEqualsExpression(left, right);
            this.TestExpression(expression, ExpressionType.Assignment, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.AssignmentExpressionType, AssignmentExpressionType.Equals);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateEqualsExpressionWithNullExpressions1()
        {
            this.document.CreateEqualsExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateEqualsExpressionWithNullExpressions2()
        {
            this.document.CreateEqualsExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateEqualsExpressionWithNullExpressions3()
        {
            this.document.CreateEqualsExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateEqualsExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateEqualsExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateEqualsExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateEqualsExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateEqualsExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateEqualsExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateEqualsExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion EqualsExpression

        #region EqualToExpression

        [TestMethod]
        public void CsCreateEqualToExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            RelationalExpression expression = this.document.CreateEqualToExpression(left, right);
            this.TestExpression(expression, ExpressionType.Relational, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.RelationalExpressionType, RelationalExpressionType.EqualTo);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateEqualToExpressionWithNullExpressions1()
        {
            this.document.CreateEqualToExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateEqualToExpressionWithNullExpressions2()
        {
            this.document.CreateEqualToExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateEqualToExpressionWithNullExpressions3()
        {
            this.document.CreateEqualToExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateEqualToExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateEqualToExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateEqualToExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateEqualToExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateEqualToExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateEqualToExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateEqualToExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateEqualToExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion EqualToExpression

        #region GreaterThanExpression

        [TestMethod]
        public void CsCreateGreaterThanExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            RelationalExpression expression = this.document.CreateGreaterThanExpression(left, right);
            this.TestExpression(expression, ExpressionType.Relational, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.RelationalExpressionType, RelationalExpressionType.GreaterThan);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateGreaterThanExpressionWithNullExpressions1()
        {
            this.document.CreateGreaterThanExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateGreaterThanExpressionWithNullExpressions2()
        {
            this.document.CreateGreaterThanExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateGreaterThanExpressionWithNullExpressions3()
        {
            this.document.CreateGreaterThanExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateGreaterThanExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateGreaterThanExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateGreaterThanExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateGreaterThanExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateGreaterThanExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateGreaterThanExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateGreaterThanExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateGreaterThanExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion GreaterThanExpression

        #region GreaterThanOrEqualToExpression

        [TestMethod]
        public void CsCreateGreaterThanOrEqualToExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            RelationalExpression expression = this.document.CreateGreaterThanOrEqualToExpression(left, right);
            this.TestExpression(expression, ExpressionType.Relational, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.RelationalExpressionType, RelationalExpressionType.GreaterThanOrEqualTo);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateGreaterThanOrEqualToExpressionWithNullExpressions1()
        {
            this.document.CreateGreaterThanOrEqualToExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateGreaterThanOrEqualToExpressionWithNullExpressions2()
        {
            this.document.CreateGreaterThanOrEqualToExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateGreaterThanOrEqualToExpressionWithNullExpressions3()
        {
            this.document.CreateGreaterThanOrEqualToExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateGreaterThanOrEqualToExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateGreaterThanOrEqualToExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateGreaterThanOrEqualToExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateGreaterThanOrEqualToExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateGreaterThanOrEqualToExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateGreaterThanOrEqualToExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateGreaterThanOrEqualToExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateGreaterThanOrEqualToExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion GreaterThanOrEqualToExpression

        #region IncrementPrefixExpression

        [TestMethod]
        public void CsCreateIncrementPrefixExpressionTest()
        {
            LiteralExpression child = this.document.CreateLiteralExpression("x");
            IncrementExpression expression = this.document.CreatePrefixIncrementExpression(child);
            this.TestExpression(expression, ExpressionType.Increment, 2, 0);
            Assert.AreEqual(expression.Value, child);
            Assert.AreEqual(expression.IncrementExpressionType, IncrementExpressionType.Prefix);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateIncrementPrefixExpressionWithNullExpressions()
        {
            this.document.CreatePrefixIncrementExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateIncrementPrefixExpressionWithWrongDoc()
        {
            this.document.CreatePrefixIncrementExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion IncrementPrefixExpression

        #region IncrementPostfixExpression

        [TestMethod]
        public void CsCreateIncrementPostfixExpressionTest()
        {
            LiteralExpression child = this.document.CreateLiteralExpression("x");
            IncrementExpression expression = this.document.CreatePostfixIncrementExpression(child);
            this.TestExpression(expression, ExpressionType.Increment, 2, 0);
            Assert.AreEqual(expression.Value, child);
            Assert.AreEqual(expression.IncrementExpressionType, IncrementExpressionType.Postfix);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateIncrementPostfixExpressionWithNullExpressions()
        {
            this.document.CreatePostfixIncrementExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateIncrementPostfixExpressionWithWrongDoc()
        {
            this.document.CreatePostfixIncrementExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion IncrementPostfixExpression

        #region IsExpression

        [TestMethod]
        public void CsCreateIsExpressionTest()
        {
            this.TestIsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("x"))));
            this.TestIsExpression(this.document.CreatePointerAccessExpression(this.document.CreateLiteralExpression("a"), "b"), this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("object"))));
        }

        [TestMethod, ExpectedException(typeof(SyntaxException))]
        public void CsCreateIsExpressionWithNonTypeExpression()
        {
            this.document.CreateIsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("object"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateIsExpressionWithNull1()
        {
            this.document.CreateIsExpression(null, this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("object"))));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateIsExpressionWithNull2()
        {
            this.document.CreateIsExpression(this.document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateIsExpressionWithNull3()
        {
            this.document.CreateIsExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateIsExpressionWithInvalidDocument()
        {
            this.document.CreateIsExpression(this.CreateDocument().CreateLiteralExpression("x"), this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("object"))));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateIsExpressionWithInvalidDocument2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateIsExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression(d.CreateTypeToken(d.CreateLiteralToken("object"))));
        }

        #endregion IsExpression

        #region LeftShiftExpression

        [TestMethod]
        public void CsCreateLeftShiftExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            ArithmeticExpression expression = this.document.CreateLeftShiftExpression(left, right);
            this.TestExpression(expression, ExpressionType.Arithmetic, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.ArithmeticExpressionType, ArithmeticExpressionType.LeftShift);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLeftShiftExpressionWithNullExpressions1()
        {
            this.document.CreateLeftShiftExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLeftShiftExpressionWithNullExpressions2()
        {
            this.document.CreateLeftShiftExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLeftShiftExpressionWithNullExpressions3()
        {
            this.document.CreateLeftShiftExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLeftShiftExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateLeftShiftExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLeftShiftExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLeftShiftExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLeftShiftExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLeftShiftExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLeftShiftExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLeftShiftExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion LeftShiftExpression

        #region LeftShiftEqualsExpression

        [TestMethod]
        public void CsCreateLeftShiftEqualsExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            AssignmentExpression expression = this.document.CreateLeftShiftEqualsExpression(left, right);
            this.TestExpression(expression, ExpressionType.Assignment, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.AssignmentExpressionType, AssignmentExpressionType.LeftShiftEquals);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLeftShiftEqualsExpressionWithNullExpressions1()
        {
            this.document.CreateLeftShiftEqualsExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLeftShiftEqualsExpressionWithNullExpressions2()
        {
            this.document.CreateLeftShiftEqualsExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLeftShiftEqualsExpressionWithNullExpressions3()
        {
            this.document.CreateLeftShiftEqualsExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLeftShiftEqualsExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateLeftShiftEqualsExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLeftShiftEqualsExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLeftShiftEqualsExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLeftShiftEqualsExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLeftShiftEqualsExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLeftShiftEqualsExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLeftShiftEqualsExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion LeftShiftEqualsExpression

        #region LessThanExpression

        [TestMethod]
        public void CsCreateLessThanExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            RelationalExpression expression = this.document.CreateLessThanExpression(left, right);
            this.TestExpression(expression, ExpressionType.Relational, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.RelationalExpressionType, RelationalExpressionType.LessThan);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLessThanExpressionWithNullExpressions1()
        {
            this.document.CreateLessThanExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLessThanExpressionWithNullExpressions2()
        {
            this.document.CreateLessThanExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLessThanExpressionWithNullExpressions3()
        {
            this.document.CreateLessThanExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLessThanExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateLessThanExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLessThanExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLessThanExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLessThanExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLessThanExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLessThanExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLessThanExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion LessThanExpression

        #region LessThanOrEqualToExpression

        [TestMethod]
        public void CsCreateLessThanOrEqualToExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            RelationalExpression expression = this.document.CreateLessThanOrEqualToExpression(left, right);
            this.TestExpression(expression, ExpressionType.Relational, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.RelationalExpressionType, RelationalExpressionType.LessThanOrEqualTo);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLessThanOrEqualToExpressionWithNullExpressions1()
        {
            this.document.CreateLessThanOrEqualToExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLessThanOrEqualToExpressionWithNullExpressions2()
        {
            this.document.CreateLessThanOrEqualToExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLessThanOrEqualToExpressionWithNullExpressions3()
        {
            this.document.CreateLessThanOrEqualToExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLessThanOrEqualToExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateLessThanOrEqualToExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLessThanOrEqualToExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLessThanOrEqualToExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLessThanOrEqualToExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLessThanOrEqualToExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLessThanOrEqualToExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLessThanOrEqualToExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion LessThanOrEqualToExpression

        #region LogicalAndExpression

        [TestMethod]
        public void CsCreateLogicalAndExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            LogicalExpression expression = this.document.CreateLogicalAndExpression(left, right);
            this.TestExpression(expression, ExpressionType.Logical, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.LogicalExpressionType, LogicalExpressionType.LogicalAnd);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLogicalAndExpressionWithNullExpressions1()
        {
            this.document.CreateLogicalAndExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLogicalAndExpressionWithNullExpressions2()
        {
            this.document.CreateLogicalAndExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLogicalAndExpressionWithNullExpressions3()
        {
            this.document.CreateLogicalAndExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLogicalAndExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateLogicalAndExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLogicalAndExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLogicalAndExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLogicalAndExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLogicalAndExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLogicalAndExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLogicalAndExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion LogicalAndExpression

        #region LogicalOrExpression

        [TestMethod]
        public void CsCreateLogicalOrExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            LogicalExpression expression = this.document.CreateLogicalOrExpression(left, right);
            this.TestExpression(expression, ExpressionType.Logical, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.LogicalExpressionType, LogicalExpressionType.LogicalOr);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLogicalOrExpressionWithNullExpressions1()
        {
            this.document.CreateLogicalOrExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLogicalOrExpressionWithNullExpressions2()
        {
            this.document.CreateLogicalOrExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLogicalOrExpressionWithNullExpressions3()
        {
            this.document.CreateLogicalOrExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLogicalOrExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateLogicalOrExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLogicalOrExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLogicalOrExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLogicalOrExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLogicalOrExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLogicalOrExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLogicalOrExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion LogicalOrExpression

        #region LogicalXorExpression

        [TestMethod]
        public void CsCreateLogicalXorExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            LogicalExpression expression = this.document.CreateLogicalXorExpression(left, right);
            this.TestExpression(expression, ExpressionType.Logical, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.LogicalExpressionType, LogicalExpressionType.LogicalXor);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLogicalXorExpressionWithNullExpressions1()
        {
            this.document.CreateLogicalXorExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLogicalXorExpressionWithNullExpressions2()
        {
            this.document.CreateLogicalXorExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLogicalXorExpressionWithNullExpressions3()
        {
            this.document.CreateLogicalXorExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateLogicalXorExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateLogicalXorExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLogicalXorExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLogicalXorExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLogicalXorExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLogicalXorExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLogicalXorExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateLogicalXorExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion LogicalXorExpression

        #region MemberAccessExpression

        [TestMethod]
        public void CsCreateMemberAccessExpressionTest()
        {
            this.TestMemberAccessExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y"));
            this.TestMemberAccessExpression(this.document.CreateMemberAccessExpression(this.document.CreateLiteralExpression("a"), this.document.CreateLiteralExpression("b")), this.document.CreateLiteralExpression("y"));
            this.TestMemberAccessExpression(this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("method1"), null), this.document.CreateLiteralExpression("y"));
            this.TestMemberAccessExpression(this.document.CreateLiteralExpression("x"), "y");
            this.TestMemberAccessExpression(this.document.CreateMemberAccessExpression(this.document.CreateLiteralExpression("a"), "b"), "y");
            this.TestMemberAccessExpression(this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("method1"), null), "y");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMemberAccessExpressionWithNullExpressions1()
        {
            this.document.CreateMemberAccessExpression(null, (LiteralExpression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMemberAccessExpressionWithNullExpressions2()
        {
            this.document.CreateMemberAccessExpression(null, (string)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMemberAccessExpressionWithNullExpressions3()
        {
            this.document.CreateMemberAccessExpression(null, document.CreateLiteralExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMemberAccessExpressionWithNullExpressions4()
        {
            this.document.CreateMemberAccessExpression(document.CreateLiteralExpression("x"), (LiteralExpression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateMemberAccessExpressionWithNullExpressions5()
        {
            this.document.CreateMemberAccessExpression(document.CreateLiteralExpression("x"), (string)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateMemberAccessExpressionWithEmptyString()
        {
            this.document.CreateMemberAccessExpression(document.CreateLiteralExpression("x"), string.Empty);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateMemberAccessExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateMemberAccessExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMemberAccessExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateMemberAccessExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMemberAccessExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateMemberAccessExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("y"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMemberAccessExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateMemberAccessExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("y"));
        }

        #endregion MemberAccessExpression

        #region MethodInvocationExpression

        [TestMethod]
        public void CsCreateMethodInvocationExpressionTest()
        {
            this.TestMethodInvocationExpression(this.document.CreateLiteralExpression("Method1"), (ArgumentList)null);
            this.TestMethodInvocationExpression(this.document.CreateLiteralExpression("Method1"), this.document.CreateArgumentList(null));
            this.TestMethodInvocationExpression(this.document.CreateLiteralExpression("Method1"), this.document.CreateArgumentList(new Argument[] { }));
            this.TestMethodInvocationExpression(this.document.CreateLiteralExpression("Method1"), this.document.CreateArgumentList(new Argument[] { this.document.CreateArgument(this.document.CreateLiteralExpression("x")) }));
            this.TestMethodInvocationExpression(this.document.CreateLiteralExpression("Method1"), this.document.CreateArgumentList(new Argument[] { this.document.CreateArgument(this.document.CreateLiteralExpression("x")), this.document.CreateArgument(this.document.CreateLiteralExpression("y")) }));

            this.TestMethodInvocationExpression(this.document.CreateMemberAccessExpression(this.document.CreateLiteralExpression("this"), "Method1"), null);

            this.TestMethodInvocationExpression(this.document.CreateLiteralExpression("Method1"), (ICollection<Argument>)null);
            this.TestMethodInvocationExpression(this.document.CreateLiteralExpression("Method1"), new Argument[] { });
            this.TestMethodInvocationExpression(this.document.CreateLiteralExpression("Method1"), new Argument[] { this.document.CreateArgument(this.document.CreateLiteralExpression("x")) });
            this.TestMethodInvocationExpression(this.document.CreateLiteralExpression("Method1"), new Argument[] { this.document.CreateArgument(this.document.CreateLiteralExpression("x")), this.document.CreateArgument(this.document.CreateLiteralExpression("y")) });

            this.TestMethodInvocationExpression(this.document.CreateLiteralExpression("Method1"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMethodInvocationExpressionWithNull()
        {
            this.TestMethodInvocationExpression(null, this.document.CreateArgumentList(new Argument[] { this.document.CreateArgument(this.document.CreateLiteralExpression("x")) }));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMethodInvocationExpressionWithNull2()
        {
            this.TestMethodInvocationExpression(null, new Argument[] { this.document.CreateArgument(this.document.CreateLiteralExpression("x")) });
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMethodInvocationExpressionWithNull3()
        {
            this.TestMethodInvocationExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMethodInvocationExpressionWithInvalidDocument1()
        {
            this.TestMethodInvocationExpression(this.CreateDocument().CreateLiteralExpression("Method1"), this.document.CreateArgumentList(new Argument[] { this.document.CreateArgument(this.document.CreateLiteralExpression("x")) }));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMethodInvocationExpressionWithInvalidDocument2()
        {
            this.TestMethodInvocationExpression(this.document.CreateLiteralExpression("Method1"), this.CreateDocument().CreateArgumentList(null));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMethodInvocationExpressionWithInvalidDocument3()
        {
            CsDocument doc = this.CreateDocument();
            this.TestMethodInvocationExpression(this.document.CreateLiteralExpression("Method1"), new Argument[] { doc.CreateArgument(doc.CreateLiteralExpression("x")) });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMethodInvocationExpressionWithInvalidDocument4()
        {
            this.TestMethodInvocationExpression(this.CreateDocument().CreateLiteralExpression("Method1"));
        }

        #endregion MethodInvocationExpression

        #region MinusEqualsExpression

        [TestMethod]
        public void CsCreateMinusEqualsExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            AssignmentExpression expression = this.document.CreateMinusEqualsExpression(left, right);
            this.TestExpression(expression, ExpressionType.Assignment, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.AssignmentExpressionType, AssignmentExpressionType.MinusEquals);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMinusEqualsExpressionWithNullExpressions1()
        {
            this.document.CreateMinusEqualsExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMinusEqualsExpressionWithNullExpressions2()
        {
            this.document.CreateMinusEqualsExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMinusEqualsExpressionWithNullExpressions3()
        {
            this.document.CreateMinusEqualsExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateMinusEqualsExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateMinusEqualsExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMinusEqualsExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateMinusEqualsExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMinusEqualsExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateMinusEqualsExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMinusEqualsExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateMinusEqualsExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion MinusEqualsExpression

        #region ModExpression

        [TestMethod]
        public void CsCreateModExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            ArithmeticExpression expression = this.document.CreateModExpression(left, right);
            this.TestExpression(expression, ExpressionType.Arithmetic, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.ArithmeticExpressionType, ArithmeticExpressionType.Mod);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateModExpressionWithNullExpressions1()
        {
            this.document.CreateModExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateModExpressionWithNullExpressions2()
        {
            this.document.CreateModExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateModExpressionWithNullExpressions3()
        {
            this.document.CreateModExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateModExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateModExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateModExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateModExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateModExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateModExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateModExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateModExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion ModExpression

        #region ModEqualsExpression

        [TestMethod]
        public void CsCreateModEqualsExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            AssignmentExpression expression = this.document.CreateModEqualsExpression(left, right);
            this.TestExpression(expression, ExpressionType.Assignment, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.AssignmentExpressionType, AssignmentExpressionType.ModEquals);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateModEqualsExpressionWithNullExpressions1()
        {
            this.document.CreateModEqualsExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateModEqualsExpressionWithNullExpressions2()
        {
            this.document.CreateModEqualsExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateModEqualsExpressionWithNullExpressions3()
        {
            this.document.CreateModEqualsExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateModEqualsExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateModEqualsExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateModEqualsExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateModEqualsExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateModEqualsExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateModEqualsExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateModEqualsExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateModEqualsExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion ModEqualsExpression

        #region MultiplicationExpression

        [TestMethod]
        public void CsCreateMultiplicationExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            ArithmeticExpression expression = this.document.CreateMultiplicationExpression(left, right);
            this.TestExpression(expression, ExpressionType.Arithmetic, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.ArithmeticExpressionType, ArithmeticExpressionType.Multiplication);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMultiplicationExpressionWithNullExpressions1()
        {
            this.document.CreateMultiplicationExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMultiplicationExpressionWithNullExpressions2()
        {
            this.document.CreateMultiplicationExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMultiplicationExpressionWithNullExpressions3()
        {
            this.document.CreateMultiplicationExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateMultiplicationExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateMultiplicationExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMultiplicationExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateMultiplicationExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMultiplicationExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateMultiplicationExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMultiplicationExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateMultiplicationExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion MultiplicationExpression

        #region MultiplicationEqualsExpression

        [TestMethod]
        public void CsCreateMultiplicationEqualsExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            AssignmentExpression expression = this.document.CreateMultiplicationEqualsExpression(left, right);
            this.TestExpression(expression, ExpressionType.Assignment, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.AssignmentExpressionType, AssignmentExpressionType.MultiplicationEquals);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMultiplicationEqualsExpressionWithNullExpressions1()
        {
            this.document.CreateMultiplicationEqualsExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMultiplicationEqualsExpressionWithNullExpressions2()
        {
            this.document.CreateMultiplicationEqualsExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateMultiplicationEqualsExpressionWithNullExpressions3()
        {
            this.document.CreateMultiplicationEqualsExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateMultiplicationEqualsExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateMultiplicationEqualsExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMultiplicationEqualsExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateMultiplicationEqualsExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMultiplicationEqualsExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateMultiplicationEqualsExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateMultiplicationEqualsExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateMultiplicationEqualsExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion MultiplicationEqualsExpression

        #region NegativeExpression

        [TestMethod]
        public void CsCreateNegativeExpressionTest()
        {
            LiteralExpression value = this.document.CreateLiteralExpression("x");
            UnaryExpression expression = this.document.CreateNegativeExpression(value);
            this.TestExpression(expression, ExpressionType.Unary, 2, 0);
            Assert.AreEqual(expression.Value, value);
            Assert.AreEqual(expression.UnaryExpressionType, UnaryExpressionType.Negative);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateNegativeExpressionWithNullExpressions()
        {
            this.document.CreateNegativeExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateNegativeExpressionWithWrongDoc()
        {
            this.document.CreateNegativeExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion NegativeExpression

        #region NotExpression

        [TestMethod]
        public void CsCreateNotExpressionTest()
        {
            LiteralExpression value = this.document.CreateLiteralExpression("x");
            UnaryExpression expression = this.document.CreateNotExpression(value);
            this.TestExpression(expression, ExpressionType.Unary, 2, 0);
            Assert.AreEqual(expression.Value, value);
            Assert.AreEqual(expression.UnaryExpressionType, UnaryExpressionType.Not);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateNotExpressionWithNullExpressions()
        {
            this.document.CreateNotExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateNotExpressionWithWrongDoc()
        {
            this.document.CreateNotExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion NotExpression

        #region NotEqualToExpression

        [TestMethod]
        public void CsCreateNotEqualToExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            RelationalExpression expression = this.document.CreateNotEqualToExpression(left, right);
            this.TestExpression(expression, ExpressionType.Relational, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.RelationalExpressionType, RelationalExpressionType.NotEqualTo);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateNotEqualToExpressionWithNullExpressions1()
        {
            this.document.CreateNotEqualToExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateNotEqualToExpressionWithNullExpressions2()
        {
            this.document.CreateNotEqualToExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateNotEqualToExpressionWithNullExpressions3()
        {
            this.document.CreateNotEqualToExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateNotEqualToExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateNotEqualToExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateNotEqualToExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateNotEqualToExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateNotEqualToExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateNotEqualToExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateNotEqualToExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateNotEqualToExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion NotEqualToExpression

        #region NullCoalescingExpression

        [TestMethod]
        public void CsCreateNullCoalescingExpressionTest()
        {
            this.TestNullCoalescingExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateNullCoalescingExpressionWithNullExpressions1()
        {
            this.document.CreateNullCoalescingExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateNullCoalescingExpressionWithNullExpressions2()
        {
            this.document.CreateNullCoalescingExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateNullCoalescingExpressionWithNullExpressions3()
        {
            this.document.CreateNullCoalescingExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateNullCoalescingExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateNullCoalescingExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateNullCoalescingExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateNullCoalescingExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateNullCoalescingExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateNullCoalescingExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateNullCoalescingExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateNullCoalescingExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion NullCoalescingExpression

        #region ObjectInitializerExpression

        [TestMethod]
        public void CsCreateObjectInitializerExpressionTest()
        {
            this.TestObjectInitializerExpression(new EqualsExpression[] { });
            this.TestObjectInitializerExpression(new EqualsExpression[] { document.CreateEqualsExpression(document.CreateLiteralExpression("X"), document.CreateLiteralExpression("2")) });
            this.TestObjectInitializerExpression(new EqualsExpression[] 
            { 
                document.CreateEqualsExpression(document.CreateLiteralExpression("X"), document.CreateLiteralExpression("2")),
                document.CreateEqualsExpression(document.CreateLiteralExpression("Y"), document.CreateLiteralExpression("3")),
                document.CreateEqualsExpression(document.CreateLiteralExpression("Z"), document.CreateMemberAccessExpression(document.CreateLiteralExpression("something"), "2"))
            });
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateObjectInitializerExpressionWithNull()
        {
            this.TestObjectInitializerExpression(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateObjectInitializerExpressionWithNull2()
        {
            this.TestObjectInitializerExpression(new EqualsExpression[] { null });
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateObjectInitializerExpressionWithNull3()
        {
            this.TestObjectInitializerExpression(new EqualsExpression[] { null, document.CreateEqualsExpression(document.CreateLiteralExpression("X"), document.CreateLiteralExpression("2")) });
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateObjectInitializerExpressionWithNull4()
        {
            this.TestObjectInitializerExpression(new EqualsExpression[] { document.CreateEqualsExpression(document.CreateLiteralExpression("X"), document.CreateLiteralExpression("2")), null });
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateObjectInitializerExpressionWithNull5()
        {
            this.TestObjectInitializerExpression(new EqualsExpression[] 
            { 
                document.CreateEqualsExpression(document.CreateLiteralExpression("X"), document.CreateLiteralExpression("2")), 
                null, 
                document.CreateEqualsExpression(document.CreateLiteralExpression("Y"), document.CreateLiteralExpression("3"))
            });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateObjectInitializerExpressionWithInvalidDocument()
        {
            CsDocument d = this.CreateDocument();
            this.TestObjectInitializerExpression(new EqualsExpression[] { d.CreateEqualsExpression(d.CreateLiteralExpression("A"), d.CreateLiteralExpression("B")) });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateObjectInitializerExpressionWithInvalidDocument2()
        {
            CsDocument d = this.CreateDocument();
            this.TestObjectInitializerExpression(new EqualsExpression[] 
            { 
                d.CreateEqualsExpression(d.CreateLiteralExpression("A"), d.CreateLiteralExpression("B")), 
                document.CreateEqualsExpression(document.CreateLiteralExpression("X"), document.CreateLiteralExpression("2")) 
            });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateObjectInitializerExpressionWithInvalidDocument3()
        {
            CsDocument d = this.CreateDocument();
            this.TestObjectInitializerExpression(new EqualsExpression[] 
            { 
                document.CreateEqualsExpression(document.CreateLiteralExpression("X"), document.CreateLiteralExpression("2")), 
                d.CreateEqualsExpression(d.CreateLiteralExpression("A"), d.CreateLiteralExpression("B"))
            });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateObjectInitializerExpressionWithInvalidDocument4()
        {
            CsDocument d = this.CreateDocument();

            this.TestObjectInitializerExpression(new EqualsExpression[] 
            { 
                document.CreateEqualsExpression(document.CreateLiteralExpression("X"), document.CreateLiteralExpression("2")), 
                d.CreateEqualsExpression(d.CreateLiteralExpression("A"), d.CreateLiteralExpression("B")), 
                document.CreateEqualsExpression(document.CreateLiteralExpression("Y"), document.CreateLiteralExpression("3"))
            });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateObjectInitializerExpressionWithInvalidAssignmentLeftHandExpression()
        {
            this.TestObjectInitializerExpression(new EqualsExpression[] { document.CreateEqualsExpression(document.CreateMemberAccessExpression(document.CreateLiteralExpression("A"), "B"), document.CreateLiteralExpression("B")) });
        }

        #endregion ObjectInitializerExpression

        #region OrEqualsExpression

        [TestMethod]
        public void CsCreateOrEqualsExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            AssignmentExpression expression = this.document.CreateOrEqualsExpression(left, right);
            this.TestExpression(expression, ExpressionType.Assignment, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.AssignmentExpressionType, AssignmentExpressionType.OrEquals);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateOrEqualsExpressionWithNullExpressions1()
        {
            this.document.CreateOrEqualsExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateOrEqualsExpressionWithNullExpressions2()
        {
            this.document.CreateOrEqualsExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateOrEqualsExpressionWithNullExpressions3()
        {
            this.document.CreateOrEqualsExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateOrEqualsExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateOrEqualsExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateOrEqualsExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateOrEqualsExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateOrEqualsExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateOrEqualsExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateOrEqualsExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateOrEqualsExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion OrEqualsExpression

        #region ParenthesizedExpression

        [TestMethod]
        public void CsCreateParenthesizedExpressionTest()
        {
            this.TestParenthesizedExpression(this.document.CreateLiteralExpression("x"));
            this.TestParenthesizedExpression(this.document.CreatePointerAccessExpression(this.document.CreateLiteralExpression("a"), "b"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateParenthesizedExpressionWithNull()
        {
            this.document.CreateParenthesizedExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateParenthesizedExpressionWithInvalidDocument()
        {
            this.document.CreateParenthesizedExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion ParenthesizedExpression

        #region PlusEqualsExpression

        [TestMethod]
        public void CsCreatePlusEqualsExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            AssignmentExpression expression = this.document.CreatePlusEqualsExpression(left, right);
            this.TestExpression(expression, ExpressionType.Assignment, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.AssignmentExpressionType, AssignmentExpressionType.PlusEquals);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreatePlusEqualsExpressionWithNullExpressions1()
        {
            this.document.CreatePlusEqualsExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreatePlusEqualsExpressionWithNullExpressions2()
        {
            this.document.CreatePlusEqualsExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreatePlusEqualsExpressionWithNullExpressions3()
        {
            this.document.CreatePlusEqualsExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreatePlusEqualsExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreatePlusEqualsExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreatePlusEqualsExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreatePlusEqualsExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreatePlusEqualsExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreatePlusEqualsExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreatePlusEqualsExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreatePlusEqualsExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion PlusEqualsExpression

        #region PointerAccessExpression

        [TestMethod]
        public void CsCreatePointerAccessExpressionTest()
        {
            this.TestPointerAccessExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y"));
            this.TestPointerAccessExpression(this.document.CreatePointerAccessExpression(this.document.CreateLiteralExpression("a"), this.document.CreateLiteralExpression("b")), this.document.CreateLiteralExpression("y"));
            this.TestPointerAccessExpression(this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("method1"), null), this.document.CreateLiteralExpression("y"));
            this.TestPointerAccessExpression(this.document.CreateLiteralExpression("x"), "y");
            this.TestPointerAccessExpression(this.document.CreatePointerAccessExpression(this.document.CreateLiteralExpression("a"), "b"), "y");
            this.TestPointerAccessExpression(this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("method1"), null), "y");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreatePointerAccessExpressionWithNullExpressions1()
        {
            this.document.CreatePointerAccessExpression(null, (LiteralExpression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreatePointerAccessExpressionWithNullExpressions2()
        {
            this.document.CreatePointerAccessExpression(null, (string)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreatePointerAccessExpressionWithNullExpressions3()
        {
            this.document.CreatePointerAccessExpression(null, document.CreateLiteralExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreatePointerAccessExpressionWithNullExpressions4()
        {
            this.document.CreatePointerAccessExpression(document.CreateLiteralExpression("x"), (LiteralExpression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreatePointerAccessExpressionWithNullExpressions5()
        {
            this.document.CreatePointerAccessExpression(document.CreateLiteralExpression("x"), (string)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreatePointerAccessExpressionWithEmptyString()
        {
            this.document.CreatePointerAccessExpression(document.CreateLiteralExpression("x"), string.Empty);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreatePointerAccessExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreatePointerAccessExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreatePointerAccessExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreatePointerAccessExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreatePointerAccessExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreatePointerAccessExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("y"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreatePointerAccessExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreatePointerAccessExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("y"));
        }

        #endregion PointerAccessExpression

        #region PositiveExpression

        [TestMethod]
        public void CsCreatePositiveExpressionTest()
        {
            LiteralExpression value = this.document.CreateLiteralExpression("x");
            UnaryExpression expression = this.document.CreatePositiveExpression(value);
            this.TestExpression(expression, ExpressionType.Unary, 2, 0);
            Assert.AreEqual(expression.Value, value);
            Assert.AreEqual(expression.UnaryExpressionType, UnaryExpressionType.Positive);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreatePositiveExpressionWithNullExpressions()
        {
            this.document.CreatePositiveExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreatePositiveExpressionWithWrongDoc()
        {
            this.document.CreatePositiveExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion PositiveExpression

        #region QualifiedAliasExpression

        [TestMethod]
        public void CsCreateQualifiedAliasExpressionTest()
        {
            this.TestQualifiedAliasExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y"));
            this.TestQualifiedAliasExpression(this.document.CreateQualifiedAliasExpression(this.document.CreateLiteralExpression("a"), this.document.CreateLiteralExpression("b")), this.document.CreateLiteralExpression("y"));
            this.TestQualifiedAliasExpression(this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("method1"), null), this.document.CreateLiteralExpression("y"));
            this.TestQualifiedAliasExpression(this.document.CreateLiteralExpression("x"), "y");
            this.TestQualifiedAliasExpression(this.document.CreateQualifiedAliasExpression(this.document.CreateLiteralExpression("a"), "b"), "y");
            this.TestQualifiedAliasExpression(this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("method1"), null), "y");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateQualifiedAliasExpressionWithNullExpressions1()
        {
            this.document.CreateQualifiedAliasExpression(null, (LiteralExpression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateQualifiedAliasExpressionWithNullExpressions2()
        {
            this.document.CreateQualifiedAliasExpression(null, (string)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateQualifiedAliasExpressionWithNullExpressions3()
        {
            this.document.CreateQualifiedAliasExpression(null, document.CreateLiteralExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateQualifiedAliasExpressionWithNullExpressions4()
        {
            this.document.CreateQualifiedAliasExpression(document.CreateLiteralExpression("x"), (LiteralExpression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateQualifiedAliasExpressionWithNullExpressions5()
        {
            this.document.CreateQualifiedAliasExpression(document.CreateLiteralExpression("x"), (string)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateQualifiedAliasExpressionWithEmptyString()
        {
            this.document.CreateQualifiedAliasExpression(document.CreateLiteralExpression("x"), string.Empty);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateQualifiedAliasExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateQualifiedAliasExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateQualifiedAliasExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateQualifiedAliasExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateQualifiedAliasExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateQualifiedAliasExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("y"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateQualifiedAliasExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateQualifiedAliasExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("y"));
        }

        #endregion QualifiedAliasExpression

        #region RightShiftExpression

        [TestMethod]
        public void CsCreateRightShiftExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            ArithmeticExpression expression = this.document.CreateRightShiftExpression(left, right);
            this.TestExpression(expression, ExpressionType.Arithmetic, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.ArithmeticExpressionType, ArithmeticExpressionType.RightShift);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateRightShiftExpressionWithNullExpressions1()
        {
            this.document.CreateRightShiftExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateRightShiftExpressionWithNullExpressions2()
        {
            this.document.CreateRightShiftExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateRightShiftExpressionWithNullExpressions3()
        {
            this.document.CreateRightShiftExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateRightShiftExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateRightShiftExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateRightShiftExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateRightShiftExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateRightShiftExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateRightShiftExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateRightShiftExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateRightShiftExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion RightShiftExpression

        #region RightShiftEqualsExpression

        [TestMethod]
        public void CsCreateRightShiftEqualsExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            AssignmentExpression expression = this.document.CreateRightShiftEqualsExpression(left, right);
            this.TestExpression(expression, ExpressionType.Assignment, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.AssignmentExpressionType, AssignmentExpressionType.RightShiftEquals);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateRightShiftEqualsExpressionWithNullExpressions1()
        {
            this.document.CreateRightShiftEqualsExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateRightShiftEqualsExpressionWithNullExpressions2()
        {
            this.document.CreateRightShiftEqualsExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateRightShiftEqualsExpressionWithNullExpressions3()
        {
            this.document.CreateRightShiftEqualsExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateRightShiftEqualsExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateRightShiftEqualsExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateRightShiftEqualsExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateRightShiftEqualsExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateRightShiftEqualsExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateRightShiftEqualsExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateRightShiftEqualsExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateRightShiftEqualsExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion RightShiftEqualsExpression

        #region SizeofExpression

        [TestMethod]
        public void CsCreateSizeofExpressionTest()
        {
            this.TestSizeofExpression(this.document.CreateLiteralExpression("int"));
            this.TestSizeofExpression(this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("int"))));
            this.TestSizeofExpression(this.document.CreatePointerAccessExpression(this.document.CreateLiteralExpression("x"), "y"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateSizeofExpressionWithNull()
        {
            this.document.CreateSizeofExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateSizeofExpressionWithInvalidDocument()
        {
            this.document.CreateSizeofExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion SizeofExpression

        #region SubtractionExpression

        [TestMethod]
        public void CsCreateSubtractionExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            ArithmeticExpression expression = this.document.CreateSubtractionExpression(left, right);
            this.TestExpression(expression, ExpressionType.Arithmetic, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.ArithmeticExpressionType, ArithmeticExpressionType.Subtraction);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateSubtractionExpressionWithNullExpressions1()
        {
            this.document.CreateSubtractionExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateSubtractionExpressionWithNullExpressions2()
        {
            this.document.CreateSubtractionExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateSubtractionExpressionWithNullExpressions3()
        {
            this.document.CreateSubtractionExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateSubtractionExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateSubtractionExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateSubtractionExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateSubtractionExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateSubtractionExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateSubtractionExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateSubtractionExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateSubtractionExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion SubtractionExpression

        #region TypeofExpression

        [TestMethod]
        public void CsCreateTypeofExpressionTest()
        {
            this.TestTypeofExpression(this.document.CreateLiteralExpression(this.document.CreateTypeToken(this.document.CreateLiteralToken("int"))));
        }

        [TestMethod, ExpectedException(typeof(SyntaxException))]
        public void CsCreateTypeofExpressionWithNoType()
        {
            this.document.CreateTypeofExpression(this.document.CreateLiteralExpression("int"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateTypeofExpressionWithNull()
        {
            this.document.CreateTypeofExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateTypeofExpressionWithInvalidDocument()
        {
            this.document.CreateTypeofExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion TypeofExpression

        #region UncheckedExpression

        [TestMethod]
        public void CsCreateUncheckedExpressionTest()
        {
            this.TestUncheckedExpression(this.document.CreateLiteralExpression("1"));
            this.TestUncheckedExpression(this.document.CreatePointerAccessExpression(this.document.CreateLiteralExpression("x"), "y"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateUncheckedExpressionWithNull()
        {
            this.document.CreateUncheckedExpression(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateUncheckedExpressionWithInvalidDocument()
        {
            this.document.CreateUncheckedExpression(this.CreateDocument().CreateLiteralExpression("x"));
        }

        #endregion UncheckedExpression

        #region VariableDeclaratorExpression

        [TestMethod]
        public void CsCreateVariableDeclaratorExpressionTest()
        {
            this.TestVariableDeclaratorExpression(this.document.CreateLiteralExpression("identifier"), null);
            this.TestVariableDeclaratorExpression(this.document.CreateLiteralExpression("identifier"), this.document.CreateMemberAccessExpression(this.document.CreateLiteralExpression("x"), "y"));

            this.TestVariableDeclaratorExpression("identifier", null);
            this.TestVariableDeclaratorExpression("identifier", this.document.CreateMemberAccessExpression(this.document.CreateLiteralExpression("x"), "y"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateVariableDeclaratorExpressionWithNull1()
        {
            this.document.CreateVariableDeclaratorExpression((LiteralExpression)null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateVariableDeclaratorExpressionWithNull2()
        {
            this.document.CreateVariableDeclaratorExpression((LiteralExpression)null, document.CreateLiteralExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclaratorExpressionWithNul31()
        {
            this.document.CreateVariableDeclaratorExpression((string)null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclaratorExpressionWithNull4()
        {
            this.document.CreateVariableDeclaratorExpression((string)null, document.CreateLiteralExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclaratorExpressionWithEmptyString()
        {
            this.document.CreateVariableDeclaratorExpression(string.Empty, null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclaratorExpressionWithInvalidDocument1()
        {
            this.document.CreateVariableDeclaratorExpression(this.CreateDocument().CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclaratorExpressionWithInvalidDocument2()
        {
            this.document.CreateVariableDeclaratorExpression(this.CreateDocument().CreateLiteralExpression("x"), this.document.CreateLiteralExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclaratorExpressionWithInvalidDocument3()
        {
            this.document.CreateVariableDeclaratorExpression(this.document.CreateLiteralExpression("x"), this.CreateDocument().CreateLiteralExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclaratorExpressionWithInvalidDocument4()
        {
            this.document.CreateVariableDeclaratorExpression("x", this.CreateDocument().CreateLiteralExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclaratorExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateVariableDeclaratorExpression(l, l);
        }

        #endregion VariableDeclaratorExpression

        #region VariableDeclarationExpression

        [TestMethod]
        public void CsCreateVariableDeclarationExpressionTest()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, string identifier)
            {
                var type = "int";
                var identifier = "a"; 
                var expression = this.document.CreateVariableDeclarationExpression(type, identifier);
                this.TestExpression(expression, ExpressionType.VariableDeclaration, 3, 1);
                Assert.AreEqual(expression.Type.Text, type);
                Assert.AreEqual(expression.Declarators.Count, 1);

                // there should only be one...
                foreach (VariableDeclaratorExpression declarator in expression.Declarators)
                {
                    Assert.AreEqual(declarator.Identifier.Text, identifier);
                }
            }

            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, VariableDeclaratorExpression declarator)
            {
                var type = "int";
                var declarator = this.document.CreateVariableDeclaratorExpression("a");
                var expression = this.document.CreateVariableDeclarationExpression(type, declarator);
                this.TestVariableDeclarationExpression(new VariableDeclaratorExpression[] { declarator }, expression);
                Assert.AreEqual(expression.Type.Text, type);
            }

            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, VariableDeclaratorExpression declarator)
            {
                var type = this.document.CreateLiteralTypeExpression("int");
                var declarator = this.document.CreateVariableDeclaratorExpression("a");
                var expression = this.document.CreateVariableDeclarationExpression(type, declarator);
                this.TestVariableDeclarationExpression(new VariableDeclaratorExpression[] { declarator }, expression);
                Assert.AreEqual(expression.Type, type.Token);
            }

            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, ICollection<VariableDeclaratorExpression> declarators)
            {
                var type = "int";
                var declarators = new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("a") };
                var expression = this.document.CreateVariableDeclarationExpression(type, declarators);
                this.TestVariableDeclarationExpression(declarators, expression);
                Assert.AreEqual(expression.Type.Text, type);
            }

            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, ICollection<VariableDeclaratorExpression> declarators)
            {
                var type = "int";
                var declarators = new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("a"), this.document.CreateVariableDeclaratorExpression("b") };
                var expression = this.document.CreateVariableDeclarationExpression(type, declarators);
                this.TestVariableDeclarationExpression(declarators, expression);
                Assert.AreEqual(expression.Type.Text, type);
            }

            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, ICollection<VariableDeclaratorExpression> declarators)
            {
                var type = this.document.CreateLiteralTypeExpression("int");
                var declarators = new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("a") };
                var expression = this.document.CreateVariableDeclarationExpression(type, declarators);
                this.TestVariableDeclarationExpression(declarators, expression);
                Assert.AreEqual(expression.Type, type.Token);
            }

            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, ICollection<VariableDeclaratorExpression> declarators)
            {
                var type = this.document.CreateLiteralTypeExpression("int");
                var declarators = new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("a"), this.document.CreateVariableDeclaratorExpression("b") };
                var expression = this.document.CreateVariableDeclarationExpression(type, declarators);
                this.TestVariableDeclarationExpression(declarators, expression);
                Assert.AreEqual(expression.Type, type.Token);
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithNull1()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, ICollection<VariableDeclaratorExpression> declarators)
            this.document.CreateVariableDeclarationExpression((string)null, (ICollection<VariableDeclaratorExpression>)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithNull2()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, ICollection<VariableDeclaratorExpression> declarators)
            this.document.CreateVariableDeclarationExpression((string)null, new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("x") });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithNull3()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, ICollection<VariableDeclaratorExpression> declarators)
            this.document.CreateVariableDeclarationExpression("x", (ICollection<VariableDeclaratorExpression>)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithNull4()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, VariableDeclaratorExpression declarator)
            this.document.CreateVariableDeclarationExpression((string)null, (VariableDeclaratorExpression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithNull5()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, VariableDeclaratorExpression declarator)
            this.document.CreateVariableDeclarationExpression((string)null, this.document.CreateVariableDeclaratorExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateVariableDeclarationExpressionWithNull6()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, VariableDeclaratorExpression declarator)
            this.document.CreateVariableDeclarationExpression("x", (VariableDeclaratorExpression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithNull7()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, string identifier)
            this.document.CreateVariableDeclarationExpression((string)null, (string)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithNull8()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, string identifier)
            this.document.CreateVariableDeclarationExpression((string)null, "x");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithNull9()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, string identifier)
            this.document.CreateVariableDeclarationExpression("x", (string)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateVariableDeclarationExpressionWithNull10()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, VariableDeclaratorExpression declarator)
            this.document.CreateVariableDeclarationExpression((LiteralExpression)null, (VariableDeclaratorExpression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateVariableDeclarationExpressionWithNull11()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, VariableDeclaratorExpression declarator)
            this.document.CreateVariableDeclarationExpression((LiteralExpression)null, this.document.CreateVariableDeclaratorExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateVariableDeclarationExpressionWithNull12()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, VariableDeclaratorExpression declarator)
            this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralExpression("x"), (VariableDeclaratorExpression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateVariableDeclarationExpressionWithNull13()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, ICollection<VariableDeclaratorExpression> declarators)
            this.document.CreateVariableDeclarationExpression((LiteralExpression)null, (ICollection<VariableDeclaratorExpression>)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateVariableDeclarationExpressionWithNull14()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, ICollection<VariableDeclaratorExpression> declarators)
            this.document.CreateVariableDeclarationExpression((LiteralExpression)null, new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("x") });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithNull15()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, ICollection<VariableDeclaratorExpression> declarators)
            this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralExpression("x"), (ICollection<VariableDeclaratorExpression>)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithEmptyString1()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, ICollection<VariableDeclaratorExpression> declarators)
            this.document.CreateVariableDeclarationExpression(string.Empty, new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("x") });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithEmptyString2()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, VariableDeclaratorExpression declarator)
            this.document.CreateVariableDeclarationExpression(string.Empty, this.document.CreateVariableDeclaratorExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithEmptyString3()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, string identifier)
            this.document.CreateVariableDeclarationExpression(string.Empty, "x");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithEmptyString4()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, string identifier)
            this.document.CreateVariableDeclarationExpression("x", string.Empty);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithEmptyString5()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, string identifier)
            this.document.CreateVariableDeclarationExpression(string.Empty, string.Empty);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithEmptyArray1()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, ICollection<VariableDeclaratorExpression> declarators)
            this.document.CreateVariableDeclarationExpression("int", new VariableDeclaratorExpression[] { });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithEmptyArray2()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, ICollection<VariableDeclaratorExpression> declarators)
            this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralTypeExpression("int"), new VariableDeclaratorExpression[] { });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionWithInvalidDocument1()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, ICollection<VariableDeclaratorExpression> declarators)
            CsDocument doc = this.CreateDocument();
            this.document.CreateVariableDeclarationExpression("int", new VariableDeclaratorExpression[] { doc.CreateVariableDeclaratorExpression("x") } );
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionWithInvalidDocument2()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, ICollection<VariableDeclaratorExpression> declarators)
            CsDocument doc = this.CreateDocument();
            this.document.CreateVariableDeclarationExpression("int", new VariableDeclaratorExpression[] { doc.CreateVariableDeclaratorExpression("x"), this.document.CreateVariableDeclaratorExpression("y") });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionWithInvalidDocument3()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, ICollection<VariableDeclaratorExpression> declarators)
            CsDocument doc = this.CreateDocument();
            this.document.CreateVariableDeclarationExpression("int", new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("x"), doc.CreateVariableDeclaratorExpression("y") });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionWithInvalidDocument4()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, VariableDeclaratorExpression declarator)
            this.document.CreateVariableDeclarationExpression("int", this.CreateDocument().CreateVariableDeclaratorExpression("x"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionWithInvalidDocument5()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, VariableDeclaratorExpression declarator)
            CsDocument doc = this.CreateDocument();
            this.document.CreateVariableDeclarationExpression(doc.CreateLiteralExpression("int"), this.document.CreateVariableDeclaratorExpression("y"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionWithInvalidDocument6()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, VariableDeclaratorExpression declarator)
            CsDocument doc = this.CreateDocument();
            this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralExpression("int"), doc.CreateVariableDeclaratorExpression("y"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionWithInvalidDocument7()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, ICollection<VariableDeclaratorExpression> declarators)
            CsDocument doc = this.CreateDocument();
            this.document.CreateVariableDeclarationExpression(doc.CreateLiteralExpression("int"), new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("x") });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionWithInvalidDocument8()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, ICollection<VariableDeclaratorExpression> declarators)
            CsDocument doc = this.CreateDocument();
            this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralExpression("int"), new VariableDeclaratorExpression[] { doc.CreateVariableDeclaratorExpression("x") });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionWithInvalidDocument9()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, ICollection<VariableDeclaratorExpression> declarators)
            CsDocument doc = this.CreateDocument();
            this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralExpression("int"), new VariableDeclaratorExpression[] { doc.CreateVariableDeclaratorExpression("x"), this.document.CreateVariableDeclaratorExpression("y") });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionWithInvalidDocument10()
        {
            // public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, ICollection<VariableDeclaratorExpression> declarators)
            CsDocument doc = this.CreateDocument();
            this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralExpression("int"), new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("x"), doc.CreateVariableDeclaratorExpression("y") });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithSameExpression11()
        {
            var v = this.document.CreateVariableDeclaratorExpression("a");
            this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralTypeExpression("int"), new VariableDeclaratorExpression[] { v, v });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithSameExpression12()
        {
            var v = this.document.CreateVariableDeclaratorExpression("a");
            var v2 = this.document.CreateVariableDeclaratorExpression("b");
            this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralTypeExpression("int"), new VariableDeclaratorExpression[] { v, v2, v });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithSameExpression13()
        {
            var v = this.document.CreateVariableDeclaratorExpression("a");
            var v2 = this.document.CreateVariableDeclaratorExpression("b");
            this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralTypeExpression("int"), new VariableDeclaratorExpression[] { v2, v, v });
        }

        [TestMethod, ExpectedException(typeof(SyntaxException))]
        public void CsCreateVariableDeclarationExpressionWithNonTypeExpression()
        {
            this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralExpression("x"), new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("a") });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithStringTypeWithNull1()
        {
            this.document.CreateVariableDeclarationExpression((string)null, (ICollection<VariableDeclaratorExpression>)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithStringTypeWithNull2()
        {
            this.document.CreateVariableDeclarationExpression((string)null, new VariableDeclaratorExpression[] { document.CreateVariableDeclaratorExpression("a") });
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateVariableDeclarationExpressionWithStringTypeWithNull3()
        {
            this.document.CreateVariableDeclarationExpression("int", new VariableDeclaratorExpression[] { null });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithStringTypeWithEmptyArray()
        {
            this.document.CreateVariableDeclarationExpression("int", new VariableDeclaratorExpression[] { });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionWithStringTypeWithInvalidDocument1()
        {
            this.document.CreateVariableDeclarationExpression("int", new VariableDeclaratorExpression[] { this.CreateDocument().CreateVariableDeclaratorExpression("a") });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionWithStringTypeWithInvalidDocument3()
        {
            this.document.CreateVariableDeclarationExpression("int", new VariableDeclaratorExpression[] { this.CreateDocument().CreateVariableDeclaratorExpression("a") });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithStringTypeWithSameExpression1()
        {
            var v = this.document.CreateVariableDeclaratorExpression("a");
            this.document.CreateVariableDeclarationExpression("int", new VariableDeclaratorExpression[] { v, v });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionWithStringTypeWithEmptyStringType()
        {
            this.document.CreateVariableDeclarationExpression(string.Empty, new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("a") });
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateVariableDeclarationExpressionSingleDeclaratorWithNull1()
        {
            this.document.CreateVariableDeclarationExpression((LiteralExpression)null, (VariableDeclaratorExpression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateVariableDeclarationExpressionSingleDeclaratorWithNull2()
        {
            this.document.CreateVariableDeclarationExpression((LiteralExpression)null, document.CreateVariableDeclaratorExpression("a"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionSingleDeclaratorWithInvalidDocument1()
        {
            this.document.CreateVariableDeclarationExpression(this.CreateDocument().CreateLiteralTypeExpression("int"), this.CreateDocument().CreateVariableDeclaratorExpression("a"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionSingleDeclaratorWithInvalidDocument2()
        {
            this.document.CreateVariableDeclarationExpression(this.CreateDocument().CreateLiteralTypeExpression("int"), this.document.CreateVariableDeclaratorExpression("a"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionSingleDeclaratorWithInvalidDocument3()
        {
            this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralTypeExpression("int"), this.CreateDocument().CreateVariableDeclaratorExpression("a"));
        }

        [TestMethod, ExpectedException(typeof(SyntaxException))]
        public void CsCreateVariableDeclarationExpressionSingleDeclaratorWithNonTypeExpression()
        {
            this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralExpression("x"), this.document.CreateVariableDeclaratorExpression("a"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionSingleDeclaratorWithStringTypeWithNull1()
        {
            this.document.CreateVariableDeclarationExpression((string)null, (VariableDeclaratorExpression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionSingleDeclaratorWithStringTypeWithNull2()
        {
            this.document.CreateVariableDeclarationExpression((string)null, document.CreateVariableDeclaratorExpression("a"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateVariableDeclarationExpressionSingleDeclaratorWithStringTypeWithNull3()
        {
            this.document.CreateVariableDeclarationExpression("int", (VariableDeclaratorExpression)null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationExpressionSingleDeclaratorWithStringTypeWithInvalidDocument1()
        {
            this.document.CreateVariableDeclarationExpression("int", this.CreateDocument().CreateVariableDeclaratorExpression("a"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateVariableDeclarationExpressionSingleDeclaratorWithStringTypeWithEmptyStringType()
        {
            this.document.CreateVariableDeclarationExpression(string.Empty, this.document.CreateVariableDeclaratorExpression("a"));
        }

        #endregion VariableDeclarationExpression

        #region XorEqualsExpression

        [TestMethod]
        public void CsCreateXorEqualsExpressionTest()
        {
            LiteralExpression left = this.document.CreateLiteralExpression("x");
            LiteralExpression right = this.document.CreateLiteralExpression("2");
            AssignmentExpression expression = this.document.CreateXorEqualsExpression(left, right);
            this.TestExpression(expression, ExpressionType.Assignment, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.AssignmentExpressionType, AssignmentExpressionType.XorEquals);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateXorEqualsExpressionWithNullExpressions1()
        {
            this.document.CreateXorEqualsExpression(null, null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateXorEqualsExpressionWithNullExpressions2()
        {
            this.document.CreateXorEqualsExpression(null, document.CreateLiteralExpression("2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateXorEqualsExpressionWithNullExpressions3()
        {
            this.document.CreateXorEqualsExpression(document.CreateLiteralExpression("x"), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateXorEqualsExpressionWithSameExpression()
        {
            LiteralExpression l = document.CreateLiteralExpression("x");
            this.document.CreateXorEqualsExpression(l, l);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateXorEqualsExpressionWithWrongDoc1()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateXorEqualsExpression(d.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateXorEqualsExpressionWithWrongDoc2()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateXorEqualsExpression(this.document.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateXorEqualsExpressionWithWrongDoc3()
        {
            CsDocument d = this.CreateDocument();
            this.document.CreateXorEqualsExpression(d.CreateLiteralExpression("x"), d.CreateLiteralExpression("4"));
        }

        #endregion XorEqualsExpression

        #endregion Expressions

        #region Statements

        #region BlockStatement

        [TestMethod]
        public void CsCreateBlockStatementTest()
        {
            {
                // Pass null
                var statement = this.document.CreateBlockStatement();
                this.TestStatement(statement, StatementType.Block, 3, 0);
                Assert.AreEqual(statement.Children.StatementCount, 0);
            }

            {
                // Pass empty collection
                var statement = this.document.CreateBlockStatement(new Statement[] { });
                this.TestStatement(statement, StatementType.Block, 3, 0);
                Assert.AreEqual(statement.Children.StatementCount, 0);
            }

            {
                // Pass one statement
                var statement = this.document.CreateBlockStatement(new Statement[] { this.document.CreateExpressionStatement(this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("2"))) });
                this.TestStatement(statement, StatementType.Block, 5, 0);
                Assert.AreEqual(statement.Children.StatementCount, 1);
            }

            {
                // Pass two statements
                var statement = this.document.CreateBlockStatement(new Statement[] 
                { 
                    this.document.CreateExpressionStatement(this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("2"))),
                    this.document.CreateExpressionStatement(this.document.CreatePrefixIncrementExpression(this.document.CreateLiteralExpression("x")))
                });

                this.TestStatement(statement, StatementType.Block, 7, 0);
                Assert.AreEqual(statement.Children.StatementCount, 2);
            }

            {
                // Pass one variable declaration statement
                var statement = this.document.CreateBlockStatement(new Statement[] { this.document.CreateVariableDeclarationStatement(this.document.CreateVariableDeclarationExpression("int", "x")) });
                this.TestStatement(statement, StatementType.Block, 5, 1);
                Assert.AreEqual(statement.Children.StatementCount, 1);
            }

            {
                // Pass one variable declaration statement having mulitiple declarators
                var statement = this.document.CreateBlockStatement(new Statement[] { this.document.CreateVariableDeclarationStatement(this.document.CreateVariableDeclarationExpression("int", new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("x"), this.document.CreateVariableDeclaratorExpression("y") })) });
                this.TestStatement(statement, StatementType.Block, 5, 2);
                Assert.AreEqual(statement.Children.StatementCount, 1);
            }

            {
                // Pass two variable declaration statements, one with multiple declarators
                var statement = this.document.CreateBlockStatement(new Statement[] 
                { 
                    this.document.CreateVariableDeclarationStatement(this.document.CreateVariableDeclarationExpression("int", new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("x"), this.document.CreateVariableDeclaratorExpression("y") })), 
                    this.document.CreateVariableDeclarationStatement(this.document.CreateVariableDeclarationExpression("string", "z")) 
                });

                this.TestStatement(statement, StatementType.Block, 7, 3);
                Assert.AreEqual(statement.Children.StatementCount, 2);
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateBlockStatementWithNull1()
        {
            this.document.CreateBlockStatement(new Statement[] { null });
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateBlockStatementWithNull2()
        {
            this.document.CreateBlockStatement(new Statement[] { this.document.CreateBreakStatement(), null });
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateBlockStatementWithNull3()
        {
            this.document.CreateBlockStatement(new Statement[] { null, this.document.CreateBreakStatement() });
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateBlockStatementWithInvalidDocument1()
        {
            var doc = this.CreateDocument();
            this.document.CreateBlockStatement(new Statement[] { doc.CreateBreakStatement() });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateBlockStatementWithSameChildStatement1()
        {
            var childStatement = this.document.CreateContinueStatement();
            this.document.CreateBlockStatement(new Statement[] { childStatement, childStatement });
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateBlockStatementWithSameChildStatement2()
        {
            var childStatement = this.document.CreateContinueStatement();
            this.document.CreateBlockStatement(new Statement[] { childStatement, this.document.CreateBreakStatement(), childStatement });
        }

        [TestMethod]
        public void CsAppendToEmptyBlockStatement()
        {
            // Create empty block
            var block = this.document.CreateBlockStatement();
            this.TestStatement(block, StatementType.Block, 3, 0);
            Assert.AreEqual(block.Children.StatementCount, 0);
                
            // Add a statement
            block.AppendChildStatement(block.Document.CreateExpressionStatement(block.Document.CreatePostfixIncrementExpression(block.Document.CreateLiteralExpression("x"))));
            this.TestStatement(block, StatementType.Block, 5, 0);
            Assert.AreEqual(block.Children.StatementCount, 1);

            // Add a newline
            block.AppendNewline();
            this.TestStatement(block, StatementType.Block, 6, 0);
            Assert.AreEqual(block.Children.StatementCount, 1);

            // Add a newline
            block.AppendNewline();
            this.TestStatement(block, StatementType.Block, 7, 0);
            Assert.AreEqual(block.Children.StatementCount, 1);

            // Add a variable declaration statement
            block.AppendChildStatement(block.Document.CreateVariableDeclarationStatement(block.Document.CreateVariableDeclarationExpression("int", "x")));
            this.TestStatement(block, StatementType.Block, 9, 1);
            Assert.AreEqual(block.Children.StatementCount, 2);

            // Add a newline
            block.AppendNewline();
            this.TestStatement(block, StatementType.Block, 10, 1);
            Assert.AreEqual(block.Children.StatementCount, 2);

            // Add a variable declaration statement
            block.AppendChildStatement(block.Document.CreateVariableDeclarationStatement(block.Document.CreateVariableDeclarationExpression("int", "y")));
            this.TestStatement(block, StatementType.Block, 12, 2);
            Assert.AreEqual(block.Children.StatementCount, 3);
        }

        [TestMethod]
        public void CsAppendToNonEmptyBlockStatement()
        {
            // Create empty block
            var block = this.document.CreateBlockStatement(
                new Statement[] 
                { 
                    this.document.CreateVariableDeclarationStatement(this.document.CreateVariableDeclarationExpression("int", "z")),
                    this.document.CreateContinueStatement()
                });

            this.TestStatement(block, StatementType.Block, 7, 1);
            Assert.AreEqual(block.Children.StatementCount, 2);

            // Add a statement
            block.AppendChildStatement(block.Document.CreateExpressionStatement(block.Document.CreatePostfixIncrementExpression(block.Document.CreateLiteralExpression("x"))));
            this.TestStatement(block, StatementType.Block, 9, 1);
            Assert.AreEqual(block.Children.StatementCount, 3);

            // Add a newline
            block.AppendNewline();
            this.TestStatement(block, StatementType.Block, 10, 1);
            Assert.AreEqual(block.Children.StatementCount, 3);

            // Add a newline
            block.AppendNewline();
            this.TestStatement(block, StatementType.Block, 11, 1);
            Assert.AreEqual(block.Children.StatementCount, 3);

            // Add a variable declaration statement
            block.AppendChildStatement(block.Document.CreateVariableDeclarationStatement(block.Document.CreateVariableDeclarationExpression("int", "x")));
            this.TestStatement(block, StatementType.Block, 13, 2);
            Assert.AreEqual(block.Children.StatementCount, 4);

            // Add a newline
            block.AppendNewline();
            this.TestStatement(block, StatementType.Block, 14, 2);
            Assert.AreEqual(block.Children.StatementCount, 4);

            // Add a variable declaration statement
            block.AppendChildStatement(block.Document.CreateVariableDeclarationStatement(block.Document.CreateVariableDeclarationExpression("int", "y")));
            this.TestStatement(block, StatementType.Block, 16, 3);
            Assert.AreEqual(block.Children.StatementCount, 5);
        }

        [TestMethod]
        public void CsAppendToTinyBlock()
        {
            // Create empty block
            var block = this.document.CreateBlockStatement();

            // Find and remove the newline between the opening and closing brackets to make this block as small as possible.
            var newline = block.FindFirstChild<EndOfLine>();

            // todo, remove the newline and then enable the lines below
            ////block.Remove(newline);
            ////block.AppendChildStatement(this.document.CreateBreakStatement());

            ////this.TestStatement(block, StatementType.Block, 4, 0);
            ////Assert.AreEqual(block.Children.StatementCount, 1);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsAppendToBlockStatementWithNull()
        {
            var block = this.document.CreateBlockStatement();
            block.AppendChildStatement(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsAppendToBlockStatementWithInvalidDoc()
        {
            var block = this.document.CreateBlockStatement();
            block.AppendChildStatement(this.CreateDocument().CreateBreakStatement());
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsAppendToBlockStatementWithSameStatement1()
        {
            var block = this.document.CreateBlockStatement();
            var statement = this.document.CreateBreakStatement();
            block.AppendChildStatement(statement);
            block.AppendChildStatement(statement);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsAppendToBlockStatementWithSameStatement2()
        {
            var statement = this.document.CreateBreakStatement();
            var block = this.document.CreateBlockStatement(new Statement[] { statement } );
            block.AppendChildStatement(statement);
        }

        [TestMethod, ExpectedException(typeof(SyntaxException))]
        public void CsAppendToBlockStatementWithMissingClosingCurly()
        {
            var block = this.document.CreateBlockStatement();
            var curly = block.FindLastChild<CloseCurlyBracketToken>();

            // Replace the closing curly bracket with a space.
            this.document.Replace(curly, this.document.CreateSpace());
            block.AppendChildStatement(this.document.CreateBreakStatement());
        }

        [TestMethod, ExpectedException(typeof(SyntaxException))]
        public void CsAppendToBlockStatementWithMissingClosingCurly2()
        {
            var block = this.document.CreateBlockStatement();
            var curly = block.FindLastChild<CloseCurlyBracketToken>();

            // Replace the closing curly bracket with a space.
            this.document.Replace(curly, this.document.CreateSpace());
            block.AppendNewline();
        }

        [TestMethod, ExpectedException(typeof(SyntaxException))]
        public void CsAppendToBlockStatementWithMissingOpeningCurly()
        {
            var block = this.document.CreateBlockStatement();

            // Replace the closing curly bracket with a space.
            var curly = block.FindFirstChild<OpenCurlyBracketToken>();
            this.document.Replace(curly, this.document.CreateSpace());

            // Replace the newline bracket with a space.
            var newline = block.FindFirstChild<EndOfLine>();
            this.document.Replace(newline, this.document.CreateSpace());

            block.AppendChildStatement(this.document.CreateBreakStatement());
        }

        [TestMethod, ExpectedException(typeof(SyntaxException))]
        public void CsAppendToBlockStatementWithMissingOpeningCurly2()
        {
            var block = this.document.CreateBlockStatement();

            // Replace the closing curly bracket with a space.
            var curly = block.FindFirstChild<OpenCurlyBracketToken>();
            this.document.Replace(curly, this.document.CreateSpace());

            // Replace the newline bracket with a space.
            var newline = block.FindFirstChild<EndOfLine>();
            this.document.Replace(newline, this.document.CreateSpace());
            
            block.AppendNewline();
        }

        #endregion BlockExpression

        #region BreakStatement

        [TestMethod]
        public void CsCreateBreakStatementTest()
        {
            BreakStatement statement = this.document.CreateBreakStatement();
            this.TestStatement(statement, StatementType.Break, 2, 0);
        }

        #endregion BreakStatement

        #region ContinueStatement

        [TestMethod]
        public void CsCreateContinueStatementTest()
        {
            ContinueStatement statement = this.document.CreateContinueStatement();
            this.TestStatement(statement, StatementType.Continue, 2, 0);
        }

        #endregion ContinueStatement

        #region DoWhileStatement

        [TestMethod]
        public void CsCreateDoWhileStatementTest()
        {
            // public static DoWhileStatement CreateDoWhileStatement(this CsDocument document, Expression condition, Expression body)
            {
                var condition = this.document.CreateLiteralExpression("true");
                var body = this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y"));
                var statement = this.document.CreateDoWhileStatement(condition, body);
                this.TestStatement(statement, StatementType.DoWhile, 9, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body.FindFirstChildExpression(), body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static DoWhileStatement CreateDoWhileStatement(this CsDocument document, Expression condition, Statement body)
            {
                var condition = this.document.CreateLiteralExpression("true");
                var body = this.document.CreateExpressionStatement(this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y")));
                var statement = this.document.CreateDoWhileStatement(condition, body);
                this.TestStatement(statement, StatementType.DoWhile, 9, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static DoWhileStatement CreateDoWhileStatement(this CsDocument document, Expression condition, Statement body)
            {
                var condition = this.document.CreateLiteralExpression("true");
                var body = this.document.CreateBlockStatement();
                var statement = this.document.CreateDoWhileStatement(condition, body);
                this.TestStatement(statement, StatementType.DoWhile, 9, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static DoWhileStatement CreateDoWhileStatement(this CsDocument document, Expression condition, Statement body)
            {
                var condition = this.document.CreateLiteralExpression("true");
                var body = this.document.CreateBlockStatement(new Statement[] { this.document.CreateExpressionStatement(this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("SomeMethod"))) });
                var statement = this.document.CreateDoWhileStatement(condition, body);
                this.TestStatement(statement, StatementType.DoWhile, 9, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static DoWhileStatement CreateDoWhileStatement(this CsDocument document, Expression condition, Statement body)
            {
                var condition = this.document.CreateEqualToExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y"));
                var body = this.document.CreateExpressionStatement(this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y")));
                var statement = this.document.CreateDoWhileStatement(condition, body);
                this.TestStatement(statement, StatementType.DoWhile, 9, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDoWhileStatementWithNullCondition()
        {
            this.document.CreateDoWhileStatement(null, this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDoWhileStatementWithNullBody1()
        {
            this.document.CreateDoWhileStatement(this.document.CreateLiteralExpression("true"), (Statement)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDoWhileStatementWithNullBody2()
        {
            this.document.CreateDoWhileStatement(this.document.CreateLiteralExpression("true"), (Expression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDoWhileStatementWithNulls1()
        {
            this.document.CreateDoWhileStatement(null, (Statement)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateDoWhileStatementWithNulls2()
        {
            this.document.CreateDoWhileStatement(null, (Expression)null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateDoWhileStatementWithWrongDoc1()
        {
            var doc = this.CreateDocument();
            this.document.CreateDoWhileStatement(doc.CreateLiteralExpression("true"), this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateDoWhileStatementWithWrongDoc2()
        {
            var doc = this.CreateDocument();
            this.document.CreateDoWhileStatement(this.document.CreateLiteralExpression("true"), doc.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateDoWhileStatementWithWrongDoc3()
        {
            var doc = this.CreateDocument();
            this.document.CreateDoWhileStatement(doc.CreateLiteralExpression("true"), doc.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateDoWhileStatementWithWrongDoc4()
        {
            var doc = this.CreateDocument();
            this.document.CreateDoWhileStatement(doc.CreateLiteralExpression("true"), doc.CreateMethodInvocationExpression(doc.CreateLiteralExpression("x")));
        }

        #endregion DoWhileStatement

        #region ExpressionStatement

        [TestMethod]
        public void CsCreateExpressionStatementTest()
        {
            {
                Expression e = this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("2"));
                ExpressionStatement statement = this.document.CreateExpressionStatement(e);
                this.TestStatement(statement, StatementType.Expression, 2, 0);
                Assert.AreEqual(statement.Expression, e);
            }

            {
                Expression e = this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("MyMethod"));
                ExpressionStatement statement = this.document.CreateExpressionStatement(e);
                this.TestStatement(statement, StatementType.Expression, 2, 0);
                Assert.AreEqual(statement.Expression, e);
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateExpressionStatementNullExpression()
        {
            this.document.CreateExpressionStatement(null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateExpressionStatementWithWrongDoc()
        {
            var doc = this.CreateDocument();
            this.document.CreateExpressionStatement(doc.CreateEqualsExpression(doc.CreateLiteralExpression("x"), doc.CreateLiteralExpression("y")));
        }

        #endregion ExpressionStatement

        #region FixedStatement

        [TestMethod]
        public void CsCreateFixedStatementTest()
        {
            // public static FixedStatement CreateFixedStatement(this CsDocument document, VariableDeclarationExpression fixedVariable, Expression body)
            {
                var variable = this.document.CreateVariableDeclarationExpression("int", "a");
                var body = this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y"));
                var statement = this.document.CreateFixedStatement(variable, body);
                this.TestStatement(statement, StatementType.Fixed, 7, 1);
                Assert.AreEqual(statement.FixedVariable, variable);
                Assert.AreEqual(statement.Body.FindFirstChildExpression(), body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static FixedStatement CreateFixedStatement(this CsDocument document, VariableDeclarationExpression fixedVariable, Statement body)
            {
                var variable = this.document.CreateVariableDeclarationExpression("int", "a");
                var body = this.document.CreateExpressionStatement(this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y")));
                var statement = this.document.CreateFixedStatement(variable, body);
                this.TestStatement(statement, StatementType.Fixed, 7, 1);
                Assert.AreEqual(statement.FixedVariable, variable);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static FixedStatement CreateFixedStatement(this CsDocument document, VariableDeclarationExpression fixedVariable, Statement body)
            {
                var variable = this.document.CreateVariableDeclarationExpression("int", this.document.CreateVariableDeclaratorExpression("a", this.document.CreateLiteralExpression("b")));
                var body = this.document.CreateBlockStatement();
                var statement = this.document.CreateFixedStatement(variable, body);
                this.TestStatement(statement, StatementType.Fixed, 7, 1);
                Assert.AreEqual(statement.FixedVariable, variable);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateFixedStatementWithNullCondition()
        {
            this.document.CreateFixedStatement(null, this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateFixedStatementWithNullBody1()
        {
            this.document.CreateFixedStatement(this.document.CreateVariableDeclarationExpression("int", "x"), (Statement)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateFixedStatementWithNullBody2()
        {
            this.document.CreateFixedStatement(this.document.CreateVariableDeclarationExpression("int", "x"), (Expression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateFixedStatementWithNulls1()
        {
            this.document.CreateFixedStatement(null, (Statement)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateFixedStatementWithNulls2()
        {
            this.document.CreateFixedStatement(null, (Expression)null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateFixedStatementWithWrongDoc1()
        {
            var doc = this.CreateDocument();
            this.document.CreateFixedStatement(doc.CreateVariableDeclarationExpression("int", "x"), this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateFixedStatementWithWrongDoc2()
        {
            var doc = this.CreateDocument();
            this.document.CreateFixedStatement(this.document.CreateVariableDeclarationExpression("int", "x"), doc.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateFixedStatementWithWrongDoc3()
        {
            var doc = this.CreateDocument();
            this.document.CreateFixedStatement(doc.CreateVariableDeclarationExpression("int", "x"), doc.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateFixedStatementWithWrongDoc4()
        {
            var doc = this.CreateDocument();
            this.document.CreateFixedStatement(doc.CreateVariableDeclarationExpression("int", "x"), doc.CreateMethodInvocationExpression(doc.CreateLiteralExpression("x")));
        }

        #endregion FixedStatement

        #region ForStatement

        [TestMethod]
        public void CsCreateForStatementTest()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (;;)
                var body = this.document.CreateBlockStatement();
                var statement = this.document.CreateForStatement(null, null, null, body);
                this.TestStatement(statement, StatementType.For, 8, 0);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 0);
                Assert.AreEqual(statement.Condition, null);
                Assert.AreEqual(statement.Iterators.Count, 0);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (;;)
                var body = this.document.CreateBlockStatement();
                var statement = this.document.CreateForStatement(new Expression[] { }, null, null, body);
                this.TestStatement(statement, StatementType.For, 8, 0);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 0);
                Assert.AreEqual(statement.Condition, null);
                Assert.AreEqual(statement.Iterators.Count, 0);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (;;)
                var body = this.document.CreateBlockStatement();
                var statement = this.document.CreateForStatement(null, null, new Expression[] { }, body);
                this.TestStatement(statement, StatementType.For, 8, 0);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 0);
                Assert.AreEqual(statement.Condition, null);
                Assert.AreEqual(statement.Iterators.Count, 0);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (;;)
                var body = this.document.CreateBlockStatement();
                var statement = this.document.CreateForStatement(new Expression[] { }, null, new Expression[] { }, body);
                this.TestStatement(statement, StatementType.For, 8, 0);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 0);
                Assert.AreEqual(statement.Condition, null);
                Assert.AreEqual(statement.Iterators.Count, 0);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (x;;)
                var body = this.document.CreateBlockStatement();
                var initializers = new Expression[] { this.document.CreateLiteralExpression("x") };
                var statement = this.document.CreateForStatement(initializers, null, null, body);
                this.TestStatement(statement, StatementType.For, 9, 0);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 1);
                Assert.AreEqual(statement.Condition, null);
                Assert.AreEqual(statement.Iterators.Count, 0);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (int x;;)
                var body = this.document.CreateBlockStatement();
                var initializers = new Expression[] { this.document.CreateVariableDeclarationExpression("int", "x") };
                var statement = this.document.CreateForStatement(initializers, null, null, body);
                this.TestStatement(statement, StatementType.For, 9, 1);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 1);
                Assert.AreEqual(statement.Condition, null);
                Assert.AreEqual(statement.Iterators.Count, 0);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (x, y;;)
                var body = this.document.CreateBlockStatement();
                var initializers = new Expression[] { this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y") };
                var statement = this.document.CreateForStatement(initializers, null, null, body);
                this.TestStatement(statement, StatementType.For, 12, 0);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 2);
                Assert.AreEqual(statement.Condition, null);
                Assert.AreEqual(statement.Iterators.Count, 0);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (int x, y;;)
                var body = this.document.CreateBlockStatement();
                var initializers = new Expression[] { this.document.CreateVariableDeclarationExpression("int", new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("x"), this.document.CreateVariableDeclaratorExpression("y") }) };
                var statement = this.document.CreateForStatement(initializers, null, null, body);
                this.TestStatement(statement, StatementType.For, 9, 2);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 1);
                Assert.AreEqual(statement.Condition, null);
                Assert.AreEqual(statement.Iterators.Count, 0);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (int x, string y;;)
                var body = this.document.CreateBlockStatement();
                var initializers = new Expression[] { this.document.CreateVariableDeclarationExpression("int", "x"), this.document.CreateVariableDeclarationExpression("string", "y") };
                var statement = this.document.CreateForStatement(initializers, null, null, body);
                this.TestStatement(statement, StatementType.For, 12, 2);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 2);
                Assert.AreEqual(statement.Condition, null);
                Assert.AreEqual(statement.Iterators.Count, 0);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (x, string y;;)
                var body = this.document.CreateBlockStatement();
                var initializers = new Expression[] { this.document.CreateLiteralExpression("x"), this.document.CreateVariableDeclarationExpression("string", "y") };
                var statement = this.document.CreateForStatement(initializers, null, null, body);
                this.TestStatement(statement, StatementType.For, 12, 1);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 2);
                Assert.AreEqual(statement.Condition, null);
                Assert.AreEqual(statement.Iterators.Count, 0);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (; x != true;)
                var body = this.document.CreateBlockStatement();
                var condition = this.document.CreateNotEqualToExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("true"));
                var statement = this.document.CreateForStatement(null, condition, null, body);
                this.TestStatement(statement, StatementType.For, 10, 0);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Iterators.Count, 0);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (;; ++x)
                var body = this.document.CreateBlockStatement();
                var iterators = new Expression[] { this.document.CreatePrefixIncrementExpression(this.document.CreateLiteralExpression("x")) };
                var statement = this.document.CreateForStatement(null, null, iterators, body);
                this.TestStatement(statement, StatementType.For, 10, 0);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 0);
                Assert.AreEqual(statement.Condition, null);
                Assert.AreEqual(statement.Iterators.Count, 1);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (;; ++x, y += 4)
                var body = this.document.CreateBlockStatement();
                var iterators = new Expression[] { this.document.CreatePrefixIncrementExpression(this.document.CreateLiteralExpression("x")), this.document.CreatePlusEqualsExpression(this.document.CreateLiteralExpression("y"), this.document.CreateLiteralExpression("4")) };
                var statement = this.document.CreateForStatement(null, null, iterators, body);
                this.TestStatement(statement, StatementType.For, 13, 0);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 0);
                Assert.AreEqual(statement.Condition, null);
                Assert.AreEqual(statement.Iterators.Count, 2);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (int x = 0, double y = -1, z = 2;; ++x, y += 4)
                var body = this.document.CreateBlockStatement();
                var initializers = new Expression[] 
                { 
                    this.document.CreateVariableDeclarationExpression("int", new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("x", this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"))) }),
                    this.document.CreateVariableDeclarationExpression("double", new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("y", this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("y"), this.document.CreateLiteralExpression("-1"))) }),
                    this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("y"), this.document.CreateLiteralExpression("2"))
                };

                var iterators = new Expression[] 
                { 
                    this.document.CreatePrefixIncrementExpression(this.document.CreateLiteralExpression("x")), 
                    this.document.CreatePlusEqualsExpression(this.document.CreateLiteralExpression("y"), this.document.CreateLiteralExpression("4")) 
                };

                var statement = this.document.CreateForStatement(initializers, null, iterators, body);
                this.TestStatement(statement, StatementType.For, 20, 2);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 3);
                Assert.AreEqual(statement.Condition, null);
                Assert.AreEqual(statement.Iterators.Count, 2);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            {
                // for (int x = 0, double y = -1, z = 2; x != 2 && y > 4; ++x, y += 4)
                var body = this.document.CreateBlockStatement();
                var initializers = new Expression[] 
                { 
                    this.document.CreateVariableDeclarationExpression("int", new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("x", this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("4"))) }),
                    this.document.CreateVariableDeclarationExpression("double", new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("y", this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("y"), this.document.CreateLiteralExpression("-1"))) }),
                    this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("y"), this.document.CreateLiteralExpression("2"))
                };

                var condition = this.document.CreateConditionalAndExpression(
                    this.document.CreateNotEqualToExpression(
                        this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("2")),
                    this.document.CreateGreaterThanExpression(
                        this.document.CreateLiteralExpression("y"), this.document.CreateLiteralExpression("4")));

                var iterators = new Expression[] 
                { 
                    this.document.CreatePrefixIncrementExpression(this.document.CreateLiteralExpression("x")), 
                    this.document.CreatePlusEqualsExpression(this.document.CreateLiteralExpression("y"), this.document.CreateLiteralExpression("4")) 
                };

                var statement = this.document.CreateForStatement(initializers, condition, iterators, body);
                this.TestStatement(statement, StatementType.For, 22, 2);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.Initializers.Count, 3);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Iterators.Count, 2);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Expression body)
            {
                // for (x = 0; x != 2; x += 2) 
                // x -= 1;
                var body = this.document.CreateMinusEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("1"));
                var initializers = new Expression[] { this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("0")) };
                var condition = this.document.CreateNotEqualToExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("2"));
                var iterators = new Expression[] { this.document.CreatePlusEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("2")) };

                var statement = this.document.CreateForStatement(initializers, condition, iterators, body);
                this.TestStatement(statement, StatementType.For, 13, 0);
                Assert.AreEqual(statement.Body.FindFirstChildExpression(), body);
                Assert.AreEqual(statement.Initializers.Count, 1);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Iterators.Count, 1);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateForStatementWithNull1()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Statement condition, ICollection<Expression> iterators, Expression body)
            this.document.CreateForStatement(
                new Expression[] { } , 
                this.document.CreateLiteralExpression("true"), 
                new Expression[] { }, 
                (Statement)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateForStatementWithNull2()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Expression body)
            this.document.CreateForStatement(
                new Expression[] { },
                this.document.CreateLiteralExpression("true"),
                new Expression[] { },
                (Expression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateForStatementWithNull3()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            this.document.CreateForStatement(
                new Expression[] { null },
                this.document.CreateLiteralExpression("true"),
                new Expression[] { },
                this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateForStatementWithNull4()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Expression body)
            this.document.CreateForStatement(
                new Expression[] { null },
                this.document.CreateLiteralExpression("true"),
                new Expression[] { },
                this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("Method")));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateForStatementWithNull5()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            this.document.CreateForStatement(
                new Expression[] { },
                this.document.CreateLiteralExpression("true"),
                new Expression[] { null },
                this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateForStatementWithNull6()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Expression body)
            this.document.CreateForStatement(
                new Expression[] { },
                this.document.CreateLiteralExpression("true"),
                new Expression[] { null },
                this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("Method")));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateForStatementWithWrongDoc1()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Statement condition, ICollection<Expression> iterators, Expression body)
            CsDocument doc = this.CreateDocument();
            this.document.CreateForStatement(
                new Expression[] { },
                this.document.CreateLiteralExpression("true"),
                new Expression[] { },
                doc.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateForStatementWithWrongDoc2()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Expression body)
            CsDocument doc = this.CreateDocument();
            this.document.CreateForStatement(
                new Expression[] { },
                this.document.CreateLiteralExpression("true"),
                new Expression[] { },
                doc.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("Method")));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateForStatementWithWrongDoc3()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            CsDocument doc = this.CreateDocument();
            this.document.CreateForStatement(
                new Expression[] { doc.CreateEqualsExpression(doc.CreateLiteralExpression("x"), doc.CreateLiteralExpression("2")) },
                this.document.CreateLiteralExpression("true"),
                new Expression[] { },
                this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateForStatementWithWrongDoc4()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Expression body)
            CsDocument doc = this.CreateDocument();
            this.document.CreateForStatement(
                new Expression[] { doc.CreateEqualsExpression(doc.CreateLiteralExpression("x"), doc.CreateLiteralExpression("2")) },
                this.document.CreateLiteralExpression("true"),
                new Expression[] { },
                this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("Method")));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateForStatementWithWrongDoc5()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            CsDocument doc = this.CreateDocument();
            this.document.CreateForStatement(
                new Expression[] { },
                doc.CreateLiteralExpression("true"),
                new Expression[] { },
                this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateForStatementWithWrongDoc6()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Expression body)
            CsDocument doc = this.CreateDocument();
            this.document.CreateForStatement(
                new Expression[] { },
                doc.CreateLiteralExpression("true"),
                new Expression[] { },
                this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("Method")));
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateForStatementWithWrongDoc7()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            CsDocument doc = this.CreateDocument();
            this.document.CreateForStatement(
                new Expression[] { },
                this.document.CreateLiteralExpression("true"),
                new Expression[] { doc.CreatePostfixIncrementExpression(doc.CreateLiteralExpression("x")) },
                this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateForStatementWithWrongDoc8()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Expression body)
            CsDocument doc = this.CreateDocument();
            this.document.CreateForStatement(
                new Expression[] { },
                this.document.CreateLiteralExpression("true"),
                new Expression[] { doc.CreatePostfixIncrementExpression(doc.CreateLiteralExpression("x")) },
                this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("Method")));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateForStatementWithReusedExpression1()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Expression body)
            Expression e = this.document.CreateLiteralExpression("x");
            this.document.CreateForStatement(
                new Expression[] { e, e },
                null,
                new Expression[] { },
                this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("Method")));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateForStatementWithReusedExpression2()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Expression body)
            Expression e = this.document.CreateLiteralExpression("x");
            this.document.CreateForStatement(
                new Expression[] { e },
                e,
                new Expression[] { },
                this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("Method")));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateForStatementWithReusedExpression3()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Expression body)
            Expression e = this.document.CreateLiteralExpression("x");
            this.document.CreateForStatement(
                new Expression[] { e, },
                null,
                new Expression[] { e },
                this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("Method")));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateForStatementWithReusedExpression5()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Expression body)
            Expression e = this.document.CreateLiteralExpression("x");
            this.document.CreateForStatement(
                new Expression[] { },
                e,
                new Expression[] { e },
                this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("Method")));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateForStatementWithReusedExpression7()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Expression body)
            Expression e = this.document.CreateLiteralExpression("x");
            this.document.CreateForStatement(
                new Expression[] { },
                null,
                new Expression[] { e, e },
                this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("Method")));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateForStatementWithReusedExpression9()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            Expression e = this.document.CreateLiteralExpression("x");
            this.document.CreateForStatement(
                new Expression[] { e, e },
                null,
                new Expression[] { },
                this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateForStatementWithReusedExpression10()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            Expression e = this.document.CreateLiteralExpression("x");
            this.document.CreateForStatement(
                new Expression[] { e },
                e,
                new Expression[] { },
                this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateForStatementWithReusedExpression11()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            Expression e = this.document.CreateLiteralExpression("x");
            this.document.CreateForStatement(
                new Expression[] { e },
                null,
                new Expression[] { e },
                this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateForStatementWithReusedExpression12()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            Expression e = this.document.CreateLiteralExpression("x");
            this.document.CreateForStatement(
                new Expression[] { },
                e,
                new Expression[] { e },
                this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateForStatementWithReusedExpression13()
        {
            // public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
            Expression e = this.document.CreateLiteralExpression("x");
            this.document.CreateForStatement(
                new Expression[] { },
                null,
                new Expression[] { e, e },
                this.document.CreateBlockStatement());
        }

        #endregion ForStatement

        #region ForeachStatement

        [TestMethod]
        public void CsCreateForeachStatementTest()
        {
            // public static ForeachStatement CreateForeachStatement(this CsDocument document, VariableDeclarationExpression iterationVariable, Expression collection, Expression body)
            {
                var variable = this.document.CreateVariableDeclarationExpression("int", "x");
                var collection = this.document.CreateLiteralExpression("y");
                var body = this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("SomeMethod"), new Argument[] { this.document.CreateArgument(this.document.CreateLiteralExpression("x")) });
                var statement = this.document.CreateForeachStatement(variable, collection, body);
                this.TestStatement(statement, StatementType.Foreach, 11, 1);
                Assert.AreEqual(statement.IterationVariable, variable);
                Assert.AreEqual(statement.Collection, collection);
                Assert.AreEqual(statement.Body.FindFirstChildExpression(), body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForeachStatement CreateForeachStatement(this CsDocument document, VariableDeclarationExpression iterationVariable, Expression collection, Statement body)
            {
                var variable = this.document.CreateVariableDeclarationExpression("int", "x");
                var collection = this.document.CreateLiteralExpression("y");
                var body = this.document.CreateExpressionStatement(this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("SomeMethod"), new Argument[] { this.document.CreateArgument(this.document.CreateLiteralExpression("x")) }));
                var statement = this.document.CreateForeachStatement(variable, collection, body);
                this.TestStatement(statement, StatementType.Foreach, 11, 1);
                Assert.AreEqual(statement.IterationVariable, variable);
                Assert.AreEqual(statement.Collection, collection);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static ForeachStatement CreateForeachStatement(this CsDocument document, VariableDeclarationExpression iterationVariable, Expression collection, Statement body)
            {
                var variable = this.document.CreateVariableDeclarationExpression("int", "x");
                var collection = this.document.CreateLiteralExpression("y");
                var body = this.document.CreateBlockStatement();
                var statement = this.document.CreateForeachStatement(variable, collection, body);
                this.TestStatement(statement, StatementType.Foreach, 11, 1);
                Assert.AreEqual(statement.IterationVariable, variable);
                Assert.AreEqual(statement.Collection, collection);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateForeachStatementWithNullVariable()
        {
            this.document.CreateForeachStatement(null, this.document.CreateLiteralExpression("y"), this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateForeachStatementWithNullCollection()
        {
            this.document.CreateForeachStatement(this.document.CreateVariableDeclarationExpression("int", "y"), null, this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateForeachStatementWithNullBody1()
        {
            this.document.CreateForeachStatement(this.document.CreateVariableDeclarationExpression("int", "y"), this.document.CreateLiteralExpression("y"), (Statement)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateForeachStatementWithNullBody2()
        {
            this.document.CreateForeachStatement(this.document.CreateVariableDeclarationExpression("int", "y"), this.document.CreateLiteralExpression("y"), (Expression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateForeachStatementWithNulls1()
        {
            this.document.CreateForeachStatement(null, null, (Statement)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateForeachStatementWithNulls2()
        {
            this.document.CreateForeachStatement(null, null, (Expression)null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateForeachStatementWithWrongDoc1()
        {
            var doc = this.CreateDocument();
            this.document.CreateForeachStatement(doc.CreateVariableDeclarationExpression("int", "y"), this.document.CreateLiteralExpression("y"), this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateForeachStatementWithWrongDoc2()
        {
            var doc = this.CreateDocument();
            this.document.CreateForeachStatement(this.document.CreateVariableDeclarationExpression("int", "y"), doc.CreateLiteralExpression("y"), this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateForeachStatementWithWrongDoc3()
        {
            var doc = this.CreateDocument();
            this.document.CreateForeachStatement(this.document.CreateVariableDeclarationExpression("int", "y"), this.document.CreateLiteralExpression("y"), doc.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateForeachStatementWithWrongDoc4()
        {
            var doc = this.CreateDocument();
            this.document.CreateForeachStatement(this.document.CreateVariableDeclarationExpression("int", "y"), this.document.CreateLiteralExpression("y"), doc.CreateEqualsExpression(doc.CreateLiteralExpression("x"), doc.CreateLiteralExpression("y")));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CsCreateForeachStatementWithReusedVariable()
        {
            var variable = this.document.CreateVariableDeclarationExpression("int", "y");
            this.document.CreateForeachStatement(variable, variable, this.document.CreateBlockStatement());
        }

        #endregion ForeachStatement

        #region IfStatement

        [TestMethod]
        public void CsCreateIfStatementTest()
        {
            // public static IfStatement CreateIfStatement(this CsDocument document, Expression condition, Expression body)
            {
                var condition = this.document.CreateLiteralExpression("true");
                var body = this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y"));
                var statement = this.document.CreateIfStatement(condition, body);
                this.TestStatement(statement, StatementType.If, 7, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body.FindFirstChildExpression(), body);
                Assert.IsNull(statement.AttachedElseStatement);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static IfStatement CreateIfStatement(this CsDocument document, Expression condition, Statement body)
            {
                var condition = this.document.CreateLiteralExpression("true");
                var body = this.document.CreateExpressionStatement(this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y")));
                var statement = this.document.CreateIfStatement(condition, body);
                this.TestStatement(statement, StatementType.If, 7, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body, body);
                Assert.IsNull(statement.AttachedElseStatement);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static IfStatement CreateIfStatement(this CsDocument document, Expression condition, Statement body)
            {
                var condition = this.document.CreateLiteralExpression("true");
                var body = this.document.CreateBlockStatement();
                var statement = this.document.CreateIfStatement(condition, body);
                this.TestStatement(statement, StatementType.If, 7, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body, body);
                Assert.IsNull(statement.AttachedElseStatement);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static IfStatement CreateIfStatement(this CsDocument document, Expression condition, Statement body)
            {
                var condition = this.document.CreateLiteralExpression("true");
                var body = this.document.CreateBlockStatement(new Statement[] { this.document.CreateExpressionStatement(this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("SomeMethod"))) });
                var statement = this.document.CreateIfStatement(condition, body);
                this.TestStatement(statement, StatementType.If, 7, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body, body);
                Assert.IsNull(statement.AttachedElseStatement);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static IfStatement CreateIfStatement(this CsDocument document, Expression condition, Statement body)
            {
                var condition = this.document.CreateEqualToExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y"));
                var body = this.document.CreateExpressionStatement(this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y")));
                var statement = this.document.CreateIfStatement(condition, body);
                this.TestStatement(statement, StatementType.If, 7, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body, body);
                Assert.IsNull(statement.AttachedElseStatement);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }
        }

        // todo: write new tests to test that attachedelsestatement and attachedstatement are correct when attaching various else statemnets to the end of hte if statement.

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateIfStatementWithNullCondition()
        {
            this.document.CreateIfStatement(null, this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateIfStatementWithNullBody1()
        {
            this.document.CreateIfStatement(this.document.CreateLiteralExpression("true"), (Statement)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateIfStatementWithNullBody2()
        {
            this.document.CreateIfStatement(this.document.CreateLiteralExpression("true"), (Expression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateIfStatementWithNulls1()
        {
            this.document.CreateIfStatement(null, (Statement)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateIfStatementWithNulls2()
        {
            this.document.CreateIfStatement(null, (Expression)null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateIfStatementWithWrongDoc1()
        {
            var doc = this.CreateDocument();
            this.document.CreateIfStatement(doc.CreateLiteralExpression("true"), this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateIfStatementWithWrongDoc2()
        {
            var doc = this.CreateDocument();
            this.document.CreateIfStatement(this.document.CreateLiteralExpression("true"), doc.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateIfStatementWithWrongDoc3()
        {
            var doc = this.CreateDocument();
            this.document.CreateIfStatement(doc.CreateLiteralExpression("true"), doc.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateIfStatementWithWrongDoc4()
        {
            var doc = this.CreateDocument();
            this.document.CreateIfStatement(doc.CreateLiteralExpression("true"), doc.CreateMethodInvocationExpression(doc.CreateLiteralExpression("x")));
        }

        #endregion IfStatement

        #region LockStatement

        [TestMethod]
        public void CsCreateLockStatementTest()
        {
            // public static LockStatement CreateLockStatement(this CsDocument document, VariableDeclarationExpression lockVariable, Expression body)
            {
                var lockObject = this.document.CreateLiteralExpression("this");
                var body = this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y"));
                var statement = this.document.CreateLockStatement(lockObject, body);
                this.TestStatement(statement, StatementType.Lock, 7, 0);
                Assert.AreEqual(statement.LockObject, lockObject);
                Assert.AreEqual(statement.Body.FindFirstChildExpression(), body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static LockStatement CreateLockStatement(this CsDocument document, VariableDeclarationExpression lockVariable, Statement body)
            {
                var lockObject = this.document.CreateLiteralExpression("this");
                var body = this.document.CreateExpressionStatement(this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y")));
                var statement = this.document.CreateLockStatement(lockObject, body);
                this.TestStatement(statement, StatementType.Lock, 7, 0);
                Assert.AreEqual(statement.LockObject, lockObject);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static LockStatement CreateLockStatement(this CsDocument document, VariableDeclarationExpression lockVariable, Statement body)
            {
                var lockObject = this.document.CreateLiteralExpression("this");
                var body = this.document.CreateBlockStatement();
                var statement = this.document.CreateLockStatement(lockObject, body);
                this.TestStatement(statement, StatementType.Lock, 7, 0);
                Assert.AreEqual(statement.LockObject, lockObject);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLockStatementWithNullCondition()
        {
            this.document.CreateLockStatement(null, this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLockStatementWithNullBody1()
        {
            this.document.CreateLockStatement(this.document.CreateLiteralExpression("this"), (Statement)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLockStatementWithNullBody2()
        {
            this.document.CreateLockStatement(this.document.CreateLiteralExpression("this"), (Expression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLockStatementWithNulls1()
        {
            this.document.CreateLockStatement(null, (Statement)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateLockStatementWithNulls2()
        {
            this.document.CreateLockStatement(null, (Expression)null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLockStatementWithWrongDoc1()
        {
            var doc = this.CreateDocument();
            this.document.CreateLockStatement(doc.CreateLiteralExpression("this"), this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLockStatementWithWrongDoc2()
        {
            var doc = this.CreateDocument();
            this.document.CreateLockStatement(this.document.CreateLiteralExpression("this"), doc.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLockStatementWithWrongDoc3()
        {
            var doc = this.CreateDocument();
            this.document.CreateLockStatement(doc.CreateLiteralExpression("this"), doc.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateLockStatementWithWrongDoc4()
        {
            var doc = this.CreateDocument();
            this.document.CreateLockStatement(doc.CreateLiteralExpression("this"), doc.CreateMethodInvocationExpression(doc.CreateLiteralExpression("x")));
        }

        #endregion LockStatement

        #region VariableDeclarationStatement

        [TestMethod]
        public void CsCreateVariableDeclarationStatementTest()
        {
            {
                var expression = this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralTypeExpression("int"), new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("a") });
                var statement = this.document.CreateVariableDeclarationStatement(expression);
                this.TestStatement(statement, StatementType.VariableDeclaration, 2, 1);
                Assert.AreEqual(statement.InnerExpression, expression);
                Assert.AreEqual(statement.Constant, false);
            }

            {
                var expression = this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralTypeExpression("int"), new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("a"), this.document.CreateVariableDeclaratorExpression("b") });
                var statement = this.document.CreateVariableDeclarationStatement(expression);
                this.TestStatement(statement, StatementType.VariableDeclaration, 2, 2);
                Assert.AreEqual(statement.InnerExpression, expression);
                Assert.AreEqual(statement.Constant, false);
            }

            {
                var expression = this.document.CreateVariableDeclarationExpression(this.document.CreateLiteralTypeExpression("int"), new VariableDeclaratorExpression[] { this.document.CreateVariableDeclaratorExpression("a") });
                var statement = this.document.CreateVariableDeclarationStatement(expression, true);
                this.TestStatement(statement, StatementType.VariableDeclaration, 4, 1);
                Assert.AreEqual(statement.InnerExpression, expression);
                Assert.AreEqual(statement.Constant, true);
            }

            // todo: handle the case where the parent is a const field, and thus the variable declaration statement should indicate that it is const.
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateVariableDeclarationStatementWithNull1()
        {
            this.document.CreateVariableDeclarationStatement(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateVariableDeclarationStatementWithNull2()
        {
            this.document.CreateVariableDeclarationStatement(null, true);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationStatementWithInvalidDocument1()
        {
            var doc = this.CreateDocument();
            var expression = doc.CreateVariableDeclarationExpression(doc.CreateLiteralTypeExpression("int"), new VariableDeclaratorExpression[] { doc.CreateVariableDeclaratorExpression("a") });
            this.document.CreateVariableDeclarationStatement(expression);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateVariableDeclarationStatementWithInvalidDocument2()
        {
            var doc = this.CreateDocument();
            var expression = doc.CreateVariableDeclarationExpression(doc.CreateLiteralTypeExpression("int"), new VariableDeclaratorExpression[] { doc.CreateVariableDeclaratorExpression("a") });
            this.document.CreateVariableDeclarationStatement(expression, true);
        }

        #endregion VariableDeclarationExpression

        #region WhileStatement

        [TestMethod]
        public void CsCreateWhileStatementTest()
        {
            // public static WhileStatement CreateWhileStatement(this CsDocument document, Expression condition, Expression body)
            {
                var condition = this.document.CreateLiteralExpression("true");
                var body = this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y"));
                var statement = this.document.CreateWhileStatement(condition, body);
                this.TestStatement(statement, StatementType.While, 7, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body.FindFirstChildExpression(), body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static WhileStatement CreateWhileStatement(this CsDocument document, Expression condition, Statement body)
            {
                var condition = this.document.CreateLiteralExpression("true");
                var body = this.document.CreateExpressionStatement(this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y")));
                var statement = this.document.CreateWhileStatement(condition, body);
                this.TestStatement(statement, StatementType.While, 7, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static WhileStatement CreateWhileStatement(this CsDocument document, Expression condition, Statement body)
            {
                var condition = this.document.CreateLiteralExpression("true");
                var body = this.document.CreateBlockStatement();
                var statement = this.document.CreateWhileStatement(condition, body);
                this.TestStatement(statement, StatementType.While, 7, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static WhileStatement CreateWhileStatement(this CsDocument document, Expression condition, Statement body)
            {
                var condition = this.document.CreateLiteralExpression("true");
                var body = this.document.CreateBlockStatement(new Statement[] { this.document.CreateExpressionStatement(this.document.CreateMethodInvocationExpression(this.document.CreateLiteralExpression("SomeMethod"))) });
                var statement = this.document.CreateWhileStatement(condition, body);
                this.TestStatement(statement, StatementType.While, 7, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }

            // public static WhileStatement CreateWhileStatement(this CsDocument document, Expression condition, Statement body)
            {
                var condition = this.document.CreateEqualToExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y"));
                var body = this.document.CreateExpressionStatement(this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("y")));
                var statement = this.document.CreateWhileStatement(condition, body);
                this.TestStatement(statement, StatementType.While, 7, 0);
                Assert.AreEqual(statement.Condition, condition);
                Assert.AreEqual(statement.Body, body);
                Assert.AreEqual(statement.AttachedStatements.Count, 0);
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateWhileStatementWithNullCondition()
        {
            this.document.CreateWhileStatement(null, this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateWhileStatementWithNullBody1()
        {
            this.document.CreateWhileStatement(this.document.CreateLiteralExpression("true"), (Statement)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateWhileStatementWithNullBody2()
        {
            this.document.CreateWhileStatement(this.document.CreateLiteralExpression("true"), (Expression)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateWhileStatementWithNulls1()
        {
            this.document.CreateWhileStatement(null, (Statement)null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CsCreateWhileStatementWithNulls2()
        {
            this.document.CreateWhileStatement(null, (Expression)null);
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateWhileStatementWithWrongDoc1()
        {
            var doc = this.CreateDocument();
            this.document.CreateWhileStatement(doc.CreateLiteralExpression("true"), this.document.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateWhileStatementWithWrongDoc2()
        {
            var doc = this.CreateDocument();
            this.document.CreateWhileStatement(this.document.CreateLiteralExpression("true"), doc.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateWhileStatementWithWrongDoc3()
        {
            var doc = this.CreateDocument();
            this.document.CreateWhileStatement(doc.CreateLiteralExpression("true"), doc.CreateBlockStatement());
        }

        [TestMethod, ExpectedException(typeof(CodeModelException))]
        public void CsCreateWhileStatementWithWrongDoc4()
        {
            var doc = this.CreateDocument();
            this.document.CreateWhileStatement(doc.CreateLiteralExpression("true"), doc.CreateEqualsExpression(doc.CreateLiteralExpression("x"), doc.CreateLiteralExpression("y")));
        }

        #endregion WhileStatement

        #endregion Statements

        #region Helper Methods

        private CsDocument CreateDocument()
        {
            CsLanguageService s = new CsLanguageService();
            return s.CreateCodeModel("namespace n { }", "temp", "temp");
        }

        private void TestArgument(Expression argumentExpression, ParameterModifiers modifiers = ParameterModifiers.None)
        {
            Argument argument = this.document.CreateArgument(argumentExpression, modifiers);

            if (modifiers == ParameterModifiers.Ref || modifiers == ParameterModifiers.Out || modifiers == ParameterModifiers.In)
            {
                Assert.AreEqual(argument.Children.Count, 3);
            }
            else if (modifiers == (ParameterModifiers.In | ParameterModifiers.Out))
            {
                Assert.AreEqual(argument.Children.Count, 5);
            }
            else
            {
                Assert.AreEqual(argument.Children.Count, 1);
            }

            Assert.AreEqual(argument.CodeUnitType, CodeUnitType.Argument);
            Assert.AreEqual(argument.Document, this.document);
            Assert.AreEqual(argument.Expression, argumentExpression);
            Assert.AreEqual(argument.Modifiers, modifiers);
            Assert.AreEqual(argument.Variables.Count, 0);
        }

        private void TestArgumentList()
        {
            ArgumentList list = this.document.CreateArgumentList();
            Assert.AreEqual(list.Arguments.Count, 0);
            Assert.AreEqual(list.Children.Count, 2); // ex: ()
            Assert.AreEqual(list.CodeUnitType, CodeUnitType.ArgumentList);
            Assert.AreEqual(list.Document, this.document);
        }

        private void TestArgumentList(ICollection<Argument> arguments)
        {
            ArgumentList list = this.document.CreateArgumentList(arguments);
            Assert.AreEqual(list.Arguments.Count, arguments.Count);
            Assert.AreEqual(list.Children.Count, arguments.Count + 2 + Math.Max(0, ((arguments.Count - 1) * 2))); // ex: (x, y, z)
            Assert.AreEqual(list.CodeUnitType, CodeUnitType.ArgumentList);
            Assert.AreEqual(list.Document, this.document);

            int i = 0;
            foreach (Argument argument in arguments)
            {
                Assert.AreEqual(list.Arguments[i], argument);
                ++i;
            }
        }

        private void TestSimpleToken(Token token, TokenType tokenType, string text)
        {
            Assert.AreEqual(token.Children.Count, 0);
            Assert.AreEqual(token.CodeUnitType, CodeUnitType.LexicalElement);
            Assert.AreEqual(token.Document, this.document);
            Assert.AreEqual(token.Generated, false);
            Assert.AreEqual(token.IsComplexToken, false);
            Assert.AreEqual(token.LexicalElementType, LexicalElementType.Token);
            Assert.AreEqual(token.Text, text);
            Assert.AreEqual(token.TokenType, tokenType);
            Assert.AreEqual(token.Variables.Count, 0);
        }

        private void TestOperator(OperatorSymbolToken op, OperatorType operatorType, string text)
        {
            Assert.AreEqual(op.Children.Count, 0);
            Assert.AreEqual(op.CodeUnitType, CodeUnitType.LexicalElement);
            Assert.AreEqual(op.Document, this.document);
            Assert.AreEqual(op.Generated, false);
            Assert.AreEqual(op.IsComplexToken, false);
            Assert.AreEqual(op.LexicalElementType, LexicalElementType.Token);
            Assert.AreEqual(op.SymbolType, operatorType);
            Assert.AreEqual(op.Text, text);
            Assert.AreEqual(op.TokenType, TokenType.OperatorSymbol);
            Assert.AreEqual(op.Variables.Count, 0);
        }

        private void TestElementHeaderLine(string text)
        {
            ElementHeaderLine comment = this.document.CreateElementHeaderLine(text);
            Assert.AreEqual(comment.Children.Count, 0);
            Assert.AreEqual(comment.CodeUnitType, CodeUnitType.LexicalElement);
            Assert.AreEqual(comment.CommentType, CommentType.ElementHeaderLine);
            Assert.AreEqual(comment.Document, this.document);
            Assert.AreEqual(comment.Generated, false);
            Assert.AreEqual(comment.LexicalElementType, LexicalElementType.Comment);
            Assert.AreEqual(comment.Text, text);
            Assert.AreEqual(comment.Variables.Count, 0);
        }

        private void TestSingleLineComment(string text)
        {
            SingleLineComment comment = this.document.CreateSingleLineComment(text);
            Assert.AreEqual(comment.Children.Count, 0);
            Assert.AreEqual(comment.CodeUnitType, CodeUnitType.LexicalElement);
            Assert.AreEqual(comment.CommentType, CommentType.SingleLineComment);
            Assert.AreEqual(comment.Document, this.document);
            Assert.AreEqual(comment.Generated, false);
            Assert.AreEqual(comment.LexicalElementType, LexicalElementType.Comment);
            Assert.AreEqual(comment.Text, text);
            Assert.AreEqual(comment.Variables.Count, 0);
        }

        private void TestMultlineComment(string text)
        {
            MultilineComment comment = this.document.CreateMultilineComment(text);
            Assert.AreEqual(comment.Children.Count, 0);
            Assert.AreEqual(comment.CodeUnitType, CodeUnitType.LexicalElement);
            Assert.AreEqual(comment.CommentType, CommentType.MultilineComment);
            Assert.AreEqual(comment.Document, this.document);
            Assert.AreEqual(comment.Generated, false);
            Assert.AreEqual(comment.LexicalElementType, LexicalElementType.Comment);
            Assert.AreEqual(comment.Text, text);
            Assert.AreEqual(comment.Variables.Count, 0);
        }

        private void TestWhitespace(Whitespace spaces, string text, int spacecount, int tabcount)
        {
            Assert.AreEqual(spaces.Children.Count, 0);
            Assert.AreEqual(spaces.CodeUnitType, CodeUnitType.LexicalElement);
            Assert.AreEqual(spaces.Document, this.document);
            Assert.AreEqual(spaces.Generated, false);
            Assert.AreEqual(spaces.LexicalElementType, LexicalElementType.WhiteSpace);
            Assert.AreEqual(spaces.SpaceCount, spacecount);
            Assert.AreEqual(spaces.TabCount, tabcount);
            Assert.AreEqual(spaces.Text, text);
            Assert.AreEqual(spaces.Variables.Count, 0);
        }

        private void TestFileHeader(int headerLineCount, string headerXml, params SingleLineComment[] elements)
        {
            FileHeader header = this.document.CreateFileHeader(elements);
            Assert.AreEqual(header.Children.Count, (elements.Length * 2) - 1); // Add the newlines.
            Assert.AreEqual(header.CodeUnitType, CodeUnitType.FileHeader);
            Assert.AreEqual(header.Document, this.document);
            //Assert.AreEqual(header.FormattedHeaderXml, "") todo
            Assert.AreEqual(header.Generated, false);
            Assert.AreEqual(header.HeaderLines.Count, headerLineCount);
            //Assert.AreEqual(header.HeaderXml, headerXml); todo
            Assert.AreEqual(header.IsEmpty, false);
            Assert.AreEqual(header.Variables.Count, 0);
        }

        private void TestElementHeader(int headerLineCount, string headerXml, params ElementHeaderLine[] lines)
        {
            ElementHeader header = this.document.CreateElementHeader(lines);
            Assert.AreEqual(header.Children.Count, (lines.Length * 2) - 1); // Add the newlines.
            Assert.AreEqual(header.CodeUnitType, CodeUnitType.ElementHeader);
            Assert.AreEqual(header.Document, this.document);
            //Assert.AreEqual(header.FormattedHeaderXml, "") todo
            Assert.AreEqual(header.Generated, false);
            Assert.AreEqual(header.HeaderLines.Count, headerLineCount);
            //Assert.AreEqual(header.HeaderXml, headerXml); todo
            Assert.AreEqual(header.IsEmpty, false);
            Assert.AreEqual(header.Variables.Count, 0);
        }

        private void TestAsExpression(Expression value, LiteralExpression type)
        {
            AsExpression expression = document.CreateAsExpression(value, type);
            this.TestExpression(expression, ExpressionType.As, 5, 0);
            Assert.AreEqual(expression.Value, value);
            Assert.AreEqual(expression.Type, type.Token);
        }

        private void TestCastExpression(LiteralExpression type, Expression castedExpression)
        {
            CastExpression expression = document.CreateCastExpression(type, castedExpression);
            this.TestExpression(expression, ExpressionType.Cast, 4, 0);
            Assert.AreEqual(expression.CastedExpression, castedExpression);
            Assert.AreEqual(expression.Type, type.Token);
        }

        private void TestCheckedExpression(Expression internalExpression)
        {
            CheckedExpression expression = document.CreateCheckedExpression(internalExpression);
            this.TestExpression(expression, ExpressionType.Checked, 4, 0);
            Assert.AreEqual(expression.InternalExpression, internalExpression);
        }

        private void TestConditionalExpression(Expression condition, Expression trueValue, Expression falseValue)
        {
            ConditionalExpression expression = document.CreateConditionalExpression(condition, trueValue, falseValue);
            this.TestExpression(expression, ExpressionType.Conditional, 9, 0);
            Assert.AreEqual(expression.Condition, condition);
            Assert.AreEqual(expression.TrueExpression, trueValue);
            Assert.AreEqual(expression.FalseExpression, falseValue);
        }

        private void TestDefaultValueExpression(LiteralExpression type)
        {
            DefaultValueExpression expression = document.CreateDefaultValueExpression(type);
            this.TestExpression(expression, ExpressionType.DefaultValue, 4, 0);
            Assert.AreEqual(expression.Type, type.Token);
        }

        private void TestIsExpression(Expression value, LiteralExpression type)
        {
            IsExpression expression = document.CreateIsExpression(value, type);
            this.TestExpression(expression, ExpressionType.Is, 5, 0);
            Assert.AreEqual(expression.Value, value);
            Assert.AreEqual(expression.Type, type.Token);
        }

        private void TestMemberAccessExpression(Expression leftHandSide, string rightHandSide)
        {
            ChildAccessExpression expression = document.CreateMemberAccessExpression(leftHandSide, rightHandSide);
            this.TestExpression(expression, ExpressionType.MemberAccess, 3, 0);
            Assert.AreEqual(expression.LeftHandSide, leftHandSide);
            Assert.AreEqual(expression.RightHandSide.Text, rightHandSide);
        }

        private void TestMemberAccessExpression(Expression leftHandSide, LiteralExpression rightHandSide)
        {
            ChildAccessExpression expression = document.CreateMemberAccessExpression(leftHandSide, rightHandSide);
            this.TestExpression(expression, ExpressionType.MemberAccess, 3, 0);
            Assert.AreEqual(expression.LeftHandSide, leftHandSide);
            Assert.AreEqual(expression.RightHandSide, rightHandSide);
        }

        private void TestMethodInvocationExpression(Expression name)
        {
            MethodInvocationExpression expression = document.CreateMethodInvocationExpression(name);
            this.TestExpression(expression, ExpressionType.MethodInvocation, 2, 0);
            Assert.IsNotNull(expression.ArgumentList);
            Assert.AreEqual(expression.ArgumentList.Arguments.Count, 0);
            Assert.AreEqual(expression.Name, name);
        }

        private void TestMethodInvocationExpression(Expression name, ArgumentList argumentList)
        {
            MethodInvocationExpression expression = document.CreateMethodInvocationExpression(name, argumentList);
            this.TestExpression(expression, ExpressionType.MethodInvocation, 2, 0);

            if (argumentList == null)
            {
                Assert.IsNotNull(expression.ArgumentList);
                Assert.AreEqual(expression.ArgumentList.Arguments.Count, 0);
            }
            else
            {
                Assert.AreEqual(expression.ArgumentList, argumentList);
            }

            Assert.AreEqual(expression.Name, name);
        }

        private void TestMethodInvocationExpression(Expression name, ICollection<Argument> arguments)
        {
            MethodInvocationExpression expression = document.CreateMethodInvocationExpression(name, arguments);
            this.TestExpression(expression, ExpressionType.MethodInvocation, 2, 0);

            if (arguments == null)
            {
                Assert.IsNotNull(expression.ArgumentList);
                Assert.AreEqual(expression.ArgumentList.Arguments.Count, 0);
            }
            else
            {
                Assert.AreEqual(expression.ArgumentList.Count, arguments.Count);

                int i = 0;
                foreach (Argument argument in arguments)
                {
                    Assert.AreEqual(expression.ArgumentList[i], argument);
                    ++i;
                }
            }

            Assert.AreEqual(expression.Name, name);
        }

        private void TestNullCoalescingExpression(Expression left, Expression right)
        {
            NullCoalescingExpression expression = document.CreateNullCoalescingExpression(left, right);
            this.TestExpression(expression, ExpressionType.NullCoalescing, 5, 0);
            Assert.AreEqual(expression.LeftHandSide, left);
            Assert.AreEqual(expression.RightHandSide, right);
        }

        private void TestObjectInitializerExpression(ICollection<EqualsExpression> initializers)
        {
            ObjectInitializerExpression expression = document.CreateObjectInitializerExpression(initializers);
            this.TestExpression(expression, ExpressionType.ObjectInitializer, 2 + 1 + (initializers.Count * 2) + Math.Max(0, initializers.Count - 1), 0); // ex: { X = 1, Y = 2, Z = 3 }
            Assert.AreEqual(expression.Initializers.Count, initializers.Count);

            List<AssignmentExpression> collection = new List<AssignmentExpression>(expression.Initializers);
            int i = 0;
            foreach (AssignmentExpression init in initializers)
            {
                Assert.AreEqual(init, collection[i]);
                ++i;
            }
        }
        
        private void TestParenthesizedExpression(Expression innerExpression)
        {
            ParenthesizedExpression expression = document.CreateParenthesizedExpression(innerExpression);
            this.TestExpression(expression, ExpressionType.Parenthesized, 3, 0);
            Assert.AreEqual(expression.InnerExpression, innerExpression);
        }

        private void TestPointerAccessExpression(Expression leftHandSide, string rightHandSide)
        {
            ChildAccessExpression expression = document.CreatePointerAccessExpression(leftHandSide, rightHandSide);
            this.TestExpression(expression, ExpressionType.PointerAccess, 3, 0);
            Assert.AreEqual(expression.LeftHandSide, leftHandSide);
            Assert.AreEqual(expression.RightHandSide.Text, rightHandSide);
        }

        private void TestPointerAccessExpression(Expression leftHandSide, LiteralExpression rightHandSide)
        {
            ChildAccessExpression expression = document.CreatePointerAccessExpression(leftHandSide, rightHandSide);
            this.TestExpression(expression, ExpressionType.PointerAccess, 3, 0);
            Assert.AreEqual(expression.LeftHandSide, leftHandSide);
            Assert.AreEqual(expression.RightHandSide, rightHandSide);
        }

        private void TestQualifiedAliasExpression(Expression leftHandSide, string rightHandSide)
        {
            ChildAccessExpression expression = document.CreateQualifiedAliasExpression(leftHandSide, rightHandSide);
            this.TestExpression(expression, ExpressionType.QualifiedAlias, 3, 0);
            Assert.AreEqual(expression.LeftHandSide, leftHandSide);
            Assert.AreEqual(expression.RightHandSide.Text, rightHandSide);
        }

        private void TestQualifiedAliasExpression(Expression leftHandSide, LiteralExpression rightHandSide)
        {
            ChildAccessExpression expression = document.CreateQualifiedAliasExpression(leftHandSide, rightHandSide);
            this.TestExpression(expression, ExpressionType.QualifiedAlias, 3, 0);
            Assert.AreEqual(expression.LeftHandSide, leftHandSide);
            Assert.AreEqual(expression.RightHandSide, rightHandSide);
        }

        private void TestSizeofExpression(Expression type)
        {
            SizeofExpression expression = document.CreateSizeofExpression(type);
            this.TestExpression(expression, ExpressionType.Sizeof, 4, 0);
            Assert.AreEqual(expression.Type, type);
        }

        private void TestTypeofExpression(LiteralExpression type)
        {
            TypeofExpression expression = document.CreateTypeofExpression(type);
            this.TestExpression(expression, ExpressionType.Typeof, 4, 0);
            Assert.AreEqual(expression.Type, type.Token);
        }

        private void TestUncheckedExpression(Expression internalExpression)
        {
            UncheckedExpression expression = document.CreateUncheckedExpression(internalExpression);
            this.TestExpression(expression, ExpressionType.Unchecked, 4, 0);
            Assert.AreEqual(expression.InternalExpression, internalExpression);
        }

        private void TestVariableDeclaratorExpression(LiteralExpression identifier, Expression initializer = null)
        {
            VariableDeclaratorExpression expression = document.CreateVariableDeclaratorExpression(identifier, initializer);
            this.TestExpression(expression, ExpressionType.VariableDeclarator, 1 + (initializer == null ? 0 : 4), 0);
            Assert.AreEqual(expression.Identifier, identifier);
            Assert.AreEqual(expression.Initializer, initializer);
            Assert.AreEqual(expression.VariableModifiers, VariableModifiers.None);
            Assert.AreEqual(expression.VariableName, identifier.Text);
            Assert.AreEqual(expression.VariableType, null);
        }

        private void TestVariableDeclaratorExpression(string identifier, Expression initializer = null)
        {
            VariableDeclaratorExpression expression = document.CreateVariableDeclaratorExpression(identifier, initializer);
            this.TestExpression(expression, ExpressionType.VariableDeclarator, 1 + (initializer == null ? 0 : 4), 0);
            Assert.AreEqual(expression.Identifier.Text, identifier);
            Assert.AreEqual(expression.Initializer, initializer);
            Assert.AreEqual(expression.VariableModifiers, VariableModifiers.None);
            Assert.AreEqual(expression.VariableName, identifier);
            Assert.AreEqual(expression.VariableType, null);
        }

        private void TestVariableDeclarationExpression(ICollection<VariableDeclaratorExpression> declarators, VariableDeclarationExpression expression)
        {
            // The item count for "int x, y, z" is equal to:
            // 2 for "int "
            // 3 "xyz"
            // 4 for ", , "
            this.TestExpression(expression, ExpressionType.VariableDeclaration, 2 + declarators.Count + ((declarators.Count - 1) * 2), declarators.Count);
            Assert.AreEqual(expression.Declarators.Count, declarators.Count);

            List<VariableDeclaratorExpression> d = new List<VariableDeclaratorExpression>(declarators);
            List<IVariable> v = new List<IVariable>(expression.Variables);

            d.Sort((v1, v2) => { return string.Compare(v1.VariableName, v2.VariableName); });
            v.Sort((v1, v2) => { return string.Compare(v1.VariableName, v2.VariableName); });

            Assert.AreEqual(d.Count, v.Count);

            for (int i = 0; i < d.Count; ++i)
            {
                Assert.AreEqual(d[i], v[i]);
            }
        }

        private void TestExpression(Expression expression, ExpressionType type, int childCount, int variableCount)
        {
            Assert.AreEqual(expression.Children.Count, childCount);
            Assert.AreEqual(expression.CodeUnitType, CodeUnitType.Expression);
            Assert.AreEqual(expression.Document, this.document);
            Assert.AreEqual(expression.ExpressionType, type);
            Assert.AreEqual(expression.Generated, false);
            Assert.AreEqual(expression.Variables.Count, variableCount);
        }

        private delegate void CreateItem<T>(T child);

        private void TestValidExpressionType(ExpressionType[] validTypes, CreateItem<Expression> createItem)
        {
            foreach (ExpressionType x in System.Enum.GetValues(typeof(ExpressionType)))
            {
                if (!ContainsType<ExpressionType>(x, validTypes))
                {
                    bool thrownOrNull = false;

                    try
                    {
                        Expression e = this.CreateExpressionOfType(x);
                        if (e == null)
                        {
                            thrownOrNull = true;
                        }
                        else
                        {
                            createItem.Invoke(e);
                        }
                    }
                    catch (CodeModelException)
                    {
                        thrownOrNull = true;
                    }

                    Assert.IsTrue(thrownOrNull, "Failed to throw exception on disallowed type.");
                }
            }
        }

        private Expression CreateExpressionOfType(ExpressionType type)
        {
            switch (type)
            {
                case ExpressionType.AnonymousMethod:
                    return null;
                case ExpressionType.Arithmetic:
                    return this.document.CreateMultiplicationExpression(this.document.CreateLiteralExpression("1"), this.document.CreateLiteralExpression("2"));
                case ExpressionType.ArrayAccess:
                    return null;
                case ExpressionType.ArrayInitializer:
                    return null;
                case ExpressionType.As:
                    return this.document.CreateAsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralTypeExpression("object"));
                case ExpressionType.Assignment:
                    return this.document.CreateEqualsExpression(this.document.CreateLiteralExpression("x"), this.document.CreateLiteralExpression("2"));
                case ExpressionType.Attribute:
                    return null;
                case ExpressionType.Cast:
                    return this.document.CreateCastExpression(this.document.CreateLiteralTypeExpression("object"), this.document.CreateLiteralExpression("x"));
                case ExpressionType.Checked:
                    return this.document.CreateCheckedExpression(this.document.CreateLiteralExpression("a"));
                case ExpressionType.CollectionInitializer:
                    return null;
                case ExpressionType.Conditional:
                    return this.document.CreateConditionalExpression(this.document.CreateLiteralExpression("true"), this.document.CreateLiteralExpression("a"), this.document.CreateLiteralExpression("b"));
                case ExpressionType.ConditionalLogical:
                    return this.document.CreateConditionalAndExpression(this.document.CreateLiteralExpression("a"), this.document.CreateLiteralExpression("b"));
                case ExpressionType.Decrement:
                    return this.document.CreatePostfixDecrementExpression(this.document.CreateLiteralExpression("a"));
                case ExpressionType.DefaultValue:
                    return this.document.CreateDefaultValueExpression(this.document.CreateLiteralExpression("bool"));
                case ExpressionType.EventDeclarator:
                    return null;
                case ExpressionType.Increment:
                    return this.document.CreatePrefixIncrementExpression(this.document.CreateLiteralExpression("b"));
                case ExpressionType.Is:
                    return this.document.CreateIsExpression(this.document.CreateLiteralExpression("a"), this.document.CreateLiteralTypeExpression("object"));
                case ExpressionType.Lambda:
                    return null;
                case ExpressionType.Literal:
                    return this.document.CreateLiteralExpression("a");
                case ExpressionType.Logical:
                    return this.document.CreateLogicalXorExpression(this.document.CreateLiteralExpression("a"), this.document.CreateLiteralExpression("b"));
                case ExpressionType.MemberAccess:
                    return this.document.CreateMemberAccessExpression(this.document.CreateLiteralExpression("a"), "b");
                case ExpressionType.MethodInvocation:
                    return null;
                case ExpressionType.New:
                    return null;
                case ExpressionType.NewArray:
                    return null;
                case ExpressionType.None:
                    return null;
                case ExpressionType.NullCoalescing:
                    return this.document.CreateNullCoalescingExpression(this.document.CreateLiteralExpression("a"), this.document.CreateLiteralExpression("b"));
                case ExpressionType.ObjectInitializer:
                    return null;
                case ExpressionType.Parenthesized:
                    return this.document.CreateParenthesizedExpression(this.document.CreateLiteralExpression("x"));
                case ExpressionType.Query:
                    return null;
                case ExpressionType.Relational:
                    return this.document.CreateGreaterThanExpression(this.document.CreateLiteralExpression("a"), this.document.CreateLiteralExpression("b"));
                case ExpressionType.Sizeof:
                    return this.document.CreateSizeofExpression(this.document.CreateLiteralTypeExpression("object"));
                case ExpressionType.Stackalloc:
                    return null;
                case ExpressionType.Typeof:
                    return this.document.CreateTypeofExpression(this.document.CreateLiteralExpression("x"));
                case ExpressionType.Unary:
                    return this.document.CreateNotExpression(this.document.CreateLiteralExpression("x"));
                case ExpressionType.Unchecked:
                    return this.document.CreateUncheckedExpression(this.document.CreateLiteralExpression("a"));
                case ExpressionType.UnsafeAccess:
                    return this.document.CreateDereferenceExpression(this.document.CreateLiteralExpression("x"));
                case ExpressionType.VariableDeclaration:
                    return null;
                case ExpressionType.VariableDeclarator:
                    return null;
                default:
                    Assert.Fail("Unhandled expression type");
                    return null;
            }
        }

        private bool ContainsType<T>(T type, T[] types)
        {
            for (int i = 0; i < types.Length; ++i)
            {
                if (types[i].Equals(type))
                {
                    return true;
                }
            }

            return false;
        }

        private void TestStatement(Statement statement, StatementType type, int childCount, int variableCount)
        {
            Assert.AreEqual(statement.Children.Count, childCount);
            Assert.AreEqual(statement.CodeUnitType, CodeUnitType.Statement);
            Assert.AreEqual(statement.Document, this.document);
            Assert.AreEqual(statement.Generated, false);
            Assert.AreEqual(statement.StatementType, type);
            Assert.AreEqual(statement.Variables.Count, variableCount);
        }

        #endregion Helper Methods
    }
}
