using Game.Gameplay.Targets;
using UnityEngine;

namespace Game.Infrastructure.Services.Factory
{
  public class TargetFactory : AbstractFactory<Target>
  {
    private const string TargetPath = "Prefabs/Target";

    public override Target Create()
    {
      var prefab = Resources.Load<GameObject>(TargetPath);
      return Object.Instantiate(prefab, GetSpawnPosition(), Quaternion.identity).GetComponent<Target>();
    }

    private Vector3 GetSpawnPosition() => 
      new Vector3(15, -5, 0);
  }
}