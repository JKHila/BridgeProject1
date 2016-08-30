using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour {
	public GameObject[] rope = new GameObject[2];
	//private ArrayList collList = new ArrayList();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D coll){
		if(!rope[0].activeSelf && !rope[1].activeSelf && coll.gameObject.tag == "Article"){
			GetComponent<Rigidbody2D>().isKinematic = true;
		}
	}
	/*void OnCollisionExit2D(Collision coll){
		collList.Remove(coll.gameObject);
	}*/
}
