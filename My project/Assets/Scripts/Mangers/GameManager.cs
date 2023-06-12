using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneAutoLoader;

public class GameManager : Singleton<GameManager>
{
    #region Inspector Variables
    #endregion

    #region Member Variables
    #endregion

    #region Properties
    #endregion

    #region Unity Methods
    #endregion

    #region Public Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sceneIndex"></param>
    public void LoadScene(SceneIndexes sceneIndex)
    {
        SceneManager.LoadScene((int)sceneIndex);
    }

    public void Loadlevel1()
    {
        LoadScene(SceneIndexes.Level1);
    }

    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}
