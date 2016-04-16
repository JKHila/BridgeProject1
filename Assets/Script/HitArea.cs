using UnityEngine;
using System.Collections;

public class HitArea : MonoBehaviour {
	public GameObject Warrior;
	GameObject tmpObj;
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Slime" && tmpObj != coll.gameObject) {
			coll.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 100 * Warrior.GetComponent<Moving> ().speed, ForceMode2D.Impulse);
			coll.gameObject.GetComponent<Slime> ().StartCoroutine ("dieAction");
			tmpObj = coll.gameObject;
		} else {
			//Warrior.
		}
	}
	// Use this for initialization
	void Start () {
		Warrior = GameObject.FindWithTag("Warrior");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
