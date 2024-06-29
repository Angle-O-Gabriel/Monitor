using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueSpeaker : MonoBehaviour, IPointerClickHandler
{
    public DialogueManager manager;
    [SerializeField] public string speaker;
    [SerializeField][TextArea(2, 10)] public string[] text;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(manager.isTalking == false)
        {
            FindFirstObjectByType<DialogueManager>().startTalking(speaker, text);
        }
    }
}
