using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public GameObject cubeObject;

    private void Start()
    {
        Debug.Log(cubeObject.transform.position);
        DontDestroyOnLoad(cubeObject);
    }
}
