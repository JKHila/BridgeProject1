using UnityEngine;
using System.Collections;

public class WarriorWalkArea : MonoBehaviour {
	private bool isIn = false;
	private GameObject tmp;
	public GameObject warrior;
	void OnTriggerEnter2D(Collider2D coll){
		isIn = true;
		//Debug.Log (isIn);
	}
	void OnTriggerExit2D(Collider2D coll){
		
		//Debug.Log (isIn);
		StartCoroutine (outCheck());

	}
	IEnumerator outCheck(){
		yield return new WaitForSeconds (1f);
		if (isIn) {
			isIn = false;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		if (!isIn) {
			warrior.GetComponent<Moving> ().moveBack ();
		}
		
	}
}
