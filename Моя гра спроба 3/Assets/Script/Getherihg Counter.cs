using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GatheringCounter : MonoBehaviour
{
    private float wood = 0;
    private float stone = 0;
    private float mob = 0;
    private float gold = 0;

    public TMP_Text woodText;
    public TMP_Text stoneText;
    public TMP_Text mobText;
    public TMP_Text goldText;

    private void Start()
    {
        // Завантаження збережених значень
        wood = PlayerPrefs.GetFloat("Wood", 0);
        stone = PlayerPrefs.GetFloat("Stone", 0);
        mob = PlayerPrefs.GetFloat("Mob", 0);
        gold = PlayerPrefs.GetFloat("Gold", 0);

        // Оновлення текстових полів після завантаження
        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Tree Gathering")
        {
            wood++;
            woodText.text = wood.ToString();
            Destroy(coll.gameObject);

            // Збереження значення дерева
            PlayerPrefs.SetFloat("Wood", wood);
        }
        else if (coll.gameObject.tag == "Stone Gathering")
        {
            stone++;
            stoneText.text = stone.ToString();
            Destroy(coll.gameObject);

            // Збереження значення каменю
            PlayerPrefs.SetFloat("Stone", stone);
        }
        else if (coll.gameObject.tag == "Mob Gathering")
        {
            mob++;
            mobText.text = mob.ToString();
            Destroy(coll.gameObject);

            // Збереження значення каменю
            PlayerPrefs.SetFloat("Mob", mob);
        }
        else if (coll.gameObject.tag == "Gold Gathering")
        {
            gold++;
            goldText.text = gold.ToString();
            Destroy(coll.gameObject);

            // Збереження значення каменю
            PlayerPrefs.SetFloat("Gold", gold);
        }
    }

    private void UpdateUI()
    {
        woodText.text = wood.ToString();
        stoneText.text = stone.ToString();
        mobText.text = mob.ToString();
        goldText.text = gold.ToString();
    }

    private void OnApplicationQuit()
    {
        // Збереження значень при виході з додатку
        PlayerPrefs.SetFloat("Wood", wood);
        PlayerPrefs.SetFloat("Stone", stone);
        PlayerPrefs.SetFloat("Mob", mob);
        PlayerPrefs.SetFloat("Gold", gold);
        PlayerPrefs.Save();
    }
}