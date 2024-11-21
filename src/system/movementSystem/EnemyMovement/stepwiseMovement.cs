using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class StepwiseMovement : IMovementStrategy
    {
        private float _StepSize;
        private float _TimeSinceLastStep;
        private float _StepInterval;

        public StepwiseMovement(float stepSize, float stepInterval)
        {
            _StepSize = stepSize;
            _StepInterval = stepInterval;
            _TimeSinceLastStep = 0;
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            _TimeSinceLastStep += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_TimeSinceLastStep >= _StepInterval)
            {
                position.Y += _StepSize;
                _TimeSinceLastStep = 0;
            }
            return position;
        }
    }

}
