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


    [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excluseLayerName = null;

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

        // var nearestGameObject = GetNearestGameObject();
        // if (nearestGameObject == null) return;
        //var ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position,fwd,out hit,5,mask))
        {
            result = hit.transform.gameObject;

            if(result == null)  return;

            var interactable = result.GetComponent<IInteractable>();
            if(interactable != null)
            {
                interactable?.Meet();
                crosshair.color = Color.red;
                //SetCrosshair();
                pressEUI.SetActive(true);
            }   
            else if(interactable == null || result == null)
            {
                // if (isCrosshairActive)
                // {
                //     CrosshairChange(false);
                //     doOnce = false;
                // }
                crosshair.color = Color.white;
                pressEUI.SetActive(false); 
            }    


            if (Input.GetKey(KeyCode.E))
            {
                interactable?.Interact();
            }
        }
        

        // var interactable = nearestGameObject.GetComponent<IInteractable>();
        // if(interactable != null)
        // {
        //     interactable?.Meet();
        //     crosshair.color = Color.red;
        //     //SetCrosshair();
        //     pressEUI.SetActive(true);
        // }   
        // else if(interactable == null || nearestGameObject == null)
        // {
        //     // if (isCrosshairActive)
        //     // {
        //     //     CrosshairChange(false);
        //     //     doOnce = false;
        //     // }
        //     crosshair.color = Color.white;
        //     pressEUI.SetActive(false); 
        // }    


        // if (Input.GetKey(KeyCode.E))
        // {
        //     interactable?.Interact();
        // }
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
GameObject result = null;
RaycastHit hit;
    // private GameObject GetNearestGameObject()
    // {
    //     RaycastHit hit;
    //     Vector3 fwd = transform.TransformDirection(Vector3.forward);

    //     GameObject result = null;
    //     //var ray = _camera.ScreenPointToRay(Input.mousePosition);
    //     //if (Physics.Raycast(ray, out var hit, 5))
    //     int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;

    //     if (Physics.Raycast(transform.position,fwd,out hit,5,mask))
    //     {
    //         result = hit.transform.gameObject;
    //     }
    //     return result;
    // }
    
}
