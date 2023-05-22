using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaitCount : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    // Update is called once per frame
    public void UpdateWaitText(int value)
    {
        text.text = "wait: " + value +"s";
    }
}
