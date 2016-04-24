using UnityEngine;
using System.Collections;

public class TorchBehaviourScript : MonoBehaviour {

    GameObject myfire;
    GameObject theFireBefore;
    GameObject andTheOneBefore;
    bool getLight;
    bool torchOnFire;
    bool infire;
    public float torchLifeSpan;
    float myFireLevel;
    Vector3 scale;


    // Use this for initialization
    void Start () {
        getLight = false;
        torchOnFire = false;
        infire = false;
        myfire = GameObject.Find("fire");
        myFireLevel = 0;
        scale = myfire.GetComponentInChildren<Transform>().localScale;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        scale.y = myFireLevel / 70.0f;
        scale.x = myFireLevel / 70.0f;
        myfire.GetComponentInChildren<Transform>().localScale = scale;
        

        if (myFireLevel > 0)
        {
            myfire.GetComponentInChildren<SpriteRenderer>().enabled = true;
            myFireLevel--;
            torchOnFire = true;
        }
        else
        {
            myfire.GetComponentInChildren<SpriteRenderer>().enabled = false;
            torchOnFire = false;
        }

        if (!torchOnFire)
            {
            if (theFireBefore && this.gameObject.tag != "checkedFire")
            {
                andTheOneBefore = theFireBefore;
                theFireBefore.gameObject.tag = "Untagged";
            }
                myfire.gameObject.tag = "Untagged";
                theFireBefore = GameObject.FindGameObjectWithTag("lastFire");
                if (theFireBefore)
                    theFireBefore.gameObject.tag = "checkedFire"; 
            
            }

    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (myFireLevel > 0)
        {
            //if (other.tag == "Payer")
                other.gameObject.SendMessage("InAndOutFire", torchOnFire);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //if (other.tag == "Payer")
            other.gameObject.SendMessage("InAndOutFire", infire);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (myFireLevel >0)
        {
            //if (other.tag == "Payer")
                other.gameObject.SendMessage("InAndOutFire", torchOnFire);
        }
        
    }
    

    void IsSheOnFire(bool reveivingFire)
    {
        theFireBefore = GameObject.FindGameObjectWithTag("checkedFire");
        getLight = reveivingFire;

        if (getLight == true)
        {
            myFireLevel = torchLifeSpan;

            if (myfire.gameObject.tag != "checkedFire")
            {
                myfire.gameObject.tag = "checkedFire";
                if (theFireBefore)
                {
                    theFireBefore.gameObject.tag = "lastFire";
                }
                
            }
        }
    }

}
