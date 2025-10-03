using Unity.Mathematics;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [Header("settings")]
    [SerializeField]  private Vector2 gridSize;

    [Header("prepopulated")]
    [SerializeField] private GameObject gridCell;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                Instantiate(gridCell, new Vector3(i, 0, j), quaternion.identity);
            }
        }

        Camera.main.transform.position = new Vector3(gridSize.x / 2 - (0.5f), 10, gridSize.y / 2 - (8.5f));
        Camera.main.transform.Translate(new Vector3(0,-1f,-15f), Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
