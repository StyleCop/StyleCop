using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Xml.XPath;

namespace Jubii.Web.UI.Controls
{
    /// <summary>
    /// Controls and output a list of stylesheets.
    /// </summary>
    [Obsolete("Should not be used, since the template(s) only requires a single stylesheet. A method to combine/compress multiple stylesheets should be researched.", false)]
    public class PageStylesheets : PageTemplateControl, IControl
    {
        private const string templateViewstateKey = "Template";
        private const string includeDefaultStylesheetsViewstateKey = "IncludeDefaultStylesheets";
        private const string stylesheetsXmlUriViewstateKey = "StylesheetsXmlUri";

        private readonly List<Stylesheet> stylesheets = new List<Stylesheet>();

        private bool defaultStylesheetsIncluded;

        protected override void OnInitInner(EventArgs e)
        {
            if (Page is BasePage)
            {
                ((BasePage)Page).SetPageStylesheets(this);
            }
            base.OnInitInner(e);
        }

        private void EnsureDefaultStylesheets()
        {
            if (IncludeDefaultStylesheets && !defaultStylesheetsIncluded)
            {
                var path = (ControlUtility.IsLocalPath(StylesheetsXmlUri)
                                ? Context.Server.MapPath(StylesheetsXmlUri)
                                : ResolveUrl(StylesheetsXmlUri));

                var document = DownloadXml(Context, path);

                if (document != null)
                {
                    document = RemoveNamespace(document);

                    foreach (var element in document.XPathSelectElements("/includes/stylesheets/stylesheet"))
                    {
                        var template = element.Attribute("template");

                        if (template == null || string.IsNullOrEmpty(template.Value) ||
                            template.Value.Equals(Template.ToString(), StringComparison.InvariantCultureIgnoreCase))
                        {
                            var location = element.Attribute("location");

                            if (location != null)
                            {
                                var media = element.Attribute("media");
                                var priority = element.Attribute("priority");

                                stylesheets.Add(new Stylesheet(
                                                    location.Value,
                                                    media == null ? "all" : media.Value,
                                                    priority == null ? 80 : Convert.ToDouble(priority.Value)));
                            }
                        }
                    }
                }

                defaultStylesheetsIncluded = true;
            }
        }

        protected override void RenderInner(HtmlTextWriter writer)
        {

            if (DesignMode)
            {
                return;
            }


            EnsureDefaultStylesheets();

            stylesheets.Sort((a, b) => -a.Priority.CompareTo(b.Priority));
            foreach (var stylesheet in stylesheets)
            {
                writer.WriteLine(@"<link rel=""stylesheet"" href=""{0}"" type=""text/css"" media=""{1}"" />", stylesheet.Href, stylesheet.Media);
            }
        }

        protected override void AddCacheKeyParameters(Dictionary<string, string> parameters)
        {
            EnsureDefaultStylesheets();

            base.AddCacheKeyParameters(parameters);
            parameters["PhysicalPath"] = Context.Request.PhysicalPath;
            parameters[templateViewstateKey] = Template.ToString();

            if (IncludeDefaultStylesheets)
            {
                parameters[stylesheetsXmlUriViewstateKey] = StylesheetsXmlUri;
            }

            parameters["Stylesheets"] = string.Join("|", (from s in stylesheets select s.Media + ':' + s.Href).ToArray());
        }


        /// <summary>
        /// Gets or sets the path to the default stylesheets that are required to be on a jubii-bage.
        /// </summary>
        public string StylesheetsXmlUri
        {
            get { return ViewState[stylesheetsXmlUriViewstateKey] as string ?? DefaultScriptsXmlUri; }
            set { ViewState[stylesheetsXmlUriViewstateKey] = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the default stylesheets should be included.
        /// </summary>
        public bool IncludeDefaultStylesheets
        {
            get
            {
                var o = ViewState[includeDefaultStylesheetsViewstateKey];
                if (o != null)
                {
                    return Convert.ToBoolean(o);
                }
                return true;
            }
            set
            {
                ViewState[includeDefaultStylesheetsViewstateKey] = value;
            }
        }

        /// <summary>
        /// Gets or sets the required template of the stylesheets that should be included in the output of this <see cref="PageStylesheets"/> control.
        /// </summary>
        public PageTemplate Template
        {
            get
            {
                var template = ViewState[templateViewstateKey];
                if (template != null)
                {
                    return (PageTemplate)template;
                }
                if (Page is BasePage)
                {
                    return ((BasePage)Page).Template;
                }
                return PageTemplate.NotSet;
            }
            set
            {
                ViewState[templateViewstateKey] = value;
            }
        }


        public void AddStylesheet(string href, string media, double priority)
        {
            stylesheets.Add(new Stylesheet(href, media, priority));
        }

        private class Stylesheet
        {

            public Stylesheet(string href, string media, double priority)
            {
                Href = href;
                Media = media;
                Priority = priority;
            }

            public string Href { get; private set; }
            public string Media { get; private set; }
            public double Priority { get; private set; }
        }
    }
}