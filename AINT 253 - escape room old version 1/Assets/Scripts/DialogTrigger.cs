using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    // tutorial followed: https://www.youtube.com/watch?v=_nRzoTzeyxU&list=WL&index=5&t=0s


    public Dialog dialog;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
            }
    
}
