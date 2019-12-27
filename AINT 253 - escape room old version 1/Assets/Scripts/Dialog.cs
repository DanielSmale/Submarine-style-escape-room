using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    // tutorial followed: https://www.youtube.com/watch?v=_nRzoTzeyxU&list=WL&index=5&t=0s


    public string name;

    [TextArea(3, 10)]
    public string[] sentences;
    

    
}
