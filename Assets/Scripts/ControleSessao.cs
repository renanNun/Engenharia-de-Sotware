using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSessao : MonoBehaviour
{
    static ControleSessao instance;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
