using UnityEngine;
using System.Collections;

public class Slime : Moving {
	private float curY;  
	private bool isJump=false;
	private bool isTemp = false;

	SpriteRenderer sr;
	public Sprite[] sp = new Sprite[3];
	public Sprite[] die = new Sprite[6];
	public GameObject checkArea;
	public GameObject handler;
	public float getCurY(){
		return curY;
	}
	public void setJump(){
		if (isJump) {
			isJump = false;
		} else {
			isJump = true;
		}
	}
	public bool getJump(){
		return isJump;
	}
	// Use this for initialization
	void Start () {
		sr = transform.GetComponent<SpriteRenderer> ();
		handler = GameObject.Find ("Main Camera");
		curY = transform.position.y;
		StartCoroutine ("moveAction");
	}
    IEnumerator stopping()
    {
        yield return new WaitForSeconds(0.5f);
        base.speed = 0;
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
	IEnumerator dieAction(){
		base.isAlive = false;
		handler.GetComponent<Handler>().addDieCnt ();
		StopCoroutine ("moveAction");
		for (int i = 0; i < 6; i++) {
			sr.sprite = die [i];
			yield return new WaitForSeconds (0.1f);
		}
		this.gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		MovingFunc ();
		if (base.speed > 0) {
			checkArea.GetComponent<BoxCollider2D>().offset = new Vector2 (0.32f, 0);
		} else {
			checkArea.GetComponent<BoxCollider2D>().offset = new Vector2 (-0.32f, 0);
		}
		if (transform.position.y < -20) {
			handler.GetComponent<Handler> ().addDieCnt ();
			Destroy (this.gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D coll){ ///checkArea에 충돌
		if (coll.tag == "Article") {
			base.moveBack ();
		} else if (coll.tag == "grab") {
			StartCoroutine (stopping ());
		} else if (coll.gameObject.tag == "temp") {
			isTemp = true;
			base.speed = 0;
			transform.Translate (Vector2.right * -0.1f);
			Debug.Log (base.speed);
		} else {
			curY = transform.position.y;
		}
	}
	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag != "cushion" && coll.gameObject.tag != "temp" || coll.gameObject.tag == "Jumping") {
			
			if (isTemp) {
				base.speed = 1.5f;
				isTemp = false;
			}
			if (transform.position.y < curY && curY - transform.position.y > 2.1f) {
				Debug.Log ("VVA");
				base.isAlive = false;
				base.speed = 0;
				StartCoroutine (dieAction());
			}
			curY = transform.position.y;
		}
		else {
			curY = transform.position.y;
		}
	}
}
