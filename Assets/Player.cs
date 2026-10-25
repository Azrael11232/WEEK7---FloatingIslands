
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject prefab;

    public Rigidbody2D rb;
    public float speed = 5f;

    void Update()
    {
        movement();
        breaking();
        placing();
    }

    void movement()
    {
        float x = 0;
        float y = 0;

        if (Input.GetKey(KeyCode.A))
            x = -1;

        if (Input.GetKey(KeyCode.D))
            x = 1;

        if (Input.GetKey(KeyCode.S))
            y = -1;

        if (Input.GetKey(KeyCode.W))
            y = 1;

        rb.linearVelocity = new Vector2(x, y).normalized * speed;
    }

    void breaking()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;

        Vector3 worldPosition =
            Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3Int cellPosition =
            tilemap.WorldToCell(worldPosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (tilemap.GetTile(cellPosition) != null)
            {
                DropBlock(cellPosition);
            }
        }
    }

    void placing()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;

        Vector3 worldPosition =
            Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3Int cellPosition =
            tilemap.WorldToCell(worldPosition);

        if (Input.GetMouseButtonDown(1))
        {

        }
    }

    public void DropBlock(Vector3Int cellPosition)
    {
        TileBase tile = tilemap.GetTile(cellPosition);

        if (tile == null)
            return;

        Sprite sprite = tilemap.GetSprite(cellPosition);

        Vector3 worldPosition =
            tilemap.GetCellCenterWorld(cellPosition);

        GameObject droppedBlock = Instantiate(
            prefab,
            worldPosition,
            Quaternion.identity
        );

        Drops drop = droppedBlock.GetComponent<Drops>();

        if (drop != null)
        {
            drop.item = new Item();
            drop.item.icon = sprite;
            drop.item.itemName = tile.name;
            drop.item.amount = 1;
        }

        droppedBlock.GetComponent<SpriteRenderer>().sprite = sprite;
        droppedBlock.transform.localScale = Vector3.one * 0.25f;

        tilemap.SetTile(cellPosition, null);
    }
}
