using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollower : MonoBehaviour
{
	#region Inspector Variables

	[SerializeField] private Transform	target;
	[SerializeField] private Vector3	offset;
	[SerializeField] private float		damping;

	#endregion

	#region Member Variables

	private Vector3 velocity = Vector3.zero;

    #endregion

    #region Properties

    #endregion

    #region Unity Methods

    private void FixedUpdate()
    {
        Vector3 movePosition    = target.position + offset;
        transform.position      = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }

    #endregion

    #region Public Methods

    #endregion

    #region Protected Methods

    #endregion

    #region Private Methods

    #endregion
}
