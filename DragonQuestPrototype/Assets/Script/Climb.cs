using UnityEngine;
using System.Collections;

public class Climb : MonoBehaviour {


    //Check if player is in a climbable area
    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.tag == "Climbable")
        {

        }
    }
}
