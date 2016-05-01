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
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Slime") {
			coll.gameObject.GetComponent<Moving> ().Jump ();
			StartCoroutine (bound());
		}

	}
}
