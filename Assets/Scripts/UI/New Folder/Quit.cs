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
        
       //�o�O�]��Application.Quit�O�b�C��Build��~�|���@�ΡA�s�説�A�U�O�L�Ī�
       // �p�G�Q�n�b�s�説�A�U�������檺�ܭn�ϥΨ�EditorApplication.isPlaying�o�ӰѼ�

    }
}
