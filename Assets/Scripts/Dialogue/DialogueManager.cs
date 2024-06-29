using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI speakingName;
    [SerializeField] private TextMeshProUGUI speakingLines;

    public bool isTalking;

    private Queue<string> lines;

    void Start()
    {
        dialogueBox.SetActive(false);

        isTalking = false;

        lines = new Queue<string>();
    }

    public void startTalking(string speaker, string[] text)
    {
        isTalking = true;

        dialogueBox.SetActive(true);

        speakingName.text = speaker;

        lines.Clear();

        Debug.Log("Starting test");

        foreach (string i in text)
        {
            lines.Enqueue(i);
        }

        keepTalking();

    }

    public void keepTalking()
    {
        if (lines.Count == 0)
        {
            isTalking = false;
            dialogueBox.SetActive (false);
            return;
        }

        string line = lines.Dequeue();
        speakingLines.text = line;
        Debug.Log(line);
    }

}
