using UnityEngine;

public class Enyme_Damage : MonoBehaviour
{
    [SerializeField] private float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerHelth>().TakeDamege(Damage);
        }
    }



}
