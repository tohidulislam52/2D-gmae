using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator anim;
    public float Attackcooldown;
    private float cooldowntime;
    public Transform firepoint;
    public GameObject[] fireboll;
    private proFireboll proFirebolll;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        proFirebolll = GetComponent<proFireboll>();
        playerMovement = GetComponent<PlayerMovement>();
        

    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldowntime > Attackcooldown && playerMovement.canAttak())
            attack();
        cooldowntime += Time.deltaTime;
    }

    private void attack()
    {
        //Debug.Log("Attack");
       
        anim.SetTrigger("Attack");
        cooldowntime = 0;
        fireboll[finefireboll()].transform.position = firepoint.position;
        fireboll[finefireboll()].GetComponent<proFireboll>().setderaction(Mathf.Sign(transform.localScale.x));
    }

    private int finefireboll()
    {
        for (int i =0; i<fireboll.Length; i++)
        {

            if (!fireboll[i].activeInHierarchy)
                return i;
            
        }
        return 0;
    }


    


}
