using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollBar : MonoBehaviour
{
    // public Text healthText;
    public static int CollCurrent;
    public static int CollMax;

    private Image gemcount;

    // Start is called before the first frame update
    void Start()
    {
        gemcount = GetComponent<Image>();
        //HealthCurrent = HealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        gemcount.fillAmount = (float)CollMax / (float)CollCurrent;
        //healthText.text = HealthCurrent.ToString() + "/" + HealthMax.ToString();
    }
}