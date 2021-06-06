using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelControl : MonoBehaviour
{
    public GameObject Panelcontrol;

    public void LogOn()
    {
        Panelcontrol.SetActive(true);
    }
    // Start is called before the first frame update
    public void SignIn()
    {
        Panelcontrol.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
