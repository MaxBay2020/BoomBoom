using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointsManager : MonoBehaviour
{
    public List<Transform> savePoints;
    public Transform beginPoint;

    private static SavePointsManager _instance;
    public static SavePointsManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        savePoints.Add(beginPoint);
    }

}
