
var strShapeName	= "Shape Name";
var strShapeText	= "Shape Text";
var strProps		= "Custom Properties";
var strResults		= "Search results for:";

var strShape	= "Shape Name:";
var strNoCustomPropertiesToDisplayText = "CTRL+click a shape in the drawing to view details.";

var FindShapeXML = parent.FindShapeXML;
var Unquote = parent.Unquote;
var put_Location = parent.put_Location;


var strChkBox		= "Chkbox";
var strPropChkBox	= "PropChkbox";

function doExpando(xxx,yyy){
	if (xxx.style.display=="none"){
		xxx.style.display = ""
		yyy.src = up.src;
	}else{
		xxx.style.display = "none"
		yyy.src = down.src;
	}
}

function doExp(xxx,yyy){
	if (xxx.style.display=="none"){
		xxx.style.display = ""
		yyy.src = "minus.gif";
	}else{
		xxx.style.display = "none"
		yyy.src = "plus.gif";
	}
}


function FindOnClick()
{
	var count, indexOfString;
	
	var fieldsToSearchArray = new Array();
	if (parent.xmlData != null && document.theForm[strProps + strChkBox].checked)
	{
		for( count=0; count < document.theForm.length; count++ )
		{
			indexOfString = document.theForm[count].name.indexOf(strPropChkBox);
			if( -1 != indexOfString && document.theForm[count].checked )
			{
				fieldsToSearchArray[ fieldsToSearchArray.length ] = document.theForm[count].name.slice(0, indexOfString);
			}
		}
	}

	var searchTokensArray = CreateSearchTokens (document.theForm.findString.value);

	if (searchTokensArray.length > 0)
	{
		var findArray = Find(searchTokensArray, fieldsToSearchArray);
		var ArrayLength = findArray.length;
		var strResultsHTML = "No matches found.";
		var lastPageID = null;
		var shapeID;
		
		
		if(ArrayLength > 0)
		{
			strResultsHTML = strResults + ' <b>'+ parent.HTMLEscape(document.theForm.findString.value) +'</b>';
			for ( count = 0; count < ArrayLength; count++)
			{
			
				if( lastPageID != findArray[count].PageID )
				{
					lastPageID = findArray[count].PageID;
				}

				shapeID = findArray[count].ShapeID;
				strResultsHTML += '<p class="results"><a href="javascript:populateSearchResultDetails(\'results_'+ lastPageID +'_'+ shapeID +'\', '+ lastPageID +','+ shapeID +'); TogglePlus(results_' + lastPageID + '_' + shapeID + ',\'img_' + lastPageID + '_' + shapeID + '\', hideResults)"><img src="plus.gif" alt="Shows/hides shape details" width="13" height="9" border="0" id="img_'+ lastPageID +'_'+ shapeID +'"></a>\n'
				strResultsHTML += '<a  class="blu1" href="JavaScript:FindQuerySelect(';

				strResultsHTML += findArray[count].PageID + ",";
				strResultsHTML += findArray[count].ShapeID + ",";
				strResultsHTML += findArray[count].PinX + ",";
				strResultsHTML += findArray[count].PinY;

				strResultsHTML += ')">'+ findArray[count].Title +'</a></p>\n'

				strResultsHTML += '</div>\n';
				strResultsHTML += '<div class="indent" id="results_'+ lastPageID +'_'+ shapeID +'" style="display:none;width:100%;"></div>\n'
			}

		}
		var divAdvSrch = document.all("hideAdvSrch");
		var imgAS0 = document.all("as0");
		
		var tmpObj = document.all("hideResults");
		if( tmpObj != null )
		{
			tmpObj.innerHTML = strResultsHTML;
			tmpObj.open = "true";
			tmpObj.style.display = "block";
		}
	}
}

