using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {
    private Camera mainCamera;
    private Camera secondaryCamera;
	// Use this for initialization
	void Start () {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        secondaryCamera = GameObject.Find("Secondary Camera").GetComponent<Camera>();
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 posMainCamera = mainCamera.WorldToViewportPoint(transform.position);
        Vector3 posSecCamera = secondaryCamera.WorldToViewportPoint(transform.position);

        if ((posMainCamera.x < 0 || posMainCamera.x > 1.0f || posMainCamera.y < 0 || posMainCamera.y > 1.0f))
        {
            if (!secondaryCamera.enabled)
            {
                secondaryCamera.enabled = true;
                mainCamera.enabled = false;
            }

            if (posSecCamera.x < 0 || posSecCamera.x > 1.0f || posSecCamera.y < 0 || posSecCamera.y > 1.0f)
            {
                if (!mainCamera.enabled)
                {
                    mainCamera.enabled = true;
                    secondaryCamera.enabled = false;
                }
            }
        }

        else if (secondaryCamera.enabled)
        {
            mainCamera.enabled = true;
            secondaryCamera.enabled = false;
        }
    }
}
