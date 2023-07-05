using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // we don't need the Start() or Update()

    public static MainManager Instance;
    public Color TeamColor;

    public void Awake()
    {
        // The very first time that you launch the Menu scene, no MainManager will have filled the Instance variable. 
        // This means it will be null, so the condition will not be met, and the script will continue as you previously 
        // wrote it.  However, if you load the Menu scene again later, there will already be one MainManager in existence, 
        // so Instance will not be null. In this case, the condition is met: the extra MainManager is destroyed and the script 
        // exits there.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
