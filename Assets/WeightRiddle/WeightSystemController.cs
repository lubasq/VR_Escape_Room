using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeightSystemController : MonoBehaviour
{

    //public GameObject firstSack;
    //public float firstDistance;
    //public GameObject secondSack;
    //public float secondDistance;
   // public static bool leversMoving = false;
    private static Vector3[] startPos = new Vector3[4];
    private static Vector3[] endPos = new Vector3[4];

    public GameObject[] sacks = new GameObject[4];

    [SerializeField] float firstDistance;
    [SerializeField] float secondDistance;

    public int whichFirstSack;
    public int whichSecondSack;

    private Vector3 resetPos = new Vector3(8.161f, 0f, -2.513f);

    private Animator anim;

    public int whichLever;
    public static int[] pulled = new int[3];

    private float lerpTime = 2.5f;
    private float currentLerpTime;

    void Awake()
    {
        for (int i = 0; i < pulled.Length; ++i) {
            pulled[i] = 0;
        } 
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
            GameVariables.leversMoving = true;
            startPos[whichFirstSack] = sacks[whichFirstSack].transform.position;
            endPos[whichFirstSack] = startPos[whichFirstSack] + Vector3.down * firstDistance;
            startPos[whichSecondSack] = sacks[whichSecondSack].transform.position;
            endPos[whichSecondSack] = startPos[whichSecondSack] + Vector3.down * secondDistance;
            for (int i = 0; i < sacks.Length; ++i) 
                // (resetPos) = (sacks[0].transform.position = resetPos) = (sacks[0].transform.position);
                startPos[i] = sacks[i].transform.position;

                if (pulled[whichLever] == 3) {
                    for (int i = 0; i < pulled.Length; ++i) {
                        pulled[i] = 0;
                    }
                }
                else 
                    pulled[whichLever] += 1;
    }

    void OnDisable()
    {
        if (WeightSystemController.pulled[0] == 2 && WeightSystemController.pulled[1] == 2 && WeightSystemController.pulled[2] == 1) {
            GameVariables.sacksInRow = true;
        }
        else {
            GameVariables.leversMoving = false;
            anim.SetBool("isOpen", false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("isOpen")) {
            if (pulled[whichLever] < 3) {
                currentLerpTime += Time.deltaTime;

                float movement = currentLerpTime / lerpTime;
                sacks[whichFirstSack].transform.position = Vector3.Lerp(startPos[whichFirstSack], endPos[whichFirstSack], movement);
                sacks[whichSecondSack].transform.position = Vector3.Lerp(startPos[whichSecondSack], endPos[whichSecondSack], movement);

                if (currentLerpTime > lerpTime) {

                    currentLerpTime = 0f;
                    startPos[whichFirstSack] = new Vector3(sacks[whichFirstSack].transform.position.x, sacks[whichFirstSack].transform.position.y, sacks[whichFirstSack].transform.position.z);
                    endPos[whichFirstSack] = startPos[whichFirstSack] + Vector3.down * firstDistance;
                    startPos[whichSecondSack] = new Vector3(sacks[whichSecondSack].transform.position.x, sacks[whichSecondSack].transform.position.y, sacks[whichSecondSack].transform.position.z);
                    endPos[whichSecondSack] = startPos[whichSecondSack] + Vector3.down * secondDistance;
                    OnDisable();

                }
            }
            else {
                currentLerpTime += Time.deltaTime;
                float movement = currentLerpTime / lerpTime;
                for (int i = 0; i < sacks.Length; ++i) {
                    // (resetPos) = (sacks[0].transform.position = resetPos) = (sacks[0].transform.position);
                    sacks[i].transform.position = Vector3.Lerp(startPos[i], resetPos, movement);
                }
                if (currentLerpTime > lerpTime) 
                    {
                    currentLerpTime = 0;
                    for (int i = 0; i < sacks.Length; i++) 
                    {  
                        sacks[i].transform.position = resetPos; 
                        startPos[i] = sacks[i].transform.position;
                        OnDisable();
                    }
                }
            }
        }
    }
}
