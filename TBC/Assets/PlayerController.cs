using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float Jumpforce; // players jump speed
    public float MoveSpeed; // players move speed multiplier
    public float CanJump; // count for the number of times the player can jump
    public float DashSpeed; // the speed of the players dash
    float currentDash =0;
    float MoveCalc; // the players current movement direction
   

    public int HP; // players HP
    public float IVFrames; // how many IV Frams the player has
    float IVTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();// sets the RB veriable to the rigidbody
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
        // checks if player should take dammage based on iv frames
        

        float Hor = Input.GetAxis("Horizontal");
        MoveCalc = Hor * MoveSpeed;
        //sets the players move dir to the horizontal input value

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
          StartCoroutine(Dash());
        }
        //checks if the dash key is pressed
        
        rb.linearVelocityX = MoveCalc+(Hor*currentDash);

        if (CanJump > 0)
        {
            Jump();    
        }
        
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

    IEnumerator Dash()
    {
        float Test=2;
        while (Test > 0)
        {
            Debug.Log("dash");
            Test --;
            currentDash=DashSpeed;
            yield return new WaitForSeconds(.2f);
        }
        currentDash = 0;
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
