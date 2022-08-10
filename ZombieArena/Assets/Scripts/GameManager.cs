using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BackgroundScript GameOverScreen;
    public BackgroundScript GameWonScreen;
    public GameObject Player;

    private bool playerIsDead = false;

    private void Update()
    {
        if (Player.GetComponent<PlayerStats>().currentHealth <= 0)
        {
            playerIsDead = true;
        }

        if (playerIsDead)
        {
            GameOver();
            playerIsDead = false;
        }
    }
    public void GameOver()
    {
        GameOverScreen.Setup();

    }

}
