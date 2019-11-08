using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private float Speed = 0.1f;
    private Rigidbody2D rigidBody;
    MovementClass mv;
    readonly string[] Colors = { "Red", "Blue" };
    string _CurrColor;
    string CurrentColor
    {
        get { return _CurrColor; }
        set
        {
            _CurrColor = value;
            if (_CurrColor == Colors[0]) { gameObject.GetComponent<SpriteRenderer>().color = Color.red; gameObject.tag = Colors[0]; }
            else if (_CurrColor == Colors[1]) { gameObject.GetComponent<SpriteRenderer>().color = Color.blue; gameObject.tag = Colors[1]; }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.SetActive(false);
    }

    void Awake()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        if (mv != null)
        {
            mv = this.gameObject.AddComponent<MovementClass>();
        }
        mv = this.gameObject.GetComponent<MovementClass>();
       // Destroy(gameObject, 2f);
    }
   

    // Update is called once per frame
    void Update()
    {
        // mv.MovementByAddingForce(rigidBody, Speed,transform.rotation * Vector2.up);
        //rigidBody.velocity = new Vector2(0, Speed * Time.deltaTime * 100);
        rigidBody.velocity = transform.rotation * Vector2.up * Speed * 100 * Time.deltaTime;
    }


    private void OnBecameInvisible()
    {
        _ = transform.rotation = Quaternion.Euler(Vector3.zero);
        this.gameObject.SetActive(false);

    }
}
