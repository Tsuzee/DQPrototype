using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy")
        {
            // TODO
        }
        if (other.collider.tag != "Player" && other.collider.tag != tag)
        {
            Destroy(gameObject);
        }
    }//end collision check
}
