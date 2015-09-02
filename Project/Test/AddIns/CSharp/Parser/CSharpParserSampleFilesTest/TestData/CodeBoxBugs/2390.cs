//--------------------------------------------------------------------------
// <copyright file="AxRSReportEditorPart.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <author>redmond\bolund</author>
//--------------------------------------------------------------------------
namespace Microsoft.Dynamics.Framework.Portal.UI.WebControls.WebParts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using Microsoft.Dynamics.ReportService2005;

    using WebUI = System.Web.UI.WebControls;

    /// <summary>
    /// Used to enhance the editing of the AxRSReportWebPart.
    /// </summary>
    [ToolboxItem(false)]
    public sealed class AxRSReportEditorPart : EditorPart
    {
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "We handle all exception types")]
        private ReportParameter[] GetReportParameters(ParameterValue[] values)
        {
            string serverUrl;
            string modelsFolder;
            string company;
            string languageCulture;

            ReportParameter[] parameters = null;
            string errMsg = null;
            try
            {
                ReportUtility.GetSessionInfo(out serverUrl, out modelsFolder, out company, out languageCulture);
                if (string.IsNullOrEmpty(serverUrl))
                {
                    throw new InvalidOperationException(Resources.GetString(Report.NoServerUrl));
                }

                ReportSettings settings = new ReportSettings();
                settings.ReportManagerUrl = serverUrl;
                settings.RootFolder = modelsFolder;
                settings.ReportPath = this.ReportPath;

                string fullPath = settings.ResolveFullPath();

                // Ask reporting services for a list of all reports and all the parameters for the currently selected report.
                using (ReportingService2005 rs = new ReportingService2005())
                {
                    // Provoke potential exceptions by validating the full path
                    settings.ValidateFullPath(fullPath);

                    rs.Url = settings.ResolvedServiceUrl;
                    rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    parameters = rs.GetReportParameters(fullPath, null, values != null, values, null);
                }
            }
            catch (System.Net.WebException)
            {
                errMsg = Resources.GetString(Report.cant_read_from_server);
            }
            catch (InvalidOperationException reportException)
            {
                errMsg = Microsoft.SharePoint.Utilities.SPHttpUtility.HtmlEncode(reportException.Message);
            }
            catch (ReportException reportException)
            {
                errMsg = AxRSReportWebPart.FormatMissingReportExceptionMessage(
                    reportException,
                    this.WebPartToEdit.CultureInfo,
                    this.WebPartToEdit.Title,
                    this.ReportPath);
            }
            catch (Exception exception)
            {
                errMsg = Microsoft.SharePoint.Utilities.SPHttpUtility.HtmlEncode(exception.Message);
            }

            if (!string.IsNullOrEmpty(errMsg))
            {
                this.AddErrorMessage(errMsg);
            }

            return parameters;
        }
    }
}
