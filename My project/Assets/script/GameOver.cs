using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public string Winner;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bola"))
        {
            collision.gameObject.SetActive(false);

            gameOverText.gameObject.SetActive(true);
            gameOverText.text = $"Parabens {Winner} wins!!";

            if (Winner == "enemy")
            {
                gameOverText.color = Color.red;
            }
            else if (Winner== "player")
            {
                gameOverText.color = Color.green;
            }

            Time.timeScale = 0f;
        }
    }
}