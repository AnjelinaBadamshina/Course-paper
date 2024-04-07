using UnityEngine;
using UnityEngine.SceneManagement;

public class Уровеньпройден : MonoBehaviour
{
   public void Finishlvl()
    {
        PlayerPrefs.SetInt("currentScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1);
    }
}
