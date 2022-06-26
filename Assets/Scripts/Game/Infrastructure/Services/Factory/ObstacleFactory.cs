using Game.Gameplay.Obstacles;
using UnityEngine;

namespace Game.Infrastructure.Services.Factory
{
  public class ObstacleFactory : AbstractFactory<BaseObstacle>
  {
    private readonly Vector3 _spawnPosition = new Vector3(15, 0, 0);
    private Transform _parent;

    private const string TwoLinePath = "Prefabs/Gameplay/Obstacles/TwoLinesObstacle";
    
    public override BaseObstacle Create()
    {
      var prefab = Resources.Load<GameObject>(TwoLinePath);
      /*if(prefab.GetComponent<TwoLinesObstacle>())
        prefab.GetComponent<TwoLinesObstacle>().SetDistanceBetweenRects(Random.Range(-1,4));*/
      return Object.Instantiate(prefab, GetSpawnPosition(), Quaternion.identity, _parent).GetComponent<BaseObstacle>();
    }

    private Vector3 GetSpawnPosition() => 
      new Vector3(15, Random.Range(0, 4), 0);

    public void SetParent(GameObject gameObjectParent) => 
      _parent = gameObjectParent.transform;
  }
}