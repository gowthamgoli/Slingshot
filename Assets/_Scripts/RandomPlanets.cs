using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlanets : MonoBehaviour {

    public int minPlanets = 2;
    public  int maxPlanets = 4;
    private int numPlanets;

    public float minX = -4.0f;
    public float maxX = 4.0f;
    public float minY = -2.5f;
    public float maxY = 2.5f;
    public float minScale = 1.5f;
    public float maxScale = 3.75f;
    private float posX;
    private float posY;
    private float scale;
    public float offset = 0.5f;

    public GameObject planetPrefab;
    private List<GameObject> planets;

    private List<int> ranges; 

    // Use this for initialization
    void Start()
    {
        planets = new List<GameObject>();
        numPlanets = Random.Range(minPlanets, maxPlanets);
        if (numPlanets == 2){
            ranges = new List<int>() {1, 2};
        }
        else if (numPlanets == 3){
            ranges = new List<int>() {0, 1, 2};
        }
        else {
            ranges = new List<int>() {0, 1, 1, 2 };
        }
        //numPlanets = 3;
        if (numPlanets == 2) offset = 4.0f;
        else if (numPlanets == 3) offset = 2.5f;
        else if (numPlanets == 4) offset = 1.0f;

        int k = 0;
        //Debug.Log("num planets " + numPlanets);
        while (planets.Count != numPlanets) {
            posX = Random.Range(minX, maxX);
            posY = Random.Range(minY, maxY);

            if (ranges[k] == 0) scale = Random.Range(minScale, 2.0f);
            else if (ranges[k] == 1) scale = Random.Range(2.0f, 2.75f);
            else if (ranges[k] == 2) scale = Random.Range(2.75f, 3.75f);

            //Debug.Log("x: " + posX + " y: " + posY + " scale: " + scale);
            if(positionIsValid(posX, posY, planets, scale)){
                //Debug.Log("Valid position");
                GameObject planet = Instantiate(planetPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                planet.transform.localScale = new Vector3(scale, scale, scale);
                planets.Add(planet);
                k++;
            }

        }
    }

    public bool positionIsValid(float x, float y, List<GameObject> planets, float scale) {
        float radius, myRadius;
        
        if (planets.Count == 0) {
            return true;
        }
        Vector3 myPos = new Vector3(x, y, 0);
        for (int i = 0; i < planets.Count; i++) {
            radius = 0.5f * planets[i].transform.localScale.x;
            myRadius = 0.5f * scale;
            //Debug.Log("radius  " + i + " : " + radius);
            if(Vector3.Distance(myPos, planets[i].transform.position) < radius + myRadius + offset){
                return false;
            }         
        }
        //Debug.Log("Not Valid position");
        return true;
    }
}
