
var MSIE = false;
var ver = 0;
var indexOfMSIE = navigator.userAgent.indexOf("MSIE"); 
if(indexOfMSIE != -1)
{
	MSIE = true;
	ver = parseFloat(navigator.userAgent.substring(indexOfMSIE + 5, navigator.userAgent.indexOf(";", indexOfMSIE)));
}

var isMac = (navigator.appVersion.indexOf("Macintosh") >= 0);
var isUpLevel = (MSIE && ver >= 5 && !isMac);

var xmlData = XMLData("VSLArchitecture_files/data.xml");

var g_RowStyleList = new  Array(
 "propViewerEvenRow",
 "propViewerOddRow"
);


var strShape	= "Shape Name:";



function XMLData(file)
{
	var temp = null;
	if(isUpLevel)
	{
		temp = CreateObject("Microsoft.XMLDOM");
		if (temp == null)
		{
			temp = CreateObject("MSXML2.DOMDocument");
		}

		if (temp != null)
		{
			temp.async = false;
		
			temp.load(file);
			if (temp.parseError.errorCode != 0)
			{
				temp = null;
			}
		}
	}

	return temp;
}

function CreateObject (strObj)
{
	var obj = null;
	eval ("try { obj = new ActiveXObject(strObj); } catch (e) {}");
	return obj;
}

function doVersion()
{
	if(isUpLevel)
	{
		frmToolbar.divDownLevel.innerHTML = "";
		frmToolbar.divUpLevel.innerHTML = frmWidgets.divData.innerHTML;
	}
}	
	
	
function FindShapeXML (pageID, shapeID)
{
	var shapeObj = null;

	if (xmlData != null)
	{
		var pagesObj = xmlData.selectSingleNode("VisioDocument/Pages");
		if(!pagesObj)
		{
			return null;
		}

		var pageQuerryString = './/Page[@ID = "' + pageID + '"]';
		var pageObj = pagesObj.selectSingleNode(pageQuerryString);
		if(pageObj == null)
		{
			return null;
		}

		var shapeQuerryString = './/Shape[@ID = "' + shapeID + '"]';
		shapeObj = pageObj.selectSingleNode(shapeQuerryString);
	}

	return shapeObj;
}

function OnShapeKey(pageID, shapeID)
{
	var e = window.frmDrawing.event;
	
	if(e.keyCode == 13 && e.ctrlKey)		//ctrl + enter
	{
		UpdateProps (pageID, shapeID);
	}
	else if (e.keyCode == 13)
	{
		OnShapeClick (pageID, shapeID);
	}
}

function OnShapeClick (pageID, shapeID)
{
	if (isUpLevel)
	{
		var e = frmDrawing.window.event;
		var elem = e.srcElement;

		if (e != null && e.ctrlKey && frmToolbar.widgets && frmToolbar.widgets.Details)
		{
			UpdateProps (pageID, shapeID);
		}
		else
		{
			var shapeNode = FindShapeXML (pageID, shapeID);
			var hlObj = GetHLAction (shapeNode, pageID, shapeID);
			if (hlObj != null)
			{
				if (hlObj.DoFunction.length > 0)
				{
					eval (hlObj.DoFunction);
				}
				else if (hlObj.Hyperlink.length > 0)
				{
					if (hlObj.NewWindow)
					{
						window.open (hlObj.Hyperlink);
					}
					else
					{
						top.location.href = hlObj.Hyperlink.substr (0, 510);
					}
				}
				else if (elem != null)
				{
					var href = elem.origHref;
					if (href == null)
					{
						href = elem.href;
					}

					var target = elem.origTarget;
					if (target == null)
					{
						target = elem.target;
					}

					if (href && href.length > 0)
					{
						href = HTMLEscape (href);
						if (target && target == "_blank")
						{
							window.open (href);
						}
						else
						{
							top.location.href = href.substr (0, 510);
						}
					}
				}
			}
		}
	}

	return (!isUpLevel);
}

function UpdateProps(pageID, shapeID)
{
	var shape = FindShapeXML (pageID, shapeID);

	FillPropPane(shape, frmToolbar.hideDetails);
}

function UpdatePropsByShapeName(pageName, shapeName)
{
	var shape = FindShapeXMLByName (pageName, shapeName);

	FillPropPane(shape, frmToolbar.hideDetails);
}

function FillPropPane (shapeNode, outputDivObj )
{
	if (shapeNode != null && outputDivObj != null)
	{
		if(outputDivObj.style.display == "none")
		{
			frmToolbar.ToggleWidget(outputDivObj);
		}
	
		var strCPHTML = "";
		
		var shapeNameAttr = shapeNode.attributes.getNamedItem ("Name");
		if (shapeNameAttr)
		{
			strCPHTML += "<span class='p2' style='padding-left:2px;'>" + strShape + " " + HTMLEscape(shapeNameAttr.text) + "</span>";
		}

		var strTableHTML = CreatePropTable (shapeNode);
		if(strTableHTML.indexOf("<table") == -1)
		{
			strTableHTML = "<p class='p2' style='margin-left:1em;margin-top:0em;'>" + strTableHTML + "</p>";
		}

		if (strTableHTML.length > 0)
		{
			strCPHTML += strTableHTML;
		}
		else
		{
			strCPHTML = strNoCustomPropertiesToDisplayText;
		}
		
		outputDivObj.innerHTML = strCPHTML;
		outputDivObj.minHeight = 75;
	}
}

