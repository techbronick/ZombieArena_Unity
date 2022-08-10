using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundScript : MonoBehaviour
{
    private void Start()
    {
        {
            gameObject.SetActive(false);
        }
    }
    public void Setup()
    {
        gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");

    }
}
