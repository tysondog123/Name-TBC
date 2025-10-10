using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public bool Positive;
    public int Heal;
    public Sprite Image;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Image;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Positive)
        {
            collision.GetComponent<PlayerController>().HP += Heal;
        }
        Destroy(gameObject);
    }
}
