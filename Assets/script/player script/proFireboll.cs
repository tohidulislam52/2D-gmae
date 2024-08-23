using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proFireboll : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxcoo;
    public float spped;
    private bool hit;
    private float diraction;
    private float lifetime;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxcoo = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        if (hit) return;
        float movement = spped * Time.deltaTime *diraction;
        transform.Translate(movement, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxcoo.enabled = false;
        anim.SetTrigger("explor");
    }

    public void setderaction(float _diraction)
    {
        lifetime = 0;
        diraction = _diraction;
        hit = false;
        gameObject.SetActive(true);
        boxcoo.enabled = true;

        float localscalX = transform.localScale.x;
        if (Mathf.Sign(localscalX) != _diraction)
        {
            localscalX = -localscalX;
        }
        transform.localScale = new Vector3(localscalX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }


}
