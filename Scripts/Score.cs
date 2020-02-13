using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform Ball;
    public Text scoreText;
    void Update()
    {
        scoreText.text = Ball.position.z.ToString("0");
    }
}
