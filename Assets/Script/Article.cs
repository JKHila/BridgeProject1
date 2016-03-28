using UnityEngine;
using System.Collections;

public class Article : MonoBehaviour {

	private float speed =-0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * speed);
	}
}
