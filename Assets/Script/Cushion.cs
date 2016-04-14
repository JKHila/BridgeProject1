using UnityEngine;
using System.Collections;

public class Cushion : MonoBehaviour {
	//public Animator anim;
	// Use this for initialization
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
		//anim.SetTrigger ("collision");
		//StopCoroutine("bound");
		coll.gameObject.GetComponent<Moving> ().Jump ();
		StartCoroutine("bound");

	}
}
