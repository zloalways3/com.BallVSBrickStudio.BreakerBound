using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallController : MonoBehaviour
{
    public float speed = 10f;
    private bool isLaunched = false; 
    public bool push = false;
    private bool pause = false;
    private AudioSource sound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            sound.Play();
        }
    }
    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(gameObject.transform.position.y >= 3.04f && GetComponent<Rigidbody2D>().velocity.y >= 0)
        {
            Debug.Log("asdas");
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -GetComponent<Rigidbody2D>().velocity.y);
        }
        if ((gameObject.transform.position.x >= 2.32f && GetComponent<Rigidbody2D>().velocity.x >= 0) || (gameObject.transform.position.x <= -2.32f && GetComponent<Rigidbody2D>().velocity.x <= 0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
        }
        if(Input.GetMouseButtonDown(0) && !isLaunched)
        {
            push = true;
        }
        if(push) 
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            Vector3 direction = mousePosition - transform.position;

            Debug.Log($"Mouse Position: {mousePosition}, Direction: {direction}");

            if (direction != Vector3.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Debug.Log($"Angle: {angle}");
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }

        if (Input.GetMouseButtonUp(0) && !isLaunched)
        {
            push = false;
            LaunchBall();
        }

        if(GetComponent<Rigidbody2D>().velocity.x == 0 && isLaunched && !pause)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + 1f, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (GetComponent<Rigidbody2D>().velocity.y == 0 && isLaunched && !pause)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y + 1f);
        }
    }

    void LaunchBall()
    {
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        
        Vector3 direction = (mousePosition - transform.position).normalized;

        
        GetComponent<Rigidbody2D>().velocity = direction * speed;

        isLaunched = true;

        transform.GetChild(0).gameObject.SetActive(false);
    }
}