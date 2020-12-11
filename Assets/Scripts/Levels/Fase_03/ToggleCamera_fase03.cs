using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera_fase03 : MonoBehaviour
{
    private int camera_index = 0;
    public Camera[] cameras = new Camera[2];
    [HideInInspector] public Camera SideCamera;
    [HideInInspector] public Camera ExplorerCamera;
    [HideInInspector] public Camera BackCamera;
    public Fase03_References references;
    public Camera currentCamera;
    public Camera previousCamera;
    private string currentActiveCamera = "Explorer Camera";
    private string previousActiveCamera = "None";

    private void Awake() {
        //Debug.Log("Length of Cameras: " + cameras.Length);
        SideCamera = cameras[0];
        ExplorerCamera = cameras[1];
        currentCamera = ExplorerCamera;
    }

    private void Start() {
        SideCamera.enabled = false;
        ExplorerCamera.enabled = true;
    }
    
    public void switchCameras(){
        for (int i = 0; i < cameras.Length; i++){
            if (i == camera_index){
                cameras[i].enabled = true;
            }
            else{
                cameras[i].enabled = false;
            }
        }

        previousCamera = currentCamera;
        previousActiveCamera = previousCamera.name;
        currentCamera = cameras[camera_index];
        currentActiveCamera = currentCamera.name;
        
        if(currentActiveCamera != "Explorer Camera"){
            Debug.Log("OI");
            GameObject joysticks_container = Utils.GetChildWithName(references.Canvas, "Joysticks Container");
            joysticks_container.GetComponent<ToggleUIElement>().Hide();
        }
        else{
            GameObject joysticks_container = Utils.GetChildWithName(references.Canvas, "Joysticks Container");
            joysticks_container.GetComponent<ToggleUIElement>().Show();
        }

        camera_index++;

        camera_index = (camera_index >= cameras.Length) ? 0 : camera_index;

        Debug.Log("Selected " + currentActiveCamera);
    }

    public void switchToCamera(Camera current, Camera destiny){
        current.enabled = false;
        destiny.enabled = true;

        currentCamera = destiny;
        currentActiveCamera = destiny.name;
    }

    public string getActiveCameraName(){
        return currentActiveCamera;
    }
}
