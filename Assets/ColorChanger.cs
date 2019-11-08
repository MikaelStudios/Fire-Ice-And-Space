using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public static ColorChanger ColorChangerBox;

    public float Speed = 3f;
    // Start is called before the first frame update
    public void Awake()
    {
        ColorChangerBox = this;
    }

    // Update is called once per frame
    public void MoveDown()
    {
          transform.position += Speed * Time.deltaTime * new Vector3(0, -1, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameMaster.SharedInstance.ColorChange(); 
        }
    }
}
