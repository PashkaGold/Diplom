using UnityEngine;
using GatheringCounter;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;

public class AtakPlayer : MonoBehaviour
{
    [SerializeField]
    Transform center;

    [SerializeField]
    float radius = 2f, angularSpeed = 2f;
    public TMP_Text GoldText;
    public TMP_Text SpeedGunText;
    public int Lvl;
    float positionX, positionY, angle = 0f;

    void Start()
    {
        LoadPlayerPrefs(); // ����������� ������������ � PlayerPrefs ��� ������� �������
    }

    public void ChangeSpeedGun()
    {
        if (Lvl <= 6 && Int32.Parse(GoldText.text) >= 10)
        {
            angularSpeed += 100f;
            SavePlayerPrefs(); // �������� ���� � PlayerPrefs
            Debug.Log("���������� ���������. ���� �������� ����: " + angularSpeed);
            Lvl++;
        }
        Text();
    }
    public void Text()
    {
        SpeedGunText.text = $"Lvl Speed Gun: {Lvl}";
    }
    void Update()
    {
        positionX = center.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        positionY = center.position.y + Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
        transform.position = new Vector2(positionX, positionY);

        angle += Time.deltaTime * angularSpeed;

        if (angle >= 360f)
        {
            angle -= 360f;
        }
    }

    private void LoadPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("AngularSpeed"))
        {
            angularSpeed = PlayerPrefs.GetFloat("AngularSpeed");
            Debug.Log("�������� ���� ����������� � PlayerPrefs: " + angularSpeed);
        }
        else
        {
            Debug.Log("���� 'AngularSpeed' �� �������� � PlayerPrefs");
        }
    }

    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetFloat("AngularSpeed", angularSpeed);
        PlayerPrefs.Save();
        Debug.Log("�������� ���� ��������� � PlayerPrefs: " + angularSpeed);
    }
}
