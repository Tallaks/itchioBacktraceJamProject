using Game.Gameplay.Targets;
using UnityEngine;

namespace Game.Infrastructure.Services.Factory
{
  public class TargetFactory : AbstractFactory<Target>
  {
    private const string TargetPath = "Prefabs/Gameplay/Target";

    private Transform _parent;

    public override Target Create()
    {
      var prefab = Resources.Load<GameObject>(TargetPath);
      return Object.Instantiate(prefab, GetSpawnPosition(), Quaternion.identity, _parent).GetComponent<Target>();
    }

    public void SetParent(GameObject gameObject) => 
      _parent = gameObject.transform;

    private Vector3 GetSpawnPosition() => 
      new Vector3(15, -5, 0);
  }
}