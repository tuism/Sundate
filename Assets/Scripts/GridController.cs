using Unity.Mathematics;
using UnityEngine;
using System.Collections.Generic;

public class GridController : MonoBehaviour
{
    [Header("settings")]
    [SerializeField]  private Vector2 gridSize;

    [Header("prefabs")]
    [SerializeField] private GameObject gridCellPrefab;

    [Header("variables")]
    [SerializeField] private new List<GridCell> cells = new List<GridCell>();
    
    [SerializeField] private GameController _gameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                GameObject tempCellobj = Instantiate(gridCellPrefab, new Vector3(i, 0, j), quaternion.identity);
                GridCell tempCellAttribs = tempCellobj.GetComponent<GridCell>();
                tempCellAttribs.SetCoord(new Vector2Int(i,j));
                tempCellAttribs.SetGameController(_gameController);
                cells.Add(tempCellAttribs);
            }
        }

        Camera.main.transform.position = new Vector3(gridSize.x / 2 - (0.5f), 10, gridSize.y / 2 - (8.5f));
        Camera.main.transform.Translate(new Vector3(0,-2f,-15f), Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
