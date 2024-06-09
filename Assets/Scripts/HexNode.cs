using UnityEngine;

public class HexNode : MonoBehaviour
{
    public Vector2Int coordinates;
    public string nodeColorLabel;
    public bool isInteractive;
    public bool isWalkable;

    public void SetNodeColor(Color color)
    {
        GetComponentInChildren<SpriteRenderer>().color = color;
    }
}
