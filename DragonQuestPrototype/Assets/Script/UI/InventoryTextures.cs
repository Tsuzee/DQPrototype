using UnityEngine;
using System.Collections;

public class InventoryTextures : MonoBehaviour
{
    [SerializeField]
    private Sprite[] textureList;

    public Sprite GetItemSprite(int index)
    {
        if (index < 0 || index >= textureList.Length)
            return null;
        return textureList[index];
    }

    public static InventoryTextures Instance { get; private set; }

    void Awake()
    {
        Instance = this;
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
