using UnityEngine;
using System.Collections;

public class Handler : MonoBehaviour {

	// Use this for initialization
	float BK_Boffset = 0.0f, BK_speed = 0.4f;
	float createTime = 0;

	public GameObject background;
	public GameObject Warrior;
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		BK_Boffset += (Time.deltaTime * BK_speed);
		background.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (BK_Boffset, 0);
	
		createTime += Time.deltaTime;
		if (createTime > 2) {
			Instantiate (Warrior, new Vector2 (-10.0f, 1.3f), this.transform.rotation);
			createTime = -5000;
		}
	}
}
