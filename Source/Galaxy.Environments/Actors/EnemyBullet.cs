using System.Drawing;
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;
using System.Diagnostics;

namespace Galaxy.Environments.Actors
{
    public class EnemyBullet : BaseActor
    {
        #region Constant

        private static int Speed = 5;

        #endregion

        #region Constructors

        public EnemyBullet(ILevelInfo info)
            : base(info)
        {
            Width = 5;
            Height = 10;
            ActorType = ActorType.Enemy;
        }

        #endregion

        #region Overrides

        public override void Load()
        {
            Load(@"Assets\bullet_2.png");
        }

        public override void Update()
        {
            Position = new Point(Position.X, Position.Y + Speed);
        }

        #endregion
    }
}