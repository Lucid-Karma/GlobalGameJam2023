using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotationXY : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 direction = cam.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
