using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class LevelScript : MonoBehaviour
{
    private SceneLoaderScript sceneLoader;
    private int blocksCount;
    private void Start()
    {
        var blocks = FindObjectsOfType<Block>();
        blocksCount = Array.FindAll(blocks, b => b.tag == "Breakable").Length;
        sceneLoader = FindObjectOfType<SceneLoaderScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (blocksCount == 0) {
            sceneLoader.LoadNextScene();
        }
    }

    public void DecrementBlock() {
        blocksCount--;
    }
}
