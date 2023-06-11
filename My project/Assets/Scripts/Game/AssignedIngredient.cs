using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignedIngredient : MonoBehaviour
{
    public GameObject Ingredient;

    public void OnClickIngredient()
    {
        FoodManager.Instance.FoodCheckForEachTable(Ingredient);
    }
}
