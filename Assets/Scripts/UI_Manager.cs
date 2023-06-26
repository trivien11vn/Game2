using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameoverPanel;
    public void SetScoreText(string text){
        if(scoreText) scoreText.text = text;
    }

    public void ShowGameOverPanel(bool isShow){
        if(gameoverPanel != null) gameoverPanel.SetActive(isShow);
    }

}
