using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivato : MonoBehaviour
{
    [SerializeField]
    GameObject targetObject;

    bool isActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isActive = !isActive;
            targetObject.SetActive(isActive);
        }
    }
}
