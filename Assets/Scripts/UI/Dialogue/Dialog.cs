using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
   
    //說話音效
    public AudioSource TextSoundEffect;
    public AudioClip TextSE;

    void Start() {
        StartCoroutine(Type());
    }

    //跑完句子顯示繼續按紐
    void Update() {

        if (textDisplay.text == sentences[index]) {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type(){

        foreach (char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            //說話音效
            TextSoundEffect.PlayOneShot(TextSE);
        }
    
    }

    //繼續顯示下一句
    public void NextSentence() {

        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text ="";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text ="";
            continueButton.SetActive(true);
        }
    }
}
