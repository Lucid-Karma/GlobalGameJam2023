using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1;

    GameObject playerObject;

    [SerializeField] private GameObject goPosition;

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

        Vector3 goTargetPosition = new Vector3(goPosition.transform.position.x,goPosition.transform.position.y,goPosition.transform.position.z);
        playerObject.transform.position = goTargetPosition;

        transition.SetTrigger("End");

        EventManager.OnTransitionEnd.Invoke();
    }
}
