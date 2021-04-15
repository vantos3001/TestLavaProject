using UnityEngine;

namespace TestLavaProject.Utils
{
    public static class Utils
    {
        public static int EnemyLayer => LayerMask.NameToLayer("Enemy");
        public static int ShootAreaLayerMask => LayerMask.GetMask("ShootArea");
        
        public static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}