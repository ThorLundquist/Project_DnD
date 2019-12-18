using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
 * this tells the engine 
 * that the data in this class 
 * is suitable for writing down 
 * in binary form, or “serializing”.
 */
[Serializable]
public class PlayerStatistics
{
    public int SceneID;
    public string myName;
    public string myRace;
    public string myClass;
    public bool isMale;
    public string portraitString;
    public int points;
    public int Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma;
    int myHP;
    public float PositionX, PositionY, PositionZ;
}