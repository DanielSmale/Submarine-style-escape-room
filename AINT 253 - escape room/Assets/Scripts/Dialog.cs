using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialog : MonoBehaviour
{
    //tutorial followed: https://www.youtube.com/watch?v=f-oSXg6_AMQ&list=WL&index=15&t=0s

    public Text textDisplay;

    [TextArea(3, 10)]
    public string[] sentences;

    private int index;
    public float typingSpeed;

    public GameObject nextButton;
    public GameObject btnA1;
    public GameObject btnB1;
    public GameObject btnC1;

    public GameObject btnA2;
    public GameObject btnB2;
    public GameObject btnC2;

    public GameObject btnA3;
    public GameObject btnB3;
    public GameObject btnC3;

    public GameObject question1UI;
    public GameObject question2UI;
    public GameObject question3UI;

    private AudioSource typeSound;

    string failQ1 = "We're on course to target"; // the messages that are printed on passing / failing each question
    string passQ1 = "We're lost";

    string failQ2 = "We've made it";
    string passQ2 = "We can't hit the target from here";

    string q3Result = "We hit them comrade!"; // and the count of civilian casulites should be recorded


    private void Start()
    {
        typeSound = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (textDisplay.text == sentences[0])
        {
            question1UI.SetActive(true);

            btnA1.SetActive(true);
            btnB1.SetActive(true);
            btnC1.SetActive(true);
        }

        if (textDisplay.text == sentences[1])
        {
            question2UI.SetActive(true);

            btnA2.SetActive(true);
            btnB2.SetActive(true);
            btnC2.SetActive(true);
        }

        if (textDisplay.text == sentences[2])
        {
            btnA3.SetActive(true);
            btnB3.SetActive(true);
            btnC3.SetActive(true);


            question3UI.SetActive(true);
        }

    }
    public void Question1Fail()
    {
        textDisplay.text = ""; // clear the text if theres any previous stuff in it

        foreach (char letter in failQ1.ToCharArray())
        {
            textDisplay.text += letter;
            new WaitForSeconds(typingSpeed);
        }

        nextButton.SetActive(true);
        btnA1.SetActive(false);
        btnB1.SetActive(false);
        btnC1.SetActive(false);
        question1UI.SetActive(false);

        FindObjectOfType<GameManager>().EndGame();
    }

    public void Question1Pass()
    {
        textDisplay.text = ""; // clear the text if theres any previous stuff in it

        foreach (char letter in passQ1.ToCharArray())
        {
            textDisplay.text += letter;
            new WaitForSeconds(typingSpeed);
        }

        nextButton.SetActive(true);
        btnA1.SetActive(false);
        btnB1.SetActive(false);
        btnC1.SetActive(false);
        question1UI.SetActive(false);
    }

    public void Question2Fail()
    {
        textDisplay.text = ""; // clear the text if theres any previous stuff in it

        foreach (char letter in failQ2.ToCharArray())
        {
            textDisplay.text += letter;
            new WaitForSeconds(typingSpeed);
        }

        nextButton.SetActive(true);
        btnA2.SetActive(false);
        btnB2.SetActive(false);
        btnC2.SetActive(false);

        question2UI.SetActive(false);

        FindObjectOfType<GameManager>().EndGame();

    }

    public void Question2Pass()
    {
        textDisplay.text = ""; // clear the text if theres any previous stuff in it

        foreach (char letter in passQ2.ToCharArray())
        {
            textDisplay.text += letter;
            new WaitForSeconds(typingSpeed);
        }

        nextButton.SetActive(true);
        btnA2.SetActive(false);
        btnB2.SetActive(false);
        btnC2.SetActive(false);

        question2UI.SetActive(false);


        question3UI.SetActive(true);
    }

    public void StartDialog()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type() // type the sentences stored in the array letter by letter
    {
        typeSound.Play();

        nextButton.SetActive(false);

        textDisplay.text = ""; // clear the text if theres any previous stuff in it

        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            nextButton.SetActive(false);
        }
    }
}
