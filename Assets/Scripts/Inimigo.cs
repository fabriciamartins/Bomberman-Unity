using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {

	public GameObject inimigoMorto;
	public float rotation;
	public float _velocidade = 0.000002f;
	public bool eixo_y_positivo = false;
	public bool eixo_y_negativo = false;
	public bool eixo_x_positivo = true;
	public bool eixo_x_negativo = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (Andar ());
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log (other.tag);
		if (other.CompareTag ("Explosao")) {
			inimigoMorto.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y,(float)-0.06);
			Destroy(gameObject);
			Instantiate (inimigoMorto);
		}
		if (other.CompareTag ("Bloco")) {
			DecidirMovimento ();
		}
	}

	private void DecidirMovimento(){
		if (eixo_y_positivo) {
			eixo_y_positivo = false;
			eixo_y_negativo = true;
		} else if (eixo_y_negativo) {
			eixo_y_negativo = false;
			eixo_x_positivo = true;
		} else if (eixo_x_positivo) {
			eixo_x_positivo = false;
			eixo_x_negativo = true;
		} else if (eixo_x_negativo) {
			eixo_x_negativo = false;
			eixo_y_positivo = true;
		}
	}

	private IEnumerator Andar(){
		yield return new WaitForSeconds(0.5f);
		if (eixo_y_positivo) {
			transform.Translate (0, (_velocidade * Time.deltaTime)/2, 0);
		} else if (eixo_y_negativo) {
			transform.Translate (0, (-_velocidade * Time.deltaTime)/2, 0);
		} else if (eixo_x_positivo) {
			transform.Translate ((_velocidade * Time.deltaTime)/2, 0, 0);
		} else if (eixo_x_negativo) {
			transform.Translate ((-_velocidade * Time.deltaTime)/2, 0, 0);
		}
	}
		
}
