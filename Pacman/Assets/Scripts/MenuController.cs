using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void MainMenu() => SceneManager.LoadScene(0);

    public void Play() => SceneManager.LoadScene(1);
}