using UnityEngine;
using System.Collections;
using System.Threading;

public class Play1 : MonoBehaviour {

	float _velocidadePositiva = 8;
	float _velocidadeNegativa = -8;
	public GameObject bomba;
	public GameObject explosao;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("right")) {
			transform.Translate ((_velocidadePositiva * Time.deltaTime), 0, 0);
		} else if (Input.GetKey ("left")) {
			transform.Translate ((_velocidadeNegativa * Time.deltaTime), 0, 0);
		} else if (Input.GetKey ("up")) {
			transform.Translate (0, (_velocidadePositiva * Time.deltaTime), 0);
		} else if (Input.GetKey ("down")) {
			transform.Translate (0, (_velocidadeNegativa * Time.deltaTime), 0);
		} else if (Input.GetKey ("space")) {
			CriarBomba ();
		}

	}

	private void CriarBomba()
	{
		bomba.transform.position = new Vector3 (transform.position.x, transform.position.y,(float)-0.06);
		//Método que irá instancias os obstaculos automaticamente
		Instantiate (bomba);
		StartCoroutine (TempoExplosao());
	}

	private IEnumerator TempoExplosao(){
		yield return new WaitForSeconds(3.0f);
		ExplodirBomba ();
	}

	private void ExplodirBomba(){
		explosao.transform.position = new Vector3 (bomba.transform.position.x, bomba.transform.position.y, (float)-0.07);
		Instantiate (explosao);
	}
}
