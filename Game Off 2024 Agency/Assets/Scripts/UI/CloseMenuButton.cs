using UnityEngine;

public class CloseMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void closeMenu(){
        menu.SetActive(false);
    }
}
