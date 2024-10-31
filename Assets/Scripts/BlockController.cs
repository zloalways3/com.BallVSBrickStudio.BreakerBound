using UnityEngine;
using UnityEngine.UI;

public class BlockController : MonoBehaviour
{
    public int lives = 1;

    public Text txtlives;

    public int damage = 1;
    private void Update()
    {
        txtlives.text = lives + "";
    }
    private void Start()
    {
        damage = PlayerPrefs.GetInt("x") + 2;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ball"))
        {
           
            lives -= damage;

            
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

