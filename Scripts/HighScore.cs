using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text score;
    public Text highScore;

    void Start()
    {

        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void UpdateScore()
    {
        int number = Random.Range(1, 2000);
        score.text = number.ToString();

        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number);
            highScore.text = number.ToString();
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
