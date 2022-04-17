using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public GameObject castle;
    public Image victoryImage;

    private void Update()
    {
        if (castle == null)
        {
            victoryImage.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
