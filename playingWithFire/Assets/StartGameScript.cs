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
    void Start () {
       
            Screen.SetResolution(1600, 900, true);
            levelCounter = 0;
            changeLevel = true;
            verticalTilt = Quaternion.Euler(new Vector3(0, 0, 90));
        
        

}
	
	// Update is called once per frame
	void Update () {

        //currentLevel = Application.loadedLevel;


        if (changeLevel == true)
        {
            Debug.Log("about to build");

            Debug.Log(levelCounter);
            if (levelCounter == 0)
            {
                Level1();
              
            }

            if (levelCounter == 1)
            {
                
                Level2();
            }

            if (levelCounter == 2)
            { 
            
            Level3();
            }

            changeLevel = false;
        }


	}

    

    void Level1()
    {

            Debug.Log("we at level 1 building");

            Instantiate(spawn, new Vector3(0f, -4.0f, 0), Quaternion.identity);
            Instantiate(vineWalls, new Vector3(0f, -4.5f, 0), verticalTilt);
            Instantiate(vineWalls, new Vector3(5.0f, -0.5f, 0), verticalTilt);
            Instantiate(vineWalls, new Vector3(-1.0f, -0.5f, 0), verticalTilt);
            Instantiate(vineWalls, new Vector3(-5.0f, -1.5f, 0), verticalTilt);
            Instantiate(finish, new Vector3(7.0f, -2.0f, 0f), Quaternion.identity);

        //if level1 == finished 
        //level counter ++
        //changeLevel = true
        changeLevel = false;
        levelCounter++;
    }

    void Level2()
    {
        Debug.Log("walls for level 2");
        changeLevel = false;
    }

    void Level3()
    {
        Debug.Log("walls for level 3");
        changeLevel = false;
    }

    void LevelReciver(int weAreAt)
    {
        levelCounter = weAreAt;
        changeLevel = true;
    }
}
