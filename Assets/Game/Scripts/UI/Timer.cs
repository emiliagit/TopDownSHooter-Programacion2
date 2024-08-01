using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int min = 1;
    private int seg = 00;

    [SerializeField] TextMeshProUGUI tiempo;
    

    public float restante;
    private bool EnMarcha;

    private void Awake()
    {
        restante = (min * 60) + seg;
        EnMarcha = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnMarcha)
        {
            restante -= Time.deltaTime;

            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{00:00} : {01:00}", tempMin, tempSeg);
        }
    }
}
