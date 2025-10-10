using UnityEngine;

public static class GlobalCrystalHelper
{

    public static string GenerateUniqueID(GameObject obj)
    {
        //Makes unique ID for crystal
        return $"{obj.scene.name}_{obj.transform.position.x}_{obj.transform.position.y}";
    }
}
