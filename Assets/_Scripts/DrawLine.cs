using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    private LineRenderer line;
    private bool isMousePressed;
    public List<Vector3> pointsList;
    private Vector3 mousePos;

    void Awake()
    {
        // Create line renderer component and set its property
        //line = gameObject.AddComponent<LineRenderer>();
        //line.material = new Material(Shader.Find("Particles/Additive"));
        
        //        renderer.material.SetTextureOffset(
    }

	// Use this for initialization
	void Start () {
        line = gameObject.GetComponent<LineRenderer>();
        line.numPositions = 0;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.startColor = Color.green;
        line.endColor = Color.green;
        line.useWorldSpace = true;
        isMousePressed = false;
        pointsList = new List<Vector3>();
    }
	
	// Update is called once per frame
	void Update () {
        pointsList.Add(transform.position);
        line.numPositions = pointsList.Count;
        line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);

    }
}
