using UnityEngine;
using System.Collections;

public class SlimeSpawn : MonoBehaviour {
    public int numOfSlime;
    public int direct=1;
    public GameObject Slime;
    public GameObject slimes;
    public Sprite[] slimeSpawnSp;
    public SpriteRenderer slimeSpawnSr;
    IEnumerator CreateSlime()
    {
        for (int i = 0; i < numOfSlime; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                slimeSpawnSr.sprite = slimeSpawnSp[j];
                yield return new WaitForSeconds(0.05f);
            }
            slimeSpawnSr.sprite = slimeSpawnSp[0];
            //float a = Random.Range (-1.0f, 1.0f);
            GameObject tmp = (GameObject)Instantiate(Slime, new Vector2(transform.position.x + 1.4f, transform.position.y - 1.5f), this.transform.rotation);
            tmp.transform.SetParent(slimes.transform);
            if(direct < 0)
                tmp.GetComponent<Moving>().moveBack();
            //tmp.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 10,ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.1f);
        }
    }
    // Use this for initialization
    void Start () {
        slimeSpawnSr = GetComponent<SpriteRenderer>();
        StartCoroutine(CreateSlime());
        slimes = GameObject.Find("MovingObj");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
