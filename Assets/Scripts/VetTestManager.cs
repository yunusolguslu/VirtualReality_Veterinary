using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VetTestManager : MonoBehaviour
{
    public List<TextsAndChoices> textAndChoices;
    public TextsAndChoices[] retryQuestions;
    public GameObject[] options;
    public int currentQTextNum;

    public GameObject testUIpanel;
    public GameObject resultUIpanel;

    public Text questionTxt;
    public Text successTxt;

    int totalQTexts = 0;
    public int successfulResult;
    public int indx;

    public Choice choice;
    public void Start()
    {
        totalQTexts = textAndChoices.Count;
        retryQuestions = new TextsAndChoices[totalQTexts];
        resultUIpanel.SetActive(false);
        GenerateQuestion();
    }

    public void Retry()
    {

        for (int i = 0; i < retryQuestions.Length; i++)
        {
            textAndChoices.Add(retryQuestions[i]);
        }
        indx = 0;
        successfulResult = 0;
        GenerateQuestion();
        testUIpanel.SetActive(true);
        resultUIpanel.SetActive(false);
        
    }

    public void FinishTst()
    {
        testUIpanel.SetActive(false);
        resultUIpanel.SetActive(true);
        successTxt.text = successfulResult + "/" + totalQTexts;
        
    }

    public void RightRslt()
    {
        successfulResult += 1;
        retryQuestions[indx] = textAndChoices[currentQTextNum];
        indx++;
        textAndChoices.RemoveAt(currentQTextNum);
        StartCoroutine(WaitForIt());
    }


    public void FailRslt()
    {
        retryQuestions[indx] = textAndChoices[currentQTextNum];
        indx++;
        textAndChoices.RemoveAt(currentQTextNum);
        StartCoroutine(WaitForIt());
    }
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1);
        GenerateQuestion();
    }

    void SetChoices()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<Choice>().dftColor;
            options[i].GetComponent<Choice>().isRight = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = textAndChoices[currentQTextNum].AChoices[i];
            if (textAndChoices[currentQTextNum].RightChoice == i + 1)
            {
                options[i].GetComponent<Choice>().isRight = true;
            }
        }
    }

    void GenerateQuestion()
    {
        if (textAndChoices.Count > 0)
        {
            //list of questiondan random question
            currentQTextNum = Random.Range(0, textAndChoices.Count);
            questionTxt.text = textAndChoices[currentQTextNum].QText;
            SetChoices();
        }
        else
        {
            FinishTst();
        }
    }
}
