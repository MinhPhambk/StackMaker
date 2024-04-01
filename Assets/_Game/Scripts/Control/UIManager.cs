using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] GameObject victoryPopup;
    [SerializeField] GameObject homePopup;
    [SerializeField] GameObject losePopup;
    [SerializeField] Transform mapTransform;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject brickPrefab;
    [SerializeField] GameObject wallPrefab;
    [SerializeField] GameObject bridgePrefab;
    [SerializeField] GameObject pivotePrefab;
    [SerializeField] GameObject winposPrefab;

    private int level = 0;

    private void ClearMap()
    {
        foreach (Transform child in mapTransform)
        {
            Destroy(child.gameObject);
        }
    }

    private void InitNewLevel()
    {
        List<Item> objs = Level.GetLevel(level);

        for (int i = 0; i < objs.Count; i++)
        {
            switch (objs[i].Type)
            {
                case ItemType.Brick:
                    Instantiate(brickPrefab, objs[i].Position, Quaternion.Euler(objs[i].Rotation)).transform.SetParent(mapTransform);
                    break;

                case ItemType.Wall:
                    Instantiate(wallPrefab, objs[i].Position, Quaternion.Euler(objs[i].Rotation)).transform.SetParent(mapTransform);
                    break;

                case ItemType.Pivote:
                    Instantiate(pivotePrefab, objs[i].Position, Quaternion.Euler(objs[i].Rotation)).transform.SetParent(mapTransform);
                    break;

                case ItemType.Brigde:
                    Instantiate(bridgePrefab, objs[i].Position, Quaternion.Euler(objs[i].Rotation)).transform.SetParent(mapTransform);
                    break;

                case ItemType.Winpos:
                    Instantiate(winposPrefab, objs[i].Position, Quaternion.Euler(objs[i].Rotation)).transform.SetParent(mapTransform);
                    break;

                case ItemType.Player:
                    playerObject.transform.position = new Vector3(playerObject.transform.position.x, 2.58f, playerObject.transform.position.z);
                    playerObject.transform.parent.position = new Vector3(objs[i].Position.x, 2.8f, objs[i].Position.z);
                    playerObject.transform.parent.rotation = Quaternion.Euler(objs[i].Rotation);
                    break;
            }
        }

        playerObject.transform.parent.GetComponent<Player>().OnInit();
    }

    public bool SetLevel()
    {
        bool checkExist = Level.CheckPathExist(level + 1);
        level++;

        if (checkExist)
        {
            levelText.text = StringCache.Level.TEXT + level.ToString();
        }
        else
        {
            level--;
        }

        return checkExist;
    }

    public void ShowVictory()
    {
        victoryPopup.SetActive(true);
    }

    public void HideVictory()
    {
        victoryPopup.SetActive(false);
    }

    public void ShowLoseGame()
    {
        losePopup.SetActive(true);
    }

    public void HideLoseGame()
    {
        losePopup.SetActive(false);
    }

    public void PlayNextLevel()
    {
        if (!SetLevel())
        {
            return;
        }

        ClearMap();

        InitNewLevel();

        HideVictory();
    }

    public void PlayGame()
    {
        if (!SetLevel())
        {
            return;
        }

        Destroy(homePopup);

        InitNewLevel();
    }

    public void PlayAgain()
    {
        level--; 

        if (!SetLevel())
        {
            return;
        }

        ClearMap();

        InitNewLevel();

        HideLoseGame();
    }
}
