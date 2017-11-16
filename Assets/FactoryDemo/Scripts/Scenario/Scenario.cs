using UnityEngine;
using UnityEngine.SceneManagement;

class Scenario : MonoBehaviour
{
    public ProgressController[] Tasks;

    protected bool isFinished;

    void Update()
    {
        if(Tasks != null)
        {
            foreach (ProgressController task in Tasks)
            {
                if (task.Points != task.Goal)
                {
                    return;
                }
            }
        }

        if (!isFinished)
        {
            OnProgressCompleted();
        }
    }

    protected virtual void OnProgressCompleted()
    {
        isFinished = true;
    }
}