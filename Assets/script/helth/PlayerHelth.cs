using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelth : MonoBehaviour

{
    [Header ("Helth")]
    [SerializeField] private float startHelth;
    public float playercarentHelth;
    private Animator anim;
    private bool death;


    [Header("Iframe")]
    public float iframduration;
    public float numberOfFlashes;
    private SpriteRenderer spriteren;

    private void Awake()
    {
        playercarentHelth = startHelth;
        anim = GetComponent<Animator>();
        spriteren = GetComponent<SpriteRenderer>();

    }

    public void TakeDamege(float Damage)
    {
        playercarentHelth = Mathf.Clamp(playercarentHelth - Damage, 0, startHelth);

        if (playercarentHelth > 0)
        {
            //player hart
            anim.SetTrigger("hut");
            StartCoroutine(invencivality());
        }

        else
        {
            //player Death
            if (!death)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                death = true;
            }
            
        }

    }
    
    public void addhelth(float addhelth)
    {
        playercarentHelth = Mathf.Clamp(playercarentHelth + addhelth, 0, startHelth);

    }

    private IEnumerator invencivality()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteren.color = new Color(1, 0, 0, .4f);
            yield return new WaitForSeconds(iframduration / (numberOfFlashes * 2));

            spriteren.color = Color.white;
            yield return new WaitForSeconds(iframduration / (numberOfFlashes * 2));

            Physics2D.IgnoreLayerCollision(8, 9, false);
        }

    }


}
