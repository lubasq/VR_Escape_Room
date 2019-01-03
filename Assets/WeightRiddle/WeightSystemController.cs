using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeightSystemController : MonoBehaviour
{

    //public GameObject firstSack;
    //public float firstDistance;
    //public GameObject secondSack;
    //public float secondDistance;

    public GameObject[] sacks = new GameObject[4];
    public Vector3[] startPos = new Vector3[4];
    public Vector3[] endPos = new Vector3[4];
    public float firstDistance;
    public float secondDistance;

    public int whichFirstSack;
    public int whichSecondSack;

    [SerializeField] Animator anim;

 //   private Vector3 startPos;
  //  private Vector3 endPos;
  //  private Vector3 startPos_;
  //  private Vector3 endPos_;
    private int pulled = 0;

    private float lerpTime = 2.5f;
    private float currentLerpTime;

    void Start()
    {
        startPos[whichFirstSack] = sacks[whichFirstSack].transform.position;
        endPos[whichFirstSack] = startPos[whichFirstSack] + Vector3.down * firstDistance;
        startPos[whichSecondSack] = sacks[whichSecondSack].transform.position;
        endPos[whichSecondSack] = startPos[whichSecondSack] + Vector3.down * secondDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("isOpen")) {
           // Debug.Log(currentLerpTime);
            currentLerpTime += Time.deltaTime;

            float movement = currentLerpTime / lerpTime;
            sacks[whichFirstSack].transform.position = Vector3.Lerp(startPos[whichFirstSack], endPos[whichFirstSack], movement);
            sacks[whichSecondSack].transform.position = Vector3.Lerp(startPos[whichSecondSack], endPos[whichSecondSack], movement);

            if (currentLerpTime > lerpTime) {

                currentLerpTime = 0f;
                anim.SetBool("isOpen", false);
                startPos[whichFirstSack] = new Vector3(sacks[whichFirstSack].transform.position.x, sacks[whichFirstSack].transform.position.y, sacks[whichFirstSack].transform.position.z);
                endPos[whichFirstSack] = startPos[whichFirstSack] + Vector3.down * firstDistance;
                startPos[whichSecondSack] = new Vector3(sacks[whichSecondSack].transform.position.x, sacks[whichSecondSack].transform.position.y, sacks[whichSecondSack].transform.position.z);
                endPos[whichSecondSack] = startPos[whichSecondSack] + Vector3.down * secondDistance;

            }
        }
    }
}
