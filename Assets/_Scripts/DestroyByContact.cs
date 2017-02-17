using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	void OnTriggerEnter(Collider other)
	{
		if(other.tag != "Boundary"){
			GameObject explosionClone = Instantiate (explosion, other.transform.position, other.transform.rotation);
			//Destroy(explosion.gameObject, 5.0f);
			Destroy(other.gameObject);
			Destroy (explosionClone, 2.0f);
		}
	}
}