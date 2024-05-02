using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace STORYGAME
{

    public class Enums
    {
    
        public enum StoryType
        {
            MAIN,
            SUB,
            SERIAL
        }

        public enum EventType
        {
            NONE,
            GoToBattle = 100,
            CheckSTR = 1000,
            CheckDEX,
            CheckCON,
            CheckINT,
            CheckWIS,
            CheckCHA
        }

        public enum ResultType
        {
            ChangeHp,
            ChangeSp,
            AddExperience = 100,
            GoToShop = 1000,
            GoToNextStory = 2000,
            GoToRandomStroy = 3000,
            GoToEnding = 10000
        }
    }

    [System.Serializable]

    public class Stats
    {
        //체력과 정신력
        public int hpPoint;
        public int spPoint;

        //현재 
        public int currentHpPoint;
        public int currentSpPoint;
        public int currentXpPoint;

        //기본 스탯 설정(Ex D&D)
        public int strength;        //STR 힘
        public int dexterity;       //DEX 민첩
        public int consitiution;    //CON 건강
        public int Intelligence;    //INT 지능
        public int wisdom;          //WIS 지혜
        public int charisma;        //CHA 매력
    }
}