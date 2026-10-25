using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public int amount;
}

public class Drops : MonoBehaviour
{
    public Item item;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory inventory = collision.GetComponent<Inventory>();

            if (inventory != null)
            {
                if (item.icon != null)
                    item.itemName = item.icon.name;

                inventory.AddItem(item);
                Destroy(gameObject);
            }
        }
    }
}