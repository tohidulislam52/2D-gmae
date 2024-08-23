using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public LayerMask groundlayre;
    public LayerMask walllayre;
    private Animator anim;
    private BoxCollider2D boxCollider;
    public float speed;
    [SerializeField] private float jumppppp;
    private float walljumpcoldown;
    private float horizontal;
    

    //private bool playerjump;

    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        // player move left rith
        float scala = 1.3f;
         horizontal = Input.GetAxis("Horizontal");

        

        if (horizontal < -0.01f)
            transform.localScale = new Vector3(-scala, scala, scala);

        else if (horizontal > 0.01f)
            transform.localScale = new Vector3(scala, scala, scala);


        


        anim.SetBool("run", horizontal != 0);
        anim.SetBool("jumpp", playerjump());

        //Debug.Log(onwall());
        // wall jump logic
        if (walljumpcoldown < 0.2f)
        {
            body.velocity = new Vector2(horizontal * speed, body.velocity.y);

            


            if (onwall() && !playerjump())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 3;
            }

            if (Input.GetKey(KeyCode.Space))
                jump();



        }
        else
            walljumpcoldown += Time.deltaTime;

        
    }
    private void jump()
    {
        if (playerjump()) { 
        
            body.velocity = new Vector2(body.velocity.x, jumppppp);
            anim.SetTrigger("triger");
            //playerjump() = false;
        }
        else if(onwall() && !playerjump())
        {
            if (horizontal == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 1, 6);
            walljumpcoldown = 0;
            
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "graund")
    //        playerjump = true;


    private bool playerjump()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundlayre);
        return (raycastHit.collider != null) ;
    }
    
    private bool onwall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, walllayre);
        return (raycastHit.collider != null);
    }
    public bool canAttak()
    {
        return horizontal == 0 && playerjump() && !onwall();
    }
    



}
