using UnityEngine;

public class Item
{
    public ItemType Type { get; set; }
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }

    public Item() { }

    public Item(ItemType type, Vector3 pos, Vector3 rota)
    {
        this.Type = type;
        this.Position = pos;
        this.Rotation = rota;
    }
}
