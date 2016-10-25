using UnityEngine;
using System.Collections;

public class ItemDropper : MonoBehaviour
{
    [SerializeField]
    private SceneItem prefab;

    [SerializeField]
    private float force = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Drop(Item item)
    {
        var go = Instantiate(prefab);
        go.transform.position = transform.position + Vector3.up;
        go.Item = item;
        go.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
}
