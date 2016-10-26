using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {

    [SerializeField]
    private QuickItemUI quickItem;

    [SerializeField]
    private Rigidbody2D bulletPrefab;

    private float life = 1.0f;
    private float timeElapsed = 0f;
    public float attackDelay = 0.5f;
    public GameObject weapon;

    private Camera cam;
    
    // Use this for initialization
    void Start () {
        cam = FindObjectOfType<Camera>();
        if (null == cam)
            throw new System.Exception("[PlayerCombat] cannot find camera.");
        if (null == quickItem)
            throw new System.Exception("[PlayerCombat] please bind quickItem.");
        ItemBehaviour.Instance.RegisterItemBehaviour(ItemName.Sword, UseSword);
        ItemBehaviour.Instance.RegisterItemBehaviour(ItemName.Pistol2, UseGun);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject.FindObjectOfType<ProgressBar>().Value = life;
        
        if(life <= 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetMouseButton(0))
        {
            quickItem.UseItem(Item.EquipSlots.LHand);
        }
        if (Input.GetMouseButton(1))
        {
            quickItem.UseItem(Item.EquipSlots.RHand);
        }

        timeElapsed += Time.deltaTime;
    }

    bool UseGun(ItemTemplate item)
    {
        if (timeElapsed > attackDelay)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;

            Vector2 playerPos = transform.position;
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            var dir = (mousePos - playerPos);
            dir.Normalize();
            print(dir + " " + dir.magnitude);
            bullet.velocity = dir * 10.0f;
            timeElapsed = 0f;
            return true;
        }

        return false;
    }

    bool UseSword(ItemTemplate item)
    {
        if (timeElapsed > attackDelay)
        {
            weapon.SetActive(true);
            StartCoroutine(Coroutine(0.5f));
            timeElapsed = 0f;

            return true;
        }

        return false;
    }

    IEnumerator Coroutine(float waitTime)
    {
        if (waitTime > 0)
            yield return new WaitForSeconds(waitTime);

        // do stuff after waitTime
        weapon.SetActive(false);
    }

    public void Heal(float hp)
    {
        life = Mathf.Clamp01(life + hp / 100.0f);
    }

    public void TakeDamage()
    {
        life -= 0.2f;
    }
}
