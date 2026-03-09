using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Level1 : MonoBehaviour
{
    public void ExitGameButton()
    {
        SceneManager.LoadScene("Intro");
    }
}
