using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HexMap : MonoBehaviour
{
    [SerializeField]
    HexNode hexPrefab;

    [SerializeField]
    int width = 1000;
    [SerializeField]
    int height = 1000;

    const float BLUE_NODES_PERCENTAGE = 0.6f;    
    const float GREEN_NODES_PERCENTAGE = 0.1f;    
    const float YELLOW_NODES_PERCENTAGE = 0.05f; 
    const float GREY_NODES_PERCENTAGE = 0.25f;

    const float X_OFFSET = 0.892f;
    const float Y_OFFSET = 0.76f;

    HexNode[] hexNodes;
    
    void Start()
    {
        CreateMap();     
    }

    void CreateMap()
    {
        hexNodes = new HexNode[width * height];

        for (int x = 0, i = 0; x < width; x++)
        {                               
            for (int y = 0; y < height; y++)
            {
                CreateNode(x, y, i++);
            }
        }
        PaintNodes();
    }

    void CreateNode(int x, int y, int i)
    {
        SetNodeCoordinates(x, y);

        float xPosition = x * X_OFFSET;
        float yPosition = y * Y_OFFSET;
       
        if (y % 2 == 1)
        {
            xPosition += X_OFFSET / 2;
        }
        
        HexNode hexNode = hexNodes[i] = Instantiate(hexPrefab, new Vector2(xPosition, yPosition), Quaternion.identity);
        hexNode.transform.SetParent(transform, false);         
    }

    void SetNodeCoordinates(int x, int y)
    {
        int coordinateOffset = 1;

        hexPrefab.coordinates = new Vector2Int(x + coordinateOffset, y + coordinateOffset);
    }

    void PaintNodes()
    {
        ShuffleNodeArray();

        int nodeCount = hexNodes.Length;

        int maxBlueNodeCount = (int)(nodeCount * BLUE_NODES_PERCENTAGE);
        int maxGreenNodeCount = (int)(nodeCount * GREEN_NODES_PERCENTAGE);
        int maxYellowNodeCount = (int)(nodeCount * YELLOW_NODES_PERCENTAGE);
        int maxGreyNodeCount = (int)(nodeCount * GREY_NODES_PERCENTAGE);

        int currentBlueNodeCount = 0;
        int currentGreenNodeCount = 0;
        int currentYellowNodeCount = 0;
        int currentGreyNodeCount = 0;

        foreach (var node in hexNodes)
        {
            if (currentBlueNodeCount < maxBlueNodeCount)
            {
                node.SetNodeColor(Color.blue);
                node.nodeColorLabel = "Blue";
                node.isWalkable = true;
                currentBlueNodeCount++;
                continue;
            }
            if (currentGreenNodeCount < maxGreenNodeCount)
            {
                node.SetNodeColor(Color.green);
                node.nodeColorLabel = "Green";
                node.isInteractive = true;
                currentGreenNodeCount++;
                continue;
            }
            if (currentYellowNodeCount < maxYellowNodeCount)
            {
                node.SetNodeColor(Color.yellow);
                node.nodeColorLabel = "Yellow";
                node.isInteractive = true;
                currentYellowNodeCount++;
                continue;
            }
            if (currentGreyNodeCount < maxGreyNodeCount)
            {
                node.SetNodeColor(Color.grey);
                node.nodeColorLabel = ("Grey");
                currentGreyNodeCount++;
                continue;
            }
        }
    }

    void ShuffleNodeArray()
    {
        for (int i = 0; i < hexNodes.Length; i++)
        {
            int randomIndex = Random.Range(0, i);

            HexNode temp = hexNodes[i];

            hexNodes[i] = hexNodes[randomIndex];
            hexNodes[randomIndex] = temp;
        }
    }
}
