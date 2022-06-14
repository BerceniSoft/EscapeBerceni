using System;
using UnityEngine;
using System.Collections;
using Dialog;
using Interactable;
using Movement;

public class Keypad : MonoBehaviour {

    public string curPassword = "BERCENI";
    public string input;
    public bool onTrigger;
    public bool doorOpen;
    public bool keypadScreen;
    public Transform doorHinge;
    public MainCharacterMovement mainCharacterMovement;
    private KeypadInteractableHandler _keypadInteractableHandler;

    void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        onTrigger = false;
        keypadScreen = false;
        input = "";
    }

    public void OpenKeypad(KeypadInteractableHandler keypadInteractableHandler)
    {
        keypadScreen = true;
        _keypadInteractableHandler = keypadInteractableHandler;
        mainCharacterMovement.PauseMovement();
    }

    void Update()
    {
        if (keypadScreen == false)
        {
            mainCharacterMovement.ResumeMovement();
        }
        if(input == curPassword)
        {
            mainCharacterMovement.StopMovement();
            mainCharacterMovement.ResumeMovement();
            input = "";
            doorOpen = true;
            _keypadInteractableHandler.ContinueDialog(3);
        }

        
    }

    void OnGUI()
    {
        if(!doorOpen)
        {
            if(onTrigger)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press 'E' to open keypad");

                if(Input.GetKeyDown(KeyCode.E))
                {
                    mainCharacterMovement.PauseMovement();
                    keypadScreen = true;
                    onTrigger = false;
                }
            }

            if(keypadScreen)
            {
                GUI.Box(new Rect(0, 0, 700, 250), "");
                GUI.Box(new Rect(5, 5, 690, 25), input);

                if(GUI.Button(new Rect(5, 35, 60, 60), "q"))
                {
                    input = input + "Q";
                }

                if(GUI.Button(new Rect(75, 35, 60, 60), "w"))
                {
                    input = input + "W";
                }
                
                if(GUI.Button(new Rect(145, 35, 60, 60), "e"))
                {
                    input = input + "E";
                }
                
                if(GUI.Button(new Rect(215, 35, 60, 60), "r"))
                {
                    input = input + "R";
                }
                
                if(GUI.Button(new Rect(285, 35, 60, 60), "t"))
                {
                    input = input + "T";
                }
                
                if(GUI.Button(new Rect(355, 35, 60, 60), "y"))
                {
                    input = input + "Y";
                }
                
                if(GUI.Button(new Rect(425, 35, 60, 60), "u"))
                {
                    input = input + "U";
                }
                
                if(GUI.Button(new Rect(495, 35, 60, 60), "i"))
                {
                    input = input + "I";
                }
                
                if(GUI.Button(new Rect(565, 35, 60, 60), "o"))
                {
                    input = input + "O";
                }
                
                if(GUI.Button(new Rect(635, 35, 60, 60), "p"))
                {
                    input = input + "P";
                }
                
                if(GUI.Button(new Rect(32, 105, 60, 60), "a"))
                {
                    input = input + "A";
                }

                if(GUI.Button(new Rect(102, 105, 60, 60), "s"))
                {
                    input = input + "S";
                }
                
                if(GUI.Button(new Rect(172, 105, 60, 60), "d"))
                {
                    input = input + "D";
                }
                
                if(GUI.Button(new Rect(242, 105, 60, 60), "f"))
                {
                    input = input + "F";
                }
                
                if(GUI.Button(new Rect(312, 105, 60, 60), "g"))
                {
                    input = input + "G";
                }
                
                if(GUI.Button(new Rect(382, 105, 60, 60), "h"))
                {
                    input = input + "H";
                }
                
                if(GUI.Button(new Rect(452, 105, 60, 60), "j"))
                {
                    input = input + "J";
                }
                
                if(GUI.Button(new Rect(522, 105, 60, 60), "k"))
                {
                    input = input + "K";
                }
                
                if(GUI.Button(new Rect(592, 105, 60, 60), "l"))
                {
                    input = input + "L";
                }
                
                if(GUI.Button(new Rect(75, 175, 60, 60), "z"))
                {
                    input = input + "Z";
                }
                
                if(GUI.Button(new Rect(145, 175, 60, 60), "x"))
                {
                    input = input + "X";
                }
                
                if(GUI.Button(new Rect(215, 175, 60, 60), "c"))
                {
                    input = input + "C";
                }
                
                if(GUI.Button(new Rect(285, 175, 60, 60), "v"))
                {
                    input = input + "V";
                }
                                
                if(GUI.Button(new Rect(355, 175, 60, 60), "b"))
                {
                    input = input + "B";
                }
                
                if(GUI.Button(new Rect(425, 175, 60, 60), "n"))
                {
                    input = input + "N";
                }

                if (GUI.Button(new Rect(495, 175, 60, 60), "m"))
                {
                    input = input + "M";
                }

                if(GUI.Button(new Rect(565, 175, 60, 60), "<-"))
                {
                    input = input.Substring(0, input.Length-1);
                }
                
                if(GUI.Button(new Rect(5, 175, 60, 60), "Close"))
                {
                    keypadScreen = false;
                    onTrigger = true;
                    mainCharacterMovement.StopMovement();
                }
            }
        }
    }
}