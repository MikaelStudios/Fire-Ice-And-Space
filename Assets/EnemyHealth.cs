using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int Health;
    string[] Colors = {"Red","Blue" };
    string _CurrColor;
    string CurrentColor 
    {
        get { return _CurrColor; }
        set 
        {
             _CurrColor = value;
            if (_CurrColor == Colors1[0]) { gameObject.GetComponent<SpriteRenderer>().color = Color.red; gameObject.tag = Colors1[0]; }
            else if (_CurrColor == Colors1[1]) { gameObject.GetComponent<SpriteRenderer>().color = Color.blue; gameObject.tag = Colors1[1]; }
        }

    }

    public string[] Colors1 { get => Colors; set => Colors = value; }

    private void Start()
    {
        CurrentColor = Colors1[Random.Range(0, 2)];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Colors1[0]) && this.gameObject.CompareTag(Colors1[0]))
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag(Colors1[1]) && this.gameObject.CompareTag(Colors1[1]))
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
          transform.position += 0.6f * Time.deltaTime * new Vector3(0, -1, 0);
    }
}
