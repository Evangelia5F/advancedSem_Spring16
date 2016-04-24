using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagerBehaviourScript : MonoBehaviour {
    static SceneManagerBehaviourScript Instance;
    //bool changeLevel;
    bool currentlyChanging;
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
            currentLevelIndicator = Application.loadedLevel;
            currentlyChanging = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(currentLevelIndicator);

        if (currentlyChanging == true) {
            currentLevelIndicator = currentLevelIndicator + 1;
            SceneManager.LoadScene(currentLevelIndicator);
            currentlyChanging = false;
        }
        else
        {
        }
        

    }

    void LevelComplete(bool sheFinished)
    {
        currentlyChanging = sheFinished;
        Debug.Log(sheFinished);

    }
}
