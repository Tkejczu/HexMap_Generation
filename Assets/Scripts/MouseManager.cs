using UnityEngine;

public class MouseManager : MonoBehaviour
{
    void Update()
    {
        SelectObject();
    }

    void SelectObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mapPoint, Vector2.zero);

            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.transform.parent.gameObject;
                HexNode selectedNode = hitObject.GetComponent<HexNode>();             

                if (selectedNode.isInteractive)
                {
                    TooltipManager._instance.GenerateTooltip(selectedNode);
                }
                else
                    TooltipManager._instance.HideTooltip();        
            }
        }
    }  
}
