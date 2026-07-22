using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void OnClickRestartButton()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene("SampleScene");
    }
}
