using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBase_fase02 : MonoBehaviour
{
    protected float _ball_mass = 1.0f;
    protected float _box_mass = 1.0f;
    protected float _acceleration = 0.0f;
    protected float _gravity = 9.81f;


    public abstract void Run();
    
    public abstract float Ball_mass { get; set; }
    public abstract float Box_mass { get; set; }
    public abstract float Acceleration { get;set; }
    public abstract float Gravity { get;set; }
}
