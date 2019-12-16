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

        mySW.WriteLine("HP:");

        mySW.Flush();
        mySW.Close();
    }

    public void LoadCharacter(string name)
    {
        name = "Test1";
        fileName = filePath + name + ".txt";
        Debug.Log("Filename is: " + fileName);
        if (!File.Exists(fileName))
        {
            Debug.Log("File not found");
            return;
        }

        StreamReader mySR = new StreamReader(fileName);

        CharacterGenerator thisCharacter = GetComponent<CharacterGenerator>();

        string input = mySR.ReadLine();

        while (input != null || input == "")
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
                        thisCharacter.myName = value;
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
                                thisCharacter.myClass = thisClass;
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
                        GetComponent<UIHandler>().UpdateUI(false);
                        break;
                    case "HP":
                        break;
                    default:
                        foreach (CharacterAttributes.BaseAttributes thisAttribute in System.Enum.GetValues(typeof(CharacterAttributes.BaseAttributes)))
                        {
                            if (thisAttribute.ToString() == thing)
                            {
                                thisCharacter.myAttributes[thisAttribute] = int.Parse(value);
                            }
                        }
                        break;
                }
            }
            else
            {
                Debug.Log("Symbol : not found");
            }
            input = mySR.ReadLine();
        }
        mySR.Close();
    }

}
