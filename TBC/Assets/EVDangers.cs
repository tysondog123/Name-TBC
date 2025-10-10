using UnityEngine;
using UnityEngine.UIElements;

public class EVDangers : MonoBehaviour
{
    public int Damage;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerController>().TakeDamage(Damage);
        }
        
    }
}
