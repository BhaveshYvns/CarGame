using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speedTextUi;
    [SerializeField] TextMeshProUGUI ScoreTextUi;
    [SerializeField] TextMeshProUGUI DistanceTextUi;

    [SerializeField] TextMeshProUGUI totalScoreTextUi;
    [SerializeField] TextMeshProUGUI MaximumSpeedTextUi;
    [SerializeField] TextMeshProUGUI TotalDistanceTextUi;

    [SerializeField] CarMovement Carspeed;
    [SerializeField] Transform carTransform;
    [SerializeField] GameObject GameOverPanel;
    private float speed = 0f;
    private float distance = 0f;
    private float Score = 0f;
    private float maximumSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SpeedCalculator();
        ScoreCalculator();
        MaximumSpeed();

        DistanceCalculator();
    }
    void SpeedCalculator()
    {
        speed = Carspeed.CarSpeed();
        speedTextUi.text = speed.ToString("0" + "Kmph");
    }

    void DistanceCalculator()
    {
        distance = carTransform.position.z / 1000;
        DistanceTextUi.text = distance.ToString("0.00" + "Km");
    }

    void ScoreCalculator()
    {
        Score = carTransform.position.z * 6;
        ScoreTextUi.text = Score.ToString("0");
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOverPanel.SetActive(true);

       totalScoreTextUi.text = Score.ToString("0");

       TotalDistanceTextUi.text = distance.ToString("0.00" + "Km");
    }
    public void MaximumSpeed()
    {
        float currentSpeed = Carspeed.CarSpeed(); // use the instance, not the class
        if (currentSpeed > maximumSpeed)
        {
            maximumSpeed = currentSpeed;
        }
        MaximumSpeedTextUi.text = maximumSpeed.ToString("0" + "kmph");
    }

}


