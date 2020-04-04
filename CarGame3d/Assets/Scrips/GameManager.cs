using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region vars
    PlayerMove[] players;
    TargetPoints[] targetPoints;
    EnterancePoint[] enterancePoints;
    [SerializeField]
    private GameObject enterance;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject playButton;
    public Text timerTxt;
    public float time;
    public float resetTime;
    string timerStr;
    public int nextSceneIndex;
    int index=0;
    #endregion

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        foreach(PlayerMove player in PlayerMove.all)
        {
            player.SetComponents(false);
            player.CanWeMove(false);
        }
        players = PlayerMove.all.ToArray();
        enterancePoints = EnterancePoint.all.ToArray();
        targetPoints = TargetPoints.all.ToArray();
        StartMove();
    }

    void Update()
    {
        timerStr = $"{time:00}";
        time -= 1 * Time.deltaTime;
        timerTxt.text = timerStr;
        if (time <= 0)
        {
            ReTry();
        }
    }
    public void PlayGame() //Starts time and controls (PlayButton onClick())
    {
        playButton.SetActive(false);
        Time.timeScale = 1;
        players[index].CanWeMove(true);
    }
    public void NextCar()//When reach to target changes car/enterance/target
    {
        int playersLength = players.Length;
        players[index].CanWeMove(false);
        index+=1;

        if(index<playersLength)
        players[index] = players[index];

        StartMove();
    }
    void StartMove()//prepares scene to next step
    {
        int playersLength = players.Length;
        if (index == playersLength) //check if there is any other car left, if not load next level
        {
            SceneManager.LoadScene(nextSceneIndex);
            index = 0;
        }

        if (enterancePoints[index] != null)
            ChangeEnterance();

        SpawnPlayer();
        players[index].SetComponents(true);

        if(targetPoints[index]!=null)
        target.transform.position = targetPoints[index].transform.position;

        ResetTimer();
        playButton.SetActive(true);
        Time.timeScale = 0;
        
    }
    public void ReTry()//when hits others
    {
        SpawnPlayer();
        players[index].CanWeMove(false);
        ResetTimer();
        playButton.SetActive(true);
        Time.timeScale = 0;
    }
    void ResetTimer()
    {
        time = resetTime;
    }
    void SpawnPlayer() //changes position of car to EP
    {
        players[index].transform.position = enterance.transform.position;
        players[index].transform.rotation = enterance.transform.rotation;
    }
    void ChangeEnterance() //called after player reached target to change car's spawn point
    {
        enterance.transform.position = enterancePoints[index].transform.position;
        enterance.transform.rotation = enterancePoints[index].transform.rotation;
    }
}
