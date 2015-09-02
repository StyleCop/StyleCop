public class C
{
    /// <summary>
    /// Gets or sets the list to open
    /// </summary>
    public string ListName
    {
        get { return this.listName; }
        set { this.listName = value; }
    }

    /// <summary>
    /// Gets or sets the web where the list is located
    /// </summary>
    public string WebName
    {
        get { return this.webName; }
        set { this.webName = value; }
    }

    /// <summary>
    /// Overridden method CreateChildControls from the Webpart class
    /// </summary>
    protected override void CreateChildControls()
    {
        this.currentSite = SPControl.GetContextSite(Context);
        this.currentWeb = this.currentSite.OpenWeb(WebName);
        try
        {
            this.currentList = this.currentWeb.Lists[ListName];
            this.listRootFolder = this.currentWeb.Lists[ListName].RootFolder.ToString();
        }
    }
}