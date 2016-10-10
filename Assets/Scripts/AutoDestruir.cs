using UnityEngine;
using System.Collections;

public class AutoDestruir : MonoBehaviour {

	public float Delay = 2f;

	// Use this for initialization
	void Start() {
		Destroy(gameObject, Delay);
	}
}
