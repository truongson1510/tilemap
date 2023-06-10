using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] Text scoreText;
    [SerializeField] int scoreCount;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text= scoreCount.ToString();

    }

    private void Update()
    {
        if (scoreCount >= 150)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void IncreaseScore()
    {
        scoreCount=scoreCount+25;
        scoreText.text = scoreCount.ToString();
    }
}
