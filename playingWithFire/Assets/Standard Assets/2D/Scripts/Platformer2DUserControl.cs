using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        GameObject burst;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
           
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            burst = GameObject.Find("BurstingFire");
            // Read the inputs.
            bool crouch = false;
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Debug.Log(h);
            if (h > 0.35f)
                h = 1;
            else {
                if (h < -0.35f)
                    h = -1;
                else h = 0;

            }
            burst.gameObject.SendMessage("TaraDirectionReciver", h);

            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }


    }
}
