using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Hero
{
    [SerializeField] private string name;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private ELEMENT resistance;
    [SerializeField] private ELEMENT weakness;
    [SerializeField] private Weapon weapon;

    public Hero(string _name , int _hp , Stats _baseStats , ELEMENT _resistance , ELEMENT _weakness , Weapon _weapon)
    {
        name = _name;
        hp = _hp;
        baseStats = _baseStats;
        resistance = _resistance;
        weakness = _weakness;
        weapon = _weapon;
    }

    public string GetName() => name;
    public int GetHP() => hp;
    public Stats GetBaseStats() => baseStats;
    public ELEMENT GetResistance() => resistance;
    public ELEMENT GetWeakness() => weakness;
    public Weapon GetWeapon() => weapon;

    public void SetName(string _name) => name = _name;
   
    public void SetHp(int _hp) => hp = Mathf.Max(0, _hp);
    public void SetBaseStats(Stats _baseStats) => baseStats = _baseStats;
    
    public void SetResistance(ELEMENT _resistance) => resistance = _resistance;
    
    public void SetWeakness(ELEMENT _weakness) => weakness = _weakness;
   
    public void SetWeapon(Weapon _weapon) => weapon = _weapon;
    
    public void AddHp (int amount)
    {
        SetHp (hp + amount);
    }
    public void TakeDamage(int damage)
    {
        AddHp (- damage);
    }
    public bool IsAlive()
    {
        if (hp > 0) return true;
        else return false;
    }
}
