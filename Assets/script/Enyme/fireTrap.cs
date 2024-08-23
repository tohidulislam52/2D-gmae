using UnityEngine;
using System.Collections;

public class fireTrap : MonoBehaviour
{
    [SerializeField] private float damege;

    [Header ("fire trap")]
    [SerializeField] private float FireactiveDaylay;
    [SerializeField] private float fireactiveTime;

    private bool triger;
    private bool Active;
    private SpriteRenderer sprite;
    private Animator anim;


    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(!triger)
            {
                StartCoroutine(fireactive());
            }

            if (Active)
            {
                collision.GetComponent<PlayerHelth>().TakeDamege(damege);
            }


        }
    }

   private IEnumerator fireactive()
    {
        triger = true;
        sprite.color = Color.red;
        yield return new WaitForSeconds(FireactiveDaylay);
        sprite.color = Color.white;
        anim.SetBool("fireactive", true);
        Active = true;
        yield return new WaitForSeconds(fireactiveTime);
        anim.SetBool("fireactive", false);
        triger = false;
        Active = false;

    }






}
