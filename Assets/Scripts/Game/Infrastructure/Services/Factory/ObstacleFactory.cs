using Game.Gameplay.Obstacles;
using UnityEngine;

namespace Game.Infrastructure.Services.Factory
{
  public class ObstacleFactory : AbstractFactory<BaseObstacle>
  {
    private readonly CoroutineRunner _runner;
    private Transform _parent;

    private const string TwoLinePath = "Prefabs/Gameplay/Obstacles/TwoLinesObstacle";
    
    public override BaseObstacle Create()
    {
      var prefab = Resources.Load<GameObject>(TwoLinePath);
      return Object.Instantiate(prefab, GetSpawnPosition(), Quaternion.identity, _parent).GetComponent<BaseObstacle>();
    }

    private Vector3 GetSpawnPosition() => 
      new Vector3(15, Random.Range(-2f, 6f), 0);

    public void SetParent(GameObject gameObjectParent) => 
      _parent = gameObjectParent.transform;
  }
}