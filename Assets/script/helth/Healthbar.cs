using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private PlayerHelth playerhelth;
    public Image totalHealth;
    public Image careantHealth;


    private void Start()
    {
        totalHealth.fillAmount = playerhelth.playercarentHelth / 10;

    }

    private void Update()
    {
        careantHealth.fillAmount = playerhelth.playercarentHelth / 10;
    }
}
