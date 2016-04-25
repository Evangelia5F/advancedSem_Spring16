using UnityEngine;
using System.Collections;

public class BurstPowerScript : MonoBehaviour {

    public int initReductionRate;
    public float speedBoost;
    public float jumpBoost;
    int reductionRate;
    int additionalReductionRate;
    float additionalSpeedBoost;
    float additionalJumpBoost;
    float h;
    bool abilityTrigerred;
    GameObject firePathParticles;
    Rigidbody2D rigi;
   // ParticleSystem.EmissionModule em;
   // ParticleSystem fireParticles;



    // Use this for initialization
    void Start () {        
        rigi = transform.parent.GetComponent<Rigidbody2D>();
        firePathParticles = this.gameObject.transform.GetChild(0).gameObject;
       // fireParticles = firePathParticles.GetComponent<ParticleSystem>();
        abilityTrigerred = false;
       // var em = fireParticles.emission;
        //ParticleSystem.EmissionModule em = firePathParticles.GetComponent<ParticleSystem>().emission;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        

        //fire on, fire off
        if (abilityTrigerred == true)
        {
            rigi.velocity = rigi.velocity + (new Vector2(speedBoost*h, 0f));
            Debug.Log(rigi.velocity.x);
            //this.GetComponent<SpriteRenderer>().enabled = true;
            firePathParticles.SetActive(true);

          //  em.enabled = true;


        }
        else
        {
            //this.GetComponent<SpriteRenderer>().enabled = false;
           firePathParticles.SetActive(false);
           // firePathParticles.GetComponent<ParticleSystem>().enableEmission = false;
           // em.enabled = false;
        }
        //Debug.Log(em.enabled);

        // fire reduction rate calculator and sender
        reductionRate = initReductionRate - additionalReductionRate;
        SendMessageUpwards("BurstFireReductionLevelReceiver", reductionRate);

        
       
        SendMessageUpwards("receivingJumpBoost", jumpBoost);
    }

    void FireButtonPressReceiver(bool onOff)
    {
        abilityTrigerred = onOff;
    }

    void TaraDirectionReciver(float direction)
    {
        h = direction;
    }

    void CollectorIncomingSpeed(float addedSpeed)
    {
        additionalSpeedBoost = additionalSpeedBoost + addedSpeed;
        speedBoost = (speedBoost + additionalSpeedBoost);
    }
    void CollectorIncomingJump(float addedJump)
    {
        additionalJumpBoost = additionalJumpBoost + addedJump;
        jumpBoost = jumpBoost + additionalJumpBoost;
    }

    void CollectorIncomingReducedReduction(int reduceReduction)
    {
        additionalReductionRate = additionalReductionRate + reduceReduction;
    }

}
