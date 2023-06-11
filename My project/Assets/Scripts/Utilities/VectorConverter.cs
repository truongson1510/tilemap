using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorConverter
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
    /// <param name="v3"></param>
    /// <returns></returns>
    public static Vector2 ToVector2(Vector3 v3)
    {
        return new Vector2(v3.x, v3.y);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="v2"></param>
    /// <returns></returns>
    public static Vector3 ToVector3(Vector2 v2)
    {
        return new Vector3(v2.x, v2.y, 0);
    }

    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}
