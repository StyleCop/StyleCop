using StyleCop.CSharp.CodeModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace StyleCop.CSharpParserTest
{
    
    
    /// <summary>
    ///This is a test class for CodeParserTest and is intended
    ///to contain all CodeParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CodeParserTest
    {
        private static readonly PreprocessorDefinition[] preprocessorDefinitions = new PreprocessorDefinition[]
        {
            new PreprocessorDefinition("DEBUG", null)
        };

        private static TestContext TestContext;

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestContext = testContext;
        }

        [TestMethod]
        public void CsReadAndWriteFiles()
        {
            string projectRoot = Environment.ExpandEnvironmentVariables("%projectroot%");
            this.ReadAndWriteFilesInDirectory(projectRoot);
        }

        private void ReadAndWriteFilesInDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (string file in Directory.GetFiles(path, "*.cs"))
                {
                    this.ReadAndWriteFile(file);
                }

                foreach (string childDirectory in Directory.GetDirectories(path))
                {
                    this.ReadAndWriteFilesInDirectory(childDirectory);
                }
            }
        }

        private void ReadAndWriteFile(string filePath)
        {
            Console.WriteLine("Checking file " + filePath);

            if (File.Exists(filePath))
            {
                string fileContents = null;

                try
                {
                    fileContents = File.ReadAllText(filePath);
                }
                catch (IOException)
                {
                }

                CsLanguageService languageService = new CsLanguageService(preprocessorDefinitions);
                CsDocument doc = null;

                try
                {
                    doc = languageService.CreateCodeModel(fileContents, Path.GetFileName(filePath), filePath);
                }
                catch (SyntaxException)
                {
                }
                catch (Exception ex)
                {
                    Assert.Fail("Exception from CodeModel: " + ex.GetType() + ", " + ex.Message + ". FilePath=" + filePath);
                }

                if (doc != null)
                {
                    using (StringWriter writer = new StringWriter())
                    {
                        doc.Write(writer);

                        this.CompareDocs(fileContents, writer.ToString(), filePath);
                    }
                }
            }
        }

        private void CompareDocs(string original, string written, string filePath)
        {
            if (original.Length < written.Length)
            {
                this.WriteFiles(original, written);
                Assert.Fail("File lengths do not match. Original=" + original.Length + ", New=" + written.Length + ". FilePath=" + filePath);
            }
            else
            {
                int originalOffset = 0;

                for (int i = 0; i < original.Length; ++i)
                {
                    if (i >= original.Length || i >= written.Length + originalOffset)
                    {
                        this.WriteFiles(original, written);
                        Assert.Fail("File lengths do not match. Original=" + original.Length + ", New=" + written.Length + ". FilePath=" + filePath);
                    }

                    if (original[i] != written[i - originalOffset])
                    {
                        if (original[i] == '\r' &&
                            (written[i - originalOffset] == '\n' && i < original.Length - 1 && original[i + 1] == '\n'))
                        {
                            ++originalOffset;
                        }
                        else
                        {
                            this.WriteFiles(original, written);
                            Assert.Fail("Character at index " + i + "does not match. Original=" + original[i] + ", New=" + written[i - originalOffset] + ". FilePath=" + filePath);
                        }
                    }
                }
            }
        }

        private void WriteFiles(string original, string written)
        {
            if (!Directory.Exists(TestContext.TestResultsDirectory))
            {
                Directory.CreateDirectory(TestContext.TestResultsDirectory);
            }

            if (original != null)
            {
                File.WriteAllText(Path.Combine(TestContext.TestResultsDirectory, "Original.cs"), original);
            }

            if (written != null)
            {
                File.WriteAllText(Path.Combine(TestContext.TestResultsDirectory, "New.cs"), written);
            }
        }
    }
}
