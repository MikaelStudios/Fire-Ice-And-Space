using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player_Controller : MonoBehaviour
{
    [Header("Ship's movement atrributes")]
    [SerializeField]
    private float Speed = 5;
    private Rigidbody2D rb;
    Camera MainCamera;
    MovementClass mv;

    [Header("Shooting Atrributes")]
    public float shootingDelay =0.1f;
    float Timer = 0;
    public GameObject[] ShootPoints;
    ObjectPooler obpool;
    
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        MainCamera = Camera.main;
         mv = this.gameObject.GetComponent<MovementClass>();
        obpool = ObjectPooler.instance;
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= shootingDelay) 
        {
            Shoot();
            Timer = 0;
        }
        mv.MovementByMovePos(this.gameObject, rb, Speed);
        mv.CameraBounds(this.gameObject,MainCamera);
    }
   
    void Shoot() 
    {
        for (int i = 0; i < ShootPoints.Length; i++)
        {
            //Instantiate(Bullet,ShootPoints[i].transform.position,ShootPoints[i].transform.rotation);
            obpool.SpawnFromPool("Bullets", ShootPoints[i].transform.position, ShootPoints[i].transform.rotation);
        }
    }
}


