using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroes : MonoBehaviour
{
    public Vector2Int Size = Vector2Int.one;

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
                Gizmos.DrawCube(transform.position + new Vector3(x, 0f, y), new Vector3(0.4f, 0.1f, 0.4f));
            }
        }
    }
}
