using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance;
    public static List<MiniGameScript> availableMiniGames = new List<MiniGameScript>();
    public static List<MiniGameScript> openMiniGames = new List<MiniGameScript>();
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Something went wrong. MiniGameManager already in scene!");
            DestroyImmediate(this);
        }
        instance = this;
        availableMiniGames = FindObjectsByType<MiniGameScript>(FindObjectsInactive.Include, FindObjectsSortMode.None).ToList();
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
        if (availableMiniGames.Count > 0)
        {
            MiniGameScript nextMiniGame = availableMiniGames[Random.Range(0, availableMiniGames.Count)];
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
        availableMiniGames.Remove(minigame);
        minigame.OnStart();
    }
    public static void MiniGameCompleted(MiniGameScript minigame)
    {
        if (openMiniGames.Contains(minigame))
        {
            openMiniGames.Remove(minigame);
            availableMiniGames.Add(minigame);
            //add completed sound
            //change ui
        }
    }

}
