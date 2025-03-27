using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterSec : MonoBehaviour
{

    private int seconds = 0;
    bool isFirst = false;
    [SerializeField]
    private Text ValueTime;

    private IEnumerator Seconds()
    {
        yield return new WaitForSeconds(1);
    }


    private void CounterMethod()
    {
        if (seconds >= 0 && seconds <= 90)
        {
            ValueTime.text = "'"+seconds + "";
            //print("Update" + seconds);
            seconds++;
            //string valueSec = TimeSpan.FromSeconds(seconds).ToString("ss");

            isFirst = false;

        }
        else
        {
            //print("vvvwww" + seconds);
        }
        //yield return new WaitForSecondsRealtime(1);



    }
    // Start is called before the first frame update
    void Start()
    {
        print("sttt" + seconds);
        
            InvokeRepeating("CounterMethod", 0, 1.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isFirst)
        //{
        //    isFirst = true;
        //    if (seconds >= 0 && seconds <= 90)
        //    {

        //        StartCoroutine(Seconds());
        //        CounterMethod();
        //    }
        //    else
        //    {
        //        print("velse" + seconds);
        //        isFirst = true;
        //    }
        //}
    }
}
