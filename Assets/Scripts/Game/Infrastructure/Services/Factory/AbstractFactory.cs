namespace Game.Infrastructure.Services.Factory
{
  public abstract class AbstractFactory<T> : IService
  {
    public abstract T Create();
  }
}