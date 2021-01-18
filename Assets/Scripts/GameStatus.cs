using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //config params
    [Range (0f, 10)] [SerializeField] float timeSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 15;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoplayEnabled;
   

    //states
    [SerializeField] int currentScore = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void DestroyItself()
    {
        Destroy(gameObject);
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeSpeed;
        scoreText.text = currentScore.ToString();

    }
    public void AddToScore()
    {
        currentScore = currentScore + pointsPerBlockDestroyed; // the same as currentScore+= pointsPerBlockDestroyed
    }
    public bool IsAutoplayEnabled()
    {
        return isAutoplayEnabled;
    }
}
