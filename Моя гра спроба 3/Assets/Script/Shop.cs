using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public string product;

    public void productUpgrade()
    {
        int count = PlayerPrefs.GetInt(product);
        PlayerPrefs.SetInt(product, count + 1);

        Debug.Log(count + 1);
    }
}
