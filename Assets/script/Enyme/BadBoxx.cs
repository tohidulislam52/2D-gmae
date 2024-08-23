using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBoxx : MonoBehaviour
{
    [Header("boxmove")]

    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float chakedilay;
    [SerializeField] private LayerMask player;

    private bool attcaking;
    private float chaketime;
    private Vector3 diraction;
    private Vector3[] diractionss = new Vector3[4];

    [Header("animation")]
    private bool right;
    private bool left;
    private bool up;
    private bool down;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //private void OnEnable()
    //{
    //    stop();
    //}
    private void Update()
    {
        if (attcaking)
            transform.Translate(diraction * Time.deltaTime * speed);
        else
        {
            chaketime += Time.deltaTime;
            if (chaketime > chakedilay)
                chakeforplayerHit();
        }
    }

    private void chakeforplayerHit()
    {
        caculateDiraction();

        for (int i = 0; i < diractionss.Length; i++)
        {
            Debug.DrawRay(transform.position, diractionss[i],Color.red );
            RaycastHit2D hit = Physics2D.Raycast(transform.position, diractionss[i], range, player);
            
            if (hit.collider != null && !attcaking)
            {
                chaketime = 0;
                attcaking = true;
                diraction = diractionss[i];
            }


            if(i == 0 && hit.collider != null )
            {
                right = true;
            }
            if (i == 1 && hit.collider != null )
            {
                left = true;
            }
            if (i == 2 && hit.collider != null )
            {
                up = true;
            }
            if (i == 3 && hit.collider != null )
            {
                down = true;
            }

        }

    }

    private void caculateDiraction()
    {
        diractionss[0] = transform.right * range;
        diractionss[1] = -transform.right * range;
        diractionss[2] = transform.up * range;
        diractionss[3] = -transform.up * range;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        stop();
        if(collision.tag == "Player")
        {
            if (right)
                anim.SetTrigger("right");
            if (left)
                anim.SetTrigger("left");
            if (up)
                anim.SetTrigger("up");
            if (down)
                anim.SetTrigger("dworn");
            if(1==1)
            {
                right = false;
                left = false;
                up = false;
                down = false;
            }
                
      
        }
    }

    private void stop()
    {
        diraction = transform.position;
        attcaking = false;
    }

    private void boxanimation()
    {
        if (transform.position == new Vector3(-transform.position.x, transform.position.y, transform.position.z))
        {
            Debug.Log("djkf");
        }
    }

    
}
