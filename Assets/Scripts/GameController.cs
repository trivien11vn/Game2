using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject obstacle;
    //spawntime: khoang thoi gian tao ra chuong ngai vat
    public float spawnTime;
    //mac ding la private
    float m_spawnTime;
    int m_score;
    bool m_isGameOver;

    //tham chieu den UI_Manager
    UI_Manager m_ui;
    // Start is called before the first frame update
    public void SetScore (int value){
        m_score = value;
    }
    public int GetScore(){
        return m_score;
    }
    public void ScoreIncrement(){
        if(m_isGameOver){
            return;
        }
        m_score +=1;
        m_ui.SetScoreText("SCORE: "+m_score);
    }
    public bool isGameOver(){
        return m_isGameOver;
    }
    public void SetGameOver(bool state){
        m_isGameOver = state;
    }
    public void SpawnObstacle(){
        float randomY = Random.Range(-4.0f,-2.0f);
        Vector2 spawnPos = new Vector2(11.54f,randomY);
        if (obstacle){
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
    }
    public void Replay(){
        SceneManager.LoadScene("SampleScene");
    }
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UI_Manager>();
        m_ui.SetScoreText("SCORE: "+m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameOver)
        {
            m_spawnTime = 0;
            m_ui.ShowGameOverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime<=0){
            SpawnObstacle();
            m_spawnTime = spawnTime;
        }
    }
}
