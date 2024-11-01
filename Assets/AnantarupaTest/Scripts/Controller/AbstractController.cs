using UnityEngine;

public abstract class AbstractController : MonoBehaviour
{
    protected abstract void Awake();

    public abstract void DoLogic();
}