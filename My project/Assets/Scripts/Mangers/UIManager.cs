using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    #region Inspector Variables

    [SerializeField] private GameObject recipeCanvas;
    //[SerializeField] private GameObject menuCanvas;

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

    /*public void ShowMenuPanel(bool state)
    {
        if (menuCanvas != null) { menuCanvas.SetActive(state); }
    }*/

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
