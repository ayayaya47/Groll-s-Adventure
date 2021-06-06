using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoler2 : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // transform.position =new Vector3( player.position.x,player.position.y,-10);
        transform.position = new Vector3(player.position.x, 0, -10);
    }
}
