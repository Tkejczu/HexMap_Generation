using UnityEngine;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager _instance;

    [SerializeField]
    Text tooltipText;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetTooltip(string tooltipContent)
    {
        gameObject.SetActive(true);
        tooltipText.text = tooltipContent;
    }

    public void HideTooltip()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
            tooltipText.text = string.Empty;
        }
    }

    public void GenerateTooltip(HexNode targetNode)
    {
        SetTooltip
            (
            "Coordinates(X: " + targetNode.coordinates.x + " Y: " + targetNode.coordinates.y + ")" +
            "\n" + "Color: " + targetNode.nodeColorLabel +
            "\n" + "Interactable: " + targetNode.isInteractive +
            "\n" + "Walkable: " + targetNode.isWalkable
            );
    }
}
