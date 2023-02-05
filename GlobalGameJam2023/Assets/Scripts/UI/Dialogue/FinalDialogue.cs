using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    void OnEnable()
    {
        EventManager.OnFinalTalk.AddListener(PreStartDialogue);
    }
    void OnDisable()
    {
        EventManager.OnFinalTalk.RemoveListener(PreStartDialogue);
    }

    void PreStartDialogue()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypleLine());
    }

    IEnumerator TypleLine()
    {
        foreach (var c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
