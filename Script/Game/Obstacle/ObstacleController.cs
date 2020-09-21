using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    #region Public Var
    public Transform gameMap;
    public GameObject[] obstacles;
    public GameObject[] pickups;
    public float interval = 5.0f;
    #endregion
    #region
    private List<GameObject> m_Obstacles;
    private List<GameObject> m_Pickup;
    #endregion

    #region Unity Function
    private void Awake()
    {
        m_Obstacles = new List<GameObject>();
        m_Pickup = new List<GameObject>();
    }
    #endregion
    #region Public Function
    public void AddOnstacles(int _progress)
    {
        GameObject _prefab = GetRandomObstacles(obstacles);
        if (!_prefab)
        {
            return;
        }
        GameObject _new = Instantiate(_prefab);
        _new.transform.parent = gameMap;
        float _y = interval * (_progress + 1);
        _new.transform.position = Vector3.up * _y;
        m_Obstacles.Insert(0,_new);
        if (m_Obstacles.Count > 4)
        {
            Destroy(m_Obstacles[m_Obstacles.Count - 1]);
            m_Obstacles.RemoveAt(m_Obstacles.Count - 1);
        }
    }
    public void AddPickup(int _progress)
    {
        GameObject _prefab = GetRandomObstacles(pickups);
        if (!_prefab)
        {
            return;
        }
        GameObject _new = Instantiate(_prefab);
        _new.transform.parent = gameMap;
        float _y = interval * (_progress + 1) + interval * 1.5f;
        _new.transform.position = Vector3.up * _y;
        m_Pickup.Insert(0, _new);
        if (m_Pickup.Count > 1)
        {
            Destroy(m_Pickup[m_Pickup.Count - 1]);
            m_Pickup.RemoveAt(m_Pickup.Count - 1);
        }
    }
    public void Reset()
    {
        for(int i = m_Obstacles.Count - 1; i >= 0; i--)
        {
            Destroy(m_Obstacles[i]);
            m_Obstacles.RemoveAt(i);
        }

        for (int i = m_Pickup.Count - 1; i >= 0; i--)
        {
            if(m_Pickup[i]!= null)
            {
                Destroy(m_Pickup[i]);
            }
            m_Pickup.RemoveAt(i);
        }
    }
    #endregion
    #region Private Function
    private GameObject GetRandomObstacles(GameObject[] _arr)
    {
        if (_arr.Length == 0)
        {
            Debug.LogError("There is no Onstacle in Array!!");
            return null;
        }
        int _random = Random.Range(0, _arr.Length);
        return _arr[_random];
    }
    #endregion
}
