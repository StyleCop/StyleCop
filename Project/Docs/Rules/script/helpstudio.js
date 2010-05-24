/* Wire up the bodyload handler (set here rather than in the body element
    in order to avoid a HTML Help viewer bug with printing multiple topics */
window.onload = hsBodyLoad;

/* Set body initially hidden unless we are printing */
document.write("<style media='screen'>div#hsbody{display: none}</style>");

/* This is required for user data support in .chms */
var curURL = document.location + ".";
var pos = curURL.indexOf("mk:@MSITStore");
var scrollPos = null;
if( pos == 0 )
{
    curURL = "ms-its:" + curURL.substring(14,curURL.length-1);
    document.location.replace(curURL);
}

function hsBodyLoad()
{
	if (scrollPos == null && curURL.indexOf("#") != -1)
	{
		var oBanner= documentElement("pagetop");
		scrollPos = document.body.scrollTop - oBanner.offsetHeight;
	}

	resizeBan();	
		
	document.body.onclick = resizeBan;
	document.body.onresize = resizeBan;
	window.onbeforeprint = hsBeforePrint;
	window.onafterprint = hsAfterPrint;	

	// make body visible, now that we're ready to render
	document.body.style.display = "";	
}

/* Non scrolling region */

function resizeBan(){

	if (hsmsieversion() > 4)
	{
		try
		{

			hsHideBoxes();

			if (document.body.clientWidth==0) return;
			var oBanner= documentElement("pagetop");
			var oText= documentElement("pagebody");
			if (oText == null) return;
			var oBannerrow1 = documentElement("projectnamebanner");
			var oTitleRow = documentElement("pagetitlebanner");
			if (oBannerrow1 != null){
				var iScrollWidth = dxBody.scrollWidth;
				oBannerrow1.style.marginRight = 0 - iScrollWidth;
			}
			if (oTitleRow != null){
				oTitleRow.style.padding = "0px 10px 0px 22px; ";
			}
			if (oBanner != null){
				document.body.scroll = "no"
				oText.style.overflow= "auto";
				oBanner.style.width= document.body.offsetWidth-2;
				oText.style.paddingRight = "20px"; // Width issue code
				oText.style.width= document.body.offsetWidth-4;
				oText.style.top=0;  
				if (document.body.offsetHeight > oBanner.offsetHeight)
					oText.style.height= document.body.offsetHeight - (oBanner.offsetHeight+4) 
				else oText.style.height=0
				if(scrollPos!=null)
				{
					oText.scrollTop = scrollPos;
					scrollPos = null;
				}				
			}	
			try{nstext.setActive();} //allows scrolling from keyboard as soon as page is loaded. Only works in IE 5.5 and above.
			catch(e){}

		}
		catch(e){}
	}
} 

function hsmsieversion()
// Return Microsoft Internet Explorer (major) version number, or 0 for others.
// This function works by finding the "MSIE " string and extracting the version number
// following the space, up to the decimal point for the minor version, which is ignored.
{
    var ua = window.navigator.userAgent
    var msie = ua.indexOf ( "MSIE " )

    if ( msie > 0 )        // is Microsoft Internet Explorer; return version number
        return parseInt ( ua.substring ( msie+5, ua.indexOf ( ".", msie ) ) )
    else
        return 0    // is other browser
}

/* End Non Scrolling Region */

/* Print Handling */

function hsBeforePrint(){

	var i;
	var allElements;

	if (window.text) document.all.text.style.height = "auto";
			
	allElements = document.getElementsByTagName("*");
			
	for (i=0; i < allElements.length; i++){
		if (allElements[i].tagName == "BODY") {
			allElements[i].scroll = "yes";
			}
		if (allElements[i].id == "pagetop") {
			allElements[i].style.margin = "0px 0px 0px 0px";
			allElements[i].style.width = "100%";
			}
		if (allElements[i].id == "pagebody") {
			allElements[i].style.overflow = "visible";
			allElements[i].style.top = "5px";
			allElements[i].style.width = "100%";
			allElements[i].style.padding = "0px 10px 0px 30px";
			}
        if (allElements[i].id == "pagetoptable1row2" || allElements[i].id == "pagetoptable2row1" || allElements[i].id == "feedbacklink")
        {
			allElements[i].style.display = "none";
			}
        if (allElements[i].className == "LanguageSpecific")
        {
            allElements[i].style.display = "block";
        }
		}
}

function hsAfterPrint(){

	 document.location.reload();

}

/* End Print Handling */

/* Utility functions */

function GetWindowExternal()
{
	try
	{
		return window.external
	}
	catch(e) { }
}

