using UnityEngine;
using UnityEditor;

public class ArrangeRoomsEditorTool : EditorWindow
{
    private GameObject roomGridContainer;
    private int rows = 3;
    private int columns = 3;
    private float spacing = 10f;
    private Vector2 roomSize = new Vector2(100f, 100f);

    [MenuItem("Tools/Arrange Rooms In Grid")]
    public static void ShowWindow()
    {
        GetWindow<ArrangeRoomsEditorTool>("Arrange Rooms");
    }

    void OnGUI()
    {
        GUILayout.Label("Arrange Rooms in a 3x3 Grid", EditorStyles.boldLabel);

        roomGridContainer = (GameObject)EditorGUILayout.ObjectField("Room Grid Container", roomGridContainer, typeof(GameObject), true);
        rows = EditorGUILayout.IntField("Rows", rows);
        columns = EditorGUILayout.IntField("Columns", columns);
        spacing = EditorGUILayout.FloatField("Spacing", spacing);
        roomSize = EditorGUILayout.Vector2Field("Room Size", roomSize);

        if (GUILayout.Button("Arrange Rooms"))
        {
            if (roomGridContainer != null)
            {
                ArrangeRooms();
            }
            else
            {
                Debug.LogWarning("Please assign a Room Grid Container.");
            }
        }
    }

    void ArrangeRooms()
    {
        Transform containerTransform = roomGridContainer.transform;
        int childCount = containerTransform.childCount;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                int index = row * columns + col;
                if (index >= childCount) return;

                Transform child = containerTransform.GetChild(index);

                // Calculate position based on row, column, room size, and spacing
                float xPosition = col * (roomSize.x + spacing) - (columns - 1) * (roomSize.x + spacing) / 2;
                float yPosition = -(row * (roomSize.y + spacing));

                // Set position
                child.localPosition = new Vector3(xPosition, yPosition, 0);
            }
        }

        Debug.Log("Rooms arranged successfully!");
    }
}
