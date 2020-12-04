using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fase02_BackupTransform : MonoBehaviour
{
    [HideInInspector]
    public Transform obj;

    private void Start() {
        obj = copyTransform(GetComponent<Transform>());
        Debug.Log(obj.localPosition.x + " " + obj.localPosition.y + " " + obj.localPosition.z);
    }

    public Transform copyTransform(Transform src){
        GameObject empty = new GameObject();
        Transform target = empty.transform;
        target.localPosition = src.localPosition;
        target.localRotation = src.localRotation;
        return target;
    }
}