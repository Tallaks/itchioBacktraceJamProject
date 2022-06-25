using UnityEngine;

namespace Extensions
{
  public static class VectorExtensions
  {
    public static Vector3 SetX(this Vector3 vector, float x) => 
      new Vector3(x, vector.y, vector.z);
    
    public static Vector3 SetY(this Vector3 vector, float y) => 
      new Vector3(vector.x, y, vector.z);

    public static Vector3 SetZ(this Vector3 vector, float z) => 
      new Vector3(vector.x, vector.y, z);
  }
}