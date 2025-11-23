using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public enum DAMAGE_TYPE
    { 
        PHYSICAL,
        MAGICAL
    }

    [SerializeField] private string name;
    [SerializeField] private DAMAGE_TYPE dmgType;
    [SerializeField] private ELEMENT elem;
    [SerializeField] private Stats bonusStats;

    public Weapon(string _name , DAMAGE_TYPE _dmgType , ELEMENT _elem , Stats _bonusStats)
    {
        name = _name;
        dmgType = _dmgType;
        elem = _elem;
        bonusStats = _bonusStats;
    }

    public string GetName() => name;
    public DAMAGE_TYPE GetDmgType() => dmgType;
    public ELEMENT GetElement() => elem;
    public Stats GetStats() => bonusStats;

    public void SetName(string _name) => name = _name;
    
    public void SetDmgType(DAMAGE_TYPE _dmgType) => dmgType = _dmgType;
    
    public void SetElem(ELEMENT _elem) => elem = _elem;
   
    public void SetStats(Stats _bonusStats) => bonusStats = _bonusStats;
    
}
