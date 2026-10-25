
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public Transform panel;
    public GameObject itemImagePrefab;

    public List<Item> inventory = new List<Item>();

    public void AddItem(Item item)
    {
        foreach (Item existingItem in inventory)
        {
            if (existingItem.itemName == item.itemName)
            {
                existingItem.amount += item.amount;
                UpdateCanvas();
                return;
            }
        }

        inventory.Add(item);
        UpdateCanvas();
    }

    void UpdateCanvas()
    {
        // Remove the old images
        foreach (Transform child in panel)
        {
            Destroy(child.gameObject);
        }

        // Create an image for each item
        foreach (Item item in inventory)
        {
            GameObject image = Instantiate(itemImagePrefab, panel);

            // Set the image to the item's sprite
            image.GetComponent<Image>().sprite = item.icon;
        }
    }
}
