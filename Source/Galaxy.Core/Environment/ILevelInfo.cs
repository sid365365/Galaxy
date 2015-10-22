using System.Drawing;
using Galaxy.Core.Actors;


namespace Galaxy.Core.Environment
{
    public interface ILevelInfo
    {
        Point GetPlayerPosition();
        Size GetLevelSize();
        void AddBullet(BaseActor pEnemyBullet);
    }
}