function CreateSearchTokens (strUserString)
{
	var searchTokensArray = new Array();

	var strToken = "";
	var chCurChar;

	for (var count = 0; count < strUserString.length; count++)
	{
		chCurChar = strUserString.charAt(count);
		if (chCurChar == '"')
		{
			var nNextQuote = strUserString.indexOf('"', count + 1);
			if (nNextQuote >= 0)
			{
				strToken = strUserString.slice(count + 1, nNextQuote);
				searchTokensArray[searchTokensArray.length] = strToken;
				strToken = "";
				count = nNextQuote;
			}
		}
		else if (chCurChar == ' ')
		{
			if (strToken.length > 0)
			{
				searchTokensArray[searchTokensArray.length] = strToken;
			}

			strToken = "";
		}
		else
		{
			strToken += chCurChar;
		}
	}

	if (strToken.length > 0)
	{
		searchTokensArray[searchTokensArray.length] = strToken;
	}

	return searchTokensArray;
}

function populateSearchResultDetails( divID, pageID, shapeID )
{
	var tmpShape = FindShapeXML (pageID, shapeID);
	var strOutput = CreatePropTable( tmpShape );
	
	var tmpObj = document.all(divID);
	if( tmpObj != null )
	{
		tmpObj.innerHTML = strOutput;
	}
}

function makeAdvancedFindCheckboxes(div)
{
	if (parent.xmlData)
	{
		var strOutput = "";

		strOutput += "<INPUT type='checkbox' name='" + strShapeName + strChkBox + "' id='" + strShapeName + strChkBox + "' checked><label for='" + strShapeName + strChkBox + "'>" + strShapeName + "</label><br>\n";
		strOutput += "<INPUT type='checkbox' name='" + strShapeText + strChkBox + "' id='" + strShapeText + strChkBox + "' checked><label for='" + strShapeText + strChkBox + "'>" + strShapeText + "</label><br>\n";
		strOutput += "<INPUT type='checkbox' name='" + strProps + strChkBox + "' id='" + strProps + strChkBox + "' onclick='AdvSearchCustomPropCheck ()'checked ><label for='" + strProps + strChkBox + "'>" + strProps +"</label><br>\n";
		strOutput += "<div id='divCPBoxes' style='margin-left:1em;'>";
		
		var objNodes = parent.xmlData.selectNodes(".//Shape/Prop/Label");
		var filter = "";
		var boolFirstPass = true;
		var tmpPropName;
		while( objNodes.length > 0)
		{
			tmpPropName = objNodes.item( 0 ).text;
			var escapedPropName = parent.EscapeString(tmpPropName);
			if( true == boolFirstPass )
			{
				filter = ". != '" + escapedPropName + "'";
				boolFirstPass = false;
			}
			else
			{
				filter += " and . != '" + escapedPropName + "'";
			}

			tmpPropName = parent.HTMLEscape (tmpPropName);
			strOutput += "<INPUT type='checkbox' name='" + tmpPropName + strPropChkBox + "' id='"+ tmpPropName + strPropChkBox + "' checked><label for='"+ tmpPropName + strPropChkBox + "'>" + tmpPropName +"</label><br>\n";

			objNodes = parent.xmlData.selectNodes(".//Shape/Prop/Label["+ filter + "]");
		}
		strOutput += "</div>"
		div.innerHTML = strOutput;
	}
}

function AdvSearchCustomPropCheck ()
{
	for( count=0; count < document.theForm.length; count++ )
	{
		indexOfString = document.theForm[count].name.indexOf(strPropChkBox);
		if( -1 != indexOfString )
		{
			document.theForm[count].disabled = !document.theForm[strProps + strChkBox].checked;
		}
	}
}


function CResultItem(title, pageID, shapeID, pinX, pinY)
{
	 this["Title"] = title;
	 this["PageID"] = pageID;
	 this["ShapeID"] = shapeID;
	 this["PinX"] = pinX;
	 this["PinY"] = pinY;
}

function FindParentPage(nodeObject)
{
	if(nodeObject == null)
	{
		return null;
	}
	if(nodeObject.baseName == "Page")
		return nodeObject;
	else
		return FindParentPage(nodeObject.parentNode);
}

