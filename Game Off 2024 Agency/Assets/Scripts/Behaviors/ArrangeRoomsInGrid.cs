using UnityEngine;

public class ArrangeRoomsInGrid : MonoBehaviour
{
    public GameObject[] rooms;  // Assign the room GameObjects in the inspector
    public int rows = 3;
    public int columns = 3;
    public float spacing = 10f;  // Space between rooms
    public Vector2 roomSize = new Vector2(100f, 100f);  // Assuming all rooms are 100x100

    void Start()
    {
        ArrangeGrid();
    }

    void ArrangeGrid()
    {
        if (rooms.Length == 0) return;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                int index = row * columns + col;
                if (index >= rooms.Length) return;

                // Calculate position based on row, column, room size, and spacing
                float xPosition = col * (roomSize.x + spacing) - (columns - 1) * (roomSize.x + spacing) / 2;
                float yPosition = -(row * (roomSize.y + spacing));

                // Set position
                rooms[index].transform.localPosition = new Vector3(xPosition, yPosition, 0);
            }
        }
    }
}