function CreatePropTable (shapeNode)
{
	var strCPHTML = "";
	var strStartTable = "<table class='propViewerTABLE' borderColor='#999999' cellPadding='2' width='95%' border='1' summary='This table contains shape details'>";
		strStartTable += "<THEAD class='propViewerTHEAD'><TH>Label</TH><TH>Value</TH></THEAD>";
	var strEndTable = "</TABLE>";

	if (shapeNode != null)
	{
		var propColl = shapeNode.selectNodes ("Prop");

		var propCount = propColl.length;
		for (var count = 0; count < propCount; count++)
		{
			strCPHTML += "<TR class='" + g_RowStyleList[count % 2] + "'>";
			
			var strLabelText = "";
			oPropLabel = propColl.item(count).selectSingleNode("Label/textnode()");
			if (oPropLabel != null)
			{
				strLabelText = HTMLEscape (oPropLabel.text);
			}
			else
			{
				oPropName = propColl.item(count).attributes.getNamedItem ("Name");
				if (oPropName)
				{
					strLabelText = HTMLEscape (oPropName.text);
				}
			}

			if (strLabelText.length > 0)
			{
				strCPHTML += "<TD class='propViewerTD'>" + strLabelText + "</TD>";
				strCPHTML += "<TD class='propViewerTD'>"

				var strValueText = "&nbsp;";
				oPropValue = propColl.item(count).selectSingleNode("Value/textnode()");
				if (oPropValue)
				{
					strValueText = HTMLEscape (oPropValue.text);
				}

				strCPHTML += strValueText + "</TD></TR>";
			}
		}

		if(strCPHTML != "")
		{
			strCPHTML = strStartTable + strCPHTML + strEndTable;
		}
		else
		{
			strCPHTML = "No Details Available.";
		}
	}

	return strCPHTML;
}

function keyHandler()
{
	var e = frmDrawing.window.event;
	if(e.keyCode == 13) //enter
	{
		e.srcElement.click();
	}
}

function GoToPage(index)
{
	if (viewMgr)
	{
		viewMgr.loadPage (index);
	}
	else
	{
		DefPageLoad (index);
	}
}

function GoToPageByID(pageID)
{
	var pageIndex = PageIndexFromID (pageID);
	if (pageIndex >= 0)
	{
		GoToPage (pageIndex);
	}
}

function PageIndexFromID (pageID)
{
	if (g_FileList != null)
	{
		var entry;

		var count;
		var fileEntry;
		var bFoundEntry = false;
		for (count = 0; 
			 count < g_FileList.length && !bFoundEntry; 
			 count++)
		{
			if (pageID == g_FileList[count].PageID)
			{
				return count;
			}
		}
	}
	return -1;
}

function PageIndexFromName (strPageName)
{
	if (g_FileList != null)
	{
		var entry;

		var strPageNameLower = strPageName;
		strPageNameLower = strPageNameLower.toLowerCase ();

		var count;
		var fileEntry;
		var bFoundEntry = false;
		for (count = 0; 
			 count < g_FileList.length && !bFoundEntry; 
			 count++)
		{
			var strFileListPageName = g_FileList[count].PageName;
			strFileListPageName = HTMLUnescape (strFileListPageName);
			strFileListPageName = strFileListPageName.toLowerCase ();
			if (strPageNameLower == strFileListPageName)
			{
				return count;
			}
		}
	}
	return -1;
}

function PageIndexFromFileName (strFileName)
{
	if (g_FileList != null)
	{
		var entry;

		var strFileNameLower = strFileName;
		strFileNameLower = strFileNameLower.toLowerCase ();

		var count;
		var fileEntry;
		var bFoundEntry = false;
		for (count = 0; 
			 count < g_FileList.length && !bFoundEntry; 
			 count++)
		{
			var strFileListFileName = g_FileList[count].PriImage;
			strFileListFileName = strFileListFileName.toLowerCase ();
			if (strFileNameLower == strFileListFileName)
			{
				return count;
			}

			strFileListFileName = g_FileList[count].SecImage;
			strFileListFileName = strFileListFileName.toLowerCase ();
			if (strFileNameLower == strFileListFileName)
			{
				return count;
			}
		}
	}
	return -1;
}

function PageIndexFromVisioPageIndex (pageIndex)
{
	if (g_FileList != null)
	{
		var entry;

		var count;
		var fileEntry;
		var bFoundEntry = false;
		for (count = 0; 
			 count < g_FileList.length && !bFoundEntry; 
			 count++)
		{
			if (pageIndex == g_FileList[count].PageIndex)
			{
				return count;
			}
		}
	}
	return -1;
}

