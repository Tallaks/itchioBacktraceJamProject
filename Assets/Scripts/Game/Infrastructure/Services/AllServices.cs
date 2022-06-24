using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Infrastructure.Services
{
  public class AllServices
  {
    public static AllServices Instance;

    public static void Initialize() => 
      Instance = new AllServices();

    private List<IService> _services = new List<IService>();

    public void RegisterService(IService newService)
    {
      if(!_services.Select(k => k.GetType()).Contains(newService.GetType()))
        _services.Add(newService);
      else
        Debug.LogWarning($"Service of type {newService.GetType()} is already registered!");
    }

    public T Resolve<T>() where T: IService => 
      (T)_services.First(k => k.GetType() == typeof(T));
  }
}