using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagerBehaviourScript : MonoBehaviour {
    static SceneManagerBehaviourScript Instance;
    //bool changeLevel;
    bool currentlyChanging;
    GameObject levelPrefabManager;
    int currentLevelIndicator;
	// Use this for initialization
	void Start () {
        if (Instance != null)
        {
            GameObject.Destroy(gameObject);

            Debug.Log(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            Instance = this;
            currentLevelIndicator = 0;
            currentlyChanging = false;
        }
    }
	
	// Update is called once per frame
	void Update () {


       


        if (currentlyChanging == true) {
            currentLevelIndicator++;
            SceneManager.LoadScene(currentLevelIndicator);
            levelPrefabManager = GameObject.Find("LevelPrefabManager");
            levelPrefabManager.gameObject.SendMessage("LevelReciver", currentLevelIndicator);
            currentlyChanging = false;
        }
        else
        {

        }
        

    }

    void LevelComplete(bool sheFinished)
    {
        currentlyChanging = sheFinished;

    }
}
