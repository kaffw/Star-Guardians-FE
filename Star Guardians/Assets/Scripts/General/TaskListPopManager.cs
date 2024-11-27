using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskListPopManager : MonoBehaviour
{
    Animator taskListAnim;
    enum AnimationStates
    {
        isOpen
    }
    void Awake()
    {
        taskListAnim = GameObject.Find("Task List").GetComponent<Animator>();
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
}
