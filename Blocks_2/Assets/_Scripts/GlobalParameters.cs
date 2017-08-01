using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalParameters : MonoBehaviour
{
    private int levelHeight;
    private int levelWeight;

    public static GlobalParameters Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int LevelHeight
    {
        get { return levelHeight; }
        set { levelHeight = value; }
    }

    public int LevelWeight
    {
        get { return levelWeight; }
        set { levelWeight = value; }
    }

}
