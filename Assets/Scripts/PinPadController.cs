using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PinPadController : MonoBehaviour
{
    [SerializeField] string word = null;
    [SerializeField] int wordIndex = -1;
    [SerializeField] public TMP_InputField pinField;
    [SerializeField] char[] nameChar = new char[5];
    [SerializeField] string alpha = null;
    [SerializeField] private string codeString;    
    [SerializeField] private TMP_Text numberOneCode;
    [SerializeField] private TMP_Text numberTwoCode;

    private int numberTwo;
    private int numberOne;
    

    void Start()
    {
        SetCode();
    }

    void Update()
    {
        CheckPin();
    }

    public void Alphabet(string alphabet)
    {
        if (wordIndex < 4)
        {
            wordIndex++;
            Debug.Log(wordIndex);
            char[] keepchar = alphabet.ToCharArray();
            nameChar[wordIndex] = keepchar[0];
            alpha = nameChar[wordIndex].ToString();
            word = word + alpha;
            pinField.text = word;
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void Backspace(string alphabet)
    {
        alpha = null;
        if (wordIndex >= 0)
        {
            wordIndex--;
            for (int i = 0; i < wordIndex + 1; i++)
            {
                alpha = alpha + nameChar[i].ToString();
            }
            word = alpha;
            pinField.text = word;
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    private void CheckPin()
    {
        if(pinField.text.Equals(codeString))
        {
            //TODO CHAIN ANIM
            pinField.text = "GRATZ";
        }
    }

    private void SetCode()
    {
        numberOne = Random.Range(1, 9);
        numberOneCode.text = "I." + numberOne;
        codeString += numberOne;
        Debug.Log("Your code is: " + codeString);
        numberTwo = Random.Range(0, 9);
        numberTwoCode.text = "II." + numberTwo;
        codeString += numberTwo;
        Debug.Log("Your code is: " + codeString);
    }
}
