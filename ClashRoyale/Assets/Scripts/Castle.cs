using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public GameObject towerLeft;
    public GameObject towerRight;
    private void Update()
    {
        if (towerLeft == null || towerRight == null)
        {
            gameObject.tag = "Tower";
        } 
    }
}
