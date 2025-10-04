using UnityEngine;

public class LandFeature : MonoBehaviour
{
    [SerializeField] private GameObject house1, house2, garbage1, garbage2, water, grass, tree;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AllStructuresOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStructure(Card.StructureType input)
    {
        AllStructuresOff();
        switch (input)
        {
            case (Card.StructureType.Tree):
                tree.SetActive(true);
                break;
            case (Card.StructureType.Grass):
                grass.SetActive(true);
                break;
            case (Card.StructureType.Garbage):
                if (Random.Range(0,2) == 0)
                {garbage1.SetActive(true);} else {garbage2.SetActive(true);}
                break;
            case (Card.StructureType.Housing):
                house1.SetActive(true);
                break;
            case (Card.StructureType.Water):
                water.SetActive(true);
                break;
            case (Card.StructureType.Building):
                break;
        }
    }

    public void AllStructuresOff()
    {
        house1.SetActive(false);
        house2.SetActive(false);
        garbage1.SetActive(false);
        garbage2.SetActive(false);
        water.SetActive(false);
        grass.SetActive(false);
        tree.SetActive(false);
    }
}
