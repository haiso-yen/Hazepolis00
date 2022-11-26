using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
       //EditorApplication.isPlaying = false; 
        
       //這是因為Application.Quit是在遊戲Build後才會有作用，編輯狀態下是無效的
       // 如果想要在編輯狀態下關閉執行的話要使用到EditorApplication.isPlaying這個參數

    }
}
