using UnityEngine;
using System.Collections;

public class StartGameScript : MonoBehaviour {
   

    public GameObject vineWalls;
    public GameObject spawn;
    public GameObject finish;
    int levelCounter;
    bool changeLevel;
    public Quaternion verticalTilt;
    int currentLevel;

    // Use this for initialization
    void Start ()
    {
       
            Screen.SetResolution(1600, 900, true);

    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    
    void LevelReciver(int weAreAt)
    {
        levelCounter = weAreAt;
        changeLevel = true;
    }
}
