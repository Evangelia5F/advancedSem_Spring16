using UnityEngine;
using System.Collections;

public class walkingInFireScript : MonoBehaviour {

    GameObject charTara;
    GameObject myFire;
    GameObject theFireBefore;
    GameObject andTheFireBeforeThat;
    Collider2D coll;
    bool burning;

    // Use this for initialization
    void Start () {
        theFireBefore = null;
        coll = gameObject.GetComponent<PolygonCollider2D>();
        charTara = GameObject.FindGameObjectWithTag("Player");
        myFire = GameObject.Find("fire");
        burning = false;

    }

// Update is called once per frame
    void FixedUpdate () {
        
        theFireBefore = GameObject.FindGameObjectWithTag("checkedFire");
        //Debug.Log(theFireBefore);


    }

	void OnTriggerEnter2D(Collider2D cool)
    {
        if (cool.tag == "Player")
        {
            burning = true;

            charTara.SendMessage("InAndOutFire", burning);
            if (theFireBefore != null)
            theFireBefore.gameObject.tag = "lastFire";

          /*  if (this.gameObject.tag != "checkedFire")
            {
                if (theFireBefore)
               // theFireBefore.gameObject.tag = "lastFire";
                this.gameObject.tag = "lastFire";
            }*/

            //Debug.Log(burning);
            //Debug.Log(this.gameObject.name);
        }
        
	}
	
	void OnTriggerStay2D()
	{
        //"is inside trigger volume
        /*if (this.gameObject.tag != "checkedFire")
        {
            if (theFireBefore)
                theFireBefore.gameObject.tag = "lastFire";
            this.gameObject.tag = "checkedFire";
        }*/
    }

    void OnTriggerExit2D(Collider2D fuckyouyoubitch)
    {
        if (fuckyouyoubitch.tag == ("Player"))
            {
                burning = false;
                charTara.SendMessage("InAndOutFire", burning);
            this.gameObject.tag = "checkedFire";
            }
    }

}


