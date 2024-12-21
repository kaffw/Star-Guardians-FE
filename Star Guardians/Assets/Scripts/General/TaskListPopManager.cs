using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskListPopManager : MonoBehaviour
{
    Animator taskListAnim;

    [Header("Tasks")]
    public GameObject humanTasks, manananggalTasks;

    [Header("Task Interactables")]    
    [HideInInspector] public GameObject mopTaskGO;
    [HideInInspector] public GameObject shelfTaskGO, scannerTaskGO, expireTaskGO, tagTaskGO;
    [HideInInspector] public TaskSpawner mopTask, shelfTask, scannerTask, expireTask, tagTask;

    //TaskText
    public static TextMeshProUGUI mopTaskText, shelfTaskText, scannerTaskText, expireTaskText, tagTaskText;

    //manananggal TaskText
    public TextMeshProUGUI manananggalDevourTask, locateLowerBodyTask;

    private bool callInstance;
    public bool nightCallInstance;

    private CharacterManager charManager;
    private DayAndNightTaskManager dntManager;

    public int devCount;
    private int devGoal;
    public bool nightTaskCleared;

    public static int firedCounter;
    private bool firedCalled;
    public GameObject firedCanvasPopUp;

    enum AnimationStates
    {
        isOpen
    }

    void Awake()
    {
        taskListAnim = GameObject.Find("Task List").GetComponent<Animator>();
        charManager = GameObject.Find("Character Manager").GetComponent<CharacterManager>();
        dntManager = GameObject.FindObjectOfType<DayAndNightTaskManager>();
        SetTasks();
    }

    void Start()
    {
        humanTasks.SetActive(true);
        manananggalTasks.SetActive(false);

        callInstance = false;
        nightCallInstance = false;
        
        devCount = 0;
        firedCounter = 0;
        firedCalled = false;
    }

    void Update()
    {
        //check if human is fired from her job (did not cleared tasks for 3 days)
        if(firedCounter == 3)
        {
            Debug.Log("You are fired");
            firedCanvasPopUp.SetActive(true);
        }
        if(charManager.isNight && !firedCalled)
        {
            firedCalled = true;

            if(
                mopTask.isCleared == false ||
                shelfTask.isCleared == false ||
                scannerTask.isCleared == false ||
                expireTask.isCleared == false ||
                tagTask.isCleared == false
            )
            {
                firedCounter++;
                Debug.Log("Fired counter = " + firedCounter);
            }
        }
        else if (!charManager.isNight)
        {
            firedCalled = false;
        }

        //call this when night
        if(charManager.isNight)
        {
            if(devCount == devGoal)
            {
                  manananggalDevourTask.color = Color.red;
                  devCount++;//disable re-call
                  nightTaskCleared = true;
            }

            if(!callInstance)
            {
                callInstance = true;

                humanTasks.SetActive(false);

                ResetHumanTasks();
                manananggalTasks.SetActive(true);
            }
        }

        //Transition to next day (auto): task
        if(!charManager.isNight && !nightCallInstance)
        {
            nightCallInstance = true;

            humanTasks.SetActive(true);
            ResetManananggalTask();
            manananggalTasks.SetActive(false);
        }

        //Transition to next day (Keybind): task
        if(Input.GetKeyDown(KeyCode.M) && !nightCallInstance)
        {
            nightCallInstance = true;

            manananggalTasks.SetActive(false);
            ResetManananggalTask();
            humanTasks.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.N) && !callInstance)
        {
            callInstance = true;

            humanTasks.SetActive(false);
            ResetHumanTasks();
            manananggalTasks.SetActive(true);
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

        mopTask.isCleared = false;
        shelfTask.isCleared = false;
        scannerTask.isCleared = false;
        expireTask.isCleared = false;
        tagTask.isCleared = false;
        
        mopTaskGO.SetActive(true);
        shelfTaskGO.SetActive(true);
        scannerTaskGO.SetActive(true);
        expireTaskGO.SetActive(true);
        tagTaskGO.SetActive(true);

        callInstance = false;
    }

    void ResetManananggalTask()
    {
        //Debug.Log("mnn task reset");
        int nc = 5 + (1 * dntManager.nightCount);
        devCount = 0;
        devGoal = nc;
        nightTaskCleared = false;
        manananggalDevourTask.color = Color.white;
        manananggalDevourTask.text = "Devour " + nc + " people.";
        nightCallInstance = false;
    }
}

/*
mopTask.isCleared &&
shelfTask.isCleared &&
scannerTask.isCleared &&
expireTask.isCleared &&
tagTask.isCleared &&
*/