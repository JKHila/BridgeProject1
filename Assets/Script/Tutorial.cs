using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {
    public GameObject pingImg;
    
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("isFirst") == 0)
        {
            pingImg.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("isFirst") == 0)
        {
            
        }

    }
}
