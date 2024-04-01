using UnityEngine;

public class Brick : IObject
{
    protected override void SetPlayerPosition(Collider other)
    {
        int countBricks = other.GetComponent<Player>().GetBricksSize();
        transform.position = other.transform.position + base.brickSizeY * countBricks;
        other.GetComponent<Player>().IncreasePosition(base.brickSizeY);
        GetComponent<BoxCollider>().enabled = false;
    }

    protected override void OnTrigger(Collider other)
    {
        if (other.CompareTag(StringCache.Tag.PLAYER))
        {
            SetPlayerPosition(other);
            transform.SetParent(other.transform);
            other.GetComponent<Player>().AddBrick(transform.gameObject);
        }
    }
}
