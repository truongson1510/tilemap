using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Inspector Variables

    [SerializeField] private GameObject recipeCanvas;

    #endregion

    #region Member Variables
    #endregion

    #region Properties
    #endregion

    #region Unity Methods

    private void Awake()
    {
        // Default state of a recipe canvas
        ShowRecipe(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        { ShowRecipe(true); }

        if (Input.GetKeyUp(KeyCode.R))
        {  ShowRecipe(false); }
    }

    #endregion

    #region Public Methods
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="state"></param>
    private void ShowRecipe(bool state)
    {
        if (recipeCanvas != null) { recipeCanvas.SetActive(state); }
    }

    #endregion
}
