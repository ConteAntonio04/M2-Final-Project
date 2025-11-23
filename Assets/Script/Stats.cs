using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Stats
{
    public int atk;
    public int def;
    public int res;
    public int spd;
    public int crt;
    public int aim;
    public int eva;

    public Stats(int _atk ,  int _def , int _res , int _spd , int _crt , int _aim , int _eva)
    {
        atk = _atk;
        def = _def;
        res = _res;
        spd = _spd;
        crt = _crt;
        aim = _aim;
        eva = _eva;
    }

     public static Stats Sum(Stats a , Stats b)
    {
        Stats c;
        c.atk = a.atk + b.atk;
        c.def = a.def + b.def;
        c.res = a.res + b.res;
        c.spd = a.spd + b.spd;
        c.crt = a.crt + b.crt;
        c.aim = a.aim + b.aim;
        c.eva = a.eva + b.eva;
        return c;
    }
}
