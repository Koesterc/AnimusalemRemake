using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CameraClamp : MonoBehaviour
{
    [SerializeField]
    Transform miniMapSize;

    [SerializeField]
    Transform target;
    Transform t;

    void Awake()
    {
        t = transform;
        target = GameObject.Find("Player").transform;
        miniMapSize = GameObject.Find("FloorMap").transform;
    }

    void LateUpdate()
    {
        float xPos = Mathf.Clamp(target.position.x, -(miniMapSize.localScale.x / 2) + 32, (miniMapSize.localScale.x / 2)-32);
        float zPos = Mathf.Clamp(target.position.z, -(miniMapSize.localScale.y / 2) + 32, (miniMapSize.localScale.y / 2)-32);
        t.position = new Vector3 (xPos,transform.position.y,zPos);
    }

}
