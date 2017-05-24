using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CameraClamp : MonoBehaviour
{
    [SerializeField]
    Transform miniMapSize;

    [SerializeField]
    Camera cam;

    [SerializeField]
    Transform target;
    Transform t;

    void Awake()
    {
        t = transform;
        target = GameObject.Find("Player").transform;
        miniMapSize = GameObject.Find("FloorMap").transform;
     //   SmallScreen();

    }

    void LateUpdate()
    {
        float xPos = Mathf.Clamp(target.position.x, -(miniMapSize.localScale.x / 2) + 32, (miniMapSize.localScale.x / 2)-32);
        float zPos = Mathf.Clamp(target.position.z, -(miniMapSize.localScale.y / 2) + 32, (miniMapSize.localScale.y / 2)-32);
        t.position = new Vector3 (xPos,transform.position.y,zPos);
    }

    //void FullScreen()
    //{
    //    // setup the rectangle 
    //    cam.rect = new Rect(.2f, 0.2f, .6f, .6f); // 16:9 viewport in a 16:10 screen res
    //}

    //void SmallScreen()
    //{
    //    cam.rect = new Rect(.685f, 0.685f, .3f, .3f); // 16:9 viewport in a 16:10 screen res
    //}

}
