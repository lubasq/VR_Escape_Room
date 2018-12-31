using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingController : MonoBehaviour {
    [SerializeField] GameObject partPainting1;
    [SerializeField] GameObject partPainting2;
    [SerializeField] GameObject partPainting3;
    [SerializeField] GameObject partPainting4;
    //[SerializeField] GameObject cube;

    private Animator anim;

    private float x1,y1,z1;
    private float x2, y2, z2;
    private float x3, y3, z3;
    private float x4, y4, z4;

    private bool b1, b2, b3, b4 = false;


    void Start () {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        x1 = partPainting1.transform.eulerAngles.x;
        y1 = partPainting1.transform.eulerAngles.y;
        z1 = partPainting1.transform.eulerAngles.z;

        x2 = partPainting2.transform.eulerAngles.x;
        y2 = partPainting2.transform.eulerAngles.y;
        z2 = partPainting2.transform.eulerAngles.z;

        x3 = partPainting3.transform.eulerAngles.x;
        y3 = partPainting3.transform.eulerAngles.y;
        z3 = partPainting3.transform.eulerAngles.z;

        x4 = partPainting3.transform.eulerAngles.x;
        y4 = partPainting3.transform.eulerAngles.y;
        z4 = partPainting3.transform.eulerAngles.z;
    }

	void Update () {
        CheckInput();
        CheckState();
    }

    void CheckInput()
    {
    
    }

     public void ChangeRotation1()
    {
        Mathf.Round(z1);
        z1 += 90;
        if (z1 > 360) z1 = 0;
        partPainting1.transform.rotation = Quaternion.Euler(x1, y1, z1);
    }

    public void ChangeRotation2()
    {
        Mathf.Round(z2);
        z2 += 90;
        if (z2 > 360) z2 = 0;
        partPainting2.transform.rotation = Quaternion.Euler(x2, y2, z2);
    }

    public void ChangeRotation3()
    {
        Mathf.Round(z3);
        z3 += 90;
        if (z3 > 360) z3 = 0;
        partPainting3.transform.rotation = Quaternion.Euler(x3, y3, z3);
    }

    public void ChangeRotation4()
    {
        Mathf.Round(z4);
        z4 += 90;
        if (z4 > 360) z4 = 0;
        partPainting4.transform.rotation = Quaternion.Euler(x4, y4, z4);
    }

    public void CheckState()
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
            anim.SetBool("isOpen", true);
            }
        }
        
}
