using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    [Header("UI組件")]
    public TextMeshProUGUI textLabel;
    public Image faceImage;


    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    [Header("立繪")]
    public Sprite headPlayer;
    public Sprite headNPC;

    bool textFinished;  //文本是否跑完
    bool isTyping;  //是否在逐字顯示


    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFromFile(textFile);
    }

    void OnEnable()
    {
        index = 0;  //對話框每次隱藏變為顯示就重置對話
        textFinished = true;    //對話框每次隱藏變為顯示狀態變為文本已結束
        StartCoroutine(setTextUI());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && index == textList.Count)
        {
            gameObject.SetActive(false);
            return;
        }

        //按下F鍵，當前行文本完成就執行協程，當前行文本未完成就直接顯示當前行文本
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (textFinished)
            {
                StartCoroutine(setTextUI());
            }
            else if (!textFinished)
            {
                isTyping = false;
            }
        }

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    textLabel.text = textList[index];
        //    index++;
        //}
    }


    //從文本中獲取資料
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();//清空文本內容

        //切割文本文件內容然後一行一行加到list集合中
        var lineData = file.text.Split('\n');
        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator setTextUI()
    {
        textFinished = false;   //進入文字顯示狀態
        textLabel.text = "";    //重置文本內容

        //判斷文本文件裡的內容
        switch (textList[index].Trim())
        {
            case "A":
                faceImage.sprite = headPlayer;
                index++;
                break;
            case "B":
                faceImage.sprite = headNPC;
                index++;
                break;
        }

        //每按一次F鍵播放一行文字
        int word = 0;
        while (isTyping && word < textList[index].Length - 1)
        {
            //逐字顯示
            textLabel.text += textList[index][word];
            word++;
            yield return new WaitForSeconds(textSpeed);
        }
        //快速顯示文本內容為本行內容
        textLabel.text = textList[index];

        isTyping = true;
        textFinished = true;
        index++;
    }
}