using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact_Offline : MonoBehaviour {
    public GameObject explosion;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            GameObject explosionClone = Instantiate(explosion, other.transform.position, other.transform.rotation);
            //gameController.decNumBolts();
            Destroy(other.gameObject);
            //gameController.ResetTimer();
            Destroy(explosionClone, 2.0f);
        }
    }
}
