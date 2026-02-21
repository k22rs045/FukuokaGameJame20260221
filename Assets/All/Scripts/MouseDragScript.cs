using UnityEngine;

public class MouseDragScript : MonoBehaviour
{
    private Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDrag()
    {
        Vector3 objectScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);

        Vector3 objectworldPoint = mainCamera.ScreenToWorldPoint(objectScreenPoint);

        transform.position = objectworldPoint;
    }
}
