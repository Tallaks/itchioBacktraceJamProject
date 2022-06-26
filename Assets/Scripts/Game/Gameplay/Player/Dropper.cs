using Game.Infrastructure.Services;
using Game.Infrastructure.Services.Factory;
using UnityEngine;

namespace Game.Gameplay.Player
{
  [RequireComponent(typeof(PlayerEntity))]
  public class Dropper : MonoBehaviour
  {
    private AidFactory _aidFactory;

    private void Awake()
    {
      _aidFactory = AllServices.Instance.Resolve<AidFactory>();
      _aidFactory.AttachToPLayer(GetComponent<PlayerEntity>());
    }


        [SerializeField] private float coolDownTime = 2f;
        private float nextAidDropTime;

    private void Update()
    {
        if (Time.time > nextAidDropTime)
         {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _aidFactory.Create();
                nextAidDropTime = Time.time + coolDownTime;
            }
        }
      
    }
  }
}