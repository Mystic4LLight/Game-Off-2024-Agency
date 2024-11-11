using UnityEngine;

public class CameraController2D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float keyboardMoveSpeed = 5f;
    public float mouseEdgeScrollSpeed = 10f;
    public float dragSpeed = 0.5f;

    [Header("Screen Edge Settings")]
    public float edgeBoundary = 10f; // Distance in pixels from edge to start moving

    [Header("Boundary Settings")]
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -10f;
    public float maxY = 10f;

    [Header("Zoom Settings")]
    public float zoomSpeed = 2f;
    public float minZoom = 2f; // Minimum zoom level
    public float maxZoom = 10f; // Maximum zoom level


    private Vector3 dragOrigin;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        KeyboardMove();
        EdgeMove();
        DragMove();
        ZoomControl();

        // Clamp the camera position within boundaries
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }


    void KeyboardMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        
        Vector3 move = new Vector3(moveX, moveY, 0f) * keyboardMoveSpeed * Time.deltaTime;
        transform.position += move;
    }

    void EdgeMove()
    {
        Vector3 pos = transform.position;

        // Check if mouse is near the screen edges, then move the camera
        if (Input.mousePosition.x >= Screen.width - edgeBoundary)
        {
            pos.x += mouseEdgeScrollSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x <= edgeBoundary)
        {
            pos.x -= mouseEdgeScrollSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y >= Screen.height - edgeBoundary)
        {
            pos.y += mouseEdgeScrollSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= edgeBoundary)
        {
            pos.y -= mouseEdgeScrollSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }

    void DragMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position += difference * dragSpeed;
        }
    }
    void ZoomControl()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            Camera.main.orthographicSize -= scroll * zoomSpeed;
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);
        }
    }
}
