using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBolt_Opponent : MonoBehaviour{

    public GameObject explosion;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bolt")
        {
            GameObject explosionClone = Instantiate(explosion, other.transform.position, other.transform.rotation);
            //Destroy(explosion.gameObject, 5.0f);
            Destroy(other.gameObject);
            Destroy(explosionClone, 2.0f);
            gameObject.GetComponent<OpponentController>().DecreaseHealth();
        }
    }
}
