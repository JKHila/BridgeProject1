using UnityEngine;
using System.Collections;

public class Jumping : MonoBehaviour {
	public Sprite[] sp;

	private SpriteRenderer sr;
	private bool isAct;
	private string objName;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Article" && coll.name ==objName) {
            StartCoroutine(setPos(coll));
            isAct = true;
		} else if (coll.tag == "Slime") {
			StartCoroutine (spring (coll));
		}
	}
    IEnumerator setPos(Collider2D coll)
    {
		if (Handler.isTuto) //when tutorial
			Tutorial.isJumpingCo = false;
        yield return new WaitForSeconds(0.1f);
		GameObject.Find("Main Camera").SendMessage("initIcon");
        transform.position = new Vector2(coll.transform.position.x, coll.transform.position.y + 0.7f);
    }
	IEnumerator spring(Collider2D coll){
		
		//yield return new WaitForSeconds (0.05f);
		if (coll.gameObject.GetComponent<Moving> ().isAlive) {
			for (int i = 0; i < 6; i++) {
				sr.sprite = sp [i];
				yield return new WaitForSeconds (0.05f);
				if (i == 0) {
					coll.GetComponent<Moving> ().boardJump ();
					coll.GetComponent<Slime> ().setJump ();
				}
			}
		}
		coll.GetComponent<Slime> ().setJump ();
		sr.sprite = sp [0];

	}
	IEnumerator checkColl(){
		yield return new WaitForSeconds (0.1f);
		if (!isAct && GetComponent<BoxCollider2D>().isActiveAndEnabled) {
			Destroy (this.gameObject);
            GameObject.Find("Main Camera").SendMessage("canceledItem");
        }
	}
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		if (!Tutorial.isJumpingCo)
			objName = "Land";
		else
			objName = "TuLand2";
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<BoxCollider2D> ().isActiveAndEnabled) {
			StartCoroutine (checkColl ());
		}
	}
}
