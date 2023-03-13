using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
   /* private void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Musica");
        if (obj.Length >1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }*/

    void Awake()
    {
        SetUpMusic();
    }

    void SetUpMusic()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
}
