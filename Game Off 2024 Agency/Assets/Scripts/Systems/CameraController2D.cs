using UnityEngine;

public class CameraController2D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float keyboardMoveSpeed = 5f;
    public float mouseEdgeScrollSpeed = 10f;
    public float dragSpeed = 0.5f;

    [Header("Screen Edge Settings")]
    public float edgeBoundary = 10f; // Distance in pixels from edge to start moving

    [Header("Zoom Settings")]
    public float zoomSpeed = 2f;
    public float minZoom = 2f; // Minimum zoom level
    public float maxZoom = 10f; // Maximum zoom level

    [Header("Layout Reference")]
    public Transform agencyLayout; // Reference to the parent object containing all rooms

    private float minX, maxX, minY, maxY; // Calculated boundaries
    private Vector3 dragOrigin;
    private Camera cam;

    private bool isDragging = false; // Tracks whether the user is currently dragging


    void Start()
    {
        cam = Camera.main;

        if (agencyLayout == null)
        {
            Debug.LogError("AgencyLayout is not assigned!");
            return;
        }

        CalculateBounds(); // Dynamically calculate boundaries
    }

    void Update()
    {
        if (UIManager.IsCameraBlocked())
            return; // Block camera movement when UI windows are active

        KeyboardMove();

        if (!isDragging) // Disable edge movement during drag
        {
            EdgeMove();
        }

        DragMove();
        ZoomControl();

        // Clamp the camera position within dynamic boundaries
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }


    void CalculateBounds()
    {
        // Initialize boundaries
        minX = float.MaxValue;
        maxX = float.MinValue;
        minY = float.MaxValue;
        maxY = float.MinValue;

        // Iterate through all child objects of AgencyLayout
        foreach (Transform child in agencyLayout)
        {
            // Find the "RoomImage" child
            Transform roomImage = child.Find("RoomImage");
            if (roomImage != null)
            {
                Renderer renderer = roomImage.GetComponent<Renderer>();
                if (renderer != null)
                {
                    Bounds bounds = renderer.bounds;

                    // Expand boundaries based on RoomImage's bounds
                    minX = Mathf.Min(minX, bounds.min.x);
                    maxX = Mathf.Max(maxX, bounds.max.x);
                    minY = Mathf.Min(minY, bounds.min.y);
                    maxY = Mathf.Max(maxY, bounds.max.y);
                }
            }
        }

        // Adjust boundaries to account for the camera's visible area
        float camHeight = cam.orthographicSize * 2;
        float camWidth = camHeight * cam.aspect;

        minX += camWidth / 2; // Prevent left edge of the screen from going outside
        maxX -= camWidth / 2; // Prevent right edge of the screen from going outside
        minY += camHeight / 2; // Prevent bottom edge of the screen from going outside
        maxY -= camHeight / 2; // Prevent top edge of the screen from going outside

        // Log calculated boundaries for debugging
        Debug.Log($"Adjusted Bounds: minX={minX}, maxX={maxX}, minY={minY}, maxY={maxY}");
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
        if (Input.GetMouseButtonDown(0)) // Start drag
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true; // Set dragging flag
        }

        if (Input.GetMouseButton(0)) // Continue drag
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position += difference * dragSpeed;
        }

        if (Input.GetMouseButtonUp(0)) // End drag
        {
            isDragging = false; // Clear dragging flag
        }
    }


    void ZoomControl()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);

            // Recalculate boundaries after zooming
            CalculateBounds();
        }
    }
}
