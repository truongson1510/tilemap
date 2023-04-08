using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayerMovement : MonoBehaviour
{
	#region Inspector Variables

	[SerializeField] private float moveSpeed = 5f;

	#endregion

	#region Member Variables

	private Rigidbody2D body2D;
    private Animator    animator;
    private Vector2     movement;

    #endregion

    #region Properties

    #endregion

    #region Unity Methods

    private void Awake()
    {
        body2D      = GetComponent<Rigidbody2D>();
        animator    = GetComponent<Animator>();
    }

    private void Update()
    {
        movement.x  = Input.GetAxisRaw("Horizontal");
        movement.y  = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        body2D.MovePosition(body2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    #endregion

    #region Public Methods

    #endregion

    #region Protected Methods

    #endregion

    #region Private Methods

    #endregion
}
