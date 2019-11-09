using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementClass : MonoBehaviour
{

     public void CameraBounds(GameObject OBJ, Camera MainCamera)
        {
            float CameraSize;
            CameraSize = MainCamera.pixelWidth / 89;
            //rb.AddForce(transform.position* Speed * horizontal);
            //rb.MovePosition((transform.position + transform.right) * Time.deltaTime * Speed);
            if (OBJ.transform.position.x >= (CameraSize))
            {
                OBJ.transform.position = new Vector3(CameraSize, OBJ.transform.position.y, 0);
            }
            else if (OBJ.transform.position.x <= -(CameraSize))
            {
                OBJ.transform.position = new Vector3(-CameraSize, OBJ.transform.position.y, 0);
            }
        }
     public void MovementByTransform(GameObject OBJ, float Speed)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            OBJ.transform.position += Speed * Time.deltaTime * new Vector3(horizontal, 0, 0);
        }
     public void MovementByMovePos(GameObject OBJ, Rigidbody2D rb, float Speed)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            rb.MovePosition(OBJ.transform.position + new Vector3(horizontal, 0, 0) * Speed * Time.deltaTime);
        }

      public void MovementByVelocity(Rigidbody2D rb, float Speed)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontal, 0) * Speed * Time.deltaTime * 100;
        }

       public void MovementByAddingForce(Rigidbody2D rb, float Speed, Vector2 horizontal)
        {
            //horizontal = Input.GetAxisRaw("Horizontal");
            rb.AddForce(horizontal * Speed * Time.deltaTime,ForceMode2D.Impulse);
        }
    }
