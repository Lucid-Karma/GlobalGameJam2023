using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// public enum ExecutingState
// {
//     KEYSEARCH,
//     KEYFOUND
// }
public class PlayerFsm : MonoBehaviour
{
    // #region FSM
    //     PlayerStates currentState;

    //     public KeySearchState keySearchState = new KeySearchState();
    //     public KeyFoundState keyFoundState = new KeyFoundState();


    //     public ExecutingState executingState;
    // #endregion

    #region UI
    [SerializeField] private Image crosshair = null;
    [SerializeField] private GameObject pressEUI;
    private bool isCrosshairActive, doOnce;
    #endregion

    private Camera _camera;

    private void Start()
    {
        //executingState = ExecutingState.KEYSEARCH;

        _camera = Camera.main;

        //currentState = keySearchState;
    }

    private void Update()
    {
        //currentState.UpdateState(this);

        var nearestGameObject = GetNearestGameObject();

        if(nearestGameObject != null)
        {
            var interactable = nearestGameObject.GetComponent<IInteractable>();
            if(interactable != null)
            {
                interactable?.Meet();
                crosshair.color = Color.red;
                pressEUI.SetActive(true);

                if (Input.GetKey(KeyCode.E))
                {
                    interactable?.Interact();
                }
            }   
            else if(interactable == null)
            {
                crosshair.color = Color.white;
                pressEUI.SetActive(false); 
            }
        }
        else if(nearestGameObject == null)
        {
            crosshair.color = Color.white;
            pressEUI.SetActive(false); 
        }    
    }

    //var interactable;
    // public void MeetWithInventory()
    // {
    //     var nearestGameObject = GetNearestGameObject();
    //     if (nearestGameObject == null) return;
    //     // if (Input.GetButtonDown("Fire1"))
    //     // {
    //         interactable = nearestGameObject.GetComponent<IInteractable>();
    //         interactable?.Meet();
    //     // }
    // }
    // public void InteractWithInventory()
    // {
    //     var nearestGameObject = GetNearestGameObject();
    //     if (nearestGameObject == null) return;
    //     if (Input.GetButtonDown("Fire1"))
    //     {
    //         interactable = nearestGameObject.GetComponent<IInteractable>();
    //         interactable?.Interact();
    //     }
    // }

    private GameObject GetNearestGameObject()
    {
        GameObject result = null;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(/*ray*/transform.position, fwd, out hit, 5))
        {
            result = hit.transform.gameObject;
        }
        return result;
    }
    
}
