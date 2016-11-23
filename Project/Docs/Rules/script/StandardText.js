
var styleCopName = "StyleCop";
var styleCopVersion = "4.7";

function StyleCopNameAndVersion()
{
    return (styleCopName + " " + styleCopVersion);    
}

function WriteStyleCopNameAndVersion()
{
    document.write(StyleCopNameAndVersion());
    return;
}

function WritePageTop(title)
{
    document.write("<div id='pagetop'><table width='100%'><tr><td align='left'><span id='projecttitle'>" + StyleCopNameAndVersion() + "</span></td><td align='right'><span id='feedbacklink'><a target='_new' href='https://github.com/StyleCop/StyleCop/issues/new'>Is this doc correct? Click here to open a bug.</a></span></td></tr><tr><td align='left' colspan='2'><span id='pagetitle'>" + title + "</span></td></tr></table></div>");
    return;
}

function WritePageFooter()
{
    document.write("<div id='pagefooter'><p>&nbsp;</p><p>&nbsp;</p><hr size=1><p>2012 - Andy Reeves</p></div>");
    return;
}