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
    private static Vector3[] startPos = new Vector3[4];
    private static Vector3[] endPos = new Vector3[4];
    [SerializeField] float firstDistance;
    [SerializeField] float secondDistance;

    public int whichFirstSack;
    public int whichSecondSack;

    private Vector3 resetPos = new Vector3(8.161f, 0f, -2.513f);

    private Animator anim;

    //   private Vector3 startPos;
    //  private Vector3 endPos;
    //  private Vector3 startPos_;
    //  private Vector3 endPos_;
    public int whichLever;
    private int[] pulled = new int[3];

    private float lerpTime = 2.5f;
    private float currentLerpTime;

    void Awake()
    {
        for(int i=0;i<pulled.Length;++i)
        {
            pulled[i] = 0;
        }
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        startPos[whichFirstSack] = sacks[whichFirstSack].transform.position;   
        endPos[whichFirstSack] = startPos[whichFirstSack] + Vector3.down * firstDistance; 
        Debug.Log(startPos[whichFirstSack]);
        Debug.Log(endPos[whichFirstSack]);
        startPos[whichSecondSack] = sacks[whichSecondSack].transform.position; /
        endPos[whichSecondSack] = startPos[whichSecondSack] + Vector3.down * secondDistance;
        if (pulled[whichLever] < 3)
            pulled[whichLever] += 1;
        else
        {
            for (int i = 0; i < pulled.Length; ++i)
            {
                pulled[i] = 1;
            }
        }
    }

    void OnDisable()
{

        anim.SetBool("isOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(pulled[whichLever]);
        if (anim.GetBool("isOpen"))
        { 
            if (pulled[whichLever] < 3)
            {
                Debug.Log("am i here");
                currentLerpTime += Time.deltaTime;

                float movement = currentLerpTime / lerpTime;
                sacks[whichFirstSack].transform.position = Vector3.Lerp(startPos[whichFirstSack], endPos[whichFirstSack], movement);
                sacks[whichSecondSack].transform.position = Vector3.Lerp(startPos[whichSecondSack], endPos[whichSecondSack], movement);

                if (currentLerpTime > lerpTime)
                {

                    currentLerpTime = 0f;
                    startPos[whichFirstSack] = new Vector3(sacks[whichFirstSack].transform.position.x, sacks[whichFirstSack].transform.position.y, sacks[whichFirstSack].transform.position.z);
                    endPos[whichFirstSack] = startPos[whichFirstSack] + Vector3.down * firstDistance;
                    startPos[whichSecondSack] = new Vector3(sacks[whichSecondSack].transform.position.x, sacks[whichSecondSack].transform.position.y, sacks[whichSecondSack].transform.position.z);
                    endPos[whichSecondSack] = startPos[whichSecondSack] + Vector3.down * secondDistance;

                }
            }
            else
            {
                    Debug.Log("?");
                    currentLerpTime += Time.deltaTime;
                    float movement = currentLerpTime / lerpTime;
                    for (int i = 0; i < sacks.Length; ++i)
                    {
                    // (resetPos) = (sacks[0].transform.position = resetPos) = (sacks[0].transform.position);
                    startPos[i] = sacks[i].transform.position; 
                    sacks[i].transform.position = Vector3.Lerp(startPos[i], resetPos, movement);
                    }
                    if(currentLerpTime > lerpTime)
                {
                    currentLerpTime = 0;
                    //reset startpos and endposition
                }
                }
            }
        }
    }

