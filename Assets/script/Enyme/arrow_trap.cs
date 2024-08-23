using UnityEngine;

public class arrow_trap : MonoBehaviour
{
    private float coldowntime;
    [SerializeField] private float atackcouldawn;
    [SerializeField] private Transform arrowPoint;
    [SerializeField] private GameObject[] allarrows;




    private void Update()
    {
        coldowntime += Time.deltaTime;
        if (coldowntime > atackcouldawn)
            Attack();

    }
    private void Attack()
    {
        coldowntime = 0;
        allarrows[fineArrow()].transform.position = arrowPoint.position;
        allarrows[fineArrow()].GetComponent<arrow_Holder>().activeArrow();

    }

    private int fineArrow()
    {
        for (int i = 0; i < allarrows.Length; i++)
        {
            if (!allarrows[i].activeInHierarchy)
                return i;
        }

        return 0;
    }




}
