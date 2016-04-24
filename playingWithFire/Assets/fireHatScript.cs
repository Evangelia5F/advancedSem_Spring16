using UnityEngine;
using System.Collections;

public class fireHatScript : MonoBehaviour {

    int fireLevel;
    Vector3 scale;
    SpriteRenderer sprites;
  
    // Use this for initialization
    void Start () {
        sprites = GetComponent<SpriteRenderer>();
        scale = transform.localScale;
        sprites.enabled = !sprites.enabled;

    }
	
	// Update is called once per frame
	void Update () {

        scale.y = fireLevel/30.0f;
        transform.localScale = scale;
	
	}

    void ReceivingFirePower(int reveivingFire)
    {
        fireLevel = reveivingFire;
    }
}
