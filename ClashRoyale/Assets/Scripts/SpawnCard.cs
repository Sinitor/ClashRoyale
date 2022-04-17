using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCard : MonoBehaviour
{
    public Vector3 vec;
    public Vector3 vec1;
    public Vector3 vec2;
    public GameObject can;
    public List<GameObject> prefabs = null;
    public GameObject[] panel;
    public static bool isRepeat;
    private int limit = 3;
    private void Start()
    {
        spawnBlock();
    }
    private void Update()
    {
        panel = GameObject.FindGameObjectsWithTag("Target");
        int count = prefabs.Count;
        if (panel.Length < limit)
        {
            int i = Random.Range(0, count - 1);
            GameObject go = prefabs[i];
            prefabs.Remove(go);
            Instantiate(go, vec2, Quaternion.identity, can.transform);
        }
        if (count < 1 )
        {
            prefabs = new List<GameObject>(Resources.LoadAll<GameObject>("UI"));
        }
    }
    private void spawnBlock()
    {
        prefabs = new List<GameObject>(Resources.LoadAll<GameObject>("UI"));
        int count = prefabs.Count;
        if (count == 0)
        {
            return;
        }
        int i = Random.Range(0, count - 1);
        GameObject go = prefabs[i];
        prefabs.Remove(go);
        int j = Random.Range(0, count - 1);
        GameObject go1 = prefabs[j];
        prefabs.Remove(go1);
        int l = Random.Range(0, count - 1);
        GameObject go2 = prefabs[l];
        prefabs.Remove(go2);
        prefabs.Add(go);
        prefabs.Add(go1);
        prefabs.Add(go2);
        Instantiate(go, vec, Quaternion.identity, can.transform);
        Instantiate(go1, vec1, Quaternion.identity, can.transform);
        Instantiate(go2, vec2, Quaternion.identity, can.transform);
    }
}