function documentElement(id){
	return document.getElementById(id);
}

function sourceElement(e){
	if (window.event)
		e = window.event;
	return e.srcElement? e.srcElement : e.target;
}

function cancelEvent(e){
	e.returnValue = false;
	e.cancelBubble = true;
	if (e.stopPropagation) { 
		e.stopPropagation(); 
		e.preventDefault();
	} 	
}

/* End Utility functions */

/* Begin Save / Restore Scroll Position */

function loadScrollPosition(){
	var historyObject = getHistoryObject();
	if(historyObject)
	{
		var scrollValue = historyObject.getAttribute("Scroll");
		if(scrollValue)
		{
			if(scrollValue!=0)
			{
				try{
					scrollPos = scrollValue;
					documentElement("pagebody").scrollTop = scrollPos;
				}
				catch(e) { }
			}
		}
	}
}

function saveScrollPosition(){
	var historyObject = getHistoryObject();
	if(historyObject)
	{
		try
		{
			historyObject.setAttribute("Scroll", documentElement("pagebody").scrollTop);
		}
		catch(e) { }
	}
}

function getHistoryObject(){

	try{
		var externalObject = window.external;
		if (externalObject)
		{
			if (externalObject.IsDocumentX)
				return window.external;
			else
				externalObject = false;
		}
	}
	catch(e) { }

	if (!externalObject)
	{
		return documentElement("allHistory");
	}
}

/* End Save / Restore Scroll Position */

/* Glossary boxes */

function getElementPosition(e){ 
	var offsetLeft = 0; 
	var offsetTop = 0; 
	while (e){ 
		// Allow for the scrolling body region in IE
		if (hsmsieversion() > 4) {
			offsetLeft += (e.offsetLeft - e.scrollLeft); 
			offsetTop += (e.offsetTop - e.scrollTop); 
		}
		else
		{
			offsetLeft += e.offsetLeft ; 
			offsetTop += e.offsetTop; 		
		}
		e = e.offsetParent; 
	} 
	if (navigator.userAgent.indexOf('Mac') != -1 && typeof document.body.leftMargin != 'undefined'){ 
		offsetLeft += document.body.leftMargin; 
		offsetTop += document.body.topMargin; 
	} 
	return {left:offsetLeft,top:offsetTop}; 
} 

function cancelEvent(e){
	e.returnValue = false;
	e.cancelBubble = true;
	if (e.stopPropagation) { 
		e.stopPropagation(); 
		e.preventDefault();
	} 	
}

function hsHideBoxes(){
	var pres = document.getElementsByTagName("DIV");
	var pre;

	if (pres) {
		for (var iPre = 0; iPre < pres.length; iPre++) {
			pre = pres[iPre];
			if (pre.className) {
				if (pre.className == "hspopupbubble") {
					pre.style.visibility = "hidden";
				}
			};
		}
	}
}

function hsShowGlossaryItemBox(term,definition,e){

	if (window.event)
		e = window.event;

	hsHideBoxes(e);

	var button = sourceElement(e);
	var documentWidth;
	var documentHeight;
	var boxWidth;
	var pixelLeft;
	var pixelTop;
	var boxHeigt;
	var boxWidth;
	
	cancelEvent(e);

	var div = documentElement("hsglossaryitembox")
	if (div && button) {

		// Have the browser size the box
		div.style.height = "";
		div.style.width = "";
		
		// Clear the tooltip so it doesn't appear above the popup
		button.title = "";
		
		div.innerHTML = "<p><strong>" + term + "</strong><br>" + definition + "</p>";
	
		pixelTop = getElementPosition(button).top + 14;
		
		// Check if the box would go off the bottom of the visible area
		documentHeight = document.body.clientHeight;
		boxHeight = div.clientHeight;
		if (pixelTop + boxHeight > documentHeight) 
		{
			// If the box won't fit both above and below the link
			//  using the default width then make the box wider
			if (boxHeight >= pixelTop)
				div.style.width = "80%";
			else			
				pixelTop = pixelTop - 14 - boxHeight;
		}
		div.style.top = pixelTop + "px";
		
		documentWidth = document.body.clientWidth;
		boxWidth = div.clientWidth;
		pixelLeft = button.offsetLeft;

		// Check if the box would go off the edge of the visible area		
		if (pixelLeft + boxWidth > documentWidth)
		{
			pixelLeft = documentWidth - boxWidth - 5;
		}
		div.style.left = pixelLeft + "px";		
		
		// Show the box
		div.style.visibility = "visible";
	}

}

/* End Glossary boxes */