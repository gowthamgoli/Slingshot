using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;

    private GameController gameController;
    private PlayerController playerController;

    void Start()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        //playerController = GameObject.Find("Player 1(Clone)").GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
	{       
        if (other.tag != "Boundary"){
			GameObject explosionClone = Instantiate (explosion, other.transform.position, other.transform.rotation);
            gameController.decNumBolts();
            Destroy(other.gameObject);
            gameController.ResetTimer();
            Destroy (explosionClone, 2.0f);
		}
	}
}