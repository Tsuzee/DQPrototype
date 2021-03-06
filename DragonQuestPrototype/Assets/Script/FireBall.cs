﻿using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

//	public Vector2 intialVelocity;

	private Vector2 initialVelocity = new Vector2(5, -1);

	public float projectileDestroyTimer = .5f;
    public GameObject Player;
	private float currentTimer = 0.0f;
	private Rigidbody2D body2D;

	void Awake(){
//		body2D = GetComponent<Rigidbody2D>;
		body2D = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
	}

	// Use this for initialization
	void Start () {
//		float startex = initialVelocity.x * transform.localScale.x;
//		body2D.velocity = new Vector2 (startex, initialVelocity.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTimer > projectileDestroyTimer) {
			Destroy (gameObject);
		} else {
			currentTimer += Time.deltaTime;
		}
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            Player.GetComponent<PlayerCombat>().TakeDamage();
        }
        if (other.collider.tag != "Enemy" && other.collider.tag != tag)
        {
            Destroy(gameObject);
        }
    }//end collision check
}
