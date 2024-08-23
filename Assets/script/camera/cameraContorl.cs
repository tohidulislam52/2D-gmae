using UnityEngine;

public class cameraContorl : MonoBehaviour
{
    //Room camera
    public float speed;
    private Vector3 valicity = Vector3.zero;
    private float carentPosition;
    public float plass;

    


    //floow player
    public Transform player;
    public float playerDictand;
    private float floowPlayer;


    private void Update()
    {
        //Roon camera
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(carentPosition, transform.position.y, transform.position.z),
            ref valicity, speed);
        // floow player
        //transform.position = new Vector3(player.position.x + floowPlayer, transform.position.y, transform.position.z);
        //floowPlayer = Mathf.Lerp(floowPlayer, (playerDictand * player.localScale.x), speed * Time.deltaTime);


    }


    //Room camera
    public void movenewRoom(Transform position)
    {
        carentPosition = (position.position.x) + plass ;
        //carentPosition = carentPosition + plass;
    }


}
