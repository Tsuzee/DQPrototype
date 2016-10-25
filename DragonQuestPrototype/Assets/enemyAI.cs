using UnityEngine;
using System.Collections;

//	Need to make it so that, the dragon doesn't fall through the tunnels and stuff.
//	Need to make it so that, it stops approaching the player when it is 2 units away from him and tries to breathe fire on him.

public class enemyAI : MonoBehaviour {

//	public Transform Target;
	private GameObject Enemy;
	private GameObject Player;
	private float Range;
	public float Speed;

	private Vector2 dir;
	private Vector2 newPosition;
	public bool facingLeft = true;
	
	
	// Use this for initialization
	void Start () {

		Enemy = GameObject.FindGameObjectWithTag ("Enemy");
		Player = GameObject.FindGameObjectWithTag ("Player");


	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log("Here");
		Range = Vector2.Distance (Enemy.transform.position, Player.transform.position);
		if (Range <= 5f) {
//			transform.Translate(Vector2.MoveTowards (Enemy.transform.position, Player.transform.position, Range) * Speed * Time.deltaTime);
			dir.x = Player.transform.position.x - Enemy.transform.position.x;
			dir.y = Player.transform.position.y - Enemy.transform.position.y;

			dir.x /= Range;
			dir.y /= Range;

			if ( facingLeft && ( dir.x > 0 ) ){
				flip();
			}else if ( !facingLeft && ( dir.x < 0 ) ){
				flip();
			}

			newPosition.x = Enemy.transform.position.x + dir.x * Speed * Time.deltaTime;
			newPosition.y = Enemy.transform.position.y;

			Enemy.transform.position = newPosition;

//			We Dont move the dragon vertically as of now..
//			Enemy.transform.position.x += dir.y * Speed;

		}
        if (Range <= 7f)
        {
            GetComponent<ShootProjectile>().shouldShoot = true;
        }
        else
        {
            GetComponent<ShootProjectile>().shouldShoot = false;
        }
	}

	void flip(){

		facingLeft = !facingLeft;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Weapon")
        {
            Destroy(gameObject);
        }
    }
}
