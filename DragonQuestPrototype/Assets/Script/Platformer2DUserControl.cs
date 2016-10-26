using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool isClimbing;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            isClimbing = false;
        }

        private void Update()
        {
            if (!isClimbing)
            {
                if (!m_Jump)
                {
                    // Read the jump input in Update so button presses aren't missed.
                    m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
                }
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = 0.0f;
            // Pass all parameters to the character control script.
            m_Character.Move(h, v, crouch, m_Jump);
            m_Jump = false;
            if(isClimbing)
            {
                v = CrossPlatformInputManager.GetAxis("Vertical");
                m_Character.Move(h, v, crouch, m_Jump);
            }
        }

        //Check if player is in a climbable area
        void OnTriggerEnter2D(Collider2D trig)
        {
            if (trig.tag == "Climbable")
            {
                isClimbing = true;
                GetComponent<PlatformerCharacter2D>().ChangeGravity(0);
            }

            if(trig.tag == "Dragon")
            {
                GetComponent<PlayerCombat>().TakeDamage();
            }
        }//end trigger enter

        void OnTriggerExit2D(Collider2D trig)
        {
            isClimbing = false;
            GetComponent<PlatformerCharacter2D>().ChangeGravity(5);
        }//end trigger enter
    }
}
