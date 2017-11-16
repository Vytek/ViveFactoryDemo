using UnityEngine;

class ProgressItem : MonoBehaviour, IRemoveOnTouch
{
    public ProgressController Controller;
    public int Modifier = 1;

    public bool ShouldRemove()
    {
        return true;
    }
}
