using UnityEngine;
public class Singleton<T> : MonoBehaviour where T : Component
{
    void Awake()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<T>();
            DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            if (instance != this)
            {
                Debug.Log($"Duplicate object of type {typeof(T)}, destroying.");
                Destroy(gameObject);
            }
        }
    }

    private static T instance = null;

    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<T>();
            return instance;
        }
    }

}