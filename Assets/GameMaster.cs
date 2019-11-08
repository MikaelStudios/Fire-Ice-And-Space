using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private Color DefaultColor;
    public float Timer = 5f;
    float CountdownToNextColor = 0;
    public GameObject[] bullets;

    public static GameMaster SharedInstance;
    public void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        bullets = new GameObject[40];
        int DC = UnityEngine.Random.Range(0, 2);
        if (DC == 0) { DefaultColor = Color.blue; } else { DefaultColor = Color.red; }
        ColorChange();
    }

    private void Update()
    {
        if (Time.time >= CountdownToNextColor)
        {
            CountdownToNextColor = Timer + Time.time;
            ColorChanger.ColorChangerBox.MoveDown();
        }
    }

    public void ColorChange()
    {
        if (bullets != null) 
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i] != null)
                {
                    if (bullets[i].GetComponent<SpriteRenderer>().color == Color.red)
                    {
                        bullets[i].GetComponent<SpriteRenderer>().color = Color.blue;
                        bullets[i].tag = "Blue";
                    }
                    else if (bullets[i].GetComponent<SpriteRenderer>().color == Color.blue)
                    {
                        bullets[i].GetComponent<SpriteRenderer>().color = Color.red;
                        bullets[i].tag = "Red";
                    }
                    else
                    {
                        bullets[i].GetComponent<SpriteRenderer>().color = DefaultColor;
                        if (DefaultColor == Color.red)
                        bullets[i].tag = "Red";
                        else { bullets[i].tag = "Blue"; }
                        
                    }
                }
            }
        }
    }
}