function FindShapeXML (pageID, shapeID)
{
	var shapeObj = null;

	if (xmlData)
	{
		var pagesObj = xmlData.selectSingleNode("VisioDocument/Pages");
		if(!pagesObj)
		{
			return null;
		}
		
		var pageQuerryString = './/Page[@ID = "' + pageID + '"]';
		var pageObj = pagesObj.selectSingleNode(pageQuerryString);
		if(!pageObj)
		{
			return null;
		}

		var shapeQuerryString = './/Shape[@ID = "' + shapeID + '"]';
		shapeObj = pageObj.selectSingleNode(shapeQuerryString);
	}

	return shapeObj;
}

function FindShapeXMLByName (pageName, shapeName)
{
	var shapeObj = null;

	if (xmlData)
	{
		var pagesObj = xmlData.selectSingleNode("VisioDocument/Pages");
		if(!pagesObj)
		{
			return null;
		}
		
		var pageQuerryString = './/Page[@Name $ieq$ "' + EscapeString (pageName) + '"]';
		var pageObj = pagesObj.selectSingleNode(pageQuerryString);
		if(!pageObj)
		{
			return null;
		}

		var shapeQuerryString = './/Shape[@Name $ieq$ "' + EscapeString (shapeName) + '"]';
		shapeObj = pageObj.selectSingleNode(shapeQuerryString);
	}

	return shapeObj;
}

function Unquote (str)
{
	var nStartIndex = 0;
	var nEndIndex = str.length;

	if (str.charAt (0) == '"')
	{
		nStartIndex = 1;
	}

	if (str.charAt (nEndIndex - 1) == '"')
	{
		nEndIndex -= 1;
	}

	return str.substring (nStartIndex, nEndIndex);
}

function ConvertXorYCoordinate(PosValue, OldMin, OldMax, NewMin, NewMax, MapBackwards)
{
	var OldMid = (OldMax - OldMin) / 2;
	var NewMid = (NewMax - NewMin) / 2;
	var ConvertResult = 1 * PosValue;
	ConvertResult = ConvertResult - (OldMin + OldMid);
	ConvertResult = ConvertResult / OldMid;
	if(MapBackwards != 0)
	{
		ConvertResult = 0 - ConvertResult;
	}
	ConvertResult = ConvertResult * NewMid;
	ConvertResult = ConvertResult + (NewMin + NewMid);
	return ConvertResult;
}

function showObject( divObject, divID ) 
{
	if( divObject == null )
		divObject = getObj( divID );
	
	if( divObject != null ) 
	{
		divObject.style.display = "";
		divObject.style.visibility = "visible"
	}
	return divObject;
}

function hideObject( divObject, divID ) 
{
	if( divObject == null )
		divObject = getObj( divID );
	
	if( divObject != null ) 
	{
		divObject.style.visibility = "hidden";
		divObject.style.display = "none";
	}
	return divObject;
}

function EscapeString (str)
{
	var strResult = "";

	for (var i = 0 ; i < str.length ; i++)
	{
		var curChar = str.charAt(i);
		if (curChar == '\\')
		{
			strResult += "\\\\";
		}
		else if (curChar == "\"")
		{
			strResult += "\\\"";
		}
		else if (curChar == "\'")
		{
			strResult += "\\\'";
		}
		else
		{
			strResult += curChar;
		}
	}

	return strResult;
}

function HTMLEscape (str)
{
	var strResult = "";

	for (var i = 0 ; i < str.length ; i++)
	{
		var curChar = str.charAt(i);
		if (curChar == '\\')
		{
			strResult += "&#92;";
		}
		else if (curChar == '\"')
		{
			strResult += "&#34;";
		}
		else if (curChar == '\'')
		{
			strResult += "&#39;";
		}
		else if (curChar == '<')
		{
			strResult += "&#60;";
		}
		else if (curChar == '<')
		{
			strResult += "&#62;";
		}
		else if (curChar == '&')
		{
			strResult += "&#38;";
		}
		else
		{
			strResult += curChar;
		}
	}

	return strResult;
}

function HTMLUnescape (str)
{
	var strResult = "";
	var strEscapePattern = "&#xx;";

	for (var i = 0 ; i < str.length - strEscapePattern.length + 1; i++)
	{
		if (str.charAt(i) == '&' && 
			str.charAt(i + 1) == '#' &&
			str.charAt(i + 4) == ';')
		{
			var charCode = str.charAt(i + 2);
			charCode += str.charAt(i + 3);

			if (charCode == "34")
			{
				strResult += '"';
			}
			else if (charCode == "39")
			{
				strResult += '\'';
			}
			else if (charCode == "60")
			{
				strResult += '<';
			}
			else if (charCode == "62")
			{
				strResult += '>';
			}
			else if (charCode == "92")
			{
				strResult += '\\';
			}
			else if (charCode == "38")
			{
				strResult += '&';
			}
			
			i = i + strEscapePattern.length - 1;
		}
		else
		{
			strResult += str.charAt(i);
		}
	}

	strResult += str.substring (i, str.length);

	return strResult;
}

