using UnityEngine;
using System.Collections;

public class Warrior : Moving {

	SpriteRenderer sr;
	public Sprite[] sp = new Sprite[3];

	// Use this for initialization
	void Start () {
		sr = transform.GetComponent<SpriteRenderer> ();
		StartCoroutine (moveAction ());
	}
	IEnumerator moveAction(){
		while (true) {
			for (int i = 0; i < 8; i++) {
				sr.sprite = sp [i];
				yield return new WaitForSeconds (0.1f);
			}
			//sr.sprite = sp [1];
			//yield return new WaitForSeconds (0.1f);
		}
	}
	// Update is called once per frame
	void Update () {
		MovingFunc ();
		/*Ray2D Ray;
		RaycastHit2D hit = Physics2D.Raycast (Ray.origin, Vector2.right);
		if (hit) {
			Debug.Log ("Sdf");
		}*/

	}

}
