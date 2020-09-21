using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ParticleSystem))]
public class PlayerController : MonoBehaviour
{
    #region Public var
    public float smooth;
    public float jumpForce;
    public float gravityAcceleration;
    public float maxGravity;
    public SpriteRenderer m_Sprite;
    public ParticleSystem m_particles;
    #endregion
    #region Private Var
    private Vector3 m_TargetPosition;
    private float m_DownwardVelocity;
    private bool m_pause = false;
    #endregion

    #region Unity Function

    #endregion
    #region Public Function
    public void OnInit()
    {
        m_TargetPosition = transform.position;
        m_Sprite = GetComponent<SpriteRenderer>();
        m_particles = GetComponent<ParticleSystem>();
    }
    public void OnUpdate()
    {
        if (m_pause)
        {
            Pause();
        } 
        Jump();
        Fall();
        Move();
    }
    public void Reset()
    {
        m_TargetPosition = Vector3.up * -4;
        transform.position = m_TargetPosition;
        m_pause = false;
        m_Sprite.enabled = true;
    }
    public void Pause()
    {
        m_Sprite.enabled = false;
        m_particles.Play();
        m_pause = true;
    }
    #endregion

    #region Private Function
    private void Jump()
    {
        if (Input.GetMouseButtonUp(0))
        {
            m_TargetPosition.y = transform.position.y + jumpForce;
            m_DownwardVelocity = 0;
        }
    }
    private void Fall() {
        m_DownwardVelocity += gravityAcceleration;
        m_DownwardVelocity = Mathf.Clamp(m_DownwardVelocity, 0, maxGravity);
        m_TargetPosition.y -= m_DownwardVelocity * Time.deltaTime;
        if(m_TargetPosition.y < -4)
        {
            m_TargetPosition.y = -4;
        }
    }
    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, m_TargetPosition, smooth * Time.deltaTime);
    }
#endregion
}
