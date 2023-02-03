using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1;

    GameObject playerObject;

    private void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    /* public void LoadNextLevel()
     {
         StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
     }

     IEnumerator LoadLevel(int levelIndex)
     {
         transition.SetTrigger("Start");

         yield return new WaitForSeconds(transitionTime);

         SceneManager.LoadScene(levelIndex);
     }*/

    public void LoadNextScene()
    {
        StartCoroutine(LoadlScene());
    }

    IEnumerator LoadlScene()
    {
        transition.SetTrigger("Start");

        EventManager.OnTransitionStart.Invoke();

        yield return new WaitForSeconds(transitionTime);

        playerObject.transform.position = new Vector3(15, 2, -10);

        transition.SetTrigger("End");

        EventManager.OnTransitionEnd.Invoke();
    }
}
