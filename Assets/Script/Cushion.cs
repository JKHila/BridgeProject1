using UnityEngine;
using System.Collections;

public class Cushion : MonoBehaviour {
	//public Animator anim;
	// Use this for initialization
	//private GameObject tmpObj;
	public Sprite[] sp = new Sprite[9];

	SpriteRenderer sr;
	IEnumerator bound(){
		for(int i = 0;i<9;i++){
			sr.sprite = sp [i];
			yield return new WaitForSeconds (0.05f);
		}
	}
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Slime") {
			if (coll.GetComponent<Rigidbody2D> ().velocity.y < 0.0f) {
				coll.gameObject.GetComponent<Moving> ().Jump ();
				StartCoroutine (bound ());
			}
		}

	}
}
