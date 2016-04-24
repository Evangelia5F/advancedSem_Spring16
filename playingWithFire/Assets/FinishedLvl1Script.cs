using UnityEngine;
using System.Collections;

public class FinishedLvl1Script : MonoBehaviour {

    bool touching;
    GameObject gameholder;

	// Use this for initialization
	void Start () {
        touching = false;
        gameholder = GameObject.Find("GameHolder");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            touching = true;
            gameholder.SendMessage("LevelComplete", touching);
        }
        
    }
}
