using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlanets_Offline : MonoBehaviour {

    // Use this for initialization
    public GameObject planetPrefab;
    public GameObject planetsParent;
    public Material[] planet_mats = new Material[4];
    Configuration[] t;
    Configuration obj;
    void Start()
    {
        obj = new Configuration();
        t = obj.getList();
        int i = Random.Range(0, t.Length);
        //if (p == 1) i = x;
        Configuration c = t[i];
        if (c.scale1 != 0.0f)
        {
            GameObject planet = Instantiate(planetPrefab, t[i].planet1, Quaternion.identity);
            planet.transform.localScale = new Vector3(t[i].scale1, t[i].scale1, t[i].scale1);
            planet.transform.GetComponent<Rigidbody>().mass = planet.transform.localScale.x * 75.0f;
            planet.transform.parent = planetsParent.transform;
            planet.transform.GetComponent<Renderer>().material = planet_mats[0];
        }

        if (c.scale2 != 0.0f)
        {
            GameObject planet = Instantiate(planetPrefab, t[i].planet2, Quaternion.identity);
            planet.transform.localScale = new Vector3(t[i].scale2, t[i].scale2, t[i].scale2);
            planet.transform.GetComponent<Rigidbody>().mass = planet.transform.localScale.x * 75.0f;
            planet.transform.parent = planetsParent.transform;
            planet.transform.GetComponent<Renderer>().material = planet_mats[1];
        }

        if (c.scale3 != 0.0f)
        {
            GameObject planet = Instantiate(planetPrefab, t[i].planet3, Quaternion.identity);
            planet.transform.localScale = new Vector3(t[i].scale3, t[i].scale3, t[i].scale3);
            planet.transform.GetComponent<Rigidbody>().mass = planet.transform.localScale.x * 75.0f;
            planet.transform.parent = planetsParent.transform;
            planet.transform.GetComponent<Renderer>().material = planet_mats[2];
        }

        if (c.scale4 != 0.0f)
        {
            GameObject planet = Instantiate(planetPrefab, t[i].planet4, Quaternion.identity);
            planet.transform.localScale = new Vector3(t[i].scale4, t[i].scale4, t[i].scale4);
            planet.transform.GetComponent<Rigidbody>().mass = planet.transform.localScale.x * 75.0f;
            planet.transform.parent = planetsParent.transform;
            planet.transform.GetComponent<Renderer>().material = planet_mats[3];
        }
        //return i;
    }
}
