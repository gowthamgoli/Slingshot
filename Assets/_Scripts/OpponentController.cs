using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour {

    public Material[] spaceCraftMaterials;

    private Quaternion _startRot;
    private Quaternion _destinationRot;
    private float _lastUpdateTime;
    private float _timePerUpdate = 0.16f;

    private bool opponentDestroyed;

    // Use this for initialization
    void Start () {
        _startRot = transform.rotation;
        opponentDestroyed = false;
    }
	
	// Update is called once per frame
	void Update () {
        // 1
        float pctDone = (Time.time - _lastUpdateTime) / _timePerUpdate;

        if (pctDone <= 1.0)
        {
           // 2
            transform.rotation = Quaternion.Slerp(_startRot, _destinationRot, pctDone);
        }
    }

    public void SetCarNumber(int carNum)
    {
        transform.FindChild("Player").GetComponent<Renderer>().material = spaceCraftMaterials[carNum - 1];
    }

    public void SetCarInformation(float rotZ)
    {
        //transform.position = new Vector3(posX, posY, 0);
        //transform.rotation = Quaternion.Euler(0, 0, 180f-rotZ);
        // We're going to do nothing with velocity.... for now

        //1
        _startRot = transform.rotation;
        //2
        _destinationRot = Quaternion.Euler(0, 0, 180f-rotZ);
        //3
        _lastUpdateTime = Time.time;
    }

    public bool GetOpponentDestroyed()
    {
        return opponentDestroyed;
    }

    public void SetOpponentDestroyed(bool val)
    {
        opponentDestroyed = val;
    }
}
