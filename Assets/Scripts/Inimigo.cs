using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {

	public GameObject inimigoMorto;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Explosao")) {
			inimigoMorto.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y,(float)-0.06);
			Destroy(gameObject);
			Instantiate (inimigoMorto);
		}
	}
		
}
