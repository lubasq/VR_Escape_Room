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
        CheckState();
    }

     public void ChangeRotation0()
    {
        var localIndex = 0;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] >= 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation1()
    {
        var localIndex = 1;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] >= 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation2()
    {
        var localIndex = 2;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] >= 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation3()
    {
        var localIndex = 3;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] >= 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation4()
    {
        var localIndex = 4;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] >= 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation5()
    {
        var localIndex = 5;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] >= 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation6()
    {
        var localIndex = 6;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] >= 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation7()
    {
        var localIndex = 7;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] >= 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }

    public void ChangeRotation8()
    {
        var localIndex = 8;
        Mathf.Round(z[localIndex]);
        z[localIndex] += 90;
        if (z[localIndex] >= 360) z[localIndex] = 0;
        partPainting[localIndex].transform.rotation = Quaternion.Euler(x[localIndex], y[localIndex], z[localIndex]);
    }




     public void CheckState()
     {
         if (z[0] == 180)
         {
             b[0] = true;
         }
         else
         {
             b[0] = false;
         }

        if (z[1] == 90)
        {
            b[1] = true;
        }
        else
        {
            b[1] = false;
        }

        if (z[2] == 180)
        {
            b[2] = true;
        }
        else
        {
            b[2] = false;
        }

        if (z[3] == 0)
        {
            b[3] = true;
        }
        else
        {
            b[3] = false;
        }

        if (z[4] == 180)
        {
            b[4] = true;
        }
        else
        {
            b[4] = false;
        }
        
        if (z[5] == 90)
        {
            b[5] = true;
        }
        else
        {
            b[5] = false;
        }

        if (z[6] == 180)
        {
            b[6] = true;
        }
        else
        {
            b[6] = false;
        }

        if (z[7] == 90)
        {
            b[7] = true;
        }
        else
        {
            b[7] = false;
        }

        if (z[8] == 180)
        {
            b[8] = true;
        }
        else
        {
            b[8] = false;
        }

        if (b[0] == true && b[1] == true && b[2] == true && b[3] == true && b[4] == true && b[5] == true && b[6] == true && b[7] == true && b[8] == true)
             {
            anim.enabled = true;
             }
         }

}