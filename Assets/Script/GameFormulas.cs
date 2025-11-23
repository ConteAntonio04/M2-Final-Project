using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class GameFormulas 
{
    static public bool HasElementAdvantage(ELEMENT attackElement , Hero defender)
    {
        if (attackElement == defender.GetWeakness()) return true;
        else return false;
    }
    static public bool HasElementDisadvantage(ELEMENT attackElement, Hero defender)
    {
        if (attackElement == defender.GetResistance()) return true;
        else return false;
    }
    static public float EvaluateElementalModifier(ELEMENT attackElement, Hero defender)
    {
        if (HasElementAdvantage(attackElement, defender)) return 1.5f;
        else if (HasElementDisadvantage(attackElement, defender)) return 0.5f;
        else return 1;
    }
    static public bool HasHit(Stats attacker, Stats defender)
    {
        int hitChance = attacker.aim - defender.eva;
        int randomNumber = Random.Range(0, 100);
        if (randomNumber > hitChance)
        {
            Debug.Log("MISS");
            return false;
        }
        else return true;
    }
    static public bool IsCrit(int critValue)
    {
        int randomNumber = Random.Range(0, 100);
        if (randomNumber < critValue)
        {
            Debug.Log("CRIT");
            return true;
        }
        else return false;
    }
    static public void AttackTurn(Hero x, Hero y, Stats totalX, Stats totalY)
    {
        if (GameFormulas.HasHit(totalX, totalY))
        {
            if (GameFormulas.HasElementAdvantage(x.GetWeapon().GetElement(), y))
            {
                Debug.Log("WEAKNESS");
            }
            else if (GameFormulas.HasElementDisadvantage(x.GetWeapon().GetElement(), y))
            {
                Debug.Log("RESIST");
            }
            Debug.Log($"Il Danno subito vale: {GameFormulas.CalculateDamage(x, y)}");
            y.TakeDamage(GameFormulas.CalculateDamage(x, y));
            if (!y.IsAlive())
            {
                Debug.Log($"Il Vincitore e' il Giocatore {x.GetName()}");
            }
        }
    }
    static public void Fight(Hero x, Hero y, Stats totalX, Stats totalY)
    {
        Debug.Log($"Il Giocatore {x.GetName()} attacca il Giocatore {y.GetName()}");
        AttackTurn(x, y, totalX, totalY);
        if (y.IsAlive())
        {
            Debug.Log($"Il Giocatore {y.GetName()} attacca il Giocatore {x.GetName()}");
            AttackTurn(y, x, totalY, totalX);
        }
    }
    static public int CalculateDamage(Hero attacker, Hero defender)
    {
        int damage = 0;
        bool critical;
        Stats attackerTotalStats = Stats.Sum(attacker.GetBaseStats() , attacker.GetWeapon().GetStats());
        Stats defenderTotalStats = Stats.Sum(defender.GetBaseStats(), defender.GetWeapon().GetStats());
        if (attacker.GetWeapon().GetDmgType() == Weapon.DAMAGE_TYPE.PHYSICAL)
        {
            damage = attackerTotalStats.atk - defenderTotalStats.def;
        }
        else if (attacker.GetWeapon().GetDmgType() == Weapon.DAMAGE_TYPE.MAGICAL)
        {
            damage = attackerTotalStats.atk - defenderTotalStats.res;
        }

        damage = Mathf.RoundToInt(damage * EvaluateElementalModifier(attacker.GetWeapon().GetElement() , defender));

        if (damage < 0) return 0;
        else if (critical = IsCrit(attacker.GetBaseStats().crt)) return damage * 2;
        else return damage;
    }
}
