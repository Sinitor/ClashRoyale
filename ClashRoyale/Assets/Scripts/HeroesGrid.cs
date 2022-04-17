using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesGrid : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(10, 10);
    public float manaCost;
    private Heroes[,] grid;
    private Heroes flyingHeroes;
    private Camera mainCamera; 
    [SerializeField] private GameObject pref;

    private void Awake()
    {
        grid = new Heroes[GridSize.x, GridSize.y];
        mainCamera = Camera.main;
    }
    public void StartPlacing(Heroes heroesPrefab)
    {
        if (flyingHeroes != null)
        {
            Destroy(flyingHeroes);
        }
        flyingHeroes = Instantiate(heroesPrefab);
    }

    private void Update()
    {
        if (flyingHeroes != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray,out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);
                flyingHeroes.transform.position = worldPosition;

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);
                
                bool isGrid = true;

                if (x > 1f || x < -1f)
                {
                    isGrid = false;
                }
                if (y > -4.4f || y < -6.9f)
                {
                    isGrid = false;
                }
                if (manaCost <= Mana.mana)
                {
                    if (Input.GetMouseButtonDown(0) && isGrid)
                    {
                        Mana.mana -= manaCost;
                        flyingHeroes = null;
                        Destroy(pref);
                    }
                }
            }
        }
    }
}
