using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GaussianRNG : MonoBehaviour {

    int iset;
    double gset;
    System.Random r1, r2;
    public GameObject go;

    public GaussianRNG()
    {
        r1 = new System.Random(unchecked((int)DateTime.Now.Ticks));
        r2 = new System.Random(~unchecked((int)DateTime.Now.Ticks));
        iset = 0;
    }


    void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            GameObject clone = GameObject.Instantiate(go);
            float set1 = ((float) Next() * 100);
            float set2 = ((float)Next() * 100);
            Debug.Log(set1 + "   " + set2);
            clone.transform.position = new Vector3(set1, 0, set2);
        }
    }

    public double Next()
    {
        double fac, rsq, v1, v2;
        if (iset == 0)
        {
            do
            {
                v1 = 2.0 * r1.NextDouble() - 1.0;
                v2 = 2.0 * r2.NextDouble() - 1.0;
                rsq = v1 * v1 + v2 * v2;
            } while (rsq >= 1.0 || rsq == 0.0);

            fac = System.Math.Sqrt(-2.0 * System.Math.Log(rsq) / rsq);
            gset = v1 * fac;
            iset = 1;
            return v2 * fac;
        }
        else
        {
            iset = 0;
            return gset;
        }
    }
}
