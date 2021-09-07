using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public bool isRight = false;
    public VetTestManager testManager;
    public Color dftColor;

    public void Start()
    {
        dftColor = GetComponent<Image>().color;
    }

    public void Answer()
    {
        if (isRight)
        {
            GetComponent<Image>().color = Color.green;
            testManager.RightRslt();         
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            testManager.FailRslt();
        }
    }
}
