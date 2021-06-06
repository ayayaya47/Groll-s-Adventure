using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPanel : MonoBehaviour
{
    public GameObject Clearpanel;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Clearpanel.SetActive(true);
            
        }
    }
}
