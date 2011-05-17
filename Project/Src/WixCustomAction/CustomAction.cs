
using Microsoft.Deployment.WindowsInstaller;

namespace WixCustomAction
{
    using System.Diagnostics;
    using System.IO;

    public class CustomActions
    {
        private static Session staticSession;

        [CustomAction]
        public static ActionResult RestoreVisualStudioTemplateFiles(Session session)
        {
            staticSession = session;
            staticSession.Log("Begin RestoreVisualStudioTemplateFiles");

            string visualStudio10DevEnvPath = staticSession["VS2010DEVENV"];
            staticSession.Log("VS2010DEVENV is '{0}'", visualStudio10DevEnvPath);

            if (string.IsNullOrEmpty(visualStudio10DevEnvPath))
            {
                return ActionResult.Success;
            }

            var ideFolderPath = Path.GetDirectoryName(visualStudio10DevEnvPath);

            if (string.IsNullOrEmpty(ideFolderPath))
            {
                return ActionResult.Success;
            }

            // only do this if:
            // we're VS10            - this is checked by the custome action code that calls us
            // we're uninstalling    - this is checked by the custome action code that calls us
            //rename the .bak files and run devenv /setup again

            var itemTemplatesPath = Path.Combine(ideFolderPath, "ItemTemplates");
            var result = ProcessFolderForRenamingFiles(itemTemplatesPath);

            var projectTemplatesPath = Path.Combine(ideFolderPath, "ProjectTemplates");
            result |= ProcessFolderForRenamingFiles(projectTemplatesPath);

            if (result)
            {   //Files were renamed so call devenv /setup
                var process = new Process();

                process.StartInfo.FileName = visualStudio10DevEnvPath;
                process.StartInfo.Arguments = "/InstallVSTemplates";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;

                process.Start();

                //give it 60 secs to reconfigure VS.
                process.WaitForExit(60000);
            }

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult BackupVisualStudioTemplateFiles(Session session)
        {
            staticSession = session;
            staticSession.Log("Begin BackupVisualStudioTemplateFiles");

            string visualStudio10DevEnvPath = staticSession["VS2010DEVENV"];
            staticSession.Log("VS2010DEVENV is '{0}'", visualStudio10DevEnvPath);

            if (string.IsNullOrEmpty(visualStudio10DevEnvPath))
            {
                return ActionResult.Success;
            }

            var ideFolderPath = Path.GetDirectoryName(visualStudio10DevEnvPath);

            if (string.IsNullOrEmpty(ideFolderPath))
            {
                return ActionResult.Success;
            }

            //copy all the .zip files as zip.bak files
            var itemTemplatesPath = Path.Combine(ideFolderPath, "ItemTemplates");
            ProcessFolderForCopyingFiles(itemTemplatesPath);

            var projectTemplatesPath = Path.Combine(ideFolderPath, "ProjectTemplates");
            ProcessFolderForCopyingFiles(projectTemplatesPath);
            
            return ActionResult.Success;
        }

        private static void ProcessFolderForCopyingFiles(string path)
        {
            staticSession.Log("Processing folder copying files in {0}", path);
            path = System.Environment.ExpandEnvironmentVariables(path);

            
            if (File.Exists(path) || !Directory.Exists(path))
            {
                // if the path passed in exists as a file then return.
                // If it doesn't exist as a folder then return.
                return;
            }

            var directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                ProcessFolderForCopyingFiles(directory);
            }

            var files = Directory.GetFiles(path, "*.zip", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                staticSession.Log("Creating a backup of {0}", file);

                var directoryName = Path.GetDirectoryName(file);
                var destFileName = Path.Combine(directoryName, Path.GetFileName(file) + ".bak");
                if (!File.Exists(destFileName))
                {
                    // If the filename we'd like to use already exists don't create backup.
                    staticSession.Log("Backup '{0}' to '{1}", file, destFileName);
                    File.Copy(file, destFileName);
                }
            }

            return;
        }

        private static bool ProcessFolderForRenamingFiles(string path)
        {
            staticSession.Log("Processing folder {0}", path);
            path = System.Environment.ExpandEnvironmentVariables(path);

            bool filesRenamed = false;

            if (File.Exists(path) || !Directory.Exists(path))
            {
                // if the path passed in exists as a file then return.
                // If it doesn't exist as a folder then return.
                return filesRenamed;
            }

            var directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                filesRenamed |= ProcessFolderForRenamingFiles(directory);
            }

            var files = Directory.GetFiles(path, "*.zip.bak", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                staticSession.Log("Processing file {0}", file);

                var directoryName = Path.GetDirectoryName(file);
                var destFileName = Path.Combine(directoryName, Path.GetFileNameWithoutExtension(file));
                if (!File.Exists(destFileName))
                {
                    // If the filename we'd like to use already exists don't change it.
                    staticSession.Log("Renaming '{0}' to '{1}", file, destFileName);
                    File.Move(file, destFileName);
                    filesRenamed = true;
                }
            }

            return filesRenamed;
        }
    }
}
