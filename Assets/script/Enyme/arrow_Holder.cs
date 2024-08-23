using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_Holder : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float resatTime;
    private float lifetime;



    private void Update()
    {
        float movement = speed * Time.deltaTime;

        transform.Translate(movement, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resatTime)
            gameObject.SetActive(false);


    }


    public void activeArrow()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
            gameObject.SetActive(false);
    }
}
