class C
{
    void M()
    {
        XElement rootElement =
            new XElement("DataSources",
            new XComment(string.Format("Made with {0} on {1}", madeWith, madeOn)),
            new XElement("DataSource", new XAttribute("Name", this.txtLinkName.Text),
            new XElement("SelectedLayer", new XAttribute("SelectedColumn", this.lblSelectedLayerColumn.Text)),
            new XElement("ShowLayerColumns", new XText("*")),
            new XElement("SelectedProvider", new XAttribute("Name", this.lblSelectedProvider.Text), new XText(this.txtFileOpen.Text)),
            new XElement("SelectedProviderTable", new XAttribute("SelectedColumn", this.lblSelectedDataSourceColumn.Text), new XText(this.lblSelectedTable.Text)),
            new XElement("ShowDataSourceColumns", new XText("*"))
            ));

        rootElement.Save(this.lblFilename.Text);
    }
}