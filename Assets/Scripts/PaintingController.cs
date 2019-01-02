using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintingController : MonoBehaviour {

    [SerializeField] GameObject[] partPainting = new GameObject[9];

    float[] x = new float[9];
    float[] y = new float[9];
    float[] z = new float[9];
    bool[] b = new bool[9];   
    private Animator anim;

    void Start () {

        anim = GetComponent<Animator>();
        anim.enabled = false;

        for (int i = 0; i<9; i++)
        {
            x[i] = partPainting[i].transform.eulerAngles.x;
            y[i] = partPainting[i].transform.eulerAngles.y;
            z[i] = partPainting[i].transform.eulerAngles.z;
            b[i] = false;
        }
    }

	void Update () {
        //CheckState();
    }

     public void ChangeRotation0()
    {
        var localIndex = 0;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] > 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation1()
    {
        var localIndex = 1;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] > 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation2()
    {
        var localIndex = 2;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] > 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation3()
    {
        var localIndex = 3;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] > 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation4()
    {
        var localIndex = 4;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] > 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation5()
    {
        var localIndex = 5;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] > 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation6()
    {
        var localIndex = 6;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] > 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation7()
    {
        var localIndex = 7;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] > 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation8()
    {
        var localIndex = 8;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] > 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }




    /* public void CheckState()
     {
         if (z1 == 180)
         {
             b1 = true;
         }
         else
         {
             b1 = false;
         }

         if (z2 == 90)
         {
             b2 = true;
         }
         else
         {
             b2 = false;
         }

         if (z3 == 180)
         {
             b3 = true;
         }
         else
         {
             b3 = false;
         }

         if (z4 == 90 )
         {
             b4 = true;
         }
         else
         {
             b4 = false;
         }


         if (b1 == true && b2 == true && b3 == true && b4 == true)
             {
             anim.enabled = true;
             }
         }*/

}