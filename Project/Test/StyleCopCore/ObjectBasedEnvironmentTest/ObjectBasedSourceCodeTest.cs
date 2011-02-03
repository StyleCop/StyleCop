using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop;

namespace StreamBasedEnvironmentTest
{
    [TestClass]
    public class ObjectBasedSourceCodeTest
    {
        [TestMethod]
        public void TestObjectBasedSourceCodeWithNoSettings()
        {
            ObjectBasedEnvironment environment = new ObjectBasedEnvironment(this.SourceCodeFactory, this.ProjectSettingsFactory);

            using (StyleCopObjectConsole styleCop = new StyleCopObjectConsole(environment, null, new string[] { "%projectroot%\\test\\testbin" }, false))
            {
                // Create the configuration.
                Configuration configuration = new Configuration(null);

                // Create a CodeProject.
                CodeProject project = new CodeProject(0, null, configuration);
                styleCop.Core.Environment.AddSourceCode(project, "source1.cs", 0);
                styleCop.Core.Environment.AddSourceCode(project, "source2.cs", 1);
                styleCop.Core.Environment.AddSourceCode(project, "source3.cs", 2);

                styleCop.Start(new CodeProject[] { project });
            }
        }

        /// <summary>
        /// Retrieves a <see cref="SourceCode" /> object corresponding to the given path.
        /// </summary>
        /// <param name="path">The path to the source code object.</param>
        /// <param name="project">The project which contains the source code object.</param>
        /// <param name="parser">The parser for the source code type.</param>
        /// <param name="context">Optional context.</param>
        /// <returns>Returns the source code object.</returns>
        private SourceCode SourceCodeFactory(string path, CodeProject project, SourceParser parser, object context)
        {
            Param.Ignore(path, project, parser, context);

            int index = (int)context;
            Assert.IsTrue(index >= 0 && index < StaticSource.Sources.Length, "The index is out of range.");

            return new ObjectBasedSourceCode(project, parser, index);
        }

        /// <summary>
        /// Retrieves a <see cref="Settings" /> object corresponding to a given project path.
        /// </summary>
        /// <param name="path">The path to the project.</param>
        /// <param name="readOnly">Indicates whether to return a <see cref="Settings" /> object or a <see cref="WritableSettings" /> object.</param>
        /// <returns>Returns the settings object.</returns>
        private Settings ProjectSettingsFactory(string path, bool readOnly)
        {
            return null;
        }
    }
}
