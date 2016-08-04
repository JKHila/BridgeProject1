using UnityEngine;
using System.Collections;

public class Cushion : MonoBehaviour {
	//public Animator anim;
	// Use this for initialization
	//private GameObject tmpObj;
	public  bool tutoCheck;
	public Sprite[] sp = new Sprite[9];

	SpriteRenderer sr;
	IEnumerator bound(){
		for(int i = 0;i<9;i++){
			sr.sprite = sp [i];
			yield return new WaitForSeconds (0.05f);
		}
	}
	IEnumerator checkDelay(){
		yield return new WaitForSeconds (0.1f);
		if (!tutoCheck) {
			Destroy (this.gameObject);
			GameObject.Find("Main Camera").SendMessage("canceledItem");
		} else {
			Tutorial.isCushionCo = false;
			GameObject.Find("Main Camera").SendMessage("initIcon");
		}
	}
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		if (Handler.isTuto) {
			StartCoroutine (checkDelay ());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (Handler.isTuto && coll.gameObject.name == "CushionCheck") {
			tutoCheck = true;
		}
		if (coll.gameObject.tag == "Slime") {
			Debug.Log (coll.GetComponent<Rigidbody2D> ().velocity.y);
			if (coll.GetComponent<Rigidbody2D> ().velocity.y < 0.0f) {
				coll.gameObject.GetComponent<Moving> ().Jump ();
				StartCoroutine (bound ());
			}
		}

	}
}
