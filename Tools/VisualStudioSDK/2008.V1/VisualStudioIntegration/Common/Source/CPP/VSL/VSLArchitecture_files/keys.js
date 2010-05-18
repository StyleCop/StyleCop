
function keyHandler()
{
	var e = window.event;
	var tag = e.srcElement.tagName;
	var override = !(tag == "A" || tag == "INPUT" || tag == "SELECT" || tag == "FORM" || tag == "SUBMIT");
	
	if(override && e.keyCode == 13) //13 is <enter> key
	{
		e.srcElement.click();
	}
}

document.onkeypress = keyHandler;
