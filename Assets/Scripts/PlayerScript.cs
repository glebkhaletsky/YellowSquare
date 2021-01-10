using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    GameObject goal1;
    [SerializeField]
    GameObject goal2;
    [SerializeField]
    bool check;
    [SerializeField]
    Text scoreText;
    int score;
    [SerializeField]
    GameObject Dead;
    [SerializeField]
    Image GameOver;
    public bool PSDead;

    int highScore;
    [SerializeField]
    Text scoreLevelText;
    [SerializeField]
    Text highScoreText;
    [SerializeField]
    GameObject resultPanel;

    private void Start()
    {
        check = true;
        goal1.SetActive(true);
        goal1.transform.position = new Vector3(Random.Range(-0.48f, 2.68f), 0.457f, 0.09f);
        score = 0;
        goal2.SetActive(false);
        GameOver.enabled = false;

        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    void FixedUpdate()
    {
        if (check)
        {
            transform.position = Vector3.MoveTowards(transform.position, goal1.transform.position, 4.5f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, goal2.transform.position, 4.5f * Time.deltaTime);
        }
        transform.rotation *= Quaternion.Euler(0f, 0f, 1.9f);
        scoreText.text = score + "";

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        scoreLevelText.text = "YOU SCORED: " + score + "";
        highScoreText.text = "HIGH SCORE: " + highScore + "";

    }
    public void onClick()
    {
        check = !check;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal1")
        {
            check = false;

            goal1.SetActive(false);
            goal1.transform.position = new Vector3(goal1.transform.position.x, 0.52f, 0.09f);
            goal2.SetActive(true);
            goal2.transform.position = new Vector3(Random.Range(-0.48f, 2.68f),-3.1f, 0.09f);
            score += 1;
        }
        if (collision.tag == "Goal2")
        {
            check = true;
 
            goal2.SetActive(false);
            goal2.transform.position = new Vector3(goal2.transform.position.x, -3.1f, 0.09f);
            goal1.SetActive(true);
            goal1.transform.position = new Vector3(Random.Range(-0.48f, 2.68f), 0.52f, 0.09f);
            score += 1;

        }
        if (collision.tag == "PSDead")
        {

            this.gameObject.SetActive(false);
            Instantiate(Dead, transform.position, Quaternion.identity);
            PSDead = true;
            Invoke("PDead", 1f);
                        
        }
        if (collision.tag == "Top")
        {
            check = false;
        }
        if (collision.tag == "Bottom")
        {
            check = true;
        }
    }
    void PDead()
    {
        GameOver.enabled = true;
        GameOver.CrossFadeAlpha(255, 0.5f, true);
        Invoke("Result", 1f);
    }
    void Result()
    {
        resultPanel.SetActive(true);
    }
}
