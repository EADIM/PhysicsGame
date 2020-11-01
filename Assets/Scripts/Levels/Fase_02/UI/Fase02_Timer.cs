﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase02_Timer : MonoBehaviour
{
    public Fase02_References references;
    private float seconds = 0.0f;
    private int minutes = 0;
    private int hours = 0;
    private Fase02_GameState gms;

    private void Start() 
    {
        gms = references.GameState.GetComponent<Fase02_GameState>();
        StartCoroutine(UpdateTime());
    }

    private IEnumerator UpdateTime()
    {
        while(true)
        {
            if(!gms.States[gms.getStartName()])
            {
                seconds += Time.deltaTime;
                if(seconds + Time.deltaTime >= 60)
                {
                    minutes += 1;
                    seconds = 0;
                }
            
                if(minutes > 60)
                {
                    hours += 1;
                    minutes = 0;
                }

                if(hours > 24)
                {
                    Reset();
                }
            }

            GetComponent<TMPro.TMP_Text>().text = hours.ToString("0#") + ":" + minutes.ToString("0#") + ":" + seconds.ToString("0#.");
            
            yield return null;
        }
    }

    public void Reset(){
        seconds = 0.0f;
        minutes = 0;
        hours = 0;
    }
}
