using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacles : MonoBehaviour
{
    #region Public Var
    public float RotateX;
    public float RotateY;
    public float RotateZ;
    #endregion
    #region Unity Function
    private void Update()
    {
        transform.Rotate(new Vector3(Time.deltaTime * RotateX, Time.deltaTime * RotateY, Time.deltaTime * RotateZ));
    }
    #endregion
}
