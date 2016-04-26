using UnityEngine;
using System.Collections;

public class Level1WallScript : MonoBehaviour {

    public GameObject vineWalls;
    public GameObject spawn;
    public GameObject finish;
    public Quaternion verticalTilt;
    bool weStart;

	// Use this for initialization
	void Start () {
        weStart = true;
        verticalTilt = Quaternion.Euler(new Vector3(0, 0, 90));
    }
	
	// Update is called once per frame
	void Update () {

        if (weStart == true)
        {
            Instantiate(spawn, new Vector3(0f, -4.0f, 0), Quaternion.identity);
            Instantiate(vineWalls, new Vector3(0f, -4.5f, 0), verticalTilt);
            Instantiate(vineWalls, new Vector3(5.0f, -0.5f, 0), verticalTilt);
            Instantiate(vineWalls, new Vector3(-1.0f, -0.5f, 0), verticalTilt);
            Instantiate(vineWalls, new Vector3(-5.0f, -1.5f, 0), verticalTilt);
            Instantiate(finish, new Vector3(-3.0f, 6.0f, 0f), Quaternion.identity);
            weStart = false;
        }
	}
}
