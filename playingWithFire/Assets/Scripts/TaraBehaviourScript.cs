using UnityEngine;
using System.Collections;

public class TaraBehaviourScript : MonoBehaviour {

    public int initFireLevel;   //public for testing and balancing purposes
    int burstReduction; //reduction of fire during burst
    int fireLevel;
    bool inFire;  //did she walk into the fire
    bool onFire;  //is she on fire
    bool burstFire; //exess use of fire
    bool weDead;
    bool weDoneHere; //completed level
    GameObject vineWall;
    GameObject fireHat;
    GameObject touchingObject;
    GameObject spawnPoint;
    GameObject tornadoSprite;
    GameObject sceneManager;

    void Awake()
    {
        tornadoSprite = GameObject.Find("BurstingFire");
    }
	// Use this for initialization
	void Start () {

        fireHat = GameObject.Find("fireHat");
       
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        
        fireLevel = initFireLevel;
        onFire = true;
        weDead = false;
        weDoneHere = false;
        burstFire = false;
        //initFireLevel = 200;
        vineWall = null;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        sceneManager = GameObject.Find("SceneManager");


        if (!onFire)
            weDead = true;
        

        if (spawnPoint == null)
        {
            spawnPoint = GameObject.FindGameObjectWithTag("checkedFire");
        }
        
        //respawn
        if (weDead == true)
        {
            spawnPoint = GameObject.FindGameObjectWithTag("checkedFire");
            fireLevel = initFireLevel;
            transform.position = spawnPoint.transform.position;
            weDead = false;
        }


        //fire level handler
        if (inFire == false)
        {
            if (fireLevel > 0)
            {
                fireLevel--;
            }
            else
            {
                onFire = false;
            }
        }
        else
            fireLevel = initFireLevel;


        //bursting fire
        if (Input.GetButton("Fire1"))
        {
            if (onFire == true)
            {
                if (fireLevel > 0)
                {
                    burstFire = true;
                    
                    fireLevel = fireLevel - (burstReduction/3);
                }
                else
                {
                    burstFire = false;
                    
                }

            }
            else
                fireLevel = 0;
        }
        else
        {
            burstFire = false;
        }
        tornadoSprite.SendMessage("FireButtonPressReceiver", burstFire);

        //burning down vine walls
        if (vineWall != null)
        {
            if (onFire == true)
            {
                Destroy(vineWall, 0.1f);
            }               
        }

        //sending to Fire Hat
        fireHat.SendMessage("ReceivingFirePower", fireLevel);
            //Debug.Log(fireLevel);


	}

    void Walls2Bern(GameObject wallTouched)
    {
        if (onFire)
            vineWall = wallTouched;
    }

    void InAndOutFire(bool insideFire)
    {
        if (insideFire == true)
        {
            
            fireLevel = initFireLevel;
            inFire = true;
            onFire = true;
        }

        if (insideFire == false)
        {
            inFire = false; 
        }
    }

    void Death(bool istouching)
    {
        if (istouching == true)
        {
            if (fireLevel > 0)
            {
                if (onFire == false)
                    weDead = true;
                else
                    weDead = false;
            }
            if (fireLevel <= 0)
                weDead = true;
        }
    }


    //what was that we touched
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            //
            coll.gameObject.SendMessage("SheBurns", onFire);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Torch")
            coll.gameObject.SendMessage("IsSheOnFire", onFire);

        if (coll.gameObject.tag == "LevelEnd") {
            weDoneHere = true;
            if (sceneManager)
            sceneManager.SendMessage("LevelComplete", weDoneHere);
            weDoneHere = false;
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Torch")
            coll.gameObject.SendMessage("IsSheOnFire", onFire);
        //Debug.Log(burstFire);
    }

    void BurstFireReductionLevelReceiver(int newBurstLevel)
    {
        burstReduction = newBurstLevel;
    }

    void OnParticleCollision(GameObject rain)
    {
        fireLevel = fireLevel - 5;
       // Debug.Log("fuck you I'm wet");
    }

}
