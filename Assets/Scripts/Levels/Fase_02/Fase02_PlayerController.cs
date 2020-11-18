using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random=UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]

public class Fase02_PlayerController : PlayerBase_fase02
{
    public Fase02_References references;
    private Dictionary<string, bool> CollidablePlaces = new Dictionary<string, bool>();

    [SerializeField]
    public override float Ball_mass 
    { 
        get => _ball_mass;
        set => _ball_mass = value; 
    }
    public override float Box_mass 
    { 
        get => _box_mass;
        set => _box_mass = value; 
    }
    [SerializeField]
    public override float Acceleration 
    {
        get => _acceleration;
        set => _acceleration = value;
    }
    [SerializeField]
    public override float Gravity
    {
        get => _gravity;
        set => _gravity = value;
    }

    
    [HideInInspector] public List<Checkpoint> Checkpoints = new List<Checkpoint>();
    public int StartPlatformPosition = 0;
    private Animator PlayerAnimator;
    private Rigidbody PlayerRigidbody;
    private Fase02_GameState GSReference;
    private int MovementDirection = -1;
    [SerializeField] private float TimeSpanned = 0.0f;
    [SerializeField] private bool IsMoving = false;
    [SerializeField]  private bool JumpedMid = false;
    [SerializeField] private int jumpstates = 0;

    [HideInInspector] public string RunAnimationName = "is_running";
    [HideInInspector] public string JumpAnimationName = "is_going_upwards";
    [HideInInspector] public string WinAnimationName = "did_win";

    private Vector3 CurrentPosition;
    private Vector3 PreviousPosition;
    private float MovementRange = 0.0000005f; // gap in which movement is not considered. 
    public bool IsPlayerOnInitialPlatform = true;
    private InputFieldSwitcher InputFieldSwitcher;

    public override void Run()
    {
        if(!PlayerAnimator.GetBool(RunAnimationName))
        {
            PlayerAnimator.Play("Base Layer.Running",  0, 0.0f);   
        }
        StartAnimation(RunAnimationName);
        Vector3 force = MovementDirection 
                        * Vector3.forward
                        * _acceleration
                        * GSReference.UnitScale
                        ;
        PlayerRigidbody.AddForce(force, ForceMode.Force);
    }

    public void StopAnimation(string animationName)
    {
        //Debug.Log("Stopping " + animationName + " animation.");
        PlayerAnimator.SetBool(animationName, false);
    }

    public void StartAnimation(string animationName)
    {
        //Debug.Log("Starting " + animationName + " animation.") ;
        PlayerAnimator.SetBool(animationName, true);
    }

    public void StopMovement()
    {
        PlayerRigidbody.velocity = Vector3.zero;
        PlayerRigidbody.angularVelocity = Vector3.zero;
    }

    private void CheckIfObjectIsMoving()
    {
        // If the object did not move
        if( // Lower limit
            (CurrentPosition.x >= PreviousPosition.x - MovementRange) &&
            (CurrentPosition.y >= PreviousPosition.y - MovementRange) &&
            (CurrentPosition.z >= PreviousPosition.z - MovementRange) &&
            // Upper limit
            (CurrentPosition.x <= PreviousPosition.x + MovementRange) &&
            (CurrentPosition.y <= PreviousPosition.y + MovementRange) &&
            (CurrentPosition.z <= PreviousPosition.z + MovementRange))
        {
            IsMoving = false;
        }
        else
        {
            IsMoving = true;    
        }
    }

    private void InitializeCollidablePlaces()
    {
        CollidablePlaces.Add("Untagged", false);
        CollidablePlaces.Add("Floor", false);
        CollidablePlaces.Add("Ceiling", true);
        CollidablePlaces.Add("Wall", true);
        CollidablePlaces.Add("StartPlatform", true);
        CollidablePlaces.Add("FinalPlatform", true);
        CollidablePlaces.Add("FinalPlatform-Collider", true);
        CollidablePlaces.Add("Boundaries", true);
    }

    public void ResetEverythingFromScratch()
    {
        Debug.Log("Resetting from scratch");
        _acceleration = 0.0f;
        Reset(Checkpoints[0]);
        Checkpoints.Clear();
    }

    public void Reset(Checkpoint ckp)
    {
        //Debug.Log("Reset() called.");
        StopMovement();
        ResetAnimation();
        ResetValues(ckp);
        ResetPosition(ckp);
    }

    public void ResetPosition(Checkpoint ckp)
    {
        //Debug.Log("ResetPosition() called.");

        StopMovement();
        PlayerRigidbody.isKinematic = true;
        transform.position = ckp.getPosition();
        transform.rotation = ckp.getRotation();
        PlayerRigidbody.isKinematic = false;
    }

    public void ResetValues(Checkpoint ckp)
    {
        //Debug.Log("ResetValues() called.");
        IsPlayerOnInitialPlatform = ckp.GetIsPlayerOnInitialPlatform();
        JumpedMid = ckp.getJumpedMid();
        TimeSpanned = 0.0f;
        jumpstates = ckp.jumpstates;
    }

    public void ResetAnimation()
    {
        //Debug.Log("ResetAnimation() called.");

        StopAnimation(RunAnimationName);
        StopAnimation(JumpAnimationName);
        PlayerAnimator.Play("Base Layer.Idle", 0, 0.0f);
    }

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

    private void Awake()
    {
        InitializeCollidablePlaces();
    }

    private void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerRigidbody = GetComponent<Rigidbody>();
        GSReference = references.GameState.GetComponent<Fase02_GameState>();
        InputFieldSwitcher = references.InputContainer.GetComponent<InputFieldSwitcher>(); 

        Physics.gravity = new Vector3(0.0f, -_gravity, 0.0f);
    }

    private void Update()
    {
        if(GSReference.States[GSReference.getSimulationName()])
        {
            TimeSpanned += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        CheckIfObjectIsMoving();
        if (Checkpoints.Count > 1) 
        {
            Fase02_ChangePlayerPosition.canChangePosition = false;
        }

        PreviousPosition = CurrentPosition;
        CurrentPosition = transform.position;

        /*if ( GSReference.States[GSReference.getSimulationName()] )
        {
            if (IsPlayerOnInitialPlatform)
            {
                Run();
            }
        }*/
    }

    private void OnTriggerEnter(Collider other) {
        string tag = other.transform.tag;
        string name = other.transform.name;

        //Debug.LogFormat("tag = {0}  name = {1}", tag, name);

        if ((name == "PM - Collider" && Checkpoints.Count == 1) || (name == "PF - Collider" && Checkpoints.Count == 2))
        {
            //Debug.Log("Colidiu com um dos colliders das outras plataformas.");
            StopMovement();
        }

    }

    public void setMassValue(float value){
        PlayerRigidbody.mass = value;
    }

    //Set values using float
    public void setAcceleration(float value){
        _acceleration = value;
    }
    public void setBallMass(){
        Debug.Log("Cheguei");
        int value = Random.Range(3,10);
        _ball_mass = value;
        setMassValue(_ball_mass);
    }
    public void setBoxMass(float value){
        _box_mass = value;
        setMassValue(value);
    }
    public void setGravity(float value){
        _gravity = value;
    }
    // Set value using string
    public void setAcceleration(string value)
    {
        _acceleration = ParseValue(value);
    }
    
    public void setGravity(string value){
        _gravity = ParseValue(value);
    }
    
    public void setBoxMass(string value){
        _box_mass = ParseValue(value);
        setMassValue(_box_mass);
    }
}
