using UnityEngine;

public class GridList : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private Vector2 offset;

    [SerializeField]
    private Vector2 stepSize;

    [SerializeField]
    private int row;

    [SerializeField]
    private int col;


    void Awake()
    {
        for (int j = 0; j < row; ++j)
        {
            for (int i = 0; i < col; ++i)
            {
                GameObject go = Instantiate(prefab);
                var pos = new Vector3(offset.x + i * stepSize.x, - offset.y - j * stepSize.y);
                go.transform.localPosition = pos;
                go.transform.SetParent(transform, false);
            }

        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
