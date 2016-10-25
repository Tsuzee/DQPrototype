using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour {

	public float shootDelay = 1f;
	public GameObject projectilePrefab;

	private float timeElapsed = 0f;
	private Vector2 initialVelocity = new Vector2(5, -1);

	// Use this for initialization
	void Start(){

	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (projectilePrefab);
		if (projectilePrefab != null) {
			if ( timeElapsed > shootDelay ){
				Vector2 velocity = new Vector2(10f, 1f);
				CreateProjectile(transform.position);
				timeElapsed = 0f;
			}

			timeElapsed += Time.deltaTime;
		}
	}

	public void CreateProjectile(Vector2 pos){

		GameObject clone = Instantiate(projectilePrefab, pos, Quaternion.identity) as GameObject;
		clone.transform.localScale = 0.3f * transform.localScale;
		Rigidbody2D body2D = clone.GetComponent<Rigidbody2D> ();

		float startex;
		startex = -1.0f * initialVelocity.x * transform.localScale.x;
		Debug.Log (startex);
		body2D.velocity = new Vector2 (startex, initialVelocity.y);
	}
}
