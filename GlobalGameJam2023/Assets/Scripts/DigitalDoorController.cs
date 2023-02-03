using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DigitalDoorController : MonoBehaviour
{
    [SerializeField] private GameObject doorLeft, doorRight;

    private GameObject playerObject;


    private void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerObject)
        {
            moveUp();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerObject)
        {
            moveDown();
        }
    }

    public void moveUp()
    {
        doorLeft.transform.DOLocalMoveZ(-3f, .5f).SetEase(Ease.OutQuad);
        doorRight.transform.DOLocalMoveZ(3f, .5f).SetEase(Ease.OutQuad);
    }
    public void moveDown()
    {
        doorLeft.transform.DOLocalMoveZ(-1.5f, .5f).SetEase(Ease.OutQuad);
        doorRight.transform.DOLocalMoveZ(1.5f, .5f).SetEase(Ease.OutQuad);
    }
}
