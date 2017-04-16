using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    private GameController gameController;
    private PlayerController playerController;

    void Start()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();     
    }

    void OnTriggerExit(Collider other)
	{
        gameController.decNumBolts();
        Destroy(other.gameObject);
        gameController.ResetTimer();
    }
}