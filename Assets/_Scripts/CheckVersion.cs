using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVersion : MonoBehaviour {

    void Start()
    {
        string url = "http://anujbora.com/slingshot/version.php";
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
            Debug.Log("Application version: " + Application.version);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
