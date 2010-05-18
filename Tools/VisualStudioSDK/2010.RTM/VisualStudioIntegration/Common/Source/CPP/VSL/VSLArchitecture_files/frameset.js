
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


// SIG // Begin signature block
// SIG // MIIXPAYJKoZIhvcNAQcCoIIXLTCCFykCAQExCzAJBgUr
// SIG // DgMCGgUAMGcGCisGAQQBgjcCAQSgWTBXMDIGCisGAQQB
// SIG // gjcCAR4wJAIBAQQQEODJBs441BGiowAQS9NQkAIBAAIB
// SIG // AAIBAAIBAAIBADAhMAkGBSsOAwIaBQAEFNA3Cl43FjKb
// SIG // QaT784pPGM7lVGapoIISMTCCBGAwggNMoAMCAQICCi6r
// SIG // EdxQ/1ydy8AwCQYFKw4DAh0FADBwMSswKQYDVQQLEyJD
// SIG // b3B5cmlnaHQgKGMpIDE5OTcgTWljcm9zb2Z0IENvcnAu
// SIG // MR4wHAYDVQQLExVNaWNyb3NvZnQgQ29ycG9yYXRpb24x
// SIG // ITAfBgNVBAMTGE1pY3Jvc29mdCBSb290IEF1dGhvcml0
// SIG // eTAeFw0wNzA4MjIyMjMxMDJaFw0xMjA4MjUwNzAwMDBa
// SIG // MHkxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5n
// SIG // dG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVN
// SIG // aWNyb3NvZnQgQ29ycG9yYXRpb24xIzAhBgNVBAMTGk1p
// SIG // Y3Jvc29mdCBDb2RlIFNpZ25pbmcgUENBMIIBIjANBgkq
// SIG // hkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAt3l91l2zRTmo
// SIG // NKwx2vklNUl3wPsfnsdFce/RRujUjMNrTFJi9JkCw03Y
// SIG // SWwvJD5lv84jtwtIt3913UW9qo8OUMUlK/Kg5w0jH9FB
// SIG // JPpimc8ZRaWTSh+ZzbMvIsNKLXxv2RUeO4w5EDndvSn0
// SIG // ZjstATL//idIprVsAYec+7qyY3+C+VyggYSFjrDyuJSj
// SIG // zzimUIUXJ4dO3TD2AD30xvk9gb6G7Ww5py409rQurwp9
// SIG // YpF4ZpyYcw2Gr/LE8yC5TxKNY8ss2TJFGe67SpY7UFMY
// SIG // zmZReaqth8hWPp+CUIhuBbE1wXskvVJmPZlOzCt+M26E
// SIG // RwbRntBKhgJuhgCkwIffUwIDAQABo4H6MIH3MBMGA1Ud
// SIG // JQQMMAoGCCsGAQUFBwMDMIGiBgNVHQEEgZowgZeAEFvQ
// SIG // cO9pcp4jUX4Usk2O/8uhcjBwMSswKQYDVQQLEyJDb3B5
// SIG // cmlnaHQgKGMpIDE5OTcgTWljcm9zb2Z0IENvcnAuMR4w
// SIG // HAYDVQQLExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xITAf
// SIG // BgNVBAMTGE1pY3Jvc29mdCBSb290IEF1dGhvcml0eYIP
// SIG // AMEAizw8iBHRPvZj7N9AMA8GA1UdEwEB/wQFMAMBAf8w
// SIG // HQYDVR0OBBYEFMwdznYAcFuv8drETppRRC6jRGPwMAsG
// SIG // A1UdDwQEAwIBhjAJBgUrDgMCHQUAA4IBAQB7q65+Siby
// SIG // zrxOdKJYJ3QqdbOG/atMlHgATenK6xjcacUOonzzAkPG
// SIG // yofM+FPMwp+9Vm/wY0SpRADulsia1Ry4C58ZDZTX2h6t
// SIG // KX3v7aZzrI/eOY49mGq8OG3SiK8j/d/p1mkJkYi9/uEA
// SIG // uzTz93z5EBIuBesplpNCayhxtziP4AcNyV1ozb2AQWtm
// SIG // qLu3u440yvIDEHx69dLgQt97/uHhrP7239UNs3DWkuNP
// SIG // tjiifC3UPds0C2I3Ap+BaiOJ9lxjj7BauznXYIxVhBoz
// SIG // 9TuYoIIMol+Lsyy3oaXLq9ogtr8wGYUgFA0qvFL0QeBe
// SIG // MOOSKGmHwXDi86erzoBCcnYOMIIEejCCA2KgAwIBAgIK
// SIG // YQHPPgAAAAAADzANBgkqhkiG9w0BAQUFADB5MQswCQYD
// SIG // VQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4G
// SIG // A1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0
// SIG // IENvcnBvcmF0aW9uMSMwIQYDVQQDExpNaWNyb3NvZnQg
// SIG // Q29kZSBTaWduaW5nIFBDQTAeFw0wOTEyMDcyMjQwMjla
// SIG // Fw0xMTAzMDcyMjQwMjlaMIGDMQswCQYDVQQGEwJVUzET
// SIG // MBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVk
// SIG // bW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0
// SIG // aW9uMQ0wCwYDVQQLEwRNT1BSMR4wHAYDVQQDExVNaWNy
// SIG // b3NvZnQgQ29ycG9yYXRpb24wggEiMA0GCSqGSIb3DQEB
// SIG // AQUAA4IBDwAwggEKAoIBAQC9MIn7RXKoU2ueiU8AI8C+
// SIG // 1B09sVlAOPNzkYIm5pYSAFPZHIIOPM4du733Qo2X1Pw4
// SIG // GuS5+ePs02EDv6DT1nVNXEap7V7w0uJpWxpz6rMcjQTN
// SIG // KUSgZFkvHphdbserGDmCZcSnvKt1iBnqh5cUJrN/Jnak
// SIG // 1Dg5hOOzJtUY+Svp0skWWlQh8peNh4Yp/vRJLOaL+AQ/
// SIG // fc3NlpKGDXED4tD+DEI1/9e4P92ORQp99tdLrVvwdnId
// SIG // dyN9iTXEHF2yUANLR20Hp1WImAaApoGtVE7Ygdb6v0LA
// SIG // Mb5VDZnVU0kSMOvlpYh8XsR6WhSHCLQ3aaDrMiSMCOv5
// SIG // 1BS64PzN6qQVAgMBAAGjgfgwgfUwEwYDVR0lBAwwCgYI
// SIG // KwYBBQUHAwMwHQYDVR0OBBYEFDh4BXPIGzKbX5KGVa+J
// SIG // usaZsXSOMA4GA1UdDwEB/wQEAwIHgDAfBgNVHSMEGDAW
// SIG // gBTMHc52AHBbr/HaxE6aUUQuo0Rj8DBEBgNVHR8EPTA7
// SIG // MDmgN6A1hjNodHRwOi8vY3JsLm1pY3Jvc29mdC5jb20v
// SIG // cGtpL2NybC9wcm9kdWN0cy9DU1BDQS5jcmwwSAYIKwYB
// SIG // BQUHAQEEPDA6MDgGCCsGAQUFBzAChixodHRwOi8vd3d3
// SIG // Lm1pY3Jvc29mdC5jb20vcGtpL2NlcnRzL0NTUENBLmNy
// SIG // dDANBgkqhkiG9w0BAQUFAAOCAQEAKAODqxMN8f4Rb0J2
// SIG // 2EOruMZC+iRlNK51sHEwjpa2g/py5P7NN+c6cJhRIA66
// SIG // cbTJ9NXkiugocHPV7eHCe+7xVjRagILrENdyA+oSTuzd
// SIG // DYx7RE8MYXX9bpwH3c4rWhgNObBg/dr/BKoCo9j6jqO7
// SIG // vcFqVDsxX+QsbsvxTSoc8h52e4avxofWsSrtrMwOwOSf
// SIG // f+jP6IRyVIIYbirInpW0Gh7Bb5PbYqbBS2utye09kuOy
// SIG // L6t6dzlnagB7gp0DEN5jlUkmQt6VIsGHC9AUo1/cczJy
// SIG // Nh7/yCnFJFJPZkjJHR2pxSY5aVBOp+zCBmwuchvxIdpt
// SIG // JEiAgRVAfJ/MdDhKTzCCBJ0wggOFoAMCAQICEGoLmU/A
// SIG // ACWrEdtFH1h6Z6IwDQYJKoZIhvcNAQEFBQAwcDErMCkG
// SIG // A1UECxMiQ29weXJpZ2h0IChjKSAxOTk3IE1pY3Jvc29m
// SIG // dCBDb3JwLjEeMBwGA1UECxMVTWljcm9zb2Z0IENvcnBv
// SIG // cmF0aW9uMSEwHwYDVQQDExhNaWNyb3NvZnQgUm9vdCBB
// SIG // dXRob3JpdHkwHhcNMDYwOTE2MDEwNDQ3WhcNMTkwOTE1
// SIG // MDcwMDAwWjB5MQswCQYDVQQGEwJVUzETMBEGA1UECBMK
// SIG // V2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwG
// SIG // A1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMSMwIQYD
// SIG // VQQDExpNaWNyb3NvZnQgVGltZXN0YW1waW5nIFBDQTCC
// SIG // ASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBANw3
// SIG // bvuvyEJKcRjIzkg+U8D6qxS6LDK7Ek9SyIPtPjPZSTGS
// SIG // KLaRZOAfUIS6wkvRfwX473W+i8eo1a5pcGZ4J2botrfv
// SIG // hbnN7qr9EqQLWSIpL89A2VYEG3a1bWRtSlTb3fHev5+D
// SIG // x4Dff0wCN5T1wJ4IVh5oR83ZwHZcL322JQS0VltqHGP/
// SIG // gHw87tUEJU05d3QHXcJc2IY3LHXJDuoeOQl8dv6dbG56
// SIG // 4Ow+j5eecQ5fKk8YYmAyntKDTisiXGhFi94vhBBQsvm1
// SIG // Go1s7iWbE/jLENeFDvSCdnM2xpV6osxgBuwFsIYzt/iU
// SIG // W4RBhFiFlG6wHyxIzG+cQ+Bq6H8mjmsCAwEAAaOCASgw
// SIG // ggEkMBMGA1UdJQQMMAoGCCsGAQUFBwMIMIGiBgNVHQEE
// SIG // gZowgZeAEFvQcO9pcp4jUX4Usk2O/8uhcjBwMSswKQYD
// SIG // VQQLEyJDb3B5cmlnaHQgKGMpIDE5OTcgTWljcm9zb2Z0
// SIG // IENvcnAuMR4wHAYDVQQLExVNaWNyb3NvZnQgQ29ycG9y
// SIG // YXRpb24xITAfBgNVBAMTGE1pY3Jvc29mdCBSb290IEF1
// SIG // dGhvcml0eYIPAMEAizw8iBHRPvZj7N9AMBAGCSsGAQQB
// SIG // gjcVAQQDAgEAMB0GA1UdDgQWBBRv6E4/l7k0q0uGj7yc
// SIG // 6qw7QUPG0DAZBgkrBgEEAYI3FAIEDB4KAFMAdQBiAEMA
// SIG // QTALBgNVHQ8EBAMCAYYwDwYDVR0TAQH/BAUwAwEB/zAN
// SIG // BgkqhkiG9w0BAQUFAAOCAQEAlE0RMcJ8ULsRjqFhBwEO
// SIG // jHBFje9zVL0/CQUt/7hRU4Uc7TmRt6NWC96Mtjsb0fus
// SIG // p8m3sVEhG28IaX5rA6IiRu1stG18IrhG04TzjQ++B4o2
// SIG // wet+6XBdRZ+S0szO3Y7A4b8qzXzsya4y1Ye5y2PENtEY
// SIG // Ib923juasxtzniGI2LS0ElSM9JzCZUqaKCacYIoPO8cT
// SIG // ZXhIu8+tgzpPsGJY3jDp6Tkd44ny2jmB+RMhjGSAYwYE
// SIG // lvKaAkMve0aIuv8C2WX5St7aA3STswVuDMyd3ChhfEjx
// SIG // F5wRITgCHIesBsWWMrjlQMZTPb2pid7oZjeN9CKWnMyw
// SIG // d1RROtZyRLIj9jCCBKowggOSoAMCAQICCmEGlC0AAAAA
// SIG // AAkwDQYJKoZIhvcNAQEFBQAweTELMAkGA1UEBhMCVVMx
// SIG // EzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1Jl
// SIG // ZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3Jh
// SIG // dGlvbjEjMCEGA1UEAxMaTWljcm9zb2Z0IFRpbWVzdGFt
// SIG // cGluZyBQQ0EwHhcNMDgwNzI1MTkwMjE3WhcNMTMwNzI1
// SIG // MTkxMjE3WjCBszELMAkGA1UEBhMCVVMxEzARBgNVBAgT
// SIG // Cldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAc
// SIG // BgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjENMAsG
// SIG // A1UECxMETU9QUjEnMCUGA1UECxMebkNpcGhlciBEU0Ug
// SIG // RVNOOjdBODItNjg4QS05RjkyMSUwIwYDVQQDExxNaWNy
// SIG // b3NvZnQgVGltZS1TdGFtcCBTZXJ2aWNlMIIBIjANBgkq
// SIG // hkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAlYEKIEIYUXrZ
// SIG // le2b/dyH0fsOjxPqqjcoEnb+TVCrdpcqk0fgqVZpAuWU
// SIG // fk2F239x73UA27tDbPtvrHHwK9F8ks6UF52hxbr5937d
// SIG // YeEtMB6cJi12P+ZGlo6u2Ik32Mzv889bw/xo4PJkj5vo
// SIG // wxL5o76E/NaLzgU9vQF2UCcD+IS3FoaNYL5dKSw8z6X9
// SIG // mFo1HU8WwDjYHmE/PTazVhQVd5U7EPoAsJPiXTerJ7tj
// SIG // LEgUgVXjbOqpK5WNiA5+owCldyQHmCpwA7gqJJCa3sWi
// SIG // Iku/TFkGd1RyQ7A+ZN2ThAhYtv7ph0kJNrOz+DOpfkyi
// SIG // eX8yWSkOnrX14DyeP+xGOwIDAQABo4H4MIH1MB0GA1Ud
// SIG // DgQWBBQolYi/Ajvr2pS6fUYP+sv0fp3/0TAfBgNVHSME
// SIG // GDAWgBRv6E4/l7k0q0uGj7yc6qw7QUPG0DBEBgNVHR8E
// SIG // PTA7MDmgN6A1hjNodHRwOi8vY3JsLm1pY3Jvc29mdC5j
// SIG // b20vcGtpL2NybC9wcm9kdWN0cy90c3BjYS5jcmwwSAYI
// SIG // KwYBBQUHAQEEPDA6MDgGCCsGAQUFBzAChixodHRwOi8v
// SIG // d3d3Lm1pY3Jvc29mdC5jb20vcGtpL2NlcnRzL3RzcGNh
// SIG // LmNydDATBgNVHSUEDDAKBggrBgEFBQcDCDAOBgNVHQ8B
// SIG // Af8EBAMCBsAwDQYJKoZIhvcNAQEFBQADggEBAADurPzi
// SIG // 0ohmyinjWrnNAIJ+F1zFJFkSu6j3a9eH/o3LtXYfGyL2
// SIG // 9+HKtLlBARo3rUg3lnD6zDOnKIy4C7Z0Eyi3s3XhKgni
// SIG // i0/fmD+XtzQSgeoQ3R3cumTPTlA7TIr9Gd0lrtWWh+pL
// SIG // xOXw+UEXXQHrV4h9dnrlb/6HIKyTnIyav18aoBUwJOCi
// SIG // fmGRHSkpw0mQOkODie7e1YPdTyw1O+dBQQGqAAwL8tZJ
// SIG // G85CjXuw8y2NXSnhvo1/kRV2tGD7FCeqbxJjQihYOoo7
// SIG // i0Dkt8XMklccRlZrj8uSTVYFAMr4MEBFTt8ZiL31EPDd
// SIG // Gt8oHrRR8nfgJuO7CYES3B460EUxggR3MIIEcwIBATCB
// SIG // hzB5MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGlu
// SIG // Z3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMV
// SIG // TWljcm9zb2Z0IENvcnBvcmF0aW9uMSMwIQYDVQQDExpN
// SIG // aWNyb3NvZnQgQ29kZSBTaWduaW5nIFBDQQIKYQHPPgAA
// SIG // AAAADzAJBgUrDgMCGgUAoIGiMBkGCSqGSIb3DQEJAzEM
// SIG // BgorBgEEAYI3AgEEMBwGCisGAQQBgjcCAQsxDjAMBgor
// SIG // BgEEAYI3AgEVMCMGCSqGSIb3DQEJBDEWBBRqmv0zgSoR
// SIG // aJcTsaiigQniNg9sVjBCBgorBgEEAYI3AgEMMTQwMqAY
// SIG // gBYAZgByAGEAbQBlAHMAZQB0AC4AagBzoRaAFGh0dHA6
// SIG // Ly9taWNyb3NvZnQuY29tMA0GCSqGSIb3DQEBAQUABIIB
// SIG // AEf5iZpez1WEiTMME0zC87eHKINd7usFuhI81eRkl49+
// SIG // FzG0I4RmUOIF2FeryDjTH8SAdXuEF5s2lWPYA+/RV0LR
// SIG // pU2vQ0BNM2ArgUHqwqtK0uamVFjMGgXTKfqomarLVexM
// SIG // g0buyQ5yJlISuOwEbj+xeIS1GvYUFZ22VWb0WKslqm6J
// SIG // pflOBi3NAIAmz2d6YKKS3UBnslYdl237zpHrxccaJo/4
// SIG // tEuamPrXmzSU/19TyjHp31WkRY8KQ/WIS+tkY5gEtyhQ
// SIG // JnTYmxMzd6d1RkUN2fASpBFXxr4bsX6xsQ4dbB//H7ZF
// SIG // rNCi/M7KZYVpFvOtxC1VQ1IGOLOKf14/Xn2hggIfMIIC
// SIG // GwYJKoZIhvcNAQkGMYICDDCCAggCAQEwgYcweTELMAkG
// SIG // A1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAO
// SIG // BgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29m
// SIG // dCBDb3Jwb3JhdGlvbjEjMCEGA1UEAxMaTWljcm9zb2Z0
// SIG // IFRpbWVzdGFtcGluZyBQQ0ECCmEGlC0AAAAAAAkwBwYF
// SIG // Kw4DAhqgXTAYBgkqhkiG9w0BCQMxCwYJKoZIhvcNAQcB
// SIG // MBwGCSqGSIb3DQEJBTEPFw0xMDAzMjAxNzUxMTVaMCMG
// SIG // CSqGSIb3DQEJBDEWBBR5up1j0EhxhG953ZR6fwPd3a5w
// SIG // vDANBgkqhkiG9w0BAQUFAASCAQB4xVeBJw0PAsP+BVvC
// SIG // kgyRIWmVAhGB7vOQ4SvRJKRCh6lWxAS5YM62eSjf5NmM
// SIG // dV7DsFyInHzrh1bUYTutjbeIirSLauC7iE6xNiP7fcQt
// SIG // y/J3ba01JNfXwGYA5Tt14LPXSX2U1l6svc+P8Q1TLGUl
// SIG // BxliOCq43ulT+aozVc5RoQwgNu12zX5//9L3RBqlAjGO
// SIG // TihBJcTPQLNd8+aM82soND2CTZZwmEQNypkhWvq3lnXg
// SIG // f1l+lr+Jcd30ha4Ebxt9fKJLLtYIBvYAbRr9RxFVWy36
// SIG // k3jRvf6S5GmDKz9USd/x9FWtiuL3Z243RNKCci4APuqa
// SIG // VgNecpYlnx/TFFG4
// SIG // End signature block
