using UnityEngine;
using System.Collections;

public class Jumping : MonoBehaviour {
	public Sprite[] sp;

	private SpriteRenderer sr;
	private bool isAct;
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Article" && coll.name != "Wall(Clone)") {
			isAct = true;
			transform.position = new Vector2 (coll.transform.position.x, coll.transform.position.y + 0.7f);
		} else if (coll.tag == "Slime") {
			StartCoroutine (spring (coll));
		}
	}
	IEnumerator spring(Collider2D coll){
		
		yield return new WaitForSeconds (0.05f);
		for (int i = 0; i < 6; i++) {
			sr.sprite = sp [i];
			yield return new WaitForSeconds (0.05f);
			if (i == 0) {
				coll.GetComponent<Moving> ().boardJump ();
				coll.GetComponent<Slime> ().setJump ();
			}
		}
		coll.GetComponent<Slime> ().setJump ();
		sr.sprite = sp [0];

	}
	IEnumerator checkColl(){
		yield return new WaitForSeconds (0.1f);
		if (!isAct && GetComponent<BoxCollider2D>().isActiveAndEnabled) {
			Destroy (this.gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<BoxCollider2D> ().isActiveAndEnabled) {
			StartCoroutine (checkColl ());
		}
	}
}
