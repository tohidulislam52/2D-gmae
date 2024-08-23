using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject[] eniymes;
    private Vector3[] carentPosition;

    private void Awake()
    {
        //Save the initial positions of the enemies
        carentPosition = new Vector3[eniymes.Length];
        for (int i = 0; i < eniymes.Length; i++)
        {
            if (eniymes[i] != null)
            {
                carentPosition[i] = eniymes[i].transform.position;
            }
        }
    }

   public void ActiveRoom(bool statas)
    {
        //Activate/deactivate enemies
        for (int i = 0; i < eniymes.Length; i++)
        {
            if(eniymes[i] != null)
            {
                eniymes[i].SetActive(statas);
                eniymes[i].transform.position = carentPosition[i];
            }
        }

    }






}

