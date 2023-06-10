using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public static FoodManager Instance;
    [SerializeField] GameObject[] foodImage;

    [SerializeField] GameObject[] tables;
    private void Awake()
    {
        Instance = this;
    }

    public void TurnOnButtons()
    {
        for (int i = 0; i < foodImage.Length; i++)
        {
            foodImage[i].SetActive(true);
        }
    }

    public void TurnOffButtons()
    {
        for (int i = 0; i < foodImage.Length; i++)
        {
            foodImage[i].SetActive(false);
        }
    }


    public void FoodCheckForEachTable(GameObject gameObject)
    {
        for (int i = 0; i < tables.Length; i++)
        {
            tables[i].GetComponent<TableManager>().CheckFood(gameObject);
        }
    }

    public void TurnOff()
    {
        for (int i = 0; i < tables.Length; i++)
        {
            tables[i].GetComponent<TableManager>().StopAllCoroutines();
            tables[i].SetActive(false);
        }
    }

}


