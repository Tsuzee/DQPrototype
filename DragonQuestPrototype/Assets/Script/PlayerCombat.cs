using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {

    private float life = 1.0f;
    private float timeElapsed = 0f;
    public float attackDelay = 0.5f;
    public GameObject weapon;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.FindObjectOfType<ProgressBar>().Value = life;
        
        if(life <= 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            
            if (timeElapsed > attackDelay)
            {
                weapon.SetActive(true);
                StartCoroutine(Coroutine(0.5f));
                timeElapsed = 0f;
            }

        }
        timeElapsed += Time.deltaTime;
    }

    IEnumerator Coroutine(float waitTime)
    {
        if (waitTime > 0)
            yield return new WaitForSeconds(waitTime);

        // do stuff after waitTime
        weapon.SetActive(false);
    }

    public void TakeDamage()
    {
        life -= 0.2f;
    }
}
