using UnityEngine;
using System.Collections;

public class CollectibleBehaviourScript : MonoBehaviour {
    
    float addJump;
    float addSpeed;
    int reducedReduction;
    GameObject burstingFireHolder;

    // Use this for initialization
    void Start () {
        burstingFireHolder = GameObject.Find("BurstingFire");
        addJump = 0.01f;
        addSpeed = 0.05f;
        reducedReduction = 3;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        burstingFireHolder.SendMessage("CollectorIncomingJump", addJump);
        burstingFireHolder.SendMessage("CollectorIncomingSpeed", addSpeed);
        burstingFireHolder.SendMessage("CollectorIncomingReducedReduction", reducedReduction);

        Destroy(this.gameObject);
        
    }

}
