using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.Collections;
using TMPro;
using System.Linq;

public class Game_Control2 : MonoBehaviour
{
    public TextMeshProUGUI[] ButtonText = new TextMeshProUGUI[9];
    public TextMeshProUGUI outputText;

    int[] ButtonNumber = new int[9];
    int im = 0, jm = 1, pressedBtn, magicSum;
    int[] square = new int[9];
    bool empty = true, isFull = false;

    int[,] array = new int[3, 3];
    string[,] stringArray = new string[3, 3];


    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            ButtonText[i].text = "";
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncrementDecrement(pressedBtn);
        }
    }

    public void IncrementDecrement(int whatButton)
    {
        if (pressedBtn != whatButton)
            ButtonNumber[whatButton] = 0;

        pressedBtn = whatButton;
        
        for (int i = 0; i < 9; i++)
        {
            if (i != whatButton)
            {
                ButtonText[i].text = "";
            }
        }

        int counter = ButtonNumber[whatButton];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            counter--;
        }
        else
        {
            counter++;
        }

        ButtonText[whatButton].text = counter.ToString();
        ButtonNumber[whatButton] = counter;
        outputText.text = "The Magic Sum";
    }

    public void CheckMagicSquare()
    {
        for(int i = 0; i < 9; i++)
        {
            if (ButtonText[i].text != "")
            {
                empty = false;
            }
        }

        if (empty)
        {
            Output_Standard_MagicSquare(1);
        }
        else 
        {
            int val = Int32.Parse(ButtonText[pressedBtn].text);
            switch(pressedBtn)
            {
                case 0:
                    val = val-7;
                    break;
                case 1:
                    val = val;
                    break;
                case 2:
                    val = val-5;
                    break;
                case 3:
                    val = val-2;
                    break;
                case 4:
                    val = val-4;
                    break;
                case 5:
                    val = val-6;
                    break;
                case 6:
                    val = val-3;
                    break;
                case 7:
                    val = val-8;
                    break;
                case 8:
                    val = val-1;
                    break;
            }
            Debug.Log(val);
            Output_Standard_MagicSquare(val);
        }
         
    }

    void Output_Standard_MagicSquare(int FirstValue)
    {
        for (int row=0; row<3; row++)
        {
            for (int col=0; col<3; col++)
            {
                stringArray[row, col] = "*";
            }
        }

        array[0, 1] = FirstValue;
        stringArray[0, 1] = FirstValue.ToString();
        
        im = (im+2)%3;
        jm = (jm+1)%3;

        while (!isFull)
        {
            ++FirstValue;
            if (stringArray[im, jm] == "*")
            {
                array[im, jm] = FirstValue;
                stringArray[im, jm] = FirstValue.ToString();
            }
            else 
            {
                im = (im+1)%3; //returning its previous position
                jm = (jm+2)%3;

                im = (im+1)%3; //new position when diagonal isn't available
                if (stringArray[im, jm] != "*")
                {
                    isFull = true;
                    break;
                }
                array[im, jm] = FirstValue;
                stringArray[im, jm] = FirstValue.ToString();
            }
            im = (im+2)%3;
            jm = (jm+1)%3;
        }

        isFull = false;

        ButtonText[0].text = array[0, 0].ToString();
        ButtonText[1].text = array[0, 1].ToString();
        ButtonText[2].text = array[0, 2].ToString();
        ButtonText[3].text = array[1, 0].ToString();
        ButtonText[4].text = array[1, 1].ToString();
        ButtonText[5].text = array[1, 2].ToString();
        ButtonText[6].text = array[2, 0].ToString();
        ButtonText[7].text = array[2, 1].ToString();
        ButtonText[8].text = array[2, 2].ToString();

        magicSum = array[0, 0] + array[0, 1] + array[0, 2];
        outputText.text +=  "\n" + magicSum.ToString();

    }
}
