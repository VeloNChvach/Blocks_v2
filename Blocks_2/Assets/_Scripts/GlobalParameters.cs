using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalParameters : MonoBehaviour
{
    private int levelHeight, levelWeight;
    private float[] rangeX, rangeY;
    private float moveStep;

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

    public float[] RangeX
    {
        get { return rangeX; }
        set { rangeX = value; }
    }

    public float[] RangeY
    {
        get { return rangeY; }
        set { rangeY = value; }
    }

    public float MoveStep
    {
        get { return moveStep; }
        set { moveStep = value; }
    }
}
