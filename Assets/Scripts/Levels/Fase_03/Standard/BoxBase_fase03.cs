using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoxBase_fase03 : MonoBehaviour
{
    protected float _rounds = 0.0f;
    protected float _box_mass = 10.0f;
    protected float _radiusMotor = 0.0f;
    protected float _dynamic_Friction = 0.3f;
    protected float _gravity = 9.81f;
    
    public abstract float Rounds {get; set;}
    public abstract float Box_mass { get; set; }
    public abstract float Radius_Motor { get; set; }
    public abstract float Dynamic_Friction {get; set;}
    public abstract float Gravity { get;set;}
}