function QueryStringForMatch(shapeNode, regTextForFind, filterString)
{
	if (filterString.length > 0)
	{
		var nodesToCheck = shapeNode.selectNodes(filterString);

		var nodeCount = nodesToCheck.length;
		var stringToParse;
		for(var ncount = 0; ncount < nodeCount; ncount++)
		{
			stringToParse = nodesToCheck.item(ncount).text;
			stringToParse = stringToParse.toLowerCase ();
			if(stringToParse.indexOf(regTextForFind) > -1)
			{
				return true;
			}
		}
	}
}

function GetShapeTitle(shapeNode)
{
	var objTempName = null;
	var objTempTextElement = shapeNode.selectSingleNode("./Text");
	if(objTempTextElement != null)
	{
		var objTextNode = objTempTextElement.selectSingleNode("textnode()");
		if (objTextNode != null)
		{
			return parent.HTMLEscape (objTextNode.text);
		}
	}

	objTempName = shapeNode.selectSingleNode("./@Name");
	if(objTempName != null)
	{
		return parent.HTMLEscape (objTempName.text);
	}

	return "";
}

function GetPageTitle(pageID)
{
	var pagesObj = parent.xmlData.selectSingleNode("VisioDocument/Pages");
	if(!pagesObj)
	{
		return "";
	}

	var pageQuerryString = './/Page[@ID = "' + pageID + '"]';
	var pageObj = pagesObj.selectSingleNode(pageQuerryString);
	if(!pageObj)
	{
		return "";
	}

	var pageNameNode = pageObj.selectSingleNode("@Name");
	if(!pageNameNode)
	{
		return "";
	}
	return pageNameNode.text;
}

function Find(searchTokensArray, propsToSearchArray)
{
	var bXMLNotValid = false;
	var findArray = new Array();
	var findIndex = 0;

	if (parent.xmlData != null && searchTokensArray.length > 0)
	{
		var fieldsToSearchArray = new Array();
		var filterString = "";
		if( null != propsToSearchArray &&
			propsToSearchArray.length > 0 )
		{
			var propFilterString = "";
			for( var count=0; count< propsToSearchArray.length; count++ )
			{
				if( count == 0 )
				{
					propFilterString = "[. = '" + parent.EscapeString (propsToSearchArray[count]) + "'";
				}
				else
				{
					propFilterString += " or . = '"+ parent.EscapeString (propsToSearchArray[count]) + "'";
				}
			}
			propFilterString += "]";

			fieldsToSearchArray[fieldsToSearchArray.length] = "Prop[Label"+ propFilterString +"]/Value";
		}

		if (document.theForm[strShapeText + strChkBox].checked)
		{
			fieldsToSearchArray[fieldsToSearchArray.length] = "Text";
		}

		if (fieldsToSearchArray.length > 0)
		{
			filterString = "(.//(";

			for (var fieldCount = 0; fieldCount < fieldsToSearchArray.length; fieldCount++)
			{
				if (fieldCount != 0)
				{
					filterString += " | ";
				}

				filterString += fieldsToSearchArray[fieldCount];
			}

			filterString += ")/textnode())";
		}

		var objShapeNodes;

		if (document.theForm[strShapeName + strChkBox].checked)
		{
			if (filterString.length > 0)
			{
				filterString += " | ";
			}
			filterString += "(@Name)";

			var objShapeNodes = parent.xmlData.selectNodes(".//Shape");
		}
		else
		{
			var objShapeNodes = parent.xmlData.selectNodes(".//Shape[(Prop/Value | Prop/Label | Text)]");
		}

		var shapeCount = objShapeNodes.length;
		var objTempData = new CResultItem("A Label","PageID","ShapeID","PinX","PinY");
		var objTempShape = null;

		for (count = 0; count < shapeCount; count++)
		{		
			objTempShape = objShapeNodes.item(count);

			var objParentPageNode = FindParentPage(objTempShape);
			if (objParentPageNode == null)
			{
				continue;
			}

			var objPageIDNode = objParentPageNode.selectSingleNode("@ID/textnode()");
			if(objPageIDNode == null)
			{
				continue;
			}
			var pageID = objPageIDNode.text;

			var pageIndex = parent.PageIndexFromID (pageID);
			if (pageIndex < 0)
			{
				continue;
			}

			var objLayerMember = objTempShape.selectSingleNode("LayerMem/LayerMember");
			if (objLayerMember != null && objLayerMember.text.length > 0)
			{
				var layerArray = objLayerMember.text.split (';');
				var visibleLayer = false;
				for (var layerCount = 0; (layerCount < layerArray.length) && !visibleLayer; layerCount++)
				{
					var objLayerVisible = objParentPageNode.selectSingleNode("Layer[@IX=" + layerArray[layerCount] + "]/Visible");
					if (objLayerVisible != null)
					{
						 visibleLayer = (objLayerVisible.text != 0);
					}
				}
				
				if (!visibleLayer)
				{
					continue;
				}
			}

			for (var tokenCount = 0; tokenCount < searchTokensArray.length; tokenCount++)
			{
				var textToFind = searchTokensArray[tokenCount];
				textToFind = textToFind.toLowerCase ();

				if (QueryStringForMatch(objTempShape, textToFind, filterString))
				{
					objTempData.Title = GetShapeTitle(objTempShape);
					objTempData.PageID = pageID;

					objShapeIDNode = objTempShape.selectSingleNode("@ID/textnode()");
					if(objShapeIDNode == null)
					{
						bXMLNotValid = true;
						break;
					}
					objTempData.ShapeID = objShapeIDNode.text;
					objPinXNode = objTempShape.selectSingleNode("XForm/PinX/textnode()");
					if(objPinXNode == null)
					{
						bXMLNotValid = true;
						break;
					}
					objTempData.PinX = objPinXNode.text;
					objPinYNode = objTempShape.selectSingleNode("XForm/PinY/textnode()");
					if(objPinYNode == null)
					{
						bXMLNotValid = true;
						break;
					}
					objTempData.PinY = objPinYNode.text;

					findArray[findIndex] = new CResultItem(objTempData.Title, objTempData.PageID, objTempData.ShapeID, objTempData.PinX, objTempData.PinY);
					findIndex++;
					break;
				}
			}
		}
		if(bXMLNotValid)
		{
			findArray.length = 0;
		}
	}

	return findArray;
}

