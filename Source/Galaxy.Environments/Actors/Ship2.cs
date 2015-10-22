#region using

using System.Timers;
using System;
using System.Diagnostics;
using System.Windows;
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

#endregion

namespace Galaxy.Environments.Actors
{
    public class Ship2 : DethAnimationActor
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

        public Ship2(ILevelInfo info) : base(info)
        {
            Width = 30;
            Height = 30;
            ActorType = ActorType.Enemy;
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

        #region Overrides

        public EnemyBullet CreateEnemyBullet(Ship2 ship)
        {
            var enbullet = new EnemyBullet(Info);
            int positionY = ship.Position.Y + 26;
            int positionX = ship.Position.X + 12;
            enbullet.Position = new Point(positionX, positionY);
            enbullet.Load();
            return enbullet;
        }

        public override void Load()
        {
            Load(@"Assets\ship_2.png");
            if (m_flyTimer == null)
            {
                m_flyTimer = new Stopwatch();
                m_flyTimer.Start();
            }
        }

        #endregion

        #region Private methods

        public void h_changePosition()
        {
            const int Speed = 2;
            if (IsPressed(VirtualKeyStates.Left))
                Position = new Point(Position.X - Speed, Position.Y);
            if (IsPressed(VirtualKeyStates.Right))
                Position = new Point(Position.X + Speed, Position.Y);
        }

        #endregion
    }
}