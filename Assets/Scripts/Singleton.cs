using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    public static T Instance;

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Trying to create new instance of {0}, should be only one.");
        }
        else
        {
            Instance = GetComponent<T>();
        }
    }
}
