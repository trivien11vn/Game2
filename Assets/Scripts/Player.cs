using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameController m_gc;
    public float jumpForce;
    Rigidbody2D m_rb;
    bool m_isGround;

    public AudioSource aus;
    public AudioClip jumpSource;
    public AudioClip loseSource;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    
    void Update()
    {
        bool isJump = Input.GetKeyDown(KeyCode.Space);
        if(isJump && m_isGround){
            // vector * number -> vector
            // vector2.up = (0,1);
            // vd: (0,1) * jumpForce = (0,jumpForce)
            m_rb.AddForce(Vector2.up * jumpForce);
            m_isGround = false;

            if(aus && jumpSource) aus.PlayOneShot(jumpSource);
        }
    }
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Ground")){
            m_isGround =  true;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("cnv"))
        {
            if(aus && loseSource && !m_gc.isGameOver()) aus.PlayOneShot(loseSource);
            m_gc.SetGameOver(true);
            Debug.Log("Player đã va chạm với chướng ngại vật");
        }
    }
    public void Jump(){
        if(!m_isGround) return;
        m_rb.AddForce(Vector2.up * jumpForce);
        m_isGround = false;
        if(aus && jumpSource) aus.PlayOneShot(jumpSource);
    }
}
