using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float Jumpforce;
    public float MoveSpeed;
    public float CanJump=2;
    public float DashSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (CanJump > 0)
        {
            Jump();    
        }
        
    }
    public void Movement()
    {
        float Hor = Input.GetAxis("Horizontal");
        
        rb.linearVelocityX = Hor*MoveSpeed;
        if (Input.GetButtonDown("Dash"))
        {
            rb.linearVelocityX = (Hor*MoveSpeed)*DashSpeed;
        }
    }
    
    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForceY(Jumpforce, ForceMode2D.Impulse);
            CanJump--;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.CompareTag("Floor"))
        {
            CanJump = 2;
        }
    }
}
