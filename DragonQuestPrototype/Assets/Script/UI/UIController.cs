using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private OverlayUI overlay;

    void Awake()
    {
        overlay.Init();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Inventory"))
        {
            overlay.Toggle();
        }
        
    }
}
