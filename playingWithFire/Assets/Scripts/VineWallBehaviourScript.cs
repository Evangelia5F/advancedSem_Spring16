using UnityEngine;
using System.Collections;

public class VineWallBehaviourScript : MonoBehaviour
{

    bool taraOnFire;
    GameObject me;
    GameObject charTara;

    // Use this for initialization
    void Start()
    {
        charTara = GameObject.FindGameObjectWithTag("Player");
        taraOnFire = false;
        me = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void thisGirlIsOnFire(bool isIt)
    {
        if (isIt == true)
        {
            taraOnFire = true;
        }
        else
        {
            taraOnFire = false;
            
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            charTara.SendMessage("Walls2Bern", me);
            /*if (taraOnFire == true)
            {
                Destroy(this.gameObject);
            }*/
        }
    }
}
