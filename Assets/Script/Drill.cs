using UnityEngine;
using System.Collections;

public class Drill : MonoBehaviour {
	public bool isAct = false;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Article") {
			isAct = true;
			Destroy (coll.gameObject);
			Destroy (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

	IEnumerator checkColl(){
		yield return new WaitForSeconds (0.1f);
		if (!isAct && GetComponent<CircleCollider2D>().isActiveAndEnabled) {
			Destroy (this.gameObject);
		}
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<CircleCollider2D> ().isActiveAndEnabled) {
			StartCoroutine (checkColl ());
		}
	}
}
