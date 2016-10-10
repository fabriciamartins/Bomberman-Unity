using UnityEngine;
using System.Collections;
using System.Threading;

public class Play1 : MonoBehaviour {

	float _velocidade = 6;
	public GameObject bomba;
	public GameObject explosao;
	public GameObject playExplodindo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("right")) {
			transform.Translate ((_velocidade * Time.deltaTime), 0, 0);
		} else if (Input.GetKey ("left")) {
			transform.Translate ((-_velocidade * Time.deltaTime), 0, 0);
		} else if (Input.GetKey ("up")) {
			transform.Translate (0, (_velocidade * Time.deltaTime), 0);
		} else if (Input.GetKey ("down")) {
			transform.Translate (0, (-_velocidade * Time.deltaTime), 0);
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
		explosao.transform.position = new Vector3 (bomba.transform.position.x, bomba.transform.position.y, (float)-0.06);
		Instantiate (explosao);
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Inimigo") || other.CompareTag("Explosao")) {
			playExplodindo.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y,(float)-0.06);
			Destroy(gameObject);
			Instantiate (playExplodindo);
			Application.LoadLevel(Application.loadedLevel);
		}
	}

}
