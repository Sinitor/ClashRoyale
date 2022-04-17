using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public Slider manaSlider;
    public float maxMana;
    public static float mana;
    private float delta = 0.008f;
    public Text manaText;

    private void Start()
    {
        maxMana = 10;
        manaSlider.maxValue = maxMana;
        mana = maxMana;
    }

    private void Update()
    {
        if (mana >= maxMana)
        {
            mana = maxMana;
        }
        mana += delta;
        manaText.text = "" + (int)mana;
    }
    IEnumerator ManaTimer()
    {
        while (true)
        {
            mana += delta;
            yield return new WaitForSeconds(1);
        }
    }

    private void OnGUI()
    {
        float t = Time.deltaTime / 0.1f;
        manaSlider.value = Mathf.Lerp(manaSlider.value, mana, t);
    }
}
