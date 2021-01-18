using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; //to see how many blocks we broke (for debugging)
    SceneLoader sceneLoader; //cached reference


    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();  //Takes the class from cache and puts it into the code
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }
    public void BlocksDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
       
            sceneLoader.LoadNextScene();
         

        }
    }

}
