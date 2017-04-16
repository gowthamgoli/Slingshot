using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBolt_Opponent : MonoBehaviour{

    public GameObject explosion;
    private GameController gameController;
    private PlayerController playerController;

    void Start()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bolt")
        {
            GameObject explosionClone = Instantiate(explosion, other.transform.position, other.transform.rotation);
            gameController.decNumBolts();
            Destroy(other.gameObject);
            gameController.ResetTimer();
            Destroy(explosionClone, 2.0f);
            gameObject.GetComponent<OpponentController>().DecreaseHealth();
        }
    }
}
