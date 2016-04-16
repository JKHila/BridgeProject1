using UnityEngine;
using System.Collections;

public class HitArea : MonoBehaviour {
	public GameObject Warrior;
	GameObject tmpObj;
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Slime" && tmpObj != coll.gameObject) {
			coll.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 100 * Warrior.GetComponent<Moving>().speed ,ForceMode2D.Impulse);
			coll.gameObject.GetComponent<Slime> ().StartCoroutine ("dieAction");
			tmpObj = coll.gameObject;
		}
	}
	// Use this for initialization
	void Start () {
		Warrior = GameObject.FindWithTag("Warrior");
	}
	
	// Update is called once per frame
	void Update () {
		if (Warrior.GetComponent<Moving>().speed > 0) {
			GetComponent<CircleCollider2D> ().offset = new Vector2 (0.39f, -0.45f);
		} else {
			GetComponent<CircleCollider2D> ().offset = new Vector2 (-0.38f, -0.45f);
		}
	}
}
