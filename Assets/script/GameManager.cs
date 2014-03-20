﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public int m_score = 0;

    public static int m_hiscore = 0;

    protected Player m_player;

    public AudioClip m_musicClip;

    protected AudioSource m_Audio;

    void Awake()
    {
        Instance = this;
    }



	// Use this for initialization
	void Start () 
    {
        m_Audio = this.audio;

        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj != null)
        {
            m_player = obj.GetComponent<Player>();
        }
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!m_Audio.isPlaying)
        {
            m_Audio.clip = m_musicClip;
            m_Audio.Play();
        }

        if (Time.timeScale > 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
        }
	
	}

    void OnGUI()
    {
        if (Time.timeScale == 0)
        {
            if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.4f, 100, 30), "继续游戏"))
            {
                Time.timeScale = 1;
            }

            if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.6f, 100, 30), "退出游戏"))
            {
                Application.Quit();
            }

            
        }

        int life = 0;
        if (m_player != null)
        {
            life = (int)m_player.m_life;

        }
        else
        {
            GUI.skin.label.fontSize = 50;
            GUI.skin.label.alignment = TextAnchor.LowerCenter;
            GUI.Label(new Rect(0,Screen.height * 0.2f, Screen.width,60), "游戏失败");

            GUI.skin.label.fontSize = 20;

            if (GUI.Button(new Rect(Screen.width * 0.5f-50, Screen.height * 0.5f, 100, 30), "再试一次"))
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
        }

        GUI.skin.label.fontSize = 15;
        GUI.Label(new Rect(5, 5, 100, 30), "装甲" + life);

        GUI.skin.label.alignment = TextAnchor.LowerCenter;

        GUI.Label(new Rect(0,5,Screen.width,30),"记录"+m_hiscore);

        GUI.Label(new Rect(0, 25, Screen.width, 30), "得分" + m_score);


    }


    public void AddScore(int point)
    {
        m_score += point;
        if (m_hiscore < m_score)
            m_hiscore = m_score;
    }
}
