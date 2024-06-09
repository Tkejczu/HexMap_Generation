using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Vector3 dragOrigin;

    void LateUpdate()
    {
        PanCamera();
    }

    void PanCamera()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 difference = dragOrigin - Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Camera.main.transform.position += difference;
        }
    }
}
