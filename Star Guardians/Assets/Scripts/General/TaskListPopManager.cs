using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskListPopManager : MonoBehaviour
{
    Animator taskListAnim;
    
    public GameObject humanTasks, manananggalTasks;
    
    public GameObject mopTaskGO, shelfTaskGO, scannerTaskGO, expireTaskGO, tagTaskGO;
    public TaskSpawner mopTask, shelfTask, scannerTask, expireTask, tagTask;
    public static TextMeshProUGUI mopTaskText, shelfTaskText, scannerTaskText, expireTaskText, tagTaskText;

    private int callInstance;

    enum AnimationStates
    {
        isOpen
    }

    void Awake()
    {
        taskListAnim = GameObject.Find("Task List").GetComponent<Animator>();
        
        SetTasks();
    }

    void Start()
    {
        humanTasks.SetActive(true);
        manananggalTasks.SetActive(false);

        callInstance = 0;
    }

    void Update()
    {
        if(
            mopTask.isCleared &&
            shelfTask.isCleared &&
            scannerTask.isCleared &&
            expireTask.isCleared &&
            tagTask.isCleared &&
            callInstance == 0
        )
        {
            callInstance++;
            humanTasks.SetActive(false);
            ResetHumanTasks();
            manananggalTasks.SetActive(true);
        }

        //Transition to next day: task
        if(Input.GetKeyDown(KeyCode.M))
        {
            humanTasks.SetActive(true);
            manananggalTasks.SetActive(false);
        }
    }

    public void TaskListManager()
    {
        bool isOpenBool = taskListAnim.GetBool(nameof(AnimationStates.isOpen)); 

        if (isOpenBool)
        {
            TaskListPopDown();
        }
        else
        {
            TaskListPopUp();
        }
    }

    public void TaskListPopUp()
    {
        taskListAnim.SetBool(nameof(AnimationStates.isOpen), true);
    }

    public void TaskListPopDown()
    {
        taskListAnim.SetBool(nameof(AnimationStates.isOpen), false);
    }

    void SetTasks()
    {
        mopTaskGO = GameObject.Find("Mop Task");
        shelfTaskGO = GameObject.Find("Shelf Task");
        scannerTaskGO = GameObject.Find("Scanner Task");
        expireTaskGO = GameObject.Find("Expire Task");
        tagTaskGO = GameObject.Find("Tag Task");
    
        mopTask = mopTaskGO.GetComponent<TaskSpawner>();
        shelfTask = shelfTaskGO.GetComponent<TaskSpawner>();
        scannerTask = scannerTaskGO.GetComponent<TaskSpawner>();
        expireTask = expireTaskGO.GetComponent<TaskSpawner>();
        tagTask = tagTaskGO.GetComponent<TaskSpawner>();

        mopTaskText = GameObject.Find("Mop Task Text").GetComponent<TextMeshProUGUI>();
        shelfTaskText = GameObject.Find("Shelf Task Text").GetComponent<TextMeshProUGUI>();
        scannerTaskText = GameObject.Find("Scanner Task Text").GetComponent<TextMeshProUGUI>();
        expireTaskText = GameObject.Find("Expire Task Text").GetComponent<TextMeshProUGUI>();
        tagTaskText = GameObject.Find("Tag Task Text").GetComponent<TextMeshProUGUI>();
    }

    void ResetHumanTasks()
    {
        mopTaskText.color = Color.white;
        shelfTaskText.color = Color.white;
        scannerTaskText.color = Color.white;
        expireTaskText.color = Color.white;
        tagTaskText.color = Color.white;
    }
}