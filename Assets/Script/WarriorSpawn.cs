using UnityEngine;
using System.Collections;

public class WarriorSpawn : MonoBehaviour {
	public float spawnDelay;
	public GameObject Warrior;
	public GameObject slimes;
	public Sprite[] warriorSpawnSp;
	public SpriteRenderer WarriorSpawnSr;
	// Use this for initialization
	IEnumerator warriorSpawnAni(){
		yield return new WaitForSeconds (spawnDelay);
		for (int i = 0; i < 16; i++) {
			WarriorSpawnSr.sprite = warriorSpawnSp [i];
			yield return new WaitForSeconds (0.1f);
			if (i == 8) {
				GameObject tmp2 = (GameObject)Instantiate (Warrior, new Vector2 (transform.position.x, transform.position.y), this.transform.rotation);
				tmp2.transform.SetParent (slimes.transform);
			}
		}

	}
	void Start () {
		WarriorSpawnSr = GetComponent<SpriteRenderer> ();
		slimes = GameObject.Find ("MovingObj");
		StartCoroutine (warriorSpawnAni ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
