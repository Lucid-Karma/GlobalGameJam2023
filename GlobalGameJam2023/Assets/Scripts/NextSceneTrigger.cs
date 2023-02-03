using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneTrigger : MonoBehaviour
{
    private LevelLoader loaderTransition;

    private void Awake()
    {
        loaderTransition = GetComponent<LevelLoader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            loaderTransition.LoadNextScene();
            // LevelLoader.instance.LoadNextScene();
        }
    }
}
