using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    #region Public Var
    public Transform Player;
    public float smooth;
    #endregion
    #region Private Var
    private Camera m_Camera;
    private Vector3 m_TargetPosition;
    private Vector3 m_InitialPosition;
    #endregion

    #region Unity Function

    #endregion
    #region Public Function
    public void OnInit()
    {
        m_Camera = GetComponent<Camera>();
        m_TargetPosition = transform.position;
        m_InitialPosition = m_TargetPosition;
    }
    public void OnUpdate()
    {
        followPlayer();
    }
    public void Reset()
    {
        m_TargetPosition = m_InitialPosition;
        transform.position = m_TargetPosition;
    }
    #endregion
    #region Private Function
    private void followPlayer()
    {
        if (!Player)
        {
            Debug.LogError("Camera can't font Player!!");
        }
        if (Player.transform.position.y > transform.position.y)
        {
            m_TargetPosition.y = Player.position.y;
        }
        transform.position = Vector3.Lerp(transform.position, m_TargetPosition, smooth * Time.deltaTime);
    }
#endregion
}
