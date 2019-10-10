using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileIO : MonoBehaviour
{
    CharacterGenerator thisCharacter;
    string filePath = "Assets\\Resources\\Character\\";
    string fileName;

    public void SaveCharacter(string name)
    {
        fileName = filePath + name + ".txt";
        StreamWriter mySW = new StreamWriter(fileName);
        //grab reference to the current character generation
        CharacterGenerator thisCharacter = GetComponent<CharacterGenerator>();
        //basic population of output file
        mySW.WriteLine("Name: " + name);
        mySW.WriteLine("Gender: " + thisCharacter.isMale);
        mySW.WriteLine("Race: " + thisCharacter.myRace.ToString());
        mySW.WriteLine("Class: " + thisCharacter.myClass.ToString());
        mySW.WriteLine("Portrait: " + thisCharacter.myPortrait.ToString());

        foreach (CharacterAttributes.BaseAttributes thisAttributes in System.Enum.GetValues(typeof(CharacterAttributes.BaseAttributes)))
        {
            mySW.WriteLine(thisAttributes.ToString() + ": " + thisCharacter.myAttributes[thisAttributes]);
        }

        mySW.WriteLine("HP: ");

        mySW.Flush();
        mySW.Close();
    }

    public void LoadCharacter()
    {

    }

}
