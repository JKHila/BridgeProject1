using UnityEngine;
using System.Collections;

public class Slime : MonoBehaviour {
	 
	SpriteRenderer sr;
	public Sprite[] sp = new Sprite[8];
	public float speed;
	// Use this for initialization
	void Start () {
		sr = transform.GetComponent<SpriteRenderer> ();
		StartCoroutine (moveAction ());
		 
	}
	IEnumerator moveAction(){
		while (true) {
			for (int i = 0; i < 4; i++) {
				sr.sprite = sp [i];
				yield return new WaitForSeconds (0.1f);
			}
		}
	}
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * speed);
	}
}
