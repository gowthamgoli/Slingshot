using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	void OnTriggerEnter(Collider other)
	{
		if(other.tag != "Boundary"){
			Instantiate (explosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
		}
	}
}