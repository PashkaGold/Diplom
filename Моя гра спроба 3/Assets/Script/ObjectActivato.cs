using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [SerializeField]
    GameObject[] targetObjects;
    [SerializeField]
    public TMP_Text GoldText;
    [SerializeField]
    GameObject[] predefinedObjects;
    [SerializeField]
    float activationInterval = 1f;  

    bool isActive = false;
    int addedObjectsCount = 0;
    const int maxAddedObjects = 5;

    void Start()
    {
        LoadPlayerPrefs();
        StartCoroutine(ActivateObjectsWithDelay());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleActivation();
        }
    }

    void ToggleActivation()
    {
        isActive = !isActive;
        StartCoroutine(ActivateObjectsWithDelay());
        SavePlayerPrefs();
    }

    IEnumerator ActivateObjectsWithDelay()
    {
        foreach (GameObject targetObject in targetObjects)
        {
            targetObject.SetActive(isActive);
            yield return new WaitForSeconds(activationInterval);
        }
    }

    public void AddNewTargetObject()
    {
        if (Int32.Parse(GoldText.text) >= 10)
        {
            if (addedObjectsCount >= maxAddedObjects)
            {
                Debug.LogWarning("Maximum number of objects added.");
                return;
            }

            addedObjectsCount++;

            GameObject newObject = predefinedObjects[addedObjectsCount - 1];

            GameObject[] newTargetObjects = new GameObject[targetObjects.Length + 1];

            for (int i = 0; i < targetObjects.Length; i++)
            {
                newTargetObjects[i] = targetObjects[i];
            }

            newTargetObjects[targetObjects.Length] = newObject;

            targetObjects = newTargetObjects;

            newObject.SetActive(isActive);

            SavePlayerPrefs();
        }
    }

    private void LoadPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("AddedObjectsCount"))
        {
            addedObjectsCount = PlayerPrefs.GetInt("AddedObjectsCount");

            // Load added objects
            for (int i = 0; i < addedObjectsCount; i++)
            {
                GameObject newObject = predefinedObjects[i];

                GameObject[] newTargetObjects = new GameObject[targetObjects.Length + 1];

                for (int j = 0; j < targetObjects.Length; j++)
                {
                    newTargetObjects[j] = targetObjects[j];
                }

                newTargetObjects[targetObjects.Length] = newObject;

                targetObjects = newTargetObjects;

                newObject.SetActive(isActive);
            }
        }

        if (PlayerPrefs.HasKey("IsActive"))
        {
            isActive = PlayerPrefs.GetInt("IsActive") == 1;
        }

        if (PlayerPrefs.HasKey("ActivationInterval"))
        {
            activationInterval = PlayerPrefs.GetFloat("ActivationInterval");
        }
    }

    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("AddedObjectsCount", addedObjectsCount);
        PlayerPrefs.SetInt("IsActive", isActive ? 1 : 0);
        PlayerPrefs.SetFloat("ActivationInterval", activationInterval);
        PlayerPrefs.Save();
    }
}
