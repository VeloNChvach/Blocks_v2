using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerateData : MonoBehaviour {

    [SerializeField] private int sizeHeight;
    [SerializeField] private int sizeWeight;
    [SerializeField] private int levelLong;

    private float stepBetweenBoxes = 1.1f;
    private float levelPosZ = 0;
    private float levelStepZ = 2f;

    public List<float[]> BoxCoordinates;

    private void Start()
    {
        generateBox();
    }

    private void generateBox()
    {
        BoxCoordinates = new List<float[]>();
        //int[] rndH = new int[] { 0, 1 };
        //int[] rndW = new int[] { 0, 1 };

        for (int l = 0; l < levelLong; l++)
        {
            int rndH = 0;
            int rndW = 0;

            // Create one level with random enter
            for (int i = 0; i < sizeHeight; i++)
                for (int j = 0; j < sizeWeight; j++)
                    if (!(i == rndH && j == rndW))
                    {
                        float[] coord = new float[] { j * stepBetweenBoxes - (sizeWeight * stepBetweenBoxes) / 2,
                            i * stepBetweenBoxes - (sizeHeight * stepBetweenBoxes) / 2 };
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
            go.transform.position = new Vector3(b[0], b[1], levelPosZ);
        }
        levelPosZ += levelStepZ;
    }

}
