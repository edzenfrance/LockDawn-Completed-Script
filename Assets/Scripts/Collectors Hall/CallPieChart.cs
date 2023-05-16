using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPieChart : MonoBehaviour
{
    public GameObject pieChartBackground;


    public void GenerateRandomPieChart()
    {
        float[] values = new float[2];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = Random.Range(0.0f, 100.0f);
        }
        pieChartBackground.GetComponent<PieChart>().SetValues(values);
        //GetComponent<PieChart>().SetValues(values);
    }
}
