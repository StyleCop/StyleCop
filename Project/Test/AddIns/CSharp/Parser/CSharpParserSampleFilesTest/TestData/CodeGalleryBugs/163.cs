public class C
{
    /// <summary>
    /// Adds the lens section.
    /// </summary>
    /// <param name="lens">The lens.</param>
    public void AddLensSection(string lens)
    {
        this.section = this.chapter.AddSection(new Paragraph(string.Format("Statistics using {0} lens", lens), this.sectionFont)); // (this is line 157)
    }
}