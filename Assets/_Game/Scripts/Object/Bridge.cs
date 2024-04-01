using UnityEngine;

public class Bridge : IObject
{
    [SerializeField] private GameObject yellowPrefab;

    protected override void OnTrigger(Collider other)
    {
        if (other.CompareTag(StringCache.Tag.PLAYER))
        {
            if (other.GetComponent<Player>().GetBricksSize() > 0)
            {
                SetPlayerPosition(other);
                ChangeStyle();
                GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                other.GetComponent<Player>().PausePlayer();
                other.GetComponent<Player>().IncreasePosition(base.brickSizeY);
                UIManager.Instance.ShowLoseGame();
            }
        }
    }

    protected override void SetPlayerPosition(Collider other)
    {
        other.GetComponent<Player>().RemoveBrick();
        other.GetComponent<Player>().IncreasePosition(-base.brickSizeY);
    }

    private void ChangeStyle()
    {
        GameObject obj = Instantiate(yellowPrefab, new Vector3(transform.position.x, 2.67f, transform.position.z), Quaternion.Euler(new Vector3(-90, 0, 0)));
        obj.transform.SetParent(transform);
    }
}
