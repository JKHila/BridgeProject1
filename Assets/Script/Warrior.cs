using UnityEngine;
using System.Collections;

public class Warrior : MonoBehaviour {

	SpriteRenderer sr;
	public Sprite[] sp = new Sprite[3];
	public float speed;

	// Use this for initialization
	void Start () {
		sr = transform.GetComponent<SpriteRenderer> ();
		StartCoroutine (moveAction ());
	}
	IEnumerator moveAction(){
		while (true) {
			for (int i = 0; i < 3; i++) {
				sr.sprite = sp [i];
				yield return new WaitForSeconds (0.1f);
			}
			sr.sprite = sp [1];
			yield return new WaitForSeconds (0.1f);
		}
	}
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * speed);
	}
}
