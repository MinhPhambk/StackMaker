using UnityEngine;

public class VictoryVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem vfx1;
    [SerializeField] private ParticleSystem vfx2;
    [SerializeField] private GameObject chestOpen;
    [SerializeField] private GameObject chestClose;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(StringCache.Tag.PLAYER))
        {
            OnActive();
            other.GetComponent<Player>().ChangeWin();
            other.GetComponent<Player>().PausePlayer();
            Invoke(nameof(ShowVictory), 2f);
        }
    }

    private void OnActive()
    {
        vfx1.Play();
        vfx2.Play();

        chestClose.SetActive(false);
        chestOpen.SetActive(true);
    }

    private void ShowVictory()
    {
        UIManager.Instance.ShowVictory();
    }
}
