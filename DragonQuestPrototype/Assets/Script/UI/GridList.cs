using System.Collections.Generic;
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

    private List<GameObject> elements = new List<GameObject>();

    void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (elements.Count > 0)
            return;

        elements.Clear();
        for (int j = 0; j < row; ++j)
        {
            for (int i = 0; i < col; ++i)
            {
                GameObject go = Instantiate(prefab);
                var pos = new Vector3(offset.x + i * stepSize.x, -offset.y - j * stepSize.y);
                go.transform.localPosition = pos;
                go.transform.SetParent(transform, false);
                go.GetComponent<GridListElement>().Index = elements.Count;
                elements.Add(go);
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

    public int Count
    {
        get { return elements.Count; }
    }

    public GameObject GetElement(int index)
    {
        if (index < 0 || index >= elements.Count)
            return null;

        return elements[index];
    }

    public T GetElement<T>(int index)
    {
        GameObject go = GetElement(index);
        if (null == go)
            return default(T);

        return go.GetComponent<T>();
    }
}
