﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase03_GetProblemInfo : MonoBehaviour
{
    public Fase03_References references;
    public Fase03_SetProblemInfo setProblemInfo;
    
    public Vector3 dimensaoPlataformaInicial = Vector3.zero;
    public Vector3 dimensaoPlataformaFinal = Vector3.zero;

    private void Awake() {
        SetVariables();
    }

    private void Start() {
        SetVariables();
    }

    public void OnIntialPlatformChange(){
        setProblemInfo.OnInfoChanged(this);
    }

    public void OnVariablesChange(){
        SetVariables();
    }

    private void SetVariables(){
        
    }

    public Vector3 GetDimensaoPlataformaInicial(){
        return dimensaoPlataformaInicial;
    }

    public Vector3 GetDimensaoPlataformaFinal(){
        return dimensaoPlataformaFinal;
    }

}