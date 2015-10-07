using System.Drawing;
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;


namespace Galaxy.Environments.Actors
{
    public class EnemyBullet : BaseActor
    {
    #region Constant

    private const int Speed = 7;

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

        //смещение кораблей
   //   if (IsPressed(VirtualKeyStates.Left))
   //       Position = new Point(Position.X - Speed, Position.Y );
   //   if (IsPressed(VirtualKeyStates.Right))
   //       Position = new Point(Position.X + Speed, Position.Y );
   //   Position = new Point((int)(Position.X), (int)(Position.Y + 1));
    }
    
    #endregion
  }
}