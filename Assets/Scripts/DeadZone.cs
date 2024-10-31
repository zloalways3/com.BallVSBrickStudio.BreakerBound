using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameManager gm;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            gm.DeadBall();
        }
    }
}
