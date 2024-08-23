using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform agerRoom;
    public Transform nextRoom;
    public cameraContorl camer;

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Debug.Log("fhdj");
            if (collision.transform.position.x < transform.position.x)
            {
                camer.movenewRoom(nextRoom);
                nextRoom.GetComponent<Room>().ActiveRoom(true);
                agerRoom.GetComponent<Room>().ActiveRoom(false);
            }

            else
            {
                camer.movenewRoom(agerRoom);
                nextRoom.GetComponent<Room>().ActiveRoom(false);
                agerRoom.GetComponent<Room>().ActiveRoom(true);

            }



        }
    }



}
