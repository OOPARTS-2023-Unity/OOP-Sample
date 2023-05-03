using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasHP
{
    void LoseHP(int damage);
    void RecoverHP(int cure);
}
