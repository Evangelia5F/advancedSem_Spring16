using UnityEngine;
using System.Collections;

public class SpiderEnemyBehaviourScript : MonoBehaviour {


    GameObject tara;
    bool isKill;
    bool touching;
    float movingSpeed;
    float speedofRig;
    float howFat;
    Vector2 oPos;
    Vector2 initPos;
    Rigidbody2D rigthis;

	// Use this for initialization
	void Start () {
        isKill = false;
        touching = false;
        tara = GameObject.FindGameObjectWithTag("Player");
        movingSpeed = 0.06f;
        initPos = transform.position;
        howFat = transform.localScale.x /2;
        rigthis = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {


        oPos = transform.position;

        transform.position = new Vector3(oPos.x + movingSpeed, initPos.y);

    }

    void SheBurns(bool nowWedie)
    {
        if (nowWedie == true)
        {
            Destroy(this.gameObject);
        }
    }



    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            touching = true;
            //Debug.Log("enemyhit");
            tara.SendMessage("Death", touching);

        }
        //tara.SendMessage

        if (coll.gameObject.tag == "Platform" || coll.gameObject.tag == "vineWall")
        {

       //     Debug.Log("hit");
            movingSpeed = movingSpeed * (-1);
        }
    }
    void OnTriggerEnter2D (Collider2D bump)
    {
        if (bump.gameObject.tag == "Turn")
        {

  //         Debug.Log("hit");
            movingSpeed = movingSpeed * (-1);
        }
    }

    

}
