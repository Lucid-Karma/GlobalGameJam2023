using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 1000f;
    public Transform playerBody;
    public bool isPapperOn = false;

    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (isPapperOn)
        {
            return;
        }

        else
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    public void MouseControlOff()
    {
        isPapperOn = true;
    }
    public void MouseControlOn()
    {
        isPapperOn = false;
    }

    private void OnEnable()
    {
        EventManager.OnOpenPapper.AddListener(MouseControlOff);
        EventManager.OnClosePapper.AddListener(MouseControlOn);
        EventManager.OnTransitionStart.AddListener(MouseControlOff);
        EventManager.OnTransitionEnd.AddListener(MouseControlOn);

    }
    private void OnDisable()
    {
        EventManager.OnOpenPapper.RemoveListener(MouseControlOff);
        EventManager.OnClosePapper.RemoveListener(MouseControlOn);
        EventManager.OnTransitionStart.RemoveListener(MouseControlOff);
        EventManager.OnTransitionEnd.RemoveListener(MouseControlOn);
    }
}
