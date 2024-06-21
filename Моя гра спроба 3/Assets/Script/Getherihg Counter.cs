using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace GatheringCounter
{

    public class GatheringCounter : MonoBehaviour
    {

        private float wood = 0;
        private float stone = 0;
        private float mob = 0;
        public float gold = 0;

        public TMP_Text woodText;
        public TMP_Text stoneText;
        public TMP_Text mobText;
        public TMP_Text goldText;
        public TMP_Text woodText1;
        public TMP_Text stoneText1;
        public TMP_Text mobText1;
        public TMP_Text goldText1;

        private void Start()
        {
            // ������������ ���������� �������
            wood = PlayerPrefs.GetFloat("Wood", 0);
            stone = PlayerPrefs.GetFloat("Stone", 0);
            mob = PlayerPrefs.GetFloat("Mob", 0);
            gold = PlayerPrefs.GetFloat("Gold", 0);

            // ��������� ��������� ���� ���� ������������
            UpdateUI();
        }

        public void ObminCoins1()
        {
            while (wood >= 1)
            {
                wood -= 1;
                gold += 1;
            }
            UpdateUI();
        }
        public void ObminCoins2()
        {
            while (stone >= 1)
            {
                stone -= 1;
                gold += 1;
            }
            UpdateUI();
        }
        public void ObminCoins3()
        {
            while (mob >= 1)
            {
                mob -= 1;
                gold += 1;
            }
            UpdateUI();
        }

        public void MinusGold(int count)
        {
            if (gold >= count)
            {
                gold -= count;
                UpdateUI();
            }
        }

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "Tree Gathering")
            {
                wood++;
                woodText.text = wood.ToString();
                Destroy(coll.gameObject);

                // ���������� �������� ������
                PlayerPrefs.SetFloat("Wood", wood);
            }
            else if (coll.gameObject.tag == "Stone Gathering")
            {
                stone++;
                stoneText.text = stone.ToString();
                Destroy(coll.gameObject);

                // ���������� �������� ������
                PlayerPrefs.SetFloat("Stone", stone);
            }
            else if (coll.gameObject.tag == "Mob Gathering")
            {
                mob++;
                mobText.text = mob.ToString();
                Destroy(coll.gameObject);

                // ���������� �������� ������
                PlayerPrefs.SetFloat("Mob", mob);
            }
            else if (coll.gameObject.tag == "Gold Gathering")
            {
                gold++;
                goldText.text = gold.ToString();
                Destroy(coll.gameObject);

                // ���������� �������� ������
                PlayerPrefs.SetFloat("Gold", gold);
            }
        }

        private void UpdateUI()
        {
            woodText.text = wood.ToString();
            stoneText.text = stone.ToString();
            mobText.text = mob.ToString();
            goldText.text = gold.ToString();
            woodText1.text = wood.ToString();
            stoneText1.text = stone.ToString();
            mobText1.text = mob.ToString();
            goldText1.text = gold.ToString();
        }

        private void OnApplicationQuit()
        {
            // ���������� ������� ��� ����� � �������
            PlayerPrefs.SetFloat("Wood", wood);
            PlayerPrefs.SetFloat("Stone", stone);
            PlayerPrefs.SetFloat("Mob", mob);
            PlayerPrefs.SetFloat("Gold", gold);
            PlayerPrefs.Save();
        }
    }
}
