using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class TypeWriter : MonoBehaviour
{

    public float charsPerSecond = 0.2f;//���r�ɶ����j
    private string words;//�O�s�ݭn��ܪ���r

    private bool isActive = false;
    private float timer;//�p�ɾ�
    private TextMeshProUGUI myText;
    private int currentPos = 0;//��e���r��m

    // Use this for initialization
    void Start()
    {
        timer = 0;
        isActive = true;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);
        myText = GetComponent<TextMeshProUGUI>();
        words = myText.text;
        myText.text = "";//���Text���奻�H���A�O�s��words���A�M��ʺA��s�奻��ܤ��e�A��{���r�����ĪG
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
    /// ���楴�r����
    /// </summary>
    void OnStartWriter()
    {

        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {//�P�_�p�ɾ��ɶ��O�_��F
                timer = 0;
                currentPos++;
                myText.text = words.Substring(0, currentPos);//��s�奻��ܤ��e

                if (currentPos >= words.Length)
                {
                    OnFinish();
                }
            }

        }
    }
    /// <summary>
    /// �������r�A��l�Ƽƾ�
    /// </summary>
    void OnFinish()
    {
        isActive = false;
        timer = 0;
        currentPos = 0;
        myText.text = words;
    }




}