using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [SerializeField]
    GameObject[] targetObjects; // ����� ��'���� ��� ���������
    [SerializeField]
    public TMP_Text GoldText;
    [SerializeField]
    GameObject[] predefinedObjects; // ����� � ��� ���������� ��'������

    bool isActive = false;
    int addedObjectsCount = 0; // ˳������� ������� ��'����
    const int maxAddedObjects = 5; // ����������� ������� ������� ��'����

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
        ActivateObjects();
    }

    void ActivateObjects()
    {
        foreach (GameObject targetObject in targetObjects)
        {
            targetObject.SetActive(isActive);
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

            // �������� �������� ������� ��'����
            addedObjectsCount++;

            // �������� ��������� ��'��� � predefinedObjects
            GameObject newObject = predefinedObjects[addedObjectsCount - 1];

            // ��������� ����� ����� � ���������� ����� ��� ������ ��'����
            GameObject[] newTargetObjects = new GameObject[targetObjects.Length + 1];

            // ������� ������� ��'���� � ����� �����
            for (int i = 0; i < targetObjects.Length; i++)
            {
                newTargetObjects[i] = targetObjects[i];
            }

            // ������ ����� ��'��� �� ������
            newTargetObjects[targetObjects.Length] = newObject;

            // �������� ������ ����� �����
            targetObjects = newTargetObjects;

            // ������ ����� ��'��� �� �����
            newObject.SetActive(isActive);
        }

    }
}

