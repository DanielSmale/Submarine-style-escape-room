using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // tutorial followed: https://www.youtube.com/watch?v=_nRzoTzeyxU&list=WL&index=5&t=0s

    public Text nameText;
    public Text dialogText;

    private Queue<string> dialogSentences;


    void Start()
    {
        dialogSentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        nameText.text = dialog.name;

        dialogSentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            dialogSentences.Enqueue(sentence);
        }

        DisplayNextSentence();


    }

    public void DisplayNextSentence()
    {
        if (dialogSentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string currentSentence = dialogSentences.Dequeue();
        dialogText.text = currentSentence;
    }


    void EndDialog()
    {
        Debug.Log("End of conversation");
    }
}
