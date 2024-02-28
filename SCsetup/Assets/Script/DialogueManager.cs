using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> diaLine;

    public TMP_Text nameText;
    public TMP_Text diaText;
    private string nextClue;


    void Start()
    {
        diaLine = new Queue<string>();
        nameText.text = "";
        diaText.text = "";
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        diaLine.Clear();
        diaText.color = Color.black;
        foreach (string line in dialogue.sentences)
        {
            diaLine.Enqueue(line);
        }
        nextClue = dialogue.nextClue;

        DisplayNext();
    }

    public void DisplayNext()
    {
        if(diaLine.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = diaLine.Dequeue();
        diaText.text = sentence; //
    }

    public void EndDialogue()
    {
        nameText.text = "";
        diaText.color = Color.blue;
        diaText.text = "[ " + nextClue + " ]";
    }
}
