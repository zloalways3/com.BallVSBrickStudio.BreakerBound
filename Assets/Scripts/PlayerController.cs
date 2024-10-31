using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float boundary;

    



    void Update()
    {


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                transform.position = new Vector3(
                    Mathf.Clamp(touchPosition.x, -boundary, boundary),
                    transform.position.y,
                    transform.position.z
                );
            }
        }
        else
        {
            
            float moveHorizontal = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(moveHorizontal, 0, 0);
            transform.position += movement * speed * Time.deltaTime;

            
            float clampedX = Mathf.Clamp(transform.position.x, -boundary, boundary);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }
}

