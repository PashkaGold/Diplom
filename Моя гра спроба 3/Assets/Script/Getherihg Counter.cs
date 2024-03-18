using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetherihgCounter : MonoBehaviour
{
    private float wood = 0;
    private float stone = 0;

    public TMP_Text woodText;
    public TMP_Text stoneText;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Tree Gathering")
        {
            wood++;
            woodText.text=wood.ToString();
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.tag == "Stone Gathering")
        {
            stone++;
            stoneText.text = stone.ToString();
            Destroy(coll.gameObject);
        }
    }
}
