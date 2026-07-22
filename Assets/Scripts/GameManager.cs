using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private StoneManager stoneManager = null;

    public static GameManager instance = null;
    public bool isWhiteTurn = false;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip stoneSound;
    [SerializeField] TextMeshProUGUI Text;
    private Coroutine soundCoroutine;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    public void ChangeText(string text)
    {
        Text.text = text;
    }

    public void ChangeTurn()
    {
        isWhiteTurn = !isWhiteTurn;
    }
    public void AddStone(Vector2Int index)
    {
        stoneManager.AddStone(index, isWhiteTurn);
        ChangeTurn();
    }
    public bool CheckFoul(Vector2Int index)
    {
        return stoneManager.CheckFoulMethode(index);
    }
    public void StoneSoundPlay(float startTime, float endTime)
    {
        soundCoroutine = StartCoroutine(CoStoneSoundPlay(startTime, endTime));
    }
    private IEnumerator CoStoneSoundPlay(float startTime, float endTime)
    {
        audioSource.Stop();

        audioSource.clip = stoneSound;
        audioSource.time = startTime;
        audioSource.Play();

        yield return new WaitForSeconds(endTime - startTime);
        audioSource.Stop();
    }
}
