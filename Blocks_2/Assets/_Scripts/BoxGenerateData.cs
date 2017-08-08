using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerateData : MonoBehaviour {

    [SerializeField] private int sizeHeight;
    [SerializeField] private int sizeWeight;
    [SerializeField] private int levelLong;
    [SerializeField] private float stepBetweenBoxes = 1.1f;

    private float levelStartPosZ = 0;
    private float levelStepZ = 5f;
    private GameObject parent;

    public List<float[]> BoxCoordinates;

    private void Start()
    {
        GlobalParameters.Instance.LevelHeight = sizeHeight;
        GlobalParameters.Instance.LevelWeight = sizeWeight;
        GlobalParameters.Instance.MoveStep = stepBetweenBoxes;

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
            if (l == levelLong - 1)
                DetRangeXY(BoxCoordinates);
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
        player.AddComponent<Rigidbody>();
        player.AddComponent<PlayerController>();
        player.name = "Player";
    }

    private void DetRangeXY(List<float[]> coord)
    {
        float minX = 0;
        float maxX = 0;
        float minY = 0;
        float maxY = 0;

        foreach (float[] xy in coord)
        {
            if (xy[0] < minX) minX = xy[0];
            if (xy[0] > maxX) maxX = xy[0];
            if (xy[1] < minY) minY = xy[1];
            if (xy[1] > maxY) maxY = xy[1];
        }

        GlobalParameters.Instance.RangeX = new float[] { minX, maxX };
        GlobalParameters.Instance.RangeY = new float[] { minY, maxY };
    }

}
