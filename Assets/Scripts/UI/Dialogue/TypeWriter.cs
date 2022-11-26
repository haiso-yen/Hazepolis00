using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class TypeWriter : MonoBehaviour
{

    public float charsPerSecond = 0.2f;//打字時間間隔
    private string words;//保存需要顯示的文字

    private bool isActive = false;
    private float timer;//計時器
    private TextMeshProUGUI myText;
    private int currentPos = 0;//當前打字位置

    // Use this for initialization
    void Start()
    {
        timer = 0;
        isActive = true;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);
        myText = GetComponent<TextMeshProUGUI>();
        words = myText.text;
        myText.text = "";//獲取Text的文本信息，保存到words中，然後動態更新文本顯示內容，實現打字機的效果
    }

    // Update is called once per frame
    void Update()
    {
        OnStartWriter();
        //Debug.Log (isActive);
    }

    public void StartEffect()
    {
        isActive = true;
    }
    /// <summary>
    /// 執行打字任務
    /// </summary>
    void OnStartWriter()
    {

        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {//判斷計時器時間是否到達
                timer = 0;
                currentPos++;
                myText.text = words.Substring(0, currentPos);//刷新文本顯示內容

                if (currentPos >= words.Length)
                {
                    OnFinish();
                }
            }

        }
    }
    /// <summary>
    /// 結束打字，初始化數據
    /// </summary>
    void OnFinish()
    {
        isActive = false;
        timer = 0;
        currentPos = 0;
        myText.text = words;
    }




}