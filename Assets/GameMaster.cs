using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private Color DefaultColor;
    public float Timer = 5f;
    public bool TimerIsRandom = false;
    float CountdownToNextColor = 1f;
    public GameObject[] bullets;

    public static GameMaster SharedInstance;
    public void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        RandomTimer();
        int DC = UnityEngine.Random.Range(0, 2);
        if (DC == 0) { DefaultColor = Color.blue; } else { DefaultColor = Color.red; }
        ColorChange();
    }

    private void Update()
    {
        if (Time.time >= CountdownToNextColor)
        {
            if (ColorChanger.ColorChangerBox.SpawnReady == true)
            {
                ColorChanger.ColorChangerBox.MoveDown();
            }
            if (ColorChanger.ColorChangerBox.SpawnReady == false)
            {
                CountdownToNextColor = Timer + Time.time;
                ColorChanger.ColorChangerBox.SpawnReady = true;
            }


        }
    }
    private void RandomTimer() 
    {
        if (TimerIsRandom == true)
        {
            Timer = UnityEngine.Random.Range(Timer, Timer * 2);
        }
    }

    public void ColorChange()
    {
        RandomTimer();
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
        else { Debug.Log("There are no bullets"); }
    }
}
