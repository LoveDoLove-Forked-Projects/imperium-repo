#region

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#endregion

namespace Imperium.Extensions;

public static class EnemySetupExtensions
{
    public static List<PrefabRef> GetSortedSpawnObjects(this EnemySetup enemySetup)
    {
        if (enemySetup == null || enemySetup.spawnObjects == null) return [];

        return enemySetup.spawnObjects.Where(x => x != null).ToList();
    }
}