using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase02_InputFieldSwitcher : MonoBehaviour {
    public ToggleUIElement InputField01;

    public void SwitchFields(){
        if (InputField01.isVisible)
            InputField01.Hide();
        else
            InputField01.Show();
    }

    public void setFieldActive(ToggleUIElement inputField){
        InputField01.Hide();
        inputField.Show();
    }
}