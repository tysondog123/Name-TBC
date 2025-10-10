using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float Jumpforce;
    public float MoveSpeed;
    public float CanJump=2;
    public float DashSpeed;

    public int HP;
    public float IVFrames;
    public float IVTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
        if(IVTimer > 0) 
        {
            IVTimer -= Time.deltaTime;
            if(IVTimer < 0)
            {
                IVTimer = 0;

            }
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Dash();
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
           Movement();
        }

        if (CanJump > 0)
        {
            Jump();    
        }
        
    }
    public void Movement()
    {
        float Hor = Input.GetAxis("Horizontal");
        
        rb.linearVelocityX = Hor*MoveSpeed;
        
    }
    
    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocityY = 0;
            rb.AddForceY(Jumpforce, ForceMode2D.Impulse);
            CanJump--;
        }
    }

    public void Dash()
    {
      
      Vector2 DashVec = new Vector2(1,0);
      rb.AddForceX(rb.linearVelocityX+ 1*DashSpeed,ForceMode2D.Impulse); 
      Debug.Log(DashVec * DashSpeed);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.CompareTag("Floor"))
        {
            CanJump = 2;
        }
    }


    public void TakeDamage(int Damage)
    {
        Debug.Log("Collision");
        if (IVTimer <= 0)
        {
            IVTimer = IVFrames;
            HP -= Damage;
        }
        else
        {
            Debug.Log("Cant Hit");
        }
    }
}
