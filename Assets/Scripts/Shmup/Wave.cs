using UnityEngine;
using System.Collections.Generic;

public class Wave
{
    public List<Enemy> enemies;

    public bool IsDead()
    {
        return enemies.Count == 0;
    }
}