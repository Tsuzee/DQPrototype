﻿using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject followee;
    public Tiled2Unity.TiledMap tileMap;

    public float moveThreshold = 0.01f;
    public float followSpeed = 10.0f;

    private Camera cam;

    private Rect mapArea;

    private float halfViewSizeX;
    private float halfViewSizeY;

    void OnEnable()
    {
        
    }

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
        halfViewSizeY = cam.orthographicSize;
        halfViewSizeX = cam.orthographicSize * cam.aspect;

        mapArea = tileMap.GetMapRectInPixelsScaled();
    }

    // Update is called once per frame
    void Update()
    {
        float targetX = followee.transform.position.x;
        float targetY = followee.transform.position.y;
        float deltaX = targetX - transform.position.x;
        float deltaY = targetY - transform.position.y;

        if (Mathf.Abs(deltaX) < moveThreshold &&
            Mathf.Abs(deltaY) < moveThreshold)
        {
            return;
        }

        //float speedX = Mathf.Min(deltaX, followSpeed);
        //float speedY = Mathf.Min(deltaY, followSpeed);

        //float newX = transform.position.x + speedX * Time.fixedDeltaTime;
        //float newY = transform.position.y + speedY * Time.fixedDeltaTime;

        float newX = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * followSpeed);
        float newY = Mathf.Lerp(transform.position.y, targetY, Time.deltaTime * followSpeed);

        //float newX = targetX;
        //float newY = targetY;

        Rect targetRect = new Rect
        {
            x = newX - halfViewSizeX,
            y = newY - halfViewSizeY,
            width = halfViewSizeX * 2,
            height = halfViewSizeY * 2
        };

        if (targetRect.xMin < mapArea.xMin)
        {
            targetRect.x = mapArea.xMin;
        }
        else if (targetRect.xMax > mapArea.xMax)
        {
            targetRect.x = mapArea.xMax - targetRect.width;
        }

        if (targetRect.yMin < mapArea.yMin)
        {
            targetRect.y = mapArea.yMin;
        }
        else if (targetRect.yMax > mapArea.yMax)
        {
            targetRect.y = mapArea.yMax - targetRect.height;
        }

        transform.position = new Vector3(targetRect.center.x, targetRect.center.y, transform.position.z);
    }
}
