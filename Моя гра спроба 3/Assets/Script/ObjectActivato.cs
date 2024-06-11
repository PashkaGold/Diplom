using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [SerializeField]
    GameObject[] targetObjects; // Масив об'єктів для активації

    bool isActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isActive = !isActive;
            StartCoroutine(ActivateObjectsWithDelay());
        }
    }

    IEnumerator ActivateObjectsWithDelay()
    {
        foreach (GameObject targetObject in targetObjects)
        {
            targetObject.SetActive(isActive);
            yield return new WaitForSeconds(0.5f); // Затримка в 1 секунду перед активацією наступного об'єкта
        }
    }
}