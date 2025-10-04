using System;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField] private Vector2 xy;
    [SerializeField] private GameController _gameController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCoord(Vector2Int inputXy)
    {
        xy = inputXy;
    }

    public void SetGameController(GameController incomingGC)
    {
        _gameController = incomingGC;
    }

    private void OnMouseEnter()
    {
        _gameController.AnnounceCursorEnter(xy);
    }

    private void OnMouseExit()
    {
        _gameController.AnnounceCursorExit();
    }

    private void OnMouseOver()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            // Raycast hit something
        }
        _gameController.AnnounceMousePos(hit.point);
    }
    
    private void OnMouseDown()
    {
        
    }
}
