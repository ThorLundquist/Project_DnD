using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileIO : MonoBehaviour
{
    CharacterGenerator thisCharacter;
    string filePath = "Assets/Resources/CharacterSaves/";
    string fileName;

    public void SaveCharacter(string name)
    {
        fileName = filePath + name + ".txt";
        StreamWriter mySW = new StreamWriter(fileName);
        //grab reference to the current character generation
        CharacterGenerator thisCharacter = GetComponent<CharacterGenerator>();
        //basic population of output file
        mySW.WriteLine("Name:" + name);
        mySW.WriteLine("Gender:" + thisCharacter.isMale);
        mySW.WriteLine("Race:" + thisCharacter.myRace.ToString());
        mySW.WriteLine("Class:" + thisCharacter.myClass.ToString());
        mySW.WriteLine("Portrait:" + thisCharacter.myPortrait.ToString());

        foreach (CharacterAttributes.BaseAttributes thisAttributes in System.Enum.GetValues(typeof(CharacterAttributes.BaseAttributes)))
        {
            mySW.WriteLine(thisAttributes.ToString() + ": " + thisCharacter.myAttributes[thisAttributes]);
        }

        mySW.WriteLine("HP: ");

        mySW.Flush();
        mySW.Close();
    }

    public void LoadCharacter(string name)
    {
        fileName = filePath + name + ".txt";
        Debug.Log("Filename is: " + fileName);

        StreamReader mySR = new StreamReader(fileName);

        if (!File.Exists(fileName))
        {
            Debug.Log("File not found");
            return;
        }

        CharacterGenerator thisCharacter = GetComponent<CharacterGenerator>();

        string input = mySR.ReadLine();
        while (input != null || input == "")
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.Log(input);
                if (input.Contains(":"))
                {
                    int index = input.IndexOf(":");
                    string thing = input.Substring(0, index);
                    string value = input.Substring(index + 1, (input.Length - 1) - index);

                    switch (thing)
                    {
                        case "Name":
                            break;
                        case "Race":
                            foreach (CharacterAttributes.Races thisRace in System.Enum.GetValues(typeof(CharacterAttributes.Races)))
                            {
                                if (thisRace.ToString() == value)
                                {
                                    thisCharacter.myRace = thisRace;
                                }
                            }
                            break;
                        case "Class":
                            foreach (CharacterAttributes.Classes thisClass in System.Enum.GetValues(typeof(CharacterAttributes.Classes)))
                            {
                                if (thisClass.ToString() == value)
                                {
                                    Debug.Log("before: " + thisCharacter.myClass);
                                    thisCharacter.myClass = thisClass;
                                    Debug.Log("after: " + thisCharacter.myClass);
                                }
                            }
                            break;
                        case "Gender":
                            thisCharacter.isMale = true;
                            if (value == "False")
                            {
                                thisCharacter.isMale = false;
                            }
                            break;
                        case "Portrait":
                            thisCharacter.portraitString = value;
                            GetComponent<UIHandler>().UpdateUI(true);
                            break;
                        case "HP":                    
                            break;
                        default:
                            foreach (CharacterAttributes.BaseAttributes thisAttributes in System.Enum.GetValues(typeof(CharacterAttributes.BaseAttributes)))
                            {
                                if (thisAttributes.ToString() == thing)
                                {
                                    thisCharacter.myAttributes[thisAttributes] = int.Parse(value);                    }
                            }
                            break;
                    }
                }
                else
                {
                    Debug.Log("Symbol : not found");
                }
            }
            break;
        }
        mySR.Close();

    }

}
