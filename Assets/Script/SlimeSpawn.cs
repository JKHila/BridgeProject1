using UnityEngine;
using System.Collections;

public class SlimeSpawn : MonoBehaviour {
	public int delay = 0;
    public int numOfSlime;
    public int direct=1;
    public GameObject Slime;
    public GameObject slimes;
    public Sprite[] slimeSpawnSp;
    public SpriteRenderer slimeSpawnSr;
    IEnumerator CreateSlime()
    {
		yield return new WaitForSeconds (delay);
        for (int i = 0; i < numOfSlime; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                slimeSpawnSr.sprite = slimeSpawnSp[j];
                yield return new WaitForSeconds(0.05f);
            }
            slimeSpawnSr.sprite = slimeSpawnSp[0];
            //float a = Random.Range (-1.0f, 1.0f);
            float x;
            if (direct == 1)
                x = 0.6f;
            else
                x = -0.5f;
            GameObject tmp = (GameObject)Instantiate(Slime, new Vector2(transform.position.x+x, transform.position.y-0.6f ), this.transform.rotation);
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
