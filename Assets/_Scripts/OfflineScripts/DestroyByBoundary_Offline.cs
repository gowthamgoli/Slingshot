using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary_Offline : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        ////gameController.decNumBolts();
        Destroy(other.gameObject);
        //gameController.ResetTimer();
    }
}
