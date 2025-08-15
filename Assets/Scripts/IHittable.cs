using UnityEngine;

public interface IHittable
{
    bool isHittable();
    void TakeDMG(float dmg);
}
