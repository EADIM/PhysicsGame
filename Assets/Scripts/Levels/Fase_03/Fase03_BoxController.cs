﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random=UnityEngine.Random;

public class Fase03_BoxController : BoxBase_fase03
{
    private float movementSpeed = 1.0f;
    public Fase03_References references;
    public float upDuration = 3.0f;
    public PhysicMaterial Physicsmaterial;
    public float waitTime = 3.0f;
    private string finalPlace;

    
    [SerializeField]
    public override float Rounds
    {
        get => _rounds;
        set => _rounds = value;
    }
    [SerializeField]
    public override float Gravity
    {
        get => _gravity;
        set => _gravity = value;
    }
    [SerializeField]
    public override float Box_mass
    {
        get => _box_mass;
        set => _box_mass = value;
    }
    [SerializeField]
    public override float Radius_Motor
    {
        get => _radiusMotor;
        set => _radiusMotor = value;
    }
    [SerializeField]
    public override float Dynamic_Friction
    {
        get => _dynamic_Friction;
        set => _dynamic_Friction = value;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if(references.GameState.GetComponent<Fase03_GameState>().States[references.GameState.GetComponent<Fase03_GameState>().getSimulationName()]){
            if (moveUp){
                float horizontalInput =-(transform.localScale.x*5f);

                transform.position = transform.position + new Vector3(horizontalInput*movementSpeed*Time.deltaTime, 0, 0);

                //Debug.Log(transform.position);
            }
            else if (moveDown){
                float horizontalInput =(transform.localScale.x*5f);

                transform.position = transform.position + new Vector3(horizontalInput*movementSpeed*Time.deltaTime, 0, 0);

                Debug.Log(transform.position);
            }
        }*/
    }

    private void OnCollisionEnter(Collision other) {
        string name = other.transform.name;
        string tag = other.transform.tag;

        if(name == "Lost Sensor"){
            references.GameState.GetComponent<Fase03_GameState>().SwitchState(references.GameState.GetComponent<Fase03_GameState>().getLostName());
        }
        else if(name == "Target"){
            StartCoroutine("isOnTarget", "Piso do meio");
        }
        else if (tag == "Floor"){
            StartCoroutine("isOnTarget", name);
        }
    }

    private void OnTriggerEnter(Collider other) {
        string name = other.transform.name;
        if (name == "Return Friction"){
            withFriction();
        }
        else if(name == "RedZone"){
            StartCoroutine("isOnTarget", name);
        }
    }

    IEnumerator isOnTarget(string name){
        float time = 0f;
        for (; time <= waitTime; time+= 0.02f) 
        {
            yield return new WaitForSeconds(.02f);
        }
        if (finalPlace != name && finalPlace=="Target"){
            references.GameState.GetComponent<Fase03_GameState>().SwitchState(references.GameState.GetComponent<Fase03_GameState>().getWinName());
        }
        else{
            references.GameState.GetComponent<Fase03_GameState>().SwitchState(references.GameState.GetComponent<Fase03_GameState>().getLostName());
        }

        //Debug.Log(name + " Colidi com " + finalPlace);
    }

    private void OnCollisionStay(Collision other) {
        finalPlace = other.transform.name;
    }

    public void StartMovement()
    {
        if(references.GameState.GetComponent<Fase03_GameState>().States[references.GameState.GetComponent<Fase03_GameState>().getSimulationName()]){
            StartCoroutine("movimento", upDuration);
        }
        Debug.Log("UP: " + upDuration);
    }
    IEnumerator movimento(float waitTime) 
    {
        float time = 0f;
        for (; time <= waitTime; time+= 0.02f) 
        {
            Up();
            yield return new WaitForSeconds(.02f);
        }
        Debug.Log("Altura final: " + transform.localPosition.x + " " + transform.localPosition.y + " " + transform.localPosition.z);
        noFriction();
    }

    void Up(){
        float horizontalInput = -transform.localScale.x;

        transform.position = transform.position + new Vector3(horizontalInput*movementSpeed*Time.deltaTime, 0, 0);
    }

    void noFriction(){
        references.Player.GetComponent<Fase03_PlayerController>().StopAnimation("isPushing");
        Physicsmaterial.dynamicFriction = 0.0f;
    }

    public void withFriction(){
        Physicsmaterial.dynamicFriction = _dynamic_Friction;
    }

    public void stopMoviment(){
        StopCoroutine("movimento");
    }

    public void stopAllCoroutines(){
        StopAllCoroutines();
    }

    public void ResetEverythingFromScratch(){
        _rounds = 0.0f;

    }

    ////////////////        Inputs and Variables         ////////////////////
    
    private float ParseValue(string text)
    {
        float value = 0.0f;

        try
        {
            value = float.Parse(text);
        }
        catch(Exception e)
        {
            Debug.Log(e.ToString() + ": Could not parse " + text);
        }

        return value;
    }
    //Set values using float
    public void setMotorRounds(float value){
        _rounds = value;
        upDuration = _rounds;
    }
    public void setBoxMass(float value){
        _box_mass = value;
    }
    public void setRadiusMotor(){
        int value = Random.Range(1,4);
        _radiusMotor = value;
    }
    public void setDynamicFriction(float value){
        _dynamic_Friction = value;
    }
    public void setGravity(float value){
        _gravity = value;
    }

    //Set values using string
    public void setMotorRounds(string value){
        _rounds = ParseValue(value);
        upDuration = _rounds;
    }
    public void setBoxMass(string value){
        _box_mass = ParseValue(value);
    }
    /*public void setRadiusMotor(string value){
        _box_mass = ParseValue(value);
    }*/
    public void setDynamicFriction(string value){
        _box_mass = ParseValue(value);
    }
    public void setGravity(string value){
        _gravity = ParseValue(value);
    }
}