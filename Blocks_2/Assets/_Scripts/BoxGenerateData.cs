using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerateData : MonoBehaviour {

    [SerializeField] private int sizeHeight;
    [SerializeField] private int sizeWeight;
    [SerializeField] private int levelLong;

    private float stepBetweenBoxes = 1.1f;
    private float levelStartPosZ = 0;
    private float levelStepZ = 5f;
    private GameObject parent;

    public List<float[]> BoxCoordinates;

    private void Start()
    {
        GlobalParameters.Instance.LevelHeight = sizeHeight;
        GlobalParameters.Instance.LevelWeight = sizeWeight;

        createParentForBoxes();
        generateBox();
        instantiatePlayer();
    }

    private void generateBox()
    {
        BoxCoordinates = new List<float[]>();

        for (int l = 0; l < levelLong; l++)
        {
            int rndH = Random.Range(0, sizeHeight - 1);
            int rndW = Random.Range(0, sizeWeight - 1);

            for (int i = 0; i < sizeHeight; i++)
                for (int j = 0; j < sizeWeight; j++)
                    if (!(i == rndH && j == rndW))
                    {
                        float[] coord = new float[] { j * stepBetweenBoxes - ((sizeWeight - 1) * stepBetweenBoxes) / 2,
                            i * stepBetweenBoxes - ((sizeHeight - 1) * stepBetweenBoxes) / 2 };
                        BoxCoordinates.Add(coord);
                    }
            instantiateBox();
        }
    }

    private void instantiateBox()
    {
        foreach (float[] b in BoxCoordinates)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = new Vector3(b[0], b[1], levelStartPosZ);
            go.transform.SetParent(parent.transform);
        }
        levelStartPosZ += levelStepZ;
        BoxCoordinates.RemoveRange(0, BoxCoordinates.Count);
    }

    private void createParentForBoxes()
    {
        parent = new GameObject();
        parent.name = "ParentBox";
    }

    private void instantiatePlayer()
    {
        GameObject player = GameObject.CreatePrimitive(PrimitiveType.Cube);
        player.AddComponent<PlayerController>();
        player.name = "Player";
    }

}
