using UnityEngine;

public class Trap_saw : MonoBehaviour
{
    [SerializeField] private float Damge;
    [SerializeField] private float maveDistand;
    [SerializeField] private float speed;
    private bool maveleft;
    private float leftmove;
    private float rightmove;


    private void Awake()
    {
        leftmove = transform.position.x - maveDistand;
        rightmove = transform.position.x + maveDistand;
    }

    private void Update()
    {
        if (maveleft)
        {
            if (transform.position.x > leftmove)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }

            else maveleft = false;
        }
        else
        {
            if (transform.position.x < rightmove)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else maveleft = true;
        }


    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHelth>().TakeDamege(Damge);
        }
    }

}
