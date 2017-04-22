using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facebookShare : MonoBehaviour {

	private const string FACEBOOK_APP_ID = "1324186410993666";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";
	public string linkParameter;
	public string nameParameter;
	public string captionParameter;
	public string descriptionParameter;
	public string pictureParameter;
	public string redirectParameter;

	public void ShareToFacebook ()
	{
		Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
			"&link=" + WWW.EscapeURL(linkParameter) +
			"&name=" + WWW.EscapeURL(nameParameter) +
			"&caption=" + WWW.EscapeURL(captionParameter) + 
			"&description=" + WWW.EscapeURL(descriptionParameter) + 
			"&picture=" + WWW.EscapeURL(pictureParameter) + 
			"&redirect_uri=" + WWW.EscapeURL(redirectParameter));
	}
}
