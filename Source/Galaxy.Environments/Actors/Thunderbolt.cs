using System;
using System.Diagnostics;
using System.Windows;
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace Galaxy.Environments.Actors
{
   public  class Thunderbolt: DethAnimationActor
    {
         #region Constant

        private const int MaxSpeed = 3;
        private const long StartFlyMs = 10;

        #endregion

        #region Private fields

        private bool m_flying;
        private Stopwatch m_flyTimer;

        #endregion

        #region Constructors

        public Thunderbolt(ILevelInfo info) : base(info)
        {
            Width = 30;
            Height = 30;
            ActorType = ActorType.Thunderbolt;
        }

        #endregion

        public override void Update()
        {
            base.Update();

            if (!IsAlive)
                return;

            if (!m_flying)
            {
                if (m_flyTimer.ElapsedMilliseconds <= StartFlyMs) return;

                m_flyTimer.Stop();
                m_flyTimer = null;
                h_changePosition();
                m_flying = true;
            }
            else
            {
                h_changePosition();
            }
        }

        public override void Load()
        {
            Load(@"Assets\Thunderbolt.gif");
            if (m_flyTimer == null)
            {
                m_flyTimer = new Stopwatch();
                m_flyTimer.Start();
            }
        }

        #region Private methods

       
       public void h_changePosition()
       {
           var datetime = DateTime.Now.Second;
           var datetime2 = DateTime.Now.Second;
           if (datetime > 20 )
               datetime = datetime*(-1);
           if (datetime < 29)
               datetime = datetime * (1);
          
           if (datetime2 % 2 == 0)
               datetime2 = datetime2 * (-1);
           if (datetime % 10 == 0)
               datetime2 = datetime2 * (1);


               Position = new Point(Position.X - datetime/10, Position.Y + datetime2/10);
                
        }

        #endregion
    }
    }

