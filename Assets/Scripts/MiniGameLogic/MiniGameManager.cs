using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance;
    public static List<MiniGameScript> reserveMiniGames = new List<MiniGameScript>();
    public static List<MiniGameScript> openMiniGames = new List<MiniGameScript>();
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Something went wrong. MiniGameManager already in scene!");
            DestroyImmediate(this);
        }
        instance = this;
        reserveMiniGames = FindObjectsByType<MiniGameScript>(FindObjectsInactive.Include, FindObjectsSortMode.None).ToList();

    }
    public void OnEnable()
    {
        DelayMiniGameSpawn();
    }
    public void DelayMiniGameSpawn()
    {
        int delay = Random.Range(1, 4);
        Debug.Log("Delaying next minigame for " + delay + " seconds");
        instance.Invoke("SpawnNewMiniGame", delay);
    }
    public void SpawnNewMiniGame()
    {
        Debug.Log("Spawning next minigame");
        if (reserveMiniGames.Count > 0)
        {
            MiniGameScript nextMiniGame = reserveMiniGames[Random.Range(0, reserveMiniGames.Count)];
            SpawnNewMiniGame(nextMiniGame);
        }
        else
        {
            Debug.Log("No MiniGame available");
        }
        DelayMiniGameSpawn();
    }
    public static void SpawnNewMiniGame(MiniGameScript minigame)
    {
        openMiniGames.Add(minigame);
        reserveMiniGames.Remove(minigame);
        minigame.OnStart();
    }
    public static void MiniGameCompleted(MiniGameScript minigame)
    {
        if (openMiniGames.Contains(minigame))
        {
            openMiniGames.Remove(minigame);
            reserveMiniGames.Add(minigame);
            //add completed sound
            //change ui
        }
    }

}
