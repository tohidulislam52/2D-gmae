
using UnityEngine;

public class Health_calettor : MonoBehaviour
{
    [SerializeField] private float HealthNumber;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "Player")
        {
            collision.GetComponent<PlayerHelth>().addhelth(HealthNumber);
                gameObject.SetActive(false);
        }
    }

}
