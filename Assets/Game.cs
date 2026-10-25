
using UnityEngine;

public class Game : MonoBehaviour
{
    public bool open;
    public GameObject Inventory;

    void Update()
    {
        Open();
    }

    void Open()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (open == true)
            {
                Inventory.SetActive(false);
                open = false;
            }
            else
            {
                Inventory.SetActive(true);
                open = true;
            }
        }
    }
}
