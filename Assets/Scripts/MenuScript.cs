using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    Text highScoreText;
    int score;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        score = PlayerPrefs.GetInt("HighScore");
    }
    private void FixedUpdate()
    {
        highScoreText.text = "HIGH SCORE: " + score + "";
    }
}
