using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.PlayerLoop;

public class TaskManager : MonoBehaviour
{
    public GameObject taskPrefab; // Das Prefab für ein Task-Element
    public Transform taskListParent; // Der Container (Panel) für die Task-Liste
 

    void Start()
    {
        // Tasks aus der statischen Liste in TaskData anzeigen
        DisplayTasks();
        MiniGameManager.openMiniGames.Add(new MiniGameScript());
        MiniGameManager.openMiniGames.Add(new MiniGameScript());
        MiniGameManager.openMiniGames.Add(new MiniGameScript());
    }

    void Update()
    {
        DisplayTasks();
    }

    // Methode zum Darstellen der Tasks
    void DisplayTasks()
    {
        foreach (MiniGameScript task in MiniGameManager.openMiniGames)
        {
            AddTaskToUI(task);
        }
    }

    // Methode zum Hinzufügen eines Task-UI-Elements zur Task-Liste
    private void AddTaskToUI(MiniGameScript task)
    {
        GameObject newTask = Instantiate(taskPrefab, taskListParent);
        newTask.GetComponentInChildren<Text>().text = task.description; // Setzt den Task-Text
    }
}

