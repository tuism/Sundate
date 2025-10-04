using System;
using UnityEngine;
using System.Collections.Generic;
using Random=UnityEngine.Random;

public class GridCell : MonoBehaviour
{
    [SerializeField] private Vector2 xy;
    [SerializeField] private GameController _gameController;
    [SerializeField] private List<LandFeature> LandFeatures = new List<LandFeature>();
    [SerializeField] private List<int> open, trees, garbages, houses, waters;
    
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

    public bool AddStructure(Card.StructureType input)
    {
        if (open.Count <= 0)
        {
            return false;
        }
        else
        {
            int randomPick = Random.Range(0, open.Count);
            switch (input)
            {
                case Card.StructureType.Garbage:
                    garbages.Add(open[randomPick]);
                    LandFeatures[randomPick].SetStructure(Card.StructureType.Garbage);
                    break;
                case Card.StructureType.Tree:
                    trees.Add(open[randomPick]);
                    LandFeatures[randomPick].SetStructure(Card.StructureType.Tree);
                    break;
                case Card.StructureType.Water:
                    waters.Add(open[randomPick]);
                    LandFeatures[randomPick].SetStructure(Card.StructureType.Water);
                    break;
                case Card.StructureType.Housing:
                    houses.Add(open[randomPick]);
                    LandFeatures[randomPick].SetStructure(Card.StructureType.Housing);
                    break;

            }
            open.RemoveAt(randomPick);
            return true;
        }
    }
}