function FindQuerySelect(pageID, shapeID, pinX, pinY)
{
	if (widgets.GoTo && (parent.g_FileList[document.all("Select1").value].PageID != pageID))
	{
		parent.g_callBackFunctionArray[parent.g_callBackFunctionArray.length] = function () { parent.viewMgr.put_Location (pageID, shapeID, pinX, pinY); };
		parent.GoToPageByID(pageID);
	}
	else 
	{
		if (parent.viewMgr != null)
		{
			parent.viewMgr.put_Location (pageID, shapeID, pinX, pinY);
		}
	}
}

function TreeSelect(pageID, shapeID)
{
	var shapeNode = FindShapeXML (pageID, shapeID);
	if (shapeNode != null)
	{
		var pinXNode = shapeNode.selectSingleNode("XForm/PinX/textnode()");
		var pinYNode = shapeNode.selectSingleNode("XForm/PinY/textnode()");

		if (pinXNode != null && pinYNode != null)
		{
			FindQuerySelect (pageID, shapeID, pinXNode.text, pinYNode.text);
		}
	}
}


var g_RowStyleList = parent.g_RowStyleList;
var FillPropPane = parent.FillPropPane;
var CreatePropTable = parent.CreatePropTable;


// SIG // Begin signature block
// SIG // MIIXNAYJKoZIhvcNAQcCoIIXJTCCFyECAQExCzAJBgUr
// SIG // DgMCGgUAMGcGCisGAQQBgjcCAQSgWTBXMDIGCisGAQQB
// SIG // gjcCAR4wJAIBAQQQEODJBs441BGiowAQS9NQkAIBAAIB
// SIG // AAIBAAIBAAIBADAhMAkGBSsOAwIaBQAEFAaJ0KyTu99e
// SIG // uEaVCk9qqbqX4zjaoIISMTCCBGAwggNMoAMCAQICCi6r
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
// SIG // Gt8oHrRR8nfgJuO7CYES3B460EUxggRvMIIEawIBATCB
// SIG // hzB5MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGlu
// SIG // Z3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMV
// SIG // TWljcm9zb2Z0IENvcnBvcmF0aW9uMSMwIQYDVQQDExpN
// SIG // aWNyb3NvZnQgQ29kZSBTaWduaW5nIFBDQQIKYQHPPgAA
// SIG // AAAADzAJBgUrDgMCGgUAoIGaMBkGCSqGSIb3DQEJAzEM
// SIG // BgorBgEEAYI3AgEEMBwGCisGAQQBgjcCAQsxDjAMBgor
// SIG // BgEEAYI3AgEVMCMGCSqGSIb3DQEJBDEWBBTZReX2O+Gl
// SIG // UbtFJX7AkZYRAHjMFzA6BgorBgEEAYI3AgEMMSwwKqAQ
// SIG // gA4AZgBpAG4AZAAuAGoAc6EWgBRodHRwOi8vbWljcm9z
// SIG // b2Z0LmNvbTANBgkqhkiG9w0BAQEFAASCAQCDDNOPpe4F
// SIG // LmFTkErohx8HED4T8BBnEZ17FnhxN5Pjm6RUqL37D4a6
// SIG // 7cOlMl3SS91zIQxy6kb5/s7vKdiBcHCzf+k3pplmuySY
// SIG // XSKYIoQ2OG3B6yAo6F/488DVcoEZ+K1UmGgu94IEn5Rn
// SIG // OrjoiqtEHBbe/OACk+VkyhmdJpwD1ayIGjvFTzUIsJ04
// SIG // SmStmHMaKVzSIJmCYOHoXl4DEOcK5gfA38uJuO2U4F7I
// SIG // SKoJDWHnM0PZlXtx5iutQF4yda1KcidbGhsPUTZE6qi5
// SIG // KvLh5xR50k0ue8WM90h0dNl6xnj3IW2VuvfAnImrMWWb
// SIG // NvhXhq4r12/JtIBjKHt4uqaaoYICHzCCAhsGCSqGSIb3
// SIG // DQEJBjGCAgwwggIIAgEBMIGHMHkxCzAJBgNVBAYTAlVT
// SIG // MRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdS
// SIG // ZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9y
// SIG // YXRpb24xIzAhBgNVBAMTGk1pY3Jvc29mdCBUaW1lc3Rh
// SIG // bXBpbmcgUENBAgphBpQtAAAAAAAJMAcGBSsOAwIaoF0w
// SIG // GAYJKoZIhvcNAQkDMQsGCSqGSIb3DQEHATAcBgkqhkiG
// SIG // 9w0BCQUxDxcNMTAwMzIwMTc1MTE1WjAjBgkqhkiG9w0B
// SIG // CQQxFgQUycY99uXUQbotP1V5Dp08Fyyn4j8wDQYJKoZI
// SIG // hvcNAQEFBQAEggEAX750YF/G11UspWRSw7DpcgCLAyyC
// SIG // aZY5n0QuGKSKIY4OM6i3GBaEPSep/i7YivAVJ/JcZCLh
// SIG // lo8b5k/ebHBqWh2zrPqaAGO/jFL58PyvqWQ2viz02oNJ
// SIG // t1297iQIOmZ7DNb/Djwz2eubR241PCaexoUHlzCYiwCa
// SIG // bBsfRj+HkW0LPOGJHOnupurwsJfgYo5MqbeHLb4XWHVH
// SIG // joCE+ac99dyvPwMNxwJVHyBp3s11+d4L7YCKn1Fg3VF0
// SIG // 6BZws4xbGEemZVu63YdUxAKDOXcypW1X+wHJC0bunJv7
// SIG // Xgx4bdN2bNmzeUS5gn1eK1S+GkTL0Oem9HQrhoP0Y9KI
// SIG // LLaQUQ==
// SIG // End signature block
