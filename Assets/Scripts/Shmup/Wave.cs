using UnityEngine;
using System.Collections.Generic;

public class Wave {
    public List<Enemy> enemies;

    public bool IsDead() {
        return enemies.Count == 0;
/*        foreach(Enemy enemy in enemies) {
            if (enemy.) {
                return false;
            }
        }
        return true;*/
    }
}