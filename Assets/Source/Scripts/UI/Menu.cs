using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        print("Exit");
        Application.Quit();
    }
}
