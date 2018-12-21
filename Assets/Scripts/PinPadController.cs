using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PinPadController : MonoBehaviour
{
    [SerializeField] string word = null;
    [SerializeField] int wordIndex = -1;
    [SerializeField] public TMP_InputField pinField;
    [SerializeField] char[] nameChar = new char[5];
    [SerializeField] string alpha = null;
    [SerializeField] private int codeInt;
    [SerializeField] private string codeString;

    void Start()
    {
        //codeInt = Random.Range(11111, 99999);
        codeInt = 12345;
        Debug.Log("Your code is: " + codeInt);
        codeString = codeInt.ToString();
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
            pinField.text = "Pog U";
        }
    }
}
