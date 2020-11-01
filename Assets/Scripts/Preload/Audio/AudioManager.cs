﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static readonly string BackgroundPref = "BackgroundPref";
    public static readonly string SoundEffectsPref = "SoundEffectsPref";
    public static float BKG_Volume = 0.0f, SFX_Volume = 0.0f;
    public static float startButtonClip = .48f;

    public AudioSource BackgroundAudio;
    public AudioSource ButtonAudio;

    private void Awake()
    {
        BKG_Volume = PlayerPrefs.GetFloat(BackgroundPref, 0.0f);
        SFX_Volume = PlayerPrefs.GetFloat(SoundEffectsPref, 0.0f);
        
        DontDestroyOnLoad(this);
    }

    public static void Save(){
        PlayerPrefs.SetFloat(BackgroundPref, BKG_Volume);
        PlayerPrefs.SetFloat(SoundEffectsPref, SFX_Volume);
    }
}
