#region using

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Galaxy.Core.Actors;
using Galaxy.Core.Collision;
using Galaxy.Core.Environment;
using Galaxy.Environments.Actors;
using System.Timers;
using System.Threading;

#endregion

namespace Galaxy.Environments

{
  /// <summary>
  ///   The level class for Open Mario.  This will be the first level that the player interacts with.
  /// </summary>
  public class LevelOne : BaseLevel
  {
    private int m_frameCount;

    #region Constructors

    /// <summary>
    ///   Initializes a new instance of the <see cref="LevelOne" /> class.
    /// </summary>
    
    public LevelOne()
    {
      // Backgrounds
      FileName = @"Assets\LevelOne.png";
     
      // Enemies
    //  EnemyBulletKri();
  //    MyTimer();
      for (int i = 0; i < 5; i++)
      {
        var ship = new Ship(this);
        int positionY = ship.Height + 10;
        int positionX = 150 + i * (ship.Width + 50);

        ship.Position = new Point(positionX, positionY);       

        Actors.Add(ship);        
      }
      for (int i = 0; i < 4; i++)
      {
          var ship2 = new Ship_2(this);
          int positionY = ship2.Height + 50;
          int positionX = 170 + i * (ship2.Width + 100);

          ship2.Position = new Point(positionX, positionY);

          Actors.Add(ship2);
      }

      


      for (int i = 0; i < 3; i++)
      {
        var starOfDeathShip = new StarOfDeathShip(this);
        int positionY = starOfDeathShip.Height + 90;
        int positionX = 160 + i * (starOfDeathShip.Width + 120);

        starOfDeathShip.Position = new Point(positionX, positionY);

        Actors.Add(starOfDeathShip);
      }

            // Player            
      Player = new PlayerShip(this);
      int playerPositionX = Size.Width / 2 - Player.Width / 2;
      int playerPositionY = Size.Height - Player.Height - 50;
      Player.Position = new Point(playerPositionX, playerPositionY);
      Actors.Add(Player);
    }

    #endregion

    #region Overrides
      //создание 5и пуль

    //private  void EnemyBulletKri()
    //{
                 
    //        for (int i = 0; i < 4; i++)
    //      {
    //          var EnemyBullet = new EnemyBullet(this);
    //          int positionY = EnemyBullet.Height + 50;
    //          int positionX = 170 + i * (EnemyBullet.Width + 100);
    //          EnemyBullet.Position = new Point(positionX, positionY);
              
    //          Actors.Add(EnemyBullet);

    //      }
                      
                
    // }
    // void MyTimer()
    //{
    //    System.Timers.Timer myTimer = new System.Timers.Timer();
    //    myTimer.Elapsed += new ElapsedEventHandler(Timer_Tick);
    //    myTimer.Interval = 500;
    //    myTimer.Start();
    //}

    //private  void Timer_Tick(object sender, ElapsedEventArgs e)
    //{
    //   EnemyBulletKri();
      
    //}
   
    private void h_dispatchKey()
    {
      if (!IsPressed(VirtualKeyStates.Space)) return;

      if(m_frameCount % 10 != 0) return;

      Bullet bullet = new Bullet(this)
      {
        Position = Player.Position
      };

     
      bullet.Load();
      Actors.Add(bullet);
    }
 
    
    

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>


    public override BaseLevel NextLevel()
    {
      return new StartScreen();
    }

    public override void Update()
    {
      m_frameCount++;
      h_dispatchKey();
     
      base.Update();

      IEnumerable<BaseActor> killedActors = CollisionChecher.GetAllCollisions(Actors);

      foreach (BaseActor killedActor in killedActors)
      {
        if (killedActor.IsAlive)
          killedActor.IsAlive = false;
      }

      List<BaseActor> toRemove = Actors.Where(actor => actor.CanDrop).ToList();
      BaseActor[] actors = new BaseActor[toRemove.Count()];
      toRemove.CopyTo(actors);

      foreach (BaseActor actor in actors.Where(actor => actor.CanDrop))
      {
        Actors.Remove(actor);
      }

      if (Player.CanDrop)
        Failed = true;

      //has no enemy
      if (Actors.All(actor => actor.ActorType != ActorType.Enemy))
        Success = true;
    }

    #endregion
  }
}

