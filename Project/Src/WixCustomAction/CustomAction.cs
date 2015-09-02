
using Microsoft.Deployment.WindowsInstaller;

namespace WixCustomAction
{
    using System.Diagnostics;
    using System.IO;

    using Microsoft.Win32;

    public class CustomActions
    {
        [CustomAction]
        public static ActionResult RestoreVisualStudioTemplateFiles(Session session)
        {
            string visualStudio10Path = GetVisualStudio10Path();

            if (string.IsNullOrEmpty(visualStudio10Path))
            {
                return ActionResult.Success;
            }

            string visualStudio10DevEnvPath = Path.Combine(visualStudio10Path, @"Common7\IDE\devenv.exe");
            string ideFolderPath = Path.Combine(visualStudio10Path, @"Common7\IDE");
            
            // only do this if:
            // we're VS10            - this is checked by the custom action code that calls us
            // we're uninstalling    - this is checked by the custom action code that calls us
            // rename the .bak files and run devenv /setup again
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

        private static string GetVisualStudio10Path()
        {
            var registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\VisualStudio\SxS\VS7");
            if (registryKey == null)
            {
                return null;
            }

            var value = registryKey.GetValue(@"10.0");
            return value as string;
        }

        [CustomAction]
        public static ActionResult BackupVisualStudioTemplateFiles(Session session)
        {
            string visualStudio10Path = GetVisualStudio10Path();
            
            if (string.IsNullOrEmpty(visualStudio10Path))
            {
                return ActionResult.Success;
            }

            string ideFolderPath = Path.Combine(visualStudio10Path, @"Common7\IDE");
            
            //copy all the .zip files as zip.bak files
            var itemTemplatesPath = Path.Combine(ideFolderPath, "ItemTemplates");
            ProcessFolderForCopyingFiles(itemTemplatesPath);

            var projectTemplatesPath = Path.Combine(ideFolderPath, "ProjectTemplates");
            ProcessFolderForCopyingFiles(projectTemplatesPath);
            
            return ActionResult.Success;
        }

        private static void ProcessFolderForCopyingFiles(string path)
        {
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
                var directoryName = Path.GetDirectoryName(file);
                var destFileName = Path.Combine(directoryName, Path.GetFileName(file) + ".bak");
                if (!File.Exists(destFileName))
                {
                    // If the filename we'd like to use already exists don't create backup.
                    File.Copy(file, destFileName);
                }
            }

            return;
        }

        private static bool ProcessFolderForRenamingFiles(string path)
        {
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
                var directoryName = Path.GetDirectoryName(file);
                var destFileName = Path.Combine(directoryName, Path.GetFileNameWithoutExtension(file));
                if (!File.Exists(destFileName))
                {
                    // If the filename we'd like to use already exists don't change it.
                    File.Move(file, destFileName);
                    filesRenamed = true;
                }
            }

            return filesRenamed;
        }
    }
}
