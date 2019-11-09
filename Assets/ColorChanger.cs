using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public static ColorChanger ColorChangerBox;
    private Vector3 DefaultPosition;
    public float Speed = 3f;
   // [HideInInspector]
    public bool SpawnReady = true;
    // Start is called before the first frame update
    public void Awake()
    {
        ColorChangerBox = this;
    }
    private void Start()
    {
        DefaultPosition = transform.position;
    }

    // Update is called once per frame
    public void MoveDown()
    {
       // SpawnReady = false;
          transform.position += Speed * Time.deltaTime * new Vector3(0, -1, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameMaster.SharedInstance.ColorChange();
            transform.position = DefaultPosition;
            SpawnReady = false;
        }
    }

}
